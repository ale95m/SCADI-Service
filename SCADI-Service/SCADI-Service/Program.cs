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
            c.Name = "Alejandro";
            c.First_surname = "Moreno";
            c.second_surname = "Pujol";
            c.ci = "95011731386";
            c.created_at = DateTime.Now;
            c.updated_at = DateTime.Now;
            c.Save();

            var repo = ClientRepository.Instance;
            var todos = repo.All();
            foreach (var item in todos)
            {
                item.second_surname = "Rodgz";
                item.Save();
            }
            Console.ReadLine();
        }
    }
}
