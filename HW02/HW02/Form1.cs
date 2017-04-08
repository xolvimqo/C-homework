using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW02
{
    public partial class Form1 : Form
    {
        bool isInTheMiddleOfTyping = false;
        int val1, val2;
        string symb = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (isInTheMiddleOfTyping)
            {
                lblScreen.Text = lblScreen.Text + btn0.Text;
            }
            else
            {
                lblScreen.Text = btn0.Text;
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (isInTheMiddleOfTyping)
            {
                lblScreen.Text = lblScreen.Text + btn1.Text;
            }
            else
            {
                lblScreen.Text = btn1.Text;
                isInTheMiddleOfTyping = true;
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (isInTheMiddleOfTyping)
            {
                lblScreen.Text = lblScreen.Text + btn2.Text;
            }
            else
            {
                lblScreen.Text = btn2.Text;
                isInTheMiddleOfTyping = true;
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (isInTheMiddleOfTyping)
            {
                lblScreen.Text = lblScreen.Text + btn3.Text;
            }
            else
            {
                lblScreen.Text = btn3.Text;
                isInTheMiddleOfTyping = true;
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (isInTheMiddleOfTyping)
            {
                lblScreen.Text = lblScreen.Text + btn4.Text;
            }
            else
            {
                lblScreen.Text = btn4.Text;
                isInTheMiddleOfTyping = true;
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (isInTheMiddleOfTyping)
            {
                lblScreen.Text = lblScreen.Text + btn5.Text;
            }
            else
            {
                lblScreen.Text = btn5.Text;
                isInTheMiddleOfTyping = true;
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (isInTheMiddleOfTyping)
            {
                lblScreen.Text = lblScreen.Text + btn6.Text;
            }
            else
            {
                lblScreen.Text = btn6.Text;
                isInTheMiddleOfTyping = true;
            }
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (isInTheMiddleOfTyping)
            {
                lblScreen.Text = lblScreen.Text + btn7.Text;
            }
            else
            {
                lblScreen.Text = btn7.Text;
                isInTheMiddleOfTyping = true;
            }
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (isInTheMiddleOfTyping)
            {
                lblScreen.Text = lblScreen.Text + btn8.Text;
            }
            else
            {
                lblScreen.Text = btn8.Text;
                isInTheMiddleOfTyping = true;
            }
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (isInTheMiddleOfTyping)
            {
                lblScreen.Text = lblScreen.Text + btn9.Text;
            }
            else
            {
                lblScreen.Text = btn9.Text;
                isInTheMiddleOfTyping = true;
            }
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            val1 = Convert.ToInt32(lblScreen.Text);
            symb = btnMinus.Text;
            isInTheMiddleOfTyping = false;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            val1 = Convert.ToInt32(lblScreen.Text);
            symb = btnMultiply.Text;
            isInTheMiddleOfTyping = false;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            val1 = Convert.ToInt32(lblScreen.Text);
            symb = btnDivide.Text;
            isInTheMiddleOfTyping = false;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            val1 = Convert.ToInt32(lblScreen.Text);
            symb = btnPercent.Text;
            isInTheMiddleOfTyping = false;
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            if(symb != "" && isInTheMiddleOfTyping == true)
            {
                val2 = Convert.ToInt32(lblScreen.Text);
                switch (symb)
                {
                    case "+":
                        lblScreen.Text = Convert.ToString(val1 + val2);
                        break;
                    case "-":
                        lblScreen.Text = Convert.ToString(val1 - val2);
                        break;
                    case "*":
                        lblScreen.Text = Convert.ToString(val1 * val2);
                        break;
                    case "/":
                        lblScreen.Text = Convert.ToString(val1 / val2);
                        break;
                    case "%":
                        lblScreen.Text = Convert.ToString(val1 % val2);
                        break;
                    default:
                        break;
                }
                val1 = Convert.ToInt32(lblScreen.Text);
                isInTheMiddleOfTyping = false;

            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            val1 = Convert.ToInt32(lblScreen.Text);
            symb = btnPlus.Text;
            isInTheMiddleOfTyping = false;
        }
    }
}
