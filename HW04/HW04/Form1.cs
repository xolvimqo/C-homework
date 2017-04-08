using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW04
{
    public partial class Form1 : Form
    {
        //Class 類別變數
        int quantity1 = 0, quantity2 = 0, quantity3 = 0, quantity4 = 0, quantity5 = 0;
        float price1 = 0.0f, price2 = 0.0f, price3 = 0.0f, price4 = 0.0f, price5 = 0.0f;
        bool isInAEvent = false;
        float[] price = new float[5];
        int[] quantity = new int[5];
        int eventNum = 0;
        float priceSum1 = 0.0f, priceSum2 = 0.0f, priceSum3 = 0.0f, priceSum4 = 0.0f, priceSum5 = 0.0f;
        float discount = 0.0f, totalPrice = 0.0f, discountPrice = 0.0f;

        private void tbQuantity2_TextChanged(object sender, EventArgs e)
        {
            Int32.TryParse(tbQuantity2.Text, out quantity2);
            countSum();
        }

        private void tbQuantity3_TextChanged(object sender, EventArgs e)
        {
            Int32.TryParse(tbQuantity3.Text, out quantity3);
            countSum();
        }

        private void tbQuantity4_TextChanged(object sender, EventArgs e)
        {
            Int32.TryParse(tbQuantity4.Text, out quantity4);
            countSum();
        }

        private void tbQuantity5_TextChanged(object sender, EventArgs e)
        {
            Int32.TryParse(tbQuantity5.Text, out quantity5);
            countSum();
        }

        private void tbDiscount_TextChanged(object sender, EventArgs e)
        {
            float.TryParse(tbDiscount.Text, out discount);
            if (discount >= 0 && discount <= 10)
            {
                countSum();
            } else
            {
                MessageBox.Show("Not a correct discount, please input a value between 0 and 10.");
            }
        }

        private void btnSendOrder_Click(object sender, EventArgs e)
        {
            isInAEvent = false;
            DialogResult diaResult;
            diaResult = MessageBox.Show("Are you sure to send lists?", "check",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (diaResult == DialogResult.No)
            {
                // Cancel
            }
            else
            {
                // Okay
                string strOrderList = "****** III 冷飲訂購單 ******\n";
                strOrderList += "---------------------------------\n";
                switch (eventNum)
                {
                    case 1:
                        strOrderList += "任選買一送一優惠\n";
                        break;
                    case 2:
                        strOrderList += "同品項買二送一優惠\n";
                        break;
                    default:
                        break;
                }
                if (quantity1 > 0)
                {
                    strOrderList += lblProduct1.Text + ":" + lblPrice1.Text
                        + "x" + tbQuantity1.Text + "="
                        + priceSum1.ToString() + "\n";
                }
                if (quantity2 > 0)
                {
                    strOrderList += lblProduct2.Text + ":" + lblPrice2.Text
                        + "x" + tbQuantity2.Text + "="
                        + priceSum2.ToString() + "\n";
                }
                if (quantity3 > 0)
                {
                    strOrderList += lblProduct3.Text + ":" + lblPrice3.Text
                        + "x" + tbQuantity3.Text + "="
                        + priceSum3.ToString() + "\n";
                }
                if (quantity4 > 0)
                {
                    strOrderList += lblProduct4.Text + ":" + lblPrice4.Text
                        + "x" + tbQuantity4.Text + "="
                        + priceSum4.ToString() + "\n";
                }
                if (quantity5 > 0)
                {
                    strOrderList += lblProduct5.Text + ":" + lblPrice5.Text
                        + "x" + tbQuantity5.Text + "="
                        + priceSum5.ToString() + "\n";
                }
                strOrderList += "---------------------------------\n";
                if (discount < 10.0f)
                {
                    strOrderList += "Discount" + string.Format("{0:F2}", discount) + "\n";
                }
                strOrderList += "Total price : " + string.Format("{0:C}", totalPrice) + "\n";
                strOrderList += "Discounted price : " + string.Format("{0:C}", discountPrice) + "\n";
                strOrderList += string.Format("{0:D}", DateTime.Now) + "\n";
                strOrderList += string.Format("{0:T}", DateTime.Now) + "\n";
                MessageBox.Show(strOrderList, "Order details", MessageBoxButtons.OK);
            }
        }

        private void btnB2G1_Click(object sender, EventArgs e)
        {
            if (!isInAEvent)
            {
                btnB2G1.BackColor = Color.Salmon;
                isInAEvent = true;

                eventNum = 2;
            }
            countSum();
        }

        private void btnB1G1_Click(object sender, EventArgs e)
        {
            if (!isInAEvent)
            {
                btnB1G1.BackColor = Color.Salmon;
                isInAEvent = true;

                eventNum = 1;
            }
            countSum();
        }

        private void tbQuantity1_TextChanged(object sender, EventArgs e)
        {
            Int32.TryParse(tbQuantity1.Text, out quantity1);
            countSum();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblProduct1.Text = "麥香紅茶";
            lblProduct2.Text = "茉莉綠茶";
            lblProduct3.Text = "珍珠奶茶";
            lblProduct4.Text = "玫瑰花茶";
            lblProduct5.Text = "西瓜汁";

            price1 = 35.0f;
            price2 = 40.0f;
            price3 = 45.0f;
            price4 = 50.0f;
            price5 = 55.0f;

            price[0] = price1;
            price[1] = price2;
            price[2] = price3;
            price[3] = price4;
            price[4] = price5;

            lblPrice1.Text = price1.ToString();
            lblPrice2.Text = price2.ToString();
            lblPrice3.Text = price3.ToString();
            lblPrice4.Text = price4.ToString();
            lblPrice5.Text = price5.ToString();

            discount = 10.0f;
        }

        private void btnMinus1_Click(object sender, EventArgs e)
        {
            if (tbQuantity1.Text.Length == 0)
            {
            }
            else
            {
                if (tbQuantity1.Text == "0") { }
                else
                {
                    try
                    {
                        int quantity = int.Parse(tbQuantity1.Text) - 1;
                        tbQuantity1.Text = Convert.ToString(quantity);
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(Convert.ToString(error));
                        tbQuantity1.Text = "0";
                    }
                }
            }
            countSum();
        }

        private void btnMinus2_Click(object sender, EventArgs e)
        {
            if (tbQuantity2.Text.Length == 0)
            {
            }
            else
            {
                if (tbQuantity2.Text == "0") { }
                else
                {
                    try
                    {
                        int quantity = int.Parse(tbQuantity2.Text) - 1;
                        tbQuantity2.Text = Convert.ToString(quantity);
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(Convert.ToString(error));
                        tbQuantity2.Text = "0";
                    }
                }
            }
            countSum();
        }

        private void btnMinus3_Click(object sender, EventArgs e)
        {
            if (tbQuantity3.Text.Length == 0)
            {
            }
            else
            {
                if (tbQuantity3.Text == "0") { }
                else
                {
                    try
                    {
                        int quantity = int.Parse(tbQuantity3.Text) - 1;
                        tbQuantity3.Text = Convert.ToString(quantity);
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(Convert.ToString(error));
                        tbQuantity3.Text = "0";
                    }
                }
            }
            countSum();
        }

        private void btnMinus4_Click(object sender, EventArgs e)
        {
            if (tbQuantity4.Text.Length == 0)
            {
            }
            else
            {
                if (tbQuantity4.Text == "0") { }
                else
                {
                    try
                    {
                        int quantity = int.Parse(tbQuantity4.Text) - 1;
                        tbQuantity4.Text = Convert.ToString(quantity);
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(Convert.ToString(error));
                        tbQuantity4.Text = "0";
                    }
                }
            }
            countSum();
        }

        private void btnMinus5_Click(object sender, EventArgs e)
        {
            if (tbQuantity5.Text.Length == 0)
            {
            }
            else
            {
                if (tbQuantity5.Text == "0") { }
                else
                {
                    try
                    {
                        int quantity = int.Parse(tbQuantity5.Text) - 1;
                        tbQuantity5.Text = Convert.ToString(quantity);
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(Convert.ToString(error));
                        tbQuantity5.Text = "0";
                    }
                }
            }
            countSum();
        }

        private void btnPlus1_Click(object sender, EventArgs e)
        {
            if (tbQuantity1.Text.Length == 0)
            {
                tbQuantity1.Text = "1";
            }
            else
            {
                try
                {
                    int quantity = int.Parse(tbQuantity1.Text) + 1;
                    tbQuantity1.Text = Convert.ToString(quantity);
                }
                catch (Exception error)
                {
                    MessageBox.Show(Convert.ToString(error));
                    tbQuantity1.Text = "0";
                }
            }
            countSum();
        }

        private void btnPlus2_Click(object sender, EventArgs e)
        {
            if (tbQuantity2.Text.Length == 0)
            {
                tbQuantity2.Text = "1";
            }
            else
            {
                try
                {
                    int quantity = int.Parse(tbQuantity2.Text) + 1;
                    tbQuantity2.Text = Convert.ToString(quantity);
                }
                catch (Exception error)
                {
                    MessageBox.Show(Convert.ToString(error));
                    tbQuantity2.Text = "0";
                }
            }
            countSum();
        }

        private void btnPlus3_Click(object sender, EventArgs e)
        {
            if (tbQuantity3.Text.Length == 0)
            {
                tbQuantity3.Text = "1";
            }
            else
            {
                try
                {
                    int quantity = int.Parse(tbQuantity3.Text) + 1;
                    tbQuantity3.Text = Convert.ToString(quantity);
                }
                catch (Exception error)
                {
                    MessageBox.Show(Convert.ToString(error));
                    tbQuantity3.Text = "0";
                }
            }
            countSum();
        }

        private void btnPlus4_Click(object sender, EventArgs e)
        {
            if (tbQuantity4.Text.Length == 0)
            {
                tbQuantity4.Text = "1";
            }
            else
            {
                try
                {
                    int quantity = int.Parse(tbQuantity4.Text) + 1;
                    tbQuantity4.Text = Convert.ToString(quantity);
                }
                catch (Exception error)
                {
                    MessageBox.Show(Convert.ToString(error));
                    tbQuantity4.Text = "0";
                }
            }
            countSum();
        }

        private void btnPlus5_Click(object sender, EventArgs e)
        {
            if (tbQuantity5.Text.Length == 0)
            {
                tbQuantity5.Text = "1";
            }
            else
            {
                try
                {
                    int quantity = int.Parse(tbQuantity5.Text) + 1;
                    tbQuantity5.Text = Convert.ToString(quantity);
                }
                catch (Exception error)
                {
                    MessageBox.Show(Convert.ToString(error));
                    tbQuantity5.Text = "0";
                }
            }
            countSum();
        }
        void countSum()
        {
            System.Int32.TryParse(tbQuantity1.Text, out quantity1);
            System.Int32.TryParse(tbQuantity2.Text, out quantity2);
            System.Int32.TryParse(tbQuantity3.Text, out quantity3);
            System.Int32.TryParse(tbQuantity4.Text, out quantity4);
            System.Int32.TryParse(tbQuantity5.Text, out quantity5);

            quantity[0] = quantity1;
            quantity[1] = quantity2;
            quantity[2] = quantity3;
            quantity[3] = quantity4;
            quantity[4] = quantity5;

            switch (eventNum)
            {
                case 1:
                    int qSum = quantity.Sum() / 2;
                    if (qSum > 0)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            if (quantity[i] < qSum)
                            {
                                qSum -= quantity[i];
                                quantity[i] = 0;
                            }
                            else
                            {
                                quantity[i] -= qSum;
                                qSum = 0;
                            }
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < 5; i++)
                    {
                        if (quantity[i] > 2)
                        {
                            quantity[i] -= quantity[i] / 3;
                        }
                    }
                    break;
                default:
                    break;
            }

            priceSum1 = price1 * quantity[0];
            priceSum2 = price2 * quantity[1];
            priceSum3 = price3 * quantity[2];
            priceSum4 = price4 * quantity[3];
            priceSum5 = price5 * quantity[4];

            totalPrice = priceSum1 + priceSum2 + priceSum3 + priceSum4 + priceSum5;
            discountPrice = totalPrice * discount / 10.0f;

            tbTotalPrice.Text = string.Format("{0:C}", totalPrice);
            tbDiscountPrice.Text = string.Format("{0:C}", discountPrice);
        }
    }
}
