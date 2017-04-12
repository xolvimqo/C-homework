using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalHW
{
    class CompareNumbers
    {
        int[,] myArray1;
        int[] myArray2;
        int myGroupNum = 0;
        int myLayoutType = 0;
        int countNum = 0;
        int[] arrayReturn;
        int[,] arrayNums;
        public int[] findSameNumbers()
        {
            if (myLayoutType == 1)
            {
                arrayNums = new int[myGroupNum + 1, 6];
            }
            else if (myLayoutType == 2)
            {
                arrayNums = new int[myGroupNum + 1, 5];
            }

            Console.WriteLine("#################################");

            for (int i = 0; i < arrayNums.GetLength(0); i++)
            {
                for (int j = 0; j < arrayNums.GetLength(1); j++)
                {
                    for (int k = 0; k < myArray2.Length; k++)
                    {
                        Console.WriteLine("\narray1[{0}, {1}] = {2}, array2[{3}] = {4}\n", i, j, myArray1[i, j], k, myArray2[k]);
                        if (myArray1[i, j] == myArray2[k])
                        {
                            arrayReturn[countNum] = myArray2[k];
                            countNum++;
                            break;
                        }
                        else if (k == 5 && myLayoutType == 1)
                        {
                            arrayReturn[countNum] = 0;
                            countNum++;
                        } else if (k == 4 && myLayoutType == 2)
                        {
                            arrayReturn[countNum] = 0;
                            countNum++;
                        }
                    }
                }
            }
             
            return arrayReturn;
        }
    
        public int getlength()
        {
            int returnValue = arrayReturn.Length;
            return returnValue;
        }
        public void setCompareNumbers(int[,] array1, int[] array2, int groupNum, int layoutType)
        {
            this.myGroupNum = groupNum - 1;
            this.myLayoutType = layoutType;
            Console.WriteLine("###########\n" + groupNum);
            if (myLayoutType == 1) {
                this.myArray1 = new int[myGroupNum + 1, 6];
                myArray1 = array1;
                arrayReturn = new int[(myGroupNum + 1) * 6];
            } else if(myLayoutType == 2)
            {
                this.myArray1 = new int[myGroupNum + 1, 5];
                myArray1 = array1;
                arrayReturn = new int[(myGroupNum + 1) * 5];
            }

            this.myArray2 = array2;
        }
    }
}
