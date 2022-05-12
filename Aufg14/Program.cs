using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aufg14
{
    class Program
    {
        /** Aufg14
         * Zeit: 150 min
         * 
         * Programmiere ein Schere, Stein, Papier Spiel, mit ein paar Zusätzen.
         * In diesem Spiel gibt es fünf Möglichkeiten: Schere, Stein, Papier, Brunnen und Streichholz.
         * 
         * Regeln:
         * Der Spieler spielt gegen einen Computer.
         * Zu Beginn, wird dem Spieler gezeigt, gegen wen er spielt;
         * Erstelle dazu einen Array mit mind. 3 Namen, welche bei jedem Spiel zufällig ausgelost werden.
         * Der Gegner soll eine Liste mit seinen Auswahlen (inputs) vorher erstellt bekommen (mind. 3).
         * Diese werden später, eine nach der andern, genutzt werden.
         * Hat der Gegner seine Liste abgearbeitet, fängt er diese von neu an.
         * Der Spieler muss immer die erste Eingabe machen, nachher macht der Computer seine Eingabe von der Liste.
         * In jedem Zug wird dem Spieler einmal das Regelwerk (was, was besiegt) und dessen Auswahlmöglichkeiten gezeigt.
         * Wie immer darf der Spieler nur genau diese fünf Werte auswählen können.
         * Nach beiden Eingaben, wird ausgewertet, welcher von beiden, diese Runde gewonnen hat.
         * Bei einem Unentschieden, passiert nichts.
         * Wenn der Spieler gewinnt, bekommt dieser einen Punkt; andersrum, wenn der Computer gewinnt.
         * Der, der zuerst Drei Punkte hat, gewinnt das Spiel.
         * Am Ende wird man nochmals gefragt, ob man nochmal spielen will.
         */

        /// <summary>
        /// Sends an decorated message
        /// </summary>
        /// <param name="msg">displayed message</param>
        static void GeneralMessage(string msg)
        {
            Console.WriteLine("" +
                "*********************************\n" +
                "{0}\n" +
                "*********************************", msg
            );
        }
        /// <summary>
        /// Generates a number between 1 and 5.<br></br>
        /// Loop Rund as long as MoveSet array is (9).<br></br>
        /// The Computers "MoveSet" will randomly be generated.<br></br>
        /// </summary>
        /// <returns>Computers MoveSet</returns>
        static ushort[] ComputerMoveSetPicker()
        {
            Random r = new Random();
            ushort[] moveSet = new ushort[9];
            int rnd = 0;
            for (byte i = 0; i < moveSet.Length; i++) {
                rnd = r.Next(1, 6);
                moveSet[i] = (ushort)rnd;
            }

            return moveSet;
        }
        /// <summary>
        /// Creates an Array, with 7 precasted names
        /// Creates rnd Number to pick an random name
        /// </summary>
        /// <returns>Computers Name</returns>
        static string ComputerNamePicker()
        {
            Random r = new Random();
            string[] name = {
                "Gian Vieli", "Mateo Bucher", "Alexander Imwinkelried", "Adrian Keusch",
                "Nicola Rubin", "Ardian Shehi", "Linus Schorro", "Fabio Hediger"
            };
            int i = r.Next(0, name.Length);

            return name[i];
        }
        /// <summary>
        /// Checks if the Players input was correct
        /// </summary>
        /// <param name="input">players input</param>
        /// <returns>true - correct / false - not correct</returns>
        static bool CorrectInput(char input)
        {
            if (input >= 49 && input <= 53) // 1 - 5 in the ASCII Table
                return true;

            return false;
        }
        /// <summary>
        /// Tests the players and computer input, and returns if the computer has won the round.
        /// </summary>
        /// <param name="player">player input</param>
        /// <param name="computer">computer input</param>
        /// <returns>true - if computer won / flase - if not</returns>
        static bool ComputerWonRound(ushort player, ushort computer)
        {
            if (player == 1 && (computer == 2 ^ computer == 5)) // ^ = xor
                return false;
            else if (player == 2 && (computer == 3 ^ computer == 5))
                return false;
            else if (player == 3 && (computer == 1 ^ computer == 4))
                return false;
            else if (player == 4 && (computer == 1 ^ computer == 2))
                return false;
            else if (player == 5 && (computer == 3 ^ computer == 4))
                return false;

            return true;
        }
        /// <summary>
        /// Converts the player input from char to byte (normal number)
        /// </summary>
        /// <param name="input">player input value</param>
        /// <returns>player input as (normal) number</returns>
        static byte ConvertInput2Byte(char input)
        {
            byte choiceNumber = 0;
            for (byte i = 49; i <= 53; i++) {   // Alle Char-Zahlenstellen zwischen 1-5 durchsuchen
                choiceNumber++;
                if(input == i)  // wenn playerInput und i gleich sind, wurde diese Zahl gedrückt
                    return choiceNumber;    // input als zahl zurückgegen
            }
            return 1;   // unbekannter error -> erste Eingabe wählen
        }
        /// <summary>
        /// The Players turn will be displayed -> <see cref="GeneralMessage(string)"/>
        /// The player make his input and check it with <see cref="CorrectInput(char)"/><br></br>
        /// Lets the Computer make his move of his moveSet -> <see cref="ComputerMoveSetPicker"/><br></br>
        /// Displays both moves; converts player input in number -> <see cref="ConvertInput2Byte(char)"/><br></br>
        /// Checks which player won the round -> <see cref="ComputerWonRound(ushort, ushort)"/><br></br>
        /// If Computer or Player won display it <see cref="GeneralMessage(string)"/> and finish<br></br>
        /// </summary>
        static void PlayGame()
        {
            string rules = "Regelwerk:\n" +
                "Stein      schlägt Scherre und Streichholz\n" +
                "Scherre    schlägt Papier und Streichholz\n" +
                "Papier     schlägt Stein und Brunnen\n" +
                "Brunnen    schlägt Stein und Schere\n" +
                "Streichholz schlägt Papier und Brunnen\n";
            string choices = "1) Stein\n2) Scherre\n3) Papier\n4) Brunnen\n5) Steichholz";
            string wonLostRound = "Du hast diese Runde {0}.";
            string[] optionsNames = { "Stein", "Scherre", "Papier", "Brunnen", "Streichholz" };
            char playerInput = '0';
            ushort computerInput = 0;
            ushort[] computerMoveSet = ComputerMoveSetPicker();
            byte computerMove = 0, playerWonRounds = 0, computerWonRounds = 0;
            bool gameOver = false;

            while (!gameOver) {
                // player turn
                GeneralMessage("Der Spieler ist an der Reihe");
                Console.WriteLine(rules);
                Console.Write(choices);
                do {
                    Console.Write("\nDeine Eingabe: ");
                    playerInput = Console.ReadKey().KeyChar;    // player input
                } while (!CorrectInput(playerInput));

                computerInput = computerMoveSet[computerMove];  // computer round
                if (computerMove >= computerMoveSet.Length - 1)
                    computerMove = 0;
                else
                    computerMove++;

                Console.Clear();

                Console.WriteLine("Spieler nutzt {0} gegen {1}!\n",
                    optionsNames[ConvertInput2Byte(playerInput) - 1], optionsNames[computerInput - 1]);   // ausgabe, wer was macht
                Thread.Sleep(1000);

                // auswertung, wer die Runde gewonnen hat
                if (playerInput == computerInput) {
                    Console.WriteLine("Unentschieden!");
                    Thread.Sleep(1000);
                } else if (ComputerWonRound(ConvertInput2Byte(playerInput), computerInput)) {
                    Console.WriteLine(wonLostRound, "verloren");
                    computerWonRounds++;
                } else {
                    Console.WriteLine(wonLostRound, "gewonnen");
                    playerWonRounds++;
                }
                Thread.Sleep(1500);

                // auswertung, wer das Spiel gewonnen hat
                Console.Clear();
                if (playerWonRounds >= 3) {
                    GeneralMessage("Du hast gewonnen!");
                    gameOver = true;
                } else if (computerWonRounds >= 3) {
                    GeneralMessage("Du hast verloren!");
                    gameOver = true;
                }
            }
            Thread.Sleep(2000);
        }
        /// <summary>
        /// Main Programm
        /// </summary>
        static void Main(string[] args)
        {
            bool programOut = false;
            char input = '0';

            // GegnerName wird einmal gebraucht, also ist abspeichern nicht nötig
            while (!programOut) {
                Console.Clear();
                Console.WriteLine("Sie werden gegen {0} spielen.\n", ComputerNamePicker());
                Thread.Sleep(1500);
                
                PlayGame(); // main game

                Console.WriteLine("Nochmal Spielen [j/n]?");
                input = Console.ReadKey().KeyChar;
                if (input == 'j')
                    continue;

                programOut = true;
            }

            Console.ReadKey();  // endl
        }
    }
}
