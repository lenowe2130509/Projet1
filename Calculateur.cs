using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculateur
{
    internal class Calculateur
    {
        private int x;
        private int y;

        public int Diviser(int x, int y)
        {
            int calcul = 0;
            calcul = x / y;

            return calcul;
        }

        public int Multiplier(int x, int y)
        {
            int calcul = 0;
            calcul = x * y;

            return calcul;
        }

        public int Additionner(int x, int y)
        {
            int calcul = 0;
            calcul = x + y;
            return calcul;
        }

        public int Soustraction(int x, int y)
        {
            int calcul = 0;
            calcul = x - y;
            return calcul;
        }

        public double Exposant(int x, int y)
        {
            double calcul = 0;
            calcul = Math.Pow(x,y);
            return calcul;
        }

        public double Logarithmes(int x, int y)
        {
            double calcul = 0;
            calcul = Math.Log(x,y);
            return calcul;
        }
    }
}
