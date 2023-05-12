using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Restaurant
{
    //Le resto y achete des recettes(plats)
    static class MarcheRecette
    {
        static List<Plat> platsEnVente;
        static void RemplirMarcheRecette()
        {
            platsEnVente = new List<Plat>();
            Plat plat1 = new Plat("Le Boeuf Bourguignon", Rarete.moyen, 20);
            //La liste d'ingredients necessaires pour faire du Boeuf bourguignon 
            plat1.remplirListeIng(Fournisseur.GetCatalogueIngredient()[5]);
            plat1.remplirListeIng(Fournisseur.GetCatalogueIngredient()[6]);
            plat1.remplirListeIng(Fournisseur.GetCatalogueIngredient()[7]);
            plat1.remplirListeIng(Fournisseur.GetCatalogueIngredient()[8]);
            plat1.remplirListeIng(Fournisseur.GetCatalogueIngredient()[9]);
            plat1.remplirListeIng(Fournisseur.GetCatalogueIngredient()[10]);
            plat1.remplirListeIng(Fournisseur.GetCatalogueIngredient()[11]);
            plat1.remplirListeIng(Fournisseur.GetCatalogueIngredient()[13]);
            //Ajout du Boeuf bourguignon a la liste des plats en vente
            platsEnVente.Add(plat1);

            Plat plat2 = new Plat("L'Omelette Du Chef", Rarete.abondant,10);
            //La liste d'ingredients necessaires pour faire L'Omelette Du Chef  
            plat2.remplirListeIng(Fournisseur.GetCatalogueIngredient()[2]);
            plat2.remplirListeIng(Fournisseur.GetCatalogueIngredient()[6]);
            plat2.remplirListeIng(Fournisseur.GetCatalogueIngredient()[7]);
            plat2.remplirListeIng(Fournisseur.GetCatalogueIngredient()[8]);
            plat2.remplirListeIng(Fournisseur.GetCatalogueIngredient()[9]);
            plat2.remplirListeIng(Fournisseur.GetCatalogueIngredient()[10]);
            plat2.remplirListeIng(Fournisseur.GetCatalogueIngredient()[17]);
            plat2.remplirListeIng(Fournisseur.GetCatalogueIngredient()[18]);
            //Ajout de L'Omelette Du Chef  a la liste des plats en vente
            platsEnVente.Add(plat2);

            Plat plat3 = new Plat("Pâtes Au Poulet", Rarete.moyen, 15);
            //La liste d'ingredients necessaires pour faire Les pâtes Au Poulet 
            plat3.remplirListeIng(Fournisseur.GetCatalogueIngredient()[5]);
            plat3.remplirListeIng(Fournisseur.GetCatalogueIngredient()[6]);
            plat3.remplirListeIng(Fournisseur.GetCatalogueIngredient()[7]);
            plat3.remplirListeIng(Fournisseur.GetCatalogueIngredient()[9]);
            plat3.remplirListeIng(Fournisseur.GetCatalogueIngredient()[10]);
            plat3.remplirListeIng(Fournisseur.GetCatalogueIngredient()[12]);
            plat3.remplirListeIng(Fournisseur.GetCatalogueIngredient()[15]);
            //Ajout des Pâtes Au Poulet  a la liste des plats en vente
            platsEnVente.Add(plat3);

            Plat plat4 = new Plat("Poutine", Rarete.moyen, 15);
            //La liste d'ingredients necessaires pour faire Le Gâteau Au Chocolat 
            plat4.remplirListeIng(Fournisseur.GetCatalogueIngredient()[0]);
            plat4.remplirListeIng(Fournisseur.GetCatalogueIngredient()[1]);
            plat4.remplirListeIng(Fournisseur.GetCatalogueIngredient()[2]);
            plat4.remplirListeIng(Fournisseur.GetCatalogueIngredient()[3]);
            plat4.remplirListeIng(Fournisseur.GetCatalogueIngredient()[14]);
            plat4.remplirListeIng(Fournisseur.GetCatalogueIngredient()[19]);
            //Ajout du  Gâteau Au Chocolat a la liste des plats en vente
            platsEnVente.Add(plat4);

        }
        
        static public List<Plat> GetCatalogueRecette()
        {
            RemplirMarcheRecette();
            return platsEnVente;

        }

    }
}
