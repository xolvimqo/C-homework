using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalHW
{
    class CompareNumbers
    {
        int iNum = 0;
        int[] arrayNums;
        public int[] findSameNumbers(int[] array1, int[] array2)
        {
            if (array1.Length > 0 && array2.Length > 0)
            {
                if (array1.Length == array2.Length)
                {
                    arrayNums = new int[array1.Length];
                    foreach (int num1 in array1)
                    {
                        foreach (int num2 in array2)
                        {
                            if (num1 == num2)
                            {
                                arrayNums[iNum] = num1;
                                iNum++;
                            }
                        }
                    }
                }
            }
            return arrayNums;
        }

        void compareNumbers()
        {

        }
    }
}
