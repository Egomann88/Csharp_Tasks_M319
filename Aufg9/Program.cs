using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aufg9
{
    class Program
    {
        private PlayerRounds Rounds = new PlayerRounds();

        /// <summary>
        /// This is the entire dice game<br></br>
        /// 1. <see cref="GenerallFuncs.WhoFirst"/> decides who can beginn
        /// 2. if player 1 begins <see cref="PlayerRounds.PlayerRound"/> will run<br></br>
        /// 2.1 if player 1 is first, <see cref="GenerallFuncs.GameWon"/> runs<br></br>
        /// 3.1 If gameMode is 1 (PvC) <see cref="PlayerRounds.ComputerRound"/> runs<br></br>
        /// 3.2 if gameMOde is 2 (PvP) <see cref="PlayerRounds.PlayerRound"/> runs (player 2)<br></br>
        /// 4. <see cref="GenerallFuncs.GameWon"/> if computer/player 2 won<br></br>
        /// 5. <see cref="PlayerRounds.PlayerRound"/> is player 1 is not first<br></br>
        /// 6. <see cref="GenerallFuncs.GameWon"/> if player 1 won<br></br>
        /// </summary>
        /// <param name="playerNameOne">Name of the first player</param>
        /// <param name="playerNameTwo">Name of the second player</param>
        /// <param name="gameMode">The choosen playmode</param>
        /// <returns></returns>
        static bool DiceGame(string playerNameOne, string playerNameTwo, char gameMode)
        {
            PlayerRounds Rounds = new PlayerRounds();
            GenerallFuncs gmFuncs = new GenerallFuncs();
            string playerTurn = "{0} ist am Zug.\n\n", // switch turn text
                ptnsNeed = "Verbleibende Punkte: {0}";  // remaining poinst to win
            bool playerTurnFirst = gmFuncs.WhoFirst(); // ist player (1) first?
            ushort GoalPtnPlayer = 0, GoalPtnEnemy = 0, goalNum = 150; // points have and need to win

            gmFuncs.GlobalMsg(playerTurnFirst ? playerNameOne + " darf beginnen" : playerNameTwo + " darf beginnen"); // display the first mover

            while (true) {
                if (playerTurnFirst) { // player is first
                    Console.WriteLine(playerTurn, playerNameOne);
                    GoalPtnPlayer += Rounds.PlayerRound(); // increase Points
                    Console.WriteLine(ptnsNeed, (goalNum - GoalPtnPlayer));
                }

                if (gmFuncs.GameWon(GoalPtnPlayer, goalNum))
                    return true;

                Thread.Sleep(1000);
                Console.Clear();
                // computer round
                Console.WriteLine(playerTurn, playerNameTwo);
                
                if(gameMode == '1') // computer
                    GoalPtnEnemy += Rounds.ComputerRound(goalNum); //  increase enemy Points
                else    //  player 2
                    GoalPtnEnemy += Rounds.PlayerRound(); //    increase enemy(player) Points

                Console.WriteLine(ptnsNeed, (goalNum - GoalPtnEnemy));
                if (gmFuncs.GameWon(GoalPtnEnemy, goalNum))
                    return false;

                Thread.Sleep(1000);
                Console.Clear();

                if (!playerTurnFirst) { // player is not first
                    Console.WriteLine(playerTurn, playerNameOne);
                    GoalPtnPlayer += Rounds.PlayerRound(); // increase Points
                    Console.WriteLine(ptnsNeed, (goalNum - GoalPtnPlayer));
                }
                if (gmFuncs.GameWon(GoalPtnPlayer, goalNum))
                    return true;

                Thread.Sleep(1000);
                Console.Clear();
            }
        }

        /// <summary>
        /// Aufg9
        /// Zeit: 150 min
        /// 
        /// Programmiere ein Würfelspiel.<br></br>
        /// Die spielende Person muss einen Namen eingeben.<br></br>
        /// Die Zielpunktzahl 150; Gewinnen tut die Person, welche zuerst 150 erreicht hat.<br></br>
        /// Das Programm entscheidet zufällig, welche/r Spieler/-in beginnen darf.<br></br>
        /// Dies wird mit Zufallszahlen von 1 bis und mit 6 simuliert.<br></br>
        /// Es gibt auch eine Glückszahl, welche ebenfalls Zahlen von 1 bis 6 simuliert.<br></br>
        /// Die Funktionen müssen in 2 Klassen unterteilt werden.<br></br>
        /// Programmiere so, dass man selbst gegen einen Computer spielen kann.<br></br>
        /// (Die Antworten des Computers können algorithmisch oder komplett zufällig sein.)<br></br>
        /// Am Ende soll man gefragt werden, ob man nochmal spielen will.<br></br>
        /// Der Code muss komplett, kommentiert und dokumentiert sein.
        /// Regeln:<br></br>
        ///     1. Nach jedem Würfeln muss die würfelnde Person entscheiden, ob sie weiter würfeln will,<br></br>
        ///        um mehr Punkte zu holen, welche am Ende einer Würfelsequenz gespeichert werden können.<br></br>
        ///     2. Beendet man die Würfelsequenz, werden die gesammelten Punkte gespeichert und der<br></br>
        ///        Spieler wechselt<br></br>
        ///     3. Würfelt man genau eine 1, verliert man alle Punkte, welche man in der aktuellen<br></br>
        ///        Würfelsequenz erspielt hat und der Spieler wechselt<br></br>
        ///     4. Wenn die Zufalls- und Glückszahl genau gleich sind, dann wird die Zufallszahl mit 3<br></br>
        ///        multipliziert.<br></br>
        ///     5. Wenn die Normale und Glückszahl beide 1 sind, werden die Punkte nicht gelöscht<br></br>
        ///     <br></br>
        /// ZUSATZ:<br></br>
        /// Programmiere einen zweiten Spielmodus, indem man gegen eine andere Person spielen kann.<br></br>
        /// Stell dir die Frage, wie optimiert ist dein Programm?<br></br>
        /// Schau, ob du passendere Datentypen (ushort, byte, char, ...),<br></br>
        /// redundante Funktionen und / oder unnütze Variablen löschen.<br></br>
        /// </summary>
        /// <param name="args">args</param>
        static void Main(string[] args)
        {
            GenerallFuncs gm = new GenerallFuncs(); // import class

            string playerNameOne = "",  // player one Name
                playerNameTwo = "Der Computer", // player Two Name, standard: the Computer
                inputName = "Geben Sie ihren Namen ein: ",  // input your name
                didWin = " hat gewonnen!";   // did win
            bool restartGame = false;   // play again?
            char playMode = '0',    // witch playmode
                input = '0';    // divers inputs

            while (!restartGame) {
                Console.Clear();
                // title + playmodes
                gm.GlobalMsg("Das Würfelspiel");
                Console.WriteLine("Welchen Spielmodus wollen Sie spielen?" +
                    "\n1) Spieler gegen Computer" +
                    "\n2) Spieler gegen Spieler");

                playMode = Console.ReadKey().KeyChar;   // input playmode
                Console.WriteLine("");
                if (playMode == '1') {   // PvC
                    Console.WriteLine("Sie werden gegen den Computer spielen.");
                    Thread.Sleep(500);
                    Console.Write(inputName);
                    playerNameOne = Console.ReadLine();
                    playerNameTwo = "Der Computer";
                    Console.Clear();
                } else if (playMode == '2') {   // PvP
                    Console.WriteLine("Sie spielen zu zweit gegeneinander.");
                    Thread.Sleep(500);
                    Console.Write("Spieler 1 " + inputName);    // pl 1
                    playerNameOne = Console.ReadLine();
                    Console.Write("Spieler 2 " + inputName);    // pl 2
                    playerNameTwo = Console.ReadLine();
                    Console.Clear();
                }
                else // wrong input
                    continue;

                // play diceGame
                if (DiceGame(playerNameOne, playerNameTwo, playMode))   // if true is returned, the 1. Player wins
                    gm.GlobalMsg(playerNameOne + didWin);
                else   // if false, player 2 wins
                    gm.GlobalMsg(playerNameTwo + didWin);

                // game end
                Console.WriteLine("Wollen Sie nochmal spielen? [j/n]"); // play again
                input = Console.ReadKey().KeyChar;
                if (input == 'j')
                    continue;

                restartGame = false;    // end progamm
            }
        }
    }
}
