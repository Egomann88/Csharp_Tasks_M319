using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufg17
{
    class Program
    {
        /** Aufg17
         * Zeit: 60 min
         * 
         * Programmiere das Spiel Chuck-a-Luck.
         * Bei diesem Spiel bezahlt der Spieler pro Runde einen CHF als Einsatz.
         * Dann darf er drei Würfel nacheinander werfen.
         * Wenn mind. ein Würfel eine 6 hat, bekommt dieser seinen Einsatz zurück und bekommt sogar noch einen CHF obendrauf.
         * Wird in derselben Runde nochmals eine 6 gewürfelt, bekommt der Spieler wieder 1.- als Gewinn.
         * Wenn keine 6 gewürfelt wird, geht der Einsatz verloren.
         * 
         * Regeln:
         * Hat der Spieler kein Geld mehr und gewinnt nichts, meldet das Programm, dass der Spieler kein Geld mehr hat und wird beendet.
         * Am Ende (wenn alle 1000 Runden gespielt wurden) soll ausgegeben werden,
         * wie viel CHF man bekommen hat und rechnet den Gewinn mit dem verbleibenden Budget zusammen.
         * Simuliere ein Spiel, mit einem Kapital von 1000 CHF und 1000 Spielrunden.
         */
        static void Main(string[] args)
        {
            Random r = new Random();
            string endText = "";
            ushort budget = 1000, rounds = 1000, gain = 0, roundPrice = 1;
            bool returnBudget = false;
            int draw = 0;

            for (ushort i = 1; i <= rounds; i++) {
                budget -= roundPrice;
                returnBudget = true;

                Console.WriteLine("\nRunde {0}", i);
                for (byte b = 1; b < 4; b++) {
                    draw = r.Next(1, 7);
                    Console.WriteLine("Würfel Nr. {0}. Gewürfelt: {1}", b, draw);

                    if (draw == 6) {
                        gain++;
                        if (returnBudget) {
                            budget++;
                            returnBudget = false;
                        }
                    }
                }
                if (budget <= 0) {
                    endText = $"\nNach {i} Runden haben Sie kein Geld mehr";
                    break;
                }

                endText = $"\nSie haben {i} lang gespielt, {gain} Euro Gewinn gemacht und verlassen das Chuck-a-luck mit {budget + gain} Euro.";
            }

            Console.WriteLine(endText);
            Console.ReadKey();  // endl
        }
    }
}