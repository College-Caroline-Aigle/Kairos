using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Office.Interop.Excel;
using ExcelDataReader;
using System.Runtime.InteropServices;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing.Text;
using System.Globalization;

namespace FichesT
{
    public partial class OpenNew6eme : Form
    {
        private BarreDeChargement barreDeCharge;
        TextInfo myTI = new CultureInfo("fr-FR", false).TextInfo;
        public OpenNew6eme()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.DoWork += BackgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += BackgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (rdbXLS.Checked)    //Importation depuis XLS
            {
                Global.pathXLS6eme = e.Argument as string;

                if (!string.IsNullOrEmpty(Global.pathXLS6eme))
                {
                    //Version Excel 
                    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                    Workbook wb;
                    Worksheet ws;

                    wb = excel.Workbooks.Open(Global.pathXLS6eme);
                    ws = (Worksheet)wb.Worksheets[1];


                    bool CasePleine = true;
                    for (int i = 2; CasePleine == true; i++)
                    {
                        if (ws.Cells[i, 3].Value != null)
                        {
                            Global.listeNumEleve.Add(Convert.ToInt32(ws.Cells[i, 3].Value));
                            Global.nbEleves++;
                        }
                        else
                            CasePleine = false;
                    }
                    

                    for (int i = 2; i < Global.nbEleves + 2; i++)
                    {
                        //Pour les listes des Noms des élèves
                        Global.listeNomEleve.Add(ws.Cells[i, 5].Value);

                        //Pour les listes des Prenoms des élèves
                        Global.listePrenomEleve.Add(ws.Cells[i, 7].Value);

                        string classe = (ws.Cells[i, 35].Value);
                        //Transformation du code en lettre H pour Homme et F pour Femme :
                        string sex = ws.Cells[i, 1].Value;

                        if (sex == "M")
                            Global.listeSexeEleve.Add("H");
                        else if (sex == "F")
                            Global.listeSexeEleve.Add("F");
                        else
                            Global.listeSexeEleve.Add("Indéterminé");

                        Global.listeNaissanceEleve.Add(ws.Cells[i, 10].Value);


                        if (classe != "" && classe != null)
                            Global.listeClasseEleve.Add(classe);
                        else
                            Global.listeClasseEleve.Add("Vide");

                        int annee = Int32.Parse(ws.Cells[i, 13].Value.Substring(6));
                        int mois = Int32.Parse(ws.Cells[i, 13].Value.Substring(3, 2));
                        int jour = Int32.Parse(ws.Cells[i, 13].Value.Substring(0, 2));

                        DateTime dateEntree = new DateTime(annee, mois, jour);

                        Global.listeDateEntreeEleve.Add(dateEntree);

                        if (!String.IsNullOrEmpty(ws.Cells[i, 14].Value))
                        {
                            annee = Int32.Parse(ws.Cells[i, 14].Value.Substring(6));
                            mois = Int32.Parse(ws.Cells[i, 14].Value.Substring(3, 2));
                            jour = Int32.Parse(ws.Cells[i, 14].Value.Substring(0, 2));

                            DateTime dateSortie = new DateTime(annee, mois, jour);

                            Global.listeDateSortieEleve.Add(dateSortie);
                        }
                        else
                            Global.listeDateSortieEleve.Add(default);

                        string MEF = "";
                        MEF = ws.Cells[i, 33].Value;
                        string LV1 = ws.Cells[i, 39].Value;
                        if (!String.IsNullOrEmpty(LV1))
                        {
                            LV1 = myTI.ToTitleCase(LV1.ToLower()).Replace(" ", "");
                        }

                        string LV2 = ws.Cells[i, 43].Value;
                        if (!String.IsNullOrEmpty(LV2))
                        {
                            LV2 = myTI.ToTitleCase(LV2.ToLower()).Replace(" ", "");
                        }
                        string OPTION = ws.Cells[i, 47].Value;
                        if (!String.IsNullOrEmpty(OPTION))
                        {
                            OPTION = myTI.ToTitleCase(OPTION.ToLower()).Replace(" ", "");
                        }

                        if (MEF != "" && MEF != null)
                            Global.listeMefEleve.Add(MEF);
                        else
                            Global.listeMefEleve.Add("Vide");

                        if (MEF != "" && MEF != null)
                        {

                            Global.listeLV1Eleve.Add(LV1);
                            Global.listeLV1EleveOption.Add(new Options(LV1));


                            if (MEF.Contains("F"))
                            {
                                Global.listeOption1EleveOption.Add(new Options("Upe2a"));
                                Global.listeOption1Eleve.Add("Upe2a");//UPE2A
                                if (!String.IsNullOrEmpty(OPTION))
                                {
                                    Global.listeOption2EleveOption.Add(new Options(OPTION));
                                    Global.listeOption2Eleve.Add(OPTION);
                                }
                                else
                                {
                                    Global.listeOption2EleveOption.Add(new Options("Aucune"));
                                    Global.listeOption2Eleve.Add("Aucune");
                                }

                            }
                            else if (MEF.Contains("U"))
                            {
                                Global.listeOption1EleveOption.Add(new Options("Ulis"));
                                Global.listeOption1Eleve.Add("Ulis");//ULIS
                                if (!String.IsNullOrEmpty(OPTION))
                                {
                                    Global.listeOption2EleveOption.Add(new Options(OPTION));
                                    Global.listeOption2Eleve.Add(OPTION);
                                }
                                else
                                {
                                    Global.listeOption2EleveOption.Add(new Options("Aucune"));
                                    Global.listeOption2Eleve.Add("Aucune");
                                }

                            }
                            else if (MEF.Contains("02110"))
                            {
                                Global.listeOption1EleveOption.Add(new Options("Segpa"));
                                Global.listeOption1Eleve.Add("Segpa");//SEGPA
                                if (!String.IsNullOrEmpty(OPTION))
                                {
                                    Global.listeOption2EleveOption.Add(new Options(OPTION));
                                    Global.listeOption2Eleve.Add(OPTION);
                                }
                                else
                                {
                                    Global.listeOption2EleveOption.Add(new Options("Aucune"));
                                    Global.listeOption2Eleve.Add("Aucune");
                                }

                            }
                            else if (!String.IsNullOrEmpty(LV2))
                            {
                                Global.listeOption1Eleve.Add(LV2);
                                Global.listeOption1EleveOption.Add(new Options(LV2));
                                if (!String.IsNullOrEmpty(OPTION))
                                {
                                    Global.listeOption2EleveOption.Add(new Options(OPTION));
                                    Global.listeOption2Eleve.Add(OPTION);
                                }
                                else
                                {
                                    Global.listeOption2EleveOption.Add(new Options("Aucune"));
                                    Global.listeOption2Eleve.Add("Aucune");
                                }
                            }
                            else
                            {
                                Global.listeOption1EleveOption.Add(new Options("Aucune"));
                                Global.listeOption1Eleve.Add("Aucune");
                                if (!String.IsNullOrEmpty(OPTION))
                                {
                                    Global.listeOption2EleveOption.Add(new Options(OPTION));
                                    Global.listeOption2Eleve.Add(OPTION);
                                }
                                else
                                {
                                    Global.listeOption2EleveOption.Add(new Options("Aucune"));
                                    Global.listeOption2Eleve.Add("Aucune");
                                }
                            }
                        }
                        else
                        {
                            Global.listeLV1EleveOption.Add(new Options("Aucune"));
                            Global.listeOption1EleveOption.Add(new Options("Aucune"));
                            Global.listeOption2EleveOption.Add(new Options("Aucune"));
                            Global.listeLV1Eleve.Add("Aucune");
                            Global.listeOption1Eleve.Add("Aucune");
                            Global.listeOption2Eleve.Add("Aucune");

                        }

                        int progressPercentage = (i + 1) * 100 / (Global.nbEleves + 2);
                        backgroundWorker1.ReportProgress(progressPercentage);

                    }

                    var result = MessageBox.Show("L'importation au format XLS est terminé. Vous pouvez sélectionner une classe.", "Import terminé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Fermer le processus Excel
                    foreach (Process clsProcess in Process.GetProcesses())
                    {
                        if (clsProcess.ProcessName.Equals("EXCEL"))
                        {
                            clsProcess.Kill();
                            break;

                        }
                    }
                }

                }
            else                        //Importation depuis XLSX
            {
                Global.pathXLSX6eme = e.Argument as string;

                if (!string.IsNullOrEmpty(Global.pathXLSX6eme))
                {
                    MessageBox.Show("L'import au format XLSX va commencer. Veuillez cliquer sur OK pour démarrer l'importation.Patientez, un message apparaîtra une fois l'importation terminée");

                    //Version XLSX
                    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                    Workbook wb;
                    Worksheet ws;

                    wb = excel.Workbooks.Open(Global.pathXLSX6eme);
                    ws = (Worksheet)wb.Worksheets[1];

                    bool CasePleine = true;
                    for (int i = 2; CasePleine == true; i++)
                    {
                        if (ws.Cells[i, 3].Value != null)
                        {
                            Global.listeNumEleve.Add(Convert.ToInt32(ws.Cells[i, 3].Value));
                            Global.nbEleves++;
                        }
                        else
                            CasePleine = false;
                    }

                    for (int i = 2; i < Global.nbEleves + 2; i++)
                    {
                        //Pour les listes des Noms des élèves
                        Global.listeNomEleve.Add(ws.Cells[i, 5].Value);

                        //Pour les listes des Prenoms des élèves
                        Global.listePrenomEleve.Add(ws.Cells[i, 7].Value);

                        string classe = (ws.Cells[i, 35].Value);
                        //Transformation du code en lettre H pour Homme et F pour Femme :
                        string sex = ws.Cells[i, 1].Value;

                        if (sex == "M")
                            Global.listeSexeEleve.Add("H");
                        else if (sex == "F")
                            Global.listeSexeEleve.Add("F");
                        else
                            Global.listeSexeEleve.Add("Indéterminé");

                        Global.listeNaissanceEleve.Add(ws.Cells[i, 10].Value);


                        if (classe != "" && classe != null)
                            Global.listeClasseEleve.Add(classe);
                        else
                            Global.listeClasseEleve.Add("Vide");

                        DateTime dateEntree = new DateTime(ws.Cells[i, 10].Value.Substring(6), ws.Cells[i, 10].Value.Substring(4, 5), ws.Cells[i, 10].Value.Substring(0, 1));

                        Global.listeDateEntreeEleve.Add(dateEntree);

                        if (!String.IsNullOrEmpty(ws.Cells[i, 11].Value))
                        {
                            DateTime dateSortie = new DateTime(ws.Cells[i, 11].Value.Substring(6), ws.Cells[i, 11].Value.Substring(4, 5), ws.Cells[i, 11].Value.Substring(0, 1));

                            Global.listeDateSortieEleve.Add(dateSortie);
                        }
                        else
                        {
                            Global.listeDateSortieEleve.Add(default);
                        }

                        string MEF = "";
                        MEF = ws.Cells[i, 33].Value;
                        string LV1 = ws.Cells[i, 39].Value;
                        if (!String.IsNullOrEmpty(LV1))
                        {
                            LV1 = myTI.ToTitleCase(LV1.ToLower()).Replace(" ", "");
                        }

                        string LV2 = ws.Cells[i, 43].Value;
                        if (!String.IsNullOrEmpty(LV2))
                        {
                            LV2 = myTI.ToTitleCase(LV2.ToLower()).Replace(" ", "");
                        }
                        string OPTION = ws.Cells[i, 47].Value;
                        if (!String.IsNullOrEmpty(OPTION))
                        {
                            OPTION = myTI.ToTitleCase(OPTION.ToLower()).Replace(" ", "");
                        }


                        if (MEF != "" && MEF != null)
                            Global.listeMefEleve.Add(MEF);
                        else
                            Global.listeMefEleve.Add("Vide");

                        if (MEF != "" && MEF != null)
                        {
                            if (!String.IsNullOrEmpty(LV1))
                            {
                                Global.listeLV1Eleve.Add(LV1);
                                Global.listeLV1EleveOption.Add(new Options(LV1));
                            }


                            if (MEF.Contains("F"))
                            {
                                Global.listeOption1EleveOption.Add(new Options("Upe2a"));
                                Global.listeOption1Eleve.Add("Upe2a");//UPE2A
                                if (!String.IsNullOrEmpty(OPTION))
                                {
                                    Global.listeOption2EleveOption.Add(new Options(OPTION));
                                    Global.listeOption2Eleve.Add(OPTION);
                                }
                                else
                                {
                                    Global.listeOption2EleveOption.Add(new Options("Aucune"));
                                    Global.listeOption2Eleve.Add("Aucune");
                                }

                            }
                            else if (MEF.Contains("U"))
                            {
                                Global.listeOption1EleveOption.Add(new Options("Ulis"));
                                Global.listeOption1Eleve.Add("Ulis");//ULIS
                                if (!String.IsNullOrEmpty(OPTION))
                                {
                                    Global.listeOption2EleveOption.Add(new Options(OPTION));
                                    Global.listeOption2Eleve.Add(OPTION);
                                }
                                else
                                {
                                    Global.listeOption2EleveOption.Add(new Options("Aucune"));
                                    Global.listeOption2Eleve.Add("Aucune");
                                }

                            }
                            else if (MEF.Contains("02110"))
                            {
                                Global.listeOption1EleveOption.Add(new Options("Segpa"));
                                Global.listeOption1Eleve.Add("Segpa");//SEGPA
                                if (!String.IsNullOrEmpty(OPTION))
                                {
                                    Global.listeOption2EleveOption.Add(new Options(OPTION));
                                    Global.listeOption2Eleve.Add(OPTION);
                                }
                                else
                                {
                                    Global.listeOption2EleveOption.Add(new Options("Aucune"));
                                    Global.listeOption2Eleve.Add("Aucune");
                                }

                            }
                            else if (!String.IsNullOrEmpty(LV2))
                            {
                                Global.listeOption1Eleve.Add(LV2);
                                Global.listeOption1EleveOption.Add(new Options(LV2));
                                if (!String.IsNullOrEmpty(OPTION))
                                {
                                    Global.listeOption2EleveOption.Add(new Options(OPTION));
                                    Global.listeOption2Eleve.Add(OPTION);
                                }
                                else
                                {
                                    Global.listeOption2EleveOption.Add(new Options("Aucune"));
                                    Global.listeOption2Eleve.Add("Aucune");
                                }
                            }
                            else
                            {
                                Global.listeOption1EleveOption.Add(new Options("Aucune"));
                                Global.listeOption1Eleve.Add("Aucune");
                                if (!String.IsNullOrEmpty(OPTION))
                                {
                                    Global.listeOption2EleveOption.Add(new Options(OPTION));
                                    Global.listeOption2Eleve.Add(OPTION);
                                }
                                else
                                {
                                    Global.listeOption2EleveOption.Add(new Options("Aucune"));
                                    Global.listeOption2Eleve.Add("Aucune");
                                }
                            }
                        }
                        else
                        {
                            Global.listeLV1EleveOption.Add(new Options("Aucune"));
                            Global.listeOption1EleveOption.Add(new Options("Aucune"));
                            Global.listeOption2EleveOption.Add(new Options("Aucune"));
                            Global.listeLV1Eleve.Add("Aucune");
                            Global.listeOption1Eleve.Add("Aucune");
                            Global.listeOption2Eleve.Add("Aucune");

                        }

                        int progressPercentage = (i + 1) * 100 / (Global.nbEleves + 2);
                        backgroundWorker1.ReportProgress(progressPercentage);
                    }

                    var result = MessageBox.Show("L'importation au format XLSX est terminé. Vous pouvez sélectionner une classe.", "Import terminé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Fermer le processus Excel
                    foreach (Process clsProcess in Process.GetProcesses())
                    {
                        if (clsProcess.ProcessName.Equals("EXCEL"))
                        {
                            clsProcess.Kill();
                            break;
                        }
                    }
                }

            }

            List<string> memory6e = new List<string>();
            for (int i = 0; i < Global.nbEleves6eme; i++) //parcours tous les élèves même ceux sans classe ni code MEF
            {
                if (Global.listeClasseEleve[i].Substring(0, 1) == "6")
                    memory6e.Add(Global.listeClasseEleve[i]);
            }
            Global.nomsClasses6e.Clear();
            Global.nomsClasses6e = memory6e.Distinct().ToList();

            NouvelleAnnee frmNouvelleAnnee = new NouvelleAnnee();
            frmNouvelleAnnee.Show();
        }

        private void btnOpen_Click(object sender, EventArgs e) //Ouverture du fichier pour récupérer les élèves de 6eme
        {

            //Selon le type de fichier sélectionné, on importe les données différemment
            if (rdbXLS.Checked)    //Importation depuis XLS
            {
                Global.nbEleves = 0;
                Global.nbElevesReal = 0;
                Global.options.Clear();
                OpenFileDialog OFD = new OpenFileDialog();
                OFD.Filter = "Excel files (*.xls)|*.xls";
                OFD.FilterIndex = 1;
                OFD.RestoreDirectory = true;
                DialogResult dr = OFD.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    string path = OFD.FileName;
                    Global.pathXLS6eme = path;
                    this.Close();
                    //On garde en mémoire le chemin vers le fichier XLS
                }

                if (!string.IsNullOrEmpty(Global.pathXLS6eme))
                {
                    MessageBox.Show("L'import au format XLS va commencer. Veuillez cliquer sur OK pour démarrer l'importation.Patientez, un message apparaîtra une fois l'importation terminée");

                    barreDeCharge = new BarreDeChargement();
                    barreDeCharge.Show();
                    backgroundWorker1.RunWorkerAsync(Global.pathXLS6eme);

                }
            }

            else if (rdbXLSX.Checked)                       //Importation depuis XLSX
            {
                Global.nbEleves = 0;
                Global.nbElevesReal = 0;
                Global.options.Clear();
                OpenFileDialog OFD = new OpenFileDialog();
                OFD.Filter = "Excel files (*.xlsx)|*.xlsx";
                OFD.FilterIndex = 1;
                OFD.RestoreDirectory = true;
                DialogResult dr = OFD.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    string path = OFD.FileName;
                    Global.pathXLSX6eme = path;
                    this.Close();
                    //On garde en mémoire le chemin vers le fichier XLSX
                }

                if (!string.IsNullOrEmpty(Global.pathXLSX6eme))
                {
                    MessageBox.Show("L'import au format XLSX va commencer. Veuillez cliquer sur OK pour démarrer l'importation.Patientez, un message apparaîtra une fois l'importation terminée");

                    barreDeCharge = new BarreDeChargement();
                    barreDeCharge.Show();
                    backgroundWorker1.RunWorkerAsync(Global.pathXLSX6eme);

                }
            }
        }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            barreDeCharge.UpdateProgress(e.ProgressPercentage);
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            barreDeCharge.Close();
            foreach (Process clsProcess in Process.GetProcesses())
                    {
                        if (clsProcess.ProcessName.Equals("EXCEL"))
                        {
                            clsProcess.Kill();
                            break;
                        }
                    }
            MessageBox.Show("L'importation des données dans le XML a été effectué correctement !");
        }

        private void btnCancel1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
