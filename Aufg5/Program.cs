using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufg5
{
    class Program
    {
        /**
         * Aufg 5
         * Zeit: 60'
         * 
         * Erstelle ein Spiel, indem du / ein Spieler gegen einen Computer spielt. Das Spiel funktioniert so:
         * Der Computer generiert eine zufällige (ganze) Zahl zwischen 1 und 100.
         * Der Spieler hat fünf Versuche, die Zahl zu erraten
         * Als Eingabe (Datentyp egal) gibt der Spieler die Zahl, welche er / sie vermutet
         * Der Computer gibt ein Feedback zurück, ob die geschätzte Zahl zu Hoch oder zu Tief war.
         * Sind die Versuche verbraucht, hat der Spieler verloren
         * Am Ende kann der Spieler auswählen, ob er / sie nochmal spielen will
         * Wenn man das Spiel neu startet, soll das Konsolenfenster geleert werden
         * 
         * ZUSATZ:
         * Wenn die geschätze Zahl über 100 oder unter 0 ist, gibt es extra Abzug.
         * Lass eine oder zwei weitere Zufallszahlen zwischen 5 und 20 generieren.
         * Beim letzten Versuch sagt der Computer einem, dass die gesuchte Zahl zwischen dieser einen (oder zwischen diesen zwei) Zufallszahlen befindet.
         *  z.B. “ Die gesuchte Zahl befindet sich zwischen 17 und 38.” (zahl1  = 8, zahl2 = 13, zielZahl = 25)
         * Schreibe eine Methode (Funktion), in der man einen Wert eingibt u. zu der Methode sendet.
         * Der Wert soll ausgewertet, zurückgegeben und als Versuche zugestellt:
         * 12, 9, 6, 3
         */

        /// <summary>
        /// Der Eingegebene Wert wird an die Funktion weitergeschickt und hier ermittelt.
        /// </summary>
        /// <param name="schGrad"></param>
        /// <returns></returns>
        static byte SchwierigkeitsGrad(char schGrad) {
            // anz Versuche definieren
            switch (schGrad) {
                case '2':   // mittel
                    return 9;
                case '3':   // schwer
                    return 6;
                case '4':   // mastermind
                    return 3;
                default:    // einfach + keine (gültige) eingabe
                    return 12;
            }
        }
        static void Main(string[] args) {
            Console.WriteLine("Aufgabe 05: Ratespiel");
            Console.WriteLine("*************************************");
            Random r = new Random();
            uint rndZahl = 0;
            byte versuche = 0, eingabe = 0;
            do {
                Console.Clear();
                rndZahl = (uint)r.Next(1, 101);
                Console.WriteLine("\nEinfach = 1, Mittel = 2, Schwer = 3, Mastermind = 4");
                versuche = SchwierigkeitsGrad(Console.ReadKey().KeyChar);
                Console.WriteLine("\n\nIch habe mir eine Zahl zwischen 1 und 100 ausgedacht.\n" +
                    "Sie haben {0} Versuche die Zahl herauszufinden.", versuche);
                Console.ReadKey();
                Console.Clear();
                while (true) {
                    if (versuche == 1) {
                        int z1 = r.Next(5, 21),
                            z2 = r.Next(5, 21);
                        Console.WriteLine("Dies ist ihr letzer Versuch!\nDie gesuchte Zahl liegt zwischen {0} und {1}."
                            , rndZahl-z1, rndZahl+z2);
                    }
                    Console.Write("Sie haben noch {0} Versuche.\nWas denken Sie? ", versuche);
                    eingabe = Convert.ToByte(Console.ReadLine());
                    if (eingabe > 100 && eingabe < 1) { // wenn eingegebene Zahl über 100 ist
                        Console.WriteLine("Die gesuchte Zahl ist ZWISCHEN 1 und 100.\nDas gibt extra Abzug!\n");
                        versuche--;
                    } else if (eingabe == rndZahl) { //  eingabe korrekt?
                        Console.WriteLine("Zahl erkannt!\nSie haben gewonnen.\n");
                        break;
                    }
                    versuche--; // versuche senken
                    if (versuche < 1) { // keine Versuche mehr
                        Console.WriteLine("Sie sind gescheitert!\nDie Zahl war {0}.\n", rndZahl);
                        break;
                    }
                    // eingabe kleiner oder grösser
                    else if (eingabe > rndZahl)
                        Console.WriteLine("\nIhre Zahl ist ZU GROSS.\n");
                    else
                        Console.WriteLine("\nIhre Zahl ist ZU KLEIN.\n");
                }
                Console.Write("Wollen Sie nocheinmal spielen? [j/n]");
            } while (Console.ReadKey().Key == ConsoleKey.J ? true : false);
        }
    }
}
