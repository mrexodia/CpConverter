//Copyright 2007 - 2011 John Church
//
//This file is part of CpConverter.
//CpConverter is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.
//
//CpConverter is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.
//
//You should have received a copy of the GNU General Public License
//along with CpConverter.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CpConverter
{
    /// <summary>
    /// Main form class
    /// </summary>
    public partial class MainForm : Form
    {
    #region "Private variables"
        //filenames to convert
        private string[] _sourceFiles = null;
        //ouput directory
        private string destDir = null;
    #endregion

    #region "Constructors"
        /// <summary>
        /// Main form constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            //load the encodings into the combos
            loadEncodings();
        }
    #endregion

    #region "Event Handlers"
        /// <summary>
        /// Handle the Exit button click event
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// Handle the open file menu click event
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //set up the open file dialog
            openFile.Multiselect = true;
            openFile.Filter = "All files (*.*)|*.*";
            openFile.FilterIndex = 0;
            openFile.ShowDialog();
            //get the filenames
            _sourceFiles = openFile.FileNames;
            string filename;
            foreach(string s in _sourceFiles)
            {
                //add the filesnames to the list box
                //john church 05/10/2008 use directory separator char instead of backslash for linux support
                filename = s.Substring(s.LastIndexOf(System.IO.Path.DirectorySeparatorChar) + 1);
                lsSource.Items.Add(filename);
            }
            //display the message
            txtMessages.Text = txtMessages.Text.Insert(0, _sourceFiles.Length + " file(s) selected for conversion" + System.Environment.NewLine);
            //validate the run button
            validateForRun();
        }

        /// <summary>
        /// Handler for the combo change event
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void cmbSourceEnc_SelectedIndexChanged(object sender, EventArgs e)
        {
            validateForRun();
            buildEncodingInfo(cmbSourceEnc.SelectedItem.ToString(), txtSourceEnc);
        }

        /// <summary>
        /// Handler for the combo change event
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void cmbDestEnc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s;
            int destCP;

            validateForRun();
            buildEncodingInfo(cmbDestEnc.SelectedItem.ToString(), txtDestEnc);

            s = cmbDestEnc.SelectedItem.ToString();
            destCP = int.Parse(s.Substring(s.LastIndexOf(" ") + 1));

            switch (Encoding.GetEncoding(destCP).CodePage)
            {
                case 1200 : cmbBOMType.SelectedIndex = 2; break;
                case 1201 : cmbBOMType.SelectedIndex = 3; break;
                case 12000: cmbBOMType.SelectedIndex = 4; break;
                case 12001: cmbBOMType.SelectedIndex = 5; break;
                case 54936: cmbBOMType.SelectedIndex = 9; break;
                case 65000: cmbBOMType.SelectedIndex =10; break;
                case 65001: cmbBOMType.SelectedIndex = 1; break;
                default:
                    if (cmbDestEnc.SelectedItem.ToString().IndexOf("EBCDIC") > 0)
                    {
                        cmbBOMType.SelectedIndex = 6;
                    }
                    else if (cmbDestEnc.SelectedItem.ToString().IndexOf("SCSU") > 0)
                    {
                        cmbBOMType.SelectedIndex = 7;
                    }
                    else if (cmbDestEnc.SelectedItem.ToString().IndexOf("BOCU") > 0)
                    {
                        cmbBOMType.SelectedIndex = 8;
                    }
                    else
                    {
                        cmbBOMType.SelectedIndex = 0;
                    }
                    break;
            }
        }
    #endregion
        
    #region "Run the conversion"
        /// <summary>
        /// Handler for the run button click event
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void btnRun_Click(object sender, EventArgs e)
        {
            int sourceCP, destCP, iSuccess = 0;
            string s, res;
            byte[] BOM = { };
            Converter.SpecialTypes specialType = Converter.SpecialTypes.None;

            //03/05/2007 tidy up the UI
            btnRun.Enabled = false;
            this.Cursor = Cursors.WaitCursor;

            try
            {
                // get the conversion codepages
                s = cmbSourceEnc.SelectedItem.ToString();
                sourceCP = int.Parse(s.Substring(s.LastIndexOf(" ") + 1));
                s = cmbDestEnc.SelectedItem.ToString();
                destCP = int.Parse(s.Substring(s.LastIndexOf(" ") + 1));

                // check for special options
                if (chkUnicodeAsDecimal.Checked == true)  specialType = Converter.SpecialTypes.UnicodeAsDecimal;

                /*
                02/05/2007 need to write first two bytes when saving as unicode
                11/08/2014 A.D. Yes, this is called Byte Order Mark (BOM). It needs to be written to the beginning of the file/stream
                                and not only for codepage 1200. BOM could be 2, 3, or 4 bytes long (see wikipedia).
                                Code that handled CP1200 is moved from Converter.cs to here because it nedds to be expanded and reorganized
                                for more flexibility. Now, all logic is done here and only byte array "BOM" is passed to ConvertFile().
                                Also, whether or not to add BOM and its type is up to the user.
                */
                // BOM needs to be added?
                // Codepage can be obtained from here: Encoding.GetEncoding(destCP).CodePage
                switch (cmbBOMType.SelectedItem.ToString())
                {
                    case "none":
                        break;
                    case "UTF-8":
                        BOM = new byte[] { (byte)0xEF, (byte)0xBB, (byte)0xBF };    // 239, 187, 191
                        break;
                    case "UTF-16 (LE)":
                        BOM = new byte[] { (byte)0xFF, (byte)0xFE };                // 255, 254
                        break;
                    case "UTF-16 (BE)":
                        BOM = new byte[] { (byte)0xFE, (byte)0xFF };                // 254, 255
                        break;
                    case "UTF-32 (LE)":
                        BOM = new byte[] { (byte)0xFF, (byte)0xFE, (byte)0x00, (byte)0x00 };    // 255, 254, 0, 0
                        break;
                    case "UTF-32 (BE)":
                        BOM = new byte[] { (byte)0x00, (byte)0x00, (byte)0xFE, (byte)0xFF };    // 0, 0, 254, 255
                        break;
                    case "UTF-EBCDIC":
                        BOM = new byte[] { (byte)0xDD, (byte)0x73, (byte)0x66, (byte)0x73 };    // 221, 115, 102, 115
                        break;
                    case "SCSU":
                        BOM = new byte[] { (byte)0x0E, (byte)0xFE, (byte)0xFF };    // 14, 254, 255
                        break;
                    case "BOCU-1":
                        BOM = new byte[] { (byte)0xFB, (byte)0xEE, (byte)0x28 };    // 251, 238, 40
                        break;
                    case "GB-18030":
                        BOM = new byte[] { (byte)0x84, (byte)0x31, (byte)0x95, (byte)0x33 };    // 132, 49, 149, 51
                        break;
                    case "UTF-7":
                        BOM = new byte[] { (byte)0x2B, (byte)0x2F, (byte)0x76, (byte)0x38 };    // 43, 47, 118, 56  (there are more of UTF-7 BOM's - no expl. on usage)
                        break;
                }

                //convert each file
                for (int i = 0; i < _sourceFiles.Length; i++)
                {
                    //display some information about the file
                    s = lsSource.Items[i].ToString();
                    txtMessages.Text = txtMessages.Text.Insert(0, "Converting " + (i + 1).ToString()
                                        + " of " + _sourceFiles.Length + System.Environment.NewLine);

                    //do the conversion
                    if(Converter.ConvertFile(_sourceFiles[i], destDir, sourceCP, destCP, specialType, chkMeta.Checked, BOM))
                    {
                        //success
                        res = char.ConvertFromUtf32(9745);
                        iSuccess++;
                    }
                    else
                    {
                        //error
                        res = char.ConvertFromUtf32(9746);
                    }
                    //output some info
                    lsSource.Items[i] = res + " " + s;
                    //update the progress bar
                    //03/05/2007 cast values as double and convert back to int
                    progFiles.Value = (int)((double)(i + 1) / (double)_sourceFiles.Length * 100);
                }
                //display the final message
                txtMessages.Text = txtMessages.Text.Insert(0, iSuccess.ToString()
                            + " file(s) converted successfully and output to:" +
                            System.Environment.NewLine + destDir + System.Environment.NewLine);
            }
            catch (Exception ex)
            {
                //just show the error
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //03/05/2007 tidy up
                btnRun.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }
    #endregion

    #region "Private Methods"
        /// <summary>
        /// Show some info about the currently selected codepage
        /// </summary>
        /// <param name="s">String - The selected encoding</param>
        /// <param name="t">The textbox to fill</param>
        private void buildEncodingInfo(string s, TextBox t)
        {
            //get the codepage number
            int cp = int.Parse(s.Substring(s.LastIndexOf(" ") + 1));
            //get the encoding
            Encoding enc = Encoding.GetEncoding(cp);
            StringBuilder sb = new StringBuilder();
            if (enc != null)
            {
                //build up some information
                sb.Append("WebName: " + enc.WebName + Environment.NewLine);
                sb.Append("Copdepage: " + enc.CodePage.ToString() + Environment.NewLine);
                if (enc.IsSingleByte == true)
                    sb.Append("Single Byte Charset");
                else
                    sb.Append("Multi Byte Charset");
            }
            //output it to the textbox
            t.Text = sb.ToString();
        }

        /// <summary>
        /// Can we run the conversion
        /// </summary>
        private void validateForRun()
        {
            if (_sourceFiles != null)
            {
                //enable / disable the run button
                btnRun.Enabled = _sourceFiles.Length > 0
                            && cmbSourceEnc.SelectedIndex >= 0
                            && cmbDestEnc.SelectedIndex >= 0;
                //set the info about the destination directory
                if (_sourceFiles.Length > 0 && cmbDestEnc.SelectedIndex >= 0)
                {
                    //john church 05/10/2008 use directory separator char instead of backslash for linux support
                    destDir = _sourceFiles[0].Substring(0, _sourceFiles[0].LastIndexOf(System.IO.Path.DirectorySeparatorChar) + 1) + cmbDestEnc.SelectedItem.ToString() + System.IO.Path.DirectorySeparatorChar;
                    txtMessages.Text = "Converted files will be output to:"
                                + System.Environment.NewLine + destDir
                                + System.Environment.NewLine + _sourceFiles.Length
                                + " file(s) selected for conversion" + System.Environment.NewLine;
                }
            }

        }

        /// <summary>
        /// Populate the combos
        /// </summary>
        private void loadEncodings()
        {
            Encoding enc;
            string s;
            cmbDestEnc.Items.Clear();
            cmbSourceEnc.Items.Clear();
            //loop through all the encodings on the system
            foreach (EncodingInfo en in Encoding.GetEncodings())
            {
                enc = en.GetEncoding();
                //build a string containing the name and codepage number
                s = enc.EncodingName + " - " + enc.CodePage.ToString();
                //add it to the combos
                cmbSourceEnc.Items.Add(s);
                cmbDestEnc.Items.Add(s);
            }
            //sort them alphabetically
            cmbDestEnc.Sorted = true;
            cmbSourceEnc.Sorted = true;
        }
    #endregion

        private void lsSource_KeyDown(object sender, KeyEventArgs e)
        {
            int i;
            if (e.KeyValue == 46)
            {
                i = lsSource.SelectedIndex;
                lsSource.Items.RemoveAt(i);
                if (i < lsSource.Items.Count )
                {
                    lsSource.SelectedIndex = i;
                }
                else
                {
                    lsSource.SelectedIndex = i - 1;
                }
            }
        }

    }
}