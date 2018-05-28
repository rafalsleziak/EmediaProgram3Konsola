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

        ulong Multiply(ulong a, ulong b, ulong n)
        {
            ulong m, w;

            w = 0; m = 1;
            while (m!=0)
            {
                if (b!=0 & m!=0) w = (w + a) % n;
                a = (a << 1) % n;
                m <<= 1;
            }
            return w;
        }


        private static ulong mult(ulong a, ulong x, ulong m)
        {
            ulong b, n, r;

            r = 0;
            n = 1;
            b = 1;
            while (n <= 64)
            {
                if ((a & b) != 0)
                    r = (r + x) % m;
                x = (x + x) % m;
                b *= 2;
                n++;
            }

            return r;
        }
        void Ziarno()  // inicjowanie ziarna
        {
            TimeSpan span = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc));
            x = (ulong)span.TotalSeconds;
            Console.WriteLine(x);
            Console.WriteLine();
        }

        public ulong LCGAlgorithm()  // generator
        {
            x = mult(x, a, m);
            x = (x + c) % m;
           // Console.WriteLine(x);
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

            xz = 2;
            y = 1000;
            n = 100;

            Lxy = y - xz + 1; //rozpietosc w jakiej losujemy

            for (int i = 1; i < n; i++)
            {
                XR = LCGAlgorithm() / (double)m;
                Wxy = (ulong)Math.Floor(XR * Lxy) + xz;
                Console.WriteLine(Wxy);
            }
            Console.ReadKey();
        }

    }
}
