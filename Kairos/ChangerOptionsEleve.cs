using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FichesT
{
    public partial class ChangerOptionsEleve : Form
    {
        Eleve unEleve;
        public ChangerOptionsEleve(object sender)
        {
            unEleve = sender as Eleve;
            InitializeComponent();
        }

        private void ChangerOptionsEleve_Load(object sender, EventArgs e)
        {
            rdbLV1.Text += unEleve.LV1Eleve;
            rdbLV1.Tag = unEleve.LV1;
            rdbOption1.Text += unEleve.option1.nomOption;
            rdbOption1.Tag = unEleve.option1;
            rdbOption2.Text += unEleve.option2.nomOption;
            rdbOption2.Tag = unEleve.option2;

            foreach (Options option in Global.options)
            {
                if (option != null && !String.IsNullOrEmpty(option.nomOption))
                    cmbOptions.Items.Add(option.nomOption);
            }
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Niveau niv in Global.lesNiveaux)
                {
                    if (niv.nomDuNiveau.Contains(unEleve.classeEleve.Substring(0, 1)))
                    {
                        foreach (Classe cls in niv.getLesClasse())
                        {
                            if (cls.nomDeLaClasse == unEleve.classeEleve)
                            {
                                foreach (Eleve elv in cls.getLesEleves())
                                {
                                    if (elv == unEleve)
                                    {
                                        foreach (Options option in Global.options)
                                        {
                                            if (option.nomOption == cmbOptions.Text)
                                            {
                                                if (rdbLV1.Checked)
                                                {
                                                    elv.LV1 = option;
                                                    elv.LV1Eleve = option.nomOption;
                                                    MessageBox.Show("L'option LV1 " + elv.LV1Eleve + " a été changée en " + option.nomOption + ".\n Cliquez sur ACTUALISER.");
                                                    rdbLV1.Text = "LV1 : " + unEleve.LV1.nomOption;
                                                    rdbLV1.Tag = unEleve.LV1;
                                                }
                                                else if (rdbOption1.Checked)
                                                {
                                                    elv.option1 = option;
                                                    elv.option1Eleve = option.nomOption;
                                                    MessageBox.Show("L'option 1 " + elv.option1Eleve + " a été changée en " + option.nomOption + ".\n Cliquez sur ACTUALISER.");
                                                    rdbOption1.Text = "Option 1 : " + unEleve.option1.nomOption;
                                                    rdbOption1.Tag = unEleve.option1;
                                                }
                                                else if (rdbOption2.Checked)
                                                {
                                                    elv.option2 = option;
                                                    elv.option2Eleve = option.nomOption;
                                                    MessageBox.Show("L'option 2 " + elv.option2Eleve + " a été changée en " + option.nomOption + ".\n Cliquez sur ACTUALISER.");
                                                    rdbOption2.Text = "Option 2 : " + unEleve.option2.nomOption;
                                                    rdbOption2.Tag = unEleve.option2;
                                                }
                                                break;
                                            }
                                        }
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
