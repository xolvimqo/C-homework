using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalHW
{
    class RandomArray
    {
        Random rand = new Random();

        int[] randArray;

        int iNum = 0;
        
        public int[] set(int maxNum, int arrayLength)
        {
            Random rand = new Random();
            randArray = new int[arrayLength];

            do
            {
                if (iNum > 0)
                {
                    randArray[iNum] = rand.Next(1, maxNum + 1);
                    for (int i = 0; i < iNum; i++)
                    {
                        if (randArray[i] == randArray[iNum])
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
                    randArray[iNum] = rand.Next(1, maxNum);
                    iNum++;
                }
            } while (iNum < arrayLength);

            return randArray;
        }
    }
}
