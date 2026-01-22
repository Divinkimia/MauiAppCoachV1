using System.Diagnostics;
using MauiAppCoachV1.Modele;


namespace MauiAppCoachV1.Tests
{
    public static class ProfilTests
    {
        public static void Run()
        {
            TestCalculIMG();
            TestResultatIMG();
        }

        private static void TestCalculIMG()
        {
            Profil profil = new Profil(1, 80, 180, 30);

            double attendu =
                (1.2 * 80 / (1.8 * 1.8))
                + (0.23 * 30)
                - 10.83
                - 5.4;

            Debug.Assert(
                Math.Abs(profil.Img - attendu) < 0.01,
                "Erreur calcul IMG"
            );
        }

        private static void TestResultatIMG()
        {
            Profil profil = new Profil(0, 85, 165, 40);

            Debug.Assert(
                profil.Message == "Surpoids.",
                "Erreur résultat IMG"
            );
        }
    }
}
