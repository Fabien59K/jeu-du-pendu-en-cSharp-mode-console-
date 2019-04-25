using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDuPendu
{
    class Program
    {
        static List<string> listeMots = new List<string>() { "Proteine", "Myope", "Battre", "Cassette", "Embrasser", "Albinos", "Squelette", "Noir",
                "Code", "Rivet", "Sueur", "Obscurite", "Sauvage", "Cereale", "Guirlande", "Seance", "Peruvien", "Siphon", "Afrique", "Divorce", "Mariage",
                "Ordinateur", "Telephone", "Tableau", "Programmation", "Stylo", "Cafetiere","Refrigirateur", "Sifflement","Ouragan", "Violence", "Terrasse"};
        static List<char> listeLettres = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'q', 'l',
                'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        static string motATrouver;
        static int tailleMot;
        static int nbDeCoups;
        static int coupsRestant;
        static void Main(string[] args)
        {
            motATrouver = PrendreMot();
            tailleMot = motATrouver.Length - 1;
            nbDeCoups = 10;
            coupsRestant = 10;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("*** Bienvenue au jeu du Pendu ***");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            CacherMot();
            Console.WriteLine();
            VerifLettre();
            Console.ReadLine();
        }
        public static string PrendreMot()
        {
            Random random = new Random();
            int randomIndex = 0;
            randomIndex = random.Next(0, listeMots.Count - 1);
            string mot = listeMots[randomIndex];
            return mot;
        }
        static void CacherMot()
        {
            Console.Write(" Mot à trouver:   ");
            string motCache = motATrouver[0].ToString().ToUpper();
            for (int i = 1; i <= tailleMot; i++)
            {
                motCache += " _";
            }
            Console.WriteLine(motCache);
        }
        static void VerifLettre()
        {
            bool win;
            List<char> listLettreTrouver = new List<char>();
            do
            {
                Console.WriteLine(" Coups restants: " + coupsRestant);
                Console.WriteLine(" Saisir une lettre:  ");
                char saisie = Convert.ToChar(Console.ReadLine().ToLower());
                if (listeLettres.Contains(saisie))
                {
                    listeLettres.Remove(saisie);
                    if (motATrouver.Contains(saisie))
                    {
                        win = true;
                        listLettreTrouver.Add(saisie);
                        Console.Write(" Mot à trouver: " + motATrouver[0]);
                        for (int i = 1; i <= tailleMot; i++)
                        {
                            if (listLettreTrouver.Contains(motATrouver[i]))
                            {
                                Console.Write(" {0}", motATrouver[i]);
                            }
                            else
                            {
                                Console.Write(" _");
                                win = false;
                            }
                        }
                        if (win)
                        {
                            int coupGagant = nbDeCoups - (coupsRestant-1);
                            Console.WriteLine();
                            Console.WriteLine("Bravo !, vous avez réussi en " + coupGagant + " coups");
                            break;
                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        coupsRestant--;
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(" -> Désolé, le mot ne contient pas cette lettre");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        if (coupsRestant <= 0)
                        {
                            Console.WriteLine("Désolé, vous avez utilisé vos 10 essais");
                            Console.WriteLine(" Le mot à trouvé été " + motATrouver);
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("La lettre saisie à déja été entrée, essayez une autre lettre");
                }
            } while (true);
        }
    }
}
