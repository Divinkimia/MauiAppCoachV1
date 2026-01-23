using Microsoft.VisualStudio.TestTools.UnitTesting;
using MauiAppCoachV1.Core.Modele;

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
                sexe: 1,     // Homme
                poids: 80,
                taille: 180,
                age: 30
            );

            // Act
            double img = profil.Img;

            // Assert
            Assert.IsTrue(img > 0, "L'IMG doit être positif");
        }

        [TestMethod]
        public void ResultatIMG_Homme_Parfait()
        {
            
            Profil profil = new Profil(
                sexe: 1,     // Homme
                poids: 75,
                taille: 180,
                age: 25
            );

            
            string message = profil.Message;

            
            Assert.AreEqual("Parfait.", message);
        }

        [TestMethod]
        public void ResultatIMG_Femme_Surpoids()
        {
           
            Profil profil = new Profil(
                sexe: 0,     // Femme
                poids: 85,
                taille: 165,
                age: 35
            );

           
            string message = profil.Message;

           
            Assert.AreEqual("Surpoids.", message);
        }

        [TestMethod]
        public void Constructeur_AssigneCorrectementLesValeurs()
        {
            
            Profil profil = new Profil(1, 70, 175, 28);

            
            Assert.AreEqual(1, profil.Sexe);
            Assert.AreEqual(70, profil.Poids);
            Assert.AreEqual(175, profil.Taille);
            Assert.AreEqual(28, profil.Age);
        }
    }
}




