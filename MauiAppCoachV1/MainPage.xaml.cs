using MauiAppCoachV1.Core.Modele;
using MauiAppCoachV1.Core.Outils;


namespace MauiAppCoachV1
{
    public partial class MainPage : ContentPage
    {
        private Profil unProfil = null;
        private readonly SQLiteDb SQLiteDbCoach = null;

        private const string NomFichierProfil = "saveprofil"; // fichier pour la serialisation

        public MainPage()
        {
            InitializeComponent();
            SQLiteDbCoach = new SQLiteDb();
            SqliteSelect();
        }

        private async void SqliteSelect()
        {
            unProfil = await SQLiteDbCoach.GetLastItemQueryAsync();
            if (unProfil != null)
            {
                entPoids.Text = unProfil.Poids.ToString();
                entTaille.Text = unProfil.Taille.ToString();
                entAge.Text = unProfil.Age.ToString();

                if (unProfil.Sexe == 1)
                {
                    rbHomme.IsChecked = true;
                }
                else if (unProfil.Sexe == 0)
                {
                    rbFemme.IsChecked = true;
                }

                // affichage du résultat 
                AfficherResultat(unProfil);
            }


        }
        /*
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ChargerProfilSauvegarde();
        }
      

        
        /// Charge le profil sauvegardé depuis le fichier et restaure les champs du formulaire.
        private void ChargerProfilSauvegarde()
        {
            Profil? profil = Serializer.deserialize(NomFichierProfil);
            if (profil != null)
            {
                entPoids.Text = profil.Poids.ToString();
                entTaille.Text = profil.Taille.ToString();
                entAge.Text = profil.Age.ToString();
                rbHomme.IsChecked = profil.Sexe == 1;
                rbFemme.IsChecked = profil.Sexe == 0;
                AfficherResultat(profil);
            }
        }
          */


        private async void OnCalculerClicked(object sender, EventArgs e)
        {
            try
            {  
                var poids = double.Parse(entPoids.Text);
                var taille = double.Parse(entTaille.Text);
                var age = int.Parse(entAge.Text);
                var sexe = 0;
                if (rbHomme.IsChecked)
                {
                    sexe = 1;
                }
                else if (rbFemme.IsChecked)
                {
                    sexe = 0;
                }

                DateTimeOffset dateMesure = DateTimeOffset.Now;
                Profil unProfil = new Profil(null, dateMesure, sexe, poids, taille, age);

                AfficherResultat(unProfil);
            }
            catch
            {
                await DisplayAlertAsync("Erreur", "Veuillez saisir des valeurs valides", "OK");
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

        private void BtnReinitialiser_Clicked(object sender, EventArgs e)
        {
            entPoids.Text = string.Empty;
            entTaille.Text = string.Empty;
            entAge.Text = string.Empty;
            rbHomme.IsChecked = true;
            AfficherResultat(null);

            // Supprimer le fichier profil sauvegardé (supp sans avoir à effacer le cahe action précédant 
            //Serializer.SupprimerFichier(NomFichierProfil);
        }
    }
}
