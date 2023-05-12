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
        public void AugmenterBudget(int augmentation)
        {
            budget = budget + augmentation;
            Console.WriteLine("Votre budget est maintenant de :" +budget+" $");

        }

       public void AcheterUneRecette(string nom)
       {
            foreach (Plat plat in MarcheRecette.GetCatalogueRecette())
            {
                if (plat.Nom()==nom)
                {
                    if (budget >= plat.PrixAchat())
                    {
                        notreMenu.Add(plat);
<<<<<<< HEAD
                        budget = budget - plat.PrixVente();
=======
                        budget = budget - plat.PrixAchat();
                        plat.ChangerPrixVente(plat.PrixAchat()*2);

>>>>>>> nouvellebranchemar
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

        public void ServiClient(string nom)
        {
            foreach (Client client in clients)
            {
                if (client.Etat() == EtatClient.NonServi)
                {

                    Affichermenu();
                    //if plat pris est inferieur a budget alors
                    //message
                    //else

                    //changeretat
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

        public void AfficherMenu()
        {
            Console.WriteLine("MENU:\n");

            // Plats principaux
            Console.WriteLine("\n---- Plats principaux ----");
            Console.WriteLine("1. Le Boeuf Bourguignon - 18$");
            Console.WriteLine("2. L'Omelette Du Chef - 16$");
            Console.WriteLine("3. Pâtes Au Poulet - 14$");

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
                        switch (choix)
                        {
                            case 1:
                                Console.WriteLine("Vous avez choisi Le Boeuf Bourguignon. Excellent choix !");
                                valid = true;
                                // Ajouter le code pour le traitement de la commande
                                break;
                            case 2:
                                Console.WriteLine("Vous optez donc pour L'Omelette Du Chef ! Bon choix :)");
                                valid = true;
                                // Ajouter le code pour le traitement de la commande
                                break;
                            case 3:
                                Console.WriteLine("Vous avez choisi les Pâtes Au Poulet.");
                                valid = true;
                                break;
                            default:
                                Console.WriteLine("Choix invalide.");
                                break;
                        }
                        break;
                    case "N":
                        Console.WriteLine("Pas de soucis je vous laisse le temps je reviens dans quelques instants !");
                        Console.WriteLine(" --------------------------");
                        Console.WriteLine("|    Two minutes later     |");
                        Console.WriteLine(" --------------------------");
                        break;
                }
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
