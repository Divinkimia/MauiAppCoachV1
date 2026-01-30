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
                AfficherResultat(profil);
            }
            catch
            {
                await DisplayAlert("Erreur", "Veuillez saisir des valeurs valides", "OK");
            }
        }

       
        /// Affiche ou masque le résultat IMG (label + image) selon le profil fourni.
        /// <param name="profil">Profil avec le résultat à afficher, ou null pour masquer.</param>
        private void AfficherResultat(Profil? profil)
        {
            if (profil is null)
            {
                lblResultat.Text = string.Empty;
                lblResultat.IsVisible = false;
                imgResultat.Source = null;
                imgResultat.IsVisible = false;
                return;
            }

            lblResultat.Text = $"IMG : {profil.Img:F1}\n{profil.Message}";
            lblResultat.IsVisible = true;
            imgResultat.Source = profil.GetImageResultat();
            imgResultat.IsVisible = true;
        }

        private void btnReinitialiser_Clicked(object sender, EventArgs e)
        {
            entPoids.Text = string.Empty;
            entTaille.Text = string.Empty;
            entAge.Text = string.Empty;
            rbHomme.IsChecked = true;
            AfficherResultat(null);
        }
    }
}
