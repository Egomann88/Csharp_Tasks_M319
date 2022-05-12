namespace Aufg6
{
    public class Mathefunktionen
    {
        public int getGgT(int x, int y)
        {
            int rest = 0;
            while(true) {
                rest = x % y;
                if (rest == 0) {
                    break;
                }
                x = y;
                y = rest;
            }
            return y;
        }
        /// <summary>
        /// Berechnet ggT in While Schleife
        /// nutzt ggT, um KgV zu berechnen
        /// (z1 * z2) / ggT = KgV
        /// </summary>
        /// <param name="x">erste Zahl</param>
        /// <param name="y">zweite Zahl / ggT</param>
        /// <returns></returns>
        public int getKgV(int x, int y)
        {
            int rest = 0, z1 = x, z2 = y; // originalwerte speichern
            while (true) {
                rest = x % y;
                if (rest == 0) {
                    break;
                }
                x = y;
                y = rest;
            }
            int ggT = y;    // ggT weitergeben
            return (z1 * z2) / ggT; // originalwerte zur berechnung benutzen
        }
    }
}
