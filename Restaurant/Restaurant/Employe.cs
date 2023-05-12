using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public enum Poste
    {
        chefCuisinier,
        assistantCuisinier,
        serveur,
        caissiere,
    }
    internal class Employe
    {
       
            private string nomComplet;
            private int experience;
            private Poste poste;
            private float compteEmploye;
            public Employe(string nomComplet,int experience,Poste poste,int compte)
            {
                this.nomComplet = nomComplet;
                this.experience = experience;
                this.poste = poste;
                this.compteEmploye = compte;
            }
            public override string ToString()
            {
                return " Nom : " + nomComplet + " Expérience: " + experience + " Poste Occupé  :" + poste +"MontantCompte : "+compteEmploye;
            }
            public void RecevoirSalaire(float salaire) { compteEmploye= compteEmploye + salaire; }
    }


}
