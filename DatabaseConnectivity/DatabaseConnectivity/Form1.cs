using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseConnectivity
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Last_\source\repos\DatabaseConnectivity\DatabaseConnectivity\ConnDatabase.mdf;Integrated Security=True";
        SqlConnection conn;
        int selectedRowId;

        // Set control visible to false

        private void btnCheckConnection_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    MessageBox.Show("Connection is opened!");
                } 
                else
                {
                    MessageBox.Show("Connection is closed!");
                    conn.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            txtboxCourseName.Visible = false;
            lblCourseName.Visible = false;
            btnSave.Visible = false;
            BindData();
        }

        // Bind data to data grid on form load
        public void BindData()
        {
            string sqlCmd = "SELECT * FROM Student";
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCmd, conn);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            conn.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "INSERT INTO Student VALUES('" + txtboxCourseName.Text + "');";
                conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Saved");
                conn.Close();
                txtboxCourseName.Visible = false;
                lblCourseName.Visible = false;
                btnSave.Visible = false;
                BindData();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            selectedRowId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtboxCourseName.Visible = true;
            lblCourseName.Visible = true;
            btnSave.Visible = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE Student SET name = '" + txtboxUpdate.Text + "' WHERE id = " + selectedRowId;

            conn.Open();
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            conn.Close();
            BindData();
        }
    }
}
