using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW03
{
    public partial class Form1 : Form
    {
        string strMessage = "";
        int intExtend = 0;
        int intCompress = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            

            if (tbCompress.Text.Length > 0 && tbExtend.Text.Length > 0)
            {
                try
                {
                    intExtend = Convert.ToInt32(tbExtend.Text);
                    intCompress = Convert.ToInt32(tbCompress.Text);
                }
                catch (Exception err)
                {
                    //MessageBox.Show(Convert.ToString(err));
                    MessageBox.Show("請輸入正確的血壓");
                }

                if (intExtend < intCompress)
                {
                    if (intCompress < 120)
                    {
                        strMessage = "理想血壓";
                        if (intExtend > 80)
                        {
                            strMessage += "，但舒張壓過高";
                        }
                    }
                    else if (intCompress < 130)
                    {
                        strMessage = "正常血壓";
                        if (intExtend < 85)
                        {
                            strMessage += "，但舒張壓過高";
                        }
                    }
                    else if (intCompress <= 139 && intCompress >= 130)
                    {
                        strMessage = "正常但偏高";
                        if (intExtend > 89)
                        {
                            strMessage += "，且舒張壓過高";
                        }
                        else if (intExtend < 85)
                        {
                            strMessage += "，且舒張壓過低";
                        }
                    }
                    else if (intCompress <= 159 && intCompress >= 140)
                    {
                        strMessage = "第一期";
                        if (intExtend > 99)
                        {
                            strMessage += "，且舒張壓過高";
                        }
                        else if (intExtend < 90)
                        {
                            strMessage += "，且舒張壓過低";
                        }
                    }
                    else if (intCompress <= 179 && intCompress >= 160)
                    {
                        strMessage = "第二期";
                        if (intExtend > 109)
                        {
                            strMessage += "，且舒張壓過高";
                        }
                        else if (intExtend < 100)
                        {
                            strMessage += "，且舒張壓過低";
                        }
                    }
                    else if (intCompress >= 180 || intExtend >= 110)
                    {
                        strMessage = "第三期";
                    }
                }
                lblMessage.Text = strMessage;

            } else
            {

            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            strMessage = "";
            lblMessage.Text = "";
            intCompress = 0;
            intExtend = 0;
        }
    }
}
