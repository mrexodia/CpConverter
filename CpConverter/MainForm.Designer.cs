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

namespace CpConverter
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnExit = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.progFiles = new System.Windows.Forms.ProgressBar();
            this.txtMessages = new System.Windows.Forms.TextBox();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.grpSource = new System.Windows.Forms.GroupBox();
            this.lsSource = new System.Windows.Forms.ListBox();
            this.grpEncodings = new System.Windows.Forms.GroupBox();
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.chkUnicodeAsDecimal = new System.Windows.Forms.CheckBox();
            this.chkMeta = new System.Windows.Forms.CheckBox();
            this.txtDestEnc = new System.Windows.Forms.TextBox();
            this.txtSourceEnc = new System.Windows.Forms.TextBox();
            this.labDestEnc = new System.Windows.Forms.Label();
            this.cmbDestEnc = new System.Windows.Forms.ComboBox();
            this.cmbSourceEnc = new System.Windows.Forms.ComboBox();
            this.labSourceEnc = new System.Windows.Forms.Label();
            this.menuMain.SuspendLayout();
            this.grpSource.SuspendLayout();
            this.grpEncodings.SuspendLayout();
            this.grpOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(541, 458);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnRun
            // 
            this.btnRun.Enabled = false;
            this.btnRun.Location = new System.Drawing.Point(451, 458);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // progFiles
            // 
            this.progFiles.Location = new System.Drawing.Point(12, 458);
            this.progFiles.Name = "progFiles";
            this.progFiles.Size = new System.Drawing.Size(424, 23);
            this.progFiles.TabIndex = 2;
            // 
            // txtMessages
            // 
            this.txtMessages.Location = new System.Drawing.Point(12, 349);
            this.txtMessages.Multiline = true;
            this.txtMessages.Name = "txtMessages";
            this.txtMessages.ReadOnly = true;
            this.txtMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessages.Size = new System.Drawing.Size(604, 93);
            this.txtMessages.TabIndex = 3;
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(628, 24);
            this.menuMain.TabIndex = 4;
            this.menuMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // openFile
            // 
            this.openFile.FileName = "openFileDialog1";
            // 
            // grpSource
            // 
            this.grpSource.Controls.Add(this.lsSource);
            this.grpSource.Location = new System.Drawing.Point(13, 28);
            this.grpSource.Name = "grpSource";
            this.grpSource.Size = new System.Drawing.Size(229, 307);
            this.grpSource.TabIndex = 5;
            this.grpSource.TabStop = false;
            this.grpSource.Text = "Source files";
            // 
            // lsSource
            // 
            this.lsSource.FormattingEnabled = true;
            this.lsSource.Location = new System.Drawing.Point(6, 19);
            this.lsSource.Name = "lsSource";
            this.lsSource.Size = new System.Drawing.Size(217, 277);
            this.lsSource.TabIndex = 7;
            // 
            // grpEncodings
            // 
            this.grpEncodings.Controls.Add(this.grpOptions);
            this.grpEncodings.Controls.Add(this.txtDestEnc);
            this.grpEncodings.Controls.Add(this.txtSourceEnc);
            this.grpEncodings.Controls.Add(this.labDestEnc);
            this.grpEncodings.Controls.Add(this.cmbDestEnc);
            this.grpEncodings.Controls.Add(this.cmbSourceEnc);
            this.grpEncodings.Controls.Add(this.labSourceEnc);
            this.grpEncodings.Location = new System.Drawing.Point(248, 28);
            this.grpEncodings.Name = "grpEncodings";
            this.grpEncodings.Size = new System.Drawing.Size(368, 307);
            this.grpEncodings.TabIndex = 6;
            this.grpEncodings.TabStop = false;
            this.grpEncodings.Text = "Encodings";
            // 
            // grpOptions
            // 
            this.grpOptions.Controls.Add(this.chkUnicodeAsDecimal);
            this.grpOptions.Controls.Add(this.chkMeta);
            this.grpOptions.Location = new System.Drawing.Point(10, 216);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(342, 85);
            this.grpOptions.TabIndex = 7;
            this.grpOptions.TabStop = false;
            this.grpOptions.Text = "Special Options";
            // 
            // chkUnicodeAsDecimal
            // 
            this.chkUnicodeAsDecimal.AutoSize = true;
            this.chkUnicodeAsDecimal.Location = new System.Drawing.Point(7, 43);
            this.chkUnicodeAsDecimal.Name = "chkUnicodeAsDecimal";
            this.chkUnicodeAsDecimal.Size = new System.Drawing.Size(219, 17);
            this.chkUnicodeAsDecimal.TabIndex = 8;
            this.chkUnicodeAsDecimal.Text = "Source Unicode Decimals (e.g. &&#1075;)";
            this.chkUnicodeAsDecimal.UseVisualStyleBackColor = true;
            // 
            // chkMeta
            // 
            this.chkMeta.AutoSize = true;
            this.chkMeta.Location = new System.Drawing.Point(6, 19);
            this.chkMeta.Name = "chkMeta";
            this.chkMeta.Size = new System.Drawing.Size(106, 17);
            this.chkMeta.TabIndex = 7;
            this.chkMeta.Text = "Output Metadata";
            this.chkMeta.UseVisualStyleBackColor = true;
            // 
            // txtDestEnc
            // 
            this.txtDestEnc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDestEnc.Location = new System.Drawing.Point(73, 150);
            this.txtDestEnc.Multiline = true;
            this.txtDestEnc.Name = "txtDestEnc";
            this.txtDestEnc.ReadOnly = true;
            this.txtDestEnc.Size = new System.Drawing.Size(279, 60);
            this.txtDestEnc.TabIndex = 5;
            // 
            // txtSourceEnc
            // 
            this.txtSourceEnc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSourceEnc.Location = new System.Drawing.Point(73, 57);
            this.txtSourceEnc.Multiline = true;
            this.txtSourceEnc.Name = "txtSourceEnc";
            this.txtSourceEnc.ReadOnly = true;
            this.txtSourceEnc.Size = new System.Drawing.Size(279, 60);
            this.txtSourceEnc.TabIndex = 4;
            // 
            // labDestEnc
            // 
            this.labDestEnc.AutoSize = true;
            this.labDestEnc.Location = new System.Drawing.Point(7, 126);
            this.labDestEnc.Name = "labDestEnc";
            this.labDestEnc.Size = new System.Drawing.Size(60, 13);
            this.labDestEnc.TabIndex = 3;
            this.labDestEnc.Text = "Destination";
            // 
            // cmbDestEnc
            // 
            this.cmbDestEnc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDestEnc.FormattingEnabled = true;
            this.cmbDestEnc.Location = new System.Drawing.Point(73, 123);
            this.cmbDestEnc.Name = "cmbDestEnc";
            this.cmbDestEnc.Size = new System.Drawing.Size(279, 21);
            this.cmbDestEnc.TabIndex = 2;
            this.cmbDestEnc.SelectedIndexChanged += new System.EventHandler(this.cmbDestEnc_SelectedIndexChanged);
            // 
            // cmbSourceEnc
            // 
            this.cmbSourceEnc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSourceEnc.FormattingEnabled = true;
            this.cmbSourceEnc.Location = new System.Drawing.Point(73, 30);
            this.cmbSourceEnc.Name = "cmbSourceEnc";
            this.cmbSourceEnc.Size = new System.Drawing.Size(279, 21);
            this.cmbSourceEnc.TabIndex = 1;
            this.cmbSourceEnc.SelectedIndexChanged += new System.EventHandler(this.cmbSourceEnc_SelectedIndexChanged);
            // 
            // labSourceEnc
            // 
            this.labSourceEnc.AutoSize = true;
            this.labSourceEnc.Location = new System.Drawing.Point(6, 33);
            this.labSourceEnc.Name = "labSourceEnc";
            this.labSourceEnc.Size = new System.Drawing.Size(41, 13);
            this.labSourceEnc.TabIndex = 0;
            this.labSourceEnc.Text = "Source";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(628, 493);
            this.Controls.Add(this.grpEncodings);
            this.Controls.Add(this.grpSource);
            this.Controls.Add(this.txtMessages);
            this.Controls.Add(this.progFiles);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.menuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuMain;
            this.Name = "MainForm";
            this.Text = "Cp Converter";
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.grpSource.ResumeLayout(false);
            this.grpEncodings.ResumeLayout(false);
            this.grpEncodings.PerformLayout();
            this.grpOptions.ResumeLayout(false);
            this.grpOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.ProgressBar progFiles;
        private System.Windows.Forms.TextBox txtMessages;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.GroupBox grpSource;
        private System.Windows.Forms.ListBox lsSource;
        private System.Windows.Forms.GroupBox grpEncodings;
        private System.Windows.Forms.ComboBox cmbDestEnc;
        private System.Windows.Forms.ComboBox cmbSourceEnc;
        private System.Windows.Forms.Label labSourceEnc;
        private System.Windows.Forms.TextBox txtDestEnc;
        private System.Windows.Forms.TextBox txtSourceEnc;
        private System.Windows.Forms.Label labDestEnc;
        private System.Windows.Forms.GroupBox grpOptions;
        private System.Windows.Forms.CheckBox chkMeta;
        private System.Windows.Forms.CheckBox chkUnicodeAsDecimal;
    }
}