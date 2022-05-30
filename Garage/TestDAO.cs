using Garage.DAO.Context;
using Garage.DAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Garage.ConsoleApp
{
    internal class TestDAO
    {

        // Affichage des voitures
        private void DisplayCar(List<Car> cars)
        {

            if (cars.Count > 0)
            {
                Console.WriteLine("+--------------------------------+");

                // Affichage du nom de la marque de voiture
                for (int i = 1; i <= 1; i++)
                {
                    using (GarageContext context = new GarageContext())
                    {
                        Brand brand = context.Brands.Find(cars[i].brandId); // Recherche de la marque de voiture par son id

                        string displayBrandName = String.Format("| {0,-30} |", brand.name);

                        Console.WriteLine(displayBrandName); // Affichage du nom de la marque de voiture

                    }
                }

                // Header du tableau
                string l1 = "+-----+------------------+-------+";
                string l2 = "| Id  | Nom              | Année |";
                string l3 = "+-----+------------------+-------+";


                Console.WriteLine(l1); // affichage de la ligne 1
                Console.WriteLine(l2); // affichage de la ligne 2
                Console.WriteLine(l3); // affichage de la ligne 3

                foreach (Car car in cars)
                {

                    // display car
                    int displayCarId = car.id;
                    string displayCarName = String.Format("{0}", car.name);     // Nom de la voiture
                    string displayCarYear = String.Format("{0}", car.year.ToString());     // Année de la voiture

                    // affichage de la ligne with padding
                    string displayCar = String.Format("| {0,-3} | {1,-16} | {2,-5} |", displayCarId, displayCarName, displayCarYear);

                    Console.WriteLine(displayCar);

                }

                Console.WriteLine(l1 + "\n"); // Fin de ligne
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nErreur : Aucune voiture n'a été trouvée !\n");
                Console.ResetColor();
            }
        }

        // Affichage des marques des voitures
        private void DisplayBrand(List<Brand> brands)
        {
            // Header du tableau
            string l1 = "+-----+------------------+";
            string l2 = "| Id  | Nom              |";
            string l3 = "+-----+------------------+";

            Console.WriteLine(l1); // affichage de la ligne 1
            Console.WriteLine(l2); // affichage de la ligne 2
            Console.WriteLine(l3); // affichage de la ligne 3

            // affichage des marques
            foreach (Brand brand in brands)
            {
                string displayBrandId = String.Format("{0}", brand.id);     // Id de la marque
                string displayBrandName = String.Format("{0}", brand.name); // Nom de la marque

                string displayBrand = String.Format("| {0,-3} | {1,-16} |", displayBrandId, displayBrandName); // affichage de la donnée

                // Affichage de la marque
                Console.WriteLine(displayBrand);
            }

            Console.WriteLine(l1 + "\n"); // Fin de la liste
        }

        // Affichage des garages
        private void DisplayGarage(List<DAO.Model.Garage> garages)
        {
            // Header du tableau
            string l1 = "+-----+----------------------+";
            string l2 = "| Id  | Nom                  |";
            string l3 = "+-----+----------------------+";

            Console.WriteLine(l1); // affichage de la ligne 1
            Console.WriteLine(l2); // affichage de la ligne 2
            Console.WriteLine(l3); // affichage de la ligne 3

            // affichage des garages
            foreach (DAO.Model.Garage garage in garages)
            {
                string displayGarageId = string.Format("{0}", garage.id);     // Id du garage
                string displayGarageName = string.Format("{0}", garage.name); // Nom du garage

                string displayGarage = string.Format("| {0,-3} | {1,-20} |", displayGarageId, displayGarageName); // affichage de la donnée

                // Affichage du garage
                Console.WriteLine(displayGarage);
            }

            Console.WriteLine(l1 + "\n"); // Fin de la liste
        }

        // Affichage des réparations
        private void DisplayRepair(List<Repair> repairs)
        {
            // Header du tableau
            string l1 = "+----------------------------------------+";
            string l2 = "| Repairs number  | Nom                  |";
            string l3 = "+----------------------------------------+";

            Console.WriteLine(l1); // affichage de la ligne 1
            Console.WriteLine(l2); // affichage de la ligne 2
            Console.WriteLine(l3); // affichage de la ligne 3

            // affichage des réparations
            List<Brand> list;

            Dictionary<int, int> BrandIdRepair = new Dictionary<int, int>();
            
            using (GarageContext context = new GarageContext())
            {
                // liste des marques
                list = context.Brands.ToList();

                foreach (var brand in list)
                {
                    int count = 0;
                    foreach (var car in context.Cars.Where(m => m.brandId == brand.id))
                    {
                        Repair repair = context.Repairs.Find(car.id);

                        count += context.Repairs.Where(m => m.carId == car.id).Count();

                    }
                    BrandIdRepair.Add(brand.id, count);
                }

                var sorted = from entry in BrandIdRepair orderby entry.Value ascending select entry;
                foreach (var sor in sorted)
                {
                    // get the brand with brand id
                    Brand brand = context.Brands.Find(sor.Key);

                    string displayNumberOfRepair = String.Format("| {0,-15} | {1,-20} |", sor.Value, brand.name);

                    Console.WriteLine(displayNumberOfRepair);
                }
                
            }

            Console.WriteLine(l1 + "\n"); // Fin de la liste
        }
        

        // Liste des marques de voitures triées par ordre d'id
        public void DisplayAllBrandOrdered()
        {
            List<Brand> list;

            using (GarageContext context = new GarageContext())
            {
                list = context.Brands.OrderBy(m => m.id).ToList();
            }
            DisplayBrand(list);
        }

        // Liste des voitures d'une marque par rapport à son ID (par ordre alphabétique)
        public void DisplayAllCarsFromBrand(int brand)
        {
            List<Car> list;


            using (GarageContext context = new GarageContext())
            {
                list = context.Cars.Where(m => m.Brand.id == brand).OrderBy(m => m.name).ToList();

            }
            DisplayCar(list);

        }

        // Classement des marques les plus fiables (selon le nombre de réparations)
        public void DisplayBrandMoreSafeOrdered()
        {
            List<Repair> list;

            using (GarageContext context = new GarageContext())
            {
                list = context.Repairs.OrderBy(m => m.id).ToList();
            }
            DisplayRepair(list);
        }

        // Liste des garages triées par ordre alphabétique
        public void DisplayAllGaragesOrdered()
        {
            List<DAO.Model.Garage> list;

            using (GarageContext context = new GarageContext())
            {
                list = context.Garages.OrderBy(m => m.name).ToList();
            }
            DisplayGarage(list);
        }

        // Marques réparées par un garage (selon son id)
        public void DisplayRepairBrandByGarage(int garageId)
        {
            using (GarageContext context = new GarageContext())
            {
                DAO.Model.Garage garage = context.Garages.Find(garageId); // recherche du garage

                // Vérification de l'existence du garage
                if (garage != null)
                {

                    // Nom de la marque
                    Console.WriteLine($"+--------------------------------------+");


                    var list = context.Repairs.Where(m => m.garageId == garageId).GroupBy(m => m.Car.brandId).ToList();

                    // Header du tableau
                    Console.WriteLine("| Id  | Nom                            |");
                    Console.WriteLine("+-----+--------------------------------+");

                    // Affichage des marques
                    foreach (var repair in list)
                    {
                        Brand brand = context.Brands.Find(repair.Key);
                        Console.WriteLine($"| {repair.Key,-4}| {brand.name,-31}|");
                    }
                    Console.WriteLine($"+--------------------------------------+");
                }
                else
                {
                    // Message d'erreur si le garage n'existe pas
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nErreur : Le garage n'existe pas !\n");
                    Console.ResetColor();
                }
            }
        }
    }
}
