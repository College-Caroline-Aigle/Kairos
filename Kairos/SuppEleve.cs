using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace FichesT
{
    public partial class SuppEleve : Form
    {
        public SuppEleve()
        {
            InitializeComponent();
        }

        private void SuppEleve_Load(object sender, EventArgs e)
        {
            foreach (Niveau unNiveau in Global.lesNiveaux)
            {
                foreach (Classe uneClasse in unNiveau.getLesClasse())
                    cbbClasse.Items.Add(uneClasse.nomDeLaClasse);
            }
            cbbEleve.Items.Clear();
        }

        private void cbbClasse_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbbEleve.Items.Clear();
            if (cbbClasse.Text.Contains("6"))
            {
                foreach (Eleve lEleve in Global.lesNiveaux[0].getClasse(cbbClasse.Text, Global.lesNiveaux[0].getLesClasse()).getLesEleves())
                    cbbEleve.Items.Add(lEleve.nomEleve + " " + lEleve.prenomEleve);
            }
            else if (cbbClasse.Text.Contains("5"))
            {
                foreach (Eleve lEleve in Global.lesNiveaux[1].getClasse(cbbClasse.Text, Global.lesNiveaux[1].getLesClasse()).getLesEleves())
                    cbbEleve.Items.Add(lEleve.nomEleve + " " + lEleve.prenomEleve);
            }
            else if (cbbClasse.Text.Contains("4"))
            {
                foreach (Eleve lEleve in Global.lesNiveaux[2].getClasse(cbbClasse.Text, Global.lesNiveaux[2].getLesClasse()).getLesEleves())
                    cbbEleve.Items.Add(lEleve.nomEleve + " " + lEleve.prenomEleve);
            }
            else if (cbbClasse.Text.Contains("3"))
            {
                foreach (Eleve lEleve in Global.lesNiveaux[3].getClasse(cbbClasse.Text, Global.lesNiveaux[3].getLesClasse()).getLesEleves())
                    cbbEleve.Items.Add(lEleve.nomEleve + " " + lEleve.prenomEleve);
            }
        } 

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            string message;
            string[] nomPrenom = cbbEleve.Text.Split(' ');

            if (cbbClasse.Text != "" | cbbEleve.Text != "")
            {
                if (cbbClasse.Text.Contains("6"))
                {
                    Classe laClasse = Global.lesNiveaux[0].getClasse(cbbClasse.Text, Global.lesNiveaux[0].getLesClasse());
                    Eleve lEleve = laClasse.getEleve(nomPrenom[0], nomPrenom[1], laClasse.getLesEleves());
                    Global.lesNiveaux[0].getClasse(cbbClasse.Text, Global.lesNiveaux[0].getLesClasse()).getLesEleves().Remove(lEleve);
                    if (Global.nbElevesReal > 0)
                        Global.nbElevesReal--;
                    else
                        Global.nbEleves--;
                    this.Close();              
                }
                else if (cbbClasse.Text.Contains("5"))
                {
                    Classe laClasse = Global.lesNiveaux[1].getClasse(cbbClasse.Text, Global.lesNiveaux[1].getLesClasse());
                    Eleve lEleve = laClasse.getEleve(nomPrenom[0], nomPrenom[1], laClasse.getLesEleves());
                    Global.lesNiveaux[1].getClasse(cbbClasse.Text, Global.lesNiveaux[1].getLesClasse()).getLesEleves().Remove(lEleve);
                    if (Global.nbElevesReal > 0)
                        Global.nbElevesReal--;
                    else
                        Global.nbEleves--;
                    this.Close();
                }
                else if (cbbClasse.Text.Contains("4"))
                {
                    Classe laClasse = Global.lesNiveaux[2].getClasse(cbbClasse.Text, Global.lesNiveaux[2].getLesClasse());
                    Eleve lEleve = laClasse.getEleve(nomPrenom[0], nomPrenom[1], laClasse.getLesEleves());
                    Global.lesNiveaux[2].getClasse(cbbClasse.Text, Global.lesNiveaux[2].getLesClasse()).getLesEleves().Remove(lEleve);
                    if (Global.nbElevesReal > 0)
                        Global.nbElevesReal--;
                    else
                        Global.nbEleves--; 
                    this.Close();
                }
                else if (cbbClasse.Text.Contains("3"))
                {
                    Classe laClasse = Global.lesNiveaux[3].getClasse(cbbClasse.Text, Global.lesNiveaux[3].getLesClasse());
                    Eleve lEleve = laClasse.getEleve(nomPrenom[0], nomPrenom[1], laClasse.getLesEleves());
                    Global.lesNiveaux[3].getClasse(cbbClasse.Text, Global.lesNiveaux[3].getLesClasse()).getLesEleves().Remove(lEleve);
                    if (Global.nbElevesReal > 0)
                        Global.nbElevesReal--;
                    else
                        Global.nbEleves--; 
                    this.Close();
                }
            }
            else if (Global.nbEleves < 50)
            {
                message = "Erreur lors de la suppression.\nVeuillez vérifier qu'un fichier d'élèves à été enregistré.";
                SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\Windows Background.wav");
                simpleSound.Play();
                MessageBox.Show(message);
            }
            else
            {
                message = "Erreur lors de la suppression.\nVeuillez vérifier les informations.";
                SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\Windows Background.wav");
                simpleSound.Play();
                MessageBox.Show(message);
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
