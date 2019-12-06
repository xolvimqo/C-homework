namespace WindowsFormsFinalProject
{
    partial class FormResumaManager
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.InfoPage = new System.Windows.Forms.TabPage();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtboxEmail = new System.Windows.Forms.TextBox();
            this.txtboxPhoneNumber = new System.Windows.Forms.TextBox();
            this.txtboxLastName = new System.Windows.Forms.TextBox();
            this.txtboxFirstName = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.EducationPage = new System.Windows.Forms.TabPage();
            this.btnDeleteEducation = new System.Windows.Forms.Button();
            this.listboxEducation = new System.Windows.Forms.ListBox();
            this.txtboxDegree = new System.Windows.Forms.TextBox();
            this.txtboxProgram = new System.Windows.Forms.TextBox();
            this.txtboxSchool = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddEducation = new System.Windows.Forms.Button();
            this.WorkHistoryPage = new System.Windows.Forms.TabPage();
            this.numericUpDownYears = new System.Windows.Forms.NumericUpDown();
            this.btnDeleteWorkHistory = new System.Windows.Forms.Button();
            this.listboxWorkHistory = new System.Windows.Forms.ListBox();
            this.txtboxPosition = new System.Windows.Forms.TextBox();
            this.txtboxCompany = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAddWorkHistory = new System.Windows.Forms.Button();
            this.InputOutputPage = new System.Windows.Forms.TabPage();
            this.btnFileBrowser = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.txtboxImport = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.txtboxFileDirectory = new System.Windows.Forms.TextBox();
            this.btnFolderBrowser = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.InfoPage.SuspendLayout();
            this.EducationPage.SuspendLayout();
            this.WorkHistoryPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYears)).BeginInit();
            this.InputOutputPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.InfoPage);
            this.tabControl1.Controls.Add(this.EducationPage);
            this.tabControl1.Controls.Add(this.WorkHistoryPage);
            this.tabControl1.Controls.Add(this.InputOutputPage);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(394, 279);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.FormResumaManager_Load);
            // 
            // InfoPage
            // 
            this.InfoPage.Controls.Add(this.btnReset);
            this.InfoPage.Controls.Add(this.btnSave);
            this.InfoPage.Controls.Add(this.txtboxEmail);
            this.InfoPage.Controls.Add(this.txtboxPhoneNumber);
            this.InfoPage.Controls.Add(this.txtboxLastName);
            this.InfoPage.Controls.Add(this.txtboxFirstName);
            this.InfoPage.Controls.Add(this.lblEmail);
            this.InfoPage.Controls.Add(this.lblPhoneNumber);
            this.InfoPage.Controls.Add(this.lblLastName);
            this.InfoPage.Controls.Add(this.lblFirstName);
            this.InfoPage.Location = new System.Drawing.Point(4, 25);
            this.InfoPage.Name = "InfoPage";
            this.InfoPage.Padding = new System.Windows.Forms.Padding(3);
            this.InfoPage.Size = new System.Drawing.Size(386, 250);
            this.InfoPage.TabIndex = 0;
            this.InfoPage.Text = "Info";
            this.InfoPage.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(267, 202);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 9;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(23, 202);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtboxEmail
            // 
            this.txtboxEmail.Location = new System.Drawing.Point(138, 151);
            this.txtboxEmail.Name = "txtboxEmail";
            this.txtboxEmail.ReadOnly = true;
            this.txtboxEmail.Size = new System.Drawing.Size(204, 22);
            this.txtboxEmail.TabIndex = 7;
            // 
            // txtboxPhoneNumber
            // 
            this.txtboxPhoneNumber.Location = new System.Drawing.Point(138, 104);
            this.txtboxPhoneNumber.Name = "txtboxPhoneNumber";
            this.txtboxPhoneNumber.Size = new System.Drawing.Size(204, 22);
            this.txtboxPhoneNumber.TabIndex = 6;
            this.txtboxPhoneNumber.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtboxPhoneNumber_MouseClick);
            // 
            // txtboxLastName
            // 
            this.txtboxLastName.Location = new System.Drawing.Point(138, 57);
            this.txtboxLastName.Name = "txtboxLastName";
            this.txtboxLastName.Size = new System.Drawing.Size(204, 22);
            this.txtboxLastName.TabIndex = 5;
            this.txtboxLastName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtboxLastName_MouseClick);
            // 
            // txtboxFirstName
            // 
            this.txtboxFirstName.Location = new System.Drawing.Point(138, 13);
            this.txtboxFirstName.Name = "txtboxFirstName";
            this.txtboxFirstName.Size = new System.Drawing.Size(204, 22);
            this.txtboxFirstName.TabIndex = 4;
            this.txtboxFirstName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtboxFirstName_MouseClick);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(20, 156);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(42, 17);
            this.lblEmail.TabIndex = 3;
            this.lblEmail.Text = "Email";
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Location = new System.Drawing.Point(20, 109);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(103, 17);
            this.lblPhoneNumber.TabIndex = 2;
            this.lblPhoneNumber.Text = "Phone Number";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(20, 62);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(76, 17);
            this.lblLastName.TabIndex = 1;
            this.lblLastName.Text = "Last Name";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(20, 18);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(76, 17);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "First Name";
            // 
            // EducationPage
            // 
            this.EducationPage.Controls.Add(this.btnDeleteEducation);
            this.EducationPage.Controls.Add(this.listboxEducation);
            this.EducationPage.Controls.Add(this.txtboxDegree);
            this.EducationPage.Controls.Add(this.txtboxProgram);
            this.EducationPage.Controls.Add(this.txtboxSchool);
            this.EducationPage.Controls.Add(this.label1);
            this.EducationPage.Controls.Add(this.label2);
            this.EducationPage.Controls.Add(this.label3);
            this.EducationPage.Controls.Add(this.btnAddEducation);
            this.EducationPage.Location = new System.Drawing.Point(4, 25);
            this.EducationPage.Name = "EducationPage";
            this.EducationPage.Padding = new System.Windows.Forms.Padding(3);
            this.EducationPage.Size = new System.Drawing.Size(386, 250);
            this.EducationPage.TabIndex = 1;
            this.EducationPage.Text = "Education";
            this.EducationPage.UseVisualStyleBackColor = true;
            // 
            // btnDeleteEducation
            // 
            this.btnDeleteEducation.Location = new System.Drawing.Point(267, 209);
            this.btnDeleteEducation.Name = "btnDeleteEducation";
            this.btnDeleteEducation.Size = new System.Drawing.Size(75, 35);
            this.btnDeleteEducation.TabIndex = 14;
            this.btnDeleteEducation.Text = "Delete";
            this.btnDeleteEducation.UseVisualStyleBackColor = true;
            this.btnDeleteEducation.Click += new System.EventHandler(this.btnDeleteEducation_Click);
            // 
            // listboxEducation
            // 
            this.listboxEducation.FormattingEnabled = true;
            this.listboxEducation.ItemHeight = 16;
            this.listboxEducation.Location = new System.Drawing.Point(23, 161);
            this.listboxEducation.Name = "listboxEducation";
            this.listboxEducation.Size = new System.Drawing.Size(319, 36);
            this.listboxEducation.TabIndex = 13;
            // 
            // txtboxDegree
            // 
            this.txtboxDegree.Location = new System.Drawing.Point(138, 110);
            this.txtboxDegree.Name = "txtboxDegree";
            this.txtboxDegree.Size = new System.Drawing.Size(204, 22);
            this.txtboxDegree.TabIndex = 12;
            // 
            // txtboxProgram
            // 
            this.txtboxProgram.Location = new System.Drawing.Point(138, 63);
            this.txtboxProgram.Name = "txtboxProgram";
            this.txtboxProgram.Size = new System.Drawing.Size(204, 22);
            this.txtboxProgram.TabIndex = 11;
            // 
            // txtboxSchool
            // 
            this.txtboxSchool.Location = new System.Drawing.Point(138, 19);
            this.txtboxSchool.Name = "txtboxSchool";
            this.txtboxSchool.Size = new System.Drawing.Size(204, 22);
            this.txtboxSchool.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Degree";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Program";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "School";
            // 
            // btnAddEducation
            // 
            this.btnAddEducation.Location = new System.Drawing.Point(23, 209);
            this.btnAddEducation.Name = "btnAddEducation";
            this.btnAddEducation.Size = new System.Drawing.Size(75, 35);
            this.btnAddEducation.TabIndex = 0;
            this.btnAddEducation.Text = "Add";
            this.btnAddEducation.UseVisualStyleBackColor = true;
            this.btnAddEducation.Click += new System.EventHandler(this.btnAddEducation_Click);
            // 
            // WorkHistoryPage
            // 
            this.WorkHistoryPage.Controls.Add(this.numericUpDownYears);
            this.WorkHistoryPage.Controls.Add(this.btnDeleteWorkHistory);
            this.WorkHistoryPage.Controls.Add(this.listboxWorkHistory);
            this.WorkHistoryPage.Controls.Add(this.txtboxPosition);
            this.WorkHistoryPage.Controls.Add(this.txtboxCompany);
            this.WorkHistoryPage.Controls.Add(this.label4);
            this.WorkHistoryPage.Controls.Add(this.label5);
            this.WorkHistoryPage.Controls.Add(this.label6);
            this.WorkHistoryPage.Controls.Add(this.btnAddWorkHistory);
            this.WorkHistoryPage.Location = new System.Drawing.Point(4, 25);
            this.WorkHistoryPage.Name = "WorkHistoryPage";
            this.WorkHistoryPage.Size = new System.Drawing.Size(386, 250);
            this.WorkHistoryPage.TabIndex = 2;
            this.WorkHistoryPage.Text = "WorkHistory";
            this.WorkHistoryPage.UseVisualStyleBackColor = true;
            // 
            // numericUpDownYears
            // 
            this.numericUpDownYears.Location = new System.Drawing.Point(142, 108);
            this.numericUpDownYears.Name = "numericUpDownYears";
            this.numericUpDownYears.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownYears.TabIndex = 24;
            // 
            // btnDeleteWorkHistory
            // 
            this.btnDeleteWorkHistory.Location = new System.Drawing.Point(271, 207);
            this.btnDeleteWorkHistory.Name = "btnDeleteWorkHistory";
            this.btnDeleteWorkHistory.Size = new System.Drawing.Size(75, 35);
            this.btnDeleteWorkHistory.TabIndex = 23;
            this.btnDeleteWorkHistory.Text = "Delete";
            this.btnDeleteWorkHistory.UseVisualStyleBackColor = true;
            this.btnDeleteWorkHistory.Click += new System.EventHandler(this.btnDeleteWorkHistory_Click);
            // 
            // listboxWorkHistory
            // 
            this.listboxWorkHistory.FormattingEnabled = true;
            this.listboxWorkHistory.ItemHeight = 16;
            this.listboxWorkHistory.Location = new System.Drawing.Point(27, 159);
            this.listboxWorkHistory.Name = "listboxWorkHistory";
            this.listboxWorkHistory.Size = new System.Drawing.Size(319, 36);
            this.listboxWorkHistory.TabIndex = 22;
            // 
            // txtboxPosition
            // 
            this.txtboxPosition.Location = new System.Drawing.Point(142, 61);
            this.txtboxPosition.Name = "txtboxPosition";
            this.txtboxPosition.Size = new System.Drawing.Size(204, 22);
            this.txtboxPosition.TabIndex = 20;
            // 
            // txtboxCompany
            // 
            this.txtboxCompany.Location = new System.Drawing.Point(142, 17);
            this.txtboxCompany.Name = "txtboxCompany";
            this.txtboxCompany.Size = new System.Drawing.Size(204, 22);
            this.txtboxCompany.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "Years";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Position";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "Company";
            // 
            // btnAddWorkHistory
            // 
            this.btnAddWorkHistory.Location = new System.Drawing.Point(27, 207);
            this.btnAddWorkHistory.Name = "btnAddWorkHistory";
            this.btnAddWorkHistory.Size = new System.Drawing.Size(75, 35);
            this.btnAddWorkHistory.TabIndex = 15;
            this.btnAddWorkHistory.Text = "Add";
            this.btnAddWorkHistory.UseVisualStyleBackColor = true;
            this.btnAddWorkHistory.Click += new System.EventHandler(this.btnAddWorkHistory_Click);
            // 
            // InputOutputPage
            // 
            this.InputOutputPage.Controls.Add(this.btnFileBrowser);
            this.InputOutputPage.Controls.Add(this.btnImport);
            this.InputOutputPage.Controls.Add(this.txtboxImport);
            this.InputOutputPage.Controls.Add(this.btnExport);
            this.InputOutputPage.Controls.Add(this.txtboxFileDirectory);
            this.InputOutputPage.Controls.Add(this.btnFolderBrowser);
            this.InputOutputPage.Location = new System.Drawing.Point(4, 25);
            this.InputOutputPage.Name = "InputOutputPage";
            this.InputOutputPage.Size = new System.Drawing.Size(386, 250);
            this.InputOutputPage.TabIndex = 4;
            this.InputOutputPage.Text = "Input/Ouput";
            this.InputOutputPage.UseVisualStyleBackColor = true;
            // 
            // btnFileBrowser
            // 
            this.btnFileBrowser.Location = new System.Drawing.Point(296, 149);
            this.btnFileBrowser.Name = "btnFileBrowser";
            this.btnFileBrowser.Size = new System.Drawing.Size(75, 37);
            this.btnFileBrowser.TabIndex = 5;
            this.btnFileBrowser.Text = "Browse";
            this.btnFileBrowser.UseVisualStyleBackColor = true;
            this.btnFileBrowser.Click += new System.EventHandler(this.btnFileBrowser_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(296, 195);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 37);
            this.btnImport.TabIndex = 4;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // txtboxImport
            // 
            this.txtboxImport.Location = new System.Drawing.Point(27, 156);
            this.txtboxImport.Name = "txtboxImport";
            this.txtboxImport.ReadOnly = true;
            this.txtboxImport.Size = new System.Drawing.Size(249, 22);
            this.txtboxImport.TabIndex = 3;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(296, 60);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 37);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // txtboxFileDirectory
            // 
            this.txtboxFileDirectory.Location = new System.Drawing.Point(27, 24);
            this.txtboxFileDirectory.Name = "txtboxFileDirectory";
            this.txtboxFileDirectory.ReadOnly = true;
            this.txtboxFileDirectory.Size = new System.Drawing.Size(249, 22);
            this.txtboxFileDirectory.TabIndex = 1;
            // 
            // btnFolderBrowser
            // 
            this.btnFolderBrowser.Location = new System.Drawing.Point(296, 17);
            this.btnFolderBrowser.Name = "btnFolderBrowser";
            this.btnFolderBrowser.Size = new System.Drawing.Size(75, 37);
            this.btnFolderBrowser.TabIndex = 0;
            this.btnFolderBrowser.Text = "Browse";
            this.btnFolderBrowser.UseVisualStyleBackColor = true;
            this.btnFolderBrowser.Click += new System.EventHandler(this.btnFolderBrowser_Click);
            // 
            // FormResumaManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 307);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormResumaManager";
            this.Text = "Resume Manager";
            this.Load += new System.EventHandler(this.FormResumaManager_Load);
            this.tabControl1.ResumeLayout(false);
            this.InfoPage.ResumeLayout(false);
            this.InfoPage.PerformLayout();
            this.EducationPage.ResumeLayout(false);
            this.EducationPage.PerformLayout();
            this.WorkHistoryPage.ResumeLayout(false);
            this.WorkHistoryPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYears)).EndInit();
            this.InputOutputPage.ResumeLayout(false);
            this.InputOutputPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage InfoPage;
        private System.Windows.Forms.TextBox txtboxEmail;
        private System.Windows.Forms.TextBox txtboxPhoneNumber;
        private System.Windows.Forms.TextBox txtboxLastName;
        private System.Windows.Forms.TextBox txtboxFirstName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TabPage EducationPage;
        private System.Windows.Forms.TabPage WorkHistoryPage;
        private System.Windows.Forms.TabPage InputOutputPage;
        private System.Windows.Forms.Button btnAddEducation;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtboxDegree;
        private System.Windows.Forms.TextBox txtboxProgram;
        private System.Windows.Forms.TextBox txtboxSchool;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listboxEducation;
        private System.Windows.Forms.Button btnDeleteEducation;
        private System.Windows.Forms.NumericUpDown numericUpDownYears;
        private System.Windows.Forms.Button btnDeleteWorkHistory;
        private System.Windows.Forms.ListBox listboxWorkHistory;
        private System.Windows.Forms.TextBox txtboxPosition;
        private System.Windows.Forms.TextBox txtboxCompany;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAddWorkHistory;
        private System.Windows.Forms.Button btnFolderBrowser;
        private System.Windows.Forms.TextBox txtboxFileDirectory;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnFileBrowser;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.TextBox txtboxImport;
    }
}