using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsFinalProject
{
    public partial class FormSignUp : Form
    {
        public FormSignUp()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (this.txtboxEmail.Text.Length > 0 && this.txtboxPassword.Text.Length > 0)
            {
                if (this.txtboxPassword.Text == this.txtboxPasswordConfirmation.Text)
                {
                    LinkSQL linkSQL = new LinkSQL();
                    if(linkSQL.Registrate(this.txtboxEmail.Text, this.txtboxPassword.Text) > 0)
                    {
                        MessageBox.Show("Your account has been created!");
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Password and Confirmation do not match!!!");
                }
            }
            else
            {
                MessageBox.Show("Email and password cannot be empty!!!");
            }
        }
    }
}
