using MauiAppCoachV1.Core.Modele;
using System.Threading.Tasks;


namespace MauiAppCoachV1
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCalculerClicked(object sender, EventArgs e)
        {
            try
            {
                double poids = double.Parse(entPoids.Text);
                double taille = double.Parse(entTaille.Text);
                int age = int.Parse(entAge.Text);

                int sexe = rbHomme.IsChecked ? 1 : 0;

                Profil profil = new Profil(sexe, poids, taille, age);

                lblResultat.Text = $"IMG : {profil.Img:F1}\n{profil.Message}";
                lblResultat.IsVisible = true;

                if (profil.Message.Contains("Surpoids"))
                    imgResultat.Source = "surpoids.png";
                else if (profil.Message.Contains("Trop maigre"))
                    imgResultat.Source = "maigre.png";
                else if (profil.Message.Contains("Parfait"))
                    imgResultat.Source = "parfait.png";

                imgResultat.IsVisible = true;
            }
            catch
            {
                await DisplayAlert("Erreur", "Veuillez saisir des valeurs valides", "OK");
            }
        }


        private void btnReinitialiser_Clicked(object sender, EventArgs e)
        {

        }
    }
}
