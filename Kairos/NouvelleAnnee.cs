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
    public partial class NouvelleAnnee : Form
    {
        public NouvelleAnnee()
        {
            InitializeComponent();
        }

        private void NouvelleAnnee_Load(object sender, EventArgs e)
        {
            Global.avancement = 1;
            Global.LeCompteur = 0;
            Global.rang = 0;
            for (int i = 0; i < 4; i++)
            {
                foreach (Classe uneClasse in Global.lesNiveaux[i].getLesClasse())
                {
                    List<Eleve> elevesASupprimer = new List<Eleve>();
                    foreach (Eleve unEleve in uneClasse.getLesEleves())
                    {
                        if (unEleve.classeEleve.Contains("6") || unEleve.classeEleve.Contains("5") || unEleve.classeEleve.Contains("4"))
                        {
                            Global.ElevesAll.Add(unEleve);
                            Global.LeCompteur++;
                        }
                        elevesASupprimer.Add(unEleve);
                    }
                    foreach (Eleve unEleve in elevesASupprimer)
                        uneClasse.getLesEleves().Remove(unEleve);
                }
            }
            Global.ElevesAll.Sort((u1, u2) => u1.nomEleve.CompareTo(u2.nomEleve));

            lblNomEleve.Text = Global.ElevesAll[Global.rang].nomEleve;
            lblPrenomEleve.Text = Global.ElevesAll[Global.rang].prenomEleve;

            lblCompteur2.Text = Global.LeCompteur + "";

            if (Global.ElevesAll[Global.rang].classeEleve.Substring(0, 1) == "6")
            {
                foreach (Classe uneClasse in Global.lesNiveaux[1].getLesClasse())
                    cbbClasse.Items.Add(uneClasse.nomDeLaClasse);
            }
            else if (Global.ElevesAll[Global.rang].classeEleve.Substring(0, 1) == "5")
            {
                foreach (Classe uneClasse in Global.lesNiveaux[2].getLesClasse())
                    cbbClasse.Items.Add(uneClasse.nomDeLaClasse);
            }
            else if (Global.ElevesAll[Global.rang].classeEleve.Substring(0, 1) == "4")
            {
                foreach (Classe uneClasse in Global.lesNiveaux[3].getLesClasse())
                    cbbClasse.Items.Add(uneClasse.nomDeLaClasse);
            }
        }

        private void btnSuivant_Click(object sender, EventArgs e)
        {
            //Avant changement des valeurs de la ComboBox

            if (cbbClasse.Text.Substring(0, 1) == "5")
                Global.lesNiveaux[1].getClasse(cbbClasse.Text, Global.lesNiveaux[1].getLesClasse()).getLesEleves().Add(Global.ElevesAll[Global.rang]);
            else if (cbbClasse.Text.Substring(0, 1) == "4")
                Global.lesNiveaux[2].getClasse(cbbClasse.Text, Global.lesNiveaux[2].getLesClasse()).getLesEleves().Add(Global.ElevesAll[Global.rang]);
            else if (cbbClasse.Text.Substring(0, 1) == "3")
                Global.lesNiveaux[3].getClasse(cbbClasse.Text, Global.lesNiveaux[3].getLesClasse()).getLesEleves().Add(Global.ElevesAll[Global.rang]);

            //Changements de la Combobox prennent effet à partir d'ici

            if (Global.avancement >= Global.ElevesAll.Count)
            {
                this.Close();
                MessageBox.Show("La procédure de passage à l'année scolaire\nest terminée !");

                for (int i = 0; i < Global.nbEleves6eme; i++) //parcours tous les élèves de la base de données (même ceux qui n'auront pas de classe)
                {
                    if (Global.listeClasseEleve[i] != "vide" || Global.listeMefEleve[i] != "vide") //si l'élève a bien une classe et un code MEF, il est alors "validé" et ajouté a une liste
                    {
                        Eleve unEleve = new Eleve(
                            Global.listeNumEleve[i], Global.listeNomEleve[i], Global.listePrenomEleve[i],
                            Global.listeNaissanceEleve[i], Global.listeSexeEleve[i], Global.listeMefEleve[i],
                            Global.listeClasseEleve[i], Global.listeLV1Eleve[i], Global.listeOption1Eleve[i], Global.listeOption2Eleve[i]);
                        Global.elevesValides6eme.Add(unEleve);
                        Global.nbElevesReal6eme++;
                    }
                }

                foreach (string nom in Global.nomsClasses6e)    
                {
                    Classe uneClasse = new Classe(nom);                    
                    Global.lesNiveaux[0].setLesClasses(uneClasse);         
                    for (int i = 0; i < Global.nbElevesReal6eme; i++)      
                        if (Global.elevesValides6eme[i].classeEleve == uneClasse.nomDeLaClasse)
                        {
                            Eleve unEleve = Global.elevesValides6eme[i];    
                            uneClasse.setLesEleves(unEleve);                
                        }
                    uneClasse.getLesEleves().Sort((u1, u2) => u1.nomEleve.CompareTo(u2.nomEleve));
                }
            }
            else if (cbbClasse.Text == "")
            {
                SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\Windows Background.wav");
                simpleSound.Play();
                MessageBox.Show("Vous devez sélectionner une classe pour pouvoir continuer.");
            }
            else
            {
                Global.avancement++;
                lblCompteur1.Text = Global.avancement + "";
                Global.rang++;
                cbbClasse.Items.Clear(); //Réinitialise la Combobox
                lblNomEleve.Text = Global.ElevesAll[Global.rang].nomEleve;
                lblPrenomEleve.Text = Global.ElevesAll[Global.rang].prenomEleve;

                if (Global.ElevesAll[Global.rang].classeEleve.Contains("6"))
                {
                    foreach (Classe uneClasse in Global.lesNiveaux[1].getLesClasse())
                        cbbClasse.Items.Add(uneClasse.nomDeLaClasse);
                }
                else if (Global.ElevesAll[Global.rang].classeEleve.Contains("5"))
                {
                    foreach (Classe uneClasse in Global.lesNiveaux[2].getLesClasse())
                        cbbClasse.Items.Add(uneClasse.nomDeLaClasse);
                }
                else if (Global.ElevesAll[Global.rang].classeEleve.Contains("4"))
                {
                    foreach (Classe uneClasse in Global.lesNiveaux[3].getLesClasse())
                        cbbClasse.Items.Add(uneClasse.nomDeLaClasse);
                }
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbbClasse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
