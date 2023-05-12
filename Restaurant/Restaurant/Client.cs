using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public enum HumeurClient
    {
        Bonne,
        Neutre,
        Mauvaise,
    }
    public enum EtatClient
    {
        Servi,
        NonServi,
    }
    internal class Client
    {
        private string nom;
        private HumeurClient humeur;
        private EtatClient etat;
        private int  budgetClient;
        static Random rand = new Random();
        public Client()
        {
            this.nom= FabriqueNom.FabriquerNom();
            this.etat = DonnerEtat(rand.Next(0,3));
            this.humeur = DonnerHumeur(rand.Next(0,3));
            this.budgetClient = rand.Next(5,100);

        }

        public HumeurClient DonnerHumeur(int n) 
        {
            HumeurClient humeur = HumeurClient.Bonne;
            if (n == 1)
            {
                humeur = HumeurClient.Neutre;

            }
            else if (n == 2)
            {
                humeur = HumeurClient.Mauvaise;

            }
            else
            {
                humeur = HumeurClient.Bonne;

            }
            return humeur;

        }
        public EtatClient DonnerEtat(int n)
        {
            EtatClient etat= EtatClient.NonServi;
            if (n == 1)
            {
                etat = EtatClient.Servi;

            }
            else if (n == 2)
            {
                etat = EtatClient.NonServi;

            }
            else
            {
                etat= EtatClient.NonServi;

            }
            return etat;

        }

        public void ChangerEtat()
        {
            etat = EtatClient.Servi;

        }
        public void ChangerHumeur()
        {
            humeur = HumeurClient.Bonne;

        }
        public void Acheter(int montant)
        {
            budgetClient = budgetClient-montant;

        }

        public string Nom() { return nom; }
        public HumeurClient Humeur() { return humeur; }
        public EtatClient Etat() { return etat; }
        public int Budget() { return budgetClient; }

        public override string ToString()
        {
            return " Nom : " + nom + " Humeur : " + humeur + " Etat(Servi ou Non-Servi) :"+etat+ " Budget :"+budgetClient;
        }
    }

    
}
