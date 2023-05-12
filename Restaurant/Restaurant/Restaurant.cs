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








        }
}
