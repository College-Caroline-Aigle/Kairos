using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FichesT
{
    internal class CopieImage
    {
        public static string dossierPhotos = "./data/photoEleve/";

        public static void CopieDossier(string cheminSource, string cheminDestination)
        {
            try
            {
                // Vérifie si le répertoire de destination n'existe pas, alors il le crée
                if (!Directory.Exists(cheminDestination))
                {
                    Directory.CreateDirectory(cheminDestination);
                }

                // Récupère tous les fichiers avec une extension d'image (.jpg, .png, etc.)
                string[] fichiers = Directory.GetFiles(cheminSource, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) || s.EndsWith(".png", StringComparison.OrdinalIgnoreCase)).ToArray();

                double numFile = 0;
                double nbFiles = fichiers.Length;

                // Copie chaque fichier vers le répertoire de destination
                foreach (string fichier in fichiers)
                {
                    string fileName = Path.GetFileName(fichier);
                    string destFile = Path.Combine(cheminDestination, fileName);
                    File.Copy(fichier, destFile, true);

                    // calcul et envoi du personnage d'avancement
                    double p = (numFile / nbFiles) * 100.0;
                    if (p < 0)
                        p = 0;
                    else if (p > 100)
                        p = 100;
                    numFile++;
                }

                MessageBox.Show("Images copiées avec succès !");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue : {ex.Message}");
            }
        }
        public static void CopierImage(string cheminSource, string cheminDestination)
        {
            /// <summary>
            /// Copies an image file from the source path to the destination path.
            /// </summary>
            try
            {
                if (File.Exists(cheminSource))
                {
                    string[] imageExtensions = { ".jpg", ".jpeg", ".png" };
                    string fileExtension = Path.GetExtension(cheminSource).ToLower();
                    if (!Directory.Exists(cheminDestination))
                    {
                        Directory.CreateDirectory(cheminDestination);
                    }

                    if (Array.Exists(imageExtensions, ext => ext == fileExtension))
                    {
                        string fileName = Path.GetFileName(cheminSource);
                        string destFile = Path.Combine(cheminDestination, fileName);
                        File.Copy(cheminSource, destFile, true);
                    }
                    else
                    {
                        MessageBox.Show("The specified file is not an image.");
                    }
                }
                else
                {
                    MessageBox.Show("Source file does not exist.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        public static void CopierImagesDossier(string cheminSource, string cheminDestination)
        {
            foreach(Niveau niv in Global.lesNiveaux)
            {
                string numClasse = niv.nomDuNiveau.Substring(2,1);
                try
                {
                    if (!Directory.Exists(cheminDestination))
                    {
                        Directory.CreateDirectory(cheminDestination);
                    }


                    string[] dossiers = Directory.GetDirectories(cheminSource, "*.*", SearchOption.TopDirectoryOnly).Where(chemin => Path.GetFileName(chemin).Substring(0,1)==numClasse).ToArray();
                    bool anyCopied = false;

                    double numDoss = 0;
                    double nbDoss = dossiers.Length;
                    foreach (string dossier in dossiers)
                    {
                        string[] fichiers = Directory.GetFiles(dossier, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) || s.EndsWith(".png", StringComparison.OrdinalIgnoreCase)).ToArray();

                        foreach (string fichier in fichiers)
                        {
                            string fileName = Path.GetFileName(fichier);
                            string destFile = Path.Combine(cheminDestination, fileName);
                            File.Copy(fichier, destFile, true);

                        }
                        // calcul et envoi du personnage d'avancement
                        double p = (numDoss / nbDoss) * 100.0;
                        if (p < 0)
                            p = 0;
                        else if (p > 100)
                            p = 100;
                        anyCopied = true;
                        numDoss++;
                    }

                    if (anyCopied)
                    {
                        MessageBox.Show("Images copiées avec succès !");
                    }
                    else
                    {
                        MessageBox.Show("Aucune image trouvée à copier.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Une erreur est survenue : {ex.Message}");
                }
            }
        }
    }
}
