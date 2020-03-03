using SCADI_Service.Control;
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
            Manager manager = Manager.Instance;
            manager.Start();
            Console.ReadLine();
        }
    }
}
