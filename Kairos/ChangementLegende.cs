using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FichesT
{
    public partial class ChangementLegende : Form
    {
        List<Options> listeDesLegendes = Global.options;

        public ChangementLegende()
        {
            InitializeComponent();
        }

        private void ChangementLegende_Load(object sender, EventArgs e)
        {
            foreach(Options option in listeDesLegendes)
            {
                if(option != null && !String.IsNullOrEmpty(option.nomOption))
                    cmbLegende.Items.Add(option.nomOption);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = bntCouleur.BackColor;
            colorDialog1.ShowDialog();
            bntCouleur.BackColor = colorDialog1.Color;

        }

        private void cmbLegende_SelectedIndexChanged(object sender, EventArgs e)
        {
            Options optionChoisie = new Options(cmbLegende.Text);
            int indexOption = listeDesLegendes.FindIndex(r => r.nomOption == optionChoisie.nomOption);
            bntCouleur.BackColor = listeDesLegendes[indexOption].couleur;
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (tbxNvNom.Text != "")
            {
                for (int i = 0; i<listeDesLegendes.Count; i++)
                {
                    if (listeDesLegendes[i].nomOption == cmbLegende.Text)
                    {
                        MessageBox.Show("Le nom de la légende " + listeDesLegendes[i].nomOption + " a été modifié par " + tbxNvNom.Text + "! \n Cliquez sur le bouton ACTUALISER.");
                        listeDesLegendes[i].nomOption = tbxNvNom.Text;
                        listeDesLegendes[i].couleur = bntCouleur.BackColor;
                        if(cmbLegende.Text == tbxNvNom.Text)
                        {
                            foreach (Eleve el in Global.elevesValides)
                            {
                                
                                if (!String.IsNullOrEmpty(el.LV1.nomOption) && el.LV1.nomOption.Contains(cmbLegende.Text))
                                {
                                    el.LV1.MaJOption(bntCouleur.BackColor);
                                }
                                else if (!String.IsNullOrEmpty(el.LV1.nomOption) && el.LV1.nomOption.Contains(cmbLegende.Text.Substring(0,3)))
                                {
                                    el.LV1.MaJOption(bntCouleur.BackColor);
                                }

                                if (el.option1.nomOption.Contains(cmbLegende.Text))
                                {
                                    el.option1.MaJOption(bntCouleur.BackColor);
                                }
                                else if (el.option1.nomOption.Contains(cmbLegende.Text.Substring(0, 3)))
                                {
                                    el.option1.MaJOption(bntCouleur.BackColor);
                                }

                                if (el.option2.nomOption.Contains(cmbLegende.Text))
                                {
                                    el.option2.MaJOption(bntCouleur.BackColor);
                                }
                                else if (el.option2.nomOption.Contains(cmbLegende.Text.Substring(0, 3)) && !el.option2.nomOption.Contains("Latin"))
                                {
                                    el.option2.MaJOption(bntCouleur.BackColor);
                                }
                            }
                        }
                        break;
                    }
                }
                cmbLegende.Items.Clear();
                foreach (Options option in listeDesLegendes)
                {
                    cmbLegende.Items.Add(option.nomOption);
                }
            }
        }
    }
}
