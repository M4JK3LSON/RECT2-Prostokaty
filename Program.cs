using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RECT2___Prostokąty
{

    class Program
    {
        public static bool mniejsze(int x1, int x2)
        {
            if (x1 < x2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool wieksze(int x1,int x2)
        {
            if (x1 > x2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void Main(string[] args)
        {
            int ndg = 0;
            int ndd = 0;
            int nwp = 0;
            int nwl = 0;
            int rw = 0;
            int rd = 0;
           // Console.WriteLine("Podaj liczbe testow");
            int test = int.Parse(Console.ReadLine());
            for(int i = 0; i < test; i++)
            {
                //Console.WriteLine("Podaj liczbe prostokatow dla testu " + (i + 1));
                int lp = int.Parse(Console.ReadLine());
                Prostokaty[] zbiorProstokatow = new Prostokaty[lp];
                for(int j = 0; j < lp; j++)
                {
                    string wspolrzedneStr = Console.ReadLine();

                    string[] wspolrzedneSplit = wspolrzedneStr.Split(' ');

                    int x1 = int.Parse(wspolrzedneSplit[0]);
                    int y1 = int.Parse(wspolrzedneSplit[1]);
                    int x2 = int.Parse(wspolrzedneSplit[2]);
                    int y2 = int.Parse(wspolrzedneSplit[3]);
                    if (j == 0)
                    {
                        if (y1 > y2)
                        {
                            ndg = y1;
                            ndd = y2;
                        }
                        else
                        {
                            ndg = y2;
                            ndd = y1;
                        }
                        if (x1 > x2)
                        {
                            nwp = x1;
                            nwl = x2;
                        }
                        else
                        {
                            nwp = x2;
                            nwl = x1;
                        }
                    }
                    else
                    {
                        if (wieksze(x1, x2))
                        {
                            if (wieksze(x1, nwp))
                            {
                                nwp = x1;
                            }
                            if (mniejsze(x2, nwl))
                            {
                                nwl = x2;
                            }
                        }
                        else
                        {
                            if (wieksze(x2, nwp))
                            {
                                nwp = x2;
                            }
                            if (mniejsze(x1, nwl))
                            {
                                nwl = x1;
                            }
                        }


                        if (wieksze(y1, y2))
                        {
                            if (wieksze(y1, ndg))
                            {
                                ndg = y1;
                            }
                            if (mniejsze(y2, ndd))
                            {
                                ndd = y2;
                            }
                        }
                        else
                        {
                            if (wieksze(y2, ndg))
                            {
                                nwp = y2;
                            }
                            if (mniejsze(y1, ndd))
                            {
                                ndd = y1;
                            }
                        }
                    }

                    
                    zbiorProstokatow[j] = new Prostokaty(x1, y1, x2, y2);
                   


                }
                rd = nwp - nwl;
                rw = ndg - ndd;
                if (lp == 1)
                {
                   
                    ulong lczarnych = (ulong)rd *(ulong)rw;
                    Console.WriteLine("Liczba czarnych kwadracikow wynosi = " + lczarnych);
                }
                else
                {


                    // Console.WriteLine("NDG= {0} | NWP={1} | NDD={2} | NWL={3} | RW={4} | RD={5}", ndg, nwp, ndd, nwl,rw,rd);

                    byte[,] tabliczka = new byte[rw, rd];


                    for (int k = 0; k < rw; k++) //Wypełnianie "BIAŁYM"
                    {
                        for (int m = 0; m < rd; m++)
                        {
                            tabliczka[k, m] = 0;
                        }
                        //  Console.WriteLine();
                    }


                    for (int n = 0; n < lp; n++)
                    {
                        // Console.WriteLine("PROSTOKAT: " + n + 1);
                        for (int p = 0; p < rw; p++)
                        {
                            for (int r = 0; r < rd; r++)
                            {
                                int rwysokosciodgory = Math.Abs(ndg - zbiorProstokatow[n].wyzszy_y);
                                int rwysokoscioddolu = Math.Abs(ndd - zbiorProstokatow[n].mniejszy_y);
                                int rodlewej = Math.Abs(nwl - zbiorProstokatow[n].mniejszy_x);
                                int rodprawej = Math.Abs(nwp - zbiorProstokatow[n].wyzszy_x);

                                int gornyindeks = 0 + rwysokosciodgory;
                                int dolnyindeks = rw - rwysokoscioddolu - 1;
                                int lewyindeks = 0 + rodlewej;
                                int prawyindeks = rd - rodprawej - 1;
                                // Console.WriteLine("Komórka[{0},{1}]:", p, r);
                                // Console.WriteLine("Roznica od gory:{0} | Roznica od dolu:{1} | Roznica od lewej:{2} | Roznica od prawej:{3}", rwysokosciodgory, rwysokoscioddolu, rodlewej, rodprawej);
                                // Console.WriteLine("Gorny indeks:{0} | Dolny indeks:{1} | Lewy indeks:{2} | Prawy indeks:{3}", gornyindeks, dolnyindeks, lewyindeks, prawyindeks);

                                if ((p >= gornyindeks && p <= dolnyindeks) && (r >= lewyindeks && r <= prawyindeks))
                                {

                                    if (tabliczka[p, r] == 0)
                                    {
                                        tabliczka[p, r] = 1;
                                    }
                                    else
                                    {
                                        tabliczka[p, r] = 0;
                                    }
                                }
                            }

                        }


                    }
                    int lc = 0;
                    for (int s = 0; s < rw; s++)
                    {
                        for (int t = 0; t < rd; t++)
                        {
                            if (tabliczka[s, t] == 1)
                            {
                                //  Console.WriteLine(s + " " + t);
                                lc++;
                            }
                        }
                    }

                    Console.WriteLine("Liczba czarnych kwadracikow wynosi = " + lc);

                }


            }
            
            Console.ReadKey();
        }
    }
}
