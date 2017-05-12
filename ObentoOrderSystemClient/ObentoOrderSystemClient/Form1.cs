using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Collections;
using System.Linq;

namespace ObentoOrderSystemClient
{
    public partial class Form1 : Form
    {
        SqlConnectionStringBuilder scsb;

        int studentID = 0;
        private byte[] _bytesOfImage;
        string imgName = "";
        public Form1()
        {
            InitializeComponent();

            Initialization();
        }

        private void Initialization()
        {
            cbStudentName.Text = "";
            cbStudentName.Enabled = false;
            cbStoreName.Enabled = false;
            chkbox.Enabled = true;
            chkbox.Checked = false;
            btnLock.Enabled = false;
            btnAdd.Enabled = false;
            btnSendSum.Enabled = false;
            btnPaid.Enabled = false;
            btnRefund.Enabled = false;

            cbObendoName.Items.Clear();
            cbStoreName.Items.Clear();
            lboxStuOrder.Items.Clear();
            lvStoreMenu.Items.Clear();
        }

        private void chkbox_CheckedChanged(object sender, EventArgs e)
        {
            cbStoreName.Items.Clear();
            if(chkbox.Checked)
            {
                btnSendSum.Enabled = true;
                new LinkSQL().setDuty(cbStudentName.Text, 1);
                cbStoreName.Enabled = true;
                btnLock.Enabled = true;
                SqlConnection sqlCnct = new SqlConnection(scsb.ToString());
                string strSQL = "";

                sqlCnct.Open();
                strSQL = "select * from storeTable";
                SqlCommand sqlCmd = new SqlCommand(strSQL, sqlCnct);
                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                while (sqlReader.Read())
                {
                    cbStoreName.Items.Add(sqlReader["storeName"]);
                }

                sqlReader.Close();
                sqlCnct.Close();
            } else
            {
                cbStoreName.Enabled = false;
                cbStoreName.Text = "";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'obentoDataSet.obentoTable' 資料表。您可以視需要進行移動或移除。
            this.obentoTableTableAdapter.Fill(this.obentoDataSet.obentoTable);
            // TODO: 這行程式碼會將資料載入 'obentoDataSet.storeTable' 資料表。您可以視需要進行移動或移除。
            this.storeTableTableAdapter.Fill(this.obentoDataSet.storeTable);
            // TODO: 這行程式碼會將資料載入 'obentoDataSet1.orderTable' 資料表。您可以視需要進行移動或移除。
            this.orderTableTableAdapter.Fill(this.obentoDataSet.orderTable);
            // TODO: 這行程式碼會將資料載入 'obentoDataSet1.studentTable' 資料表。您可以視需要進行移動或移除。
            this.studentTableTableAdapter.Fill(this.obentoDataSet.studentTable);
            // SQL
            scsb = new SqlConnectionStringBuilder();
			scsb.DataSource = @".";
			//scsb.DataSource = @"XOLVIMQO-PC\SQLEXPRESS";
            scsb.InitialCatalog = "Obento";
            scsb.IntegratedSecurity = true;

            SqlConnection sqlCnct = new SqlConnection(scsb.ToString());
            string strSQL = "";
            
            sqlCnct.Open();
            strSQL = "select distinct classRoom from studentTable";
            SqlCommand sqlCmd = new SqlCommand(strSQL, sqlCnct);
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
                cbClassroom.Items.Add(sqlReader["classRoom"]);
                cbClassroom2.Items.Add(sqlReader["classRoom"]);
                cbClassroom3.Items.Add(sqlReader["classRoom"]);
            }

            sqlReader.Close();
            sqlCnct.Close();

            Timer timer = new Timer();
            timer.Interval = 5 * 1000; // 10 seconds
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lboxUnpaidOrder.Items.Clear();
            lboxPaidOrder.Items.Clear();
            lboxCounter.Items.Clear();
            ArrayList strArrayList = new ArrayList();
            string[] strArray = new string[5];
            string name = "";
            string str = "";
            int sum = 0;
            ArrayList sumArray = new ArrayList();
            int totalPrice = 0;

            // To load unpaid order periodically
            if (cbClassroom.Text.Length > 0) { // check if classroom is selected
                ArrayList unpaidOrder = new LinkSQL().loadUnpaidOrder(cbClassroom.Text);
                unpaidOrder.Add("1 2 3 4 5");
                if (unpaidOrder.Count > 0)
                {
                    foreach (string strLine in unpaidOrder)
                    {
                        strArray = strLine.Split(' ');
                        if (name != strArray[0]) {
                            if (sum != 0 && name != "1") {
                                lboxUnpaidOrder.Items.Add(name + " " + str + "總共 " + sum.ToString() + " 元");
                            }
                            str = "";
                            sum = 0;
                            name = strArray[0];
                            str += strArray[1] + " * " + strArray[4] + ", ";
                            sum += int.Parse(strArray[2]) * int.Parse(strArray[4]);
                        } else
                        {
                            str += strArray[1] + " * " + strArray[4] + ", ";
                            sum += int.Parse(strArray[2]) * int.Parse(strArray[4]);
                        }
                    }
                }

                // To load paid order periodically
                ArrayList paidOrder = new LinkSQL().loadPaidOrder(cbClassroom.Text);
                paidOrder.Add("1 2 3 4 5");
                if (paidOrder.Count > 0)
                {
                    foreach (string strLine in paidOrder)
                    {
                        strArray = strLine.Split(' ');
                        if (name != strArray[0])
                        {
                            if (sum != 0 && name != "1")
                            {
                                lboxPaidOrder.Items.Add(name + " " + str + "總共 " + sum.ToString() + " 元");
                            }
                            str = "";
                            sum = 0;
                            name = strArray[0];
                            str += strArray[1] + " * " + strArray[4] + ", ";
                            sum += int.Parse(strArray[2]) * int.Parse(strArray[4]);
                        }
                        else
                        {
                            str += strArray[1] + " * " + strArray[4] + ", ";
                            sum += int.Parse(strArray[2]) * int.Parse(strArray[4]);
                        }
                    }
                }
                // To load submitted order to counter
                int envLength = new LinkSQL().getEnvLength(DateTime.Now);
                if (envLength > 0) {
                    if (new LinkSQL().getSubmitState() == "true" && cbClassroom2.Text.Length > 0)
                    {
                        ArrayList counterOrder = new LinkSQL().loadPaidOrder(cbClassroom2.Text);
                        paidOrder.Add("1 2 3 4 5");
                        if (paidOrder.Count > 0)
                        {
                            foreach (string strLine in paidOrder)
                            {
                                strArray = strLine.Split(' ');
                                if (name != strArray[0])
                                {
                                    if (sum != 0 && name != "1")
                                    {
                                        lboxCounter.Items.Add(name + " " + str + "總共 " + sum.ToString() + " 元");
                                        sumArray.Add(sum);
                                    }
                                    str = "";
                                    sum = 0;
                                    name = strArray[0];
                                    str += strArray[1] + " * " + strArray[4] + ", ";
                                    sum += int.Parse(strArray[2]) * int.Parse(strArray[4]);
                                }
                                else
                                {
                                    str += strArray[1] + " * " + strArray[4] + ", ";
                                    sum += int.Parse(strArray[2]) * int.Parse(strArray[4]);
                                }
                            }
                            foreach(int price in sumArray)
                            {
                                totalPrice += price;
                            }
                            lboxCounter.Items.Add("訂單總金額: " + totalPrice.ToString());
                        }
                    }
                }
            }
        }

