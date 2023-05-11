
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
namespace Restaurant
{
    enum Qualite
    {
        Moyenne,
        Bonne,
        Excellente,
    }

    internal class Ingredient
    {
        public string Nom { get; set; }
        public int Calorie { get; set; }
        public Qualite QualiteIng { get; set; }
        public float Prix { get; set; }

        [JsonConstructor]

        public Ingredient(string nom,int calorie,string qualite,float prix)
        {
            Nom = nom;
            Calorie = calorie;
            if (qualite.Contains("Moyenne"))
                QualiteIng = Qualite.Moyenne;
            else if (qualite.Contains("Bonne"))
                QualiteIng = Qualite.Bonne;
            else if (qualite.Contains("Excellente"))
                QualiteIng = Qualite.Excellente;
            else
                QualiteIng = Qualite.Moyenne;
            Prix = prix;

        }

    }
}
