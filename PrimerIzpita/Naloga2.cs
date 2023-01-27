using System.Security.Cryptography;
using System.Text;

namespace PrimerIzpita
{
    /// <summary>
    /// NALOGA 2:
    /// V metodi ResitevNaloge imate pripravljena dva seznama.
    /// Prvi je seznam predmetov, drugi pa seznam vpisnih številk študentov.
    /// 
    /// Definirana sta tudi razreda Student in Predmet.
    /// 
    /// Za vsako vpisno številko pripravite instanco razreda Student,
    /// ki bo imel dano vpisno številko in seznam vseh petih predmetov,
    /// pri čemer za vsak predmet oceno izberete slučajno med ocenami
    /// od 6 do 10. [10 točk]
    /// 
    /// V razred Student dodajte metodo, ki izračuna in vrne povprečno oceno študenta. [5 točk]
    /// 
    /// Na koncu izpišite povprečno oceno študentov pri vsakem od predmetov. [10 točk]
    /// </summary>
    public class Naloga2
    {
        /// <summary>
        /// V tej metodi se začne izvajati program za reševanje Naloge 2
        /// </summary>
        public static void ResitevNaloge()
        {
            // *** KODE OD TUKAJ DO SPODNJE MEJE NE SPREMINJAJTE!

            // Seznam predmetov
            List<string> lstImenaPredmetov = new List<string>() 
            { 
                "Osnove programiranja",
                "Informacijski sistemi",
                "Internet stvari",
                "Industrijska avtomatizacija",
                "Kibernetska varnost"
            };

            // Seznam vpisnih številk študentov
            List<int> lstVpisneStevilke = new List<int>();
            for(int i=3530_001; i<=3530_100; i++)
            {
                lstVpisneStevilke.Add(i);
            }
            // *** KODE DO TUKAJ OD ZGORNJE MEJE NE SPREMINJAJTE!


        }
    }

    public class Student
    {
        public Student(int vpSt)
        {
            VpisnaStevilka = vpSt;
            Ocene = new List<Predmet>();
        }

        public int VpisnaStevilka { get; set; }

        public List<Predmet> Ocene { get; set; }
    }

    public class Predmet
    {
        public Predmet(string naziv, int ocena)
        {
            Naziv = naziv;
            Ocena = ocena;
        }

        public string Naziv { get; set; }
        public int Ocena { get; set; }
    }
}