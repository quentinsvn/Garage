using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestDAO testDAO = new TestDAO();

            // Menu

            Console.Title = "Garage"; // Nom de l'application

            bool bOk = false;

            while (!bOk)
            {
                Console.WriteLine("Que voulez-vous faire ?");
                Console.WriteLine("1. Afficher les marques de voitures");
                Console.WriteLine("2. Afficher les voitures d'une marque");
                Console.WriteLine("3. Afficher le classement des marques les plus fiables");
                Console.WriteLine("4. Afficher les garages");
                Console.WriteLine("5. Afficher les marques réparées par un garage");
                Console.WriteLine("Q. Quitter");
                Console.Write("Votre choix : ");

                char choix;
                char[] menuChoix = { '1', '2', '3', '4', '5', 'Q' };

                while (!char.TryParse(Console.ReadLine(), out choix) || !menuChoix.Contains(choix))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Valeur alphanumérique incorrecte.");
                    Console.ResetColor();
                    
                    Console.Write("\nEntrer un nombre entre 1 et 5 ou Q (pour quitter): ");
                }
                

                switch (choix)
                {
                    case '1':
                        testDAO.DisplayAllBrandOrdered();
                        break;
                    case '2':
                        // Demander la marque
                        Console.Write("Numéro de marque : ");
                        int brand = int.Parse(Console.ReadLine());
                        testDAO.DisplayAllCarsFromBrand(brand);
                        break;
                    case '3':
                        testDAO.DisplayBrandMoreSafeOrdered();
                        break;
                    case '4':
                        testDAO.DisplayAllGaragesOrdered();
                        break;
                    case '5':
                        Console.Write("Numéro de garage : ");
                        int garage = int.Parse(Console.ReadLine());
                        testDAO.DisplayRepairBrandByGarage(garage);
                        break;
                    case 'Q':
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Au revoir !");
                        Console.ResetColor();
                        
                        bOk = true;
                        break;
                }
            }

            Console.WriteLine("\nAppuyez sur n'importe quel touche pour quitter...");

            Console.ReadKey();
        }
    }
}
