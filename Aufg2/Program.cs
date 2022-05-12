using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufg2
{
    class Program
    {
        static void Main(string[] args)
        {
            /**
             * Aufg. 2
             * Zeit 25'
             * Versuche einen Programmcode zu diesen Infos zu bilden:
             * ;
             * Anzahl Schritte: 1205
             * Umweltkategorie: B
             * Kontostand: 5090.50
             * Position: X-Achse: -50
             * 
             * Ihre Eingaben:
             * Anzahl Schritte: 1205
             * Umweltkategorie: B
             * Kontostand: 5090.50
             * Position: X-Achse: -50
             * ;
             * Zuerst wird der Benutzer aufgefordert, vier Werte einzugeben.
             * Danach werden nach zwei Zeilenumbrüchen (\n) die eingegebenen Werte ausgegeben.
             * Erstelle zuerst die Variablen auf der Basis von sinnvollen und ressourcenschonenden Datentypen. 
             * Danach erfolgt die Erfassung der Benutzerdaten mittels Console.ReadLine().
             * Am Schluss die Ausgabe mittels Console.WriteLine()-Befehl.
             * 
             */

            Console.WriteLine("Aufgabe 02a: Informationen einlesen und ausgeben");
            Console.WriteLine("*************************************");
            //Die Eingaben des Benutzers in Variablen speichern
            Console.Write("Anzahl Schritte:");
            uint anzahlSchritte = Convert.ToUInt32(Console.ReadLine());
            Console.Write("Umweltkategorie:");
            char umwKategorie = Convert.ToChar(Console.ReadLine());
            Console.Write("Kontostand:");
            double kontostand = Convert.ToDouble(Console.ReadLine());
            Console.Write("Position x-Achse:");
            short positionXAchse = Convert.ToInt16(Console.ReadLine());
            //Verarbeitung gibt es hier keine
            //Ausgabe
            Console.WriteLine("\n\nAnzahl Schritte \t:" + anzahlSchritte.ToString());
            Console.WriteLine("Umweltkategorie \t:" + umwKategorie.ToString());
            Console.WriteLine("Kontostand \t\t:" + kontostand.ToString());
            Console.WriteLine("Position x-Achse \t:" + positionXAchse.ToString());
            Console.Write("\nDrücken sie eine Taste um die Applikation zu beenden...");
            Console.ReadKey();
        }
    }
}
