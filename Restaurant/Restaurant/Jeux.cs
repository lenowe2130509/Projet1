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
            bool valide = false;
            Console.WriteLine("             Oh lala j'ai faim et si j'allais au EL RESTAU !");
            restaurant.AfficherResto();
            Console.WriteLine("Bienvenue chez EL RESTAU ! \n \n Nous avons plusieurs menu à disposition lequel souhaitez-vous ?");
            Console.WriteLine("Le [M]enu normal ou le Menu [S]pécial ?");
            while (!valide)
            {
                string choix = Console.ReadLine();
                switch (choix)
                {
                    case "M":
                        Console.WriteLine();
                        Console.WriteLine("Vous avez choisis le Menu normal ! \n Le voici !");
                        Console.WriteLine("\n Je vous laisse vous décidez ;)");
                        restaurant.AfficherMenu();
                        valide = true;
                        break;
                    case "S":
                        Console.WriteLine();
                        Console.WriteLine("Vous avez choisis le Menu Spécial ! \n Le voici !");
                        Console.WriteLine("\n Je vous laisse vous décidez ;)");
                        restaurant.AfficherMenuSpeciale();
                        valide = true;
                        break;
                    default:
                        Console.WriteLine("Excusez moi j'ai pas entendu ! Veuillez répéter s'il vous plaît.");
                        break;
                }
                
            }

            Console.WriteLine();   
            Console.WriteLine(" --------------------------");
            Console.WriteLine("|    Five minutes later     |");
            Console.WriteLine(" --------------------------");
            Console.WriteLine();

            valide = false;

            Console.WriteLine("Et voici votre plat j'espère que ce n'était pas trop long ! \n [S]i --------- [N]on ");
            while(!valide)
            {
                string avis = Console.ReadLine();
                switch(avis)
                {
                    case "S":
                        Console.WriteLine("J'en suis sincèrement désolé !");
                        valide = true;
                        break ;
                    case "N":
                        Console.WriteLine("Tant mieux on fait de notre mieux !");
                        valide = true;
                        break;
                    default:
                        Console.WriteLine("Excusez moi je n'ai pas entendu il y a beaucoup de bruit autour.");
                        break;
                }
            }
            Console.WriteLine("Je vous souhaite un bon appétit !");

            //Donner le plat + affirmation client servi

            Console.WriteLine("      ________");
            Console.WriteLine("   .-'        '-.");
            Console.WriteLine("  /    .---.    \\");
            Console.WriteLine(" |    /     \\    |");
            Console.WriteLine(" |   ;       ;   |");
            Console.WriteLine(" \\  |       |  /");
            Console.WriteLine("   '-;       ;-'");
            Console.WriteLine("      '-...-'");


        }


        public void validationCoteRestaurant()
        {

        }
    }
}
