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
using System.IO;
using System.Diagnostics;

namespace FichesT
{
    public partial class OuvertureFichierGenererParNous : Form
    {
        public OuvertureFichierGenererParNous()
        {
            InitializeComponent();
        }

        private void btnOuvrirFIchierCsv_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();

            OFD.InitialDirectory = "c:\\";
            OFD.Filter = "XML files (*.xml)|*.xml";
            OFD.FilterIndex = 2;
            OFD.RestoreDirectory = true;
            DialogResult dr = OFD.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string path = OFD.FileName;
                Global.pathXML = path;
                this.Close();
                //On garde en mémoire le chemin vers le fichier XML
            }

            if (!string.IsNullOrEmpty(Global.pathXML))
            {
                try
                {
                    Global.nbEleves = 0;
                    Global.nbElevesReal = 0;
                    Global.options.Clear();
                    List<Niveau> listNiveau = new List<Niveau>();
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(Global.pathXML);
                    XmlNodeList niveauNodes = xmlDoc.SelectNodes("//College/Niveau");

                    foreach (XmlNode niveauNode in niveauNodes)
                    {
                        string nomNiveau = niveauNode.Attributes["nomNiveau"].Value;
                        Niveau niveau = new Niveau(nomNiveau);

                        List<Classe> listClasse = new List<Classe>();
                        //Global.lesNiveaux.Add(niveau); // listNiveau.Add(niveau);

                        XmlNodeList classeNodes = niveauNode.SelectNodes("Classe");
                        foreach (XmlNode classeNode in classeNodes)
                        {

                            string nomClasse = classeNode.Attributes["nomClasse"].Value;
                            string nomProf = classeNode.Attributes["nomProfPrinc"].Value;
                            if(nomProf != "")
                            {
                                Global.listeNomEtPrenomProf.Add(nomProf);
                            }
                            Classe classe = new Classe(nomClasse, nomProf);
                            // listClasse.Add(classe); 
                            List<Eleve> listEleve = new List<Eleve>();

                            XmlNodeList eleveNodes = classeNode.SelectNodes("Eleve");
                            foreach (XmlNode eleveNode in eleveNodes)
                            {
                                int numEleve = Convert.ToInt32(eleveNode.Attributes["numEleve"].Value);
                                Global.listeNumEleve.Add(numEleve);
                                string ineEleve = eleveNode["ineEleve"].InnerText;
                                string nomEleve = eleveNode["nomEleve"].InnerText;
                                string prenomEleve = eleveNode["prenomEleve"].InnerText;
                                string naissanceEleve = eleveNode["naissanceEleve"].InnerText;
                                string sexeEleve = eleveNode["sexeEleve"].InnerText;
                                string mefEleve = eleveNode["mefEleve"].InnerText;
                                string redouble = eleveNode["redouble"].InnerText;
                                string LV1Eleve = eleveNode["LV1Eleve"].InnerText;
                                string option1Eleve = eleveNode["option1Eleve"].InnerText;
                                if (String.IsNullOrEmpty(option1Eleve))
                                {
                                    option1Eleve = "Aucune";
                                }
                                string option2Eleve = eleveNode["option2Eleve"].InnerText;
                                string eleveNonInscrit = eleveNode["eleveNonInscrit"].InnerText;
                                string etabOrig = eleveNode["etabOrig"].InnerText;
                                string[] anciennesClasses = eleveNode["anciennesClasses"].InnerText.Split(';');
                                List<string> lesAnciennesClasse = new List<string>();
                                foreach (string cls in anciennesClasses)
                                    lesAnciennesClasse.Add(cls);

                                string anciennesNotes = eleveNode["anciennesNotes"].InnerText;
                                List<char> lesAnciennesNotes = new List<char>();
                                foreach (char nte in anciennesNotes)
                                {
                                    if (nte != ';')
                                        lesAnciennesNotes.Add(nte);
                                }
                                Options LV1EleveOption = new Options(LV1Eleve);
                                Options option1EleveOption = new Options(option1Eleve);
                                Options option2EleveOption = new Options(option2Eleve);

                                int annee = Int32.Parse(eleveNode["dateEntree"].InnerText.Substring(6));
                                int mois = Int32.Parse(eleveNode["dateEntree"].InnerText.Substring(3, 2));
                                int jour = Int32.Parse(eleveNode["dateEntree"].InnerText.Substring(0, 2));

                                DateTime dateEntree = new DateTime(annee, mois, jour);

                                string note = eleveNode["note"].InnerText;
                                Eleve eleve = new Eleve(numEleve, nomEleve, prenomEleve, naissanceEleve, sexeEleve, mefEleve, redouble, nomClasse,LV1Eleve, option1Eleve, option2Eleve, LV1EleveOption, option1EleveOption, option2EleveOption, dateEntree)
                                {
                                    rdbNiveau = new RadioButton(),
                                    ine = ineEleve,
                                    anciennesClasses = lesAnciennesClasse,
                                    anciensNiveaux = lesAnciennesNotes
                                };
                                eleve.nonInscrit = eleveNonInscrit;
                                eleve.etablissementOrigine = etabOrig;
                                if (!String.IsNullOrEmpty(eleveNode["dateSortie"].InnerText))
                                {
                                    annee = Int32.Parse(eleveNode["dateSortie"].InnerText.Substring(6));
                                    mois = Int32.Parse(eleveNode["dateSortie"].InnerText.Substring(3, 2));
                                    jour = Int32.Parse(eleveNode["dateSortie"].InnerText.Substring(0, 2));

                                    eleve.setDateSortie(new DateTime(annee, mois, jour));
                                }
                                else
                                    eleve.setDateSortie(default);
                                eleve.rdbNiveau.Name = "rdb" + note;
                                listEleve.Add(eleve);
                                eleve.classeEleve = nomClasse;
                                if (nomClasse.Substring(0, 1) != "2")
                                    Global.nbEleves++;
                                Global.elevesValides.Add(eleve);

                                string testListeOption = LV1Eleve;
                                if (!String.IsNullOrEmpty(LV1Eleve) && LV1Eleve.Contains("Lv1"))
                                    testListeOption = LV1Eleve.Remove(LV1Eleve.IndexOf("Lv1"));

                                if (!Global.lesOptions.Contains(testListeOption))
                                {
                                    if (!String.IsNullOrEmpty(testListeOption) && !Global.lesOptions.Any(s => s.Contains(testListeOption.Substring(0, 3))))
                                    {
                                        Global.lesOptions.Add(testListeOption);
                                        Global.options.Add(new Options(testListeOption));
                                    }
                                }
                                if (option1Eleve.Contains("Lv2"))
                                {
                                    testListeOption = option1Eleve.Remove(option1Eleve.IndexOf("Lv2"));
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

                                    testListeOption = option2Eleve;
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
                                else if (option1Eleve.Contains("Lv1"))
                                {
                                    testListeOption = option1Eleve.Remove(option1Eleve.IndexOf("Lv1"));
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

                                    testListeOption = option2Eleve;
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
                                else
                                {
                                    testListeOption = option1Eleve;

                                    if (!Global.lesOptions.Any(s => s.Contains(testListeOption.Substring(0, 3))))
                                    {
                                        Global.lesOptions.Add(testListeOption);
                                        Global.options.Add(new Options(testListeOption));
                                    }

                                    testListeOption = option2Eleve;
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

                                        if ((testListeOption.Contains("Grec") || testListeOption.Contains("Ens")))
                                        {
                                            if (!Global.lesOptions.Contains(testListeOption))
                                            {
                                                Global.lesOptions.Add(testListeOption);
                                                Global.options.Add(new Options(testListeOption));
                                            }
                                        }
                                    }
                                }
                                Global.listeLV1Eleve.Add(LV1Eleve);
                                Global.listeOption1Eleve.Add(option1Eleve);
                                Global.listeOption2Eleve.Add(option2Eleve);
                            }
                            classe.setListEleve(listEleve);
                            listClasse.Add(classe);
                        }
                        niveau.setListClasse(listClasse);
                        listNiveau.Add(niveau);
                    }

                    Global.lesNiveaux = listNiveau;

                    this.Close();
                    MessageBox.Show("Les données ont bien été importées avec succès ! \n Cliquez sur le bouton ACTUALISER.");
                    //InterfacePr.pnlBarre_Paint();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.ToString());
                }
            }
        }

        private void btnAnnulerOuvertureCsv_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OuvertureFichierGenererParNous_Load(object sender, EventArgs e)
        {

        }
    }
}
