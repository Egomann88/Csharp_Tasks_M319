using System;

namespace Array
{
    class Program
    {
        /*
         * Aufg7
         * Zeit: 30min
         * 
         * Du hast folgenden Array vorgegeben:
         * ( ͡❛ ‿‿ ͡❛)
         * Deine Aufgabe ist es,
         * Auszurechnen, welche Zahlen durch 3 Teilbar sind
         * Am Ende soll ausgegeben werden, wie viele Zahlen Teilbar sind und
         * die Zahlen, welche Teilbar sind
         * Bei der Ausgabe werden alle Zahlen, von der grössten bedinent, geordnet
         */
        static void Main()
        {
            Console.WriteLine("Aufgabe 07: Array");
            Console.WriteLine("*************************************");
            int[] zahlenUngeordnet = {
                2, 17, 10, 9, 16, 3, 5, 1, 14, 70, 44, 47, 53, 27, 8, 37, 32,
                82, 91, 56, 36, 90, 33, 34, 69, 40, 38, 86, 57, 62, 65, 54, 67,
                84, 43, 71, 50, 25, 75, 76, 28, 64, 4, 45, 21, 60, 15, 23, 81
            },
            zahlenGeordnet = new int[500];
            int i = 0, j = 0, a = 0, temp = 0;

            for (i = 0; i < zahlenUngeordnet.Length; i++) {
                if (zahlenUngeordnet[i] % 3 == 0) {
                    zahlenGeordnet[a] = zahlenUngeordnet[i];
                    a++;
                }
            }

            for (i = 0; i < zahlenGeordnet.Length; i++) {
                for (j = i + 1; j < zahlenGeordnet.Length; j++) {
                    if (zahlenGeordnet[i] < zahlenGeordnet[j]) {
                        temp = zahlenGeordnet[i];
                        zahlenGeordnet[i] = zahlenGeordnet[j];
                        zahlenGeordnet[j] = temp;
                    }
                }
            }

            Console.WriteLine("Anzahl, welche durch 3 Teilbar sind: {0}\nTeilbar sind:", a);

            for (i = 0; i < zahlenGeordnet.Length; i++) {
                if (zahlenGeordnet[i] == 0) {
                    break;
                }
                Console.Write(zahlenGeordnet[i] + ", ");
            }

            Console.ReadKey();
        }
    }
}