using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    internal class Client
    {
        public Client()
        {
            string nouveauNom = FabriqueNom.FabriquerNom();
            Console.WriteLine(nouveauNom);
        }
    }
}
