using System;
using System.Collections.Generic;

namespace Internship_2_C_Sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Odaberite akciju: ");

            var GlavniIzbornik = new Dictionary<int, string>
            {
                { 1, "Ispis stanovništva" },
                { 2, "Ispis stanovnika po OIB-u" },
                { 3, "Ispis OIB-a po unosu imena i prezimena te datuma rođenja" },
                { 4, "Unos novog stanovnika" },
                { 5, "Brisanje stanovnika unosom OIB-a" },
                { 6, "Brisanje stanovnika po imenu i prezimenu te datumu rođenja" },
                { 7, "Brisanje svih stanovnika" },
                { 8, "Uređivanje stanovnika" },
                { 9, "Statistika" },
                { 0, "Izlaz iz aplikacije" }
            };

            var Podizbornik1 = new Dictionary<int, string>
            {
                { 1, "Onako kako su spremljeni" },
                { 2, "Onako kako su spremljeni" },
                { 3, "Po datumu rođenja silazno" },
                { 0, "Povratak na glavni izbornik" }
            };

            var Podizbornik8 = new Dictionary<int, string>
            {
                { 1, "Uredi OIB stanovnika" },
                { 2, "Uredi ime i prezime stanovnika" },
                { 3, "Uredi datum rođenja" },
                { 0, "Povratak na glavni izbornik" }
            };

            var Podizbornik9 = new Dictionary<int, string>
            {
                { 1, "Postotak nezaposlenih (od 0 do 23 godine i od 65 do 100 godine) i postotak zaposlenih (od 23 do 65 godine)" },
                { 2, "Ispis najčešćeg imena i koliko ga stanovnika ima" },
                { 3, "Ispis najčešćeg prezimena i koliko ga stanovnika ima" },
                { 4, "Ispis datum na koji je rođen najveći broj ljudi i koji je to datum" },
                { 5, "Ispis broja ljudi rođenih u svakom od godišnjih doba" },
                { 6, "Ispis najmlađeg stanovnika" },
                { 7, "Ispis najstarijeg stanovnika" },
                { 8, "Prosječan broj godina" },
                { 9, "Medijan godina" },
                { 0, "Povratak na glavni izbornik" }
            };
        }
    }
}
