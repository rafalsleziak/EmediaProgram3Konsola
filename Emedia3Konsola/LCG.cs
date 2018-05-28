using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emedia3Konsola
{
    class LCG
    {
        private const ulong a = 3141592653;
        private const ulong c = 2718281829;
        private const ulong m = 34359738368;
        public ulong x;

        public ulong Multiply(ulong a, ulong b, ulong m)  // obliczanie funkcji a*b % n
        {
            ulong n, w;

            w = 0; n = 1;
            while (n != 0)
            {
                if (b != 0 && n != 0)
                    w = (w + a) % m;
                a = (a << 1) % m;
                n <<= 1;
            }
            return w;
        }

        void Ziarno()  // inicjowanie ziarna
        {
            TimeSpan span = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc));
            x = (ulong)span.TotalSeconds;
        }

        public ulong LCGAlgorithm()  // generator
        {
            x = Multiply(x, a, m);
            x = (x + c) % m;
            return x;
        }

        public void RandomGenerator()
        {
            ulong Wxy, Lxy, xz, y;
            int n;
            double XR;

            Ziarno();
            // X i Y okreslaja nasz przedzial z jakiego losujemy 
            //n okresla ilosc losowany liczb
            //Liczbe XR dzielimy przez m by zwiekszyc pseudolosowosc

            /*Console.WriteLine ("Podaj zakres od:);
            x=Convert.ToInt32(Console.ReadLine());;
            Console.WriteLine ("Podaj zakres do:)";
            y=Convert.ToInt32(Console.ReadLine());;
            Console.WriteLine ("Podaj ile liczb wylosowac:);
            n=Convert.ToInt32(Console.ReadLine());*/

            xz = 0;
            y = 500000;
            n = 10000;

            Lxy = y - xz + 1;

            for (int i = 0; i < n; i++)
            {
                XR = LCGAlgorithm() / (double)m;
                Wxy = (ulong)Math.Floor(XR * Lxy) + xz;
                Console.WriteLine(Wxy);
            }
            Console.ReadKey();


        }

    }
}
