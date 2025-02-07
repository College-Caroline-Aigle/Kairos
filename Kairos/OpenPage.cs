using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Globalization;

namespace FichesT
{
    public partial class OpenPage : Form
    {
        private BarreDeChargement barreDeCharge;
        TextInfo myTI = new CultureInfo("fr-FR", false).TextInfo;
        public OpenPage()
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

                Global.pathXLS = e.Argument as string;

                if (!string.IsNullOrEmpty(Global.pathXLS))
                {
                    // Réinitialise les différentes listes et variables globales
                    Global.nbEleves = 0;
                    Global.elevesValides.Clear(); // Supprime tous les éléments de la liste "elevesValides"
                    Global.options.Clear();
                    Global.lesOptions.Clear();
                    Global.listeClasseEleve.Clear();
                    Global.listeMefEleve.Clear();
                    Global.listeNaissanceEleve.Clear();
                    Global.listeNomEleve.Clear();
                    Global.listeNumEleve.Clear();
                    Global.listePrenomEleve.Clear();
                    Global.listeNomEtPrenomProf.Clear();
                    Global.listeLV1Eleve.Clear();
                    Global.listeOption1Eleve.Clear();
                    Global.listeOption2Eleve.Clear();
                    Global.listeSexeEleve.Clear();
                    Global.listeLV1EleveOption.Clear();
                    Global.listeOption1EleveOption.Clear();
                    Global.listeOption2EleveOption.Clear();
                    Global.listeSexeEleve.Clear();
                    Global.listeDateEntreeEleve.Clear();
                    Global.listeDateSortieEleve.Clear();
                    Global.listeEtabOrig.Clear();
                    Global.listeIneEleve.Clear();
                    Global.listeRedouble.Clear();

                    // Réinitialise les listes des noms de classe par niveau
                    Global.nomsClasses6e.Clear();
                    Global.nomsClasses5e.Clear();
                    Global.nomsClasses4e.Clear();
                    Global.nomsClasses3e.Clear();


                    try
                    {


                        //Version Excel 
                        Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                        Workbook wb;
                        Worksheet ws;

                        wb = excel.Workbooks.Open(Global.pathXLS);
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

                            Global.listeRedouble.Add(ws.Cells[i, 11].Value);

                            if (classe != "" && classe != null)
                                Global.listeClasseEleve.Add(classe);
                            else
                                Global.listeClasseEleve.Add("Vide");

                            string ine = ws.Cells[i, 12].Value;

                            if (!String.IsNullOrEmpty(ine))
                                Global.listeIneEleve.Add(ine);
                            else
                                Global.listeIneEleve.Add("Vide");

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
                            string libMEF = "";
                            libMEF = ws.Cells[i, 34].Value;
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

                                if (MEF.Last() == '9')
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

                        var result = MessageBox.Show("L'importation au format XLS est terminé. Vous pouvez sélectionner une classe.", "Import terminé", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        // Fermer le processus Excel
                        foreach (Process clsProcess in Process.GetProcesses())
                        {
                            if (clsProcess.ProcessName.Equals("EXCEL"))
                            {
                                clsProcess.Kill();
                                break;

                            }
                        }

                        //Déclaration de listes locales pour stocker les élèves par classes puis les trier
                        List<string> memory6e = new List<string>();
                        List<string> memory5e = new List<string>();
                        List<string> memory4e = new List<string>();
                        List<string> memory3e = new List<string>();

                        //memory pour garder en mémoire les noms des classes récupérés


                        for (int i = 0; i < Global.nbEleves; i++) //parcours tous les élèves même ceux sans classe ni code MEF
                        {
                            //Ajoute les élèves aux listes memory 6e, 5e, 4e ou 3e selon si le nom de leur classe contient un 6, un 5, un 4 ou un 3
                            if (Global.listeClasseEleve[i].Substring(0, 1) == "6")
                                memory6e.Add(Global.listeClasseEleve[i]);
                            if (Global.listeClasseEleve[i].Substring(0, 1) == "5")
                                memory5e.Add(Global.listeClasseEleve[i]);
                            if (Global.listeClasseEleve[i].Substring(0, 1) == "4")
                                memory4e.Add(Global.listeClasseEleve[i]);
                            if (Global.listeClasseEleve[i].Substring(0, 1) == "3")
                                memory3e.Add(Global.listeClasseEleve[i]);
                        }

                        //Supprime les doublons de classes et importe dans de nouvelles listes utilisables ailleurs
                        Global.nomsClasses6e = memory6e.Distinct().ToList();
                        Global.nomsClasses5e = memory5e.Distinct().ToList();
                        Global.nomsClasses4e = memory4e.Distinct().ToList();
                        Global.nomsClasses3e = memory3e.Distinct().ToList();

                        InterfacePrinc InterfacePr = new InterfacePrinc();
                        InterfacePr.repartitionEleves(); //lancement de la procédure de répartition des élèves dans des tableaux
                    }
                    catch (Exception ex) 
                    { 
                        MessageBox.Show("Une erreur est survenue. \nIl vous manque peut-être Microsoft Office Excel, qui est nécessaire au bon fonctionnement de cette application. \n" + ex.Message);
                    }
                }
            }

