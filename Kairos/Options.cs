using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FichesT
{
    public class Options
    {
        public string nomOption {  get; set; }
        public Color couleur { get; set; }
        public string niveauOption { get; set; }

        public Options(string nom)
        {
            nomOption = nom;

            if (!String.IsNullOrEmpty(nom))
            {
                if (nom == "Upe2a")
                {
                    couleur = Color.SaddleBrown;
                    niveauOption = "Option1";
                }
                else if (nom == "Ulis")
                {
                    couleur = Color.Orange;
                    niveauOption = "Option1";
                }
                else if (nom == "Segpa")
                {
                    couleur = Color.FromArgb(154, 83, 108);
                    niveauOption = "Option1";
                }
                else if (nom.Contains("Angl"))
                {
                    //nomOption = "Anglais";
                    couleur = Color.Green;

                    if (nom.Contains("LV1"))
                    {
                        niveauOption = "LV1";
                    }
                    else
                    {
                        niveauOption = "Option1";
                    }
                }
                else if (nom.Contains("All"))
                {
                    //nomOption = "Allemand";
                    couleur = Color.DarkBlue;

                    if (nom.Contains("LV1"))
                    {
                        niveauOption = "LV1";
                    }
                    else
                    {
                        niveauOption = "Option1";
                    }
                }
                else if (nom.Contains("Esp"))
                {
                    //nomOption = "Espagnol";
                    couleur = Color.Purple;

                    if (nom.Contains("LV1"))
                    {
                        niveauOption = "LV1";
                    }
                    else
                    {
                        niveauOption = "Option1";
                    }
                }
                else if (nom.Contains("Ita"))
                {
                    //nomOption = "Italien";
                    couleur = Color.LightGreen;

                    if (nom.Contains("LV1"))
                    {
                        niveauOption = "LV1";
                    }
                    else
                    {
                        niveauOption = "Option1";
                    }
                }
                else if (nom.Contains("Russe"))
                {
                    //nomOption = "Russe";
                    couleur = Color.Red;

                    if (nom.Contains("LV1"))
                    {
                        niveauOption = "LV1";
                    }
                    else
                    {
                        niveauOption = "Option1";
                    }
                }
                else if (nom.Contains("Arabe"))
                {
                    nomOption = "Arabe";
                    couleur = Color.Green;

                    if (nom.Contains("LV1"))
                    {
                        niveauOption = "LV1";
                    }
                    else
                    {
                        niveauOption = "Option1";
                    }
                }
                else if (nom.Contains("Chinois"))
                {
                    //nomOption = "Chinois";
                    couleur = Color.Yellow;

                    if (nom.Contains("LV1"))
                    {
                        niveauOption = "LV1";
                    }
                    else
                    {
                        niveauOption = "Option1";
                    }
                }
                else if (nom.Contains("Latin"))
                {
                    if (!nom.Contains("Grec"))
                    {
                        nomOption = "Latin";
                        couleur = Color.Black;
                    }
                    else
                    {
                        nomOption = "LatinEtGrec";
                        couleur = Color.White;
                    }
                    niveauOption = "Option2";
                }
                else if (nom.Contains("CulturesRe"))
                {
                    nomOption = "CulturesReg";
                    couleur = Color.Blue;
                    niveauOption = "Option2";
                }
                else if (nom.Contains("Bilingue"))
                {
                    couleur = Color.DeepPink;
                    niveauOption = "LV1";
                }
                else
                {
                    couleur = Color.Transparent;
                    niveauOption = "";
                }
            }
            else
            {
                couleur = Color.Transparent;
                niveauOption = "";
            }
        }

        public void MaJOption(Color nvlleCouleur)
        {
            couleur = nvlleCouleur;
        }
    }
}
