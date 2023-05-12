using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

namespace Restaurant
{
    static class FabriqueNom
    {
        static List<string> listNom = new List<string>();
        static List<string> listPrenom = new List<string>();
        static Random rand = new Random();

        static public void RemplirListe()
        {
            AjouterNom();
            AjouterPrenom();

        }
        static void AjouterNom()
        {
            string fichierNomFamille = "nom_famille.txt";
            using (StreamReader reader = new StreamReader(fichierNomFamille))
            {
                string line;
                //Lire chaque ligne du fichier
                while ((line = reader.ReadLine()) != null)
                {
                    //ajouter le nom de la liste
                    listNom.Add(line);
                }
            }

        }

        static public void InitialiserNom()
        {
            try
            {
                FabriqueNom.RemplirListe();
            }
            catch (Exception ex)
            {
                //Gérer les erreurs en affichant le message d'erreur
                Console.WriteLine("Une erreur est survenue lors de la lecture du fichier : " + ex.Message);
            }
        }

        static void AjouterPrenom()
        {
            string fichierPrenom = "Prenom.txt";
            using (StreamReader reader = new StreamReader(fichierPrenom))
            {
                string line;
                //Lire chaque ligne du fichier
                while ((line = reader.ReadLine()) != null)
                {
                    //ajouter le nom de la liste
                    listPrenom.Add(line);
                }
            }
        }

        static public string FabriquerNom()
        {
            string nomPrenom = "";
            rand = new Random();
            Thread.Sleep(10);
            nomPrenom = listNom[rand.Next(0, listNom.Count() -1)] + " " + listPrenom[rand.Next(0, listPrenom.Count() -1)];
            return nomPrenom;
        }
    }
}

    

