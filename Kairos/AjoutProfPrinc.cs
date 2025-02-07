using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FichesT
{
    public partial class AjoutProfPrinc : Form
    {
        public AjoutProfPrinc()
        {
            InitializeComponent();
        }

        private void btnOuvrirFIchierCsv_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "csv files (*.csv)|*.csv";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    var reader = new StreamReader(openFileDialog1.FileName);
                    while (!reader.EndOfStream)
                    {
                        var ligne = reader.ReadLine();
                        var colonnes = ligne.Split(',');
                        var civilite = colonnes[0];
                        var nom = colonnes[1];
                        var prenom = colonnes[2];
                        var nomPrenomProf = civilite + " " + nom + " " + prenom;
                        Global.listeNomEtPrenomProf.Add(nomPrenomProf);
                    }
                }

                foreach (String xString in Global.listeNomEtPrenomProf)
                {
                    if (xString == "Civilité Nom d'usage Prénom" || xString == "Civilité Prénom Nom d'usage" || xString == "Civilit� Pr�nom Nom d'usage"
                        || xString == "Civilit� Nom d'usage Pr�nom")
                    {
                        Global.listeNomEtPrenomProf.Remove(xString);
                        break;
                    }
                }
                this.Close();
                MessageBox.Show("L'importation des professeurs est terminé.");
            }
            catch (Exception erreur)
            {
                MessageBox.Show(erreur.ToString());
            }
        }

        private void btnAnnulerOuvertureCsv_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AjoutProfPrinc_Load(object sender, EventArgs e)
        {

        }
    }
}
