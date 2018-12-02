using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Utilitaire
{
    public static class Entrées
    {
        public static T LireTouche<T>() where T : IConvertible
        {
            T touche;
            for(; ; )
            {
                try
                {
                    touche = (T)Convert.ChangeType(Convert.ToString(Console.ReadKey(true).KeyChar), typeof(T));
                    /***/
                    if (touche is T) return touche;
                    /***/
                }
                catch
                {
                    Console.WriteLine("La touche sur laquelle vous avez appuyé n'est pas valide. Veuilez essayer à nouveau.");
                }
            }
        }

        public static T LireTouche<T>(Predicate<T> p_condition) where T : IConvertible
        {
            T touche;
            for (; ; )
            {
                touche = LireTouche<T>();
                /***/
                if (p_condition(touche)) break;
                /***/ 
                Console.WriteLine("Veuilez appuyer sur une touche valide");
            }
            return touche;
        }

        public static T Lire<T>() where T : IConvertible
        {
            T lecture;
            for(; ; )
            {
                try
                {
                    lecture = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                    return lecture;
                }
                catch
                {
                    Console.WriteLine("La donnée entrée n'est pas valide. Veuillez essayer à nouveau.");
                }
            }
        }

        public static T Lire<T>(Predicate<T> p_condition) where T : IConvertible
        {
            T valeurConvertie;
            for(; ; )
            {
                valeurConvertie = Lire<T>();
                /***/
                if (p_condition(valeurConvertie)) break;
                /***/
                Console.WriteLine("Veuillez entrer une valeur {0} valide", typeof(T));
            }
            return valeurConvertie;
        }
    }
    /// <summary>
    /// Class regroupant des méthodes utiles et génériques pour pouvoir manipuler des vecteurs.
    /// </summary>
    public static class Vecteurs
    {
        /// <summary>
        /// Méthode générique servant à afficher dans la console tous les éléments d'un vecteur générique.
        /// </summary>
        /// <typeparam name="T">Représente le type d'objet contenu dans le vecteur générique</typeparam>
        /// <param name="p_vecteur">Représente le vecteur duquel les éléments seront affichés</param>
        public static void LireÉléments<T>(List<T> p_vecteur)
        {
            foreach (T element in p_vecteur)
            {
                Console.WriteLine(element);
            }
        }
    }
    /// <summary>
    /// Classe regroupant plusieurs méthodes statiques utiles et génériques pour la sérialisation et
    /// la désérialisation d'objets.
    /// </summary>
    public static class Fichiers
    {
        /// <summary>
        /// Méthode servant à sérialiser un objet dans un fichier avec un formatage binaire.
        /// </summary>
        /// <typeparam name="T">Type qui représente le type de l'objet à sérialiser</typeparam>
        /// <param name="p_objet">L'objet à sérialiser</param>
        /// <param name="p_nomFichier">Un string qui représente le nom du fichier dans lequel l'objet sera sérialisé</param>
        public static void Sauvegarder<T>(T p_objet, string p_nomFichier)
        {
            using (FileStream flux = File.Open(p_nomFichier, FileMode.Create))
            {
                BinaryFormatter formateur = new BinaryFormatter();
                formateur.Serialize(flux, p_objet);
            }
        }
        /// <summary>
        /// Méthode servant à désérialiser un objet provenant d'un fichier encodé en binaire par
        /// la méthode système BinaryFormatter
        /// </summary>
        /// <typeparam name="T">Un type représentant le type de l'objet à désérialiser</typeparam>
        /// <param name="p_nomFichier">Un string représentant le nom du fichier à désérialiser</param>
        /// <returns>Retourne un objet issue de la désérialisation</returns>
        public static T Lire<T>(string p_nomFichier)
        {
            using (FileStream flux = File.Open(p_nomFichier, FileMode.Open))
            {
                BinaryFormatter formateur = new BinaryFormatter();

                T objetChargé = (T)formateur.Deserialize(flux);
                return objetChargé;
            }
        }
    }
}
