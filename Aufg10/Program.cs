using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aufg10
{
    class Program
    {
        static bool bankLogin()
        {
            string bankNumber = "";
            byte wrongInput = 0;
            do {
                Console.Clear();
                Console.Write("Geben Sie ihre Banknummer ein: ");
                bankNumber = Console.ReadLine();
            } while (bankNumber != "4807239" && wrongInput++ <= 5);

            if (wrongInput >= 5) {
                Console.WriteLine("Zu viele Fehleingaben.");
                return false;
            }
            return true;
        }

        static double depositChf()
        {
            Console.Clear();
            Console.WriteLine("Wie viel Geld möchten Sie einzahlen?");
            double inputMoney = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Transaktion wird gestartet. Bitte warten Sie einen Moment...");
            
            int timeSleep = (int)Math.Floor(Math.Round(inputMoney));
            Thread.Sleep(timeSleep);
            
            Console.WriteLine("Transaktion erfolgreich");
            Thread.Sleep(1000);

            return inputMoney;
        }

        static double pickMoney(double bankMoney)
        {
            double inputMoney = 0;
            while (true) {
                Console.Clear();
                do {
                    Console.WriteLine("Wie viel Geld möchten Sie abheben?");
                } while (double.TryParse(Console.ReadLine(), out inputMoney) == false);

                if(inputMoney > bankMoney) {
                    Console.WriteLine("Sie wollen mehr Geld abheben, als Sie besitzen!");
                    continue;
                }

                Console.WriteLine("Transaktion wird gestartet. Bitte warten Sie einen Moment...");

                int timeSleep = (int)Math.Floor(Math.Round(inputMoney));
                Thread.Sleep(timeSleep);

                Console.WriteLine("Transaktion erfolgreich");
                Thread.Sleep(2000);

                break;
            }

            return inputMoney;
        }

        static double[] changeMoney(double[] money, bool currencyChf)
        {
            double inputMoney = 0;
            while(true) {
                Console.Clear();
                do {
                    Console.Write("Kurs:\t1 EUR = 1,02 CHF\n\t1 CHF = 0,98 CHF\nWie viel {0} wollen Sie umwandeln? "
                        , currencyChf ? "EUR" : "CHF");
                } while (double.TryParse(Console.ReadLine(), out inputMoney) == false);

                if(inputMoney > money[0] && inputMoney > money[1]) {
                    Console.WriteLine("Sie wollen mehr Geld umtauschen, als Sie besitzen!");
                    Thread.Sleep(1000);
                    continue;
                }

                if (currencyChf == true) {  // chf
                    money[1] -= inputMoney; // remove current currency
                    money[0] = inputMoney * 1.02;   // change currency
                } else {    // eur
                    money[0] -= inputMoney; // remove current currency
                    money[1] = inputMoney * 0.98;   // change currency
                }

                Console.WriteLine("Transaktion wird gestartet. Bitte warten Sie einen Moment...");

                int timeSleep = (int)Math.Floor(Math.Round(inputMoney));
                Thread.Sleep(timeSleep);

                Console.WriteLine("Transaktion erfolgreich");
                Thread.Sleep(2000);

                break;
            }
            return money;
        }

        /**
         * Aufg9
         * Zeit: 120 min
         * 
         * Schreibe ein Programm, dass einen Bankautomaten simuliert.
         * Zuerst musst du einen siebenstelligen Pin eingeben (4807239), um Zugriff auf dein Konto zu bekommen.
         * Im Konto eingeloggt, wird dir dein Kontostand in CHF angezeigt. Da du ein SP (SuPer) Konto besitzt,
         * hast du einen zweiten Geldbetrag, der in EUR angezeigt wird.
         * Nun hast du sechs Möglichkeiten:
         * 1. Einzahlen CHF
         * 2. Abheben CHF
         * 3. Abheben EUR
         * 4. EUR umtauschen
         * 5. CHF umtauschen
         * 6. Ausloggen
         * 
         * Regeln:
         * Jeder Knopf wird in einer anderen Methode (Funktion) bearbeitet.
         * Bei jeder Transaktion, welche Geld entfernt, muss geprüft werden, ob genügend Geld vorhanden ist. Kein Minus Geld
         * Jede Transaktion braucht Zeit, um durchgeführt zu werden → soviel Geld, wie man hinzufügen / entfernen will wird in Millisekunden gewartet.
         * Die Wartezeit ist eine (hoch gerundete) ganze Zahl.
         * Nach der Wartezeit wird ein Text ausgegeben, welcher sag, dass die Transaktion abgeschlossen ist.
         * Diese Nachricht bleibt für 2 Sekdamit der Benutzer sie sehen kann.
         * Im ganzen Programm werden nur Zahlen geduldet!
         * Wenn der Nutzer sich ausloggt, berichtet das Programm, dass der Nutzer ausgeloggt wird. Dieser wird nach 2 Sek ausgeloggt (Programm Beenden)
         * Wird der Pin mehr als fünf Mal falsch eingegeben, wird das Programm beendet.
         */
        static void Main(string[] args)
        {        
            bool loggedIn = false;
            double[] money = { 0, 0 };  // 1. chf 2. eur

            loggedIn = bankLogin();
            while(loggedIn) {
                Console.Clear();
                Console.WriteLine("Ihr Kontostand:\nCHF: {0}\tEUR: {1}\nWelche Funktion möchten Sie ausführen?\n" +
                    "1) Einzahlen CHF\n2) Abheben CHF\n3) Abheben EUR\n4) EUR umtauschen\n5) CHF umtauschen\n6) Ausloggen", money[0], money[1]);
                char input = Console.ReadKey().KeyChar;

                switch (input) {
                    case '1':
                        money[0] += depositChf();
                        break;
                    case '2':
                        money[0] -= pickMoney(money[0]);
                        break;
                    case '3':
                        money[1] -= pickMoney(money[1]);
                        break;
                    case '4':
                        money = changeMoney(money, true);
                        break;
                    case '5':
                        money = changeMoney(money, false);
                        break;
                    case '6':
                        Console.WriteLine("Sie werden ausgeloggt. Einen Moment bitte...");
                        Thread.Sleep(2000);
                        loggedIn = false;
                        break;
                    default:
                        continue;
                }
            }
        }
    }
}
