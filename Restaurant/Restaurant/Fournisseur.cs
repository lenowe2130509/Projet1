using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Restaurant
{
    static class Fournisseur
    {
        static string Nom { get; set; }

        static public List<Ingredient> listIngredientDispo = new List<Ingredient>();
        static public List<Ingredient> GetCatalogueIngredient()
        {
            Initialiser();
            return listIngredientDispo;
        }

        static  void Initialiser()
        {
            //Charger la liste d'ingrédients
            listIngredientDispo = JsonFileLoader.ChargerFichier<List<Ingredient>>("json_ingredient.json");
        }
       
    }
}
