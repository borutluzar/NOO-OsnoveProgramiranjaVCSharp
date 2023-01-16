﻿using System;

namespace Methods
{
    internal class Program
    {
        /*
         * Ko pišemo programe, jih vedno poskušamo razdeliti na majhne, čim bolj neodvisne sklope kode. 
         * Na ta način se izognemo podvojenemu pisanju kode, 
         * saj delček kode, ki je nekje že napisan, le ``pokličemo'' in izvedemo na ustreznih mestih, 
         * namesto da bi vse ukaze napisali znova.
         * Zapisovanje posameznih delčkov kode nam omogočajo metode.
         */

        static void Main(string[] args)
        {
            // V tem projektu bomo v Main druge metode samo klicali,
            // zapisovali pa jih bomo izven nje, kot samostojne delčke kode

            // Izvedimo metodo Kvocient in izpišimo njen rezultat
            int a = 7;
            int b = 13;
            double result = Kvocient(a, b);
            Console.WriteLine($"Rezultat metode {nameof(Kvocient)} za parametra {a} in {b} je {result:0.0000}");

            // Pokličemo metodo SumThree
            int sum = SumThree(1, 10, 100);
            Console.WriteLine($"Naš rezultat je {sum}");

            // Klic metode Quotient
            double quotient = Quotient(12, 13);
            Console.WriteLine($"Rezultat deljenja je {quotient:0.000}");

            // In še klic metode GetPatientsHeight
            int patientsHeight = GetPatientsHeight();
            Console.WriteLine($"Višina pacienta je {patientsHeight}");

            Console.Read();


            // Izpiši GCD za vse pare števil od 1 do n
            //WriteGCDForPairs(15);

            // Pokličimo še metodo, ki lovi izjeme
            //CatchException();

            // Še ena funkcija z nekaj več opravili
            ComputingQuestions();

            Console.Read();
        }

        /// <summary>
        /// Metoda kot parametra prejme dve celi števili,
        /// vrača pa realno število, ki predstavlja
        /// kvocient parametrov.
        /// </summary>
        static double Kvocient(int a, int b)
        {
            double result = (double)a / b;
            // Stavek return pove, katero vrednost vračamo
            return result;
        }

        static int GetPatientsHeight()
        {
            int height = 0;
            while (height == 0)
            {
                Console.Write($"Vpišite svojo višino: ");
                string answer = Console.ReadLine();

                try
                {
                    height = int.Parse(answer);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Prišlo je do napake, " +
                        $"zaradi nepravilne oblike vnosa (ni število)!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"Prišlo je do napake, " +
                        $"zaradi vnosa števila, ki je preveliko ali premajhno za int!");
                }
                catch (Exception ex)
                {
                    //Console.WriteLine($"Prišlo je do napake:\n{ex.Message}");
                    throw new Exception($"Nekaj je šlo hudo narobe!\n{ex.Message}");
                }
            }

            return height;
        }

        /// <summary>
        /// Sešteje tri podana števila.
        /// </summary>
        /// <param name="num1">Prvo število</param>
        /// <param name="num2">Drugo število</param>
        /// <param name="num3">Tretjo število</param>
        /// <returns>Vsoto treh podanih števil.</returns>
        static int SumThree(int num1, int num2, int num3) // Glava metode
        {
            int result = num1 + num2 + num3;

            return result;
        }

        static double Quotient(int num1, int num2)
        {
            double result = num1 / (double)num2;
            return result;
        }

        /// <summary>
        /// Poišče največji skupni delitelj dveh števil
        /// </summary>
        public static int GreatestCommonDivisor(int a, int b)
        {
            int gcd = 1;
            for (int i = 2; i < Math.Min(a, b); i++)
            {
                if (a % i == 0 && b % i == 0)
                {
                    gcd = i;
                }
            }
            return gcd;
        }

