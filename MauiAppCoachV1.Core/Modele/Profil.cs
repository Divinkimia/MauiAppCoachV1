using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MauiAppCoachV1.Core.Modele
{
    [Serializable]
    public class Profil
    {
        private readonly Nullable<int> id;         // Pour l'ajout de id pour base de données SQLite
        private DateTimeOffset datemesure;        // ajout de la date de la mesure
        private int sexe;                        // 0 pour une Femme et 1 pour un homme
        private double poids;
        private double taille;
        private int age;
        private double img;                     // Indice de Masse Grasse
        private string message = string.Empty; // Pour annoncer le résultat avec un commentaire


        public Profil(Nullable<int> unId, DateTimeOffset uneDate, int unSexe, double unPoids, double uneTaille, int unAge)
        {
            id = unId;
            datemesure = uneDate;
            sexe = unSexe;
            poids = unPoids;
            taille = uneTaille;
            age = unAge;
            // Calcul automatique de l'IMG et du message lors de l'instanciation
            CalculIMG();
            ResultatIMG();

        }


        [PrimaryKey, AutoIncrement] //Clé primaire et auto-incrémentée pour SQLite
        public int Id { get; set; }

        public DateTimeOffset DateMesure
        {
            get { return datemesure; }
            set { datemesure = value; }
        }

        public Profil()
        {
            datemesure = new DateTimeOffset();
            sexe = 0;
            poids = 0;
            taille = 0;
            age = 0;
            img = 0;
            message = "";
        }

        


       

        private void CalculIMG()
        {
            // Convertir la taille de cm en mètres
            double tailleEnMetres = taille / 100.0;

            // Protection contre la division par zéro ou taille invalide
            if (tailleEnMetres <= 0)
            {
                img = 0;
                message = "Taille invalide.";
                return;
            }

            // Calcule de l'img
            img = (1.2 * poids / (tailleEnMetres * tailleEnMetres)) + (0.23 * age) - (10.83 * sexe) - 5.4;
        }

        //  fournir le message en fonction de l'img et du sexe
        private void ResultatIMG()
        {
            if (sexe == 1) // Homme
            {
                if (img < 15)
                    message = "Trop maigre.";
                else if (img >= 15 && img <= 20)
                    message = "Parfait.";
                else // img > 20
                    message = "Surpoids.";
            }
            else // Femme (sexe == 0)
            {
                if (img < 25)
                    message = "Trop maigre.";
                else if (img >= 25 && img <= 30)
                    message = "Parfait.";
                else // img > 30
                    message = "Surpoids.";
            }
        }


        // FONCTION qui affiche le resultat de l'image en fonction du message
        public string GetImageResultat()
        {
            if (Message.Contains("Surpoids"))
                return "smiley_surpoids.png";

            if (Message.Contains("Trop maigre"))
                return "smiley_tropmaigre.png";

            if (Message.Contains("Parfait"))
                return "smiley_parfait.png";

            return "dotnet_bot.png";
        }

        //  La propriétés en lecture seule ( mes getters )

       
        public int Sexe
        {
            get { return sexe; }
            set { sexe = value;}
        }
        public double Poids
        {
            get { return poids; }
            set { poids = value;}
        }

        public double Taille
        {
            get { return taille; }
            set { taille = value;}
        }
        public int Age
        {
            get { return age; }
            set { age = value;}
        }
        public double Img
        {
            get { return img; }
            set { img = value; }
        }
        public string Message
        {
            get { return message; }
            set { message = value; }
        }
    }

}
