using System;
using System.IO;
using System.Text.Json;
using MauiAppCoachV1.Core.Modele;

namespace MauiAppCoachV1.Core.Outils
{

	public static class Serializer
	{
		public static void serialize(string nomFichier, Profil profil)
		{
			string fichier = Path.Combine(
				System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
				nomFichier);

			if (File.Exists(fichier))
			{
				File.Delete(fichier);
			}

			try
			{
				// Serialize des objects de la collection
				string jsonString = JsonSerializer.Serialize(profil);

				// WriteAllText tronque et ecrit le fichier s'il existe deja
				File.WriteAllText(fichier, jsonString);

            }
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine("Erreur lors de la sérialisation: ");
            }

        }

		public static Profil? deserialize(string nomFichier)
		{
			Profil? profil = null;

			string fichier = Path.Combine(
				System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
				nomFichier);
			if (File.Exists(fichier))
			{
				try
				{
					//Lecture du fichier
					string jsonString = File.ReadAllText(fichier);

					// Deserialize des objects de la collection
					profil = JsonSerializer.Deserialize<Profil>(jsonString);
				}
				catch (Exception ex)
				{
					System.Diagnostics.Debug.WriteLine("Erreur lors de la désérialisation: ");
				}
			}
			return profil;
        }

		public static void SupprimerFichier(string nomFichier)
		{
			string fichier = Path.Combine(
				System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
				nomFichier);

			if (File.Exists(fichier))
			{
				try { File.Delete(fichier); } catch { }
			}
		}

    }
}