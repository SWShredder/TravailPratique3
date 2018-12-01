/*
 *      Auteur: Yanik Sweeney
 *      Dernière modification: 01/12/2018
 * 
 *      Ce programme gère une liste de plats et les ingredients nécessaires pour les réaliser.
 *      Le programme calcule la valeur calorifique d'un plat à partir des ingrédients de celui-ci et
 *      permet à l'usager de faires des opérations sur la liste de plats enregistrés
 * 
 */

using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace TravailPartique3
{

    class Program
    {
        const string NomFichierEnregistrement = "données.bin";
        public List<Plat> VecteurPlats { set; get; }

        static void Main(string[] args)
        {
            new Program().Principale();
        }

        private void Principale()
        {
            VecteurPlats = new List<Plat>()
            {
                new Plat("Bonjour", 1),
                new Plat("Brownies au chocolat", 2),
                new Plat("Soufflé", 3)
            };

            Console.WriteLine("Voulez vous enregistrer le fichier (O ou N) ?");
            char caractère = Convert.ToChar(Console.ReadLine());

            if(caractère == 'O')
            {
                SauvegarderFichier<List<Plat>>(VecteurPlats);
                var nouvelleListe = LireFichier<List<Plat>>(NomFichierEnregistrement);
                //LireListe<List<Plat>>(nouvelleListe);
                LireListe2(nouvelleListe);
            }
            
        }


        private void SauvegarderFichier<T>(T p_objet)
        {
            using (Stream flux = File.Open(NomFichierEnregistrement, FileMode.Create))
            {
                BinaryFormatter formateur = new BinaryFormatter();
                formateur.Serialize(flux, p_objet);
            }
        }

        private T LireFichier<T>(string nomFichier)
        {
            using (Stream flux = File.Open(nomFichier, FileMode.Open))
            {
                BinaryFormatter formateur = new BinaryFormatter();

                T objetChargé = (T)formateur.Deserialize(flux);
                return objetChargé;
            }
        }

        private void LireListe<T>(T p_vecteur) where T : IEnumerable
        {
            foreach(T objet in p_vecteur)
            {
                Console.WriteLine(objet);
            }
        }

        private void LireListe2(List<Plat> p_vecteur)
        {
            foreach (Plat objet in p_vecteur)
            {
                Console.WriteLine(objet);
            }
        }
    }
}
