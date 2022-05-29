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

            Console.Title = "Garage";

            bool allDone = false;

            while (!allDone)
            {
                Console.WriteLine("Que voulez-vous faire ?");
                Console.WriteLine("1. Afficher les marques de voitures");
                Console.WriteLine("2. Afficher les voitures d'une marque");
                Console.WriteLine("3. Afficher le classement des marques les plus fiables");
                Console.WriteLine("4. Afficher les garages");
                Console.WriteLine("5. Afficher les marques réparées par un garage");
                Console.WriteLine("6. Quitter");
                Console.Write("Votre choix : ");

                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 6)
                {
                    Console.Write("Valeur alphanumérique incorrecte. Entrer un nombre entre 1 et 6: ");
                }

                switch (choice)
                {
                    case 1:
                        testDAO.DisplayAllBrandOrdered();
                        break;
                    case 2:
                        // Demander la marque
                        Console.Write("Numéro de marque : ");
                        int brand = int.Parse(Console.ReadLine());
                        testDAO.DisplayAllCarsFromBrand(brand);
                        break;
                    case 3:
                        testDAO.DisplayBrandMoreSafeOrdered();
                        break;
                    case 4:
                        testDAO.DisplayAllGaragesOrdered();
                        break;
                    case 5:
                        Console.Write("Numéro de garage : ");
                        int garage = int.Parse(Console.ReadLine());
                        testDAO.DisplayRepairBrandByGarage(garage);
                        break;
                    case 6:
                        Console.WriteLine("Au revoir !");
                        allDone = true;
                        break;
                }
            }

            Console.WriteLine("\nAppuyez sur n'importe quel touche pour quitter...");

            Console.ReadKey();
        }
    }
}
