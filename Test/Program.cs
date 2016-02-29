using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            ClientDAO data = new ClientDAO();

            Client c = data.Find(2);

            Console.WriteLine(c.Nom);
        }
    }
}
