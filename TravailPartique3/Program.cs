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
using Utilitaire;

namespace TravailPartique3
{

    class Program
    {
        const string NomProgramme = "Nom du Programme";
        const string NomFichierEnregistrement = "données.bin";

        static public Program Instance { private set;  get; }

        public bool EstEnMarche { set; get; }
        public MenuPlats MenuPlat { get; }

        static void Main(string[] args)
        {
            new Program().Principale();
        }

        public Program()
        {
            MenuPlat = new MenuPlats();
            MenuPlat.Éléments = Fichiers.Lire<List<Plat>>(NomFichierEnregistrement);            
            EstEnMarche = true;
            Instance = this;
        }

        private void Principale()
        {
            while (EstEnMarche)
            {
                MenuPlat.Démarrer();
            }
            Fichiers.Sauvegarder<List<Plat>>(MenuPlat.Éléments, NomFichierEnregistrement);
        }    
    }
}
