using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufg15
{
    class Program
    {
        /** Aufg15
         * Zeit: 30 min
         * 
         * Schreibe ein Programm, das die Nummerierung eines Schachbretts in eine der folgenden Formen ausgibt:
         * 
         * A8 A7 A6 A5 A4 A3 A2 A1
         * B8 B7 B6 B5 B4 B3 B2 B1
         * C8 C7 C6 C5 C4 C3 C2 C1
         * D8 D7 D6 D5 D4 D3 D2 D1
         * E8 E7 E6 E5 E4 E3 E2 E1
         * F8 F7 F6 F5 F4 F3 F2 F1
         * G8 G7 G6 G5 G4 G3 G2 G1
         * H8 H7 H6 H5 H4 H3 H2 H1
         * 
         * Oder in dieser Form:
         * H1 H2 H3 H4 H5 H6 H7 H8
         * G1 G2 G3 G4 G5 G6 G7 G8
         * F1 F2 F3 F4 F5 F6 F7 F8
         * E1 E2 E3 E4 E5 E6 E7 E8
         * D1 D2 D3 D4 D5 D6 D7 D8
         * C1 C2 C3 C4 C5 C6 C7 C8
         * B1 B2 B3 B4 B5 B6 B7 B8
         * A1 A2 A3 A4 A5 A6 A7 A8
         */
        static void Main(string[] args)
        {
            /* ursprüngliche Aufgabenstellung
            for (byte i = 65; i < 73; i++) {
                for (byte b = 1; b < 9; b++) {
                    Console.Write("{0}{1} {2}", (char)i, b, b > 7 ? "\n" : "");

                    if (b > 7)
                        break;

                }
            }
            */

            for (byte i = 72; i > 64; i--) {
                for (byte b = 1; b < 9; b++) {
                    Console.Write("{0}{1} {2}", (char)i, b, b > 7 ? "\n" : "");

                    if (b > 7)
                        break;

                }
            }

            Console.ReadKey();  // endl
        }
    }
}
