namespace FinalHW
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.PowerLottery = new System.Windows.Forms.TabPage();
            this.TodayLottery539 = new System.Windows.Forms.TabPage();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.tbRandom = new System.Windows.Forms.TextBox();
            this.lblOutput = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.PowerLottery);
            this.tabControl1.Controls.Add(this.TodayLottery539);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(459, 372);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Layout += new System.Windows.Forms.LayoutEventHandler(this.todayLottery539_Layout);
            // 
            // PowerLottery
            // 
            this.PowerLottery.BackColor = System.Drawing.Color.Gray;
            this.PowerLottery.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.PowerLottery.Location = new System.Drawing.Point(4, 22);
            this.PowerLottery.Name = "PowerLottery";
            this.PowerLottery.Padding = new System.Windows.Forms.Padding(3);
            this.PowerLottery.Size = new System.Drawing.Size(451, 346);
            this.PowerLottery.TabIndex = 0;
            this.PowerLottery.Text = "PowerLottery";
            this.PowerLottery.Click += new System.EventHandler(this.PowerLottery_Click);
            this.PowerLottery.Layout += new System.Windows.Forms.LayoutEventHandler(this.PowerLottery_Layout);
            // 
            // TodayLottery539
            // 
            this.TodayLottery539.BackColor = System.Drawing.Color.DarkGray;
            this.TodayLottery539.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TodayLottery539.Location = new System.Drawing.Point(4, 22);
            this.TodayLottery539.Name = "TodayLottery539";
            this.TodayLottery539.Padding = new System.Windows.Forms.Padding(3);
            this.TodayLottery539.Size = new System.Drawing.Size(451, 346);
            this.TodayLottery539.TabIndex = 1;
            this.TodayLottery539.Text = "TodayLottery539";
            this.TodayLottery539.Click += new System.EventHandler(this.TodayLottery539_Click);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnStart.Location = new System.Drawing.Point(16, 471);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(202, 55);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnReset.Location = new System.Drawing.Point(221, 471);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(202, 55);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // tbRandom
            // 
            this.tbRandom.Enabled = false;
            this.tbRandom.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbRandom.Location = new System.Drawing.Point(13, 387);
            this.tbRandom.Name = "tbRandom";
            this.tbRandom.Size = new System.Drawing.Size(410, 27);
            this.tbRandom.TabIndex = 6;
            // 
            // lblOutput
            // 
            this.lblOutput.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblOutput.Location = new System.Drawing.Point(487, 34);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(299, 492);
            this.lblOutput.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 546);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.tbRandom);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage PowerLottery;
        private System.Windows.Forms.TabPage TodayLottery539;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox tbRandom;
        private System.Windows.Forms.Label lblOutput;
    }
}

