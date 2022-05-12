using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufg13
{
    class Program
    {
		/** Aufg13
         * Zeit: 30 min
         * 
         * Schreibe ein Programm, indem der Nutzer ein Positiv ganze Zahl eingeben soll.
         * In der Methode (Funktion) istUngrade soll geprüft werden,
         * ob die Zahl grade oder ungerade ist und dementsprechend bei grade true und bei ungerade false zurückgeben.
         * Mit dem true und false soll die letzte Ausgabe erstellt werden.
         * 
         */

		static bool IstUngerade(uint i)
        {
			if (i % 2 == 0)
				return true;

			return false;
        }
		static void Main()
		{
			uint input = 0;

			do {
				Console.Clear();
				Console.Write("Geben Sie eine Zahl ein: ");
			} while (uint.TryParse(Console.ReadLine(), out input) == false);

            Console.WriteLine("Die Zahl ist {0}.", istUngerade(input) ? "Grade" : "Ungrade");
			Console.ReadKey();	// endl
		}
	}
}
