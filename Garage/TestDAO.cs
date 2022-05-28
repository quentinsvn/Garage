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
                list = context.Garages.OrderBy(m => m.id).ToList();
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

        public void DisplayBrandMoreSafe()
        {
            List<Brand> list;

            using (GarageContext context = new GarageContext())
            {
                /*
                list = (from movie in context.Movies
                        orderby movie.Title ascending
                        where movie.Date < date
                        select movie).ToList();
                */

                //display the all brand
                //list = context.Brands.OrderBy(m => m.id).ToList();
                // display the brand ordered with minimum row un repear.cs table
                list = context.Brands
                    .GroupBy(m => m.name)
                    .Select(m => m.First())
                    .OrderBy(m => m.id).ToList();


                Console.WriteLine("******************** TEST DAO - DisplayMoviesBeforeYear **************");

            }
            DisplayBrand(list);
        }

        public void DisplayAllGarage()
        {
            List<Car> list;

            using (GarageContext context = new GarageContext())
            {
                /*
                list = (from movie in context.Movies
                        from genre in movie.Genres
                        where genre.Name == genreName
                        orderby movie.Title ascending
                        select movie).ToList();
                
                list = context.Movies
                    .Where(m => m.Genres
                        .Any(g ==> g.Name == genreName))
                    .OrderBy(movie => movie.Title)
                */
                // display all garages
                list = context.Cars.ToList();





                Console.WriteLine("******************** TEST DAO - DisplayAllGarage **************");

            }
            DisplayCar(list);
        }

    }
}
