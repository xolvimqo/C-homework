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

namespace FinalHW
{
    public partial class Form1 : Form
    {
        //Local Database
        SqlConnectionStringBuilder scsb;
        // to set a group of numbers is selected.
        bool numberSelected = false;
        // Power lottery is 1, Today lottery is 2
        int layoutType = 0;
        // to set different groups of numbers that are operated currently
        int groupNum = 0;
        // random array
        int[] randNum;
        // Maximum number that can selected in lottery
        int powerMax = 38;
        int todayMax = 39;
        // to count selected numbers in a group
        int powerSelectedNumCount = 0; 
        int todaySelectedNumCount = 0;
        int powerSelectedSpecialNumCount = 0;

        // set arrays for groups of numbers
        int[,] powerNums = new int[50,6];
        int[] powerSpecialNums = new int[50];
        int[,] todayNums = new int[50,5];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            //Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = F:\iii\c#程式設計\FinalHW\FinalHW\history.mdf;Integrated Security=True
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @"(localDB)\MSSQLLocalDB";
            scsb.InitialCatalog = "Database1";
            scsb.IntegratedSecurity = true;
            */
        }

        private void PowerLottery_Click(object sender, EventArgs e)
        {
        }
        private void TodayLottery539_Click(object sender, EventArgs e)
        {

        }

        void dynamicButton(int Count1, int Count2, TabPage a)
        {
            // set main numbers button
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
            // set special number button
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
                powerNums[groupNum,powerSelectedNumCount] = int.Parse(currentBtn.Text);
                if (powerSelectedNumCount > 0 && powerNums[groupNum, powerSelectedNumCount] != powerNums[groupNum, powerSelectedNumCount - 1])
                {
                    powerSelectedNumCount++;
                    currentBtn.BackColor = Color.Salmon;
                    currentBtn.ForeColor = Color.White;
                } else if (powerSelectedNumCount == 0)
                {
                    powerSelectedNumCount++;
                    currentBtn.BackColor = Color.Salmon;
                    currentBtn.ForeColor = Color.White;
                }
                // to layout selected number when the last number be selected in a group 
                if (powerSelectedNumCount == 6)
                {
                    int[] tempArray = new int[6];
                    for (int i = 0; i < 6; i++) {
                        tempArray[i] = powerNums[groupNum, i];
                    }
                    Array.Sort(tempArray);
                    foreach (int i in tempArray)
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
                powerSpecialNums[groupNum] = int.Parse(currentBtn.Text);
                powerSelectedSpecialNumCount++;
                currentBtn.BackColor = Color.Salmon;
                currentBtn.ForeColor = Color.White;
                // to reset counting of numbers when a group of numbers is completed and layout special number
                if (powerSelectedNumCount == 6 && powerSelectedSpecialNumCount == 1)
                {
                    lblOutput.Text += ",special number :" + powerSpecialNums[groupNum].ToString() + "\n";
                    powerSelectedNumCount = 0;
                    powerSelectedSpecialNumCount = 0;
                }
            }
        }

        void todayBtn_Click(object sender, EventArgs e)
        {
            Button currentBtn = (Button)sender;
            if (todaySelectedNumCount < 5)
            {
                todayNums[groupNum,todaySelectedNumCount] = int.Parse(currentBtn.Text);
                if (todaySelectedNumCount > 0 && todayNums[groupNum, todaySelectedNumCount] != todayNums[groupNum, todaySelectedNumCount - 1])
                {
                    todaySelectedNumCount++;
                    currentBtn.BackColor = Color.Salmon;
                    currentBtn.ForeColor = Color.White;
                } else if (todaySelectedNumCount == 0)
                {
                    todaySelectedNumCount++;
                    currentBtn.BackColor = Color.Salmon;
                    currentBtn.ForeColor = Color.White;
                }
                if (todaySelectedNumCount == 5)
                {
                    int[] tempArray = new int[5];
                    for (int i = 0; i < 5; i++) {
                        tempArray[i] = todayNums[groupNum, i];
                    }
                    
                    Array.Sort(tempArray);
                    foreach (int i in tempArray) {
                        lblOutput.Text += i.ToString() + "  ";
                    }
                    todaySelectedNumCount = 0;
                }
            }
        }

