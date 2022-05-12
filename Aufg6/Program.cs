using System;

namespace Aufg6
{
    class Program
    {
        /*
         * Aufg6
         * Zeit: 30'
         * 
         * Baue ihn so um, dass ggT und kgV unabhängig voneinander auf Methoden (Funktionen) in einer anderen Datei (Class) zugreifen.
         * Gehe dazu auf dein Projekt und erstelle eine neue Class und importiere sie:
         * Mathefunktionen mathe = new Mathefunktionen();
         * Damit du in deinem Code auf die Methoden (Funktionen) zugreifen kannst, musst du sie so: mathe.getGgT(); aufrufen.
         * Damit die Methoden (Funktionen) und die Class aufgerufen werden können, muss ein public vor ihnen stehen.
         */
        static void Main(string[] args)
        {
            // eingene Class importieren
            Mathefunktionen mathe = new Mathefunktionen();
            Console.WriteLine("Aufgabe 06: Mathefunktionen");
            Console.WriteLine("*************************************");
            int zahl1 = 0, zahl2 = 0, ggT = 0, kgV = 0;
            do {
                Console.Write("Zahl 1 eingeben: ");
            } while (int.TryParse(Console.ReadLine(), out zahl1) == false);
            zahl1 = Math.Abs(zahl1); //Vorzeichen weglassen (Absolutwert)
            do {
                Console.Write("Zahl 2 eingeben: ");
            } while (int.TryParse(Console.ReadLine(), out zahl2) == false);
            zahl2 = Math.Abs(zahl2); //Vorzeichen weglassen (Absolutwert)
            string ausgabeText = "Der {0} der beiden Zahlen " + zahl1 + " und " + zahl2 + " ist: {1}";
            ggT = mathe.getGgT(zahl1, zahl2);
            kgV = mathe.getKgV(zahl1, zahl2);
            Console.WriteLine(ausgabeText, "ggT", ggT);
            Console.WriteLine(ausgabeText, "kgV", kgV);
            Console.ReadKey();
        }
    }
}
