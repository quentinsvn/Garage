using Garage.DAO.Context;
using Garage.DAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.ConsoleApp
{
    internal class TestDAO
    {

        // Affichage des voitures
        private void DisplayCar(List<Car> cars)
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

            Console.WriteLine(l1); // affichage de la ligne 1

            Console.WriteLine(); // Saut de ligne
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

            Console.WriteLine(l1); // Fin de la liste
            Console.WriteLine(); // Saut de ligne
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

            Console.WriteLine(l1); // Fin de la liste
            Console.WriteLine(); // Saut de ligne
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
            foreach (Repair repair in repairs)
            {

                // ID de la voiture
                int displayCarId = repair.carId;

                // Nom de la voiture
                using (GarageContext context = new GarageContext())
                {
                    Car car = context.Cars.Find(displayCarId); // Recherche de la voiture par son id

                    // Count the number of car repairs taking into account cars without any repairs
                    int carRepairCount = context.Repairs.Where(r => r.carId == car.id).Count();

                    // Nom des marques
                    Brand brand = context.Brands.Find(car.brandId);
                    
                    string displayBrandName = String.Format("{0}", brand.name);

                    // Nom des marques de voitures par rapport à l'id de la voiture
                    string displayCarName = String.Format("{0}", displayBrandName);
                    


                    string displayRepair = String.Format("| {0,-15} | {1,-20} |", carRepairCount, displayCarName); // affichage de la donnée
                    Console.WriteLine(displayRepair);
                }

                // Affichage de la réparation
                //Console.WriteLine(displayRepair);
            }

            Console.WriteLine(l1); // Fin de la liste
            Console.WriteLine(); // Saut de ligne
        }
        

        // Liste des marques de voitures triées par ordre alphabétique
        public void DisplayAllBrandOrdered()
        {
            List<Brand> list;

            using (GarageContext context = new GarageContext())
            {
                list = context.Brands.OrderBy(m => m.id).ToList();
            }
            DisplayBrand(list);
        }

        // Liste des voitures triées par ordre alphabétique
        public void DisplayAllCarsOrdered()
        {

            List<Car> list;

            using (GarageContext context = new GarageContext())
            {
                list = context.Cars.OrderBy(m => m.id).ToList();
            }
            DisplayCar(list);

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

        // Liste des voitures d'une marque par rapport à son ID
        public void DisplayAllCarsFromBrand(int brand)
        {
            List<Car> list;


            using (GarageContext context = new GarageContext())
            {
                //foreach car get garage id and name
                list = context.Cars.Where(m => m.Brand.id == brand).OrderBy(m => m.name).ToList();

                //Console.WriteLine("******************** TEST DAO - DisplayAllCarsFromBrand **************");

            }
            DisplayCar(list);

        }

        // Afficher le classement des réparations
        public void DisplayRepairOrdered()
        {
            List<Repair> list;

            using (GarageContext context = new GarageContext())
            {
                list = context.Repairs.OrderBy(m => m.id).ToList();
            }
            DisplayRepair(list);
        }

    }
}
