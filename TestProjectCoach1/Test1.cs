using Microsoft.VisualStudio.TestTools.UnitTesting;
using MauiAppCoachV1.Core.Modele;
using System;

namespace TestProjectCoach1
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void CalculIMG_Homme_RetourneValeurPositive()
        {
            // Arrange
            Profil profil = new Profil(
                unId: null,
                uneDate: DateTimeOffset.Now,
                unSexe: 1,     // Homme
                unPoids: 80,
                uneTaille: 180,
                unAge: 30
            );

            // Act
            double img = profil.Img;

            // Assert
            Assert.IsGreaterThan(img, 0, "L'IMG doit être positif");
        }

        [TestMethod]
        public void ResultatIMG_Homme_Parfait()
        {
            
            Profil profil = new Profil(
                unId: null,
                uneDate: DateTimeOffset.Now,
                unSexe: 1,     // Homme
                unPoids: 75,
                uneTaille: 180,
                unAge: 25
            );

            
            string message = profil.Message;

            
            Assert.AreEqual("Parfait.", message);
        }

        [TestMethod]
        public void ResultatIMG_Femme_Surpoids()
        {
           
            Profil profil = new Profil(
                unId: null,
                uneDate: DateTimeOffset.Now,
                unSexe: 0,     // Femme
                unPoids: 85,
                uneTaille: 165,
                unAge: 35
            );

           
            string message = profil.Message;

           
            Assert.AreEqual("Surpoids.", message);
        }

        [TestMethod]
        public void Constructeur_AssigneCorrectementLesValeurs()
        {
            
            Profil profil = new Profil(null, DateTimeOffset.Now, 1, 70, 175, 28);

            
            Assert.AreEqual(1, profil.Sexe);
            Assert.AreEqual(70, profil.Poids);
            Assert.AreEqual(175, profil.Taille);
            Assert.AreEqual(28, profil.Age);
        }
    }
}




