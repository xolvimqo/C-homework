namespace WindowsFormsApplication8
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblBeforeSorting = new System.Windows.Forms.Label();
            this.lblAfterSorting = new System.Windows.Forms.Label();
            this.btnSubjectSort = new System.Windows.Forms.Button();
            this.btnNameSort = new System.Windows.Forms.Button();
            this.btnScoreSort = new System.Windows.Forms.Button();
            this.btnSearchName = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblAverage = new System.Windows.Forms.Label();
            this.btnHighSorting = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "排序前";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(238, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "排序後";
            // 
            // lblBeforeSorting
            // 
            this.lblBeforeSorting.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblBeforeSorting.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblBeforeSorting.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblBeforeSorting.Location = new System.Drawing.Point(13, 51);
            this.lblBeforeSorting.Name = "lblBeforeSorting";
            this.lblBeforeSorting.Size = new System.Drawing.Size(188, 323);
            this.lblBeforeSorting.TabIndex = 2;
            // 
            // lblAfterSorting
            // 
            this.lblAfterSorting.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblAfterSorting.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblAfterSorting.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblAfterSorting.Location = new System.Drawing.Point(238, 51);
            this.lblAfterSorting.Name = "lblAfterSorting";
            this.lblAfterSorting.Size = new System.Drawing.Size(181, 323);
            this.lblAfterSorting.TabIndex = 3;
            // 
            // btnSubjectSort
            // 
            this.btnSubjectSort.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSubjectSort.Location = new System.Drawing.Point(12, 387);
            this.btnSubjectSort.Name = "btnSubjectSort";
            this.btnSubjectSort.Size = new System.Drawing.Size(101, 35);
            this.btnSubjectSort.TabIndex = 4;
            this.btnSubjectSort.Text = "科目排序";
            this.btnSubjectSort.UseVisualStyleBackColor = true;
            this.btnSubjectSort.Click += new System.EventHandler(this.btnSubjectSort_Click);
            // 
            // btnNameSort
            // 
            this.btnNameSort.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnNameSort.Location = new System.Drawing.Point(242, 387);
            this.btnNameSort.Name = "btnNameSort";
            this.btnNameSort.Size = new System.Drawing.Size(101, 35);
            this.btnNameSort.TabIndex = 5;
            this.btnNameSort.Text = "姓名排序";
            this.btnNameSort.UseVisualStyleBackColor = true;
            this.btnNameSort.Click += new System.EventHandler(this.btnNameSort_Click);
            // 
            // btnScoreSort
            // 
            this.btnScoreSort.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnScoreSort.Location = new System.Drawing.Point(12, 440);
            this.btnScoreSort.Name = "btnScoreSort";
            this.btnScoreSort.Size = new System.Drawing.Size(101, 35);
            this.btnScoreSort.TabIndex = 6;
            this.btnScoreSort.Text = "成績排序";
            this.btnScoreSort.UseVisualStyleBackColor = true;
            this.btnScoreSort.Click += new System.EventHandler(this.btnScoreSort_Click);
            // 
            // btnSearchName
            // 
            this.btnSearchName.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSearchName.Location = new System.Drawing.Point(455, 440);
            this.btnSearchName.Name = "btnSearchName";
            this.btnSearchName.Size = new System.Drawing.Size(101, 35);
            this.btnSearchName.TabIndex = 7;
            this.btnSearchName.Text = "姓名搜尋";
            this.btnSearchName.UseVisualStyleBackColor = true;
            this.btnSearchName.Click += new System.EventHandler(this.btnSearchName_Click);
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbName.Location = new System.Drawing.Point(242, 440);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(100, 30);
            this.tbName.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(461, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 21);
            this.label5.TabIndex = 9;
            this.label5.Text = "總分";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(461, 255);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 21);
            this.label6.TabIndex = 10;
            this.label6.Text = "平均";
            // 
            // lblScore
            // 
            this.lblScore.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblScore.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblScore.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblScore.Location = new System.Drawing.Point(461, 199);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(95, 35);
            this.lblScore.TabIndex = 11;
            // 
            // lblAverage
            // 
            this.lblAverage.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblAverage.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblAverage.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblAverage.Location = new System.Drawing.Point(461, 276);
            this.lblAverage.Name = "lblAverage";
            this.lblAverage.Size = new System.Drawing.Size(95, 35);
            this.lblAverage.TabIndex = 12;
            // 
            // btnHighSorting
            // 
            this.btnHighSorting.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnHighSorting.Location = new System.Drawing.Point(12, 481);
            this.btnHighSorting.Name = "btnHighSorting";
            this.btnHighSorting.Size = new System.Drawing.Size(101, 35);
            this.btnHighSorting.TabIndex = 13;
            this.btnHighSorting.Text = "身高排序";
            this.btnHighSorting.UseVisualStyleBackColor = true;
            this.btnHighSorting.Click += new System.EventHandler(this.btnHighSorting_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(591, 517);
            this.Controls.Add(this.btnHighSorting);
            this.Controls.Add(this.lblAverage);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.btnSearchName);
            this.Controls.Add(this.btnScoreSort);
            this.Controls.Add(this.btnNameSort);
            this.Controls.Add(this.btnSubjectSort);
            this.Controls.Add(this.lblAfterSorting);
            this.Controls.Add(this.lblBeforeSorting);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Operation of Array";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblBeforeSorting;
        private System.Windows.Forms.Label lblAfterSorting;
        private System.Windows.Forms.Button btnSubjectSort;
        private System.Windows.Forms.Button btnNameSort;
        private System.Windows.Forms.Button btnScoreSort;
        private System.Windows.Forms.Button btnSearchName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblAverage;
        private System.Windows.Forms.Button btnHighSorting;
    }
}

