using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufg1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Aufg. 1
             * Zeit: 25’
             * Aufgabe: Erstelle ein Programm, das den Benutzer nach dem Vornamen, Namen und Alter fragt.
             * Gibt der Benutzer z.B. Daniel Fotomacher und 20 ein, soll danach die Ausgabe
             * «Hallo Daniel Fotomacher, bald wirst du 21» ausgegeben werden.
             */
            Console.WriteLine("Aufgabe 01: Einfache Ein- und Ausgaben");
            Console.WriteLine("*************************************");
            //Die Eingaben des Benutzers in Variablen speichern
            Console.Write("Vornamen:");
            string vorname = Console.ReadLine();
            Console.Write("Nachnamen:");
            string nachname = Console.ReadLine();
            Console.Write("Alter:");
            byte alter = Convert.ToByte(Console.ReadLine());
            //Verarbeitung
            alter++; //erhöht das Alter um 1 --> alter = alter +1;
                     //Ausgabe
            string ausgabe = "\n\nHallo " + vorname + " " + nachname;
            ausgabe += " bald wirst du " + Convert.ToString(alter);
            Console.WriteLine(ausgabe);
            Console.ReadKey();
        }
    }
}
