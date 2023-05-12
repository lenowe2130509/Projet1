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
        private List<Plat> notreMenu;

        // private Fournisseur fournisseur;
        private float budget;

        public Restaurant(string nom,float budget)
        {
            this.nom = nom;
            //this.fournisseur = fournisseur;
            this.budget = budget;
            this.clients = new List<Client>();
            nosIngredients = new List<Ingredient>();

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
                    if (budget >= plat.PrixVente())
                    {
                        notreMenu.Add(plat);
                        budget = budget - plat.PrixVente();
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


        public void AfficherMenu()
        {
            Console.WriteLine("MENU:\n");

            // Plats principaux
            Console.WriteLine("\n---- Plats principaux ----");
            Console.WriteLine("1. Le Boeuf Bourguignon - 18$"); // Dans ce plat nous avons (listIngredient(1))
            Console.WriteLine("2. L'Omelette Du Chef - 16$");
            Console.WriteLine("3. Pâtes Au Poulet - 14$");

            //foreach (Plat plat in notreMenu )
            //{
            //    int n = 1;
            //    Console.WriteLine(n + " - "  + plat.Nom() + " - " + plat.PrixVente() + plat.retournerListe());
            //    n++;
            //}

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
