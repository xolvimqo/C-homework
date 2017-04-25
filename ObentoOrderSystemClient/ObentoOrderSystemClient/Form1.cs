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
            ImageList imageList = new ImageList();
            string storeName = cbStoreName.Text;
            String[] imageFiles = Directory.GetFiles(@"C:\obentoImages");

            foreach (var file in imageFiles)
            {
                imageList.Images.Add(Image.FromFile(file));
            }

            lvStoreMenu.LargeImageList = imageList;
            lvStoreMenu.SmallImageList = imageList;
            lvStoreMenu.View = View.Details; // Enables Details view so you can see columns

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
                //lvStoreMenu.Items.Add(new ListViewItem { ImageIndex = 0, Text = sqlReader["obentoName"].ToString() + " " + sqlReader["obentoPrice"] });
                cbObendoName.Items.Add(sqlReader["obentoName"].ToString() + " " + sqlReader["obentoPrice"]);
            }

            sqlReader.Close();
            sqlCnct.Close();
        }
    }
}
