using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitaire;

namespace TravailPartique3
{
    class MenuPlats
    {
        public List<Plat> Éléments { set; get; }

        public void Démarrer()
        {
            AfficherOptions();
            TraiterChoixUtilisateur(ObtenirChoixUtilisateur());
        }

        public MenuPlats()
        {
            Éléments = new List<Plat>();
        }

        private void AfficherOptions()
        {
            Console.WriteLine("\nBienvenue !\n\n");
            Console.WriteLine(
                "Voici les options disponibles : \n" +
                "   1. Ajouter un nouveau plat\n" +
                "   2. Afficher la liste des plats\n" +
                "   3. Renommer un plat\n" +
                "   4. Supprimer la liste des plats\n" +
                "   5. Sauvegarder et quitter\n");
        }

        private int ObtenirChoixUtilisateur()
        {
            return Entrées.LireTouche<int>(choix => choix <= 5 && choix >= 1);
        }

        private void TraiterChoixUtilisateur(int p_optionChoisie)
        {
            switch (p_optionChoisie)
            {
                case 1:
                    AjouterÉlément();
                    break;
                case 2:
                    AfficherÉléments();
                    break;
                case 3:
                    break;
                case 4:
                    EffacerÉléments();
                    break;
                case 5:
                    Program.Instance.EstEnMarche = false;
                    break;
            }
        }

        private void AfficherÉléments()
        {
            if (Éléments.Count > 0)
                Vecteurs.LireÉléments<Plat>(Éléments);
            else
                Console.WriteLine("Il n'y a aucun plat dans la liste.");

        }

        private void AjouterÉlément()
        {
            string nomNouvelÉlément = ObtenirNouvelÉlément();
            Plat nouveauPlat = new Plat(nomNouvelÉlément, Éléments.Count + 1);
            Éléments.Add(nouveauPlat);
        }

        private void EffacerÉléments()
        {
            Console.WriteLine("Tous les éléments seront effacés. Désirez vous continuer ? (O ou N)");
            char réponse = Entrées.LireTouche<char>(c => Char.ToUpper(c) == 'O' || Char.ToUpper(c) == 'N');
            if(Char.ToUpper(réponse) == 'O')
            {
                Console.WriteLine("Les éléments sont maintenant effacés.");
                Éléments = new List<Plat>();
            }                
        }

        private string ObtenirNouvelÉlément()
        {
            Console.WriteLine("Veuillez entrer le nom du nouveau plat que vous désirez ajouter : ");
            string élément;
            for(; ; )
            {
                élément = Entrées.Lire<string>(s => s.Length > 0);
                /***/
                if (!ÉlémentExiste(élément)) return élément;
                /***/
                Console.WriteLine("Ce plat existe déjà. Veuillez choisir un nom unique.");
            }
        }

        private bool ÉlémentExiste(string p_nom)
        {
            foreach(Plat élément in Éléments)
            {
                if (élément.Nom == p_nom) return true;
            }
            return false;
        }
    }
}
