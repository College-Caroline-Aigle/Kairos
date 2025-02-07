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
    public partial class RenommerClasse : Form
    {
        List<Classe> listeDesClasses = new List<Classe>();

        public RenommerClasse()
        {
            InitializeComponent();
        }

        private void RenommerClasse_Load(object sender, EventArgs e)
        {
            foreach (Niveau unNiveau in Global.lesNiveaux)
            {
                foreach (Classe uneClasse in unNiveau.getLesClasse())
                {
                    listeDesClasses.Add(uneClasse);
                    cmbClasse.Items.Add(uneClasse.nomDeLaClasse);
                }
            }
        }

        private void cmbClasse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbxNouveaNomClasse_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            string ancienNom = cmbClasse.Text;
            if(tbxNouveaNomClasse.Text != "" && (tbxNouveaNomClasse.Text.StartsWith("6") || tbxNouveaNomClasse.Text.StartsWith("5") || tbxNouveaNomClasse.Text.StartsWith("4") || tbxNouveaNomClasse.Text.StartsWith("3")))
            {
                string nouvNom = tbxNouveaNomClasse.Text;
                foreach(Classe xClasse in listeDesClasses)
                {
                    if(xClasse.nomDeLaClasse == ancienNom)
                    {
                        MessageBox.Show("Le nom de la classe " + xClasse.nomDeLaClasse + " a été modifié par " + nouvNom);

                        if(ancienNom.First() != nouvNom.First())
                        {
                            Classe stockClasse = new Classe(nouvNom);
                            foreach (Niveau unNiveau in Global.lesNiveaux)
                            {
                                if (unNiveau.nomDuNiveau.Contains(ancienNom.First().ToString()))
                                {
                                    List<Classe> lesClasses = unNiveau.getLesClasse();
                                    for (int i = 0; i< lesClasses.Count; i++)
                                    {
                                        if (lesClasses[i].nomDeLaClasse == ancienNom)
                                        {
                                            stockClasse.nomProfPrinc = lesClasses[i].nomProfPrinc;
                                            stockClasse.setListEleve(lesClasses[i].getLesEleves());
                                            unNiveau.supprClasse(lesClasses[i]);
                                            break;
                                        }
                                    }
                                }
                            }

                            foreach (Niveau unNiveau in Global.lesNiveaux)
                            {
                                if (unNiveau.nomDuNiveau.Contains(nouvNom.First().ToString()))
                                {
                                    unNiveau.setLesClasses(stockClasse);
                                    break;
                                }
                            }

                            if(ancienNom.First() == '6')
                            {
                                Global.nomsClasses6e.Remove(ancienNom);

                                if(nouvNom.First() == '5')
                                {
                                    Global.nomsClasses5e.Add(nouvNom);
                                }
                                else if (nouvNom.First() == '4')
                                {
                                    Global.nomsClasses4e.Add(nouvNom);
                                }
                                else if (nouvNom.First() == '3')
                                {
                                    Global.nomsClasses3e.Add(nouvNom);
                                }
                            }
                            else if (ancienNom.First() == '5')
                            {
                                Global.nomsClasses5e.Remove(ancienNom);

                                if (nouvNom.First() == '6')
                                {
                                    Global.nomsClasses6e.Add(nouvNom);
                                }
                                else if (nouvNom.First() == '4')
                                {
                                    Global.nomsClasses4e.Add(nouvNom);
                                }
                                else if (nouvNom.First() == '3')
                                {
                                    Global.nomsClasses3e.Add(nouvNom);
                                }
                            }
                            else if (ancienNom.First() == '4')
                            {
                                Global.nomsClasses4e.Remove(ancienNom);

                                if (nouvNom.First() == '6')
                                {
                                    Global.nomsClasses6e.Add(nouvNom);
                                }
                                else if (nouvNom.First() == '5')
                                {
                                    Global.nomsClasses5e.Add(nouvNom);
                                }
                                else if (nouvNom.First() == '3')
                                {
                                    Global.nomsClasses3e.Add(nouvNom);
                                }
                            }
                            else if (ancienNom.First() == '3')
                            {
                                Global.nomsClasses3e.Remove(ancienNom);

                                if (nouvNom.First() == '6')
                                {
                                    Global.nomsClasses6e.Add(nouvNom);
                                }
                                else if (nouvNom.First() == '5')
                                {
                                    Global.nomsClasses5e.Add(nouvNom);
                                }
                                else if (nouvNom.First() == '4')
                                {
                                    Global.nomsClasses4e.Add(nouvNom);
                                }
                            }
                            else if (ancienNom.First() == '2')
                            {
                                Global.nomsClasses3e.Remove(ancienNom);

                                if (nouvNom.First() == '6')
                                {
                                    Global.nomsClasses6e.Add(nouvNom);
                                }
                                else if (nouvNom.First() == '5')
                                {
                                    Global.nomsClasses5e.Add(nouvNom);
                                }
                                else if (nouvNom.First() == '4')
                                {
                                    Global.nomsClasses4e.Add(nouvNom);
                                }
                                else if (nouvNom.First() == '3')
                                {
                                    Global.nomsClasses3e.Add(nouvNom);
                                }
                            }
                        }

                        foreach (Eleve el in Global.elevesValides)
                        {
                            if (el.classeEleve == ancienNom)
                            {
                                el.classeEleve = nouvNom;
                            }
                        }

                        for (int i = 0; i < Global.listeClasseEleve.Count; i++)
                        {
                            if (Global.listeClasseEleve[i] == ancienNom)
                            {
                                Global.listeClasseEleve[i] = nouvNom;
                            }
                        }

                        xClasse.nomDeLaClasse = nouvNom;

                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Le nom de la nouvelle classe doit commencer par un niveau de collège (6, 5, 4 ou 3)");
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