        private void cbClassroom_SelectedIndexChanged(object sender, EventArgs e)
        {
            int store_ID = 0;

            Initialization();
            cbStoreName.Text = "";
            cbStudentName.Items.Clear();
            cbStudentName.Text = "";
            cbStudentName.Enabled = true;

            SqlConnection sqlCnct = new SqlConnection(scsb.ToString());
            string strSQL = "";
            string classRoom = cbClassroom.Text;

            sqlCnct.Open();
            strSQL = "select * from studentTable where classRoom = '" + classRoom + "'";
            SqlCommand sqlCmd = new SqlCommand(strSQL, sqlCnct);
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            if (sqlReader.HasRows) {
                while (sqlReader.Read())
                {
                    cbStudentName.Items.Add(sqlReader["stuName"]);
                }
            }

            sqlReader.Close();
            sqlCnct.Close();

            try
            {
                store_ID = int.Parse(new LinkSQL().getEnvStoreID(cbClassroom.Text));
                if (store_ID != 0)
                {
                    cbStoreName.Text = new LinkSQL().getStoreName(store_ID);
                    chkbox.Enabled = false;
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }

        private void cbStoreName_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Initialization of comboBox and listView
            lvStoreMenu.Items.Clear();
            cbObendoName.Items.Clear();

            // To read image files
            ImageList imageList = new ImageList();
            string storeName = cbStoreName.Text;

            // To collect strings of obento informations from database
            ArrayList obentoArrayList = new LinkSQL().getMenuArrayList(storeName);

            foreach (string str in obentoArrayList)
            {
                Console.WriteLine(str.Split(' ')[0]);
                imageList = new ReadImages(new LinkSQL().getImgName(str.Split(' ')[0], storeName)).getImages();
                cbObendoName.Items.Add(str.Split(' ')[0]);
                lvStoreMenu.View = View.LargeIcon;
                imageList.ImageSize = new Size(64, 64);
                lvStoreMenu.LargeImageList = imageList;
                ListViewItem lvItem = new ListViewItem();
                lvItem.ImageIndex = 0;
                lvItem.Text = str;
                lvStoreMenu.Items.Add(lvItem);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                LinkSQL linkSQL = new LinkSQL();
                if (lboxStuOrder.Items.Count == 0 && numUD.Value > 0)
                {
                    string[] stuOrder = new string[2];
                    stuOrder = cbObendoName.Text.Split(' ');
                    // if there is no item in the listBox, then add an item
                    lboxStuOrder.Items.Add(stuOrder[0] + " " + linkSQL.getObentoPrice(cbStoreName.Text, cbObendoName.Text) + " * " + numUD.Value.ToString());
                } else if (numUD.Value > 0)
                {
                    string[] stuOrder = new string[2];
                    stuOrder = cbObendoName.Text.Split(' ');
                    foreach (string strLine in lboxStuOrder.Items) {
                        if (strLine.Split(' ')[0] != stuOrder[0])
                        {
                            // if lboxStuOrder.FindString() is -1, means the string is not in the listBox.
                            lboxStuOrder.Items.Add(stuOrder[0] + " " + linkSQL.getObentoPrice(cbStoreName.Text, cbObendoName.Text) + " * " + numUD.Value.ToString());
                        }
                    }
                }
                /* This is not work
                else if (lboxStuOrder.FindString(cbObendoName.Text) == ListBox.NoMatches && numUD.Value > 0)
                {
                    string[] stuOrder = new string[2];
                    stuOrder = cbObendoName.Text.Split(' ');
                    // if lboxStuOrder.FindString() is -1, means the string is not in the listBox.
                    lboxStuOrder.Items.Add(stuOrder[0] + " " + linkSQL.getObentoPrice(cbStoreName.Text, cbObendoName.Text) + " * " + numUD.Value.ToString());
                }
                */
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void numUD_ValueChanged(object sender, EventArgs e)
        {
            // To ensure there is no value below zero
            numUD.Minimum = 0;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            lboxStuOrder.Items.RemoveAt(lboxStuOrder.SelectedIndex);
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            cbStudentName.Enabled = false;
            cbClassroom.Enabled = false;
            LinkSQL linkSQL = new LinkSQL();
            int stuOrderPrice = 0;
            int stuOrderSum = 0;
            string[] strList = new string[4];

            foreach (string strLine in lboxStuOrder.Items)
            {
                strList = strLine.Split(' ');
                stuOrderPrice = int.Parse(linkSQL.getObentoPrice(cbStoreName.Text, strList[0]));
                stuOrderSum += stuOrderPrice * int.Parse(strList[3]);
            }

            //MessageBox.Show(stuOrderSum.ToString());
            lboxStuOrder.Items.Add("學生訂單小計： " + stuOrderSum.ToString() + " NTD");
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnCheck.Enabled = false;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            LinkSQL linkSQL = new LinkSQL();
            string[] strList = new string[4];
            int obentoID;
            int countRows = 0;
            for(int i = 0; i < lboxStuOrder.Items.Count - 1; i++)
            {
                string strLine = lboxStuOrder.Items[i].ToString();
                strList = strLine.Split(' ');
                obentoID = linkSQL.getObentoID(strList[0]);
                countRows += linkSQL.writeOrder(studentID, obentoID, int.Parse(strList[3]));
            }

            MessageBox.Show(string.Format("共 {0} 筆資料受影響", countRows));
        }

        private void cbStudentName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbObendoName.Text = "";
            lboxStuOrder.Items.Clear();
            LinkSQL linkSQL = new LinkSQL();
            studentID = linkSQL.getStudentID(cbStudentName.Text);

            if (linkSQL.isOnDuty(cbStudentName.Text) == 1) {
                chkbox.Checked = true;
                btnAdd.Enabled = true;
                btnPaid.Enabled = true;
                btnRefund.Enabled = true;
                btnSendSum.Enabled = true;
                cbStoreName_SelectedIndexChanged(sender, e);
            } else if(chkbox.Enabled == false && cbStoreName.Text.Length > 0)
            {
                btnAdd.Enabled = true;
                cbStoreName_SelectedIndexChanged(sender, e);
            }
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;

            int countEnvRows = new LinkSQL().setEnv(cbClassroom.Text, cbStoreName.Text);
        }

        private void btnPaid_Click(object sender, EventArgs e)
        {
            if (lboxUnpaidOrder.SelectedItem != null)
            {
                string stuName = lboxUnpaidOrder.SelectedItem.ToString().Split(' ')[0];
                LinkSQL linkSQL = new LinkSQL();
                int countRows = linkSQL.changePaymentState(stuName, 1);

                //MessageBox.Show(string.Format("共 {0} 筆資料受影響", countRows));
            }
        }

        private void btnRefund_Click(object sender, EventArgs e)
        {
            if (lboxPaidOrder.SelectedItem != null)
            {
                string stuName = lboxPaidOrder.SelectedItem.ToString().Split(' ')[0];
                LinkSQL linkSQL = new LinkSQL();
                int countRows = linkSQL.changePaymentState(stuName, 0);

                //MessageBox.Show(string.Format("共 {0} 筆資料受影響", countRows));
            }
        }

        private void btnSendSum_Click(object sender, EventArgs e)
        {
            if (lboxPaidOrder.Items.Count > 0) {
                int countRows = new LinkSQL().setSubmitState(cbClassroom.Text, "true");
                MessageBox.Show(string.Format("共 {0} 筆資料受影響", countRows));
            }
        }

        private void btnDeny_Click(object sender, EventArgs e)
        {
            DialogResult myResult;
            myResult = MessageBox.Show("您確定要退回訂單嗎?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (lboxCounter.Items.Count > 0 && myResult == DialogResult.OK)
            {
                int deletedOrder = new LinkSQL().deleteOrder(cbClassroom2.Text);
                int countRows = new LinkSQL().setSubmitState(cbClassroom2.Text, "false");
                MessageBox.Show(string.Format("共 {0} 筆資料受影響", countRows));
            }
        }

        private void cbClassroom2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbClassroom.Text = cbClassroom2.Text;
        }

        private void btnAddStu_Click(object sender, EventArgs e)
        {
            if (cbClassroom3.Text.Length >　0 && tbStuName.Text.Length > 0 && tbStuID.Text.Length >0)
            {
                try
                {
                    int count = new LinkSQL().addStudent(int.Parse(tbStuID.Text), tbStuName.Text, cbClassroom3.Text);
                    MessageBox.Show(string.Format("共 {0} 筆資料受影響", count));
                } catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    MessageBox.Show("資料輸入有誤");
                }
            } else
            {
                MessageBox.Show("請輸完整資料");
            }
        }

        private void btnDeleteStu_Click(object sender, EventArgs e)
        {
            if (tbStuID.Text.Length > 0)
            {
                try {
                    int count = new LinkSQL().deleteStudent(int.Parse(tbStuID.Text));
                    MessageBox.Show(string.Format("共 {0} 筆資料受影響", count));
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show("資料輸入有誤");
                }
            } else {
                MessageBox.Show("請輸入學號");
            }
        }

        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            // To read image files
            string currentDir = Directory.GetCurrentDirectory();
            //MessageBox.Show(currentDir);
            //DirectoryInfo imageDir = new DirectoryInfo(currentDir + @"\obentoImages");

            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "C# Open File Dialog";
            fdlg.InitialDirectory = @"C:\";
            fdlg.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF;";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                string[] strFile = fdlg.FileName.Split('\\');
                imgName = strFile.Last().Split('.')[0];
                Console.WriteLine(imgName);
                try
                {
                    try
                    {
                        // show image in picture box
                        pbObento.ImageLocation = fdlg.FileName;
                        pbObento.SizeMode = PictureBoxSizeMode.StretchImage;
                        pbObento.Refresh();
                        /*
                        FileStream fsReader = new FileStream(fdlg.FileName, FileMode.Open);
                        BytesOfImage = new Byte[fsReader.Length];
                        fsReader.Read(BytesOfImage, 0, BytesOfImage.Length);
                        fsReader.Close();
                        */
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return;
                    }
                    using (MemoryStream memory = new MemoryStream())
                    {
                        using (FileStream fs = new FileStream(currentDir + @"\obentoImages", FileMode.Create, FileAccess.ReadWrite))
                        {
                            Bitmap bm = Image.FromFile(fdlg.FileName) as Bitmap;
                            bm.Save(memory, System.Drawing.Imaging.ImageFormat.Jpeg);
                            byte[] bytes = memory.ToArray();
                            fs.Write(bytes, 0, bytes.Length);
                        }
                    }
                    
                } catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
        }

