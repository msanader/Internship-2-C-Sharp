using System;
using System.Collections.Generic;

namespace Internship_2_C_Sharp
{
    class Program
    {
        static void Main(string[] args)
        {
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

            var PopisStanovnika = new Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)>()
            {
                { "12345678901", ("Mirna Sanader", new DateTime(2003, 8, 19)) },
                { "01234567891", ("Anita Sanader", new DateTime(2001, 2, 11)) },
                { "00123456789", ("Silvana Sanader", new DateTime(1965, 1, 28)) }
            };


            var VracanjeNaGlavniIzbornik = true;

            do
            {
                Console.WriteLine("Odaberite akciju: ");

                foreach (var izbor in GlavniIzbornik)
                    Console.WriteLine(izbor.Key + " " + izbor.Value);

                var Unos = Console.ReadLine();
                var OdabranaAkcija = ProvjeraUnosa(Unos);


                switch (OdabranaAkcija)
                {
                    case 1:
                        Console.Clear();
                        foreach (var izbor in Podizbornik1)
                            Console.WriteLine(izbor.Key + " " + izbor.Value);

                        var DodatniUnos = Console.ReadLine();
                        var IducaOdabranaAkcija = ProvjeraUnosa(DodatniUnos);

                        switch (IducaOdabranaAkcija)
                        {
                            case 1:
                                var TrazenaOsoba1 = (nameAndSurname: "Nitko", dateOfBirth: new DateTime(2020, 1, 1));
                                foreach (KeyValuePair<string, (string nameAndSurname, DateTime dateOfBirth)> osoba in PopisStanovnika)
                                {
                                    TrazenaOsoba1 = osoba.Value;
                                    Console.WriteLine(TrazenaOsoba1.nameAndSurname);
                                }
                                break;
                            case 2:
                                break;
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Unesi OIB:");

                        var OIB = Console.ReadLine();
                        Console.WriteLine(PretragaPoOIBU(OIB, PopisStanovnika));
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Unesi ime i prezime: ");

                        var ImeIPrezime = Console.ReadLine();

                        Console.WriteLine("Unesi godinu, mjesec i dan rođenja (jedno ispod drugog): ");
                        var godina = int.Parse(Console.ReadLine());
                        var mjesec = int.Parse(Console.ReadLine());
                        var dan = int.Parse(Console.ReadLine());

                        var TrazenaOsoba = (nameAndSurname: ImeIPrezime, dateOfBirth: new DateTime(godina, mjesec, dan));

                        foreach(var osoba in PopisStanovnika)
                        {
                            if (osoba.Value == TrazenaOsoba)
                                Console.WriteLine(osoba.Key);
                        }
                        break;
    


                }

            } while (VracanjeNaGlavniIzbornik = true);








        }
        static int ProvjeraUnosa(string Unos)
        {
            var KriviUnos = -1;
            var PokusajOdabraneAkcije = int.TryParse(Unos, out KriviUnos);


            if (!PokusajOdabraneAkcije)
                return KriviUnos;
            else
                return int.Parse(Unos);
        }
        static string PretragaPoOIBU(string OIB, Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> PopisStanovnika)
        {
            var TrazenaOsoba = (nameAndSurname: "Osoba nije unesena u sustav", dateOfBirth: new DateTime(2000, 1, 1));

            foreach (var osoba in PopisStanovnika)
            {
                if (osoba.Key == OIB)
                    TrazenaOsoba = (osoba.Value);
            }
            return TrazenaOsoba.nameAndSurname;
        }
        /////static Array SortiraniDatumi(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> PopisStanovnika)
        /////{
        /////    var Datumi = new List<DateTime>();
        //    var TrazenaOsoba = (nameAndSurname: "None", dateOfBirth: new DateTime(2000, 1, 1));

        //    foreach (var osoba in PopisStanovnika)
        //    {
        //        TrazenaOsoba = osoba.Value;
        //        Datumi.Add(TrazenaOsoba.dateOfBirth);
        //    }

        //    var SortiraniDatumi = new List<DateTime>();
        ////    var datum = Datumi[0];
        //}
    }   
}
