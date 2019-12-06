using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseConnectivity
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Last_\source\repos\DatabaseConnectivity\DatabaseConnectivity\ConnDatabase.mdf;Integrated Security=True";
        SqlConnection conn;
        int selectedRowId;

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

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            selectedRowId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            if (txtboxCourseName.Text != "")
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Student(name) VALUES (@name)", conn);

                cmd.Parameters.AddWithValue("@name", txtboxCourseName.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Record insert successfully");
                BindData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please provide details!");
            }
        }

        public void ClearData()
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            if (txtboxUpdate.Text != "")
            {
                SqlCommand cmd = new SqlCommand("UPDATE Student SET name = @name WHERE id = @id", conn);

                cmd.Parameters.AddWithValue("@name", txtboxUpdate.Text);
                cmd.Parameters.AddWithValue("@id", selectedRowId);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Record update successfully");
                BindData();
                ClearData();
                txtboxUpdate.Text = "";
            }
            else
            {
                MessageBox.Show("Please provide details!");
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            txtboxCourseName.Visible = false;
            lblCourseName.Visible = false;
            btnSave.Visible = false;
            BindData();
        }

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtboxCourseName.Visible = true;
            lblCourseName.Visible = true;
            btnSave.Visible = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM Student WHERE id = @id", conn);

            cmd.Parameters.AddWithValue("@id", selectedRowId);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Record delete successfully");
            BindData();
            ClearData();
        }
    }
}
