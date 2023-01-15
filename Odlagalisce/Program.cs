namespace Odlagalisce
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dobrodošel, svet!");

            long t = 10;
            int[] x = new int[] { 1, 2, 3 };
            Console.WriteLine(x.LongLength);

            /*long[] fib = new long[100];
            fib[0] = 1;
            fib[1] = 1;
            for (long i = 2; i < 100; i++)
            {
                fib[i] = fib[i - 1] + fib[i - 2];
            }

            fib.ToList().ForEach(x => Console.WriteLine(x));*/

            // Določimo število mesecev varčevanja
            int months = 24;
            // Določimo glavnico
            decimal principalAmount = 1000;
            // Določimo obrestno mero
            decimal intRate = 0.0678M; // 6,78%

            // Definiramo tabelo za shranjevanje
            decimal[] amountsPerMonth = new decimal[25]; // 24 mesec + začetek
            amountsPerMonth[0] = principalAmount;
            for (int i = 1; i < amountsPerMonth.Length; i++)
            {
                // Vsak mesec se znesek poveča za znesek prejšnjega meseca
                // plus obresti
                amountsPerMonth[i] = amountsPerMonth[i - 1] * (1 + intRate);
            }

            int countMonth = 0;
            foreach (var amount in amountsPerMonth)
            {
                Console.WriteLine($"V {countMonth}. mesecu imamo na računu {amount:0.00} evrov.");
                countMonth++;
            }

            /*
            int width = 25;
            int height = 10;
            Random rnd = new Random();
            char[][] mreza = new char[height][];
            for (int i = 0; i < height; i++)
            {
                mreza[i] = new char[width];
                for (int j = 0; j < width; j++)
                {
                    int type = rnd.Next(3);
                    switch (type)
                    {
                        case 0:
                            mreza[i][j] = '#';
                            break;
                        case >= 1:
                            mreza[i][j] = '.';
                            break;
                    }
                    Console.Write(mreza[i][j]);
                }
                Console.WriteLine();
            }
            */

            List<string> seznam = new List<string>();
            seznam.Add("Riba");
            seznam.Add("Riba");
            seznam.Add("reže");
            seznam.Add("raci");
            seznam.Add("rep.");
            seznam[0] = "morska";

            seznam.RemoveAt(0);


            Random rnd = new Random();
            List<int> seznamSodih = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                int rndChosen = rnd.Next(1001);
                if (rndChosen % 2 == 0)
                    seznamSodih.Add(rndChosen);
            }
            Console.WriteLine($"Med izbranimi števili je {seznamSodih.Count} sodih.");


            double kvocient = Kvocient(3, 4);
            Console.WriteLine($"Kvocient števil 3 in 4 je {kvocient}.");

            Console.Read();
        }

        static double Kvocient(int a, int b)
        {
            double result = (double)a / b;
            return result;
        }
    }
}