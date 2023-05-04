using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Restaurant
{
    public static class JsonFileLoader
    {
        

        //ici, c'est un brin spécial..
        // On parle d'un type générique, qui permet de prendre n'importe quel type d"éléments en paramètre 
        public static T ChargerFichier<T>(string nomFichier)
        {
            try
            {
                //le using est utilisé pour automatiquement lancer la méthode dispose à la fin du bloc 
                using (StreamReader reader = new StreamReader(nomFichier))
                {
                    string json = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<T>(json);
                }
            }
            catch(Exception ex)
            {
                //Gérer l'erreur ici, par exmple :
                Console.WriteLine("Erreur lors du chargement du fichier JSON : " + ex.Message);
                return default(T);
            }
        }

        
    }
}
