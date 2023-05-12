using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    internal class Jeux
    {
        Restaurant restaurant = new Restaurant("EL RESTAU", 120);
            
        public void Jouer()
        {
            FabriqueNom.InitialiserNom();
            Client client = new Client();
            Client client1 = new Client();
            Client client2 = new Client();

            restaurant.AjouterClient(client1);
            restaurant.AjouterClient(client2);
            restaurant.AjouterClient(client);
            Employe emp = new Employe(" Max Duran", 2, Poste.chefCuisinier, 1500);
            Employe emp1 = new Employe(" Vincent Morin", 0, Poste.caissiere, 15000000);
            Employe emp2 = new Employe(" Marie", 10, Poste.caissiere, 15);
            restaurant.Embaucher(emp);
            restaurant.Embaucher(emp1);
            restaurant.Embaucher(emp2);



            Console.WriteLine("             Oh lala j'ai faim et si j'allais au EL RESTAU !");
           
           restaurant.AfficherMenu();

            Console.WriteLine("Vous avez fini le jeu bien joué à vous !");


        }


        public void validationCoteRestaurant()
        {

        }
    }
}
