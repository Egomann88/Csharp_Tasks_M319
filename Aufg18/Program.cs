using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufg18
{
    class Program
    {
        /** Aufg18
         * Zeit: 30 min
         * 
         * Programmiere ein Programm, welches zwei Durchläufe hat.
         * Beide Durchläufe haben 100 Türen, beginnend bei 1.
         * Beim ersten Durchlauf wird jede zweite Tür geöffnet, bedienend bei eins.
         * Beim zweiten Durchlauf wird ein anderes Verfahren angewendet.
         * Bei diesem ist es so, dass die erste, vierte, neunte, ... Tür geöffnet wird (die letzte offene Tür ist 100).
         * Wie viele Türen werden bei beiden Abläufen geöffnet?
         * 
         * Regeln:
         * In Forme einer Zahl soll ausgegeben werden, welche Tür geöffnet wird, z.B. “Tür Nr. 1”
         * Am Ende jedes Durchlaufes soll die Gesamtanzahl der geöffneten Türen angezeigt werden.
         * 
         */
        static void Main()
        {
            byte increment = 1, openDoors = 0;
            string endText = "\nTotal sind {0} Türen offen.";

            Console.WriteLine("Durchgang 1:");
            for (byte i = 1; i < 100; i += 2) {
                Console.Write(i + " ");
                openDoors++;
            }

            Console.WriteLine(endText, openDoors);
            openDoors = 0;  // counter reset

            Console.WriteLine("\nDurchgang 2:");
            for (byte i = 1; i <= 100; i += increment) {
                Console.Write(i + " ");
                openDoors++;
                increment += 2;
            }

            Console.Write(endText, openDoors);
            Console.ReadKey();  // endl
        }
    }
}
