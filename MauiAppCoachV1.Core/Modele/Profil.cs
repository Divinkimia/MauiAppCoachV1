using System;
using System.Collections.Generic;
using System.Text;

namespace MauiAppCoachV1.Core.Modele
{
    public class Profil
    {
        private int sexe;      // 0 pour une Femme et 1 pour un homme
        private double poids;
        private double taille;
        private int age;
        private double img;    // Indice de Masse Grasse
        private string message = string.Empty; // Pour annoncer le résultat avec un commentaire



        public Profil(int sexe, double poids, double taille, int age)
        {
            this.sexe = sexe;
            this.poids = poids;
            this.taille = taille;
            this.age = age;

            // Calcul automatique de l'IMG et du message lors de l'instanciation
            CalculIMG();
            ResultatIMG();
        }


        private void CalculIMG()
        {
            // Convertir la taille de cm en mètres
            double tailleEnMetres = taille / 100.0;

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

        //  La propriétés en lecture seule
        public int Sexe => sexe;
        public double Poids => poids;
        public double Taille => taille;
        public int Age => age;
        public double Img => img;
        public string Message => message;
    }
}