        /// <summary>
        /// Izpiše GCD za vse pare od 1 do n
        /// </summary>
        public static void WriteGCDForPairs(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = i; j <= n; j++)
                {
                    int gcd = GreatestCommonDivisor(i, j);
                    Console.WriteLine($"Največji skupni delitelj števil {i} in {j} je {gcd}.");
                }
                Console.WriteLine();
            }
        }

        static void CatchException()
        {
            Console.Write("Vnesite število, jaz pa bom izračunal njegov kvadrat: ");
            string input = Console.ReadLine();
            try
            {
                // Pretvorimo dane vhodne podatke v celo število
                int inputInt = int.Parse(input);
                Console.WriteLine($"Kvadrat števila {inputInt} je {inputInt * inputInt}");
            }
            catch (FormatException) //
            {
                Console.WriteLine("Vnos ni v pravilni obliki!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Prišlo je do nepredvidene napake!\n" +
                    $"{ex.Message}");
            }
            finally
            {
                Console.WriteLine("Na tem mestu se metoda zaključi!");
            }
        }

        /// <summary>
        /// Metoda uporabniku podaja računske naloge, dokler se ta ne zmoti,
        /// in vrne število pravilnih odgovorov
        /// </summary>
        static int ComputingQuestions()
        {
            Random rnd = new Random();
            int countCorrect = 0;
            int upperLimit = 8;
            while (true)
            {
                upperLimit *= (countCorrect / 5) + 1;
                int num1 = rnd.Next(1, upperLimit);
                int num2 = rnd.Next(1, upperLimit);
                int num3 = rnd.Next(1, 10);

                byte operation1 = (byte)rnd.Next(0, 4);
                byte operation2 = (byte)rnd.Next(0, 4);

                int correctAnswer = Compute(num1, num2, num3, operation1, operation2);
                string question = $"{num1} {GetOperator(operation1)} {num2} {GetOperator(operation2)} {num3}";

                Console.WriteLine($"Zapišite rezultat izraza: {question}");
                Console.Write("Odgovor: ");
                string answer = Console.ReadLine();

                try
                {
                    int answerInt = int.Parse(answer);
                    if (answerInt == correctAnswer)
                    {
                        countCorrect++;
                        Console.WriteLine($"Odgovor {answerInt} je pravilen! Imate že {countCorrect} pravilnih odgovorov!");
                    }
                    else
                    {
                        Console.WriteLine($"Odgovor {answerInt} ni pravilen! " +
                            $"Igra je zaključena. Zbrali ste {countCorrect} pravilnih odgovorov!");
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Vaš odgovor ni število, zato je žal napačen!\n\nGAME OVER!\n\n");
                    Console.WriteLine($"Pravilno ste odgovorili na {countCorrect} vprašanj!");
                    break;
                }
                finally
                {
                    Console.WriteLine();
                }
            }
            return countCorrect;
        }

        /// <summary>
        /// Funkcija vrne znak, ki predstavlja operacijo
        /// glede na podano vrednost.
        /// </summary>
        /// <param name="operation">Številska vrednost operacije (0-seštevanje, 1-odštevanje, 2-množenje in 3-deljenje)</param>
        /// <returns>Znak za operacijo</returns>
        /// <exception cref="Exception">Napaka, če podana vrednost ni celo število iz intervala [0,3]</exception>
        static string GetOperator(byte operation)
        {
            switch (operation)
            {
                case 0:
                    return "+";
                case 1:
                    return "-";
                case 2:
                    return "*";
                case 3:
                    return "/";
                default:
                    throw new Exception("Operacija s to vredostjo ni predvidena!");
            }
        }

        static int Compute(int num1, int num2, int num3, byte op1, byte op2)
        {
            int finalResult = 0;
            if (op1 == 2 || op1 == 3)
            {
                finalResult = ComputeSimple(num1, num2, op1);
                finalResult = ComputeSimple(finalResult, num3, op2);
            }
            else if (op2 == 2 || op2 == 3)
            {
                finalResult = ComputeSimple(num2, num3, op2);
                finalResult = ComputeSimple(num1, finalResult, op1);
            }
            else
            {
                finalResult = ComputeSimple(num1, num2, op1);
                finalResult = ComputeSimple(finalResult, num3, op2);
            }
            return finalResult;
        }

        /// <summary>
        /// Izračuna vrednost izraza za dani operator.
        /// </summary>
        static int ComputeSimple(int num1, int num2, byte op)
        {
            switch (op)
            {
                case 0: return num1 + num2;
                case 1: return num1 - num2;
                case 2: return num1 * num2;
                case 3: return num1 / num2;
                default: return 0;
            }
        }
    }
}