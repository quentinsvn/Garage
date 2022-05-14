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
        public void DisplayCar(List<Car> cars)
        {
            foreach (Car car in cars)
            {
                // display movie
                string displayCar = String.Format("Title : {0}, date : {1}", car.name, car.year.ToString());
                Console.WriteLine(displayCar);

                /*
                using (GarageContext context = new GarageContext())
                {
                    context.Cars.Attach(car);

                    foreach (Brand brand in car.Brand.OrderBy(b => b.name))
                    {
                        string displayBrand = String.Format(" - Marque : {0}", brand.name);
                        Console.WriteLine(displayBrand);
                    }
                }
                */

                Console.WriteLine();
            }
        }

        public void DisplayAllMoviesOrdered()
        {
            List<Car> list;

            using (GarageContext context = new GarageContext())
            {
                list = context.Cars.OrderBy(m => m.name).ToList();

                /*
                 var req = from movie in context.movies
                 orderby = movue.Title ascending
                select movie;
                list = req.ToList();
                 */

                Console.WriteLine("******************** TEST DAO - CarAlphabetical **************");

            }
            DisplayCar(list);
        }

    }
}
