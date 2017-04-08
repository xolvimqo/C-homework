using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalHW
{
    public partial class Form1 : Form
    {
        bool numberSelected = false;
        int layoutType = 0;

        int[] randNum;
        int powerMax = 38;
        int todayMax = 39;

        int powerSelectedNumCount = 0;
        int powerSelectedSpecialNumCount = 0;
        int[] powerNums = new int[6];
        int powerSpecialNums = 0;

        int todaySelectedNumCount = 0;
        int[] todayNums = new int[5];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PowerLottery_Click(object sender, EventArgs e)
        {
        }
        private void TodayLottery539_Click(object sender, EventArgs e)
        {

        }

        void dynamicButton(int Count1, int Count2, TabPage a)
        {
            for (int i = 1; i <= Count1; i++)
            {
                Button dynamicBtn = new Button();
                dynamicBtn.BackColor = Color.White;
                dynamicBtn.ForeColor = Color.Black;
                dynamicBtn.Location = new Point(20 + 42 * ((i - 1) % 10), 20 + 42 * ((i - 1)/10));
                dynamicBtn.Size = new Size(40, 40);
                dynamicBtn.Text = i.ToString();
                dynamicBtn.Name = "btn" + i.ToString();
                dynamicBtn.Font = new Font("Times New Roman", 14);
                if (a == PowerLottery)
                {
                    dynamicBtn.Click += new EventHandler(powerMainBtn_Click);
                } else if (a == TodayLottery539)
                {
                    dynamicBtn.Click += new EventHandler(todayBtn_Click);
                }
                
                a.Controls.Add(dynamicBtn);
            }

            for (int i = 1; i <= Count2; i++)
            {
                Button dynamicBtn = new Button();
                dynamicBtn.BackColor = Color.White;
                dynamicBtn.ForeColor = Color.Black;
                dynamicBtn.Location = new Point(20 + 42 * ((i - 1)%10), 20 + 42 * ((Count1 / 10) + i / 10 + 2));
                dynamicBtn.Size = new Size(40, 40);
                dynamicBtn.Text = i.ToString();
                dynamicBtn.Name = "btni" + i.ToString();
                dynamicBtn.Font = new Font("Times New Roman", 14);
                dynamicBtn.Click += new EventHandler(powerSpecialBtn_Click);

                a.Controls.Add(dynamicBtn);
            }
        }

        void powerMainBtn_Click(object sender, EventArgs e)
        {
            Button currentBtn = (Button)sender;
            if (powerSelectedNumCount < 6)
            {
                powerNums[powerSelectedNumCount] = int.Parse(currentBtn.Text);
                powerSelectedNumCount++;
                currentBtn.BackColor = Color.Salmon;
                currentBtn.ForeColor = Color.White;
                if (powerSelectedNumCount == 6)
                {
                    Array.Sort(powerNums);
                    foreach (int i in powerNums)
                    {
                        lblOutput.Text += i.ToString() + "  ";
                    }
                }
            }
        }

        void powerSpecialBtn_Click(object sender, EventArgs e)
        {
            Button currentBtn = (Button)sender;
            if (powerSelectedSpecialNumCount < 1)
            {
                powerSpecialNums = int.Parse(currentBtn.Text);
                powerSelectedSpecialNumCount++;
                currentBtn.BackColor = Color.Salmon;
                currentBtn.ForeColor = Color.White;
                if (powerSelectedNumCount == 6 && powerSelectedSpecialNumCount == 1)
                {
                    lblOutput.Text += ",special number :" + powerSpecialNums.ToString();
                }
            }
        }

        void todayBtn_Click(object sender, EventArgs e)
        {
            Button currentBtn = (Button)sender;
            if (todaySelectedNumCount < 5)
            {
                todayNums[todaySelectedNumCount] = int.Parse(currentBtn.Text);
                todaySelectedNumCount++;
                currentBtn.BackColor = Color.Salmon;
                currentBtn.ForeColor = Color.White;
                if (todaySelectedNumCount == 5)
                {
                    Array.Sort(todayNums);
                    foreach (int i in todayNums) {
                        lblOutput.Text += i.ToString() + "  ";
                    }
                }
            }
        }

        private void PowerLottery_Layout(object sender, LayoutEventArgs e)
        {
            layoutType = 1;
            dynamicButton(powerMax, 8, PowerLottery);
        }

        private void todayLottery539_Layout(object sender, LayoutEventArgs e)
        {
            layoutType = 2;
            dynamicButton(todayMax, 0, TodayLottery539);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int iNum = 0;
            int maxNum = 0;
            int arrayLength = 0;
            int[] arrayNums;
            

            if (layoutType == 1)
            {
                maxNum = powerMax;
                arrayLength = 6;
                arrayNums = new int[arrayLength];
                arrayNums = powerNums;
                int specialNum = powerSpecialNums;
                if (arrayNums.Length > 0 && specialNum > 0)
                {
                    numberSelected = true;
                }
            } else if (layoutType == 2)
            {
                maxNum = todayMax;
                arrayLength = 5;
                arrayNums = new int[arrayLength];
                arrayNums = todayNums;
                if( arrayNums.Length > 0)
                {
                    numberSelected = true;
                }
            }

            if (numberSelected)
            {
                Random rand = new Random();
                randNum = new int[arrayLength];

                do
                {
                    if (iNum > 0)
                    {
                        randNum[iNum] = rand.Next(1, maxNum + 1);
                        for (int i = 0; i < iNum; i++)
                        {
                            if (randNum[i] == randNum[iNum])
                            {
                                break;
                            }
                            else if (i == iNum - 1)
                            {
                                iNum++;
                                break; // to avoid error from infinited loop like (int i = 0; i < f; i++) { f++; }
                            }
                        }
                    }
                    else
                    {
                        randNum[iNum] = rand.Next(1, maxNum + 1);
                        iNum++;
                    }
                } while (iNum < arrayLength);

                Array.Sort(randNum);

                foreach (int i in randNum)
                {
                    tbRandom.Text += i.ToString() + "  ";
                }

                if (layoutType == 1)
                {
                    tbRandom.Text += ", special number: " + rand.Next(1, 9).ToString();
                }

                CompareNumbers compareNum = new CompareNumbers();
                foreach (int sameNum in compareNum.findSameNumbers(powerNums, randNum))
                {
                    if (sameNum != 0)
                    {
                        lblOutput.Text += sameNum.ToString();
                    } 
                }

            } else
            {
                MessageBox.Show("{Please select numbers.");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (layoutType == 1)
            {
                powerNums = new int[6];
                powerSpecialNums = 0;
                powerSelectedNumCount = 0;
                powerSelectedSpecialNumCount = 0;
                PowerLottery.Controls.Clear();
            } else if (layoutType == 2)
            {
                todayNums = new int[5];
                todaySelectedNumCount = 0;
                TodayLottery539.Controls.Clear();
            }

            tbRandom.Text = "";
            lblOutput.Text = "";
            
        }
    }
}
