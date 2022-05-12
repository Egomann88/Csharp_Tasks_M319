using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufg16
{
    class Program
    {
        /** Aufg16
         * Zeit: 15 min
         * 
         * Schreibe ein Programm, das normalen Zahlen in eine binäre Zahl umwandeln.
         * Die binäre Zahl soll immer mit mind. 8 Stellen dargestellt werden. Z.B. 50 = 00110010
         * 
         */
        static void Main(string[] args)
        {
            int number = 0;
            do {
                Console.Write("Geben Sie eine ganze Zahl ein: ");
            } while (int.TryParse(Console.ReadLine(), out number) == false);    

            Console.WriteLine("Die ganze Zahl als Binärzahl: {0}", Convert.ToString(number, 2).PadLeft(8, '0')); // methode 1

            Console.ReadLine();  // endl
        }
    }
}
