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
            testDAO.DisplayAllMoviesOrdered();

            Console.ReadKey();
        }
    }
}
