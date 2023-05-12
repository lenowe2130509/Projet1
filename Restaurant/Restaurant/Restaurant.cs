using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Restaurant
{
    internal class Restaurant
    {
        string nom;
        private List<Client> clients;
        private List<Ingredient> nosIngredients;
        private List<Employe> notrePersonnel;
        private List<Plat> notreMenu;
        private float budget;
        

        public Restaurant(string nom,float budget)
        {
            this.nom = nom;
            this.budget = budget;
            this.clients = new List<Client>();
            nosIngredients = new List<Ingredient>();
            notrePersonnel= new List<Employe>();
            notreMenu= new List<Plat>();
            FabriqueNom.InitialiserNom();
        }


        public void AcheterIngredient(string nom)
        {
            foreach(Ingredient ingredient in Fournisseur.GetCatalogueIngredient())
            {
                if(ingredient.Nom==nom)
                {
                    if(budget >= ingredient.Prix)
                    {
                        nosIngredients.Add(ingredient);
                        budget = budget-ingredient.Prix;
                        
                    }
                    else
                    {
                        Console.WriteLine("Vous n'avez pas assez d'argent , veuillez augmenter votre budget avant d'effectuer l'achat");
                    }  
                }
                else
                {
                    Console.WriteLine("Fournisseur" + " : « Nous N'avons pas cet article en stock »");
                }


            }

        }
        public Plat plat(int choix)
        {
            return notreMenu[choix];
        }

        public void Embaucher(Employe empl)
        {
            notrePersonnel.Add(empl);
        }

        public void AjouterClient(Client client)
        {
           clients.Add(client);
        }


        public void AfficherMenu()
        {
            Console.WriteLine("MENU:\n");

            // Plats principaux
            //Console.WriteLine("\n---- Plats principaux ----");
            //Console.WriteLine("1. Le Boeuf Bourguignon - 18$"); // Dans ce plat nous avons (listIngredient(1))
            //Console.WriteLine("2. L'Omelette Du Chef - 16$");
            //Console.WriteLine("3. Pâtes Au Poulet - 14$");
            Console.WriteLine("1 - Acheter Recette");
            Console.WriteLine("2 - Acheter Ingrédient");
            Console.WriteLine("3 - Servir client");
            Console.WriteLine("4 - Payer personnel");
            Console.WriteLine("5 - Obtenir Info Resto");
            Console.WriteLine("6 - Partir");
            Console.WriteLine();
            Console.WriteLine("Veuillez entrer un chiffre de la fonction voulu");
            string choi = Console.ReadLine();
            bool valide = false;
            do
            {
                switch (choi)
                {
                    case "1":
                        Console.WriteLine();
                        Console.WriteLine("Vous avez choisis Acheter Recette ! \n Voici la liste des recettes disponibles !");
                        foreach (Plat plat in MarcheRecette.GetCatalogueRecette())
                        {
                            Console.WriteLine(plat.ToString());

                        }
                        Console.WriteLine("Veuillez entrez le nom de la recette que vous voulez acheter");
                        string nomRecette = Console.ReadLine();
                        AcheterUneRecette(nomRecette);
                        valide = true;
                        break;
                    case "2":
                        Console.WriteLine();
                        Console.WriteLine("Vous avez choisis Acheter Ingrédient ! \n Voici la liste des ingrédients disponibles !");
                        foreach (Ingredient ingredient in Fournisseur.listIngredientDispo)
                        {
                            Console.WriteLine(ingredient.ToString());

                        }
                        string nomIng = Console.ReadLine();
                        AcheterIngredient(nomIng);
                        valide = true;
                        break;
                    case "3":
                        Console.WriteLine();
                        Console.WriteLine("Vous avez choisis Servir client ! \n Le voici !");
                        ServirClient();
                        Console.WriteLine(" ----------------------------");
                        Console.WriteLine("|    Three minutes later     |");
                        Console.WriteLine(" ----------------------------");

                        Console.WriteLine("Vous avez fait votre choix ?");
                        Console.WriteLine("[O]ui ----------- [N]on");
                        bool valid = false;
                        while (!valid)
                        {
                            string decide = Console.ReadLine();
                            switch (decide)
                            {
                                case "O":
                                    Console.WriteLine("\nMerci de faire votre choix en indiquant le numéro du plat.");
                                    int choix = Convert.ToInt32(Console.ReadLine());

                                    // Traiter le choix de l'utilisateur
                                    Console.WriteLine($"Vous avez {plat(choix).Nom()}. Excellent choix !");
                                    VerifPlat(plat(choix));
                                    break;
                                case "N":
                                    Console.WriteLine("Pas de soucis je vous laisse le temps je reviens dans quelques instants !");
                                    Console.WriteLine(" --------------------------");
                                    Console.WriteLine("|    Two minutes later     |");
                                    Console.WriteLine(" --------------------------");
                                    break;
                            }
                        }
                        //VerifPlat(plat());
                        valide = true;
                        break;
                    case "4":
                        Console.WriteLine();
                        Console.WriteLine("Vous avez choisis Payer personnel ! \n Le voici !");
                        PayerPersonnel();
                        valide = true;
                        break;
                    case "5":
                        Console.WriteLine();
                        Console.WriteLine("Vous avez choisis Obtenir Info Resto ! \n Le voici !");
                        Console.WriteLine(ToString());
                        valide = true;
                        break;
                    case "6":
                        Console.WriteLine("A+");
                        valide = true;
                        break;
                    default:
                        Console.WriteLine("Excusez moi j'ai pas entendu ! Veuillez répéter s'il vous plaît.");
                        break;
                }
            }while (!valide);   
        }

        public void AugmenterBudget(int augmentation)
        {
            budget = budget + augmentation;
            Console.WriteLine("Votre budget est maintenant de :" +budget+" $");

        }


       public void AcheterUneRecette(string nom)
       {
            bool correspond = false;
            bool estSup = false;

            foreach (Plat plat in MarcheRecette.GetCatalogueRecette())
            {

                if (plat.Nom() == nom)
                {
                    correspond = true;

                    if (budget >= plat.PrixAchat())
                    {
                        estSup = true;
                    }

                    break;
                }
                if (correspond)
                {
                    if (estSup)
                    {
                        notreMenu.Add(plat);
                        budget = budget - plat.PrixVente();

                        budget = budget - plat.PrixAchat();
                        plat.ChangerPrixVente(plat.PrixAchat() * 2);

                    }
                    else
                    {
                        Console.WriteLine("Vous n'avez pas assez d'argent , veuillez augmenter votre budget avant d'effectuer l'achat");

                    }
                }
                else
                {
                    Console.WriteLine("Marche De Recettes" + " : « Nous N'avons pas ce plat en stock »");
                }



                /* if (plat.Nom()==nom)
                 {
                     if (budget >= plat.PrixAchat())
                     {
                         notreMenu.Add(plat);
                         budget = budget - plat.PrixVente();

                         budget = budget - plat.PrixAchat();
                         plat.ChangerPrixVente(plat.PrixAchat()*2);

                     }
                     else
                     {
                         Console.WriteLine("Vous n'avez pas assez d'argent , veuillez augmenter votre budget avant d'effectuer l'achat");
                     }
                 }
                 else
                 {
                     Console.WriteLine("Marche De Recettes" + " : « Nous N'avons pas ce plat en stock »");
                 }
             }*/






            }
        }

        public void RetirerRecette(string nom)
        {
            foreach (Plat plat in notreMenu)
            {
                if (plat.Nom() == nom)
                {
                    
                        notreMenu.Remove(plat);

                }
                else
                {
                        Console.WriteLine(" Aucun Plat de Votre Menu ne possède ce nom");
                }
            }

        }

        public void ServirClient()
        {
            Client client1 = new Client();
            foreach (Client client in clients)
            {
                if (client.Etat() == EtatClient.NonServi)
                {
                    bool valide = false;
                    AfficherResto();
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
                                foreach (Plat plat in notreMenu)
                                {
                                    int n = 0;
                                    Console.WriteLine(n + " - " + plat.Nom() + " - " + plat.PrixVente() + plat.retournerListe());
                                    n++;
                                }
                                int r = Convert.ToInt32(Console.ReadLine());
                                VerifPlat(plat(r));
                                bool valideu = false;
                                Console.WriteLine();
                                Console.WriteLine(" --------------------------");
                                Console.WriteLine("|    Five minutes later     |");
                                Console.WriteLine(" --------------------------");
                                Console.WriteLine();


                                Console.WriteLine("Et voici votre plat j'espère que ce n'était pas trop long ! \n [S]i --------- [N]on ");
                                while (!valideu)
                                {
                                    string avis = Console.ReadLine();
                                    switch (avis)
                                    {
                                        case "S":
                                            Console.WriteLine("J'en suis sincèrement désolé !");
                                            valideu = true;
                                            break;
                                        case "N":
                                            Console.WriteLine("Tant mieux on fait de notre mieux !");
                                            valideu = true;
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
                                valide = true;
                                break;
                            case "S":
                                Console.WriteLine();
                                Console.WriteLine("Vous avez choisis le Menu Spécial ! \n Le voici !");
                                Console.WriteLine("\n Je vous laisse vous décidez ;)");
                                AfficherMenuSpeciale();
                                valide = true;
                                break;
                            default:
                                Console.WriteLine("Excusez moi j'ai pas entendu ! Veuillez répéter s'il vous plaît.");
                                break;
                        }

                    }
                    
                    //if plat pris est inferieur a budget alors
                    //message
                    //else
                    client.ChangerEtat();
                    client.ChangerHumeur();
                }
                else
                {
                    Console.WriteLine("Client déjà servi !");
                }
            }
        }

        public void VerifPlat(Plat lePlat)
        {
            foreach (Plat plat in notreMenu)
            {
                if (plat.Nom() == nom)
                {
                    foreach(Client client in clients)
                    {
                        if (client.Budget()>= plat.PrixVente())
                        {
                            client.Acheter(plat.PrixVente());
                            budget = budget+plat.PrixVente();
                            Console.WriteLine("Vous avez bien pris votre commande");
                        }
                        else
                        {
                            Console.WriteLine("Restaurant : Nous sommes désolée ,Vous n'avez pas assez d'argent pour acheter ce plat . Veuillez en choisir un moins cher ou revenir plus tard ,Merci");

                        }
                    }
                }
                    
                else
                {
                    Console.WriteLine(" Aucun Plat de Notre Menu ne possède ce nom");
                }
            }

        }



        public override string ToString()
        {
            string info = " *** INFORMATION DU RESTAURANT *** \n";
            info += " Nom : " + nom+"\n";
            info += " *** SECTION INFO SUR NOS CLIENTS *** "+ "\n";
            foreach (Client client in clients)
                info+= client.ToString();
            info += " SECTION INFO SUR NOTRE MENU" + "\n";
            foreach (Plat plat in notreMenu)
                info += plat.ToString();
            info += " SECTION INFO SUR NOTRE PERSONNEL" + "\n";
            foreach (Employe employe in notrePersonnel)
                info += employe.ToString();
            return info;
        }

        public void PayerPersonnel()
        {
            if (budget >0)
            {
                float montantSalaire = budget/2;
                budget = budget - montantSalaire;
                float salaireIndividuel = montantSalaire/notrePersonnel.Count();
                foreach (Employe employe in notrePersonnel)
                {

                    employe.RecevoirSalaire(salaireIndividuel);
                }

                
            }
            else
            {
                Console.WriteLine("Vous n'avez pas assez d'argent pour payer votre personnel");
            }

           

           }


        public void AfficherMenuSpeciale()
        {
            Console.WriteLine("MENU:\n");

            // Plats principaux
            Console.WriteLine("\n---- Plats principaux ----");
            Console.WriteLine("1. Poutine - 7$");
            Console.WriteLine("2. Filet de saumon - 16$");
            Console.WriteLine("3. Pâtes Au Poulet - 14$");

            Console.WriteLine(" ----------------------------");
            Console.WriteLine("|    Three minutes later     |");
            Console.WriteLine(" ----------------------------");
            bool valide = false;
            while(!valide)
            {
            Console.WriteLine("Vous avez fait votre choix ?");

            Console.WriteLine("[O]ui ----------- [N]on");

                string decide = Console.ReadLine();
                switch (decide)
                {
                    case "O":
                        Console.WriteLine("\nMerci de faire votre choix en indiquant le numéro du plat.");
                        int choix = Convert.ToInt32(Console.ReadLine());

                        // Traiter le choix de l'utilisateur
                        switch (choix)
                        {
                            case 1:
                                Console.WriteLine($"Vous avez choisi la Poutine très bon choix ! ");
                                valide = true;//ajout fonction pauvreté 


                                // Ajouter le code pour le traitement de la commande
                                break;
                            case 2:
                                Console.WriteLine($"Vous avez choisi L'Omelette Du Chef bon choix !");
                                valide = true;
                                // Ajouter le code pour le traitement de la commande
                                break;
                            case 3:
                                Console.WriteLine("Vous avez choisi les Pâtes Au Poulet.");
                                break;
                            default:
                                Console.WriteLine("Choix invalide.");
                                break;
                        }
                        VerifPlat(plat(choix));
                        bool valid = false;
                        Console.WriteLine();
                        Console.WriteLine(" --------------------------");
                        Console.WriteLine("|    Five minutes later     |");
                        Console.WriteLine(" --------------------------");
                        Console.WriteLine();


                        Console.WriteLine("Et voici votre plat j'espère que ce n'était pas trop long ! \n [S]i --------- [N]on ");
                        while (!valid)
                        {
                            string avis = Console.ReadLine();
                            switch (avis)
                            {
                                case "S":
                                    Console.WriteLine("J'en suis sincèrement désolé !");
                                    valid = true;
                                    break;
                                case "N":
                                    Console.WriteLine("Tant mieux on fait de notre mieux !");
                                    valid = true;
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
                        break;
                    case "N":
                        Console.WriteLine("Pas de soucis je vous laisse le temps je reviens dans quelques instants !");
                        Console.WriteLine(" --------------------------");
                        Console.WriteLine("|    Two minutes later     |");
                        Console.WriteLine(" --------------------------");
                        break;
                    default :
                        Console.WriteLine("Excusez moi mais ce n'est pas une réponse ");
                        break ;
                }
            }
        }

        public void AfficherResto()
        {
            Console.WriteLine("         ");
            Console.WriteLine("         ");
            Console.WriteLine("         ");
            Console.WriteLine("         ");
            Console.WriteLine("         ");
            Console.WriteLine("         ");
            Console.WriteLine("                  ");
            Console.WriteLine("                                      ");
            Console.WriteLine("                            ____            ");
            Console.WriteLine("         __________________[____]__         ");
            Console.WriteLine("        /                          \\        ");
            Console.WriteLine("       /                            \\       ");
            Console.WriteLine("      /      _______________         \\      ");
            Console.WriteLine("     /      /                \\       \\     ");
            Console.WriteLine("    /      /     El RESTAU    \\       \\    ");
            Console.WriteLine("   /      /____________________\\       \\   ");
            Console.WriteLine("  /                                      \\  ");
            Console.WriteLine(" /                                        \\ ");
            Console.WriteLine("/__________________________________________\\");
            Console.WriteLine(" |                                          |");
            Console.WriteLine(" |                                          |");
            Console.WriteLine(" |                                          |");
            Console.WriteLine(" |   ___      _______       ____________    |");
            Console.WriteLine(" |  |   |    |       |     |      |     |   |");
            Console.WriteLine(" |  |___|    |       |     |______|_____|   |");
            Console.WriteLine(" |           |      o|                      |");
            Console.WriteLine(" |___________|_______|______________________|");
            Console.WriteLine();
        }


        }
}