        public Byte[] BytesOfImage
        {
            get { return _bytesOfImage; }
            set { _bytesOfImage = value; }
        }

        private void btnAddStore_Click(object sender, EventArgs e)
        {
            if (tbStoreID.TextLength > 0 && tbStoreName.TextLength > 0 && tbStoreTel.TextLength > 0 && tbStoreAddress.TextLength > 0)
            {
                try
                {
                    int count = new LinkSQL().addStore(int.Parse(tbStoreID.Text), tbStoreName.Text, tbStoreTel.Text, tbStoreAddress.Text, tbPS.Text);
                    MessageBox.Show(string.Format("共 {0} 筆資料受影響", count));
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } else
            {
                MessageBox.Show("請輸入除了備註外的完整資料");
            }
        }

        private void btnDeleteStore_Click(object sender, EventArgs e)
        {
            if (tbStoreID.TextLength > 0)
            {
                try
                {
                    int count = new LinkSQL().deleteStore(int.Parse(tbStoreID.Text));
                    MessageBox.Show(string.Format("共 {0} 筆資料受影響", count));
                } catch (Exception ex)
                {
                    MessageBox.Show("資料格式有誤\n" + ex.Message);
                }
            } else
            {
                MessageBox.Show("請輸入店家編號");
            }
        }

        private void btnAddObento_Click(object sender, EventArgs e)
        {
            if (tbStoreID.TextLength > 0 && tbObentoID.TextLength > 0 && tbObentoName.TextLength > 0 && tbObentoPrice.TextLength > 0 && imgName != "")
            {
                try
                {
                    int count = new LinkSQL().addObento(int.Parse(tbObentoID.Text), tbObentoName.Text, int.Parse(tbObentoPrice.Text), int.Parse(tbStoreID.Text), imgName);
                    MessageBox.Show(string.Format("共 {0} 筆資料受影響", count));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("請輸入除了備註外的完整資料");
            }
        }

        private void btnDeleteObento_Click(object sender, EventArgs e)
        {
            if (tbObentoID.TextLength > 0)
            {
                try
                {
                    int count = new LinkSQL().deleteObento(int.Parse(tbObentoID.Text));
                    MessageBox.Show(string.Format("共 {0} 筆資料受影響", count));
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
