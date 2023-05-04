using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Restaurant
{
    internal class Fournisseur
    {
        private string nom;

        static public List<Ingredient> listIngredientDispo = new List<Ingredient>();
        public Fournisseur(string nom)
        {
            this.nom = nom;

        }

        public void Initialiser()
        {
            //Charger la liste d'ingrédients
            listIngredientDispo = JsonFileLoader.ChargerFichier<List<Ingredient>>("json_ingredient.json");
        }
    }
}
