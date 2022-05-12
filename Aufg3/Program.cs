using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufg3
{
    class Program
    {
        static void Main(string[] args)
        {
            /**
             * Aufg3
             * Zeit: 25'
             * Erstellen Sie ein Programm, das folgende Aufgabe löst:
             * Den Benutzer fragen, wie schnell sich ein Auto bewegt in Km/h
             * Nach der zu fahrenden Distanz (in Km) fragen
             * Fahrzeit in Minuten u. Benzinverbrauch in Liter ausgeben
             * Benzinverbrauch soll zweimal ausgegeben werden:
             * einmal die normale zahl angezeigt werden
             * die zweite Zahl soll auf zwei Stellen nach dem Komma gerudnet wwerden
             */

            Console.WriteLine("Aufgabe 03: Fahrzeit und Verbrauch");
            Console.WriteLine("*************************************");
            //Die Eingaben des Benutzers in Variablen speichern
            ushort kmh = 0; // in Km/h
            ushort distanz = 0; // zu fahrenden Distanz in Km
            double verbrauch = 0; // Liter pro 100Km.
            uint fahrzeit = 0; // Fahrzeit in Minuten (wird berechnet)
            double totalVerbrauchNormal = 0; // Verbrauch für die gesammte Strecke in Liter
            double totalVerbrauchGerundet = 0; // Verbrauch für die gesammte Strecke, gerundet auf 2 Stellen
            Console.Write("Geschwindigkeit in Km/h?: ");
            kmh = Convert.ToUInt16(Console.ReadLine());
            Console.Write("Welche Strecke legen sie zurück? (Km): ");
            distanz = Convert.ToUInt16(Console.ReadLine());
            Console.Write("Wie viel Benzin verbraucht ihr Fahrzeug pro 100km?: ");
            verbrauch = Convert.ToDouble(Console.ReadLine());
            //Verarbeitung
            fahrzeit = (uint)((double)distanz / (double)kmh * 60);
            totalVerbrauchNormal = (double)distanz / 100 * verbrauch;
            totalVerbrauchGerundet = Math.Round(totalVerbrauchNormal, 2);
            //Ausgabe
            Console.WriteLine("\nFahrzeit: {0} Minuten", fahrzeit);
            Console.WriteLine("\nBenzinverbrauch: {0} Liter\n\nBenzinverbrauch (gerunet): {1}"
                , totalVerbrauchNormal, totalVerbrauchGerundet);
            Console.Write("\nDrücken sie eine Taste um die Applikation zu beenden . . . ");
            Console.ReadKey();
        }
    }
}
