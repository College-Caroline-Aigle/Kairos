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
    public partial class ChangementClasseEleve : Form
    {
        public ChangementClasseEleve()
        {
            InitializeComponent();
        }

        private void ChangementClasseEleve_Load(object sender, EventArgs e)
        {
            foreach (Niveau unNiveau in Global.lesNiveaux)
            {
                foreach (Classe uneClasse in unNiveau.getLesClasse().OrderByDescending(classe => classe.nomDeLaClasse).ToList())
                    cbbClasse.Items.Add(uneClasse.nomDeLaClasse);
            }
            foreach (Niveau unNiveau in Global.lesNiveaux)
            {
                foreach (Classe uneClasse in unNiveau.getLesClasse().OrderByDescending(classe => classe.nomDeLaClasse).ToList())
                    cbbNewClasse.Items.Add(uneClasse.nomDeLaClasse);
            }
            cbbEleve.Items.Clear();
        }
        private void cbbClasse_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbbEleve.Items.Clear();
            if (cbbClasse.Text.Substring(0, 1) == "6")
            {
                foreach (Eleve lEleve in Global.lesNiveaux[0].getClasse(cbbClasse.Text, Global.lesNiveaux[0].getLesClasse()).getLesEleves().OrderBy(eleve => eleve.nomEleve).ToList())
                    cbbEleve.Items.Add(lEleve.nomEleve + " " + lEleve.prenomEleve);
            }
            else if (cbbClasse.Text.Substring(0, 1) == "5")
            {
                foreach (Eleve lEleve in Global.lesNiveaux[1].getClasse(cbbClasse.Text, Global.lesNiveaux[1].getLesClasse()).getLesEleves().OrderBy(eleve => eleve.nomEleve).ToList())
                    cbbEleve.Items.Add(lEleve.nomEleve + " " + lEleve.prenomEleve);
            }
            else if (cbbClasse.Text.Substring(0, 1) == "4")
            {
                foreach (Eleve lEleve in Global.lesNiveaux[2].getClasse(cbbClasse.Text, Global.lesNiveaux[2].getLesClasse()).getLesEleves().OrderBy(eleve => eleve.nomEleve).ToList())
                    cbbEleve.Items.Add(lEleve.nomEleve + " " + lEleve.prenomEleve);
            }
            else if (cbbClasse.Text.Substring(0, 1) == "3")
            {
                foreach (Eleve lEleve in Global.lesNiveaux[3].getClasse(cbbClasse.Text, Global.lesNiveaux[3].getLesClasse()).getLesEleves().OrderBy(eleve => eleve.nomEleve).ToList())
                    cbbEleve.Items.Add(lEleve.nomEleve + " " + lEleve.prenomEleve);
            }
            else if (cbbClasse.Text.Substring(0, 1) == "2")
            {
                foreach (Eleve lEleve in Global.lesNiveaux[4].getClasse(cbbClasse.Text, Global.lesNiveaux[4].getLesClasse()).getLesEleves().OrderBy(eleve => eleve.nomEleve).ToList())
                    cbbEleve.Items.Add(lEleve.nomEleve + " " + lEleve.prenomEleve);
            }
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            string message;
            string[] nomPrenom = cbbEleve.Text.Split(' ');

            if (cbbClasse.Text != "" | cbbEleve.Text != "" | cbbNewClasse.Text != "")
            {
                Classe laNouvelleClasse;
                if (cbbNewClasse.Text.Substring(0, 1) == "6")
                    laNouvelleClasse = Global.lesNiveaux[0].getClasse(cbbNewClasse.Text, Global.lesNiveaux[0].getLesClasse());
                else if (cbbNewClasse.Text.Substring(0, 1) == "5")
                    laNouvelleClasse = Global.lesNiveaux[1].getClasse(cbbNewClasse.Text, Global.lesNiveaux[1].getLesClasse());
                else if (cbbNewClasse.Text.Substring(0, 1) == "4")
                    laNouvelleClasse = Global.lesNiveaux[2].getClasse(cbbNewClasse.Text, Global.lesNiveaux[2].getLesClasse());
                else if (cbbNewClasse.Text.Substring(0, 1) == "3")
                    laNouvelleClasse = Global.lesNiveaux[3].getClasse(cbbNewClasse.Text, Global.lesNiveaux[3].getLesClasse());
                else if (cbbNewClasse.Text.Substring(0, 1) == "2")
                    laNouvelleClasse = Global.lesNiveaux[4].getClasse(cbbNewClasse.Text, Global.lesNiveaux[4].getLesClasse());
                else
                {
                    laNouvelleClasse = null;
                    message = "Erreur avec la classe de destination";
                    SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\Windows Background.wav");
                    simpleSound.Play();
                    MessageBox.Show(message);
                }

                if (cbbClasse.Text.Substring(0, 1) == "6")
                {
                    Classe laClasse = Global.lesNiveaux[0].getClasse(cbbClasse.Text, Global.lesNiveaux[0].getLesClasse());
                    Eleve lEleve = laClasse.getEleve(nomPrenom[0], nomPrenom[1], laClasse.getLesEleves());
                    laNouvelleClasse.getLesEleves().Add(lEleve);
                    Global.lesNiveaux[0].getClasse(cbbClasse.Text, Global.lesNiveaux[0].getLesClasse()).getLesEleves().Remove(lEleve);
                    this.Close();
                }
                else if (cbbClasse.Text.Substring(0, 1) == "5")
                {
                    Classe laClasse = Global.lesNiveaux[1].getClasse(cbbClasse.Text, Global.lesNiveaux[1].getLesClasse());
                    Eleve lEleve = laClasse.getEleve(nomPrenom[0], nomPrenom[1], laClasse.getLesEleves());
                    laNouvelleClasse.getLesEleves().Add(lEleve);
                    Global.lesNiveaux[1].getClasse(cbbClasse.Text, Global.lesNiveaux[1].getLesClasse()).getLesEleves().Remove(lEleve);
                    this.Close();
                }
                else if (cbbClasse.Text.Substring(0, 1) == "4")
                {
                    Classe laClasse = Global.lesNiveaux[2].getClasse(cbbClasse.Text, Global.lesNiveaux[2].getLesClasse());
                    Eleve lEleve = laClasse.getEleve(nomPrenom[0], nomPrenom[1], laClasse.getLesEleves());
                    laNouvelleClasse.getLesEleves().Add(lEleve);
                    Global.lesNiveaux[2].getClasse(cbbClasse.Text, Global.lesNiveaux[2].getLesClasse()).getLesEleves().Remove(lEleve);
                    this.Close();
                }
                else if (cbbClasse.Text.Substring(0, 1) == "3")
                {
                    Classe laClasse = Global.lesNiveaux[3].getClasse(cbbClasse.Text, Global.lesNiveaux[3].getLesClasse());
                    Eleve lEleve = laClasse.getEleve(nomPrenom[0], nomPrenom[1], laClasse.getLesEleves());
                    laNouvelleClasse.getLesEleves().Add(lEleve);
                    Global.lesNiveaux[3].getClasse(cbbClasse.Text, Global.lesNiveaux[3].getLesClasse()).getLesEleves().Remove(lEleve);
                    this.Close();
                }
                else if (cbbClasse.Text.Substring(0, 1) == "2")
                {
                    Classe laClasse = Global.lesNiveaux[4].getClasse(cbbClasse.Text, Global.lesNiveaux[4].getLesClasse());
                    Eleve lEleve = laClasse.getEleve(nomPrenom[0], nomPrenom[1], laClasse.getLesEleves());
                    laNouvelleClasse.getLesEleves().Add(lEleve);
                    Global.lesNiveaux[4].getClasse(cbbClasse.Text, Global.lesNiveaux[4].getLesClasse()).getLesEleves().Remove(lEleve);
                    if (cbbNewClasse.Text.Substring(0, 1) != "2")
                    {
                        if (Global.nbElevesReal > 0)
                            Global.nbElevesReal++;
                        else
                            Global.nbEleves++;
                    }
                    this.Close();
                }
            }
            else if (Global.nbEleves < 50)
            {
                message = "Erreur lors de l'opération.\nVeuillez vérifier qu'un fichier d'élèves à été enregistré.";
                SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\Windows Background.wav");
                simpleSound.Play();
                MessageBox.Show(message);
            }
            else
            {
                message = "Erreur lors de l'opération.\nVeuillez vérifier les informations.";
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
