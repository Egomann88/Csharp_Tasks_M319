using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufg9
{
    class GenerallFuncs
    {
        /// <summary>
        /// 1. Creats a random number between 1-2<br></br>
        /// 2. if the rnd number is 1, player 1 beginns<br></br>
        /// 3. if the rnd nubmer is 2, player 2 / computer beginns<br></br>
        /// </summary>
        /// <returns>true / false</returns>
        public bool WhoFirst()
        {
            Random r = new Random();
            int rndNum = r.Next(1, 3);

            if (rndNum == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// If goalPts is smaller than the needed Points; The Person / Computer wins
        /// </summary>
        /// <param name="goalPts">All of the Persons/Computers Points</param>
        /// <param name="ptsNeed">The points, which must be surpassed</param>
        /// <returns>true - when surpassed - / false</returns>
        public bool GameWon(ushort goalPts, ushort ptsNeed)
        {
            if (goalPts >= ptsNeed)
                return true;

            return false;
        }

        /// <summary>
        /// Sets an title or a very important statement
        /// </summary>
        /// <param name="msg">The displayed message</param>
        public void GlobalMsg(string msg)
        {
            Console.Clear();    // title 
            Console.WriteLine (
                "**********************************************\n" +
                "{0}\n" +
                "**********************************************", msg
            );
        }
    }
}
