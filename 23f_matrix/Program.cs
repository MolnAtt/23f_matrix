using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23f_matrix
{
	internal class Program
	{
		static void Kiir(int[,] m, int N, int M)
		{
			for (int i = 0; i < N; i++)
			{
				for (int j = 0; j < M; j++)
				{
					Console.Write(m[i, j]);
					Console.Write("\t"); // "elem vége"
				}
				Console.WriteLine(); // sor vége
			}
			// mátrix vége
		}

		static void Szűkösen_Kiir(int[,] m, int N, int M)
		{
			for (int i = 0; i < N; i++)
			{
				for (int j = 0; j < M; j++)
				{
					if (0 <= m[i, j] && m[i, j] < 10)
					{
						Console.Write(" ");
					}

					if (80 <= m[i,j])
					{
						Console.ForegroundColor = ConsoleColor.Red;
					} else if (m[i, j] < 10)
					{
						Console.ForegroundColor = ConsoleColor.Blue;
					}
					Console.Write(m[i, j]);

					Console.ResetColor();


					Console.Write(" "); // "elem vége"
				}
				Console.WriteLine(); // sor vége
			}
			// mátrix vége
		}
		static (int, int, int[,]) Beolvas(string fajlnev)
		{
			int[,] m;
			int N;
			int M;
			using (StreamReader f = new StreamReader(fajlnev,Encoding.Default))
			{
				string sor = f.ReadLine();
				string[] sortomb =  sor.Split('\t');
				N = int.Parse(sortomb[0]);
				M = int.Parse(sortomb[1]);
				m = new int[N, M];
				for (int i = 0; i < N; i++)
				{
					sor = f.ReadLine();
					sortomb = sor.Split('\t');
					for (int j = 0; j < M; j++)
					{
						m[i,j] = int.Parse(sortomb[j]);
					}
				}
			}
			return (N, M, m);
		}
		private static int Legkisebb_ertek(int[,] terkep, int N, int M)
		{
			int legkisebb_ertek = terkep[0, 0];
			for (int i = 0; i < N; i++)
			{
				for (int j = 0; j < M; j++)
				{
					if (terkep[i, j] < legkisebb_ertek)
					{
						legkisebb_ertek = terkep[i, j];
					}
				}
			}
			return legkisebb_ertek;
		}
		static void Main(string[] args)
		{
			// hogyan lehet mátrixot létrehozni?
			// 1. Listában a lista
			List<List<int>> listaban_a_lista = new List<List<int>>();
			// 2. Listában a tömb
			List<int[]> listaban_a_tomb = new List<int[]>();
			listaban_a_tomb.Add(new int[19]);
			// 3. Tömbben a lista -- meg kell mondani, hogy hány lista lesz benne!
			List<int>[] tombben_a_lista = new List<int>[17];
			// 4. Tömbben a tömb -- ezt javasoljuk leginkább fix méretű mátrixokra!
			int[][] tombben_a_tomb = new int[16][]; // érettségin ezt javaslom!
			// C#-ban van beépített mátrixfogalom:
			int[,] matrix = new int[1000, 24];

			int[] tomb = new int[8];

			Console.WriteLine(tomb[4]); // az int default értéke a 0. 

			Console.WriteLine(matrix[4,5]); // 4. sor 5. eleme! Megint: a default érték 0. 

			// minden elemet írjunk át 1-esre.
			// minden sor minden oszlopa legyen 1!
			for (int i = 0; i < 1000; i++) // minden sor
			{
				for (int j = 0; j < 24; j++) // minden oszlopán
				{
					matrix[i, j] = 1;
				}
			}

			// Írjuk ki a mátrixot!
			//Kiir(matrix, 1000, 24);

			Console.ForegroundColor = ConsoleColor.Green; // mostantól minden zöld!
            Console.WriteLine("ez zöld!");
			Console.ForegroundColor = ConsoleColor.White; // mostantól minden fehér!
			Console.WriteLine("ez újra fehér");

			(int N, int M, int[,] terkep) = Beolvas("terkep.tsv");

			Szűkösen_Kiir(terkep, N, M);

			int legkisebb_ertek = Legkisebb_ertek(terkep, N, M);

            Console.WriteLine(legkisebb_ertek);

			int vizes_terulet_merete = VizesTeruletMerete(terkep, N, M);
            Console.WriteLine(vizes_terulet_merete);

			bool vane = Van_e_efolotti(terkep, N, M , 90);
            Console.WriteLine(vane);
        }

		private static bool Van_e_efolotti(int[,] terkep, int n, int m, int ennel)
		{
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < m; j++)
				{
					if (ennel < terkep[i, j])
					{
						return true;
					}
				}
			}
			return false;
		}

		private static (int,int) Elso_negativ(int[,] terkep, int n, int m)
		{
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < m; j++)
				{
					if (terkep[i, j]<0)
					{
						return (i,j);
					}
				}
			}
			return (-1,-1);
		}

		private static int VizesTeruletMerete(int[,] terkep, int N, int M)
		{
			int db = 0;
			for (int i = 0; i < N; i++)
			{
				for (int j = 0; j < M; j++)
				{
					if (terkep[i,j]<10)
					{
						db++;
					}
				}
			}
			return db;
		}
	}
}
