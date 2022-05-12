using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufg11
{
    class Program
    {
        /**
         * Aufg 11
         * Zeit: 30 min
         * 
         * Ein Händler verlangt für seine Waren folgende Preise:
         * 7 Cent pro Schraube (screw)
         * 4 Cent pro Mutter (screw nut)
         * 2 Cent pro Unterlegscheibe (grommet)
         * Schreibe ein Programm, das vom Anwender die Anzahl der Schrauben, Muttern, Unterlegscheiben erfragt.
         * Dannach mit den Angaben den Gesamtbetrag berechnen und ausgeben.
         */

        static double Rechnen(uint[] sng)
        {
            double sPrice = 0.07, nPrice = 0.04, gPrice = 0.02;
            return (sng[0] * sPrice) + (sng[1] * nPrice) + (sng[2] * gPrice);
        }
        static void Main()
        {
            uint[] sng = { 0, 0, 0 }; // Screw, Nut, Grommet
            string HowMuchText = "Wie viele {0} wollen sie kaufen? ";
            string[] textContent = { "Schrauben", "Schraubenmütter", "Unterlegscheiben" };

            for(byte i = 0; i < sng.Length; i++) {
                do {
                    Console.Write(HowMuchText, textContent[i]);
                } while (uint.TryParse(Console.ReadLine(), out sng[i]) == false);
            }

            double total = Rechnen(sng);
            Console.WriteLine("Alles zusammen kostet {0} Franken.", total);

            Console.ReadKey();  // endl
        }
    }
}
