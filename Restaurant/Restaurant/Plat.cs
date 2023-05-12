using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Restaurant
{
    enum Rarete
    {
       rare,
       moyen,
       abondant,

    }
    internal class Plat
    {
        private string nom;
        private List<Ingredient>ingredientsNecessaires;
        private Rarete rarete;
        private int prixAchat;
        private int prixVente;

        public Plat(string nom,Rarete rarete,int prixAchat)
        {
            this.nom = nom;
            this.rarete = rarete;
            this.prixAchat = prixAchat;
            this.prixVente = 0;
            ingredientsNecessaires = new List<Ingredient>() ;
        }

        //pour remplir la liste des ingredients nécessaire pour la confection du plat
         public void remplirListeIng(Ingredient ing)
         {
            ingredientsNecessaires.Add(ing);
            
            
         }

        public string Nom(){return nom;}
        public Rarete Rarete() { return rarete; }
        public int PrixAchat() { return prixAchat;}
        public int PrixVente() { return prixVente;}


        //Pour changer le prix de vente du produit qui est de 0 a l'achat
        public void ChangerPrixVente(int nouveauMontant)
        {
            prixVente = nouveauMontant;
            
        }
        public override string ToString()
        {
            string info = "";
            info += " Nom : " + nom + " Rareté : "+rarete+ " Prix D'Achat: " + prixAchat+ " Prix De Vente : " +prixVente+ "\n";
            foreach (Ingredient ing in ingredientsNecessaires)
                info += ing.ToString();

            return info;
        }



    }

}
