using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication8
{
    public partial class Form1 : Form
    {
        // Class Variables
        int[] arrayStudentHigh;
        string[] arraySubject;
        string[] arrayStudentName;
        int[] arrayStudentScore;
        int[] arrayTempStudentHigh;
        string[] arrayTempStudentName; // 暫存陣列
        int[] arrayTempStudentScore;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubjectSort_Click(object sender, EventArgs e)
        {
            subjectSorting(arraySubject);
        }

        void subjectSorting(string[] mySubjectArray)
        {
            string strMsg = "Before sorting " + "-----------------\n";

            for (int index = 0; index <= mySubjectArray.GetUpperBound(0); index++)
            {
                strMsg += string.Format("{0}\n", mySubjectArray[index]);
            }

            lblBeforeSorting.Text = strMsg;

            System.Array.Sort(mySubjectArray);

            strMsg = "After sorting " + "---------------\n";

            foreach (string strSubject in mySubjectArray)
            {
                strMsg += string.Format("{0}\n", strSubject);
            }

            lblAfterSorting.Text = strMsg;
        }

        private void btnScoreSort_Click(object sender, EventArgs e)
        {
            Array.Copy(arrayStudentName, arrayTempStudentName, arrayStudentName.GetLength(0));
            Array.Copy(arrayStudentScore, arrayTempStudentScore, arrayStudentScore.GetLength(0));
            scoreSorting(arrayTempStudentName, arrayTempStudentScore);
        }

        void scoreSorting(string[] myNameArray, int[] myScoreArray)
        {
            string strMsg = "Before sorting " + "--------------\n";

            for (int index = 0; index <= myNameArray.GetUpperBound(0); index++)
            {
                strMsg += string.Format("{0}:{1}\n", myNameArray[index], myScoreArray[index]);
            }

            lblBeforeSorting.Text = strMsg;

            strMsg = "After sorting " + "--------------\n";

            Array.Sort(myScoreArray, myNameArray);

            for (int index = myNameArray.GetUpperBound(0); index >= 0; index--)
            {
                strMsg += string.Format("{0}:{1}\n", myNameArray[index], myScoreArray[index]);
            }

            lblAfterSorting.Text = strMsg;
        }

        private void btnNameSort_Click(object sender, EventArgs e)
        {
            Array.Copy(arrayStudentName, arrayTempStudentName, arrayStudentName.GetLength(0));
            Array.Copy(arrayStudentScore, arrayTempStudentScore, arrayStudentScore.GetLength(0));

            nameSorting(arrayTempStudentName, arrayTempStudentScore);
        }

        void nameSorting(string[] myNameArray, int[] myScoreArray)
        {
            string strMsg = "Before sorting " + "--------------\n";

            for (int index = 0; index <= myNameArray.GetUpperBound(0); index++)
            {
                strMsg += string.Format("{0}:{1}\n", myNameArray[index], myScoreArray[index]);
            }

            lblBeforeSorting.Text = strMsg;

            strMsg = "After sorting " + "--------------\n";

            Array.Sort(myNameArray, myScoreArray); // Name sorting with key-value pairs

            for (int index = 0; index <= myNameArray.GetUpperBound(0); index++)
            {
                strMsg += string.Format("{0}:{1}\n", myNameArray[index], myScoreArray[index]);
            }

            lblAfterSorting.Text = strMsg;
        }

        private void btnSearchName_Click(object sender, EventArgs e)
        {
            if (tbName.Text.Length > 0)
            {
                int index = 0, num1 = 0;
                int originalIndex = 0;
                string strMsg = "Searching results:\n" + "----------------\n";
                string strSearch = tbName.Text;
                Array.Copy(arrayStudentName, arrayTempStudentName, arrayStudentName.GetLength(0));
                Array.Copy(arrayStudentScore, arrayTempStudentScore, arrayStudentScore.GetLength(0));
                scoreSorting(arrayTempStudentName, arrayTempStudentScore);

                index = Array.IndexOf(arrayTempStudentName, strSearch);
                originalIndex = Array.IndexOf(arrayStudentName, strSearch);

                if (index < 0 || index > arrayTempStudentName.GetUpperBound(0))
                {
                    strMsg += "No information";
                } else
                {
                    num1 = arrayTempStudentName.GetLength(0) - index;

                    strMsg += string.Format("{0}:\nScore : {1}\nNo.{2}\nHigh:{3}", arrayTempStudentName[index], arrayTempStudentScore[index], num1, arrayStudentHigh[originalIndex]);
                }

                lblAfterSorting.Text = strMsg;
            } else
            {
                lblAfterSorting.Text = "Please input name!";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            arrayStudentHigh = new int[5];
            arrayStudentHigh[0] = 201;
            arrayStudentHigh[1] = 198;
            arrayStudentHigh[2] = 213;
            arrayStudentHigh[3] = 221;
            arrayStudentHigh[4] = 193;

            arraySubject = new string[7];
            arraySubject[0] = "Chinese";
            arraySubject[1] = "English";
            arraySubject[2] = "Mathematics";
            arraySubject[3] = "Physics";
            arraySubject[4] = "Chemistry";
            arraySubject[5] = "Nature";
            arraySubject[6] = "Sociaty";

            arrayStudentName = new string[5]; // key
            arrayStudentName[0] = "Lumin Wang";
            arrayStudentName[1] = "Cat Cheng";
            arrayStudentName[2] = "Pegi Ling";
            arrayStudentName[3] = "Book Chang";
            arrayStudentName[4] = "Spring Huang";

            arrayStudentScore = new int[5]; // value
            arrayStudentScore[0] = 76;
            arrayStudentScore[1] = 68;
            arrayStudentScore[2] = 54;
            arrayStudentScore[3] = 92;
            arrayStudentScore[4] = 86;

            arrayTempStudentName = new string[5];
            arrayTempStudentScore = new int[5];
            arrayTempStudentHigh = new int[5];

            lblScore.Text = totalScore(arrayStudentScore).ToString();
            lblAverage.Text = average(arrayStudentScore).ToString();
        }

        int totalScore(int[] scoreArray)
        {
            int intTotalScore = 0;

            foreach (int myScore in scoreArray)
            {
                intTotalScore += myScore;
            }

            return intTotalScore;
        }

        float average(int[] scoreArray)
        {
            float myAverage = 0.0f;
            myAverage = (float)totalScore(scoreArray) / scoreArray.GetLength(0);
            return myAverage;
        }

        private void btnHighSorting_Click(object sender, EventArgs e)
        {
            Array.Copy(arrayStudentHigh, arrayTempStudentHigh, arrayStudentHigh.GetLength(0));
            Array.Copy(arrayStudentName, arrayTempStudentName, arrayStudentName.GetLength(0));
            highSorting(arrayTempStudentHigh, arrayTempStudentName);
        }

        void highSorting(int[] highArray, string[] nameArray)
        {
            string strMsg = "Before sorting " + "--------------\n";

            for (int index = 0; index <= highArray.GetUpperBound(0); index++)
            {
                strMsg += string.Format("{0}:{1}\n", nameArray[index], highArray[index]);
            }

            lblBeforeSorting.Text = strMsg;

            strMsg = "After sorting " + "--------------\n";

            Array.Sort(highArray, nameArray); // Name sorting with key-value pairs

            //for (int index = highArray.GetUpperBound(0); index >= 0; index--)
            {
                strMsg += string.Format("{0}:{1}\n", nameArray[index], highArray[index]);
            }

            lblAfterSorting.Text = strMsg;
        }
    }
}
