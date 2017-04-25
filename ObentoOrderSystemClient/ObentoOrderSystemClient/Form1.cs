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
        public Form1()
        {
            InitializeComponent();

            cbStudentName.Text = "";
            cbStudentName.Enabled = false;
            cbStoreName.Enabled = false;
        }

        private void chkbox_CheckedChanged(object sender, EventArgs e)
        {
            if(chkbox.Checked)
            {
                cbStoreName.Enabled = true;

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
            // TODO: 這行程式碼會將資料載入 'obentoDataSet1.studentTable' 資料表。您可以視需要進行移動或移除。
            this.studentTableTableAdapter.Fill(this.obentoDataSet1.studentTable);
            // SQL
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
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
        }

        private void tbStudentID_TextChanged(object sender, EventArgs e)
        {
        }

        private void tbStudentName_TextChanged(object sender, EventArgs e)
        {
        }

        private void cbClassroom_SelectedIndexChanged(object sender, EventArgs e)
        {
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

            while (sqlReader.Read())
            {
                cbStudentName.Items.Add(sqlReader["stuName"]);
            }

            sqlReader.Close();
            sqlCnct.Close();
        }

        private void cbStoreName_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Initialization of comboBox and listView
            lvStoreMenu.Items.Clear();
            cbObendoName.Items.Clear();

            // To read image files
            ImageList imageList = new ImageList();
            string storeName = cbStoreName.Text;
            DirectoryInfo imageDir = new DirectoryInfo(@"C:\obentoImages");

            foreach (FileInfo file in imageDir.GetFiles())
            {
                try
                {
                    imageList.Images.Add(Image.FromFile(file.FullName));
                } catch
                {
                    Console.WriteLine("This is not an image file");
                }
                
            }
            // To collect strings of obento informations from database
            ArrayList obentoArrayList = new ArrayList();

            SqlConnection sqlCnct = new SqlConnection(scsb.ToString());
            string strSQL = "";
            sqlCnct.Open();
            strSQL = "select o.obentoName, o.obentoPrice from storeTable as s inner join obentoTable as o on s.storeID = o.storeID where storeName = '"
                + storeName + "'";
            SqlCommand sqlCmd = new SqlCommand(strSQL, sqlCnct);
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
                Console.WriteLine(sqlReader["obentoName"] + " " + sqlReader["obentoPrice"]);
                obentoArrayList.Add(sqlReader["obentoName"] + " " + sqlReader["obentoPrice"]);
                cbObendoName.Items.Add(sqlReader["obentoName"].ToString());
            }
            foreach (string str in obentoArrayList)
            {

                lvStoreMenu.View = View.LargeIcon;
                imageList.ImageSize = new Size(64, 64);
                lvStoreMenu.LargeImageList = imageList;
                ListViewItem lvItem = new ListViewItem();
                lvItem.ImageIndex = 0;
                lvItem.Text = str;
                lvStoreMenu.Items.Add(lvItem);
            }

            sqlReader.Close();
            sqlCnct.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                LinkSQL linkSQL = new LinkSQL();
                if (lboxStuOrder.Items.Count == 0 && numUD.Value > 0)
                {
                    // if there is no item in the listBox, then add an item
                    lboxStuOrder.Items.Add(cbObendoName.Text + " " + linkSQL.getObentoPrice(cbStoreName.Text, cbObendoName.Text).ToString() + " * " + numUD.Value.ToString());
                } else if (lboxStuOrder.FindString(cbObendoName.Text) == -1 && numUD.Value > 0)
                {
                    // if lboxStuOrder.FindString() is -1, means the string is not in the listBox.
                    lboxStuOrder.Items.Add(cbObendoName.Text + " " + linkSQL.getObentoPrice(cbStoreName.Text, cbObendoName.Text).ToString() + " * " + numUD.Value.ToString());
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
            string[] strList = new string[3];

            foreach (string strLine in lboxStuOrder.Items)
            {
                strList = strLine.Split(' ');
                stuOrderPrice = linkSQL.getObentoPrice(cbStoreName.Text, strList[0]);
                stuOrderSum += stuOrderPrice * int.Parse(strList[3]);
            }

            //MessageBox.Show(stuOrderSum.ToString());
            lboxStuOrder.Items.Add("學生訂單小計： " + stuOrderSum.ToString() + " NTD");
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnCheck.Enabled = false;
        }
    }
}
