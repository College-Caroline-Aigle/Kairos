using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FichesT
{
    public partial class OpenSLK : Form
    {

        private BarreDeChargement barreDeCharge;
        TextInfo myTI = new CultureInfo("fr-FR", false).TextInfo;
        public OpenSLK()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.DoWork += BackgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += BackgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;
        }

        // Méthode appelée lorsqu'un travail de fond (BackgroundWorker) est démarré.
        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // Initialisation de l'application Excel.
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb;
            Worksheet ws;

            // Ouverture du fichier Excel spécifié par Global.pathSLK.
            wb = excel.Workbooks.Open(Global.pathSLK);
            ws = (Worksheet)wb.Worksheets[1]; // Sélection de la première feuille du classeur.

            bool CasePleine = true;
            Global.nbEleves6eme = 0; // Initialisation du compteur d'élèves.

            // Parcours des lignes de la feuille Excel jusqu'à trouver une cellule vide.
            for (int i = 2; CasePleine == true; i++)
            {
                if (ws.Cells[i, 1].Value != null) // Si la cellule de la colonne 1 (A) n'est pas vide.
                {
                    Global.numEleveMax++;
                    // Ajout des informations de l'élève aux listes globales.
                    Global.listeNumEleve.Add(Global.numEleveMax);
                    Global.listeNomEleve.Add(ws.Cells[i, 1].Value);
                    Global.listePrenomEleve.Add(ws.Cells[i, 2].Value);
                    Global.listeNaissanceEleve.Add(ws.Cells[i, 3].Value);
                    Global.listeMefEleve.Add("");
                    Global.listeSexeEleve.Add("");
                    Global.listeRedouble.Add("N");
                    Global.listeDateEntreeEleve.Add(new DateTime(DateTime.Now.Year, 9, 1)); // Date d'entrée fixée au 1er septembre de l'année courante.
                    Global.nbEleves6eme++;
                }
                else
                    CasePleine = false; // Si une cellule vide est trouvée, on arrête la boucle.
            }

            // Calcul du nombre de nouvelles classes nécessaires.
            int nouvellesClasses = (Global.nbEleves6eme / 30);
            int placeDansClasse = 30; // Initialisation de la capacité de chaque classe à 30 élèves.

            // Parcours des élèves pour attribuer les options et les classes.
            for (int i = 2; i < Global.nbEleves6eme; i++)
            {
                // Traitement des informations des élèves.
                string LV1 = myTI.ToTitleCase(ws.Cells[i, 11].Value.ToLower()).Replace(" ", "");
                string formationAcuueil = ws.Cells[i, 8].Value;
                if (formationAcuueil.Contains("BILINGUE"))
                {
                    Global.listeLV1Eleve.Add("Bilingue");
                    Global.listeLV1EleveOption.Add(new Options("Bilingue"));

                    if (!Global.lesOptions.Contains("Bilingue"))
                    {
                        Global.lesOptions.Add("Bilingue");
                        Global.options.Add(new Options("Bilingue"));
                    }
                }
                else
                {
                    Global.listeLV1Eleve.Add(LV1);
                    Global.listeLV1EleveOption.Add(new Options(LV1));
                }
                if (formationAcuueil.Contains("SEGPA"))
                {
                    Global.listeOption1Eleve.Add("Segpa");
                    Global.listeOption1EleveOption.Add(new Options("Segpa"));
                }
                else if (formationAcuueil.Contains("ULIS"))
                {
                    Global.listeOption1Eleve.Add("Ulis");
                    Global.listeOption1EleveOption.Add(new Options("Ulis"));
                }
                else if (formationAcuueil.Contains("ALLOPHONES"))
                {
                    Global.listeOption1Eleve.Add("Upe2a");
                    Global.listeOption1EleveOption.Add(new Options("Upe2a"));
                }
                else if (String.IsNullOrEmpty(formationAcuueil))
                {
                    Global.listeOption1Eleve.Add("Aucune");
                    Global.listeOption1EleveOption.Add(new Options("Aucune"));
                }
                else
                {
                    string LV2 = myTI.ToTitleCase(ws.Cells[i, 12].Value.ToLower()).Replace(" ", "");
                    if (String.IsNullOrEmpty(LV2))
                    {
                        Global.listeOption1Eleve.Add("Aucune");
                        Global.listeOption1EleveOption.Add(new Options("Aucune"));
                    }
                    else
                    {
                        Global.listeOption1Eleve.Add(LV2);
                        Global.listeOption1EleveOption.Add(new Options(LV2));
                    }
                }

                // Option 2 par défaut à "Aucune".
                Global.listeOption2Eleve.Add("Aucune");
                Global.listeOption2EleveOption.Add(new Options("Aucune"));

                // Attribution des classes en fonction de la formation d'accueil.
                if (formationAcuueil.Contains("SEGPA"))
                {
                    Global.listeClasseEleve.Add("6 SEGPA");
                }
                else
                {
                    Global.listeClasseEleve.Add("6 " + nouvellesClasses.ToString());
                    placeDansClasse--;
                    if (placeDansClasse == 0)
                    {
                        placeDansClasse = 30;
                        nouvellesClasses--;
                    }
                }

                string etabOrig = ws.Cells[i,4].Value;

                if (etabOrig.Contains("0672499C"))
                {
                    Global.listeEtabOrig.Add("Neufeld");
                }
                else if (etabOrig.Contains("0672361C"))
                {
                    Global.listeEtabOrig.Add("Ste.Madeleine");
                }
                else if (etabOrig.Contains("0670413K"))
                {
                    Global.listeEtabOrig.Add("Louvois");
                }
                else if (etabOrig.Contains("0670407D"))
                {
                    Global.listeEtabOrig.Add("Schluthfeld");
                }
                else if (etabOrig.Contains("0670402Y"))
                {
                    Global.listeEtabOrig.Add("St.Thomas");
                }
                else
                {
                    Global.listeEtabOrig.Add("Autre");
                }

                int progressPercentage = (i + 1) * 100 / (Global.nbEleves6eme + 2);
                backgroundWorker1.ReportProgress(progressPercentage);
            }

            // Fermeture des processus Excel ouverts pour éviter les fuites de mémoire.
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName.Equals("EXCEL"))
                {
                    clsProcess.Kill();
                    break;
                }
            }

            // Création d'une liste de mémoire pour les classes de 6ème.
            List<string> memory6e = new List<string>();

            for (int i = 0; i < Global.listeClasseEleve.Count(); i++)
            {
                memory6e.Add(Global.listeClasseEleve[i]);
            }

            // Elimination des doublons pour obtenir les noms des classes uniques.
            Global.nomsClasses6e = memory6e.Distinct().ToList();

            // Appel de la méthode NouvelleAnnee pour initialiser une nouvelle année scolaire.
            NouvelleAnnee();
        }


        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            barreDeCharge.UpdateProgress(e.ProgressPercentage);
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            barreDeCharge.Close();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOuvrirSLK_Click(object sender, EventArgs e)
        {
            // Crée une boîte de dialogue pour ouvrir un fichier
            OpenFileDialog OFD = new OpenFileDialog();
            // Définit le filtre pour afficher uniquement les fichiers .slk
            OFD.Filter = "SLK files (*.slk)|*.slk";
            // Définit l'index par défaut du filtre
            OFD.FilterIndex = 1;
            // Restaurer le répertoire sélectionné précédemment
            OFD.RestoreDirectory = true;
            // Affiche la boîte de dialogue et vérifie si l'utilisateur a sélectionné un fichier
            DialogResult dr = OFD.ShowDialog();
            if (dr == DialogResult.OK)
            {
                // Récupère le chemin du fichier sélectionné
                string path = OFD.FileName;
                // Stocke le chemin du fichier dans une variable globale
                Global.pathSLK = path;
                // Ferme la fenêtre actuelle
                this.Close();
                // On garde en mémoire le chemin vers le fichier SLK
            }

            // Vérifie si le chemin du fichier SLK n'est pas vide
            if (!string.IsNullOrEmpty(Global.pathSLK))
            {
                // Définit le numéro maximum d'élève en fonction de la liste actuelle des numéros d'élèves
                Global.numEleveMax = Global.listeNumEleve.Max();

                // Vide les listes contenant les informations des élèves
                Global.listeNumEleve.Clear();
                Global.listeNomEleve.Clear();
                Global.listePrenomEleve.Clear();
                Global.listeNaissanceEleve.Clear();
                Global.listeSexeEleve.Clear();
                Global.listeMefEleve.Clear();
                Global.listeClasseEleve.Clear();
                Global.listeLV1Eleve.Clear();
                Global.listeOption1Eleve.Clear();
                Global.listeOption2Eleve.Clear();
                Global.listeLV1EleveOption.Clear();
                Global.listeOption1EleveOption.Clear();
                Global.listeOption2EleveOption.Clear();
                Global.listeEtabOrig.Clear();
                Global.listeRedouble.Clear();
                Global.listeDateEntreeEleve.Clear();
                Global.listeDateSortieEleve.Clear();

                // Affiche un message indiquant le début de l'importation des nouveaux élèves de 6ème
                MessageBox.Show("L'import des nouveaux élèves de 6ème va commencer. Veuillez cliquer sur OK pour démarrer l'importation.");

                // Crée et affiche une barre de chargement
                barreDeCharge = new BarreDeChargement();
                barreDeCharge.Show();
                // Démarre un travail en arrière-plan pour traiter l'importation du fichier SLK
                backgroundWorker1.RunWorkerAsync(Global.pathSLK);
            }
        }

        public void NouvelleAnnee()
        {
            //Niveau niv = Global.lesNiveaux.SingleOrDefault(n => n.nomDuNiveau == "la3eme");
            //Global.lesNiveaux.Remove(niv);

            Global.nbElevesReal = 0;
            Global.nbElevesReal6eme = 0;

            //foreach(Niveau nv in Global.lesNiveaux)
            //{
            //    if(nv.nomDuNiveau.Contains("3"))
            //    {
            //        foreach (Classe cls in nv.getLesClasse())
            //        {
            //            Global.nbElevesReal += cls.getLesEleves().Count();
            //        }
            //    }
            //}

            for (int i = 0; i < Global.listeClasseEleve.Count(); i++) //parcours tous les élèves de la base de données (même ceux qui n'auront pas de classe)
            {
                if (!String.IsNullOrEmpty(Global.listeClasseEleve[i])) //si l'élève a bien une classe, il est alors "validé" et ajouté a une liste
                {
                    Eleve unEleve = new Eleve(
                        Global.listeNumEleve[i], Global.listeNomEleve[i], Global.listePrenomEleve[i],
                        Global.listeNaissanceEleve[i], Global.listeSexeEleve[i], Global.listeMefEleve[i], Global.listeRedouble[i],
                        Global.listeClasseEleve[i], Global.listeLV1Eleve[i], Global.listeOption1Eleve[i], Global.listeOption2Eleve[i],
                        Global.listeLV1EleveOption[i], Global.listeOption1EleveOption[i], Global.listeOption2EleveOption[i], Global.listeDateEntreeEleve[i]);
                    Global.elevesValides6eme.Add(unEleve);
                    unEleve.nonInscrit = "V";
                    unEleve.etablissementOrigine = Global.listeEtabOrig[i];
                    Global.nbElevesReal6eme++;

                    string testListeOption = Global.listeLV1Eleve[i];
                    if (!String.IsNullOrEmpty(testListeOption) && testListeOption.Contains("Lv1"))
                        testListeOption = testListeOption.Remove(testListeOption.IndexOf("Lv1"));

                    if (!Global.lesOptions.Contains(testListeOption))
                    {
                        if (!String.IsNullOrEmpty(testListeOption) && !Global.lesOptions.Any(s => s.Contains(testListeOption.Substring(0, 3))))
                        {
                            Global.lesOptions.Add(testListeOption);
                            Global.options.Add(new Options(testListeOption));
                        }
                    }
                    if (Global.listeOption1Eleve[i].Contains("Lv2"))
                    {
                        testListeOption = Global.listeOption1Eleve[i].Remove(Global.listeOption1Eleve[i].IndexOf("Lv2"));
                        if (!String.IsNullOrEmpty(testListeOption))
                        {
                            if (!Global.lesOptions.Contains(testListeOption))
                            {
                                if (!Global.lesOptions.Any(s => s.Contains(testListeOption.Substring(0, 3))))
                                {
                                    Global.lesOptions.Add(testListeOption);
                                    Global.options.Add(new Options(testListeOption));
                                }
                            }
                        }

                        testListeOption = Global.listeOption2Eleve[i];
                        if (!String.IsNullOrEmpty(testListeOption))
                        {
                            if (testListeOption.Contains("Lv1"))
                                testListeOption = testListeOption.Remove(testListeOption.IndexOf("Lv1"));
                            else if (testListeOption.Contains("Lv2"))
                                testListeOption = testListeOption.Remove(testListeOption.IndexOf("Lv2"));

                            if (!String.IsNullOrEmpty(testListeOption) && !Global.lesOptions.Any(s => s.Contains(testListeOption.Substring(0, 3))))
                            {
                                Global.lesOptions.Add(testListeOption);
                                Global.options.Add(new Options(testListeOption));
                            }

                            if (testListeOption.Contains("Latin") || testListeOption.Contains("Ens"))
                            {
                                if (!Global.lesOptions.Contains(testListeOption))
                                {
                                    Global.lesOptions.Add(testListeOption);
                                    Global.options.Add(new Options(testListeOption));
                                }
                            }
                        }
                    }
                    else if (Global.listeOption1Eleve[i].Contains("Lv1"))
                    {
                        testListeOption = Global.listeOption1Eleve[i].Remove(Global.listeOption1Eleve[i].IndexOf("Lv1"));
                        if (!String.IsNullOrEmpty(testListeOption))
                        {
                            if (!Global.lesOptions.Contains(testListeOption))
                            {
                                if (!Global.lesOptions.Any(s => s.Contains(testListeOption.Substring(0, 3))))
                                {
                                    Global.lesOptions.Add(testListeOption);
                                    Global.options.Add(new Options(testListeOption));
                                }
                            }
                        }

                        testListeOption = Global.listeOption2Eleve[i];
                        if (!String.IsNullOrEmpty(testListeOption))
                        {
                            if (testListeOption.Contains("Lv1"))
                                testListeOption = testListeOption.Remove(testListeOption.IndexOf("Lv1"));
                            else if (testListeOption.Contains("Lv2"))
                                testListeOption = testListeOption.Remove(testListeOption.IndexOf("Lv2"));

                            if (!Global.lesOptions.Any(s => s.Contains(testListeOption.Substring(0, 3))))
                            {
                                Global.lesOptions.Add(testListeOption);
                                Global.options.Add(new Options(testListeOption));
                            }

                            if ((testListeOption.Contains("Latin") || testListeOption.Contains("Ens")))
                            {
                                if (!Global.lesOptions.Contains(testListeOption))
                                {
                                    Global.lesOptions.Add(testListeOption);
                                    Global.options.Add(new Options(testListeOption));
                                }
                            }
                        }
                    }
                    //else
                    //{
                    //    testListeOption = Global.listeOption1Eleve[i];

                    //    if (!Global.lesOptions.Any(s => s.Contains(testListeOption.Substring(0, 3))))
                    //    {
                    //        Global.lesOptions.Add(testListeOption);
                    //        Global.options.Add(new Options(testListeOption));
                    //    }
                    //}
                }
            }

            // Monter des niveaux pour la nouvelle année
            Global.lesNiveaux[3].nomDuNiveau = "la2nde";
            Global.lesNiveaux[2].nomDuNiveau = "la3eme";
            Global.lesNiveaux[1].nomDuNiveau = "la4eme";
            Global.lesNiveaux[0].nomDuNiveau = "la5eme";

            foreach (Classe cls in Global.lesNiveaux[3].getLesClasse())
            {
                cls.nomDeLaClasse = "2" + cls.nomDeLaClasse.Substring(1);
                foreach (Eleve elv in cls.getLesEleves())
                {
                    elv.classeEleve = "2" + cls.nomDeLaClasse.Substring(1);
                }
            }

            foreach (Classe cls in Global.lesNiveaux[2].getLesClasse())
            {
                cls.nomDeLaClasse = "3" + cls.nomDeLaClasse.Substring(1);
                foreach(Eleve elv in cls.getLesEleves())
                {
                    elv.classeEleve = "3" + cls.nomDeLaClasse.Substring(1);
                    Global.nbElevesReal++;
                }
            }

            foreach (Classe cls in Global.lesNiveaux[1].getLesClasse())
            {
                cls.nomDeLaClasse = "4" + cls.nomDeLaClasse.Substring(1);
                foreach (Eleve elv in cls.getLesEleves())
                {
                    elv.classeEleve = "4" + cls.nomDeLaClasse.Substring(1);
                    Global.nbElevesReal++;
                }
            }

            foreach (Classe cls in Global.lesNiveaux[0].getLesClasse())
            {
                cls.nomDeLaClasse = "5" + cls.nomDeLaClasse.Substring(1);
                foreach (Eleve elv in cls.getLesEleves())
                {
                    elv.classeEleve = "5" + cls.nomDeLaClasse.Substring(1);
                    Global.nbElevesReal++;
                }
            }

            Niveau niveau6eme = new Niveau("la6eme");       //Création d'un objet Niveau contenant le nom du niveau concerné
            foreach (string nom in Global.nomsClasses6e)     //On parcourt les noms des classes correspondant au niveau
            {
                Classe uneClasse = new Classe(nom);                     //Création d'un objet Classe qui contient le nom de celle-ci
                niveau6eme.setLesClasses(uneClasse);                    //Ajout de l'objet Classe à la liste des classes de l'objet Niveau
                for (int i = 0; i < Global.nbElevesReal6eme; i++)           //On parcourt maintenant tous les élèves étant bien scolarisés dans le collège
                    if (Global.elevesValides6eme[i].classeEleve == uneClasse.nomDeLaClasse)
                    {
                        Eleve unEleve = Global.elevesValides6eme[i];        //Si l'élève est dans la classe consultée par le foreach il est donc ajouté en tant qu'objet Eleve
                        uneClasse.setLesEleves(unEleve);                //Et enfin ajouté à la liste des élèves de l'objet Classe
                    }
            }

            Global.nbElevesReal += Global.nbElevesReal6eme;

            Global.lesNiveaux.Insert(0, niveau6eme);

            MessageBox.Show("Les nouveaux élèves de 6ème ont été enregistré et toutes les classes sont montées d'un niveaux");
        }
    }
}
