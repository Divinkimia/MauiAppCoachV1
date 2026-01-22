using MauiAppCoachV1.Modele;
using System.Threading.Tasks;

namespace MauiAppCoachV1
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
        }

        private async Task OnCounterClicked(object? sender, EventArgs e)
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
            }
            catch
            {
                await DisplayAlertAsync(
                 "Erreur",
                 "Veuillez saisir des valeurs valides",
                 "OK");
            }
        }
    }
}
