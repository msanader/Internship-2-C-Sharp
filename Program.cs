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

            while(VracanjeNaGlavniIzbornik)
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
                        var brojac = 0;

                        foreach (var osoba in PopisStanovnika)
                        {
                            if (osoba.Value == TrazenaOsoba)
                                brojac += 1;
                            Console.WriteLine(osoba.Key);
                            
                        }

                        if (brojac == 0)
                            Console.WriteLine("Osoba koju tražite nije unesena u sustav!");

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
                            Console.WriteLine(brojac);

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

                    case 0:
                        VracanjeNaGlavniIzbornik = false;
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
         
    }
}
    
