using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aufg9
{
    class PlayerRounds
    {
        /// <summary>
        /// The Round will be counted.<br></br>
        /// Every Round a two new Numbers will be created (between 1-6)<br></br>
        /// The first is the normal number, the other one is the lucky number<br></br>
        /// The normal number will be used to increase the points.<br></br>
        /// 1. It checks if normal and lucky number are the same.<br></br>
        /// 1.1 if they are the normal number will be multiplied with 3.<br></br>
        /// 2. It tests if the normal number is one<br></br>
        /// 2.1 If it is 1, all gatherd points will be erased and the turn ist over.<br></br>
        /// 3. the normal number value will be added to the max points.<br></br>
        /// 4. The Player decides to continiue playing
        /// </summary>
        /// <returns><code>points</code></returns>
        public ushort PlayerRound()
        {
            Random r = new Random();
            bool roundOver = false;
            int rndNum = 0, rndNumLuck = 0;
            ushort points = 0;
            char input = '0';

            while (!roundOver)
            {
                roundOver = false;
                rndNum = r.Next(1, 7);
                rndNumLuck = r.Next(1, 7);

                if (rndNum == rndNumLuck)
                {
                    Console.Write("GLÜCKSZAHL!");
                    Thread.Sleep(500);
                    rndNum *= 3;
                }
                else if (rndNum == 1)
                {
                    Console.WriteLine("Die gewürfelte Zahl ist eine 1!\tIhr Zug ist vorbei.");
                    Thread.Sleep(500);
                    points = 0;
                    break;
                }
                points += (ushort)rndNum;
                Console.WriteLine("\nDie gewürfelte Zahl ist eine {0}\n" +
                    "Angesammelte Punktzahl: {1}\n" +
                    "Wollen Sie weiter spielen? [j/n]", rndNum, points);
                input = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (input == 'j')
                    continue;
                else
                    roundOver = true;
            }
            return points;
        }
        /// <summary>
        /// The Round will be counted.<br></br>
        /// Every Round a two new Numbers will be created (between 1-6)<br></br>
        /// The first is the normal number, the other one is the lucky number<br></br>
        /// The normal number will be used to increase the points.<br></br>
        /// 1. It checks if normal and lucky number are the same.<br></br>
        /// 1.1 if they are the normal number will be multiplied with 3.<br></br>
        /// 2. It tests if the normal number is one<br></br>
        /// 2.1 If it is 1, all gatherd points will be erased and the turn ist over.<br></br>
        /// 3. the normal number value will be added to the max points.<br></br>
        /// 4. <see cref="ComputerAlgorithm"/> decide to continue playing
        /// </summary>
        /// <returns><code>points</code></returns>
        public ushort ComputerRound(ushort ptnNeed)
        {
            Random r = new Random();
            int rndNum = 0, rndNumLuck = 0;
            bool roundOver = false;
            ushort points = 0;
            byte round = 0;

            while (!roundOver)
            {
                round++;    // current round
                rndNum = r.Next(1, 7);
                rndNumLuck = r.Next(1, 7);

                if (rndNum == rndNumLuck)
                {
                    Console.Write("GLÜCKSZAHL!");
                    Thread.Sleep(500);
                    rndNum *= 3;
                }
                else if (rndNum == 1)
                {
                    Console.WriteLine("Die gewürfelte Zahl ist eine 1!\tIhr Zug ist vorbei.");
                    Thread.Sleep(500);
                    points = 0;
                    break;
                }
                points += (ushort)rndNum;
                Console.WriteLine("\nDie gewürfelte Zahl ist eine {0}\n" +
                    "Angesammelte Punktzahl: {1}\n" +
                    "Wollen Sie weiter spielen? [j/n]", rndNum, points);
                Thread.Sleep(750);
                roundOver = ComputerAlgorithm(round, rndNum, rndNumLuck, points, ptnNeed);
            }
            return points;
        }
        /// <summary>
        /// The Computer has three unique branches.<br></br>
        /// 1. if it has more points than needed, stop an win game<br></br>
        /// 2. if current points are more than 50, stop playing<br></br>
        /// 3. max. round count: 11, stop the round<br></br>
        /// 4. if last round was a lucky Number and it was at least 5, stop playing.<br></br>
        /// The normal schedule is to continue<br></br>
        /// </summary>
        /// <param name="round">current round</param>
        /// <param name="rndNum">last rounds normal Number</param>
        /// <param name="rndNumLuck">last rounds lucky Number</param>
        /// <returns>true - 1, 2 - / false - 3, normal schedule -</returns>
        public bool ComputerAlgorithm(byte round, int rndNum, int rndNumLuck, ushort points, ushort ptnNeed)
        {
            if (points >= ptnNeed)   // more points, than needed, stop funktion
                return true;
            else if (points >= 50)  // same as, more than 50 points
                return true;
            else if (round == 9)   // max. round count: 9, stop the round
                return true;
            else if (rndNum == rndNumLuck && rndNum >= 5)    // if last number was lucky and higher than 5, end ya turn
                return true;

            return false;   // normals schedule, continue
        }
    }
}
