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
            c.Name = "aaasc";
            c.FirstSurname = "adc";
            c.SecondSurname = "asvv";

            c.Ci = "95011731386";
            c.Save();

            ClientRepository cr = ClientRepository.Instance;
            var todos = cr.Where("Name", "aaasc").Where("SecondSurname", "asvv").Get();
            foreach (var item in todos)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadLine();

        }
    }
}
