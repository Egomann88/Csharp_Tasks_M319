using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufg19
{
    class Program
    {
        /** Aufg19
         * Zeit: 30 min
         * 
         * Schreibe ein Programm, dass 6 zufällige (ganze) Zahlen (1 bis 49) generiert und ausgibt.
         * 
         * Regeln:
         * Jede Zahl darf nur einmal vorkommen
         * 
         */
        static void Main()
        {
            Random r = new Random();
            int[] lottoNums = new int[6];

            Console.Write("Lotto Zahlen: ");
            for (byte i = 0; i < lottoNums.Length; i++) {
                int rndNum = r.Next(1, 49);

                for(byte b = 0; b < lottoNums.Length; b++) {
                    if (rndNum == lottoNums[i])
                        continue;
                }

                Console.Write(rndNum + " ");
            }

            Console.ReadKey();  // endl
        }
    }
}