            else if (rdbXLSX.Checked)                       //Importation depuis XLSX
            {

                Global.pathXLSX = e.Argument as string;

                if (!string.IsNullOrEmpty(Global.pathXLSX))
                {
                    // Réinitialise les différentes listes et variables globales
                    Global.nbEleves = 0;
                    Global.elevesValides.Clear(); // Supprime tous les éléments de la liste "elevesValides"
                    Global.options.Clear();
                    Global.lesOptions.Clear();
                    Global.listeClasseEleve.Clear();
                    Global.listeMefEleve.Clear();
                    Global.listeNaissanceEleve.Clear();
                    Global.listeNomEleve.Clear();
                    Global.listeNumEleve.Clear();
                    Global.listePrenomEleve.Clear();
                    Global.listeNomEtPrenomProf.Clear();
                    Global.listeLV1Eleve.Clear();
                    Global.listeOption1Eleve.Clear();
                    Global.listeOption2Eleve.Clear();
                    Global.listeSexeEleve.Clear();
                    Global.listeLV1EleveOption.Clear();
                    Global.listeOption1EleveOption.Clear();
                    Global.listeOption2EleveOption.Clear();
                    Global.listeSexeEleve.Clear();
                    Global.listeDateEntreeEleve.Clear();
                    Global.listeDateSortieEleve.Clear();
                    Global.listeEtabOrig.Clear();
                    Global.listeIneEleve.Clear();
                    Global.listeRedouble.Clear();

                    // Réinitialise les listes des noms de classe par niveau
                    Global.nomsClasses6e.Clear();
                    Global.nomsClasses5e.Clear();
                    Global.nomsClasses4e.Clear();
                    Global.nomsClasses3e.Clear();

                    try
                    {

                        //Version XLSX
                        Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                        Workbook wb;
                        Worksheet ws;

                        wb = excel.Workbooks.Open(Global.pathXLSX);
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

                            Global.listeRedouble.Add(ws.Cells[i, 11].Value);

                            if (classe != "" && classe != null)
                                Global.listeClasseEleve.Add(classe);
                            else
                                Global.listeClasseEleve.Add("Vide");

                            string ine = ws.Cells[i, 12].Value;

                            if (!String.IsNullOrEmpty(ine))
                                Global.listeIneEleve.Add(ine);
                            else
                                Global.listeIneEleve.Add("Vide");

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
                            string libMEF = "";
                            libMEF = ws.Cells[i, 34].Value;
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
                                if (libMEF.Contains("bilingue"))
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


                        var result = MessageBox.Show("L'importation au format XLSX est terminé. Vous pouvez sélectionner une classe.", "Import terminé", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        // Fermer le processus Excel
                        foreach (Process clsProcess in Process.GetProcesses())
                        {
                            if (clsProcess.ProcessName.Equals("EXCEL"))
                            {
                                clsProcess.Kill();
                                break;
                            }
                        }


                        //Déclaration de listes locales pour stocker les élèves par classes puis les trier
                        List<string> memory6e = new List<string>();
                        List<string> memory5e = new List<string>();
                        List<string> memory4e = new List<string>();
                        List<string> memory3e = new List<string>();

                        //memory pour garder en mémoire les noms des classes récupérés


                        for (int i = 0; i < Global.nbEleves; i++) //parcours tous les élèves même ceux sans classe ni code MEF
                        {
                            //Ajoute les élèves aux listes memory 6e, 5e, 4e ou 3e selon si le nom de leur classe contient un 6, un 5, un 4 ou un 3
                            if (Global.listeClasseEleve[i].Substring(0, 1) == "6")
                                memory6e.Add(Global.listeClasseEleve[i]);
                            if (Global.listeClasseEleve[i].Substring(0, 1) == "5")
                                memory5e.Add(Global.listeClasseEleve[i]);
                            if (Global.listeClasseEleve[i].Substring(0, 1) == "4")
                                memory4e.Add(Global.listeClasseEleve[i]);
                            if (Global.listeClasseEleve[i].Substring(0, 1) == "3")
                                memory3e.Add(Global.listeClasseEleve[i]);
                        }

                        //Supprime les doublons de classes et importe dans de nouvelles listes utilisables ailleurs
                        Global.nomsClasses6e = memory6e.Distinct().ToList();
                        Global.nomsClasses5e = memory5e.Distinct().ToList();
                        Global.nomsClasses4e = memory4e.Distinct().ToList();
                        Global.nomsClasses3e = memory3e.Distinct().ToList();

                        InterfacePrinc InterfacePr = new InterfacePrinc();
                        InterfacePr.repartitionEleves(); //lancement de la procédure de répartition des élèves dans des tableaux
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Une erreur est survenue. \nIl vous manque peut-être Microsoft Office Excel, qui est nécessaire au bon fonctionnement de cette application. \n" + ex.Message);
                    }
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
            MessageBox.Show("L'importation des données dans le XML a été effectué correctement ! \n Cliquez sur le bouton ACTUALISER.");
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (rdbXLS.Checked)    // Importation au format XLS
            {
                // Réinitialisation des variables globales et des options
                Global.nbEleves = 0;
                Global.nbElevesReal = 0;
                Global.options.Clear();

                // Configuration de la boîte de dialogue pour sélectionner un fichier XLS
                OpenFileDialog OFD = new OpenFileDialog();
                OFD.Filter = "Excel files (*.xls)|*.xls"; // Filtrer les fichiers pour n'afficher que les fichiers .xls
                OFD.FilterIndex = 1; // Sélectionner le premier filtre par défaut
                OFD.RestoreDirectory = true; // Restaurer le répertoire précédent ouvert

                // Afficher la boîte de dialogue de sélection de fichier et récupérer le résultat
                DialogResult dr = OFD.ShowDialog();
                if (dr == DialogResult.OK) // Si un fichier a été sélectionné
                {
                    string path = OFD.FileName; // Récupérer le chemin du fichier sélectionné
                    Global.pathXLS = path; // Enregistrer le chemin du fichier XLS dans une variable globale
                    this.Close(); // Fermer la fenêtre actuelle
                }

                // Si un chemin de fichier valide a été sélectionné
                if (!string.IsNullOrEmpty(Global.pathXLS))
                {
                    // Afficher un message pour informer l'utilisateur du début de l'importation
                    MessageBox.Show("L'import au format XLS va commencer. Veuillez cliquer sur OK pour démarrer l'importation. Patientez, un message apparaîtra une fois l'importation terminée");

                    // Afficher une barre de chargement
                    barreDeCharge = new BarreDeChargement();
                    barreDeCharge.Text = "Importation en cours";
                    barreDeCharge.Show();
                    // Démarrer le travail en arrière-plan pour importer les données depuis le fichier XLS
                    backgroundWorker1.RunWorkerAsync(Global.pathXLS);
                }
            }

            else if (rdbXLSX.Checked) // importation au format XLSX
            {
                // Réinitialisation des variables globales et des options
                Global.nbEleves = 0;
                Global.nbElevesReal = 0;
                Global.options.Clear();

                // Configuration de la boîte de dialogue pour sélectionner un fichier XLSX
                OpenFileDialog OFD = new OpenFileDialog();
                OFD.Filter = "Excel files (*.xlsx)|*.xlsx"; // Filtrer les fichiers pour n'afficher que les fichiers .xlsx
                OFD.FilterIndex = 1; // Sélectionner le premier filtre par défaut
                OFD.RestoreDirectory = true; // Restaurer le répertoire précédent ouvert

                // Afficher la boîte de dialogue de sélection de fichier et récupérer le résultat
                DialogResult dr = OFD.ShowDialog();
                if (dr == DialogResult.OK) // Si un fichier a été sélectionné
                {
                    string path = OFD.FileName; // Récupérer le chemin du fichier sélectionné
                    Global.pathXLSX = path; // Enregistrer le chemin du fichier XLSX dans une variable globale
                    this.Close(); // Fermer la fenêtre actuelle
                }

                // Si un chemin de fichier valide a été sélectionné
                if (!string.IsNullOrEmpty(Global.pathXLSX))
                {
                    // Afficher un message pour informer l'utilisateur du début de l'importation
                    MessageBox.Show("L'import au format XLSX va commencer. Veuillez cliquer sur OK pour démarrer l'importation. Patientez, un message apparaîtra une fois l'importation terminée");

                    // Afficher une barre de chargement
                    barreDeCharge = new BarreDeChargement();
                    barreDeCharge.Text = "Importation en cours";
                    barreDeCharge.Show();
                    // Démarrer le travail en arrière-plan pour importer les données depuis le fichier XLSX
                    backgroundWorker1.RunWorkerAsync(Global.pathXLSX);
                }
            }
        }

        private void btnCancel1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void OpenPage_Load(object sender, EventArgs e)
        {

        }

        private void lblText1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
