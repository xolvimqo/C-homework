using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Collections;

namespace ObentoOrderSystemClient
{
    public partial class Form1 : Form
    {
        SqlConnectionStringBuilder scsb;

        int studentID = 0;
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
            ArrayList strArrayList = new ArrayList();
            string[] strArray = new string[5];
            string name = "";
            string str = "";
            int sum = 0;

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
            }
        }

        private void cbClassroom_SelectedIndexChanged(object sender, EventArgs e)
        {
            int store_ID = 0;

            Initialization();

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

            imageList = new ReadImages().getImages();

            // To collect strings of obento informations from database
            ArrayList obentoArrayList = new LinkSQL().getMenuArrayList(storeName);

            foreach (string str in obentoArrayList)
            {
                cbObendoName.Items.Add(str);
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
                } else if (lboxStuOrder.FindString(cbObendoName.Text) == -1 && numUD.Value > 0)
                {
                    string[] stuOrder = new string[2];
                    stuOrder = cbObendoName.Text.Split(' ');
                    // if lboxStuOrder.FindString() is -1, means the string is not in the listBox.
                    lboxStuOrder.Items.Add(stuOrder[0] + " " + linkSQL.getObentoPrice(cbStoreName.Text, cbObendoName.Text) + " * " + numUD.Value.ToString());
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("請正確選擇商品和數量");
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
            //foreach(string strLine in lboxStuOrder.Items)
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

            LinkSQL linkSQL = new LinkSQL();
            studentID = linkSQL.getStudentID(cbStudentName.Text);
            //MessageBox.Show(studentID.ToString());
            if(chkbox.Enabled == false && cbStoreName.Text.Length > 0)
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
            string stuName = lboxUnpaidOrder.SelectedItem.ToString().Split(' ')[0];
            LinkSQL linkSQL = new LinkSQL();
            int countRows = linkSQL.changePaymentState(stuName, 1);

            MessageBox.Show(string.Format("共 {0} 筆資料受影響", countRows));
        }

        private void btnRefund_Click(object sender, EventArgs e)
        {
            string stuName = lboxPaidOrder.SelectedItem.ToString().Split(' ')[0];
            LinkSQL linkSQL = new LinkSQL();
            int countRows = linkSQL.changePaymentState(stuName, 0);

            MessageBox.Show(string.Format("共 {0} 筆資料受影響", countRows));
        }
    }
}
