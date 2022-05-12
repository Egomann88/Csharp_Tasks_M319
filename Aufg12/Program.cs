using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufg12
{
    class Program
    {
        /**
         * Aufg 12
         * Zeit: 90 min
         * 
         * Schreibe ein Programm, das 20 Zeugnisnoten (1.0 - 6.0) in Zehntelnoten (z.B. 4.2, 5.6, ...) zufällig erstellt.
         * Am Ende soll der Durchschnitt aller (übriggeblieben) Noten ausgegeben werden.
         * 
         * Die beste und schlechteste Note wird gestrichen (wenn schlechteste / beste mehrfach vorkommt → beide streichen).
         * Der Durchschnitt am Ende soll auf die nächste halbe Note gerundet werden
         * Das Filtern nach der schlechtesten und der besten Note soll ich verschiedenen Methoden (Funktionen) gemacht werden.
         */

        static float KleinsterWert(float[] noten)   // kleinsten Wert rausfiltern
        {
            float kleinsterWert = noten[0];
            for (byte i = 0; i < noten.Length; i++) {
                if (kleinsterWert > noten[i])
                    kleinsterWert = noten[i];
            }

            return kleinsterWert;
        }
        static float GrössterWert(float[] noten)    // grössten Wert rausfilten
        {
            float grössterWert = noten[0];
            for (byte i = 0; i < noten.Length - 1; i++) {
                if (grössterWert < noten[i])
                    grössterWert = noten[i];
            }

            return grössterWert;
        }
        static void Main()
        {
            Random r = new Random();
            float[] noten = new float[20];
            byte i = 0;
            for (i = 0; i < 20; i++) {
                float zwischenNoten = (float)r.Next(10, 61);
                noten[i] = zwischenNoten / 10;
            }

            float kleinsterWert = KleinsterWert(noten);
            float grössterWert = GrössterWert(noten);
            float durchschnitt = 0;
            List<float> gefillNoten = new List<float>();
            for (i = 0; i < noten.Length; i++) {
                if (noten[i] != kleinsterWert && noten[i] != grössterWert) { // kleinsten u. grössten Wert rauslöschen
                    gefillNoten.Add(noten[i]);
                    durchschnitt += noten[i];
                }
            }

            durchschnitt /= gefillNoten.Count; // durschnitt berechnen
            for (i = 0; i < gefillNoten.Count; i++) {
                Console.WriteLine("Note {0}: {1}", i+1, gefillNoten[i]);   // noten ausgabe
            }

            Console.WriteLine("\nDurschschnitt: {0:0.0}", Math.Round(gefillNoten.Sum() / gefillNoten.Count / 0.5) * 0.5);   // Durschnitt ausgabe
            Console.ReadKey();  // endl
        }
    }
}
