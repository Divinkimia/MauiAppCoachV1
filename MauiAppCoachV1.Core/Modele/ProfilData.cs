using System.Text.Json.Serialization;

namespace MauiAppCoachV1.Core.Modele
{
   
    /// Classe de données pour la sérialisation JSON du profil.
    /// Permet de sauvegarder et restaurer les données du profil utilisateur.
    public class ProfilData
    {
        [JsonPropertyName("sexe")]
        public int Sexe { get; set; }

        [JsonPropertyName("poids")]
        public double Poids { get; set; }

        [JsonPropertyName("taille")]
        public double Taille { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }
    }
}