        private void PowerLottery_Layout(object sender, LayoutEventArgs e)
        {
            // initialize dynamic buttons and layout type
            layoutType = 1;
            dynamicButton(powerMax, 8, PowerLottery);
        }

        private void todayLottery539_Layout(object sender, LayoutEventArgs e)
        {
            // initialize dynamic buttons and layout type
            layoutType = 2;
            dynamicButton(todayMax, 0, TodayLottery539);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // to set position of numbers in random array
            int iNum = 0;
            // the maximum of random array that is dependent on layout type
            int maxNum = 0;

            int arrayLength = 0;
            // Temporary arrays
            int[,] arrayNums;
            int[] fittedSpecialNums = new int[groupNum + 1];

            bool haveFitted = false;
            string myStr = "";
            int countGroup = 0;

            if (layoutType == 1)
            {
                maxNum = powerMax;
                arrayLength = 6;
                arrayNums = new int[groupNum + 1, arrayLength];
                arrayNums = powerNums;
                if (arrayNums.Length > 0 && powerSpecialNums.Length > 0)
                {
                    numberSelected = true;
                }
            } else if (layoutType == 2)
            {
                maxNum = todayMax;
                arrayLength = 5;
                arrayNums = new int[groupNum + 1, arrayLength];
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
                RandomArray randArray = new RandomArray();

                randNum = randArray.set(maxNum, arrayLength);

                Array.Sort(randNum);

                tbRandom.Text += "Winning Numbers: ";

                foreach (int i in randNum)
                {
                    tbRandom.Text += i.ToString() + "  ";
                }

                CompareNumbers compareNum = new CompareNumbers();
                
                lblOutput.Text += "\nFitted Number: \n";

                if (layoutType == 1)
                {
                    // to fit each group numbers with winning numbers
                    compareNum.setCompareNumbers(powerNums, randNum, groupNum, layoutType);
                    int[] tempNum = new int[compareNum.getlength()];

                    // set fitted numbers to tempNum
                    tempNum = compareNum.findSameNumbers();
                    // to get a winning special number
                    int randSpecialNum = 0;
                    randSpecialNum = rand.Next(1, 8);
                    tbRandom.Text += ", special number: " + randSpecialNum.ToString() + "\n";

                    for (int i = 0; i < groupNum; i++)
                    {
                        if (powerSpecialNums[i] == randSpecialNum)
                        {
                            fittedSpecialNums[i] = randSpecialNum;
                        } else
                        {
                            fittedSpecialNums[i] = 0;
                        }
                    }

                    // to layout fitting results to lblOutput.Text
                    for (int i = 0; i < tempNum.Length; i++)
                    {
                        if (tempNum[i] > 0)
                        {
                            haveFitted = true;
                            myStr += tempNum[i].ToString() + "  ";
                        } else if (fittedSpecialNums[i / 6] > 0)
                        {
                            haveFitted = true;
                        }

                        if (((i + 1) % 6) == 0)
                        {
                            if (haveFitted)
                            {
                                lblOutput.Text += "\n##############################";
                                lblOutput.Text += "\nThe fitted number(s) in group " + countGroup.ToString() + " :\n" + myStr;
                                if (fittedSpecialNums[i/6] != 0)
                                {
                                    lblOutput.Text += "\nSpecial num:" + fittedSpecialNums[i / 6].ToString() + "\n";
                                }
                                haveFitted = false;
                            } else
                            {
                                lblOutput.Text += "\n##############################";
                                lblOutput.Text += "\nThere are no fitted number in group " + countGroup.ToString();
                            }
                            countGroup++;
                            myStr = "";
                        }
                    }
                    

                } else if (layoutType == 2)
                {
                    // to fit each group numbers with winning numbers
                    compareNum.setCompareNumbers(todayNums, randNum, groupNum, layoutType);
                    int[] tempNum = new int[compareNum.getlength()];

                    // set fitted numbers to tempNum
                    tempNum = compareNum.findSameNumbers();
                    for (int i = 0; i < tempNum.Length; i++)
                    {
                        if (tempNum[i] > 0)
                        {
                            haveFitted = true;
                            myStr += tempNum[i].ToString() + "  ";
                        }

                        if (((i + 1) % 5) == 0)
                        {
                            if (haveFitted)
                            {
                                lblOutput.Text += "\n##############################";
                                lblOutput.Text += "\nThe fitted number(s) in group " + countGroup.ToString() + " :\n" + myStr;
                                haveFitted = false;
                            }
                            else
                            {
                                lblOutput.Text += "\n##############################";
                                lblOutput.Text += "\nThere are no fitted number in group " + countGroup.ToString();
                            }
                            countGroup++;
                            myStr = "";
                        }
                    }
                }

            } else
            {
                MessageBox.Show("{Please select numbers.");
            }
            /*
            // add history to LocalDB
            SqlConnection sqlConnection = new SqlConnection(scsb.ToString());
            sqlConnection.Open();
            string strSQL = "insert into history values( @NewHistory)";
            SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@NewHistory", lblOutput.Text);
            sqlConnection.Close();
            */
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (layoutType == 1)
            {
                powerNums = new int[groupNum, 6];
                powerSpecialNums = new int[groupNum];
                powerSelectedNumCount = 0;
                powerSelectedSpecialNumCount = 0;
                PowerLottery.Controls.Clear();
            } else if (layoutType == 2)
            {
                todayNums = new int[groupNum, 5];
                todaySelectedNumCount = 0;
                TodayLottery539.Controls.Clear();
            }

            groupNum = 0;
            tbRandom.Text = "";
            lblOutput.Text = "";
            
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            RandomArray randArray;

            if (layoutType == 1)
            {
                if (powerSelectedNumCount == 0 && powerSelectedSpecialNumCount == 0)
                {
                    int count = 0;
                    randArray = new RandomArray();
                    randNum = new int[6];
                    randNum = randArray.set(powerMax, 6);
                    powerSpecialNums[groupNum] = rand.Next(8) + 1;
                    Array.Sort(randNum);
                    foreach (int i in randNum)
                    {
                        powerNums[groupNum, count] = i;
                        count++;
                        lblOutput.Text += i.ToString() + "  ";
                    }
                    lblOutput.Text += ", special number: " + powerSpecialNums[groupNum].ToString() + "\n";
                    groupNum++;
                }
            } else if (layoutType == 2)
            {
                if (todaySelectedNumCount == 0)
                {
                    int count = 0;
                    randArray = new RandomArray();
                    randNum = new int[5];
                    randNum = randArray.set(todayMax, 5);
                    Array.Sort(randNum);
                    foreach (int i in randNum)
                    {
                        todayNums[groupNum, count] = i;
                        count++;
                        lblOutput.Text += i.ToString() + "  ";
                    }
                    lblOutput.Text += "\n";
                    groupNum++;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            groupNum++;

            if (layoutType == 1)
            {
                powerSelectedNumCount = 0;
                powerSelectedSpecialNumCount = 0;
                PowerLottery.Controls.Clear();
            }
            else if (layoutType == 2)
            {
                todaySelectedNumCount = 0;
                TodayLottery539.Controls.Clear();
            }
        }
        /*
        private void btnShowHistory_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(scsb.ToString());
            sqlConnection.Open();
            
            string strSQL = "select * from history";
            SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();

            string strOutput = "";

            while (sqlReader.Read())
            {
                strOutput += sqlReader["myHistory"].ToString();
            }

            sqlReader.Close();
            sqlConnection.Close();

            lblOutput.Text = strOutput;
        }
        */
    }
}
