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

        static void WritingInFiles()
        {
            StreamWriter swFile = new StreamWriter("Borut.txt", true);

            DateTime dtNow = DateTime.Now;
            swFile.WriteLine($"Zapis je bil ustvarjen: {dtNow.ToString("d. M. yyyy  HH:mm:ss")}");
            swFile.WriteLine("-1");
            swFile.WriteLine("Sončno");
            swFile.WriteLine("Malo pa sneži.");

            swFile.Close();
            Console.WriteLine("Zapisovanje v datoteko je končano!");
        }

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

            string noviPodatki = "  alfa,beta\tgama\tdelta,kappa,,,omega   ";
            noviPodatki = noviPodatki.Trim();
            Console.WriteLine(noviPodatki);

            char[] znaki = new char[] { ',', '\t' };
            string[] podatkiTab = noviPodatki.Split(znaki, StringSplitOptions.RemoveEmptyEntries);

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
        }

    }
}