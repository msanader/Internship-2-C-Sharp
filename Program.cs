using System;
using System.Collections.Generic;
using System.Linq;

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
                { 2, "Po datumu rođenja uzlazno" },
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
                { 1, "Postotak nezaposlenih i postotak zaposlenih" },
                { 2, "Ispis najčešćeg imena i koliko ga stanovnika ima" },
                { 3, "Ispis najčešćeg prezimena i koliko ga stanovnika ima" },
                { 4, "Ispis datum na koji je rođen najveći broj ljudi i koliko je stanovninka rođeno na taj dan" },
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

            while (VracanjeNaGlavniIzbornik)
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
                                Console.Clear();
                                var TrazenaOsoba1 = (nameAndSurname: "Nitko", dateOfBirth: new DateTime(2020, 1, 1));
                                foreach (KeyValuePair<string, (string nameAndSurname, DateTime dateOfBirth)> osoba in PopisStanovnika)
                                {
                                    TrazenaOsoba1 = osoba.Value;
                                    Console.WriteLine(TrazenaOsoba1.nameAndSurname);
                                }
                                break;
                            case 2:
                                Console.Clear();
                                foreach (KeyValuePair<string, (string nameAndSurname, DateTime dateOfBirth)> osoba in PopisStanovnika.OrderBy(p => p.Value.dateOfBirth))
                                {
                                    Console.WriteLine(osoba.Value.nameAndSurname);
                                }
                                break;
                            case 3:
                                Console.Clear();
                                foreach (KeyValuePair<string, (string nameAndSurname, DateTime dateOfBirth)> osoba in PopisStanovnika.OrderByDescending(p => p.Value.dateOfBirth))
                                {
                                    Console.WriteLine(osoba.Value.nameAndSurname);
                                }
                                break;
                            case 0:
                                Console.Clear();
                                break;
                            default:
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
                        var brojac = 0;

                        foreach (var osoba in PopisStanovnika)
                        {
                            if (osoba.Value == TrazenaOsoba)
                                brojac += 1;

                        }
                        switch (brojac)
                        {
                            case 0:
                                Console.WriteLine("Osoba koju tražite nije unesena u sustav!");
                                break;
                            default:
                                foreach (var osoba in PopisStanovnika)
                                {
                                    if (osoba.Value == TrazenaOsoba)
                                        Console.WriteLine(osoba.Key);
                                }
                                break;
                        }


                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Želite li potvrditi radnju? DA/NE");

                        var odgovor = -1;

                        do
                        {
                            var Potvrda = Console.ReadLine();
                            odgovor = PotvrdaRadnje(Potvrda);

                        } while (odgovor < 0);

                        if (odgovor == 0)
                            break;
                        else
                        {
                            Console.WriteLine("Unesite OIB osobe koju želite unijeti:");
                            var noviOIB = Console.ReadLine();

                            foreach (var osoba in PopisStanovnika)
                            {
                                if (noviOIB == osoba.Key)
                                    Console.WriteLine("Osoba je već popisana!");
                                break;
                            }

                            Console.WriteLine("Unesite ime i prezime:");
                            var novoImeIPrezime = Console.ReadLine();

                            Console.WriteLine("Unesite godinu, mjesec i dan rođenja (jedno ispod drugog)");
                            var novaGodina = int.Parse(Console.ReadLine());
                            var noviMjesec = int.Parse(Console.ReadLine());
                            var noviDan = int.Parse(Console.ReadLine());

                            PopisStanovnika.Add(noviOIB, (novoImeIPrezime, new DateTime(novaGodina, noviMjesec, noviDan)));
                        }

                        break;
                    case 5:

                        Console.Clear();
                        Console.WriteLine("Unesite OIB osobe koju želite izbrisati:");
                        var OIBZaIzbrisati = Console.ReadLine();

                        Console.WriteLine("Želite li potvrditi radnju? DA/NE");

                        odgovor = -1;

                        do
                        {
                            var Potvrda = Console.ReadLine();
                            odgovor = PotvrdaRadnje(Potvrda);

                        } while (odgovor < 0);

                        if (odgovor == 0)
                            break;
                        else
                        {
                            if (!PopisStanovnika.ContainsKey(OIBZaIzbrisati))
                                Console.WriteLine("Osoba koju želite izbrisati nije popisana!");

                            foreach (var osoba in PopisStanovnika)
                            {
                                if (OIBZaIzbrisati == osoba.Key)
                                    PopisStanovnika.Remove(OIBZaIzbrisati);

                            }

                        }
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("Unesi ime i prezime osobe koje želite izbrisati: ");

                        ImeIPrezime = Console.ReadLine();

                        Console.WriteLine("Unesi godinu, mjesec i dan rođenja (jedno ispod drugog) osobe koje želite izbrisati: ");
                        godina = int.Parse(Console.ReadLine());
                        mjesec = int.Parse(Console.ReadLine());
                        dan = int.Parse(Console.ReadLine());

                        TrazenaOsoba = (nameAndSurname: ImeIPrezime, dateOfBirth: new DateTime(godina, mjesec, dan));
                        brojac = 0;

                        Console.WriteLine("Želite li potvrditi radnju? DA/NE");

                        odgovor = -1;

                        do
                        {
                            var Potvrda = Console.ReadLine();
                            odgovor = PotvrdaRadnje(Potvrda);

                        } while (odgovor < 0);

                        if (odgovor > 0)
                        {
                            foreach (var osoba in PopisStanovnika)
                            {
                                if (TrazenaOsoba == osoba.Value)
                                    brojac += 1;

                            }


                            switch (brojac)
                            {
                                case 1:
                                    foreach (var osoba in PopisStanovnika)
                                    {
                                        if (TrazenaOsoba == osoba.Value)
                                            PopisStanovnika.Remove(osoba.Key);
                                    }
                                    break;
                                case 0:
                                    Console.WriteLine("Osoba koju želite izbrisati nije popisana!");
                                    break;

                                default:
                                    Console.WriteLine("Ima više osoba s tim imenom. Unesite OIB osobe koje želite izbrisati:");

                                    foreach (var osoba in PopisStanovnika)
                                    {
                                        if (TrazenaOsoba == osoba.Value)
                                            Console.WriteLine(osoba.Key + " " + TrazenaOsoba.nameAndSurname);
                                    }

                                    OIBZaIzbrisati = Console.ReadLine();
                                    if (PopisStanovnika.ContainsKey(OIBZaIzbrisati))
                                        PopisStanovnika.Remove(OIBZaIzbrisati);
                                    else
                                        Console.WriteLine("Niste unijeli točan OIB");
                                    break;

                            }
                        }
                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine("Želite li potvrditi radnju? DA/NE");

                        odgovor = -1;

                        do
                        {
                            var Potvrda = Console.ReadLine();
                            odgovor = PotvrdaRadnje(Potvrda);

                        } while (odgovor < 0);

                        if (odgovor == 1)
                            foreach (var osoba in PopisStanovnika)
                            {
                                PopisStanovnika.Remove(osoba.Key);
                            }
                        else
                            break;
                        break;
                    case 8:
                        Console.Clear();
                        foreach (var izbor in Podizbornik8)
                            Console.WriteLine(izbor.Key + " " + izbor.Value);

                        DodatniUnos = Console.ReadLine();
                        IducaOdabranaAkcija = ProvjeraUnosa(DodatniUnos);

                        switch (IducaOdabranaAkcija)
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("Želite li potvrditi radnju? DA/NE");

                                odgovor = -1;

                                do
                                {
                                    var Potvrda = Console.ReadLine();
                                    odgovor = PotvrdaRadnje(Potvrda);

                                } while (odgovor < 0);

                                if (odgovor == 1)
                                {
                                    Console.WriteLine("Unesite OIB osobe na kojoj želiti izvršiti promjene: ");
                                    OIB = Console.ReadLine();

                                    Console.WriteLine("Unesite novi OIB: ");
                                    var noviOIB = Console.ReadLine();
                                    var OsobaZaPromjene = (nameAndSurname: "Neko ime", dateOfBirth: new DateTime(1000, 10, 10));

                                    foreach (var osoba in PopisStanovnika)
                                    {
                                        if (OIB == osoba.Key)
                                            OsobaZaPromjene = osoba.Value;

                                    }

                                    PopisStanovnika.Remove(OIB);
                                    PopisStanovnika.Add(noviOIB, OsobaZaPromjene);
                                }
                                else
                                    break;

                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Želite li potvrditi radnju? DA/NE");

                                odgovor = -1;

                                do
                                {
                                    var Potvrda = Console.ReadLine();
                                    odgovor = PotvrdaRadnje(Potvrda);

                                } while (odgovor < 0);

                                if (odgovor == 1)
                                {
                                    Console.WriteLine("Unesite OIB osobe na kojoj želiti izvršiti promjene: ");
                                    OIB = Console.ReadLine();

                                    Console.WriteLine("Unesite novi ime i prezime: ");
                                    var novoImeIPrezime = Console.ReadLine();
                                    var OsobaZaPromjene = (nameAndSurname: "Neko ime", dateOfBirth: new DateTime(1000, 10, 10));
                                    var datum1 = new DateTime();

                                    foreach (var osoba in PopisStanovnika)
                                    {
                                        if (OIB == osoba.Key)
                                            OsobaZaPromjene = osoba.Value;
                                        datum1 = OsobaZaPromjene.dateOfBirth;
                                        OsobaZaPromjene = (novoImeIPrezime, datum1);
                                    }

                                    PopisStanovnika.Remove(OIB);
                                    PopisStanovnika.Add(OIB, OsobaZaPromjene);

                                }
                                else
                                    break;

                                break;
                            case 3:
                                Console.Clear();
                                Console.WriteLine("Želite li potvrditi radnju? DA/NE");

                                odgovor = -1;

                                do
                                {
                                    var Potvrda = Console.ReadLine();
                                    odgovor = PotvrdaRadnje(Potvrda);

                                } while (odgovor < 0);

                                if (odgovor == 1)
                                {
                                    Console.WriteLine("Unesite OIB osobe na kojoj želiti izvršiti promjene: ");
                                    OIB = Console.ReadLine();

                                    Console.WriteLine("Unesite novi datum (godinu, mjesec i dan rođenja jedno ispod drugog): ");
                                    godina = int.Parse(Console.ReadLine());
                                    mjesec = int.Parse(Console.ReadLine());
                                    dan = int.Parse(Console.ReadLine());
                                    var datum = new DateTime(godina, mjesec, dan);
                                    var OsobaZaPromjene1 = (nameAndSurname: "Neko ime", dateOfBirth: new DateTime(1000, 10, 10));
                                    ImeIPrezime = "";

                                    foreach (var osoba in PopisStanovnika)
                                    {
                                        if (OIB == osoba.Key)
                                            OsobaZaPromjene1 = osoba.Value;
                                        ImeIPrezime = OsobaZaPromjene1.nameAndSurname;
                                        OsobaZaPromjene1 = (ImeIPrezime, datum);
                                    }

                                    PopisStanovnika.Remove(OIB);
                                    PopisStanovnika.Add(OIB, OsobaZaPromjene1);
                                }
                                else
                                    break;
                                break;

                            case 0:
                                Console.Clear();
                                break;
                            default:
                                break;
                        }
                        break;
                    case 9:
                        Console.Clear();
                        foreach (var izbor in Podizbornik9)
                            Console.WriteLine(izbor.Key + " " + izbor.Value);

                        DodatniUnos = Console.ReadLine();
                        IducaOdabranaAkcija = ProvjeraUnosa(DodatniUnos);

                        switch (IducaOdabranaAkcija)
                        {
                            case 1:
                                Console.Clear();

                                List<Double> udio = UdioZaposlenosti(PopisStanovnika);
                                Console.WriteLine(udio[0] + "% je zaposlenih, a " + udio[1] + "% nezaposlenih.");

                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine(NajcesceIme(PopisStanovnika));
                                break;
                            case 3:
                                Console.Clear();
                                Console.WriteLine(NajcescePrezime(PopisStanovnika));
                                break;
                            case 4:
                                Console.Clear();
                                Console.WriteLine(NajcesciDatum(PopisStanovnika));
                                break;
                            case 5:
                                Console.Clear();
                            
                                var Podatci = new List<(string godisnjeDoba, int brojStanovnika)>();
                                Podatci = GodisnjaDoba(PopisStanovnika);
                                Podatci = SortTuplesByItem2(Podatci);

                                foreach (var podatak in Podatci)
                                {
                                    Console.WriteLine(podatak.godisnjeDoba + " " + podatak.brojStanovnika);
                                }

                                break;
                            case 6:
                                Console.Clear();
                                Console.WriteLine("Najmlađi stanovnik je " + NajmladiStanovnik(PopisStanovnika) + ".");
                                break;
                            case 7:
                                Console.Clear();
                                Console.WriteLine("Najstariji stanovnik je " + NajstarijiStanovnik(PopisStanovnika) + ".");
                                break;
                            case 8:
                                Console.Clear();
                                Console.WriteLine(ProsjekGodina(PopisStanovnika));
                                break;
                            case 9:
                                Console.Clear();
                                Console.WriteLine(Medijan(PopisStanovnika));
                                break;
                            case 0:
                                Console.Clear();
                                break;
                            default:
                                break;
                        }
                        break;
                    case 0:
                        Console.Clear();
                        VracanjeNaGlavniIzbornik = false;
                        break;
                    default:
                        break;


                }

            }


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
        static int PotvrdaRadnje(string Unos)
        {
            switch (Unos)
            {
                case "DA":
                    return 1;
                case "NE":
                    return 0;
                default:
                    Console.WriteLine("Niste ispravno unijeli. Pokušajte ponovo!");
                    return -1;
            }
        }
        static double ProsjekGodina(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> PopisStanovnika)
        {
            var Godine = new List<int>();

            foreach (var osoba in PopisStanovnika)
            {
                Godine.Add(2021 - osoba.Value.dateOfBirth.Year);

            }

            double brojac = 0;

            for (var i = 0; i < Godine.Count; i++)
            {
                brojac += Godine[i];
            }

            double prosjek = brojac / Godine.Count;
            prosjek = Math.Round(prosjek, 2);

            return prosjek;

        }
        static int Medijan(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> PopisStanovnika)
        {
            var Godine = new List<int>();

            foreach (var osoba in PopisStanovnika)
            {
                Godine.Add(2021 - osoba.Value.dateOfBirth.Year);

            }

            Godine.Sort();

            if (Godine.Count % 2 == 1)
                return Godine[(Godine.Count - 1) / 2];
            else
                return Godine[(Godine.Count - 2) / 2];

        }
        static List<double> UdioZaposlenosti(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> PopisStanovnika)
        {
            var Godine = new List<int>();

            foreach (var osoba in PopisStanovnika)
            {
                Godine.Add(2021 - osoba.Value.dateOfBirth.Year);

            }

            double zaposleni = 0;

            for (var i = 0; i < Godine.Count; i++)
            {
                if (Godine[i] >= 23 && Godine[i] <= 65)
                    zaposleni += 1;
            }

            var udio = new List<double>();
            udio.Add(Math.Round((zaposleni / Godine.Count) * 100, 2));
            udio.Add(Math.Round(100 - udio[0], 2));

            return udio;

        }
        static string NajcesceIme(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> PopisStanovnika)
        {
            var ime = new List<string>();

            foreach (var osoba in PopisStanovnika)
            {

                var pomocna = (osoba.Value.nameAndSurname);
                string[] ImeIPrezime = pomocna.Split(" ");
                ime.Add(ImeIPrezime[0]);

            }
            var najcesceIme = (from i in ime
                               group i by i into grp
                               orderby grp.Count() descending
                               select grp.Key).First();
            var koliko = 0;

            foreach (var osoba in ime)
            {
                if (najcesceIme == osoba)
                    koliko += 1;
            }
            string rezultat;

            if (koliko > 1)
                rezultat = najcesceIme + " " + koliko;
            else
                rezultat = "Nema najčešćeg imena!";

            return rezultat;
        }
        static string NajcescePrezime(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> PopisStanovnika)
        {
            var prezime = new List<string>();

            foreach (var osoba in PopisStanovnika)
            {

                var pomocna = (osoba.Value.nameAndSurname);
                string[] ImeIPrezime = pomocna.Split(" ");
                prezime.Add(ImeIPrezime[1]);

            }
            var najcescePrezime = (from i in prezime
                                   group i by i into grp
                                   orderby grp.Count() descending
                                   select grp.Key).First();
            var koliko = 0;

            foreach (var osoba in prezime)
            {
                if (najcescePrezime == osoba)
                    koliko += 1;
            }
            string rezultat;

            if (koliko > 1)
                rezultat = najcescePrezime + " " + koliko;
            else
                rezultat = "Nema najčešćeg prezimena!";

            return rezultat;
        }
        static string NajcesciDatum(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> PopisStanovnika)
        {
            var datum = new List<DateTime>();

            foreach (var osoba in PopisStanovnika)
            {
                datum.Add(osoba.Value.dateOfBirth);

            }

            var najcesciDatum = (from i in datum
                                 group i by i into grp
                                 orderby grp.Count() descending
                                 select grp.Key).First();
            var koliko = 0;

            foreach (var osoba in datum)
            {
                if (najcesciDatum == osoba)
                    koliko += 1;
            }
            string rezultat;

            if (koliko > 1)
                rezultat = najcesciDatum.Day + "." + najcesciDatum.Month + "." + najcesciDatum.Year + "." + " " + koliko;
            else
                rezultat = "Nema najčešćeg datuma rođenja!";

            return rezultat;
        }
        static string NajmladiStanovnik(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> PopisStanovnika)
        {
            var stanovnici = new List<string>();

            foreach (KeyValuePair<string, (string nameAndSurname, DateTime dateOfBirth)> osoba in PopisStanovnika.OrderByDescending(p => p.Value.dateOfBirth))
            {
                stanovnici.Add(osoba.Value.nameAndSurname);
            }

            return stanovnici[0];
        }
        static string NajstarijiStanovnik(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> PopisStanovnika)
        {
            var stanovnici = new List<string>();

            foreach (KeyValuePair<string, (string nameAndSurname, DateTime dateOfBirth)> osoba in PopisStanovnika.OrderBy(p => p.Value.dateOfBirth))
            {
                stanovnici.Add(osoba.Value.nameAndSurname);
            }

            return stanovnici[0];
        }
        static List<(string godisnjeDoba, int brojStanovnika)> GodisnjaDoba(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> PopisStanovnika)
        {
            var zima = 0;
            var proljece = 0;
            var ljeto = 0;
            var jesen = 0;

            foreach (var osoba in PopisStanovnika)
            {
                var pomocna = osoba.Value;
                var datum = pomocna.dateOfBirth;

                if ((datum.DayOfYear >= 80) && (datum.DayOfYear < 172))
                    proljece += 1;
                else if ((datum.DayOfYear >= 172) && (datum.DayOfYear < 266))
                    ljeto += 1;
                else if ((datum.DayOfYear >= 266) && (datum.DayOfYear < 355))
                    jesen += 1;
                else if ((datum.DayOfYear >= 355) || (datum.DayOfYear < 80))
                    zima += 1;
            }

            var Podatci = new List<(string godisnjeDoba, int brojStanovnika)>();
            Podatci.Add(("Zima", zima));
            Podatci.Add(("Proljeće", proljece));
            Podatci.Add(("Ljeto", ljeto));
            Podatci.Add(("Jesen", jesen));


            return Podatci;
        }
        static List<(string godisnjeDoba, int brojStanovnika)> SortTuplesByItem2(List<(string godisnjeDoba, int brojStanovnika)> Podatci)
        {
            var brojke = new List<int>();
            var doba = (godisnjeDoba: "", brojStanovnika: 0);
            var konacnaLista = new List<(string godisnjeDoba, int brojStanovnika)>();


            foreach (var godisnjeDoba in Podatci)
            {
                brojke.Add(godisnjeDoba.brojStanovnika);
            }

            brojke.Sort();

            foreach (var podatak in Podatci)
            {
                for (var i = 0; i < Podatci.Count; i++)
                {
                    if (brojke[i] == podatak.brojStanovnika)
                        doba = (godisnjeDoba: podatak.godisnjeDoba, brojStanovnika: brojke[i]);
                }
                konacnaLista.Add(doba);
            }
            return konacnaLista;
        }
    }
}



