﻿using System.Drawing;

namespace FilesAndStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ***********************************************
            // Nizi

            // Delo z nizi bomo opisali v metodi StringManipulation.
            StringManipulation();


            
            // ***********************************************
            // Pisanje v datoteko
            WritingInFiles();

            
            
            // ***********************************************
            // Branje iz datoteke
            ReadingFromFiles();

            Console.Read();
        }

        /// <summary>
        /// Metoda, v kateri na kratko prikažemo 
        /// zapisovanje v datoteko
        /// </summary>
        static void WritingInFiles()
        {
            // Z datoteko se povežemo s pomočjo razreda StreamWriter
            StreamWriter swFile = new StreamWriter("Borut.txt", true);

            // Pridobimo trenutni čas in datum
            DateTime dtNow = DateTime.Now;
            // Zapišimo ga v datoteko skupaj s podatki o vremenu
            swFile.WriteLine($"Zapis je bil ustvarjen: {dtNow.ToString("d. M. yyyy  HH:mm:ss")}");
            swFile.WriteLine("-1");
            swFile.WriteLine("Sončno");
            swFile.WriteLine("Malo pa sneži.");
            
            // Zaprimo datoteko
            swFile.Close();
            Console.WriteLine("Zapisovanje v datoteko je končano!");
        }

        static void WriteWeatherData(string fileName, double temperature, double pressure, double windSpeed)
        {
            StreamWriter swFile = new StreamWriter(fileName, true);

            DateTime dtNow = DateTime.Now;
            swFile.WriteLine("--------------------------");
            swFile.WriteLine($"Zapis je bil ustvarjen: {dtNow.ToString("d. M. yyyy  HH:mm:ss")}");
            swFile.WriteLine("--------------------------");
            swFile.WriteLine($"Temperatura: {temperature:0.00}");
            swFile.WriteLine($"Zračni tlak: {pressure:0.00}");
            swFile.WriteLine($"Hitrost vetra: {windSpeed:0.00}");
            swFile.WriteLine("**************************");

            swFile.Close();
        }

        /// <summary>
        /// Metoda, v kateri na kratko prikažemo 
        /// branje iz datoteke
        /// </summary>
        static void ReadingFromFiles()
        {
            string fileName = "Borut.txt";
            StreamReader srFile = new StreamReader(fileName);

            Console.WriteLine($"Beremo iz datoteke {fileName}\n");
            int count = 0;
            int countTemps = 0;
            double totalTemps = 0;
            while (srFile.EndOfStream == false)
            {
                count++;
                // Beremo
                string line = srFile.ReadLine();
                if (count % 4 == 2)
                {
                    double temp = double.Parse(line);
                    totalTemps = totalTemps + temp;
                    countTemps++;
                    Console.WriteLine(line);
                }
            }

            Console.WriteLine($"Povprečna temperatura je: {totalTemps / countTemps}");

            srFile.Close();
        }


        static void StringManipulation()
        {
            // Dani niz razbijemo na več vrednosti glede na podane separatorje z metodo Split

            // Recimo, da imamo naslednjo vrstico s podatki ločenimi z vejicami
            string suroviPodatki = "Janez,Novak,33,185,90,rdeča,samozaposlen";

            // Uporabimo metodo Split, ki vrne tabelo nizov
            string[] podatki = suroviPodatki.Split(',');
            // Izpišimo jih
            foreach (string podatek in podatki)
            {
                Console.WriteLine(podatek);
            }

            // Običajno ob podatkih dobimo še shemo oziroma navodila,
            // kaj kateri od podatkov pomeni in glede na to lahko 
            // pridobljene podatke tudi validiramo. 
            // Za zgornje podatke imamo naslednjo shemo:
            // Ime, Priimek, Starost, Višina, Teža, Barva oči, Zaposlitveni status
            string ime = podatki[0];
            string priimek = podatki[1];
            int starost = int.Parse(podatki[2]);
            int visina = int.Parse(podatki[3]);
            int teza = int.Parse(podatki[4]);
            string barvaOci = podatki[5];
            string zaposlitveniStatus = podatki[6];
            Console.WriteLine($"Oseba {ime} {priimek} ima {starost} let, " +
                $"visoka je {visina} cm in težka {teza} kg, " +
                $"barva njenih oči je {barvaOci}, " +
                $"zaposlitveni status pa je {zaposlitveniStatus}.");

            // Če za podatke nimamo posebne sheme in so samo našteti,
            // lahko morebitna prazna polja (npr. dve zaporedni vejici brez znaka vmes še vedno
            // pomenita polje, vendar z vrednostjo "praznega" niza) izločimo
            // z uporabo lastnosti StringSplitOptions.RemoveEmptyEntries
            string abeceda = "  alfa,beta\tgama\tdelta,kappa,,,omega   ";
            abeceda = abeceda.Trim();
            Console.WriteLine(abeceda);

            // Določimo množico ločil
            char[] znaki = new char[] { ',', '\t' };
            // In zahtevajmo izločitev praznih polj
            string[] podatkiTab = abeceda.Split(znaki, StringSplitOptions.RemoveEmptyEntries);

            foreach (string podatek in podatkiTab)
            {
                Console.WriteLine(podatek);
            }

            string messi = "Messi";
            Console.WriteLine(messi.ToLower()); // Pretvorimo v male črke
            Console.WriteLine(messi.ToUpper()); // Pretvorimo v velike črke

            // Funkcija Substring
            string emso = "0101023500001";
            //Console.WriteLine(emso.Substring(4, 3));            
            int letoRojstva = int.Parse(emso.Substring(4, 3));

            // Nize lahko obravnavamo kot tabele znakov.
            // Po nizu se tako lahko sprehodimo z zanko foreach
            // in pregledamo vse njegove znake.
            foreach (char znak in emso)
            {
                Console.WriteLine(znak);
            }

            if (emso[4] == '0')
            {
                letoRojstva += 2000;
            }
            else
            {
                letoRojstva += 1000;
            }
            Console.WriteLine($"Leto rojstva: {letoRojstva}");

            // Izpis zadnjega znaka niza na dva načina:
            string kompliciranNiz = "aksfbweijnač,xpwqmxBLsnanč";
            char zadnjiZnak1 = kompliciranNiz[kompliciranNiz.Length - 1];
            string zadnjiZnak2 = kompliciranNiz.Substring(kompliciranNiz.Length - 1, 1);
            kompliciranNiz.IndexOf("wei");
        }

    }
}