using SCADI_Service.Models;
using SCADI_Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCADI_Service
{
    class Program
    {
        static void Main(string[] args)
        {
            Client c = new Client();
            c.Name = "Yolanda";
            c.FirstSurname = "Tremol";
            c.SecondSurname = "Pujol";
            c.Ci = "95011731386";
            c.Save();

            var repo = ClientRepository.Instance;
            var todos = repo.All();
            foreach (var item in todos)
            {
                Console.WriteLine(item.Name+" "+item.FirstSurname+" "+item.SecondSurname);
            }
            Console.ReadLine();
        }
    }
}
