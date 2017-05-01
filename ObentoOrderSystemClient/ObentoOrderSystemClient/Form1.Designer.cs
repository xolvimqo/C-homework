namespace ObentoOrderSystemClient
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.studentPage = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnSendSum = new System.Windows.Forms.Button();
            this.btnRefund = new System.Windows.Forms.Button();
            this.btnPaid = new System.Windows.Forms.Button();
            this.lboxPaidOrder = new System.Windows.Forms.ListBox();
            this.lboxUnpaidOrder = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnLock = new System.Windows.Forms.Button();
            this.lvStoreMenu = new System.Windows.Forms.ListView();
            this.cbStoreName = new System.Windows.Forms.ComboBox();
            this.obentoDataSet = new ObentoOrderSystemClient.ObentoDataSet();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lboxStuOrder = new System.Windows.Forms.ListBox();
            this.cbObendoName = new System.Windows.Forms.ComboBox();
            this.numUD = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbClassroom = new System.Windows.Forms.ComboBox();
            this.cbStudentName = new System.Windows.Forms.ComboBox();
            this.chkbox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.counterPage = new System.Windows.Forms.TabPage();
            this.orderTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.studentTableBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.studentTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.studentTableTableAdapter = new ObentoOrderSystemClient.ObentoDataSetTableAdapters.studentTableTableAdapter();
            this.orderTableTableAdapter = new ObentoOrderSystemClient.ObentoDataSetTableAdapters.orderTableTableAdapter();
            this.tableAdapterManager = new ObentoOrderSystemClient.ObentoDataSetTableAdapters.TableAdapterManager();
            this.tabControl1.SuspendLayout();
            this.studentPage.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.obentoDataSet)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentTableBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentTableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.studentPage);
            this.tabControl1.Controls.Add(this.counterPage);
            this.tabControl1.Location = new System.Drawing.Point(12, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1095, 670);
            this.tabControl1.TabIndex = 0;
            // 
            // studentPage
            // 
            this.studentPage.AutoScroll = true;
            this.studentPage.Controls.Add(this.groupBox4);
            this.studentPage.Controls.Add(this.groupBox3);
            this.studentPage.Controls.Add(this.groupBox2);
            this.studentPage.Controls.Add(this.groupBox1);
            this.studentPage.Location = new System.Drawing.Point(4, 22);
            this.studentPage.Name = "studentPage";
            this.studentPage.Padding = new System.Windows.Forms.Padding(3);
            this.studentPage.Size = new System.Drawing.Size(1087, 644);
            this.studentPage.TabIndex = 0;
            this.studentPage.Text = "學生";
            this.studentPage.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnSendSum);
            this.groupBox4.Controls.Add(this.btnRefund);
            this.groupBox4.Controls.Add(this.btnPaid);
            this.groupBox4.Controls.Add(this.lboxPaidOrder);
            this.groupBox4.Controls.Add(this.lboxUnpaidOrder);
            this.groupBox4.Location = new System.Drawing.Point(584, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(496, 605);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "總訂單";
            // 
            // btnSendSum
            // 
            this.btnSendSum.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSendSum.Location = new System.Drawing.Point(385, 464);
            this.btnSendSum.Name = "btnSendSum";
            this.btnSendSum.Size = new System.Drawing.Size(105, 41);
            this.btnSendSum.TabIndex = 18;
            this.btnSendSum.Text = "送出";
            this.btnSendSum.UseVisualStyleBackColor = true;
            // 
            // btnRefund
            // 
            this.btnRefund.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnRefund.Location = new System.Drawing.Point(6, 464);
            this.btnRefund.Name = "btnRefund";
            this.btnRefund.Size = new System.Drawing.Size(105, 41);
            this.btnRefund.TabIndex = 17;
            this.btnRefund.Text = "退款";
            this.btnRefund.UseVisualStyleBackColor = true;
            // 
            // btnPaid
            // 
            this.btnPaid.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnPaid.Location = new System.Drawing.Point(6, 203);
            this.btnPaid.Name = "btnPaid";
            this.btnPaid.Size = new System.Drawing.Size(105, 41);
            this.btnPaid.TabIndex = 15;
            this.btnPaid.Text = "已付款";
            this.btnPaid.UseVisualStyleBackColor = true;
            // 
            // lboxPaidOrder
            // 
            this.lboxPaidOrder.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lboxPaidOrder.FormattingEnabled = true;
            this.lboxPaidOrder.ItemHeight = 16;
            this.lboxPaidOrder.Location = new System.Drawing.Point(6, 278);
            this.lboxPaidOrder.Name = "lboxPaidOrder";
            this.lboxPaidOrder.Size = new System.Drawing.Size(484, 180);
            this.lboxPaidOrder.TabIndex = 16;
            // 
            // lboxUnpaidOrder
            // 
            this.lboxUnpaidOrder.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lboxUnpaidOrder.FormattingEnabled = true;
            this.lboxUnpaidOrder.ItemHeight = 16;
            this.lboxUnpaidOrder.Location = new System.Drawing.Point(6, 17);
            this.lboxUnpaidOrder.Name = "lboxUnpaidOrder";
            this.lboxUnpaidOrder.Size = new System.Drawing.Size(484, 180);
            this.lboxUnpaidOrder.TabIndex = 15;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnLock);
            this.groupBox3.Controls.Add(this.lvStoreMenu);
            this.groupBox3.Controls.Add(this.cbStoreName);
            this.groupBox3.Location = new System.Drawing.Point(274, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(304, 599);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "店家菜單";
            // 
            // btnLock
            // 
            this.btnLock.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnLock.Location = new System.Drawing.Point(212, 20);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(86, 36);
            this.btnLock.TabIndex = 15;
            this.btnLock.Text = "鎖定";
            this.btnLock.UseVisualStyleBackColor = true;
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // lvStoreMenu
            // 
            this.lvStoreMenu.Location = new System.Drawing.Point(6, 62);
            this.lvStoreMenu.Name = "lvStoreMenu";
            this.lvStoreMenu.Size = new System.Drawing.Size(292, 531);
            this.lvStoreMenu.TabIndex = 15;
            this.lvStoreMenu.UseCompatibleStateImageBehavior = false;
            // 
            // cbStoreName
            // 
            this.cbStoreName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.obentoDataSet, "storeTable.storeName", true));
            this.cbStoreName.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbStoreName.FormattingEnabled = true;
            this.cbStoreName.Location = new System.Drawing.Point(6, 24);
            this.cbStoreName.Name = "cbStoreName";
            this.cbStoreName.Size = new System.Drawing.Size(200, 32);
            this.cbStoreName.TabIndex = 14;
            this.cbStoreName.SelectedIndexChanged += new System.EventHandler(this.cbStoreName_SelectedIndexChanged);
            // 
            // obentoDataSet
            // 
            this.obentoDataSet.DataSetName = "ObentoDataSet1";
            this.obentoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCheck);
            this.groupBox2.Controls.Add(this.btnSend);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.lboxStuOrder);
            this.groupBox2.Controls.Add(this.cbObendoName);
            this.groupBox2.Controls.Add(this.numUD);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Location = new System.Drawing.Point(6, 178);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(261, 428);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "訂購單";
            // 
            // btnCheck
            // 
            this.btnCheck.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCheck.Location = new System.Drawing.Point(6, 356);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(105, 41);
            this.btnCheck.TabIndex = 14;
            this.btnCheck.Text = "  確認";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSend.Location = new System.Drawing.Point(117, 356);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(105, 41);
            this.btnSend.TabIndex = 13;
            this.btnSend.Text = " 送出";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDelete.Location = new System.Drawing.Point(117, 107);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(105, 41);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "刪除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnAdd.Location = new System.Drawing.Point(6, 107);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(105, 41);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "加入";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lboxStuOrder
            // 
            this.lboxStuOrder.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lboxStuOrder.FormattingEnabled = true;
            this.lboxStuOrder.ItemHeight = 16;
            this.lboxStuOrder.Location = new System.Drawing.Point(6, 154);
            this.lboxStuOrder.Name = "lboxStuOrder";
            this.lboxStuOrder.Size = new System.Drawing.Size(226, 196);
            this.lboxStuOrder.TabIndex = 10;
            // 
            // cbObendoName
            // 
            this.cbObendoName.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbObendoName.FormattingEnabled = true;
            this.cbObendoName.Location = new System.Drawing.Point(79, 15);
            this.cbObendoName.Name = "cbObendoName";
            this.cbObendoName.Size = new System.Drawing.Size(171, 32);
            this.cbObendoName.TabIndex = 9;
            // 
            // numUD
            // 
            this.numUD.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numUD.Location = new System.Drawing.Point(79, 53);
            this.numUD.Name = "numUD";
            this.numUD.Size = new System.Drawing.Size(171, 36);
            this.numUD.TabIndex = 8;
            this.numUD.ValueChanged += new System.EventHandler(this.numUD_ValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.Location = new System.Drawing.Point(6, 56);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 24);
            this.label14.TabIndex = 7;
            this.label14.Text = "數量";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label13.Location = new System.Drawing.Point(6, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 24);
            this.label13.TabIndex = 6;
            this.label13.Text = "商品";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbClassroom);
            this.groupBox1.Controls.Add(this.cbStudentName);
            this.groupBox1.Controls.Add(this.chkbox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 166);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "學生";
            // 
            // cbClassroom
            // 
            this.cbClassroom.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbClassroom.FormattingEnabled = true;
            this.cbClassroom.Location = new System.Drawing.Point(97, 21);
            this.cbClassroom.Name = "cbClassroom";
            this.cbClassroom.Size = new System.Drawing.Size(153, 32);
            this.cbClassroom.TabIndex = 14;
            this.cbClassroom.SelectedIndexChanged += new System.EventHandler(this.cbClassroom_SelectedIndexChanged);
            // 
            // cbStudentName
            // 
            this.cbStudentName.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbStudentName.FormattingEnabled = true;
            this.cbStudentName.Location = new System.Drawing.Point(97, 66);
            this.cbStudentName.Name = "cbStudentName";
            this.cbStudentName.Size = new System.Drawing.Size(153, 32);
            this.cbStudentName.TabIndex = 13;
            this.cbStudentName.SelectedIndexChanged += new System.EventHandler(this.cbStudentName_SelectedIndexChanged);
            // 
            // chkbox
            // 
            this.chkbox.AutoSize = true;
            this.chkbox.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkbox.Location = new System.Drawing.Point(103, 123);
            this.chkbox.Name = "chkbox";
            this.chkbox.Size = new System.Drawing.Size(72, 28);
            this.chkbox.TabIndex = 5;
            this.chkbox.Text = "YES";
            this.chkbox.UseVisualStyleBackColor = true;
            this.chkbox.CheckedChanged += new System.EventHandler(this.chkbox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = " 教室";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(14, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "姓名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(14, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "值日生";
            // 
            // counterPage
            // 
            this.counterPage.Location = new System.Drawing.Point(4, 22);
            this.counterPage.Name = "counterPage";
            this.counterPage.Padding = new System.Windows.Forms.Padding(3);
            this.counterPage.Size = new System.Drawing.Size(1087, 644);
            this.counterPage.TabIndex = 1;
            this.counterPage.Text = "櫃台";
            this.counterPage.UseVisualStyleBackColor = true;
            // 
            // orderTableBindingSource
            // 
            this.orderTableBindingSource.DataMember = "orderTable";
            this.orderTableBindingSource.DataSource = this.obentoDataSet;
            // 
            // studentTableBindingSource1
            // 
            this.studentTableBindingSource1.DataMember = "studentTable";
            this.studentTableBindingSource1.DataSource = this.obentoDataSet;
            // 
            // studentTableBindingSource
            // 
            this.studentTableBindingSource.DataMember = "studentTable";
            this.studentTableBindingSource.DataSource = this.obentoDataSet;
            // 
            // studentTableTableAdapter
            // 
            this.studentTableTableAdapter.ClearBeforeFill = true;
            // 
            // orderTableTableAdapter
            // 
            this.orderTableTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.environmentTableTableAdapter = null;
            this.tableAdapterManager.obentoTableTableAdapter = null;
            this.tableAdapterManager.orderTableTableAdapter = this.orderTableTableAdapter;
            this.tableAdapterManager.storeTableTableAdapter = null;
            this.tableAdapterManager.studentTableTableAdapter = this.studentTableTableAdapter;
            this.tableAdapterManager.UpdateOrder = ObentoOrderSystemClient.ObentoDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 673);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.studentPage.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.obentoDataSet)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentTableBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentTableBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage studentPage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lboxStuOrder;
        private System.Windows.Forms.NumericUpDown numUD;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage counterPage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnCheck;
        private ObentoDataSet obentoDataSet;
        private System.Windows.Forms.BindingSource studentTableBindingSource;
        private ObentoDataSetTableAdapters.studentTableTableAdapter studentTableTableAdapter;
        private System.Windows.Forms.BindingSource studentTableBindingSource1;
        private System.Windows.Forms.ComboBox cbObendoName;
        private System.Windows.Forms.ComboBox cbStudentName;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbStoreName;
        private System.Windows.Forms.ComboBox cbClassroom;
        private System.Windows.Forms.ListView lvStoreMenu;
        private System.Windows.Forms.BindingSource orderTableBindingSource;
        private ObentoDataSetTableAdapters.orderTableTableAdapter orderTableTableAdapter;
        private ObentoDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ListBox lboxUnpaidOrder;
        private System.Windows.Forms.Button btnSendSum;
        private System.Windows.Forms.Button btnRefund;
        private System.Windows.Forms.Button btnPaid;
        private System.Windows.Forms.ListBox lboxPaidOrder;
        private System.Windows.Forms.Button btnLock;
    }
}

