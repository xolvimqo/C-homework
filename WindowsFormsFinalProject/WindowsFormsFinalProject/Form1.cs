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

namespace WindowsFormsFinalProject
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            FormSignUp formSignUp = new FormSignUp();
            formSignUp.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LinkSQL linkSQL = new LinkSQL();
            if (linkSQL.EmailPasswordMatches(this.txtboxEmail.Text, this.txtboxPassword.Text))
            {
                FormResumaManager formResumaManager = new FormResumaManager(this.txtboxEmail.Text, this.txtboxPassword.Text);
                formResumaManager.ShowDialog();
            }
            else
            {
                MessageBox.Show("Account doesn't be found or wrong password!");
            }
        }
    }
}
