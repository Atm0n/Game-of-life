using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Game_of_Life
{
    class Program
    {
        static void Main(string[] args)
        {
            Game hola = new Game();
            Console.WriteLine("Fes un enter per acabar, qualsevol tecla per continuar");// hola.TaulerRandom();
            Console.WriteLine(hola.TaulerSeguent());
            while (Console.ReadKey().KeyChar != 13)
            {
                Console.Clear();
                Console.WriteLine(hola.TaulerSeguent());
                Console.WriteLine(hola.Iteracio);
                hola.Seguent();
            }
            hola.GuardarEstat("fitxer.txt2");
            Console.WriteLine(hola.TaulerSeguent());
            Console.ReadKey();

        }
    }
    public class Game
    {
        #region atributs
        private static int iteracio = 0;
        private bool[,] tauler = {
                { false, false, false, false },
                { false, true, false, true },
                { false, false, true, false },
                { false, false, false, false } };
        #endregion
        #region propietats
        public int Iteracio
        {
            get { return iteracio; }
        }
        #endregion
        #region Constructors
        public Game()
        {

        }
        public bool[,] Tauler
        {
            set
            {
                tauler = value;
            }
            get
            {
                return tauler;
            }
        }
        public Game(string nomFitxer)
        {
            llegirTauler(Llegir(nomFitxer));
        }
        #endregion
        #region Mètodes
        public void EditarCasella(int x, int y, bool viu)
        {
            tauler[x, y] = viu;
        }
        public void GuardarEstat(string nom)
        {
            StreamWriter file2 = new StreamWriter(nom, true);
            string dades = string.Format("{0},{1};", tauler.GetLength(0), tauler.GetLength(1));
            file2.WriteLine(dades);
            for (int i = 0; i < tauler.GetLength(0); i++)
            {
                dades = "";
                for (int j = 0; j < tauler.GetLength(1); j++)
                {
                    if (tauler[i, j]) dades += '1';
                    else dades += '0';
                }
                file2.WriteLine(dades);
            }
            file2.Close();
        }
        public void TaulerRandom()
        {
            Random rnd = new Random();
            for (int i = 0; i < tauler.GetLength(0); i++)
            {
                for (int j = 0; j < tauler.GetLength(1); j++)
                {
                    if (rnd.Next(2) == 0) EditarCasella(i, j, false);
                    else EditarCasella(i, j, true);
                }
            }
        }
        public string Llegir(string nom)
        {
            string dades = File.ReadAllText(nom);
            return dades;
        }
        public void llegirTauler(string fitxer)
        {
            string[] dimensions = fitxer.Split(';')[0].Split(',');
            string array = fitxer.Split(';')[1];
            int i = 0;
            bool[,] dades = new bool[int.Parse(dimensions[0]), int.Parse(dimensions[1])];
            for (int j = 0; int.Parse(dimensions[0]) > j; j++)
            {
                for (int k = 0; int.Parse(dimensions[1]) > k; k++)
                {
                    while (!"01".Contains(array[i])) i++;
                    if ('1' == array[i])
                    {
                        dades[j, k] = true;
                    }
                    else
                    {
                        dades[j, k] = false;
                    }
                    i++;
                }
            }
            tauler = dades;
        }
        public bool Viu(int x, int y)
        {
            int veins = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if ((i != 0 && j != 0))
                    {
                        try
                        {
                            if (tauler[x + i, y + j] == true) veins++;
                        }
                        catch
                        {
                        }
                    }
                }
            }
            //if (tauler[x, y] && (veins == 2 || veins == 3))
            //{
            //    return true;
            //}

            if (tauler[x, y]&& (veins == 3 || veins == 2))
            {
                return true;
                
            }
            if (tauler[x, y] == false && veins == 3) return true;
            return false;
        }
        public void Seguent()
        {
            iteracio++;
            for (int i = 0; i < tauler.GetLength(0); i++)
            {
                for (int j = 0; j < tauler.GetLength(1); j++)
                {
                    if (Viu(i, j)) tauler[i, j] = true;
                    else tauler[i, j] = false;
                }
            }
        }
        public string TaulerSeguent()
        {
            string taulerText = "";
            for (int i = 0; i < tauler.GetLength(0); i++)
            {
                string temp = "";
                for (int j = 0; j < tauler.GetLength(1); j++)
                {
                    if (tauler[i, j] == true) temp += "X";
                    else temp += "·";
                }
                taulerText += "\n" + temp;
            }
            return taulerText;
        }
        #endregion
    }
}
