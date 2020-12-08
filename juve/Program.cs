using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace juve
{
    
    class Program
    {
        struct Juventus
        {
            public int Mez;
            public string Nev;
            public string Nemzet;
            public string Poszt;
            public int Szulev;

            public Juventus(string sor)
            {
                var t = sor.Split(';');
                Mez = int.Parse(t[0]);
                Nev = t[1];
                Nemzet = t[2];
                Poszt = t[3];
                Szulev = int.Parse(t[4]);
            }
        }
        static void Main(string[] args)
        {
            Beolvasas();
            F01();
            F02();
            F03();
            F04();
            F05();
            F06();
            F07();
            F08();
            F11();
            F22();
            Console.ReadKey(true);
        }

        private static void F07()
        {
            int szulev = int.MaxValue;
            foreach (var i in jatekosok)
            {

                if (i.Poszt=="csatár")
                {
                    if (i.Szulev<szulev)
                    {
                        szulev = i.Szulev;
                    }

                }
                if (i.Szulev==szulev)
                {
                    Console.WriteLine($"{i.Nev} a legidősebb csatár");
                }
            }
            

            
        }

        private static void F22()
        {
            StreamWriter sw = new StreamWriter(@"..\..\Res\hatvedek.txt");
            foreach (var u in jatekosok)
            {
                var f = u.Nev.Split(' ');
                if (u.Poszt == "hátvéd")
                {
                    sw.WriteLine($"{f[1]}\t\t{2020 - u.Szulev}");
                }
                
            
                
            }
            sw.Close();
            Console.WriteLine("fájlbaírás kész");
        }

        private static void F11()
        {
            Console.WriteLine("Adj meg egy mezszámot: ");
            int mezszam = Convert.ToInt32(Console.ReadLine());
            foreach (var i in jatekosok)
            {
                if (i.Mez==mezszam)
                {
                    Console.WriteLine($"a {i.Mez} számú mezet {i.Nev} viseli");
                }
            }
        }

        private static void F08()
        {
            var dic = new Dictionary<int, int>();
            foreach (var i in jatekosok)
            {
                if (!dic.Keys.Contains(i.Szulev))
                {
                    dic.Add(i.Szulev, 1);
                }
                else
                {
                    dic[i.Szulev]++;
                }
            }
            foreach (var item in dic)
            {
                if (item.Value==3)
                {
                    Console.WriteLine($"{item.Key} évben született pontosan 3 játékos");
                }
            }


        }

        private static void F06()
        {

            var dic = new Dictionary<string, int>();

            foreach (var i in jatekosok)
            {
                if (!dic.Keys.Contains(i.Poszt))
                {
                    dic.Add(i.Poszt, 1);
                }
                else
                {
                    dic[i.Poszt]++;
                }
            }
            foreach (var i in dic)
            {
                Console.WriteLine($"{i.Key}: {i.Value}");
            }
            
        }

        private static void F05()
        {
            int eletkor = 0;
            foreach (var i in jatekosok)
            {
                eletkor += 2020 - i.Szulev;
            }
            Console.WriteLine($"átlag életkor: {eletkor/jatekosok.Count}");
        }

        private static void F04()
        {
            int szulev = 0;
            foreach (var i in jatekosok)
            {

                if (i.Szulev > szulev)
                {
                    szulev = i.Szulev;
                }
            }
            foreach (var i in jatekosok)
            {
                if (i.Szulev == szulev)
                {
                    Console.WriteLine($"{i.Nev} a legfiatalabb játékos");
                }
            }
        }

        private static void F03()
        {
            int olasz = 0;
            foreach (var i in jatekosok)
            {
                if (i.Nemzet=="olasz")
                {
                    olasz++;
                }
            }
            Console.WriteLine($"{olasz} olasz játékos van a csapatban");
        }

        private static void F02()
        {
            bool magyar = false;
            foreach (var i in jatekosok)
            {
                if (i.Nemzet.Contains("magyar"))
                {
                    magyar = true;
                }
            }
            if (magyar)
            {
                Console.WriteLine("Van benne magyar játékos");
            }
            else
            {
                Console.WriteLine("nincs benne magyar játékos");
            }
        }

        private static void F01()
        {
            Console.WriteLine($"Ennyi igazolt játékosa van a csapatnak: {jatekosok.Count()}");
        }

        static List<Juventus> jatekosok = new List<Juventus>();
        private static void Beolvasas()
        {
            StreamReader sr = new StreamReader(@"..\..\Res\juve.txt");

            while (!sr.EndOfStream)
            {
                jatekosok.Add(new Juventus(sr.ReadLine()));
            }
            sr.Close();
        }
    }
}
