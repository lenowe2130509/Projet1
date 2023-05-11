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








    }
}
