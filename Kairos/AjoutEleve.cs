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
using System.Globalization;

namespace FichesT
{
    public partial class AjoutEleve : Form
    {
        private string selecClasse;
        private string selecNom;
        private string selecPrenom;
        private string selecSexe;
        private string selecNaissance;
        private string selecMef;
        private string selecLV1;
        private string selecOpt1;
        private string selecOpt2;
        private Options selecLV1Option;
        private Options selecOpt1Option;
        private Options selecOpt2Option;
        private DateTime selecDateEntree;

        public AjoutEleve()
        {
            InitializeComponent();
        }
        private void AjoutEleve_Load(object sender, EventArgs e)
        {
            foreach (Niveau unNiveau in Global.lesNiveaux)
            {
                foreach (Classe uneClasse in unNiveau.getLesClasse())
                    cbbClasse.Items.Add(uneClasse.nomDeLaClasse);
            }

            dtbNaissance.CustomFormat = "dd/MM/yyyy";


            foreach (string nomLV1 in Global.listeLV1Eleve.Distinct())
            {
                if(!String.IsNullOrEmpty(nomLV1))
                    cbbLV1.Items.Add(nomLV1);
            }
            //cbbLV1.Items.Add("Anglais LV1");
            //cbbLV1.Items.Add("Allemand LV1");
            //cbbLV1.Items.Add("Espagnol LV1");

            foreach (string nomOption1 in Global.listeOption1Eleve.Distinct())
            {
                cbbOpt1.Items.Add(nomOption1);
            }
            //cbbOpt1.Items.Add("UPE2A");
            //cbbOpt1.Items.Add("ULIS");
            //cbbOpt1.Items.Add("SEGPA");
            //cbbOpt1.Items.Add("Anglais LV2");
            //cbbOpt1.Items.Add("Allemand LV2");
            //cbbOpt1.Items.Add("Espagnol LV2");

            foreach (string nomOption2 in Global.listeOption2Eleve.Distinct())
            {
                cbbOpt2.Items.Add(nomOption2);
            }

            //cbbOpt2.Items.Add("Latin");
            //cbbOpt2.Items.Add("Culture Régionale");
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            TextInfo myTI = new CultureInfo("fr-FR", false).TextInfo;
            string sx = null;
            int error = 0; //état par défaut sans erreurs
            string message;
            if (rdbHomme.Checked)
                sx = "H";
            else if (rdbFemme.Checked)
                sx = "F";
            else
                error++; //ajoute 1 pour compter l'erreur
            if (txtNom.Text == "" | txtPrenom.Text == "" | txtCodeMEF.Text == "" | cbbClasse.Text == "" | cbbOpt1.Text == "" | cbbOpt2.Text == "")
                error++;

            if (error == 0) //s'il n'y a pas d'erreurs l'élève est bien ajouté
            {
                selecClasse = cbbClasse.Text;
                selecNom = txtNom.Text.ToUpper();
                selecPrenom = myTI.ToTitleCase(txtPrenom.Text.ToLower());
                selecSexe = sx;
                selecNaissance = dtbNaissance.Text;
                selecMef = txtCodeMEF.Text;
                //if (cbbLV1.Text == "Anglais LV1")
                //    selecLV1 = "AnglaisLv1";
                //if (cbbLV1.Text == "Allemand LV1")
                //    selecLV1 = "AllemandLv1";
                //if (cbbLV1.Text == "Espagnol LV1")
                //    selecLV1 = "EspagnolLv1";
                //Correspondance option1
                //if (cbbOpt1.Text == "Pas d'option")
                //    selecOpt1 = "Aucune";
                //else
                //    selecOpt1 = cbbOpt1.Text;
                //if (cbbOpt1.Text == "UPE2A")
                //    selecOpt1 = "Upe2a";
                //if (cbbOpt1.Text == "ULIS")
                //    selecOpt1 = "Ulis";
                //if (cbbOpt1.Text == "SEGPA")
                //    selecOpt1 = "Segpa";
                //if (cbbOpt1.Text == "Anglais LV2")
                //    selecOpt1 = "AnglaisLv2";
                //if (cbbOpt1.Text == "Allemand LV2")
                //    selecOpt1 = "AllemandLv2";
                //if (cbbOpt1.Text == "Espagnol LV2")
                //    selecOpt1 = "EspagnolLv2";
                //Correspondance option2
                //if (cbbOpt2.Text == "Pas d'option")
                //    selecOpt2 = "Aucune";
                //else
                //    selecOpt2 = cbbOpt2.Text;
                //if (cbbOpt2.Text == "Latin")
                //    selecOpt2 = "Latin";
                //if (cbbOpt2.Text == "Culture Régionale")
                //    selecOpt2 = "CulturesReg";
                selecLV1 = cbbLV1.Text;
                selecOpt1 = cbbOpt1.Text;
                selecOpt2 = cbbOpt2.Text;


                selecLV1Option = new Options(selecLV1);
                selecOpt1Option = new Options(selecOpt1);
                selecOpt2Option = new Options(selecOpt2);

                selecDateEntree = dtbEntree.Value.Date;

                if (selecClasse.Contains("6"))
                {
                    Classe laClasse = Global.lesNiveaux[0].getClasse(selecClasse, Global.lesNiveaux[0].getLesClasse());
                    Eleve lEleve = new Eleve(laClasse.getLesEleves().LastOrDefault().numEleve + 1, selecNom, selecPrenom, selecNaissance, selecSexe, selecMef, selecClasse, selecLV1,selecOpt1, selecOpt2, selecLV1Option, selecOpt1Option, selecOpt2Option, selecDateEntree);
                    laClasse.getLesEleves().Add(lEleve);
                    Global.elevesValides.Add(lEleve);
                    if (Global.nbElevesReal > 0)
                        Global.nbElevesReal++;
                    else
                        Global.nbEleves++;
                    MessageBox.Show("L'élève : " + selecNom + " " + selecPrenom + " a bien été ajouté à la classe " + selecClasse);
                }
                else if (selecClasse.Contains("5"))
                {
                    Classe laClasse = Global.lesNiveaux[1].getClasse(selecClasse, Global.lesNiveaux[1].getLesClasse());
                    Eleve lEleve = new Eleve(laClasse.getLesEleves().LastOrDefault().numEleve + 1, selecNom, selecPrenom, selecNaissance, selecSexe, selecMef, selecClasse, selecLV1, selecOpt1, selecOpt2, selecLV1Option, selecOpt1Option, selecOpt2Option, selecDateEntree);
                    laClasse.getLesEleves().Add(lEleve);
                    Global.elevesValides.Add(lEleve);
                    if (Global.nbElevesReal > 0)
                        Global.nbElevesReal++;
                    else
                        Global.nbEleves++;
                    MessageBox.Show("L'élève : " + selecNom + " " + selecPrenom + " a bien été ajouté à la classe " + selecClasse);
                }
                else if (selecClasse.Contains("4"))
                {
                    Classe laClasse = Global.lesNiveaux[2].getClasse(selecClasse, Global.lesNiveaux[2].getLesClasse());
                    Eleve lEleve = new Eleve(laClasse.getLesEleves().LastOrDefault().numEleve + 1, selecNom, selecPrenom, selecNaissance, selecSexe, selecMef, selecClasse, selecLV1, selecOpt1, selecOpt2, selecLV1Option, selecOpt1Option, selecOpt2Option, selecDateEntree);
                    laClasse.getLesEleves().Add(lEleve);
                    Global.elevesValides.Add(lEleve);
                    if (Global.nbElevesReal > 0)
                        Global.nbElevesReal++;
                    else
                        Global.nbEleves++;
                    MessageBox.Show("L'élève : " + selecNom + " " + selecPrenom + " a bien été ajouté à la classe " + selecClasse);
                }
                else if (selecClasse.Contains("3"))
                {
                    Classe laClasse = Global.lesNiveaux[3].getClasse(selecClasse, Global.lesNiveaux[3].getLesClasse());
                    Eleve lEleve = new Eleve(laClasse.getLesEleves().LastOrDefault().numEleve + 1, selecNom, selecPrenom, selecNaissance, selecSexe, selecMef, selecClasse, selecLV1, selecOpt1, selecOpt2, selecLV1Option, selecOpt1Option, selecOpt2Option, selecDateEntree);
                    laClasse.getLesEleves().Add(lEleve);
                    Global.elevesValides.Add(lEleve);
                    if (Global.nbElevesReal > 0)
                        Global.nbElevesReal++;
                    else
                        Global.nbEleves++;
                    MessageBox.Show("L'élève : " + selecNom + " " + selecPrenom + " a bien été ajouté à la classe " + selecClasse);
                }
                else
                    MessageBox.Show("Le nom de la classe n'est pas reconnu");

            }
            else //s'il y a une erreur un message apparait avec un son d'alerte prévenant de l'erreur
            {
                message = "Erreur lors de l'ajout.\nVeuillez vérifier la saisie des données.";
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
