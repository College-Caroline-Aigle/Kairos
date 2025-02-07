using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Office.Interop.Excel;
using Microsoft.Win32.SafeHandles;
using System.Xml.Serialization;
using Button = System.Windows.Forms.Button;
using Font = System.Drawing.Font;
using GroupBox = System.Windows.Forms.GroupBox;
using Label = System.Windows.Forms.Label;
using Point = System.Drawing.Point;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices.ComTypes;
using System.Drawing.Printing;
using Rectangle = System.Drawing.Rectangle;
using Application = Microsoft.Office.Interop.Excel.Application;
using System.Runtime.InteropServices;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using OxyPlot.Axes;
using OxyPlot.Annotations;
using OxyPlot.Legends;

using HorizontalAlignmentOxyPlot = OxyPlot.HorizontalAlignment;
using PlotView = OxyPlot.WindowsForms.PlotView;
using Plotplo = OxyPlot.Wpf.PlotView;

namespace FichesT
{
    public partial class InterfacePrinc : Form
    {
        //Déclaration des booléens pour les animations de menus
        private bool MenuFichiers = true;
        private bool MenuNiveaux = true;
        private bool MenuEleve = true;
        private bool MenuClasse = true;
        private Panel currentPanel; // panel actif de la classe
        private Panel currentPanelEleve; // panel actif de l'élève
        private Panel currentPanelNiv;
        private int niveauCharge;

        // Le "FlowLayoutPanel" c'est un contrôle d'interface graphique qui permet de disposer dynamiquement les éléments enfants de manière fluide et adaptative.
        FlowLayoutPanel flowLayoutPanelPrinc;

        //Le "ToolTip" permet d'afficher un message contextuel lorsque l'utilisateur survole un élément de l'interface graphique
        ToolTip tltInforBoutonSupAffichage = new ToolTip();
        ToolTip tltInforBoutonSuppressionDonnees = new ToolTip();

        private BarreDeChargement barreDeChargement;

        public InterfacePrinc()
        {
            InitializeComponent(); //initialisation de l'interface principale
        }

        private void btnOpenBase_Click(object sender, EventArgs e) //Quand le bouton fichier est cliqué
        {
            OpenPage uneOpenPage = new OpenPage(); //initialise une instance de OpenPage afin de récupérer ses variables et fonctions
            uneOpenPage.Show(); //affiche l'instance
            uneOpenPage.TopMost = true; //affiche au dessus des autres pages
        }

        #region Animations
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //ANIMATIONS
        private void btnFiles_Click(object sender, EventArgs e)
        {
            FichierTimer.Start();
        }
        private void FichierTimer_Tick(object sender, EventArgs e)
        {
            if (MenuFichiers) //Si le menu Fichier est fermé (à sa taille minimale), alors :
            {
                pnlContientFichiers.Height += 10; //Permet au panel d'augmenter sa hauteur de 10px 
                if (pnlContientFichiers.Height == pnlContientFichiers.MaximumSize.Height) //Si la taille du panel est égale à sa taille maximale
                {
                    MenuFichiers = false; //le booléens est faux lorsque que la taille du panelContientFichiers à atteint sa taille maximum
                    FichierTimer.Stop(); //Le Timer de Fichier peut s'arrêter
                }
            }
            else
            {
                pnlContientFichiers.Height -= 10;  //Permet au panel de réduire sa hauteur de 10px
                if (pnlContientFichiers.Height == pnlContientFichiers.MinimumSize.Height) //Si la taille du panel est égale a sa taille minimale
                {
                    MenuFichiers = true; //le booléens est vrai lorsque que la taille du panelContientFichiers à atteint sa taille Minimale
                    FichierTimer.Stop();
                }
            }
        }
        private void btnNiveaux_Click(object sender, EventArgs e)
        {
            NiveauxTimer.Start();
        }
        private void NiveauxTimer_Tick(object sender, EventArgs e)
        {
            if (MenuNiveaux)
            {
                pnlNiveaux.Height += 10;
                if (pnlNiveaux.Size == pnlNiveaux.MaximumSize)
                {
                    MenuNiveaux = false;
                    NiveauxTimer.Stop();
                }
            }
            else
            {
                pnlNiveaux.Height -= 10;
                if (pnlNiveaux.Height == pnlNiveaux.MinimumSize.Height)
                {
                    MenuNiveaux = true;
                    NiveauxTimer.Stop();
                }
            }
        }
        private void Btnélèves_Click(object sender, EventArgs e)
        {
            EleveTimer.Start();
        }
        private void EleveTimer_Tick(object sender, EventArgs e)
        {
            if (MenuEleve)
            {
                pnlEleves.Height += 10;
                if (pnlEleves.Size == pnlEleves.MaximumSize)
                {
                    MenuEleve = false;
                    EleveTimer.Stop();
                }
            }
            else
            {
                pnlEleves.Height -= 10;
                if (pnlEleves.Height == pnlEleves.MinimumSize.Height)
                {
                    MenuEleve = true;
                    EleveTimer.Stop();
                }
            }
        }
        private void btnClasse_Click(object sender, EventArgs e)
        {
            ClasseTimer.Start();
        }
        private void ClasseTimer_Tick(object sender, EventArgs e)
        {
            if (MenuClasse)
            {
                pnlClasse.Height += 10;
                if (pnlClasse.Size == pnlClasse.MaximumSize)
                {
                    MenuClasse = false;
                    ClasseTimer.Stop();
                }
            }
            else
            {
                pnlClasse.Height -= 10;
                if (pnlClasse.Height == pnlClasse.MinimumSize.Height)
                {
                    MenuClasse = true;
                    ClasseTimer.Stop();
                }
            }
        }
        //FIN ANIMATIONS
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion

        // Les commentaires de ce bouton sont applicable pour le code des 3 autres boutons car ils fonctionnent de la même manière------------------!
        private void btn6ème_Click(object sender, EventArgs e)
        {
            try
            {
                if (Global.elevesValides.Count() != 0)
                {
                    layoutNiveaux.Controls.Clear();
                    layoutNiveaux.Tag = Global.lesNiveaux[0];
                    niveauCharge = 6;
                    // Une liste classeDe6eme est initialisée avec les classes du premier niveau dans Global.lesNiveaux[0].getLesClasse()
                    List<Classe> classeDe6eme = Global.lesNiveaux[0].getLesClasse().OrderByDescending(classe => classe.nomDeLaClasse).ToList();


                    // Un nouvel objet FlowLayoutPanel est créé et assigné à la variable flowLayoutPanelPrinc. Ce conteneur sera utilisé pour afficher les informations des classes
                    flowLayoutPanelPrinc = new FlowLayoutPanel();
                    // Dock est défini sur DockStyle.Top pour le positionner en haut du conteneur parent
                    flowLayoutPanelPrinc.Dock = DockStyle.Top;
                    // AutoSize est défini sur true pour ajuster automatiquement sa taille en fonction du contenu
                    flowLayoutPanelPrinc.AutoSize = true;
                    // FlowDirection est défini sur FlowDirection.TopDown pour organiser les éléments de haut en ba
                    flowLayoutPanelPrinc.FlowDirection = FlowDirection.TopDown;
                    // WrapContents est défini sur false pour éviter le renvoi à la ligne des éléments
                    flowLayoutPanelPrinc.WrapContents = false;

                    layoutNiveaux.Controls.Add(flowLayoutPanelPrinc);
                    Controls.Add(flowLayoutPanelPrinc);
                    flowLayoutPanelPrinc.BringToFront();

                    for (int i = 0; i < classeDe6eme.Count(); i++)
                    {
                        //Récupérer la liste des élèves de la classe courante
                        List<Eleve> uneListeEleve = classeDe6eme[i].getLesEleves().OrderBy(eleve => eleve.nomEleve).ToList();

                        List<Eleve> versLaFin = new List<Eleve>();

                        int k = 0;

                        while (k < uneListeEleve.Count)
                        {
                            if (uneListeEleve[k].dateSortie != default)
                            {
                                versLaFin.Add(uneListeEleve[k]);
                                uneListeEleve.RemoveAt(k);
                                k = 0;
                            }
                            else
                            {
                                k++;
                            }
                        }

                        foreach (Eleve el in versLaFin)
                        {
                            uneListeEleve.Add(el);
                        }

                        // Création des colonnes qui contient le prof principal, la classe et les élèves sous forme de panel 
                        // ------------------------------------------------------------------------- //
                        //Un nouvel objet FlowLayoutPanel est créé et assigné à la variable colonnePourLesClasses.
                        //Ce conteneur sera utilisé pour afficher les informations de la classe, le professeur principal et les élèves
                        FlowLayoutPanel colonnePourLesClasses = new FlowLayoutPanel();
                        // La propriété Dock est définie sur DockStyle.Left, ce qui permet au conteneur de se positionner sur le côté gauche de son conteneur parent
                        colonnePourLesClasses.Dock = DockStyle.Left;
                        // La propriété AutoSize est définie sur true, ce qui permet au conteneur d'ajuster automatiquement sa taille en fonction de son contenu
                        colonnePourLesClasses.AutoSize = true;
                        // Définition de la taille du FlowLayoutPanel
                        colonnePourLesClasses.Size = new Size(162, 4);
                        // La propriété FlowDirection est définie sur FlowDirection.TopDown, ce qui indique que les éléments du conteneur seront disposés de haut en bas
                        colonnePourLesClasses.FlowDirection = FlowDirection.TopDown;
                        // La propriété WrapContents est définie sur false, ce qui signifie que les éléments ne seront pas enveloppés et continueront à être affichés en haut en bas même s'ils dépassent la taille du conteneur
                        colonnePourLesClasses.WrapContents = false;
                        // ------------------------------------------------------------------------- //

                        // Pour afficher le professeur principal de la classe
                        // ------------------------------------------------------------------------- //



                        // Un nouvel objet Label est créé et assigné à la variable lblProfPrinc. 
                        // Ce Label sera utilisé pour afficher le professeur principal de la classe et permettre de le changer si nécessaire
                        Label lblProfPrinc = new Label();
                        // La propriété BackColor est définie sur Color.WhiteSmoke, ce qui définit la couleur de fond du Label comme étant du blanc fumée
                        lblProfPrinc.BackColor = Color.WhiteSmoke;
                        // Définition de la position du Label
                        lblProfPrinc.Location = new Point(2, 2);
                        // Définition de la taille du Label
                        lblProfPrinc.Size = new Size(162, 30);
                        // La propriété TabIndex est définie sur 1, ce qui indique l'ordre de tabulation du contrôle lors de la navigation au clavier.
                        lblProfPrinc.TabIndex = 1;
                        // Mettre le texte du nom du professeur Principal
                        lblProfPrinc.Text = classeDe6eme[i].getNomProfPrinc();

                        // ------------------------------------------------------------------------- //

                        // Pour afficher le nom de la classe
                        // ------------------------------------------------------------------------- //
                        // Création d'un nouveau Panel pour afficher une classe
                        Panel panelClasse = new Panel();
                        // Création d'un nouveau Label pour afficher le nom de la classe
                        Label lblNomClasse = new Label();
                        // Définition de la couleur d'arrière-plan du Panel
                        panelClasse.BackColor = Color.FromArgb(235, 194, 154);
                        // Ajout du Label à la liste des contrôles du Panel
                        panelClasse.Controls.Add(lblNomClasse);
                        // Définition de la position du Panel sur la forme
                        panelClasse.Location = new Point(172, 182);
                        // Définition des marges du Panel (espaces autour du contrôle)
                        panelClasse.Margin = new Padding(2, 0, 2, 2);
                        // Définition de la taille du Panel
                        panelClasse.Size = new Size(162, 46);
                        // Définition de l'index de tabulation du Panel
                        panelClasse.TabIndex = 3;

                        // Le ".Tag" permet de stocker dans le panel un objet pour ne pas le perdre
                        panelClasse.Tag = classeDe6eme[i];

                        // Le ".DoubleClick" permet de mettre en place le double-clique pour chaque panel de classe 
                        // Pour pouvoir l'utiliser, il faut l'écrire à la main.
                        panelClasse.DoubleClick += PanelClasse_DoubleClick;
                        panelClasse.MouseHover += PanelClasse_MouseHover;
                        panelClasse.MouseLeave += PanelClasse_MouseLeave;

                        // Définition de la propriété AutoSize pour ajuster automatiquement la taille du Label en fonction de son contenu
                        lblNomClasse.AutoSize = true;
                        // Définition de la propriété Dock pour ancrer le Label en haut du Panel
                        lblNomClasse.Dock = DockStyle.Top;
                        // Définition de la position du Label à l'intérieur du Panel
                        lblNomClasse.Location = new Point(0, 0);
                        // Définition des marges du Label (espaces autour du contrôle)
                        lblNomClasse.Margin = new Padding(2, 0, 2, 0);
                        // Définition du nom du Label
                        lblNomClasse.Name = "lblNomClasse";
                        // Définition des marges intérieures du Label (espaces à l'intérieur du contrôle)
                        lblNomClasse.Padding = new Padding(50, 13, 12, 13);
                        // Définition de la taille du Label
                        lblNomClasse.Size = new Size(90, 39);
                        // Définition de l'index de tabulation du Label
                        lblNomClasse.TabIndex = 0;
                        // Définition du texte affiché dans le Label en utilisant le nom de la classe de 6ème correspondant
                        lblNomClasse.Text = classeDe6eme[i].nomDeLaClasse;
                        // Définition de l'alignement du texte dans le Label (centré horizontalement et verticalement)
                        lblNomClasse.TextAlign = ContentAlignment.MiddleCenter;
                        lblNomClasse.DoubleClick += (s, ev) => PanelClasse_DoubleClick(panelClasse, e);
                        lblNomClasse.MouseHover += (s, ev) => PanelClasse_MouseHover(panelClasse, e);
                        lblNomClasse.MouseLeave += (s, ev) => PanelClasse_MouseLeave(panelClasse, e);
                        // ------------------------------------------------------------------------- //

                        // Ajout du Label lblProfPrinc au contrôle colonnePourLesClasses
                        colonnePourLesClasses.Controls.Add(lblProfPrinc);
                        // Ajout du Panel panelClasse au contrôle colonnePourLesClasses
                        colonnePourLesClasses.Controls.Add(panelClasse);
                        // Ajout du contrôle colonnePourLesClasses au formulaire principal
                        Controls.Add(colonnePourLesClasses);

                        // Ajout du contrôle colonnePourLesClasses au contrôle layoutNiveaux
                        layoutNiveaux.Controls.Add(colonnePourLesClasses);

                        // Boucle sur chaque élève dans la liste uneListeEleve
                        for (int j = 0; j < uneListeEleve.Count(); j++)
                        {
                            // Récupération de l'objet Eleve correspondant à l'index j dans la liste uneListeEleve
                            Eleve unEleve = uneListeEleve[j];
                            // Vérification si l'index j est un multiple de 10 (donc tous les 10 élèves) et différent de zéro
                            if (j % 10 == 0 && j != 0)
                            {
                                // Ajout d'un Label vide à colonnePourLesClasses pour créer un espacement (pour le visuel)
                                colonnePourLesClasses.Controls.Add(new Label() { Text = " " });
                            }
                            // Création d'un nouveau Panel pour représenter un élève
                            Panel panelEleve = new Panel();
                            // Définition du texte du panel (vide dans ce cas)
                            panelEleve.Text = "";
                            // Définition de la taille du panel
                            panelEleve.Size = new Size(162, 46);
                            // Gestion de l'événement DoubleClick pour le panel
                            panelEleve.DoubleClick += PanelEleve_DoubleClick;
                            if (unEleve.dateSortie != default)
                            {
                                panelEleve.BackColor = Color.Red;
                                panelEleve.MouseHover += PanelEleveParti_MouseHover;
                                panelEleve.MouseLeave += PanelEleveParti_MouseLeave;
                            }
                            else if (!String.IsNullOrEmpty(unEleve.nonInscrit))
                            {
                                panelEleve.BackColor = Color.LightGray;
                                panelEleve.MouseHover += PanelEleveNonInscrit_MouseHover;
                                panelEleve.MouseLeave += PanelEleveNonInscrit_MouseLeave;

                            }
                            else
                            {
                                panelEleve.BackColor = Color.FromArgb(253, 255, 157);
                                panelEleve.MouseHover += PanelEleve6eme_MouseHover;
                                panelEleve.MouseLeave += PanelEleve6eme_MouseLeave;

                            }

                            // Nom de famille de l'élève
                            // Création d'un Label pour afficher le nom de famille de l'élève
                            Label lblNomEleve = new Label();
                            // Définition du texte du Label avec le nom de famille de l'élève
                            lblNomEleve.Text = unEleve.nomEleve;
                            // Définition de la taille du Label
                            lblNomEleve.Size = new Size(29, 13);
                            // Définition de la position du Label dans le Panel
                            lblNomEleve.Location = new Point(4, 1);
                            // Définition de l'ajustement automatique de la taille du Label
                            lblNomEleve.AutoSize = true;
                            // Définition des marges du Label
                            lblNomEleve.Margin = new Padding(2, 0, 2, 0);
                            // Définition du nom du Label
                            lblNomEleve.Name = "lblNomEleve";
                            // Définition de la police du Label
                            lblNomEleve.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
                            // Définition de l'alignement du texte dans le Label (alignement à gauche)
                            lblNomEleve.TextAlign = ContentAlignment.MiddleLeft;
                            lblNomEleve.DoubleClick += (s, ev) => PanelEleve_DoubleClick(panelEleve, e);
                            if (unEleve.dateSortie != default)
                            {
                                lblNomEleve.MouseHover += (s, ev) => PanelEleveParti_MouseHover(panelEleve, e);
                                lblNomEleve.MouseLeave += (s, ev) => PanelEleveParti_MouseLeave(panelEleve, e);
                            }
                            else if (!String.IsNullOrEmpty(unEleve.nonInscrit))
                            {
                                lblNomEleve.MouseHover += (s, ev) => PanelEleveNonInscrit_MouseHover(panelEleve, e);
                                lblNomEleve.MouseLeave += (s, ev) => PanelEleveNonInscrit_MouseLeave(panelEleve, e);
                            }
                            else
                            {
                                lblNomEleve.MouseHover += (s, ev) => PanelEleve6eme_MouseHover(panelEleve, e);
                                lblNomEleve.MouseLeave += (s, ev) => PanelEleve6eme_MouseLeave(panelEleve, e);
                            }
                            // Ajout du Label au Panel pour l'afficher à l'intérieur
                            panelEleve.Controls.Add(lblNomEleve);

                            // Prenom de l'élève
                            // Création d'un Label pour afficher le prénom de l'élève
                            Label lblPrenomEleve = new Label();
                            // Définition du texte du Label avec le prénom de l'élève
                            lblPrenomEleve.Text = unEleve.prenomEleve;
                            // Définition de la taille du Label
                            lblPrenomEleve.Size = new Size(80, 13);
                            // Définition des marges du Label
                            lblPrenomEleve.Margin = new Padding(2, 0, 2, 0);
                            // Définition de la position du Label dans le Panel
                            lblPrenomEleve.Location = new Point(2, 17);
                            // Définition du nom du Label
                            lblPrenomEleve.Name = "lblPrenomEleve";
                            // Définition de la police du Label
                            lblPrenomEleve.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
                            // Définition de l'alignement du texte dans le Label (alignement à gauche)
                            lblPrenomEleve.TextAlign = ContentAlignment.MiddleLeft;
                            lblPrenomEleve.DoubleClick += (s, ev) => PanelEleve_DoubleClick(panelEleve, e);
                            if (unEleve.dateSortie != default)
                            {
                                lblPrenomEleve.MouseHover += (s, ev) => PanelEleveParti_MouseHover(panelEleve, e);
                                lblPrenomEleve.MouseLeave += (s, ev) => PanelEleveParti_MouseLeave(panelEleve, e);
                            }
                            else if (!String.IsNullOrEmpty(unEleve.nonInscrit))
                            {
                                lblPrenomEleve.MouseHover += (s, ev) => PanelEleveNonInscrit_MouseHover(panelEleve, e);
                                lblPrenomEleve.MouseLeave += (s, ev) => PanelEleveNonInscrit_MouseLeave(panelEleve, e);
                            }
                            else
                            {
                                lblPrenomEleve.MouseHover += (s, ev) => PanelEleve6eme_MouseHover(panelEleve, e);
                                lblPrenomEleve.MouseLeave += (s, ev) => PanelEleve6eme_MouseLeave(panelEleve, e);
                            }
                            // Ajout du Label au Panel pour l'afficher à l'intérieur
                            panelEleve.Controls.Add(lblPrenomEleve);

                            if (unEleve.redouble == "O")
                            {
                                Label lblRedouble = new Label();
                                lblRedouble.Text = "R";
                                lblRedouble.Location = new Point(2, 30);
                                lblRedouble.Size = new Size(80, 13);
                                lblRedouble.Name = "lblRedouble";
                                lblRedouble.Font = new Font("Microsoft Sans Serif", 7F, FontStyle.Bold, GraphicsUnit.Point, 0);
                                lblRedouble.TextAlign = ContentAlignment.MiddleLeft;
                                lblRedouble.DoubleClick += (s, ev) => PanelEleve_DoubleClick(panelEleve, e);
                                if (unEleve.dateSortie != default)
                                {
                                    lblRedouble.MouseHover += (s, ev) => PanelEleveParti_MouseHover(panelEleve, e);
                                    lblRedouble.MouseLeave += (s, ev) => PanelEleveParti_MouseLeave(panelEleve, e);
                                }
                                else if (!String.IsNullOrEmpty(unEleve.nonInscrit))
                                {
                                    lblRedouble.MouseHover += (s, ev) => PanelEleveNonInscrit_MouseHover(panelEleve, e);
                                    lblRedouble.MouseLeave += (s, ev) => PanelEleveNonInscrit_MouseLeave(panelEleve, e);
                                }
                                else
                                {
                                    lblRedouble.MouseHover += (s, ev) => PanelEleve6eme_MouseHover(panelEleve, e);
                                    lblRedouble.MouseLeave += (s, ev) => PanelEleve6eme_MouseLeave(panelEleve, e);
                                }
                                panelEleve.Controls.Add(lblRedouble);
                            }

                            if (!String.IsNullOrEmpty(unEleve.etablissementOrigine))
                            {
                                if (unEleve.etablissementOrigine != "Autre")
                                {
                                    Label lblEtabOrig = new Label();
                                    lblEtabOrig.Text = unEleve.etablissementOrigine;
                                    lblEtabOrig.Location = new Point(2, 30);
                                    lblEtabOrig.Size = new Size(90, 13);
                                    lblEtabOrig.Name = "lblEtabOrig";
                                    lblEtabOrig.Font = new Font("Microsoft Sans Serif", 7F, FontStyle.Bold, GraphicsUnit.Point, 0);
                                    lblEtabOrig.TextAlign = ContentAlignment.MiddleLeft;
                                    lblEtabOrig.DoubleClick += (s, ev) => PanelEleve_DoubleClick(panelEleve, e);
                                    if (unEleve.dateSortie != default)
                                    {
                                        lblEtabOrig.MouseHover += (s, ev) => PanelEleveParti_MouseHover(panelEleve, e);
                                        lblEtabOrig.MouseLeave += (s, ev) => PanelEleveParti_MouseLeave(panelEleve, e);
                                    }
                                    else if (!String.IsNullOrEmpty(unEleve.nonInscrit))
                                    {
                                        lblEtabOrig.MouseHover += (s, ev) => PanelEleveNonInscrit_MouseHover(panelEleve, e);
                                        lblEtabOrig.MouseLeave += (s, ev) => PanelEleveNonInscrit_MouseLeave(panelEleve, e);
                                    }
                                    else
                                    {
                                        lblEtabOrig.MouseHover += (s, ev) => PanelEleve6eme_MouseHover(panelEleve, e);
                                        lblEtabOrig.MouseLeave += (s, ev) => PanelEleve6eme_MouseLeave(panelEleve, e);
                                    }
                                    panelEleve.Controls.Add(lblEtabOrig);
                                }
                            }

                            //LV1 
                            // Création d'un nouveau Panel pour représenter la LV1 de l'élève
                            Panel panelLV1 = new Panel();
                            // Définition de la taille du Panel
                            panelLV1.Size = new Size(16, 32);
                            // Définition de la position du Panel dans le Panel principal
                            panelLV1.Location = new Point(96, 6);
                            // Définition de la couleur de fond du Panel en utilisant une méthode de l'objet unEleve
                            panelLV1.BackColor = unEleve.LV1.couleur;
                            panelLV1.BorderStyle = BorderStyle.FixedSingle;
                            // Définition du nom du Panel
                            panelLV1.Name = "panelLV1";
                            panelLV1.DoubleClick += (s, ev) => PanelEleve_DoubleClick(panelEleve, e);
                            if (unEleve.dateSortie != default)
                            {
                                panelLV1.MouseHover += (s, ev) => PanelEleveParti_MouseHover(panelEleve, e);
                                panelLV1.MouseLeave += (s, ev) => PanelEleveParti_MouseLeave(panelEleve, e);
                            }
                            else if (!String.IsNullOrEmpty(unEleve.nonInscrit))
                            {
                                panelLV1.MouseHover += (s, ev) => PanelEleveNonInscrit_MouseHover(panelEleve, e);
                                panelLV1.MouseLeave += (s, ev) => PanelEleveNonInscrit_MouseLeave(panelEleve, e);

                            }
                            else
                            {
                                panelLV1.MouseHover += (s, ev) => PanelEleve6eme_MouseHover(panelEleve, e);
                                panelLV1.MouseLeave += (s, ev) => PanelEleve6eme_MouseLeave(panelEleve, e);
                            }
                            // Ajout du Panel au Panel de l'élève pour l'afficher à l'intérieur
                            panelEleve.Controls.Add(panelLV1);

                            //Option 1 
                            // Création d'un nouveau Panel pour représenter l'option 1 de l'élève
                            Panel panelOption1 = new Panel();
                            // Définition de la taille du Panel
                            panelOption1.Size = new Size(16, 32);
                            // Définition de la position du Panel dans le Panel principal
                            panelOption1.Location = new Point(117, 6);
                            // Définition de la couleur de fond du Panel en utilisant une méthode de l'objet unEleve
                            panelOption1.BackColor = unEleve.option1.couleur;
                            if (panelOption1.BackColor != Color.Transparent)
                                panelOption1.BorderStyle = BorderStyle.FixedSingle;
                            // Définition du nom du Panel
                            panelOption1.Name = "pnlOption1";
                            panelOption1.DoubleClick += (s, ev) => PanelEleve_DoubleClick(panelEleve, e);
                            if (unEleve.dateSortie != default)
                            {
                                panelOption1.MouseHover += (s, ev) => PanelEleveParti_MouseHover(panelEleve, e);
                                panelOption1.MouseLeave += (s, ev) => PanelEleveParti_MouseLeave(panelEleve, e);
                            }
                            else if (!String.IsNullOrEmpty(unEleve.nonInscrit))
                            {
                                panelOption1.MouseHover += (s, ev) => PanelEleveNonInscrit_MouseHover(panelEleve, e);
                                panelOption1.MouseLeave += (s, ev) => PanelEleveNonInscrit_MouseLeave(panelEleve, e);
                            }
                            else
                            {
                                panelOption1.MouseHover += (s, ev) => PanelEleve6eme_MouseHover(panelEleve, e);
                                panelOption1.MouseLeave += (s, ev) => PanelEleve6eme_MouseLeave(panelEleve, e);
                            }
                            // Ajout du Panel au Panel de l'élève pour l'afficher à l'intérieur
                            panelEleve.Controls.Add(panelOption1);

                            // Option 2
                            // Création d'un nouveau Panel pour représenter l'option 2 de l'élève
                            Panel panelOption2 = new Panel();
                            // Définition de la taille du Panel
                            panelOption2.Size = new Size(16, 32);
                            // Définition de la position du Panel dans le Panel principal
                            panelOption2.Location = new Point(138, 6);
                            // Définition de la couleur de fond du Panel en utilisant une méthode de l'objet unEleve
                            panelOption2.BackColor = unEleve.option2.couleur;
                            if (panelOption2.BackColor != Color.Transparent)
                                panelOption2.BorderStyle = BorderStyle.FixedSingle;
                            // Définition du nom du Panel
                            panelOption2.Name = "pnlOption2";
                            panelOption2.DoubleClick += (s, ev) => PanelEleve_DoubleClick(panelEleve, e);
                            if (unEleve.dateSortie != default)
                            {
                                panelOption2.MouseHover += (s, ev) => PanelEleveParti_MouseHover(panelEleve, e);
                                panelOption2.MouseLeave += (s, ev) => PanelEleveParti_MouseLeave(panelEleve, e);
                            }
                            else if (!String.IsNullOrEmpty(unEleve.nonInscrit))
                            {
                                panelOption2.MouseHover += (s, ev) => PanelEleveNonInscrit_MouseHover(panelEleve, e);
                                panelOption2.MouseLeave += (s, ev) => PanelEleveNonInscrit_MouseLeave(panelEleve, e);
                            }
                            else
                            {
                                panelOption2.MouseHover += (s, ev) => PanelEleve6eme_MouseHover(panelEleve, e);
                                panelOption2.MouseLeave += (s, ev) => PanelEleve6eme_MouseLeave(panelEleve, e);
                            }
                            // Ajout du Panel au Panel de l'élève pour l'afficher à l'intérieur
                            panelEleve.Controls.Add(panelOption2);
                            // Déplacer le panelEleve au premier plan (au-dessus des autres contrôles)
                            panelEleve.BringToFront();

                            // Stockage de l'objet unEleve dans la propriété Tag du panelEleve pour le conserver
                            panelEleve.Tag = unEleve;

                            // Ajout du panelEleve au Panel de classe pour l'afficher à l'intérieur
                            colonnePourLesClasses.Controls.Add(panelEleve);
                        }
                        // Ajout de la colonnePourLesClasses au layoutNiveaux pour l'afficher à l'intérieur
                        layoutNiveaux.Controls.Add(colonnePourLesClasses);
                        // Déplacer la colonnePourLesClasses au premier plan (au-dessus des autres contrôles)
                        colonnePourLesClasses.BringToFront();
                    }
                    btnStatsNiv.Visible = true;
                    //btnImprimer.Visible = true;
                }
                else
                {
                    // Afficher une boîte de message avec un avertissement indiquant qu'il faut insérer un fichier pour afficher les informations des niveaux
                    MessageBox.Show("Il faut tout d'abord insérer un fichier pour pouvoir afficher les informations des niveaux !");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        private void btn5ème_Click(object sender, EventArgs e)
        {
            try
            {
                if (Global.elevesValides.Count() != 0)
                {
                    layoutNiveaux.Controls.Clear();
                    layoutNiveaux.Tag = Global.lesNiveaux[1];
                    niveauCharge = 5;
                    List<Classe> classeDe5eme = Global.lesNiveaux[1].getLesClasse().OrderByDescending(classe => classe.nomDeLaClasse).ToList();

                    flowLayoutPanelPrinc = new FlowLayoutPanel();
                    flowLayoutPanelPrinc.Dock = DockStyle.Top;
                    flowLayoutPanelPrinc.AutoSize = true;
                    flowLayoutPanelPrinc.FlowDirection = FlowDirection.TopDown;
                    flowLayoutPanelPrinc.WrapContents = false;

                    layoutNiveaux.Controls.Add(flowLayoutPanelPrinc);
                    Controls.Add(flowLayoutPanelPrinc);
                    flowLayoutPanelPrinc.BringToFront();

                    for (int i = 0; i < classeDe5eme.Count(); i++)
                    {
                        List<Eleve> uneListeEleve = classeDe5eme[i].getLesEleves().OrderBy(eleve => eleve.nomEleve).ToList();

                        List<Eleve> versLaFin = new List<Eleve>();

                        int k = 0;

                        while (k < uneListeEleve.Count)
                        {
                            if (uneListeEleve[k].dateSortie != default)
                            {
                                versLaFin.Add(uneListeEleve[k]);
                                uneListeEleve.RemoveAt(k);
                                k = 0;
                            }
                            else
                            {
                                k++;
                            }
                        }

                        foreach (Eleve el in versLaFin)
                        {
                            uneListeEleve.Add(el);
                        }

                        // Création des colonnes qui contient le prof principal, la classe et les élèves sous forme de panel 
                        // ------------------------------------------------------------------------- //
                        FlowLayoutPanel colonnePourLesClasses = new FlowLayoutPanel();
                        colonnePourLesClasses.Dock = DockStyle.Left;
                        colonnePourLesClasses.AutoSize = true;
                        colonnePourLesClasses.Size = new Size(162, 4);
                        colonnePourLesClasses.FlowDirection = FlowDirection.TopDown;
                        colonnePourLesClasses.WrapContents = false;
                        // ------------------------------------------------------------------------- //

                        // Pour afficher le professeur principal de la classe
                        // ------------------------------------------------------------------------- //
                        // Un nouvel objet Label est créé et assigné à la variable lblProfPrinc. 
                        // Ce Label sera utilisé pour afficher le professeur principal de la classe et permettre de le changer si nécessaire
                        Label lblProfPrinc = new Label();
                        lblProfPrinc.BackColor = Color.WhiteSmoke;
                        lblProfPrinc.Location = new Point(2, 2);
                        lblProfPrinc.Size = new Size(162, 30);
                        lblProfPrinc.TabIndex = 1;
                        lblProfPrinc.Text = classeDe5eme[i].getNomProfPrinc();
                        // ------------------------------------------------------------------------- //

                        // Pour afficher le nom de la classe
                        // ------------------------------------------------------------------------- //
                        Panel panelClasse = new Panel();
                        Label lblNomClasse = new Label();
                        panelClasse.BackColor = Color.FromArgb(235, 194, 154);
                        panelClasse.Controls.Add(lblNomClasse);
                        panelClasse.Location = new Point(172, 182);
                        panelClasse.Margin = new Padding(2, 0, 2, 2);
                        panelClasse.Size = new Size(162, 44);
                        panelClasse.TabIndex = 3;

                        // Le ".Tag" permet de stocker dans le panel un objet pour ne pas le perdre
                        panelClasse.Tag = classeDe5eme[i];

                        // Le ".DoubleClick" permet de mettre en place le double-clique pour chaque panel de classe 
                        // Pour pouvoir l'utiliser, il faut l'écrire à la main.
                        panelClasse.DoubleClick += PanelClasse_DoubleClick;
                        panelClasse.MouseHover += PanelClasse_MouseHover;
                        panelClasse.MouseLeave += PanelClasse_MouseLeave;

                        lblNomClasse.AutoSize = true;
                        lblNomClasse.Dock = DockStyle.Top;
                        lblNomClasse.Location = new Point(0, 0);
                        lblNomClasse.Margin = new Padding(2, 0, 2, 0);
                        lblNomClasse.Name = "lblNomClasse";
                        lblNomClasse.Padding = new Padding(50, 13, 12, 13);
                        lblNomClasse.Size = new Size(90, 39);
                        lblNomClasse.TabIndex = 0;
                        lblNomClasse.Text = classeDe5eme[i].nomDeLaClasse;
                        lblNomClasse.TextAlign = ContentAlignment.MiddleCenter;
                        lblNomClasse.DoubleClick += (s, ev) => PanelClasse_DoubleClick(panelClasse, e);
                        lblNomClasse.MouseHover += (s, ev) => PanelClasse_MouseHover(panelClasse, e);
                        lblNomClasse.MouseLeave += (s, ev) => PanelClasse_MouseLeave(panelClasse, e);
                        // ------------------------------------------------------------------------- //

                        colonnePourLesClasses.Controls.Add(lblProfPrinc);
                        colonnePourLesClasses.Controls.Add(panelClasse);
                        Controls.Add(colonnePourLesClasses);

                        layoutNiveaux.Controls.Add(colonnePourLesClasses);

                        for (int j = 0; j < uneListeEleve.Count(); j++)
                        {
                            Eleve unEleve = uneListeEleve[j];
                            if (j % 10 == 0 && j != 0)
                            {
                                colonnePourLesClasses.Controls.Add(new Label() { Text = " " });
                            }
                            Panel panelEleve = new Panel();
                            panelEleve.Text = "";
                            panelEleve.Size = new Size(162, 46);
                            panelEleve.DoubleClick += PanelEleve_DoubleClick;
                            if (unEleve.dateSortie != default)
                            {
                                panelEleve.BackColor = Color.Red;
                                panelEleve.MouseHover += PanelEleveParti_MouseHover;
                                panelEleve.MouseLeave += PanelEleveParti_MouseLeave;
                            }
                            else
                            {
                                panelEleve.BackColor = Color.FromArgb(188, 255, 159);
                                panelEleve.MouseHover += PanelEleve5eme_MouseHover;
                                panelEleve.MouseLeave += PanelEleve5eme_MouseLeave;
                            }

                            // Nom de famille de l'élève
                            Label lblNomEleve = new Label();
                            lblNomEleve.Text = unEleve.nomEleve;
                            lblNomEleve.Size = new Size(29, 13);
                            lblNomEleve.Location = new Point(4, 1);
                            lblNomEleve.AutoSize = true;
                            lblNomEleve.Margin = new Padding(2, 0, 2, 0);
                            lblNomEleve.Name = "lblNomEleve";
                            lblNomEleve.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                            lblNomEleve.TextAlign = ContentAlignment.MiddleLeft;
                            lblNomEleve.DoubleClick += (s, ev) => PanelEleve_DoubleClick(panelEleve, e);
                            if (unEleve.dateSortie != default)
                            {

                                lblNomEleve.MouseHover += (s, ev) => PanelEleveParti_MouseHover(panelEleve, e);
                                lblNomEleve.MouseLeave += (s, ev) => PanelEleveParti_MouseLeave(panelEleve, e);
                            }
                            else
                            {
                                lblNomEleve.MouseHover += (s, ev) => PanelEleve5eme_MouseHover(panelEleve, e);
                                lblNomEleve.MouseLeave += (s, ev) => PanelEleve5eme_MouseLeave(panelEleve, e);

                            }
                            panelEleve.Controls.Add(lblNomEleve);

                            // Prenom de l'élève
                            Label lblPrenomEleve = new Label();
                            lblPrenomEleve.Text = unEleve.prenomEleve;
                            lblPrenomEleve.Size = new Size(80, 13);
                            lblPrenomEleve.Margin = new Padding(2, 0, 2, 0);
                            lblPrenomEleve.Location = new Point(2, 17);
                            lblPrenomEleve.Name = "lblPrenomEleve";
                            lblPrenomEleve.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                            lblPrenomEleve.TextAlign = ContentAlignment.MiddleLeft;
                            lblPrenomEleve.DoubleClick += (s, ev) => PanelEleve_DoubleClick(panelEleve, e);
                            if (unEleve.dateSortie != default)
                            {
                                lblPrenomEleve.MouseHover += (s, ev) => PanelEleveParti_MouseHover(panelEleve, e);
                                lblPrenomEleve.MouseLeave += (s, ev) => PanelEleveParti_MouseLeave(panelEleve, e);

                            }
                            else
                            {
                                lblPrenomEleve.MouseHover += (s, ev) => PanelEleve5eme_MouseHover(panelEleve, e);
                                lblPrenomEleve.MouseLeave += (s, ev) => PanelEleve5eme_MouseLeave(panelEleve, e);

                            }
                            panelEleve.Controls.Add(lblPrenomEleve);

                            if (unEleve.redouble == "O")
                            {
                                Label lblRedouble = new Label();
                                lblRedouble.Text = "R";
                                lblRedouble.Location = new Point(2, 30);
                                lblRedouble.Size = new Size(80, 13);
                                lblRedouble.Name = "lblRedouble";
                                lblRedouble.Font = new Font("Microsoft Sans Serif", 7F, FontStyle.Bold, GraphicsUnit.Point, 0);
                                lblRedouble.TextAlign = ContentAlignment.MiddleLeft;
                                lblRedouble.DoubleClick += (s, ev) => PanelEleve_DoubleClick(panelEleve, e);
                                if (unEleve.dateSortie != default)
                                {
                                    lblRedouble.MouseHover += (s, ev) => PanelEleveParti_MouseHover(panelEleve, e);
                                    lblRedouble.MouseLeave += (s, ev) => PanelEleveParti_MouseLeave(panelEleve, e);
                                }
                                else
                                {
                                    lblRedouble.MouseHover += (s, ev) => PanelEleve5eme_MouseHover(panelEleve, e);
                                    lblRedouble.MouseLeave += (s, ev) => PanelEleve5eme_MouseLeave(panelEleve, e);
                                }
                                panelEleve.Controls.Add(lblRedouble);
                            }

                            //LV1 
                            Panel panelLV1 = new Panel();
                            panelLV1.Size = new Size(16, 32);
                            panelLV1.Location = new Point(96, 6);
                            panelLV1.BackColor = unEleve.LV1.couleur;
                            if (panelLV1.BackColor != Color.Transparent)
                                panelLV1.BorderStyle = BorderStyle.FixedSingle;
                            panelLV1.Name = "panelLV1";
                            panelLV1.DoubleClick += (s, ev) => PanelEleve_DoubleClick(panelEleve, e);
                            if (unEleve.dateSortie != default)
                            {
                                panelLV1.MouseHover += (s, ev) => PanelEleveParti_MouseHover(panelEleve, e);
                                panelLV1.MouseLeave += (s, ev) => PanelEleveParti_MouseLeave(panelEleve, e);

                            }
                            else
                            {
                                panelLV1.MouseHover += (s, ev) => PanelEleve5eme_MouseHover(panelEleve, e);
                                panelLV1.MouseLeave += (s, ev) => PanelEleve5eme_MouseLeave(panelEleve, e);
                            }
                            panelEleve.Controls.Add(panelLV1);

                            //Option 1 
                            Panel panelOption1 = new Panel();
                            panelOption1.Size = new Size(16, 32);
                            panelOption1.Location = new Point(117, 6);
                            panelOption1.BackColor = unEleve.option1.couleur;
                            if (panelOption1.BackColor != Color.Transparent)
                                panelOption1.BorderStyle = BorderStyle.FixedSingle;
                            panelOption1.Name = "pnlOption1";
                            panelOption1.DoubleClick += (s, ev) => PanelEleve_DoubleClick(panelEleve, e);
                            if (unEleve.dateSortie != default)
                            {
                                panelOption1.MouseHover += (s, ev) => PanelEleveParti_MouseHover(panelEleve, e);
                                panelOption1.MouseLeave += (s, ev) => PanelEleveParti_MouseLeave(panelEleve, e);
                            }
                            else
                            {
                                panelOption1.MouseHover += (s, ev) => PanelEleve5eme_MouseHover(panelEleve, e);
                                panelOption1.MouseLeave += (s, ev) => PanelEleve5eme_MouseLeave(panelEleve, e);
                            }
                            panelEleve.Controls.Add(panelOption1);

                            // Option 2
                            Panel panelOption2 = new Panel();
                            panelOption2.Size = new Size(16, 32);
                            panelOption2.Location = new Point(138, 6);
                            panelOption2.BackColor = unEleve.option2.couleur;
                            if (panelOption2.BackColor != Color.Transparent)
                                panelOption2.BorderStyle = BorderStyle.FixedSingle;
                            panelOption2.Name = "pnlOption2";
                            panelOption2.DoubleClick += (s, ev) => PanelEleve_DoubleClick(panelEleve, e);
                            if (unEleve.dateSortie != default)
                            {
                                panelOption2.MouseHover += (s, ev) => PanelEleveParti_MouseHover(panelEleve, e);
                                panelOption2.MouseLeave += (s, ev) => PanelEleveParti_MouseLeave(panelEleve, e);
                            }
                            else
                            {
                                panelOption2.MouseHover += (s, ev) => PanelEleve5eme_MouseHover(panelEleve, e);
                                panelOption2.MouseLeave += (s, ev) => PanelEleve5eme_MouseLeave(panelEleve, e);
                            }
                            panelEleve.Controls.Add(panelOption2);
                            panelEleve.BringToFront();

                            panelEleve.Tag = unEleve;

                            colonnePourLesClasses.Controls.Add(panelEleve);
                        }
                        layoutNiveaux.Controls.Add(colonnePourLesClasses);
                        colonnePourLesClasses.BringToFront();
                    }
                    btnStatsNiv.Visible = true;
                    //btnImprimer.Visible = true;
                }
                else
                {
                    MessageBox.Show("Il faut tout d'abord insérer un fichier pour pouvoir afficher les informations des niveaux !");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        private void btn4ème_Click(object sender, EventArgs e)
        {
            try
            {
                if (Global.elevesValides.Count() != 0)
                {
                    layoutNiveaux.Controls.Clear();
                    layoutNiveaux.Tag = Global.lesNiveaux[2];
                    niveauCharge = 4;
                    List<Classe> classeDe4eme = Global.lesNiveaux[2].getLesClasse().OrderByDescending(classe => classe.nomDeLaClasse).ToList();

                    flowLayoutPanelPrinc = new FlowLayoutPanel();
                    flowLayoutPanelPrinc.Dock = DockStyle.Top;
                    flowLayoutPanelPrinc.AutoSize = true;
                    flowLayoutPanelPrinc.FlowDirection = FlowDirection.TopDown;
                    flowLayoutPanelPrinc.WrapContents = false;

                    layoutNiveaux.Controls.Add(flowLayoutPanelPrinc);
                    Controls.Add(flowLayoutPanelPrinc);
                    flowLayoutPanelPrinc.BringToFront();

                    for (int i = 0; i < classeDe4eme.Count(); i++)
                    {
                        List<Eleve> uneListeEleve = classeDe4eme[i].getLesEleves().OrderBy(eleve => eleve.nomEleve).ToList();

                        List<Eleve> versLaFin = new List<Eleve>();

                        int k = 0;

                        while (k < uneListeEleve.Count)
                        {
                            if (uneListeEleve[k].dateSortie != default)
                            {
                                versLaFin.Add(uneListeEleve[k]);
                                uneListeEleve.RemoveAt(k);
                                k = 0;
                            }
                            else
                            {
                                k++;
                            }
                        }

                        foreach (Eleve el in versLaFin)
                        {
                            uneListeEleve.Add(el);
                        }

                        // Création des colonnes qui contient le prof principal, la classe et les élèves sous forme de panel 
                        // ------------------------------------------------------------------------- //
                        FlowLayoutPanel colonnePourLesClasses = new FlowLayoutPanel();
                        colonnePourLesClasses.Dock = DockStyle.Left;
                        colonnePourLesClasses.AutoSize = true;
                        colonnePourLesClasses.Size = new Size(162, 4);
                        colonnePourLesClasses.FlowDirection = FlowDirection.TopDown;
                        colonnePourLesClasses.WrapContents = false;
                        // ------------------------------------------------------------------------- //

                        // Pour afficher le professeur principal de la classe
                        // ------------------------------------------------------------------------- //
                        // Un nouvel objet Label est créé et assigné à la variable lblProfPrinc. 
                        // Ce Label sera utilisé pour afficher le professeur principal de la classe et permettre de le changer si nécessaire
                        Label lblProfPrinc = new Label();
                        lblProfPrinc.BackColor = Color.WhiteSmoke;
                        lblProfPrinc.Location = new Point(2, 2);
                        lblProfPrinc.Size = new Size(162, 30);
                        lblProfPrinc.TabIndex = 1;
                        lblProfPrinc.Text = classeDe4eme[i].getNomProfPrinc();
                        // ------------------------------------------------------------------------- //

                        // Pour afficher le nom de la classe
                        // ------------------------------------------------------------------------- //
                        Panel panelClasse = new Panel();
                        Label lblNomClasse = new Label();
                        panelClasse.BackColor = Color.FromArgb(235, 194, 154);
                        panelClasse.Controls.Add(lblNomClasse);
                        panelClasse.Location = new Point(172, 182);
                        panelClasse.Margin = new Padding(2, 0, 2, 2);
                        panelClasse.Size = new Size(162, 44);
                        panelClasse.TabIndex = 3;

                        // Le ".Tag" permet de stocker dans le panel un objet pour ne pas le perdre
                        panelClasse.Tag = classeDe4eme[i];

                        // Le ".DoubleClick" permet de mettre en place le double-clique pour chaque panel de classe 
                        // Pour pouvoir l'utiliser, il faut l'écrire à la main.
                        panelClasse.DoubleClick += PanelClasse_DoubleClick;
                        panelClasse.MouseHover += PanelClasse_MouseHover;
                        panelClasse.MouseLeave += PanelClasse_MouseLeave;

                        lblNomClasse.AutoSize = true;
                        lblNomClasse.Dock = DockStyle.Top;
                        lblNomClasse.Location = new Point(0, 0);
                        lblNomClasse.Margin = new Padding(2, 0, 2, 0);
                        lblNomClasse.Name = "lblNomClasse";
                        lblNomClasse.Padding = new Padding(50, 13, 12, 13);
                        lblNomClasse.Size = new Size(90, 39);
                        lblNomClasse.TabIndex = 0;
                        lblNomClasse.Text = classeDe4eme[i].nomDeLaClasse;
                        lblNomClasse.TextAlign = ContentAlignment.MiddleCenter;
                        lblNomClasse.DoubleClick += (s, ev) => PanelClasse_DoubleClick(panelClasse, e);
                        lblNomClasse.MouseHover += (s, ev) => PanelClasse_MouseHover(panelClasse, e);
                        lblNomClasse.MouseLeave += (s, ev) => PanelClasse_MouseLeave(panelClasse, e);
                        // ------------------------------------------------------------------------- //

                        colonnePourLesClasses.Controls.Add(lblProfPrinc);
                        colonnePourLesClasses.Controls.Add(panelClasse);
                        Controls.Add(colonnePourLesClasses);

                        layoutNiveaux.Controls.Add(colonnePourLesClasses);

                        for (int j = 0; j < uneListeEleve.Count(); j++)
                        {
                            Eleve unEleve = uneListeEleve[j];
                            if (j % 10 == 0 && j != 0)
                            {
                                colonnePourLesClasses.Controls.Add(new Label() { Text = " " });
                            }
                            Panel panelEleve = new Panel();
                            panelEleve.Text = "";
                            panelEleve.Size = new Size(162, 46);
                            panelEleve.DoubleClick += PanelEleve_DoubleClick;
                            if (unEleve.dateSortie != default)
                            {
                                panelEleve.BackColor = Color.Red;
                                panelEleve.MouseHover += PanelEleveParti_MouseHover;
                                panelEleve.MouseLeave += PanelEleveParti_MouseLeave;
                            }
                            else
                            {
                                panelEleve.BackColor = Color.FromArgb(188, 255, 159);
                                panelEleve.MouseHover += PanelEleve4eme_MouseHover;
                                panelEleve.MouseLeave += PanelEleve4eme_MouseLeave;
                            }

                            // Nom de famille de l'élève
                            Label lblNomEleve = new Label();
                            lblNomEleve.Text = unEleve.nomEleve;
                            lblNomEleve.Size = new Size(29, 13);
                            lblNomEleve.Location = new Point(4, 1);
                            lblNomEleve.AutoSize = true;
                            lblNomEleve.Margin = new Padding(2, 0, 2, 0);
                            lblNomEleve.Name = "lblNomEleve";
                            lblNomEleve.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                            lblNomEleve.TextAlign = ContentAlignment.MiddleLeft;
                            lblNomEleve.DoubleClick += (s, ev) => PanelEleve_DoubleClick(panelEleve, e);
                            if (unEleve.dateSortie != default)
                            {
                                lblNomEleve.MouseHover += (s, ev) => PanelEleveParti_MouseHover(panelEleve, e);
                                lblNomEleve.MouseLeave += (s, ev) => PanelEleveParti_MouseLeave(panelEleve, e);
                            }
                            else
                            {
                                lblNomEleve.MouseHover += (s, ev) => PanelEleve4eme_MouseHover(panelEleve, e);
                                lblNomEleve.MouseLeave += (s, ev) => PanelEleve4eme_MouseLeave(panelEleve, e);
                            }
                            panelEleve.Controls.Add(lblNomEleve);

                            // Prenom de l'élève
                            Label lblPrenomEleve = new Label();
                            lblPrenomEleve.Text = unEleve.prenomEleve;
                            lblPrenomEleve.Size = new Size(80, 13);
                            lblPrenomEleve.Margin = new Padding(2, 0, 2, 0);
                            lblPrenomEleve.Location = new Point(2, 17);
                            lblPrenomEleve.Name = "lblPrenomEleve";
                            lblPrenomEleve.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                            lblPrenomEleve.TextAlign = ContentAlignment.MiddleLeft;
                            lblPrenomEleve.DoubleClick += (s, ev) => PanelEleve_DoubleClick(panelEleve, e);
                            if (unEleve.dateSortie != default)
                            {
                                lblPrenomEleve.MouseHover += (s, ev) => PanelEleveParti_MouseHover(panelEleve, e);
                                lblPrenomEleve.MouseLeave += (s, ev) => PanelEleveParti_MouseLeave(panelEleve, e);
                            }
                            else
                            {
                                lblPrenomEleve.MouseHover += (s, ev) => PanelEleve4eme_MouseHover(panelEleve, e);
                                lblPrenomEleve.MouseLeave += (s, ev) => PanelEleve4eme_MouseLeave(panelEleve, e);
                            }
                            panelEleve.Controls.Add(lblPrenomEleve);

                            if (unEleve.redouble == "O")
                            {
                                Label lblRedouble = new Label();
                                lblRedouble.Text = "R";
                                lblRedouble.Location = new Point(2, 30);
                                lblRedouble.Size = new Size(80, 13);
                                lblRedouble.Name = "lblRedouble";
                                lblRedouble.Font = new Font("Microsoft Sans Serif", 7F, FontStyle.Bold, GraphicsUnit.Point, 0);
                                lblRedouble.TextAlign = ContentAlignment.MiddleLeft;
                                lblRedouble.DoubleClick += (s, ev) => PanelEleve_DoubleClick(panelEleve, e);
                                if (unEleve.dateSortie != default)
                                {
                                    lblRedouble.MouseHover += (s, ev) => PanelEleveParti_MouseHover(panelEleve, e);
                                    lblRedouble.MouseLeave += (s, ev) => PanelEleveParti_MouseLeave(panelEleve, e);
                                }
                                else
                                {
                                    lblRedouble.MouseHover += (s, ev) => PanelEleve4eme_MouseHover(panelEleve, e);
                                    lblRedouble.MouseLeave += (s, ev) => PanelEleve4eme_MouseLeave(panelEleve, e);
                                }
                                panelEleve.Controls.Add(lblRedouble);
                            }

                            //LV1 
                            Panel panelLV1 = new Panel();
                            panelLV1.Size = new Size(16, 32);
                            panelLV1.Location = new Point(96, 6);
                            panelLV1.BackColor = unEleve.LV1.couleur;
                            if (panelLV1.BackColor != Color.Transparent)
                                panelLV1.BorderStyle = BorderStyle.FixedSingle;
                            panelLV1.Name = "panelLV1";
                            panelLV1.DoubleClick += (s, ev) => PanelEleve_DoubleClick(panelEleve, e);
                            if (unEleve.dateSortie != default)
                            {
                                panelLV1.MouseHover += (s, ev) => PanelEleveParti_MouseHover(panelEleve, e);
                                panelLV1.MouseLeave += (s, ev) => PanelEleveParti_MouseLeave(panelEleve, e);
                            }
                            else
                            {
                                panelLV1.MouseHover += (s, ev) => PanelEleve4eme_MouseHover(panelEleve, e);
                                panelLV1.MouseLeave += (s, ev) => PanelEleve4eme_MouseLeave(panelEleve, e);
                            }
                            panelEleve.Controls.Add(panelLV1);

                            //Option 1 
                            Panel panelOption1 = new Panel();
                            panelOption1.Size = new Size(16, 32);
                            panelOption1.Location = new Point(117, 6);
                            panelOption1.BackColor = unEleve.option1.couleur;
                            if (panelOption1.BackColor != Color.Transparent)
                                panelOption1.BorderStyle = BorderStyle.FixedSingle;
                            panelOption1.Name = "pnlOption1";
                            panelOption1.DoubleClick += (s, ev) => PanelEleve_DoubleClick(panelEleve, e);
                            if (unEleve.dateSortie != default)
                            {
                                panelOption1.MouseHover += (s, ev) => PanelEleveParti_MouseHover(panelEleve, e);
                                panelOption1.MouseLeave += (s, ev) => PanelEleveParti_MouseLeave(panelEleve, e);
                            }
                            else
                            {
                                panelOption1.MouseHover += (s, ev) => PanelEleve4eme_MouseHover(panelEleve, e);
                                panelOption1.MouseLeave += (s, ev) => PanelEleve4eme_MouseLeave(panelEleve, e);
                            }
                            panelEleve.Controls.Add(panelOption1);

                            // Option 2
                            Panel panelOption2 = new Panel();
                            panelOption2.Size = new Size(16, 32);
                            panelOption2.Location = new Point(138, 6);
                            panelOption2.BackColor = unEleve.option2.couleur;
                            if (panelOption2.BackColor != Color.Transparent)
                                panelOption2.BorderStyle = BorderStyle.FixedSingle;
                            panelOption2.Name = "pnlOption2";
                            panelOption2.DoubleClick += (s, ev) => PanelEleve_DoubleClick(panelEleve, e);
                            if (unEleve.dateSortie != default)
                            {
                                panelOption2.MouseHover += (s, ev) => PanelEleveParti_MouseHover(panelEleve, e);
                                panelOption2.MouseLeave += (s, ev) => PanelEleveParti_MouseLeave(panelEleve, e);
                            }
                            else
                            {
                                panelOption2.MouseHover += (s, ev) => PanelEleve4eme_MouseHover(panelEleve, e);
                                panelOption2.MouseLeave += (s, ev) => PanelEleve4eme_MouseLeave(panelEleve, e);
                            }
                            panelEleve.Controls.Add(panelOption2);
                            panelEleve.BringToFront();

                            panelEleve.Tag = unEleve;

                            colonnePourLesClasses.Controls.Add(panelEleve);
                        }
                        layoutNiveaux.Controls.Add(colonnePourLesClasses);
                        colonnePourLesClasses.BringToFront();
                    }
                    btnStatsNiv.Visible = true;
                    //btnImprimer.Visible = true;
                }
                else
                {
                    MessageBox.Show("Il faut tout d'abord insérer un fichier pour pouvoir afficher les informations des niveaux !");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        private void btn3ème_Click(object sender, EventArgs e)
        {
            try
            {
                if (Global.elevesValides.Count() != 0)
                {
                    layoutNiveaux.Controls.Clear();
                    layoutNiveaux.Tag = Global.lesNiveaux[3];
                    niveauCharge = 3;
                    List<Classe> classeDe3eme = Global.lesNiveaux[3].getLesClasse().OrderByDescending(classe => classe.nomDeLaClasse).ToList();

                    flowLayoutPanelPrinc = new FlowLayoutPanel();
                    flowLayoutPanelPrinc.Dock = DockStyle.Top;
                    flowLayoutPanelPrinc.AutoSize = true;
                    flowLayoutPanelPrinc.FlowDirection = FlowDirection.TopDown;
                    flowLayoutPanelPrinc.WrapContents = false;

                    layoutNiveaux.Controls.Add(flowLayoutPanelPrinc);
                    Controls.Add(flowLayoutPanelPrinc);
                    flowLayoutPanelPrinc.BringToFront();

                    for (int i = 0; i < classeDe3eme.Count(); i++)
                    {
                        List<Eleve> uneListeEleve = classeDe3eme[i].getLesEleves().OrderBy(eleve => eleve.nomEleve).ToList();

                        List<Eleve> versLaFin = new List<Eleve>();

                        int k = 0;

                        while (k < uneListeEleve.Count)
                        {
                            if (uneListeEleve[k].dateSortie != default)
                            {
                                versLaFin.Add(uneListeEleve[k]);
                                uneListeEleve.RemoveAt(k);
                                k = 0;
                            }
                            else
                            {
                                k++;
                            }
                        }

                        foreach (Eleve el in versLaFin)
                        {
                            uneListeEleve.Add(el);
                        }

                        // Création des colonnes qui contient le prof principal, la classe et les élèves sous forme de panel 
                        // ------------------------------------------------------------------------- //
                        FlowLayoutPanel colonnePourLesClasses = new FlowLayoutPanel();
                        colonnePourLesClasses.Dock = DockStyle.Left;
                        colonnePourLesClasses.AutoSize = true;
                        colonnePourLesClasses.Size = new Size(162, 4);
                        colonnePourLesClasses.FlowDirection = FlowDirection.TopDown;
                        colonnePourLesClasses.WrapContents = false;
                        // ------------------------------------------------------------------------- //

                        // Pour afficher le professeur principal de la classe
                        // ------------------------------------------------------------------------- //
                        // Un nouvel objet Label est créé et assigné à la variable lblProfPrinc. 
                        // Ce Label sera utilisé pour afficher le professeur principal de la classe et permettre de le changer si nécessaire
                        Label lblProfPrinc = new Label();
                        lblProfPrinc.BackColor = Color.WhiteSmoke;
                        lblProfPrinc.Location = new Point(2, 2);
                        lblProfPrinc.Size = new Size(162, 30);
                        lblProfPrinc.TabIndex = 1;
                        lblProfPrinc.Text = classeDe3eme[i].getNomProfPrinc();
                        // ------------------------------------------------------------------------- //

                        // Pour afficher le nom de la classe
                        // ------------------------------------------------------------------------- //
                        Panel panelClasse = new Panel();
                        Label lblNomClasse = new Label();
                        panelClasse.BackColor = Color.FromArgb(235, 194, 154);
                        panelClasse.Controls.Add(lblNomClasse);
                        panelClasse.Location = new Point(172, 182);
                        panelClasse.Margin = new Padding(2, 0, 2, 2);
                        panelClasse.Size = new Size(162, 44);
                        panelClasse.TabIndex = 3;

                        // Le ".Tag" permet de stocker dans le panel un objet pour ne pas le perdre
                        panelClasse.Tag = classeDe3eme[i];

                        // Le ".DoubleClick" permet de mettre en place le double-clique pour chaque panel de classe 
                        // Pour pouvoir l'utiliser, il faut l'écrire à la main.
                        panelClasse.DoubleClick += PanelClasse_DoubleClick;
                        panelClasse.MouseHover += PanelClasse_MouseHover;
                        panelClasse.MouseLeave += PanelClasse_MouseLeave;

                        lblNomClasse.AutoSize = true;
                        lblNomClasse.Dock = DockStyle.Top;
                        lblNomClasse.Location = new Point(0, 0);
                        lblNomClasse.Margin = new Padding(2, 0, 2, 0);
                        lblNomClasse.Name = "lblNomClasse";
                        lblNomClasse.Padding = new Padding(50, 13, 12, 13);
                        lblNomClasse.Size = new Size(90, 39);
                        lblNomClasse.TabIndex = 0;
                        lblNomClasse.Text = classeDe3eme[i].nomDeLaClasse;
                        lblNomClasse.TextAlign = ContentAlignment.MiddleCenter;
                        lblNomClasse.DoubleClick += (s, ev) => PanelClasse_DoubleClick(panelClasse, e);
                        lblNomClasse.MouseHover += (s, ev) => PanelClasse_MouseHover(panelClasse, e);
                        lblNomClasse.MouseLeave += (s, ev) => PanelClasse_MouseLeave(panelClasse, e);
                        // ------------------------------------------------------------------------- //

                        colonnePourLesClasses.Controls.Add(lblProfPrinc);
                        colonnePourLesClasses.Controls.Add(panelClasse);
                        Controls.Add(colonnePourLesClasses);

                        layoutNiveaux.Controls.Add(colonnePourLesClasses);

                        for (int j = 0; j < uneListeEleve.Count(); j++)
                        {
                            Eleve unEleve = uneListeEleve[j];
                            if (j % 10 == 0 && j != 0)
                            {
                                colonnePourLesClasses.Controls.Add(new Label() { Text = " " });
                            }
                            Panel panelEleve = new Panel();
                            panelEleve.Text = "";
                            panelEleve.Size = new Size(162, 46);
                            panelEleve.DoubleClick += PanelEleve_DoubleClick;
                            if (unEleve.dateSortie != default)
                            {
                                panelEleve.BackColor = Color.Red;
                                panelEleve.MouseHover += PanelEleveParti_MouseHover;
                                panelEleve.MouseLeave += PanelEleveParti_MouseLeave;
                            }
                            else
                            {
                                panelEleve.BackColor = Color.FromArgb(136, 210, 247);
                                panelEleve.MouseHover += PanelEleve3eme_MouseHover;
                                panelEleve.MouseLeave += PanelEleve3eme_MouseLeave;
                            }

                            // Nom de famille de l'élève
                            Label lblNomEleve = new Label();
                            lblNomEleve.Text = unEleve.nomEleve;
                            lblNomEleve.Size = new Size(29, 13);
                            lblNomEleve.Location = new Point(4, 1);
                            lblNomEleve.AutoSize = true;
                            lblNomEleve.Margin = new Padding(2, 0, 2, 0);
                            lblNomEleve.Name = "lblNomEleve";
                            lblNomEleve.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                            lblNomEleve.TextAlign = ContentAlignment.MiddleLeft;
                            lblNomEleve.DoubleClick += (s, ev) => PanelEleve_DoubleClick(panelEleve, e);
                            if (unEleve.dateSortie != default)
                            {
                                lblNomEleve.MouseHover += (s, ev) => PanelEleveParti_MouseHover(panelEleve, e);
                                lblNomEleve.MouseLeave += (s, ev) => PanelEleveParti_MouseLeave(panelEleve, e);
                            }
                            else
                            {
                                lblNomEleve.MouseHover += (s, ev) => PanelEleve3eme_MouseHover(panelEleve, e);
                                lblNomEleve.MouseLeave += (s, ev) => PanelEleve3eme_MouseLeave(panelEleve, e);
                            }
                            panelEleve.Controls.Add(lblNomEleve);

                            // Prenom de l'élève
                            Label lblPrenomEleve = new Label();
                            lblPrenomEleve.Text = unEleve.prenomEleve;
                            lblPrenomEleve.Size = new Size(80, 13);
                            lblPrenomEleve.Margin = new Padding(2, 0, 2, 0);
                            lblPrenomEleve.Location = new Point(2, 17);
                            lblPrenomEleve.Name = "lblPrenomEleve";
                            lblPrenomEleve.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                            lblPrenomEleve.TextAlign = ContentAlignment.MiddleLeft;
                            lblPrenomEleve.DoubleClick += (s, ev) => PanelEleve_DoubleClick(panelEleve, e);
                            if (unEleve.dateSortie != default)
                            {
                                lblPrenomEleve.MouseHover += (s, ev) => PanelEleveParti_MouseHover(panelEleve, e);
                                lblPrenomEleve.MouseLeave += (s, ev) => PanelEleveParti_MouseLeave(panelEleve, e);
                            }
                            else
                            {
                                lblPrenomEleve.MouseHover += (s, ev) => PanelEleve3eme_MouseHover(panelEleve, e);
                                lblPrenomEleve.MouseLeave += (s, ev) => PanelEleve3eme_MouseLeave(panelEleve, e);
                            }
                            panelEleve.Controls.Add(lblPrenomEleve);

                            if (unEleve.redouble == "O")
                            {
                                Label lblRedouble = new Label();
                                lblRedouble.Text = "R";
                                lblRedouble.Location = new Point(2, 30);
                                lblRedouble.Size = new Size(80, 13);
                                lblRedouble.Name = "lblRedouble";
                                lblRedouble.Font = new Font("Microsoft Sans Serif", 7F, FontStyle.Bold, GraphicsUnit.Point, 0);
                                lblRedouble.TextAlign = ContentAlignment.MiddleLeft;
                                lblRedouble.DoubleClick += (s, ev) => PanelEleve_DoubleClick(panelEleve, e);
                                if (unEleve.dateSortie != default)
                                {
                                    lblRedouble.MouseHover += (s, ev) => PanelEleveParti_MouseHover(panelEleve, e);
                                    lblRedouble.MouseLeave += (s, ev) => PanelEleveParti_MouseLeave(panelEleve, e);
                                }
                                else
                                {
                                    lblRedouble.MouseHover += (s, ev) => PanelEleve3eme_MouseHover(panelEleve, e);
                                    lblRedouble.MouseLeave += (s, ev) => PanelEleve3eme_MouseLeave(panelEleve, e);
                                }
                                panelEleve.Controls.Add(lblRedouble);
                            }

                            //LV1 
                            Panel panelLV1 = new Panel();
                            panelLV1.Size = new Size(16, 32);
                            panelLV1.Location = new Point(96, 6);
                            panelLV1.BackColor = unEleve.LV1.couleur;
                            if (panelLV1.BackColor != Color.Transparent)
                                panelLV1.BorderStyle = BorderStyle.FixedSingle;
                            panelLV1.Name = "panelLV1";
                            panelLV1.DoubleClick += (s, ev) => PanelEleve_DoubleClick(panelEleve, e);
                            if (unEleve.dateSortie != default)
                            {
                                panelLV1.MouseHover += (s, ev) => PanelEleveParti_MouseHover(panelEleve, e);
                                panelLV1.MouseLeave += (s, ev) => PanelEleveParti_MouseLeave(panelEleve, e);
                            }
                            else
                            {
                                panelLV1.MouseHover += (s, ev) => PanelEleve3eme_MouseHover(panelEleve, e);
                                panelLV1.MouseLeave += (s, ev) => PanelEleve3eme_MouseLeave(panelEleve, e);
                            }
                            panelEleve.Controls.Add(panelLV1);

                            //Option 1 
                            Panel panelOption1 = new Panel();
                            panelOption1.Size = new Size(16, 32);
                            panelOption1.Location = new Point(117, 6);
                            panelOption1.BackColor = unEleve.option1.couleur;
                            if (panelOption1.BackColor != Color.Transparent)
                                panelOption1.BorderStyle = BorderStyle.FixedSingle;
                            panelOption1.Name = "pnlOption1";
                            panelOption1.DoubleClick += (s, ev) => PanelEleve_DoubleClick(panelEleve, e);
                            if (unEleve.dateSortie != default)
                            {
                                panelOption1.MouseHover += (s, ev) => PanelEleveParti_MouseHover(panelEleve, e);
                                panelOption1.MouseLeave += (s, ev) => PanelEleveParti_MouseLeave(panelEleve, e);
                            }
                            else
                            {
                                panelOption1.MouseHover += (s, ev) => PanelEleve3eme_MouseHover(panelEleve, e);
                                panelOption1.MouseLeave += (s, ev) => PanelEleve3eme_MouseLeave(panelEleve, e);
                            }
                            panelEleve.Controls.Add(panelOption1);

                            // Option 2
                            Panel panelOption2 = new Panel();
                            panelOption2.Size = new Size(16, 32);
                            panelOption2.Location = new Point(138, 6);
                            panelOption2.BackColor = unEleve.option2.couleur;
                            if (panelOption2.BackColor != Color.Transparent)
                                panelOption2.BorderStyle = BorderStyle.FixedSingle;
                            panelOption2.Name = "pnlOption2";
                            panelOption2.DoubleClick += (s, ev) => PanelEleve_DoubleClick(panelEleve, e);
                            if (unEleve.dateSortie != default)
                            {
                                panelOption2.MouseHover += (s, ev) => PanelEleveParti_MouseHover(panelEleve, e);
                                panelOption2.MouseLeave += (s, ev) => PanelEleveParti_MouseLeave(panelEleve, e);
                            }
                            else
                            {
                                panelOption2.MouseHover += (s, ev) => PanelEleve3eme_MouseHover(panelEleve, e);
                                panelOption2.MouseLeave += (s, ev) => PanelEleve3eme_MouseLeave(panelEleve, e);
                            }
                            panelEleve.Controls.Add(panelOption2);
                            panelEleve.BringToFront();

                            panelEleve.Tag = unEleve;

                            colonnePourLesClasses.Controls.Add(panelEleve);
                        }
                        layoutNiveaux.Controls.Add(colonnePourLesClasses);
                        colonnePourLesClasses.BringToFront();
                    }
                    btnStatsNiv.Visible = true;
                    //btnImprimer.Visible = true;
                }
                else
                {
                    MessageBox.Show("Il faut tout d'abord insérer un fichier pour pouvoir afficher les informations des niveaux !");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnDeplaClasse_Click(object sender, EventArgs e)
        {
            ChangementClasseEleve unChangementClasse = new ChangementClasseEleve();
            unChangementClasse.Show();
            unChangementClasse.TopMost = true;
        }
        private void btnRenomClasse_Click(object sender, EventArgs e)
        {
            RenommerClasse frmRenommerClasse = new RenommerClasse();
            frmRenommerClasse.Show();
        }
        private void btnAjoutFicheEleve_Click(object sender, EventArgs e)
        {
            AjoutEleve unAjoutEleve = new AjoutEleve(); //initialise une instance du form "AjoutEleve"
            unAjoutEleve.Show(); //affiche l'instance
            unAjoutEleve.TopMost = true; //affiche au dessus des autres pages
        }
        private void btnSuppEleve_Click(object sender, EventArgs e)
        {
            SuppEleve uneSuppEleve = new SuppEleve(); //initialise une instance du form
            uneSuppEleve.Show(); //affiche l'instance
            uneSuppEleve.TopMost = true; //affiche au dessus des autres pages
        }

        public void repartitionEleves() //procédure de répartition des élèves par classes
        {
            if (Global.nbEleves < 50) //fait en sorte de ne pas poursuivre s'il n'y a pas assez d'élèves ou si aucune base n'a été importée
            {
                MessageBox.Show("ERREUR : Nombre d'élèves insuffisant");
            }
            else
            {
                Global.nbElevesReal = 0;
                for (int i = 0; i < Global.nbEleves; i++) //parcours tous les élèves de la base de données (même ceux qui n'auront pas de classe)
                {
                    if (Global.listeClasseEleve[i] != "Vide" && Global.listeMefEleve[i] != "Vide") //si l'élève a bien une classe et un code MEF, il est alors "validé" et ajouté a une liste
                    {
                        bool eleveExisteDeja = false;

                        foreach (Niveau niv in Global.lesNiveaux)
                        {
                            foreach (Classe cls in niv.getLesClasse())
                            {
                                foreach (Eleve elv in cls.getLesEleves())
                                {
                                    if (Global.listeIneEleve[i] == elv.ine)
                                    {
                                        elv.mefEleve = Global.listeMefEleve[i];
                                        elv.redouble = Global.listeRedouble[i];
                                        if (elv.anciennesClasses == null)
                                            elv.anciennesClasses = new List<string>();
                                        elv.anciennesClasses.Add(elv.classeEleve);
                                        if (elv.anciensNiveaux == null)
                                            elv.anciensNiveaux = new List<char>();
                                        elv.classeEleve = Global.listeClasseEleve[i];
                                        elv.LV1Eleve = Global.listeLV1Eleve[i];
                                        elv.option1Eleve = Global.listeOption1Eleve[i];
                                        elv.option2Eleve = Global.listeOption2Eleve[i];
                                        elv.LV1 = Global.listeLV1EleveOption[i];
                                        elv.option1 = Global.listeOption1EleveOption[i];
                                        elv.option2 = Global.listeOption2EleveOption[i];
                                        elv.dateSortie = Global.listeDateSortieEleve[i];

                                        Global.elevesValides.Add(elv);

                                        eleveExisteDeja = true;
                                        break;
                                    }
                                }

                                if (eleveExisteDeja)
                                    break;
                            }

                            if (eleveExisteDeja)
                                break;
                        }

                        if(!eleveExisteDeja)
                        {
                            Eleve unEleve = new Eleve(
                            Global.listeNumEleve[i], Global.listeNomEleve[i], Global.listePrenomEleve[i],
                            Global.listeNaissanceEleve[i], Global.listeSexeEleve[i], Global.listeMefEleve[i], Global.listeRedouble[i],
                            Global.listeClasseEleve[i], Global.listeLV1Eleve[i], Global.listeOption1Eleve[i], Global.listeOption2Eleve[i],
                            Global.listeLV1EleveOption[i], Global.listeOption1EleveOption[i], Global.listeOption2EleveOption[i], Global.listeDateEntreeEleve[i]);
                            unEleve.setDateSortie(Global.listeDateSortieEleve[i]);
                            unEleve.ine = Global.listeIneEleve[i];
                            unEleve.rdbNiveau = new RadioButton();
                            unEleve.rdbNiveau.Name = "rdbNR";
                            unEleve.anciennesClasses = new List<string>();
                            unEleve.anciensNiveaux = new List<char>();
                            Global.elevesValides.Add(unEleve);
                            
                        }

                        Global.nbElevesReal++;

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
                        else
                        {
                            testListeOption = Global.listeOption1Eleve[i];

                            if (!Global.lesOptions.Any(s => s.Contains(testListeOption.Substring(0, 3))))
                            {
                                Global.lesOptions.Add(testListeOption);
                                Global.options.Add(new Options(testListeOption));
                            }
                        }
                    }
                    else
                    {
                        bool eleveExistait = false;

                        foreach (Niveau niv in Global.lesNiveaux)
                        {
                            foreach (Classe cls in niv.getLesClasse())
                            {
                                foreach (Eleve elv in cls.getLesEleves())
                                {
                                    if (Global.listeIneEleve[i] == elv.ine)
                                    {
                                        if (elv.anciennesClasses == null)
                                            elv.anciennesClasses = new List<string>();
                                        elv.anciennesClasses.Add(elv.classeEleve);
                                        elv.classeEleve = "parti";
                                        elv.dateSortie = Global.listeDateSortieEleve[i];


                                        eleveExistait = true;
                                        break;
                                    }
                                }

                                if (eleveExistait)
                                    break;
                            }

                            if (eleveExistait)
                                break;
                        }
                    }
                }

                Global.lesNiveaux.Clear(); // on vide les niveaux pour mettre les nouvelles classes

                /*
                            Global.listeNaissanceEleve.Count(), Global.listeSexeEleve.Count(), Global.listeMefEleve.Count(),
                            Global.listeClasseEleve.Count(), Global.listeOption1Eleve.Count(), Global.listeOption2Eleve.Count());*/

                //REPARTITIONS DES ELEVES PAR NIVEAU ET CLASSE

                Niveau niveau6eme = new Niveau("la6eme");       //Création d'un objet Niveau contenant le nom du niveau concerné
                foreach (string nom in Global.nomsClasses6e)     //On parcourt les noms des classes correspondant au niveau
                {
                    Classe uneClasse = new Classe(nom);                     //Création d'un objet Classe qui contient le nom de celle-ci
                    niveau6eme.setLesClasses(uneClasse);                    //Ajout de l'objet Classe à la liste des classes de l'objet Niveau
                    for (int i = 0; i < Global.nbElevesReal; i++)           //On parcourt maintenant tous les élèves étant bien scolarisés dans le collège
                        if (Global.elevesValides[i].classeEleve == uneClasse.nomDeLaClasse)
                        {
                            Eleve unEleve = Global.elevesValides[i];        //Si l'élève est dans la classe consultée par le foreach il est donc ajouté en tant qu'objet Eleve
                            uneClasse.setLesEleves(unEleve);                //Et enfin ajouté à la liste des élèves de l'objet Classe
                        }
                }
                // Le commentaire est pareil pour le reste des niveaux
                Niveau niveau5eme = new Niveau("la5eme");       //On répète la même opération pour chaque niveau
                foreach (string nom in Global.nomsClasses5e)
                {
                    Classe uneClasse = new Classe(nom);
                    niveau5eme.setLesClasses(uneClasse);
                    for (int i = 0; i < Global.nbElevesReal; i++)
                        if (Global.elevesValides[i].classeEleve == uneClasse.nomDeLaClasse)
                        {
                            Eleve unEleve = Global.elevesValides[i];
                            uneClasse.setLesEleves(unEleve);
                        }
                }
                Niveau niveau4eme = new Niveau("la4eme");
                foreach (string nom in Global.nomsClasses4e)
                {
                    Classe uneClasse = new Classe(nom);
                    niveau4eme.setLesClasses(uneClasse);
                    for (int i = 0; i < Global.nbElevesReal; i++)
                        if (Global.elevesValides[i].classeEleve == uneClasse.nomDeLaClasse)
                        {
                            Eleve unEleve = Global.elevesValides[i];
                            uneClasse.setLesEleves(unEleve);
                        }
                }
                Niveau niveau3eme = new Niveau("la3eme");
                foreach (string nom in Global.nomsClasses3e)
                {
                    Classe uneClasse = new Classe(nom);
                    niveau3eme.setLesClasses(uneClasse);
                    for (int i = 0; i < Global.nbElevesReal; i++)
                        if (Global.elevesValides[i].classeEleve == uneClasse.nomDeLaClasse)
                        {
                            Eleve unEleve = Global.elevesValides[i];
                            uneClasse.setLesEleves(unEleve);
                        }
                }

                Global.lesNiveaux.Add(niveau6eme);
                Global.lesNiveaux.Add(niveau5eme);
                Global.lesNiveaux.Add(niveau4eme);
                Global.lesNiveaux.Add(niveau3eme);
            }

            // Réinitialise les chemins de fichiers
            Global.pathXLS = "";
            Global.pathXLSX = "";
            Global.pathXML = "";

        }

        public void ChangerLblTotalNbEleves()
        {
            if (Global.nbElevesReal > 0)
            {
                lblNbEleves.Text = Global.nbElevesReal.ToString();
            }
            else
            {
                lblNbEleves.Text = Global.nbEleves.ToString();
            }
        }

        private void layoutClasses6e_Paint(object sender, PaintEventArgs e)
        {

        }

        private void InterfacePrinc_Load(object sender, EventArgs e)
        {
            if (File.Exists("informationsElevesModifie.xml"))
            {
                MessageBox.Show("Ouverture des dernières données enregistrées");
                ChargerDernierEnregistre("informationsElevesModifie.xml");
            }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            // Récupère le bouton sur lequel le clic a été effectué et le convertit en objet Button
            Button btnEnregistrer = sender as Button;
            // Récupère l'objet de type "Tuple<Eleve, GroupBox>" associé au bouton à l'aide de sa propriété "Tag"
            Tuple<Eleve, GroupBox> tuple = btnEnregistrer.Tag as Tuple<Eleve, GroupBox>;
            // Récupère l'objet de type "Eleve" à partir du premier élément du tuple
            Eleve unEleve = tuple.Item1;
            // Récupère l'objet de type "GroupBox" à partir du deuxième élément du tuple
            GroupBox gpbNiveau = tuple.Item2;

            // Parcourt les contrôles contenus dans le group box "gpbNiveau"
            foreach (Control xControl in gpbNiveau.Controls)
            {
                // Vérifie si chaque contrôle est de type RadioButton
                if (xControl is RadioButton)
                {
                    // Convertit le contrôle en objet RadioButton
                    RadioButton radioButton = xControl as RadioButton;
                    // Vérifie si le bouton radio est sélectionné
                    if (radioButton.Checked)
                    {
                        // Si un bouton radio est sélectionné, met à jour la propriété "rdbNiveau" de l'objet "unEleve" avec ce bouton radio et arrête la boucle
                        unEleve.rdbNiveau = radioButton;
                        break;
                    }
                }
            }
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            // Récupère le bouton sur lequel le clic a été effectué et le convertit en objet Button
            Button btnEnregistrer = sender as Button;
            // Récupère l'objet de type "Tuple<Eleve, GroupBox>" associé au bouton à l'aide de sa propriété "Tag"
            Tuple<Eleve, GroupBox, System.Windows.Forms.CheckBox, GroupBox> tuple = btnEnregistrer.Tag as Tuple<Eleve, GroupBox, System.Windows.Forms.CheckBox, GroupBox>;
            // Récupère l'objet de type "Eleve" à partir du premier élément du tuple
            Eleve unEleve = tuple.Item1;
            // Récupère l'objet de type "GroupBox" à partir du deuxième élément du tuple
            GroupBox gpbNiveau = tuple.Item2;
            System.Windows.Forms.CheckBox eleveInscrit = tuple.Item3;
            GroupBox gpbSexe = tuple.Item4;

            // Parcourt les contrôles contenus dans le group box "gpbNiveau"
            foreach (Control xControl in gpbNiveau.Controls)
            {
                // Vérifie si chaque contrôle est de type RadioButton
                if (xControl is RadioButton)
                {
                    // Convertit le contrôle en objet RadioButton
                    RadioButton radioButton = xControl as RadioButton;
                    // Vérifie si le bouton radio est sélectionné
                    if (radioButton.Checked)
                    {
                        // Si un bouton radio est sélectionné, met à jour la propriété "rdbNiveau" de l'objet "unEleve" avec ce bouton radio et arrête la boucle
                        if(!unEleve.rdbNiveau.Name.Contains("NR"))
                            unEleve.anciensNiveaux.Add(unEleve.rdbNiveau.Name.Last());

                        unEleve.rdbNiveau = radioButton;
                        MessageBox.Show("Les modifications du niveau de l'élève ont été enregistrées.");
                        break;
                    }
                }
            }

            if (eleveInscrit.Checked)
            {
                unEleve.nonInscrit = "";
            }
            else
            {
                unEleve.nonInscrit = "V";
            }

            foreach (Control xControl in gpbSexe.Controls)
            {
                if (xControl is RadioButton)
                {
                    // Convertit le contrôle en objet RadioButton
                    RadioButton radioButton = xControl as RadioButton;
                    // Vérifie si le bouton radio est sélectionné
                    if (radioButton.Checked)
                    {
                        // Si un bouton radio est sélectionné, met à jour la propriété "rdbNiveau" de l'objet "unEleve" avec ce bouton radio et arrête la boucle
                        unEleve.sexeEleve = (string)radioButton.Tag;
                        MessageBox.Show("Les modifications du sexe l'élève ont été enregistrées.");
                        break;
                    }
                }
            }
        }

        private void btnEnregistrerProf_Click(object sender, EventArgs e, Classe uneClasse, ComboBox cmbProfPrinc)
        {
            if (cmbProfPrinc.SelectedItem != null)
            {
                string profPrinc = cmbProfPrinc.SelectedItem.ToString();
                MessageBox.Show("Professeur principal enregistrée : " + profPrinc);
                uneClasse.setNomProfPrinc(profPrinc);

            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une valeur dans la liste déroulante.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            if (currentPanel != null)
            {
                this.Controls.Remove(currentPanel);
                currentPanel.Dispose();
                currentPanel = null;
            }
        }

        private void btnQuitterEleve_Click(object sender, EventArgs e)
        {
            if (currentPanelEleve != null)
            {
                this.Controls.Remove(currentPanelEleve);
                currentPanelEleve.Dispose();
                currentPanelEleve = null;
            }
        }
        private void btnQuitterNiveau_Click(object sender, EventArgs e)
        {
            if (currentPanelNiv != null)
            {
                this.Controls.Remove(currentPanelNiv);
                currentPanelNiv.Dispose();
                currentPanelNiv = null;
            }
        }

        private void PanelClasse_DoubleClick(object sender, EventArgs e)
        {
            // Récupère le panel sur lequel l'événement a été déclenché et le convertit en objet Panel.
            Panel panelClasse = sender as Panel;
            // Récupère l'objet de type "Classe" associé au panel à l'aide de sa propriété "Tag"
            Classe uneClasse = panelClasse.Tag as Classe;

            // Appelle la méthode "getLesEleves()" de l'objet "uneClasse" pour obtenir la liste des élèves
            var lesEleves = uneClasse.getLesEleves();
            // Initialise les compteurs pour le nombre de filles, de garçons, ainsi que les niveaux A, B et C
            int nbTotEleve = 0;
            int nbFille = 0;
            int nbGarcon = 0;
            int nbNiveauA = 0;
            int nbNiveauB = 0;
            int nbNiveauC = 0;
            int nbNiveauD = 0;
            int nbNiveauE = 0;
            int nbNiveauNR = 0; // NR pour Non renseigné
            int nbLatin = 0;
            int nbEspagnol = 0;
            int nbAllemand = 0;
            int nbAnglaisLv2 = 0;
            int nbBilingue = 0;
            int nbCultureReg = 0;
            int nbSegpa = 0;
            int nbUPE2A = 0;
            int nbUlis = 0;
            int nbNonInscrit = 0;
            int nbNeufeld = 0;
            int nbMadeleine = 0;
            int nbLouvois = 0;
            int nbSchluthfeld = 0;
            int nbThomas = 0;
            int nbAutre = 0;

            // Parcourt la liste des élèves
            foreach (Eleve xEleve in lesEleves)
            {
                nbTotEleve++;
                // Vérifie le sexe de chaque élève et incrémente le compteur correspondant
                if (xEleve.sexeEleve == "H")
                {
                    nbGarcon++;
                }
                else if (xEleve.sexeEleve == "F")
                {
                    nbFille++;
                }
                // Vérifie si le bouton radio du niveau de l'élève n'est pas null
                if (xEleve.rdbNiveau != null)
                {
                    // Vérifie le nom du bouton radio et incrémente le compteur correspondant au niveau A, B ou C
                    if (xEleve.rdbNiveau.Name == "rdbA")
                    {
                        nbNiveauA++;
                    }
                    else if (xEleve.rdbNiveau.Name == "rdbB")
                    {
                        nbNiveauB++;
                    }
                    else if (xEleve.rdbNiveau.Name == "rdbC")
                    {
                        nbNiveauC++;
                    }
                    else if (xEleve.rdbNiveau.Name == "rdbD")
                    {
                        nbNiveauD++;
                    }
                    else if (xEleve.rdbNiveau.Name == "rdbE")
                    {
                        nbNiveauE++;
                    }
                    else if (xEleve.rdbNiveau.Name == "rdbNR")
                    {
                        nbNiveauNR++;
                    }
                }
                //
                if (xEleve.LV1Eleve == "Bilingue")
                {
                    nbBilingue++;
                }


                if (xEleve.option1Eleve == "Upe2a")
                {
                    nbUPE2A++;
                }
                else if (xEleve.option1Eleve == "Ulis")
                {
                    nbUlis++;
                }
                else if (xEleve.option1Eleve == "Segpa")
                {
                    nbSegpa++;
                }
                else if (xEleve.option1Eleve.Contains("Angl"))
                {
                    nbAnglaisLv2++;
                }
                else if (xEleve.option1Eleve.Contains("All"))
                {
                    nbAllemand++;
                }
                else if (xEleve.option1Eleve.Contains("Esp"))
                {
                    nbEspagnol++;
                }

                if (xEleve.option2Eleve == "Latin")
                {
                    nbLatin++;
                }
                else if (xEleve.option2Eleve == "CulturesReg")
                {
                    nbCultureReg++;
                }

                switch (xEleve.etablissementOrigine)
                {
                    case "Neufeld":
                        nbNeufeld++;
                        break;
                    case "Ste.Madeleine":
                        nbMadeleine++;
                        break;
                    case "Louvois":
                        nbLouvois++;
                        break;
                    case "Schluthfeld":
                        nbSchluthfeld++;
                        break;
                    case "St.Thomas":
                        nbThomas++;
                        break;
                    case "Autre":
                        nbAutre++;
                        break;
                }

                if (!String.IsNullOrEmpty(xEleve.nonInscrit))
                {
                    nbNonInscrit++;
                }
            }

            if (currentPanel != null)
            {
                this.Controls.Remove(currentPanel);
                currentPanel.Dispose();
            }

            // Crée un nouveau Panel au lieu d'un Form
            Panel pnlInfoClasse = new Panel();


            // Définit la couleur de fond du panel en blanc
            pnlInfoClasse.BackColor = Color.White;

            // Définit le titre comme un label dans le panel
            Label titleLabel = new Label();
            titleLabel.Text = "Information de la " + uneClasse.nomDeLaClasse;
            titleLabel.Font = new Font(titleLabel.Font, FontStyle.Bold);
            titleLabel.Size = new Size(300, 20);
            titleLabel.Location = new Point(10, 10);
            pnlInfoClasse.Controls.Add(titleLabel);

            // Définit la taille du panel
            pnlInfoClasse.Size = new Size(400, 400);
            pnlInfoClasse.BorderStyle = BorderStyle.FixedSingle;


            if (nbNeufeld + nbMadeleine + nbLouvois + nbSchluthfeld + nbThomas + nbAutre > 0)
            {
                pnlInfoClasse.Size = new Size(400, 480);

                GroupBox gpbEtabOrig = new GroupBox();
                gpbEtabOrig.Size = new Size(380, 100);
                gpbEtabOrig.Location = new Point(10, 370);
                gpbEtabOrig.Text = "Établissements d'origine";


                Label lblNeufeld = new Label();
                lblNeufeld.Location = new Point(30, 30);
                lblNeufeld.Size = new Size(95, 30);
                lblNeufeld.Text = "Neufeld : " + nbNeufeld;
                gpbEtabOrig.Controls.Add(lblNeufeld);

                int pointWidth = 30 + lblNeufeld.Width + 10;

                Label lblMadeleine = new Label();
                lblMadeleine.Location = new Point(pointWidth, 30);
                lblMadeleine.Size = new Size(105, 30);
                lblMadeleine.Text = "Ste.Madeleine : " + nbMadeleine;
                gpbEtabOrig.Controls.Add(lblMadeleine);

                pointWidth += 30 + lblMadeleine.Width;

                Label lblLouvois = new Label();
                lblLouvois.Location = new Point(pointWidth, 30);
                lblLouvois.Size = new Size(95, 30);
                lblLouvois.Text = "Louvois : " + nbLouvois;
                gpbEtabOrig.Controls.Add(lblLouvois);


                Label lblThomas = new Label();
                lblThomas.Location = new Point(30, 65);
                lblThomas.Size = new Size(95, 30);
                lblThomas.Text = "St.Thomas : " + nbThomas;
                gpbEtabOrig.Controls.Add(lblThomas);

                pointWidth = 30 + lblThomas.Width + 10;

                Label lblSchluthfeld = new Label();
                lblSchluthfeld.Location = new Point(pointWidth, 65);
                lblSchluthfeld.Size = new Size(95, 30);
                lblSchluthfeld.Text = "Schluthfeld : " + nbSchluthfeld;
                gpbEtabOrig.Controls.Add(lblSchluthfeld);

                pointWidth += 30 + lblSchluthfeld.Width + 10;

                Label lblAutre = new Label();
                lblAutre.Location = new Point(pointWidth, 65);
                lblAutre.Size = new Size(95, 30);
                lblAutre.Text = "Autre : " + nbAutre;
                gpbEtabOrig.Controls.Add(lblAutre);

                pnlInfoClasse.Controls.Add(gpbEtabOrig);
            }

            // Pour afficher le professeur principal de la classe et le changer si besoin
            // ------------------------------------------------------------------------- //
            // Un nouvel objet ComboBox est créé et assigné à la variable cmbProfPrinc. 
            // Ce ComboBox sera utilisé pour afficher le professeur principal de la classe et permettre de le changer si nécessaire
            ComboBox cmbProfPrinc = new ComboBox();
            // La propriété BackColor est définie sur Color.WhiteSmoke, ce qui définit la couleur de fond du ComboBox comme étant du blanc fumée
            cmbProfPrinc.BackColor = Color.WhiteSmoke;
            // Définition de la position du ComboBox
            cmbProfPrinc.Location = new Point(10, 30);
            // Définition de la taille du ComboBox
            cmbProfPrinc.Size = new Size(200, 30);
            // La propriété TabIndex est définie sur 1, ce qui indique l'ordre de tabulation du contrôle lors de la navigation au clavier.
            cmbProfPrinc.TabIndex = 1;
            cmbProfPrinc.SelectedText = uneClasse.getNomProfPrinc();
            // La méthode Items.AddRange() est appelée pour ajouter les éléments de la liste Global.listeNomEtPrenomProf (qui est convertie en tableau à l'aide de ToArray()) 
            // à la collection d'éléments du ComboBox. Cela permet de remplir le ComboBox avec les noms et prénoms des professeurs disponibles
            cmbProfPrinc.Items.AddRange(Global.listeNomEtPrenomProf.ToArray());

            pnlInfoClasse.Controls.Add(cmbProfPrinc);

            // Crée un bouton "Enregistrer"
            Button btnEnregistrerProf = new Button();
            btnEnregistrerProf.Text = "Enregistrer";
            btnEnregistrerProf.Location = new Point(250, 30); // x, y
            pnlInfoClasse.Controls.Add(btnEnregistrerProf);
            btnEnregistrerProf.Click += (s, ev) => btnEnregistrerProf_Click(sender, e, uneClasse, cmbProfPrinc);
            btnEnregistrerProf.Tag = cmbProfPrinc.SelectedItem;

            // Créer les labels contenant le nombre de fille, de garçon et le nombre des niveaux de la classe
            Label nbTotalEleves = new Label();
            nbTotalEleves.Location = new Point(50, 60);
            nbTotalEleves.Size = new Size(150, 20);
            nbTotalEleves.Text = "Total des élèves : " + nbTotEleve;
            pnlInfoClasse.Controls.Add(nbTotalEleves);

            if (nbNonInscrit > 0)
            {
                Label nbInscrits = new Label();
                nbInscrits.Location = new Point(200, 60);
                nbInscrits.Size = new Size(150, 20);
                nbInscrits.Text = "Élèves inscrits : " + (nbTotEleve - nbNonInscrit);
                pnlInfoClasse.Controls.Add(nbInscrits);
            }


            Label nbGarconTot = new Label();
            nbGarconTot.Location = new Point(50, 90);
            nbGarconTot.Size = new Size(100, 20);
            nbGarconTot.Text = "Garçon : " + nbGarcon;
            pnlInfoClasse.Controls.Add(nbGarconTot);

            Label nbFilleTot = new Label();
            nbFilleTot.Location = new Point(50, 120);
            nbFilleTot.Size = new Size(100, 20);
            nbFilleTot.Text = "Fille : " + nbFille;
            pnlInfoClasse.Controls.Add(nbFilleTot);

            Label nbNiveauATot = new Label();
            nbNiveauATot.Location = new Point(50, 150);
            nbNiveauATot.Size = new Size(100, 20);
            nbNiveauATot.Text = "Niveau A : " + nbNiveauA;
            pnlInfoClasse.Controls.Add(nbNiveauATot);

            Label nbNiveauBTot = new Label();
            nbNiveauBTot.Location = new Point(50, 180);
            nbNiveauBTot.Size = new Size(100, 20);
            nbNiveauBTot.Text = "Niveau B : " + nbNiveauB;
            pnlInfoClasse.Controls.Add(nbNiveauBTot);

            Label nbNiveauCTot = new Label();
            nbNiveauCTot.Location = new Point(50, 210);
            nbNiveauCTot.Size = new Size(100, 20);
            nbNiveauCTot.Text = "Niveau C : " + nbNiveauC;
            pnlInfoClasse.Controls.Add(nbNiveauCTot);

            Label nbNiveauDTot = new Label();
            nbNiveauDTot.Location = new Point(50, 240);
            nbNiveauDTot.Size = new Size(100, 20);
            nbNiveauDTot.Text = "Niveau D : " + nbNiveauD;
            pnlInfoClasse.Controls.Add(nbNiveauDTot);

            Label nbNiveauETot = new Label();
            nbNiveauETot.Location = new Point(50, 270);
            nbNiveauETot.Size = new Size(100, 20);
            nbNiveauETot.Text = "Niveau E : " + nbNiveauE;
            pnlInfoClasse.Controls.Add(nbNiveauETot);

            Label nbNiveauNRTot = new Label();
            nbNiveauNRTot.Location = new Point(50, 300);
            nbNiveauNRTot.Size = new Size(100, 20);
            nbNiveauNRTot.Text = "Non renseigné : " + nbNiveauNR;
            pnlInfoClasse.Controls.Add(nbNiveauNRTot);

            Label nbAllemandTot = new Label();
            nbAllemandTot.Location = new Point(200, 60);
            nbAllemandTot.Size = new Size(150, 20);
            nbAllemandTot.Text = "ALLEMAND LV2: " + nbAllemand;
            pnlInfoClasse.Controls.Add(nbAllemandTot);

            Label nbEspagnolTot = new Label();
            nbEspagnolTot.Location = new Point(200, 90);
            nbEspagnolTot.Size = new Size(100, 20);
            nbEspagnolTot.Text = "ESPAGNOL : " + nbEspagnol;
            pnlInfoClasse.Controls.Add(nbEspagnolTot);

            Label nbAnglaisLv2Tot = new Label();
            nbAnglaisLv2Tot.Location = new Point(200, 120);
            nbAnglaisLv2Tot.Size = new Size(100, 20);
            nbAnglaisLv2Tot.Text = "ANGLAIS LV2 : " + nbAnglaisLv2;
            pnlInfoClasse.Controls.Add(nbAnglaisLv2Tot);

            Label nbBilingueTot = new Label();
            nbBilingueTot.Location = new Point(200, 150);
            nbBilingueTot.Size = new Size(100, 20);
            nbBilingueTot.Text = "BILINGUE : " + nbBilingue;
            pnlInfoClasse.Controls.Add(nbBilingueTot);

            Label nbSegpaTot = new Label();
            nbSegpaTot.Location = new Point(200, 180);
            nbSegpaTot.Size = new Size(100, 20);
            nbSegpaTot.Text = "SEGPA : " + nbSegpa;
            pnlInfoClasse.Controls.Add(nbSegpaTot);

            Label nbUpe2aTot = new Label();
            nbUpe2aTot.Location = new Point(200, 210);
            nbUpe2aTot.Size = new Size(100, 20);
            nbUpe2aTot.Text = "UPE2A : " + nbUPE2A;
            pnlInfoClasse.Controls.Add(nbUpe2aTot);

            Label nbUlisTot = new Label();
            nbUlisTot.Location = new Point(200, 240);
            nbUlisTot.Size = new Size(100, 20);
            nbUlisTot.Text = "ULIS : " + nbUlis;
            pnlInfoClasse.Controls.Add(nbUlisTot);

            Label nbLatinTot = new Label();
            nbLatinTot.Location = new Point(200, 270);
            nbLatinTot.Size = new Size(100, 20);
            nbLatinTot.Text = "LATIN : " + nbLatin;
            pnlInfoClasse.Controls.Add(nbLatinTot);

            Label nbCultureRegTot = new Label();
            nbCultureRegTot.Location = new Point(200, 300);
            nbCultureRegTot.Size = new Size(200, 20);
            nbCultureRegTot.Text = "Culture régionale : " + nbCultureReg;
            pnlInfoClasse.Controls.Add(nbCultureRegTot);

            Button btnQuitter = new Button();
            btnQuitter.Text = "Quitter";
            btnQuitter.Location = new Point(50, 330); // x, y
            pnlInfoClasse.Controls.Add(btnQuitter);
            btnQuitter.Click += new EventHandler(btnQuitter_Click);

            Button btnCourbe = new Button();
            btnCourbe.Text = "Courbe de Gauss";
            btnCourbe.Size = new Size(120, 20);
            btnCourbe.Location = new Point(200, 330);
            pnlInfoClasse.Controls.Add(btnCourbe);
            btnCourbe.Click += new EventHandler((s, ev) => BtnCourbe_Click(uneClasse, ev));

            // Ajoute le Panel au formulaire principal
            layoutNiveaux.Controls.Add(pnlInfoClasse);

            // Met à jour la référence au panel actuel
            currentPanel = pnlInfoClasse;

            layoutNiveaux.HorizontalScroll.Value = layoutNiveaux.HorizontalScroll.Maximum;
        }

        // Méthode déclenchée lors du clic sur le bouton "BtnCourbe"
        private void BtnCourbe_Click(object sender, EventArgs e)
        {
            // Convertit le sender en objet de type "Classe"
            Classe uneClasse = sender as Classe;

            // Initialise une liste pour stocker les notes des élèves
            List<int> notes = new List<int>();
            // Compteur pour le nombre d'élèves avec des notes
            int elevesAvecNote = 0;

            // Parcourt tous les élèves de la classe
            foreach (Eleve elv in uneClasse.getLesEleves())
            {
                if (elv.rdbNiveau != null)
                {
                    // Vérifie le nom du contrôle radio bouton associé au niveau de l'élève
                    switch (elv.rdbNiveau.Name)
                    {
                        case "rdbA":
                            notes.Add(5);  // Ajoute 5 pour le niveau A
                            elevesAvecNote++;
                            break;
                        case "rdbB":
                            notes.Add(4);  // Ajoute 4 pour le niveau B
                            elevesAvecNote++;
                            break;
                        case "rdbC":
                            notes.Add(3);  // Ajoute 3 pour le niveau C
                            elevesAvecNote++;
                            break;
                        case "rdbD":
                            notes.Add(2);  // Ajoute 2 pour le niveau D
                            elevesAvecNote++;
                            break;
                        case "rdbE":
                            notes.Add(1);  // Ajoute 1 pour le niveau E
                            elevesAvecNote++;
                            break;
                    }
                }

            }

            // Vérifie si au moins 5 élèves ont des notes
            if (elevesAvecNote >= 5)
            {
                // Calcule la moyenne des notes
                double moyenne = notes.Average();
                // Calcule la variance des notes
                double variance = notes.Sum(note => Math.Pow(note - moyenne, 2)) / notes.Count;
                // Calcule l'écart type des notes
                double ecartType = Math.Sqrt(variance);

                // Crée un nouveau formulaire pour afficher la courbe de Gauss
                Form dynamicForm = new Form();
                dynamicForm.Size = new Size(600, 600);
                dynamicForm.Text = "Courbe de Gauss " + uneClasse.nomDeLaClasse;

                // Fonction pour convertir une moyenne en une lettre
                string ConvertMoyenneToLetter(double moy)
                {
                    if (moy >= 4.5) return "A";
                    if (moy >= 3.5) return "B";
                    if (moy >= 2.5) return "C";
                    if (moy >= 1.5) return "D";
                    return "E";
                }

                // Lettre correspondant à la moyenne
                string moyenneLettre = ConvertMoyenneToLetter(moyenne);

                // Création du modèle de graphique
                var plotModel = new PlotModel { Title = "Courbe de Gauss des notes de la classe " + uneClasse.nomDeLaClasse + $"\nMoyenne: {moyenneLettre}, Écart type: {ecartType:F2}" };

                // Configuration de l'axe X
                var xAxis = new CategoryAxis
                {
                    Position = AxisPosition.Bottom,
                    Title = "Notes",
                    Key = "NotesAxis",
                    IsZoomEnabled = false, // Désactive le zoom sur l'axe X
                    IsPanEnabled = false // Désactive le pan sur l'axe X
                };

                // Ajout des étiquettes A à E correspondant aux valeurs 5 à 1
                xAxis.Labels.Add("E"); // Correspond à 1
                xAxis.Labels.Add("D"); // Correspond à 2
                xAxis.Labels.Add("C"); // Correspond à 3
                xAxis.Labels.Add("B"); // Correspond à 4
                xAxis.Labels.Add("A"); // Correspond à 5

                // Configuration de l'axe Y pour afficher des nombres entiers
                var yAxis = new LinearAxis
                {
                    Position = AxisPosition.Left,
                    Minimum = 0,
                    MajorStep = 1,
                    MinorStep = 1,
                    StringFormat = "0",
                    IsZoomEnabled = false, // Désactive le zoom sur l'axe Y
                    IsPanEnabled = false // Désactive le pan sur l'axe Y
                };

                // Ajoute les axes au modèle de graphique
                plotModel.Axes.Add(xAxis);
                plotModel.Axes.Add(yAxis);

                // Création de la série pour la courbe de Gauss
                var lineSeries = new LineSeries { Title = "Courbe de Gauss" };

                // Génération des points pour la courbe de Gauss
                for (double x = 0; x <= 6; x += 0.01)
                {
                    // Calcul de la valeur de y pour la courbe de Gauss
                    double y = (1 / (ecartType * Math.Sqrt(2 * Math.PI))) * Math.Exp(-Math.Pow((x + 1) - moyenne, 2) / (2 * Math.Pow(ecartType, 2)));
                    lineSeries.Points.Add(new DataPoint(x, y));
                }

                // Ajout de la série au modèle de graphique
                plotModel.Series.Add(lineSeries);

                // Ajout d'une ligne verticale à la moyenne
                var averageLine = new LineAnnotation
                {
                    Type = LineAnnotationType.Vertical,
                    X = moyenne - 1,  // Ajustement pour l'échelle de l'axe X
                    Color = OxyColors.Red,
                    LineStyle = LineStyle.Solid,
                    Text = $"Moyenne: {moyenneLettre}",
                    TextOrientation = AnnotationTextOrientation.Vertical,
                    TextVerticalAlignment = VerticalAlignment.Top,
                    TextHorizontalAlignment = HorizontalAlignmentOxyPlot.Right
                };

                // Ajoute l'annotation de ligne moyenne au modèle de graphique
                plotModel.Annotations.Add(averageLine);

                var plo = new Plotplo();
                // Création du PlotView pour afficher le modèle de graphique
                var plotView = new PlotView
                {
                    Model = plotModel,
                    Dock = DockStyle.Fill
                };

                // Ajout du PlotView au formulaire
                dynamicForm.Controls.Add(plotView);

                // Affiche le formulaire
                dynamicForm.Show();
            }
            else
            {
                // Affiche un message si moins de 5 élèves ont des notes
                MessageBox.Show("Veuillez donner une note à au moins 5 élèves");
            }
        }


        private void PanelEleve_DoubleClick(object sender, EventArgs e)
        {
            Panel panelEleve = sender as Panel; // Convertit le contrôle "sender" en objet de type Panel
            Eleve unEleve = panelEleve.Tag as Eleve; // Obtient l'objet "Eleve" associé au panneau et le stocke dans la variable "unEleve"
            RadioButton rdbNiveauEleve = unEleve.rdbNiveau; // Obtient le bouton radio de niveau de l'élève associé à l'objet "Eleve"

            // Si un panel est déjà affiché, le supprimer
            if (currentPanelEleve != null)
            {
                this.Controls.Remove(currentPanelEleve);
                currentPanelEleve.Dispose();
            }

            // Crée un nouveau Panel au lieu d'un Form
            Panel pnlInfoEleve = new Panel();

            // Définit la couleur de fond du panel en blanc
            pnlInfoEleve.BackColor = Color.White;

            // Définit le titre comme un label dans le panel
            Label titleLabel = new Label();
            titleLabel.Text = "Information de " + unEleve.nomEleve + " " + unEleve.prenomEleve;
            titleLabel.Font = new Font(titleLabel.Font, FontStyle.Bold);
            titleLabel.Size = new Size(300, 20);
            titleLabel.Location = new Point(10, 10);
            pnlInfoEleve.Controls.Add(titleLabel);

            // Définit la taille du panel
            pnlInfoEleve.Size = new Size(400, 400);
            pnlInfoEleve.BorderStyle = BorderStyle.FixedSingle;
            Form fenetreInformationEleve = new Form(); // Crée une nouvelle fenêtre
            fenetreInformationEleve.Text = "Information de " + unEleve.nomEleve + " " + unEleve.prenomEleve; // Définit le texte de la fenêtre avec le nom et le prénom de l'élève
            fenetreInformationEleve.Size = new Size(400, 400); // Définit la taille de la fenêtre


            System.Windows.Forms.CheckBox eleveInscrit = new System.Windows.Forms.CheckBox();
            GroupBox gpbSexe = new GroupBox();
            if (unEleve.classeEleve.Substring(0, 1) == "6")
            {
                eleveInscrit.Location = new Point(15, 25);
                eleveInscrit.Text = "Élève inscrit";
                if (!String.IsNullOrEmpty(unEleve.nonInscrit))
                    eleveInscrit.Checked = false;
                else
                    eleveInscrit.Checked = true;
                pnlInfoEleve.Controls.Add(eleveInscrit);


                gpbSexe.Text = "Sexe de l'élève :";
                gpbSexe.Size = new Size(130, 70);
                gpbSexe.Location = new Point(250, 30);
                pnlInfoEleve.Controls.Add(gpbSexe);

                RadioButton rdbH = new RadioButton();
                rdbH.Text = "Garçon";
                rdbH.Name = "rdbH";
                rdbH.Tag = "H";
                rdbH.Location = new Point(20, 20);
                gpbSexe.Controls.Add(rdbH);

                RadioButton rdbF = new RadioButton();
                rdbF.Text = "Fille";
                rdbF.Name = "rdbF";
                rdbF.Tag = "F";
                rdbF.Location = new Point(20, 40);
                gpbSexe.Controls.Add(rdbF);

                if (unEleve.sexeEleve == "H")
                    rdbH.Checked = true;
                else if (unEleve.sexeEleve == "F")
                    rdbF.Checked = true;
            }


            // Crée les labels pour le nom et le prénom de l'élève
            Label nomEleve = new Label();
            nomEleve.Location = new Point(100, 50);
            nomEleve.Size = new Size(200, 20);
            nomEleve.Text = unEleve.nomEleve;
            pnlInfoEleve.Controls.Add(nomEleve);

            Label prenomEleve = new Label();
            prenomEleve.Location = new Point(100, 80);
            prenomEleve.Size = new Size(200, 20);
            prenomEleve.Text = unEleve.prenomEleve;
            pnlInfoEleve.Controls.Add(prenomEleve);

            if (unEleve.dateEntree != null)
            {
                Label dateEntree = new Label();
                dateEntree.Location = new Point(200, 140);
                dateEntree.Size = new Size(200, 20);
                dateEntree.Text = "Date d'entrée : " + unEleve.dateEntree.ToString("dd MMMM yyyy");
                pnlInfoEleve.Controls.Add(dateEntree);
            }

            if (unEleve.dateSortie != default)
            {
                Label dateSortie = new Label();
                dateSortie.Location = new Point(200, 170);
                dateSortie.Size = new Size(200, 20);
                dateSortie.Text = "Date de sortie : " + unEleve.dateSortie.ToString("dd MMMM yyyy");
                pnlInfoEleve.Controls.Add(dateSortie);
            }
            else
            {
                Button departEleve = new Button();
                departEleve.Location = new Point(225, 170);
                departEleve.Size = new Size(125, 30);
                departEleve.Text = "Départ de l'élève";
                departEleve.Click += new EventHandler((s, ev) => BoutonDepartEleve_Click(unEleve, ev));
                pnlInfoEleve.Controls.Add(departEleve);
            }

            if (unEleve.anciensNiveaux.Count > 0)
            {
                string ancNiv = "Anciens niveaux : ";
                foreach (char niv in unEleve.anciensNiveaux)
                {
                    ancNiv += " " + niv + " ;";
                }

                ancNiv = ancNiv.Remove(ancNiv.Length - 1);

                Label anciensNiv = new Label();
                anciensNiv.Location = new Point(200, 230);
                anciensNiv.Size = new Size(200, 20);
                anciensNiv.Text = ancNiv;
                pnlInfoEleve.Controls.Add(anciensNiv);
            }

            if (unEleve.anciennesClasses.Count > 0 && !string.IsNullOrEmpty(unEleve.anciennesClasses[0]))
            {
                string ancCls = "Anciennes classes : ";
                foreach(string cls in unEleve.anciennesClasses)
                {
                    ancCls += "\n" + cls + " ;";
                }

                ancCls = ancCls.Remove(ancCls.Length - 1);

                Label anciennesClasses = new Label();
                anciennesClasses.Location = new Point(200, 260);
                anciennesClasses.Size = new Size(200, 70);
                anciennesClasses.Text = ancCls;
                pnlInfoEleve.Controls.Add(anciennesClasses);
            }


            // Crée les panels pour les options de l'élève
            Panel LV1Couleur = new Panel();
            LV1Couleur.Location = new Point(20, 50);
            LV1Couleur.Size = new Size(70, 20);
            LV1Couleur.BackColor = unEleve.LV1.couleur;
            if (LV1Couleur.BackColor != Color.Transparent)
                LV1Couleur.BorderStyle = BorderStyle.FixedSingle;
            pnlInfoEleve.Controls.Add(LV1Couleur);

            Label LV1nom = new Label();
            LV1nom.AutoSize = true;
            LV1nom.Dock = DockStyle.Top;
            LV1nom.Location = new Point(20, 50);
            LV1nom.Name = "LV1nom";
            LV1nom.Size = new Size(50, 15);
            LV1nom.TabIndex = 0;
            LV1nom.Text = unEleve.LV1.nomOption;
            LV1nom.TextAlign = ContentAlignment.MiddleCenter;
            if (LV1Couleur.BackColor.GetBrightness() <= 0.5)
            {
                LV1nom.ForeColor = Color.White;
            }
            else
            {
                LV1nom.ForeColor = Color.Black;
            }
            LV1Couleur.Controls.Add(LV1nom);

            // Crée les panels pour les options de l'élève
            Panel option1Couleur = new Panel();
            option1Couleur.Location = new Point(20, 80);
            option1Couleur.Size = new Size(70, 20);
            option1Couleur.BackColor = unEleve.option1.couleur;
            if (option1Couleur.BackColor != Color.Transparent)
                option1Couleur.BorderStyle = BorderStyle.FixedSingle;
            pnlInfoEleve.Controls.Add(option1Couleur);

            if (unEleve.option1.nomOption != "Aucune")
            {
                Label option1nom = new Label();
                option1nom.AutoSize = true;
                option1nom.Dock = DockStyle.Top;
                option1nom.Location = new Point(20, 80);
                option1nom.Name = "option1nom";
                option1nom.Size = new Size(50, 15);
                option1nom.TabIndex = 0;
                option1nom.Text = unEleve.option1.nomOption;
                option1nom.TextAlign = ContentAlignment.MiddleCenter;
                if (option1Couleur.BackColor.GetBrightness() < 0.5)
                {
                    option1nom.ForeColor = Color.White;
                }
                else
                {
                    option1nom.ForeColor = Color.Black;
                }
                option1Couleur.Controls.Add(option1nom);
            }


            Panel option2Couleur = new Panel();
            option2Couleur.Location = new Point(20, 110);
            option2Couleur.Size = new Size(70, 20);
            option2Couleur.BackColor = unEleve.option2.couleur;
            if (option2Couleur.BackColor != Color.Transparent)
                option2Couleur.BorderStyle = BorderStyle.FixedSingle;
            pnlInfoEleve.Controls.Add(option2Couleur);

            if (!unEleve.option2.nomOption.Contains("Aucune"))
            {
                Label option2nom = new Label();
                option2nom.AutoSize = true;
                option2nom.Dock = DockStyle.Top;
                option2nom.Location = new Point(20, 110);
                option2nom.Name = "option2nom";
                option2nom.Size = new Size(50, 15);
                option2nom.TabIndex = 0;
                option2nom.Text = unEleve.option2.nomOption;
                option2nom.TextAlign = ContentAlignment.MiddleCenter;
                if (option2Couleur.BackColor.GetBrightness() < 0.5)
                {
                    option2nom.ForeColor = Color.White;
                }
                else
                {
                    option2nom.ForeColor = Color.Black;
                }
                option2Couleur.Controls.Add(option2nom);
            }

            Button btnChangeOption = new Button();
            btnChangeOption.Size = new Size(120, 25);
            btnChangeOption.Location = new Point(100, 110);
            btnChangeOption.Text = "Changer les options";
            btnChangeOption.Click += (s, ev) => BtnChangeOption_Click(unEleve, ev);
            pnlInfoEleve.Controls.Add(btnChangeOption);


            // Crée un group box pour le niveau de l'élève
            GroupBox gpbNiveau = new GroupBox();
            gpbNiveau.Text = "Niveau de l'élève :";
            gpbNiveau.Size = new Size(150, 205);
            gpbNiveau.Location = new Point(20, 140);
            pnlInfoEleve.Controls.Add(gpbNiveau);

            // Crée les boutons radio pour les niveaux A, B, C, D et E
            RadioButton rdbNiveauA = new RadioButton();
            rdbNiveauA.Text = "A";
            rdbNiveauA.Name = "rdbA";
            rdbNiveauA.Location = new Point(20, 20);
            gpbNiveau.Controls.Add(rdbNiveauA);

            RadioButton rdbNiveauB = new RadioButton();
            rdbNiveauB.Text = "B";
            rdbNiveauB.Name = "rdbB";
            rdbNiveauB.Location = new Point(20, 50);
            gpbNiveau.Controls.Add(rdbNiveauB);

            RadioButton rdbNiveauC = new RadioButton();
            rdbNiveauC.Text = "C";
            rdbNiveauC.Name = "rdbC";
            rdbNiveauC.Location = new Point(20, 80);
            gpbNiveau.Controls.Add(rdbNiveauC);

            RadioButton rdbNiveauD = new RadioButton();
            rdbNiveauD.Text = "D";
            rdbNiveauD.Name = "rdbD";
            rdbNiveauD.Location = new Point(20, 110);
            gpbNiveau.Controls.Add(rdbNiveauD);

            RadioButton rdbNiveauE = new RadioButton();
            rdbNiveauE.Text = "E";
            rdbNiveauE.Name = "rdbE";
            rdbNiveauE.Location = new Point(20, 140);
            gpbNiveau.Controls.Add(rdbNiveauE);

            RadioButton rdbNiveauNonRenseigne = new RadioButton();
            rdbNiveauNonRenseigne.Text = "Non renseigné";
            rdbNiveauNonRenseigne.Name = "rdbNR";
            rdbNiveauNonRenseigne.Location = new Point(20, 170);
            gpbNiveau.Controls.Add(rdbNiveauNonRenseigne);

            // Vérifie si le bouton radio du niveau de l'élève n'est pas null
            if (unEleve.rdbNiveau != null)
            {
                // Parcourt tous les contrôles dans le group box
                foreach (Control xControl in gpbNiveau.Controls)
                {
                    // Vérifie si le contrôle actuel est un bouton radio
                    if (xControl is RadioButton radioButton)
                    {
                        // Vérifie si le nom du bouton radio correspond au niveau de l'élève
                        if (unEleve.rdbNiveau.Name == radioButton.Name)
                        {
                            // Coche le bouton radio correspondant au niveau de l'élève
                            radioButton.Checked = true;
                            // Sort de la boucle foreach une fois que le bouton radio correspondant a été trouvé
                            break;
                        }
                        else
                        {
                            // Coche le bouton radio "rdbNiveauNonRenseigne" par défaut si le bouton radio du niveau de l'élève est null
                            rdbNiveauNonRenseigne.Checked = true;
                        }
                    }
                }
            }
            else
            {
                // Coche le bouton radio "rdbNiveauNonRenseigne" par défaut si le bouton radio du niveau de l'élève est null
                rdbNiveauNonRenseigne.Checked = true;
            }

            // Crée un tuple contenant l'objet "Eleve" et le group box "gpbNiveau"
            var monTuple = new Tuple<Eleve, GroupBox, System.Windows.Forms.CheckBox, GroupBox>(unEleve, gpbNiveau, eleveInscrit, gpbSexe);

            // Crée un bouton "Enregistrer"
            Button btnEnregistrer = new Button();
            btnEnregistrer.Text = "Enregistrer";
            btnEnregistrer.Location = new Point(115, 355); // x, y
            pnlInfoEleve.Controls.Add(btnEnregistrer);
            btnEnregistrer.Click += new EventHandler(btnEnregistrer_Click);
            btnEnregistrer.Tag = monTuple;

            // Crée un bouton "Quitter"
            Button btnQuitterEleve = new Button();
            btnQuitterEleve.Text = "Quitter";
            btnQuitterEleve.Location = new Point(195, 355);
            pnlInfoEleve.Controls.Add(btnQuitterEleve);
            btnQuitterEleve.Click += new EventHandler(btnQuitterEleve_Click);
            btnQuitterEleve.Tag = pnlInfoEleve;

            // Ajoute le Panel au formulaire principal
            layoutNiveaux.Controls.Add(pnlInfoEleve);

            // Met à jour la référence au panel actuel
            currentPanelEleve = pnlInfoEleve;



            // Attribue le tuple "monTuple" comme valeur de la propriété "Tag" du bouton (pour stocker des informations supplémentaires)
            btnEnregistrer.Tag = monTuple;

            // Crée un bouton "Quitter", le configure avec du texte et une position
            Button btnQuitter = new Button();
            btnQuitter.Text = "Quitter";
            btnQuitter.Location = new Point(195, 325);
            // Ajoute le bouton à la fenêtre "fenetreInformationEleve"
            fenetreInformationEleve.Controls.Add(btnQuitter);
            // Lie l'événement "Click" du bouton à la méthode "btnQuitter_Click"
            btnQuitter.Click += new EventHandler(btnQuitter_Click);

            layoutNiveaux.VerticalScroll.Value = 0;
            layoutNiveaux.HorizontalScroll.Value = layoutNiveaux.HorizontalScroll.Maximum;

        }

        private void BoutonDepartEleve_Click(object sender, EventArgs e)
        {
            Eleve unEleve = sender as Eleve;

            // Crée un nouveau formulaire
            Form dynamicForm = new Form();
            dynamicForm.Size = new Size(400, 200);
            dynamicForm.MaximumSize = dynamicForm.Size;
            dynamicForm.MinimumSize = dynamicForm.Size;
            dynamicForm.Text = "Départ de " + unEleve.nomEleve + " " + unEleve.prenomEleve;

            Panel panel1 = new Panel();
            panel1.Size = new Size(384, 65);
            panel1.Location = new Point(0, 0);
            panel1.BackColor = Color.FromArgb(46, 56, 88);
            dynamicForm.Controls.Add(panel1);

            Label labelTitle = new Label();
            labelTitle.Text = "Départ de \n" + unEleve.nomEleve + "\n" + unEleve.prenomEleve;
            labelTitle.Location = new Point(125, 5);
            labelTitle.ForeColor = Color.WhiteSmoke;
            labelTitle.AutoSize = true;
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            labelTitle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            panel1.Controls.Add(labelTitle);

            // Crée et configure le DateTimePicker
            DateTimePicker dateTimePicker = new DateTimePicker();
            dateTimePicker.Location = new Point(110, 80);
            dateTimePicker.Size = new Size(150, 50);
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "dd/MM/yyyy"; // Définit le format de date
            dynamicForm.Controls.Add(dateTimePicker);

            // Crée et configure le bouton "Enregistrer"
            Button saveButton = new Button();
            saveButton.Text = "Enregistrer";
            saveButton.Location = new Point(150, 115);
            saveButton.Click += (s, args) =>
            {
                // Affiche une popup de confirmation
                DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir faire partir l'élève ?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // Code pour l'enregistrement (par exemple, sauvegarder la date sélectionnée)
                    unEleve.setDateSortie(dateTimePicker.Value);

                    MessageBox.Show("Le départ de l'élève a été enregistré.");
                }
            };
            dynamicForm.Controls.Add(saveButton);

            // Affiche le formulaire dynamique
            dynamicForm.Show();
        }

        private void BtnChangeOption_Click(object sender, EventArgs e)
        {
            ChangerOptionsEleve chgOptEleve = new ChangerOptionsEleve(sender);
            Eleve unEleve = sender as Eleve;
            chgOptEleve.Text = unEleve.nomEleve + " " + unEleve.prenomEleve;
            chgOptEleve.Show();
        }

        private void btnSupAffichage_Click(object sender, EventArgs e)
        {
            layoutNiveaux.Controls.Clear();
            btn6ème.Enabled = true;
            btn5ème.Enabled = true;
            btn3ème.Enabled = true;
            btn4ème.Enabled = true;
            btnStatsNiv.Visible = false;
            btnImprimer.Visible = false;
        }

        private void btnResetTout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer toutes les données ?", "Validation de la suppression des données", MessageBoxButtons.YesNo); // Affiche une boîte de dialogue de confirmation pour la suppression des données
            if (result == DialogResult.Yes) // Vérifie si l'utilisateur a répondu "Oui"
            {
                Global.anneeScolaire = 0; // Réinitialise la variable "anneeScolaire" à 0
                Global.elevesValides.Clear(); // Supprime tous les éléments de la liste "elevesValides"
                Global.options.Clear();
                Global.lesOptions.Clear();

                // Réinitialise les différentes listes et variables globales
                Global.lesNiveaux.Clear();
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
                Global.listeLV1EleveOption.Clear();
                Global.listeOption1EleveOption.Clear();
                Global.listeOption2EleveOption.Clear();
                Global.listeSexeEleve.Clear();
                Global.listeDateEntreeEleve.Clear();
                Global.listeDateSortieEleve.Clear();
                Global.listeEtabOrig.Clear();
                Global.listeIneEleve.Clear();
                Global.listeRedouble.Clear();

                Global.nbCodesMEF = 0;
                Global.nbEleves = 0;
                Global.nbElevesReal = 0;

                // Réinitialise les listes des noms de classe par niveau
                Global.nomsClasses6e.Clear();
                Global.nomsClasses5e.Clear();
                Global.nomsClasses4e.Clear();
                Global.nomsClasses3e.Clear();

                // Réinitialise les chemins de fichiers
                Global.pathXLS = "";
                Global.pathXLSX = "";
                Global.pathXML = "";

                layoutNiveaux.Controls.Clear(); // Supprime tous les contrôles enfants du conteneur "layoutNiveaux"
                btn6ème.Enabled = true; // Active le bouton "btn6ème"
                btn5ème.Enabled = true; // Active le bouton "btn5ème"
                btn3ème.Enabled = true; // Active le bouton "btn3ème"
                btn4ème.Enabled = true; // Active le bouton "btn4ème"

                MessageBox.Show("Toutes les informations contenues dans l'application ont été supprimées !"); // Affiche un message de confirmation de la suppression
            }
        }

        private void btnAjoutProf_Click(object sender, EventArgs e)
        {
            AjoutProfPrinc frmAjoutProf = new AjoutProfPrinc();
            frmAjoutProf.Show();
        }
        //---------------------------------------------------------------------------------------------------//


        // Ce bout de code gère l'enregistrement de toute les informations contenu dans l'application
        //----Par pitié ne supprimer pas ce code, il est vraiment important ET FONCTIONNEL----\\

        private void btnExtraireDonneesEleves_Click(object sender, EventArgs e)
        {
            try
            {
                using (XmlWriter writer = XmlWriter.Create("books.xml"))
                {

                }
                XmlDocument XMLDoc = new XmlDocument(); // Crée un nouvel objet XmlDocument
                XmlDeclaration dec = XMLDoc.CreateXmlDeclaration("1.0", "utf-8", null); // Crée une déclaration XML avec la version et l'encodage
                XMLDoc.AppendChild(dec); // Ajoute la déclaration au document XML

                XmlElement racine = XMLDoc.CreateElement(null, "College", null); // Crée un élément racine nommé "College"
                XMLDoc.AppendChild(racine); // Ajoute l'élément racine au document XML

                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//informationsElevesModifie.xml"; // Définit le chemin de destination du fichier XML

                for (int i = 0; i < Global.lesNiveaux.Count(); i++) // Boucle pour chaque niveau
                {
                    List<Classe> laClasse = Global.lesNiveaux[i].getLesClasse(); // Récupère la liste des classes pour le niveau actuel

                    XmlNode niveaux = XMLDoc.CreateElement("Niveau"); // Crée un élément "Niveau"

                    XmlAttribute attributeNiveau = XMLDoc.CreateAttribute("nomNiveau"); // Crée un attribut "nomNiveau"
                    attributeNiveau.Value = Global.lesNiveaux[i].nomDuNiveau; // Définit la valeur de l'attribut "nomNiveau"
                    niveaux.Attributes.Append(attributeNiveau); // Ajoute l'attribut à l'élément "Niveau"

                    for (int j = 0; j < laClasse.Count(); j++) // Boucle pour chaque classe dans le niveau actuel
                    {
                        XmlNode classe = XMLDoc.CreateElement("Classe"); // Crée un élément "Classe"
                        XmlAttribute attributeClasse = XMLDoc.CreateAttribute("nomClasse"); // Crée un attribut "nomClasse"
                        attributeClasse.Value = laClasse[j].nomDeLaClasse; // Définit la valeur de l'attribut "nomClasse"
                        XmlAttribute nomProfPrinc = XMLDoc.CreateAttribute("nomProfPrinc"); // Crée un attribut "nomProfPrinc"
                        nomProfPrinc.Value = laClasse[j].nomProfPrinc; // Définit la valeur de l'attribut "nomProfPrinc"
                        classe.Attributes.Append(attributeClasse); // Ajoute l'attribut à l'élément "Classe"
                        classe.Attributes.Append(nomProfPrinc); // Ajoute l'attribut à l'élément "Classe"

                        List<Eleve> uneListeEleve = laClasse[j].getLesEleves(); // Récupère la liste des élèves pour la classe actuelle
                        racine.AppendChild(niveaux); // Ajoute l'élément "Niveau" à l'élément racine "College"
                        niveaux.AppendChild(classe); // Ajoute l'élément "Classe" à l'élément "Niveau"

                        for (int k = 0; k < uneListeEleve.Count(); k++) // Boucle pour chaque élève dans la classe actuelle
                        {
                            Eleve unEleve = uneListeEleve[k]; // Récupère l'élève actuel

                            XmlNode eleve = XMLDoc.CreateElement("Eleve"); // Crée un élément "Eleve"
                            XmlAttribute numEleve = XMLDoc.CreateAttribute("numEleve");
                            numEleve.Value = unEleve.numEleve.ToString();
                            //eleve.InnerText = unEleve.numEleve.ToString(); // Définit le contenu texte de l'élément "Eleve"
                            eleve.Attributes.Append(numEleve);

                            XmlNode ineEleve = XMLDoc.CreateElement("ineEleve");
                            ineEleve.InnerText = unEleve.ine;
                            eleve.AppendChild(ineEleve);

                            // Crée et ajoute les attributs de l'élève
                            XmlNode attributeNom = XMLDoc.CreateElement("nomEleve");
                            attributeNom.InnerText = unEleve.nomEleve;
                            eleve.AppendChild(attributeNom);

                            XmlNode attributePrenom = XMLDoc.CreateElement("prenomEleve");
                            attributePrenom.InnerText = unEleve.prenomEleve;
                            eleve.AppendChild(attributePrenom);

                            XmlNode attributeNaissance = XMLDoc.CreateElement("naissanceEleve");
                            attributeNaissance.InnerText = unEleve.naissanceEleve;
                            eleve.AppendChild(attributeNaissance);

                            XmlNode attributeSexe = XMLDoc.CreateElement("sexeEleve");
                            attributeSexe.InnerText = unEleve.sexeEleve;
                            eleve.AppendChild(attributeSexe);

                            XmlNode attributeMef = XMLDoc.CreateElement("mefEleve");
                            attributeMef.InnerText = unEleve.mefEleve;
                            eleve.AppendChild(attributeMef);

                            XmlNode attributeRedouble = XMLDoc.CreateElement("redouble");
                            attributeRedouble.InnerText = unEleve.redouble;
                            eleve.AppendChild(attributeRedouble);

                            XmlNode attributeLV1 = XMLDoc.CreateElement("LV1Eleve");
                            attributeLV1.InnerText = unEleve.LV1.nomOption;
                            eleve.AppendChild(attributeLV1);

                            XmlNode attributeOption1 = XMLDoc.CreateElement("option1Eleve");
                            attributeOption1.InnerText = unEleve.option1.nomOption;
                            eleve.AppendChild(attributeOption1);

                            XmlNode attributeOption2 = XMLDoc.CreateElement("option2Eleve");
                            attributeOption2.InnerText = unEleve.option2.nomOption;
                            eleve.AppendChild(attributeOption2);

                            XmlNode attributeNote = XMLDoc.CreateElement("note");
                            attributeNote.InnerText = "";
                            if (unEleve.rdbNiveau != null && unEleve.rdbNiveau.Name.Last() != 'b' && unEleve.rdbNiveau.Name.Last() != 'R')
                            {
                                attributeNote.InnerText = unEleve.rdbNiveau.Name.Last().ToString();
                            }
                            else
                            {
                                attributeNote.InnerText = "NR";
                            }
                            eleve.AppendChild(attributeNote);

                            XmlNode dateEntree = XMLDoc.CreateElement("dateEntree");
                            dateEntree.InnerText = unEleve.dateEntree.ToString("dd/MM/yyyy");
                            eleve.AppendChild(dateEntree);

                            XmlNode dateSortie = XMLDoc.CreateElement("dateSortie");
                            if (unEleve.dateSortie != default)
                                dateSortie.InnerText = unEleve.dateSortie.ToString("dd/MM/yyyy");
                            else
                                dateSortie.InnerText = "";
                            eleve.AppendChild(dateSortie);

                            XmlNode eleveNonInscrit = XMLDoc.CreateElement("eleveNonInscrit");
                            eleveNonInscrit.InnerText = unEleve.nonInscrit;
                            eleve.AppendChild(eleveNonInscrit);

                            XmlNode etabOrig = XMLDoc.CreateElement("etabOrig");
                            etabOrig.InnerText = unEleve.etablissementOrigine;
                            eleve.AppendChild(etabOrig);

                            string lesAnciennesClasses = "";
                            foreach (string cls in unEleve.anciennesClasses)
                                lesAnciennesClasses += cls + ";";

                            if(!string.IsNullOrEmpty(lesAnciennesClasses))
                                lesAnciennesClasses = lesAnciennesClasses.Remove(lesAnciennesClasses.Length - 1);

                            XmlNode anciennesClasses = XMLDoc.CreateElement("anciennesClasses");
                            anciennesClasses.InnerText = lesAnciennesClasses;
                            eleve.AppendChild(anciennesClasses);

                            string lesAnciennesNotes = "";
                            foreach (char note in unEleve.anciensNiveaux)
                                lesAnciennesNotes += note + ";";
                            // ici

                            if (!string.IsNullOrEmpty(lesAnciennesNotes))
                                lesAnciennesNotes = lesAnciennesNotes.Remove(lesAnciennesNotes.Length - 1);

                            XmlNode anciennesNotes = XMLDoc.CreateElement("anciennesNotes");
                            anciennesNotes.InnerText = lesAnciennesNotes;
                            eleve.AppendChild(anciennesNotes);

                            classe.AppendChild(eleve); // Ajoute l'élément "Eleve" à l'élément "Classe"

                        }

                        try
                        {
                            XMLDoc.Save(path);
                            XMLDoc.Save("informationsElevesModifie.xml");
                        }
                        catch (Exception er)
                        {
                            MessageBox.Show(er.ToString());
                        }

                    }
                }
                try
                {
                    Excel.Application xApp = new Excel.Application();
                    Workbook excelWorkBook = xApp.Workbooks.OpenXML(path, Type.Missing, XlXmlLoadOption.xlXmlLoadImportToList);

                    excelWorkBook.SaveAs("informationsElevesModifieExcel", XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, false, false, XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                    excelWorkBook.Close();
                    xApp.Workbooks.Close();

                }
                catch (Exception err)
                {
                    MessageBox.Show("Il vous manque peut-être Microsoft Office Excel, qui est nécessaire au bon fonctionnement de cette application.\n" + err.ToString());
                }

                MessageBox.Show("Toute les données ont bien été enregistrer en format XML et XLSX ! \n" +
                    "(le fichier XML est sauvegarder sur le bureau sous le nom " + "\"informationsElevesModifie.xml\" " +
                    "et le fichier XML dans Documents sous le nom \"informationsElevesModifieExcel.xlsx\"");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void btnNouvelleAnnee_Click(object sender, EventArgs e)
        {
            if (Global.nbEleves < 50)
            {
                MessageBox.Show("Il faut d'abord charger un fichier élève dans -fichiers-");
            }
            else
            {
                OpenSLK frmAvertissementNewYear = new OpenSLK();
                frmAvertissementNewYear.Show();
                frmAvertissementNewYear.TopMost = true;
            }
        }

        private void btnSupAffichage_MouseHover(object sender, EventArgs e)
        {
            tltInforBoutonSupAffichage.Show("Ce bouton permet de supprimer l'affichage des labels !", btnSupAffichage);
        }

        private void btnResetTout_MouseHover(object sender, EventArgs e)
        {
            tltInforBoutonSuppressionDonnees.Show("Supprimer toute les données stockées dans l'application !", btnResetTout);
        }

        private void btnOuvertureXmlGenererParAppli_Click(object sender, EventArgs e)
        {
            OuvertureFichierGenererParNous frmFichierXml = new OuvertureFichierGenererParNous();
            frmFichierXml.Show();
        }

        private void pnlBarre_Paint(object sender, PaintEventArgs e)
        {
            //var legendItems = new (Color color, string description)[]
            //{
            //    (Color.DarkGreen, "Allemand"),
            //    (Color.Purple, "Espagnol"),
            //    (Color.Pink, "Anglais"),
            //    (Color.Yellow, "Latin"),
            //    (Color.OrangeRed, "Segpa"),
            //    (Color.SaddleBrown, "UPE2A"),
            //    (Color.Orange, "Ulis"),
            //    (Color.Blue, "Culture Régionale")
            //};

            //// Position de départ pour les éléments de légende
            //int startX = 800;
            //int startY = 10;
            //int offsetX = 150; // Espace horizontal entre chaque élément de légende
            //int offsetY = 20;  // Espace vertical entre les lignes
            //int colorBoxSize = 30; // Taille de chaque boîte de couleur

            //// Définir le nombre d'éléments par ligne
            //int itemsPerLine = 4;

            //for (int i = 0; i < legendItems.Length; i++)
            //{
            //    // Calculer la position X pour cet élément
            //    int currentX = startX + ((i % itemsPerLine) * offsetX);
            //    // Calculer la position Y pour cet élément
            //    int currentY = startY + ((i / itemsPerLine) * offsetY * 2); // multiplier par 2 pour laisser de l'espace pour les descriptions

            //    // Dessine le rectangle de couleur
            //    using (Brush brush = new SolidBrush(legendItems[i].color))
            //    {
            //        e.Graphics.FillRectangle(brush, currentX, currentY, colorBoxSize, colorBoxSize);
            //    }

            //    // Dessine le texte de description
            //    using (Font font = new Font("Arial", 10))
            //    {
            //        e.Graphics.DrawString(legendItems[i].description, font, Brushes.White, currentX + colorBoxSize + 5, currentY);
            //    }
            //}
        }

        private void PanelClasse_MouseHover(object sender, EventArgs e)
        {
            Panel panelClasse = sender as Panel;

            // Change la couleur de fond pour indiquer qu'il est survolé
            panelClasse.BackColor = Color.Orange;
        }

        private void PanelClasse_MouseLeave(object sender, EventArgs e)
        {
            Panel panelClasse = sender as Panel;

            // Rétablit la couleur de fond originale
            panelClasse.BackColor = Color.FromArgb(235, 194, 154);

        }
        private void PanelEleve6eme_MouseHover(object sender, EventArgs e)
        {
            Panel panelClasse = sender as Panel;

            // Change la couleur de fond pour indiquer qu'il est survolé
            panelClasse.BackColor = Color.Yellow;
        }

        private void PanelEleve6eme_MouseLeave(object sender, EventArgs e)
        {
            Panel panelClasse = sender as Panel;

            // Rétablit la couleur de fond originale
            panelClasse.BackColor = Color.FromArgb(253, 255, 157);

        }

        private void PanelEleve5eme_MouseHover(object sender, EventArgs e)
        {
            Panel panelClasse = sender as Panel;

            // Change la couleur de fond pour indiquer qu'il est survolé
            panelClasse.BackColor = Color.Green;
        }

        private void PanelEleve5eme_MouseLeave(object sender, EventArgs e)
        {
            Panel panelClasse = sender as Panel;

            // Rétablit la couleur de fond originale
            panelClasse.BackColor = Color.FromArgb(188, 255, 159);

        }

        private void PanelEleve4eme_MouseHover(object sender, EventArgs e)
        {
            Panel panelClasse = sender as Panel;

            // Change la couleur de fond pour indiquer qu'il est survolé
            panelClasse.BackColor = Color.Green;
        }

        private void PanelEleve4eme_MouseLeave(object sender, EventArgs e)
        {
            Panel panelClasse = sender as Panel;

            // Rétablit la couleur de fond originale
            panelClasse.BackColor = Color.FromArgb(188, 255, 159);

        }

        private void PanelEleve3eme_MouseHover(object sender, EventArgs e)
        {
            Panel panelClasse = sender as Panel;

            // Change la couleur de fond pour indiquer qu'il est survolé
            panelClasse.BackColor = Color.LightBlue;
        }

        private void PanelEleve3eme_MouseLeave(object sender, EventArgs e)
        {
            Panel panelClasse = sender as Panel;

            // Rétablit la couleur de fond originale
            panelClasse.BackColor = Color.FromArgb(136, 210, 247);

        }
        private void PanelEleveParti_MouseHover(object sender, EventArgs e)
        {
            Panel panelClasse = sender as Panel;

            // Change la couleur de fond pour indiquer qu'il est survolé
            panelClasse.BackColor = Color.LightCoral;
        }

        private void PanelEleveParti_MouseLeave(object sender, EventArgs e)
        {
            Panel panelClasse = sender as Panel;

            // Rétablit la couleur de fond originale
            panelClasse.BackColor = Color.Red;

        }

        private void PanelEleveNonInscrit_MouseHover(object sender, EventArgs e)
        {
            Panel panelClasse = sender as Panel;

            // Change la couleur de fond pour indiquer qu'il est survolé
            panelClasse.BackColor = Color.Silver;
        }

        private void PanelEleveNonInscrit_MouseLeave(object sender, EventArgs e)
        {
            Panel panelClasse = sender as Panel;

            // Rétablit la couleur de fond originale
            panelClasse.BackColor = Color.LightGray;

        }

        private void BtnActualiser_Click(object sender, EventArgs e)
        {
            ChangerLblTotalNbEleves();
            if (Global.options != null)
            {
                pnlBarre.Paint -= pnlBarre_Paint;
                pnlBarre.Paint += PnlBarre_RePaint;
                pnlBarre.Invalidate();
            }

            if (niveauCharge == 6)
            {
                btn6ème.PerformClick();
            }
            else if (niveauCharge == 5)
            {
                btn5ème.PerformClick();
            }
            else if (niveauCharge == 4)
            {
                btn4ème.PerformClick();
            }
            else if (niveauCharge == 3)
            {
                btn3ème.PerformClick();
            }
        }

        private void btnLegende_Click(object sender, EventArgs e)
        {
            ChangementLegende chgLegende = new ChangementLegende();
            chgLegende.Show();
        }

        private void PnlBarre_RePaint(object sender, PaintEventArgs e)
        {
            // Position de départ pour les éléments de légende
            int startX = 620;
            int startY = 10;
            int offsetX = 125; // Espace horizontal entre chaque élément de légende
            int offsetY = 20;  // Espace vertical entre les lignes
            int colorBoxSize = 30; // Taille de chaque boîte de couleur

            // Liste temporaire pour les options filtrées
            List<Options> options = new List<Options>();

            // Parcourir les options globales
            foreach (Options o in Global.options)
            {
                // Ajouter à la liste si la couleur n'est pas transparente et n'est pas nulle
                if (o.couleur != Color.Transparent && o.couleur != null)
                {
                    options.Add(o);

                    // Modifier le nom de l'option selon les critères spécifiés
                    if (o.nomOption.Contains("Angl"))
                    {
                        options.Last().nomOption = "Anglais";
                    }
                    else if (o.nomOption.Contains("All"))
                    {
                        options.Last().nomOption = "Allemand";
                    }
                    else if (o.nomOption.Contains("Esp"))
                    {
                        options.Last().nomOption = "Espagnol";
                    }
                    else if (o.nomOption.Contains("Ita"))
                    {
                        options.Last().nomOption = "Italien";
                    }
                    else if (o.nomOption.Contains("Russe"))
                    {
                        options.Last().nomOption = "Russe";
                    }
                    else if (o.nomOption.Contains("Arabe"))
                    {
                        options.Last().nomOption = "Arabe";
                    }
                    else if (o.nomOption.Contains("Chinois"))
                    {
                        options.Last().nomOption = "Chinois";
                    }
                }
            }
            // Trier les options par nom
            options = options.OrderBy(opt => opt.nomOption).ToList();

            // Définir le nombre d'éléments par ligne
            int itemsPerLine = options.Count / 2;
            if (options.Count % 2 == 1)
            {
                itemsPerLine++;
            }

            // Dessiner chaque option
            for (int i = 0; i < options.Count; i++)
            {
                // Calculer la position X pour cet élément
                int currentX = startX + ((i % itemsPerLine) * offsetX);
                // Calculer la position Y pour cet élément
                int currentY = startY + ((i / itemsPerLine) * offsetY * 2); // multiplier par 2 pour laisser de l'espace pour les descriptions

                // Dessiner le rectangle de couleur
                using (Brush brush = new SolidBrush(options[i].couleur))
                {
                    e.Graphics.FillRectangle(brush, currentX, currentY, colorBoxSize, colorBoxSize);
                }

                // Dessiner le texte de description
                using (Font font = new Font("Arial", 10))
                {
                    e.Graphics.DrawString(options[i].nomOption, font, Brushes.White, currentX + colorBoxSize + 5, currentY);
                }
            }
        }


        private void btnStatsNiv_Click(object sender, EventArgs e)
        {
            // Récupère le panel sur lequel l'événement a été déclenché et le convertit en objet Panel.
            Panel panelNiveau = layoutNiveaux as Panel;
            // Récupère l'objet de type "Classe" associé au panel à l'aide de sa propriété "Tag"
            Niveau unNiveau = panelNiveau.Tag as Niveau;

            // Initialise les compteurs pour le nombre de filles, de garçons, ainsi que les niveaux A, B, C, D et E
            int nbEleveNiveau = 0;
            int nbFille = 0;
            int nbGarcon = 0;
            int nbNiveauA = 0;
            int nbNiveauB = 0;
            int nbNiveauC = 0;
            int nbNiveauD = 0;
            int nbNiveauE = 0;
            int nbNiveauNR = 0; // NR = non renseigné
            int nbLatin = 0;
            int nbEspagnol = 0;
            int nbAllemand = 0;
            int nbAnglaisLv2 = 0;
            int nbBilingue = 0;
            int nbCultureReg = 0;
            int nbSegpa = 0;
            int nbUPE2A = 0;
            int nbUlis = 0;
            int nbNonInscrits = 0;
            int nbNeufeld = 0;
            int nbMadeleine = 0;
            int nbLouvois = 0;
            int nbSchluthfeld = 0;
            int nbThomas = 0;
            int nbAutre = 0;

            foreach (Classe uneClasse in unNiveau.getLesClasse())
            {
                // Appelle la méthode "getLesEleves()" de l'objet "uneClasse" pour obtenir la liste des élèves
                var lesEleves = uneClasse.getLesEleves();


                // Parcourt la liste des élèves
                foreach (Eleve xEleve in lesEleves)
                {
                    // Vérifie le sexe de chaque élève et incrémente le compteur correspondant
                    if (xEleve.sexeEleve == "H")
                    {
                        nbGarcon++;
                    }
                    else if (xEleve.sexeEleve == "F")
                    {
                        nbFille++;
                    }
                    // Vérifie si le bouton radio du niveau de l'élève n'est pas null
                    if (xEleve.rdbNiveau != null)
                    {
                        // Vérifie le nom du bouton radio et incrémente le compteur correspondant au niveau A, B ou C
                        if (xEleve.rdbNiveau.Name == "rdbA")
                        {
                            nbNiveauA++;
                        }
                        else if (xEleve.rdbNiveau.Name == "rdbB")
                        {
                            nbNiveauB++;
                        }
                        else if (xEleve.rdbNiveau.Name == "rdbC")
                        {
                            nbNiveauC++;
                        }
                        else if (xEleve.rdbNiveau.Name == "rdbD")
                        {
                            nbNiveauD++;
                        }
                        else if (xEleve.rdbNiveau.Name == "rdbE")
                        {
                            nbNiveauE++;
                        }
                        else if (xEleve.rdbNiveau.Name == "rdbNR")
                        {
                            nbNiveauNR++;
                        }
                    }

                    if (xEleve.LV1Eleve == "Bilingue")
                    {
                        nbBilingue++;
                    }

                    //
                    if (xEleve.option1Eleve == "Upe2a")
                    {
                        nbUPE2A++;
                    }
                    else if (xEleve.option1Eleve == "Ulis")
                    {
                        nbUlis++;
                    }
                    else if (xEleve.option1Eleve == "Segpa")
                    {
                        nbSegpa++;
                    }
                    else if (xEleve.option1Eleve.Contains("Angl"))
                    {
                        nbAnglaisLv2++;
                    }
                    else if (xEleve.option1Eleve.Contains("All"))
                    {
                        nbAllemand++;
                    }
                    else if (xEleve.option1Eleve.Contains("Esp"))
                    {
                        nbEspagnol++;
                    }

                    if (xEleve.option2Eleve == "Latin")
                    {
                        nbLatin++;
                    }
                    else if (xEleve.option2Eleve == "CultureReg")
                    {
                        nbCultureReg++;
                    }

                    switch (xEleve.etablissementOrigine)
                    {
                        case "Neufeld":
                            nbNeufeld++;
                            break;
                        case "Ste.Madeleine":
                            nbMadeleine++;
                            break;
                        case "Louvois":
                            nbLouvois++;
                            break;
                        case "Schluthfeld":
                            nbSchluthfeld++;
                            break;
                        case "St.Thomas":
                            nbThomas++;
                            break;
                        case "Autre":
                            nbAutre++;
                            break;
                    }

                    if (!String.IsNullOrEmpty(xEleve.nonInscrit))
                    {
                        nbNonInscrits++;
                    }

                    nbEleveNiveau++;
                }

            }

            if (currentPanelNiv != null)
            {
                this.Controls.Remove(currentPanelNiv);
                currentPanelNiv.Dispose();
            }

            // Crée un nouveau Panel au lieu d'un Form
            Panel pnlInfoNiveau = new Panel();


            // Définit la couleur de fond du panel en blanc
            pnlInfoNiveau.BackColor = Color.White;

            // Définit le titre comme un label dans le panel
            Label titleLabel = new Label();
            titleLabel.Text = "Information du niveau " + unNiveau.nomDuNiveau;
            titleLabel.Font = new Font(titleLabel.Font, FontStyle.Bold);
            titleLabel.Size = new Size(300, 20);
            titleLabel.Location = new Point(10, 10);
            pnlInfoNiveau.Controls.Add(titleLabel);

            // Définit la taille du panel
            pnlInfoNiveau.Size = new Size(400, 400);
            pnlInfoNiveau.BorderStyle = BorderStyle.FixedSingle;

            if (nbNeufeld + nbMadeleine + nbLouvois + nbSchluthfeld + nbThomas + nbAutre > 0)
            {
                pnlInfoNiveau.Size = new Size(400, 480);

                GroupBox gpbEtabOrig = new GroupBox();
                gpbEtabOrig.Size = new Size(380, 100);
                gpbEtabOrig.Location = new Point(10, 370);
                gpbEtabOrig.Text = "Établissements d'origine";


                Label lblNeufeld = new Label();
                lblNeufeld.Location = new Point(30, 30);
                lblNeufeld.Size = new Size(95, 30);
                lblNeufeld.Text = "Neufeld : " + nbNeufeld;
                gpbEtabOrig.Controls.Add(lblNeufeld);

                int pointWidth = 30 + lblNeufeld.Width + 10;

                Label lblMadeleine = new Label();
                lblMadeleine.Location = new Point(pointWidth, 30);
                lblMadeleine.Size = new Size(105, 30);
                lblMadeleine.Text = "Ste.Madeleine : " + nbMadeleine;
                gpbEtabOrig.Controls.Add(lblMadeleine);

                pointWidth += 30 + lblMadeleine.Width;

                Label lblLouvois = new Label();
                lblLouvois.Location = new Point(pointWidth, 30);
                lblLouvois.Size = new Size(95, 30);
                lblLouvois.Text = "Louvois : " + nbLouvois;
                gpbEtabOrig.Controls.Add(lblLouvois);


                Label lblThomas = new Label();
                lblThomas.Location = new Point(30, 65);
                lblThomas.Size = new Size(95, 30);
                lblThomas.Text = "St.Thomas : " + nbThomas;
                gpbEtabOrig.Controls.Add(lblThomas);

                pointWidth = 30 + lblThomas.Width + 10;

                Label lblSchluthfeld = new Label();
                lblSchluthfeld.Location = new Point(pointWidth, 65);
                lblSchluthfeld.Size = new Size(95, 30);
                lblSchluthfeld.Text = "Schluthfeld : " + nbSchluthfeld;
                gpbEtabOrig.Controls.Add(lblSchluthfeld);

                pointWidth += 30 + lblSchluthfeld.Width + 10;

                Label lblAutre = new Label();
                lblAutre.Location = new Point(pointWidth, 65);
                lblAutre.Size = new Size(95, 30);
                lblAutre.Text = "Autre : " + nbAutre;
                gpbEtabOrig.Controls.Add(lblAutre);

                pnlInfoNiveau.Controls.Add(gpbEtabOrig);
            }

            // Créer les labels contenant le nombre de fille, de garçon et le nombre des niveaux de la classe
            Label nbTotalEleves = new Label();
            nbTotalEleves.Location = new Point(50, 60);
            nbTotalEleves.Size = new Size(150, 20);
            nbTotalEleves.Text = "Total des élèves : " + nbEleveNiveau;
            pnlInfoNiveau.Controls.Add(nbTotalEleves);

            if (nbNonInscrits > 0)
            {
                Label nbInscrits = new Label();
                nbInscrits.Location = new Point(200, 60);
                nbInscrits.Size = new Size(150, 20);
                nbInscrits.Text = "Élèves inscrits : " + (nbEleveNiveau - nbNonInscrits);
                pnlInfoNiveau.Controls.Add(nbInscrits);
            }

            Label nbGarconTot = new Label();
            nbGarconTot.Location = new Point(50, 90);
            nbGarconTot.Size = new Size(100, 20);
            nbGarconTot.Text = "Garçon : " + nbGarcon;
            pnlInfoNiveau.Controls.Add(nbGarconTot);

            Label nbFilleTot = new Label();
            nbFilleTot.Location = new Point(50, 120);
            nbFilleTot.Size = new Size(100, 20);
            nbFilleTot.Text = "Fille : " + nbFille;
            pnlInfoNiveau.Controls.Add(nbFilleTot);

            Label nbNiveauATot = new Label();
            nbNiveauATot.Location = new Point(50, 150);
            nbNiveauATot.Size = new Size(100, 20);
            nbNiveauATot.Text = "Niveau A : " + nbNiveauA;
            pnlInfoNiveau.Controls.Add(nbNiveauATot);

            Label nbNiveauBTot = new Label();
            nbNiveauBTot.Location = new Point(50, 180);
            nbNiveauBTot.Size = new Size(100, 20);
            nbNiveauBTot.Text = "Niveau B : " + nbNiveauB;
            pnlInfoNiveau.Controls.Add(nbNiveauBTot);

            Label nbNiveauCTot = new Label();
            nbNiveauCTot.Location = new Point(50, 210);
            nbNiveauCTot.Size = new Size(100, 20);
            nbNiveauCTot.Text = "Niveau C : " + nbNiveauC;
            pnlInfoNiveau.Controls.Add(nbNiveauCTot);

            Label nbNiveauDTot = new Label();
            nbNiveauDTot.Location = new Point(50, 240);
            nbNiveauDTot.Size = new Size(100, 20);
            nbNiveauDTot.Text = "Niveau D : " + nbNiveauD;
            pnlInfoNiveau.Controls.Add(nbNiveauDTot);

            Label nbNiveauETot = new Label();
            nbNiveauETot.Location = new Point(50, 270);
            nbNiveauETot.Size = new Size(100, 20);
            nbNiveauETot.Text = "Niveau E : " + nbNiveauE;
            pnlInfoNiveau.Controls.Add(nbNiveauETot);

            Label nbNiveauNRTot = new Label();
            nbNiveauNRTot.Location = new Point(50, 300);
            nbNiveauNRTot.Size = new Size(100, 20);
            nbNiveauNRTot.Text = "Non renseigné : " + nbNiveauNR;
            pnlInfoNiveau.Controls.Add(nbNiveauNRTot);

            Label nbAllemandTot = new Label();
            nbAllemandTot.Location = new Point(200, 60);
            nbAllemandTot.Size = new Size(100, 20);
            nbAllemandTot.Text = "ALLEMAND: " + nbAllemand;
            pnlInfoNiveau.Controls.Add(nbAllemandTot);

            Label nbEspagnolTot = new Label();
            nbEspagnolTot.Location = new Point(200, 90);
            nbEspagnolTot.Size = new Size(100, 20);
            nbEspagnolTot.Text = "ESPAGNOL : " + nbEspagnol;
            pnlInfoNiveau.Controls.Add(nbEspagnolTot);

            Label nbAnglaisLv2Tot = new Label();
            nbAnglaisLv2Tot.Location = new Point(200, 120);
            nbAnglaisLv2Tot.Size = new Size(100, 20);
            nbAnglaisLv2Tot.Text = "ANGLAIS LV2 : " + nbAnglaisLv2;
            pnlInfoNiveau.Controls.Add(nbAnglaisLv2Tot);

            Label nbBilingueTot = new Label();
            nbBilingueTot.Location = new Point(200, 150);
            nbBilingueTot.Size = new Size(100, 20);
            nbBilingueTot.Text = "BILINGUE : " + nbBilingue;
            pnlInfoNiveau.Controls.Add(nbBilingueTot);

            Label nbSegpaTot = new Label();
            nbSegpaTot.Location = new Point(200, 180);
            nbSegpaTot.Size = new Size(100, 20);
            nbSegpaTot.Text = "SEGPA : " + nbSegpa;
            pnlInfoNiveau.Controls.Add(nbSegpaTot);

            Label nbUpe2aTot = new Label();
            nbUpe2aTot.Location = new Point(200, 210);
            nbUpe2aTot.Size = new Size(100, 20);
            nbUpe2aTot.Text = "UPE2A : " + nbUPE2A;
            pnlInfoNiveau.Controls.Add(nbUpe2aTot);

            Label nbUlisTot = new Label();
            nbUlisTot.Location = new Point(200, 240);
            nbUlisTot.Size = new Size(100, 20);
            nbUlisTot.Text = "ULIS : " + nbUlis;
            pnlInfoNiveau.Controls.Add(nbUlisTot);

            Label nbLatinTot = new Label();
            nbLatinTot.Location = new Point(200, 270);
            nbLatinTot.Size = new Size(100, 20);
            nbLatinTot.Text = "LATIN : " + nbLatin;
            pnlInfoNiveau.Controls.Add(nbLatinTot);

            Label nbCultureRegTot = new Label();
            nbCultureRegTot.Location = new Point(200, 300);
            nbCultureRegTot.Size = new Size(200, 20);
            nbCultureRegTot.Text = "Culture régionale : " + nbCultureReg;
            pnlInfoNiveau.Controls.Add(nbCultureRegTot);

            Button btnQuitter = new Button();
            btnQuitter.Text = "Quitter";
            btnQuitter.Location = new Point(50, 330); // x, y
            pnlInfoNiveau.Controls.Add(btnQuitter);
            btnQuitter.Click += new EventHandler(btnQuitterNiveau_Click);

            Button btnCourbe = new Button();
            btnCourbe.Text = "Courbe de Gauss";
            btnCourbe.Size = new Size(120, 20);
            btnCourbe.Location = new Point(200, 330);
            pnlInfoNiveau.Controls.Add(btnCourbe);
            btnCourbe.Click += new EventHandler((s, ev) => BtnCourbeNiveau_Click(unNiveau, ev));

            // Ajoute le Panel au formulaire principal
            layoutNiveaux.Controls.Add(pnlInfoNiveau);

            // Met à jour la référence au panel actuel
            currentPanelNiv = pnlInfoNiveau;
            layoutNiveaux.HorizontalScroll.Value = layoutNiveaux.HorizontalScroll.Maximum;

        }

        
        private void BtnCourbeNiveau_Click(object sender, EventArgs e)
        {
            Niveau uneNiveau = sender as Niveau;

            List<int> notesNiveau = new List<int>();
            var classes = uneNiveau.getLesClasse();
            Dictionary<string, List<int>> classesNotes = new Dictionary<string, List<int>>();

            foreach (Classe cls in classes)
            {
                List<int> notesClasse = new List<int>();

                foreach (Eleve elv in cls.getLesEleves())
                {
                    if (elv.rdbNiveau != null)
                    {
                        switch (elv.rdbNiveau.Name)
                        {
                            case "rdbA": notesClasse.Add(5); notesNiveau.Add(5); break;
                            case "rdbB": notesClasse.Add(4); notesNiveau.Add(4); break;
                            case "rdbC": notesClasse.Add(3); notesNiveau.Add(3); break;
                            case "rdbD": notesClasse.Add(2); notesNiveau.Add(2); break;
                            case "rdbE": notesClasse.Add(1); notesNiveau.Add(1); break;
                        }
                    }
                }

                if (notesClasse.Count > 0)
                {
                    classesNotes[cls.nomDeLaClasse] = notesClasse;
                }
            }

            if (notesNiveau.Count < 5)
            {
                MessageBox.Show("Veuillez donner une note à au moins 5 élèves pour le niveau.");
                return;
            }

            // Calcul des statistiques pour le niveau
            double moyenneNiveau = notesNiveau.Average();
            double varianceNiveau = notesNiveau.Sum(note => Math.Pow(note - moyenneNiveau, 2)) / notesNiveau.Count;
            double ecartTypeNiveau = Math.Sqrt(varianceNiveau);

            // Création du formulaire dynamique
            Form dynamicForm = new Form
            {
                Size = new Size(1500, 800),
                Text = "Courbe de Gauss - Niveau et Classes: " + uneNiveau.nomDuNiveau
            };

            // Initialisation du graphe principal
            var plotModel = new PlotModel { Title = "Courbe de Gauss - Niveau et Classes" };

            // Configuration de la légende pour une meilleure interactivité
            var legend = new OxyPlot.Legends.Legend
            {
                LegendTitle = "Légende",
                LegendPosition = LegendPosition.TopCenter,
                LegendPlacement = LegendPlacement.Outside,
                LegendOrientation = LegendOrientation.Horizontal,
                LegendBorderThickness = 1,
                LegendItemSpacing = 30,
                LegendPadding = 10,
                LegendMargin = 10,
            };
            plotModel.Legends.Add(legend);
            plotModel.IsLegendVisible = true;


            // Ajout des axes
            var xAxis = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Notes",
                Minimum = 0,
                Maximum = 7,
                MajorStep = 1,
                MinorStep = 0.5,
                AxisTickToLabelDistance = 10,
                LabelFormatter = x =>
                {
                    switch ((int)x)
                    {
                        case 5: return "A";
                        case 4: return "B";
                        case 3: return "C";
                        case 2: return "D";
                        case 1: return "E";
                        default: return string.Empty;
                    }
                }
            };

            var yAxis = new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Fréquence",
                Minimum = 0
            };

            plotModel.Axes.Add(xAxis);
            plotModel.Axes.Add(yAxis);

            // Liste étendue de couleurs
            var couleurs = new List<OxyColor>
            {
                OxyColors.Red,
                OxyColors.Blue,
                OxyColors.Green,
                OxyColors.Orange,
                OxyColors.Purple,
                OxyColors.Brown,
                OxyColors.Magenta,
                OxyColors.Yellow,
                OxyColors.Gray,
                OxyColors.LightGreen,
                OxyColors.LightBlue,
                OxyColors.Violet,
                OxyColors.Turquoise,
                OxyColors.Cyan,
                OxyColors.Maroon,
                OxyColors.Salmon,
                OxyColors.LimeGreen,
                OxyColors.Navy
            };

            int couleurIndex = 0;
            List<LineSeries> allSeries = new List<LineSeries>();

            // Ajout de la courbe pour le niveau
            var niveauLineSeries = new LineSeries
            {
                Title = "Niveau",
                Color = couleurs[couleurIndex++ % couleurs.Count]
            };

            for (double x = 0; x <= 7; x += 0.01)
            {
                double y = (1 / (ecartTypeNiveau * Math.Sqrt(2 * Math.PI))) *
                           Math.Exp(-Math.Pow(x - moyenneNiveau, 2) / (2 * Math.Pow(ecartTypeNiveau, 2)));
                niveauLineSeries.Points.Add(new DataPoint(x, y));
            }

            allSeries.Add(niveauLineSeries);
            plotModel.Series.Add(niveauLineSeries);

            // Ajout des courbes pour chaque classe
            foreach (var cls in classesNotes)
            {
                var notesClasse = cls.Value;
                double moyenneClasse = notesClasse.Average();
                double varianceClasse = notesClasse.Sum(note => Math.Pow(note - moyenneClasse, 2)) / notesClasse.Count;
                double ecartTypeClasse = Math.Sqrt(varianceClasse);

                var classeLineSeries = new LineSeries
                {
                    Title = "Classe: " + cls.Key,
                    Color = couleurs[couleurIndex++ % couleurs.Count]
                };

                for (double x = 0; x <= 7; x += 0.01)
                {
                    double y = (1 / (ecartTypeClasse * Math.Sqrt(2 * Math.PI))) *
                               Math.Exp(-Math.Pow(x - moyenneClasse, 2) / (2 * Math.Pow(ecartTypeClasse, 2)));
                    classeLineSeries.Points.Add(new DataPoint(x, y));
                }

                allSeries.Add(classeLineSeries);
                plotModel.Series.Add(classeLineSeries);
            }

            // Créer l'objet PlotView et y attacher les événements
            var plotView = new PlotView
            {
                Model = plotModel,
                Dock = DockStyle.Fill
            };

            // Ajouter le retard dans l'exécution des événements de souris (Move et Leave)
            SetupMouseEventHandlers(dynamicForm, plotView, allSeries);

            dynamicForm.Controls.Add(plotView);
            dynamicForm.Show();
        }

        private Timer _timer;

        private void SetupMouseEventHandlers(Form dynamicForm, PlotView plotView, List<LineSeries> allSeries)
        {
            // Créer un Timer qui attendra un court délai avant d'enregistrer les événements de souris
            _timer = new Timer();
            _timer.Interval = 200; // Attente de 200 millisecondes avant d'activer les événements
            _timer.Tick += (s, e) =>
            {
                // Enregistrer l'événement MouseMove après le délai
                plotView.MouseMove += (s2, mouseEventArgs) =>
                {
                    var screenPoint = new ScreenPoint(mouseEventArgs.X, mouseEventArgs.Y);
                    HandleMouseMoveUpdated(plotView, screenPoint, allSeries);
                };

                // Enregistrer l'événement MouseLeave après le délai
                plotView.MouseLeave += (s2, eventArgs) => HandleMouseLeaveUpdated(plotView, allSeries);

                // Arrêter le Timer après que les événements aient été enregistrés
                _timer.Stop();
            };
            _timer.Start();  // Démarrer le Timer
        }

        private void HandleMouseMoveUpdated(PlotView plotView, ScreenPoint screenPoint, List<LineSeries> allSeries)
        {
            // Vérifie si le modèle du graphique (PlotView.Model) existe. Si non, quitte la méthode immédiatement.
            if (plotView?.Model == null) return;

            // Convertit la coordonnée X de l'écran (screenPoint.X) en une coordonnée de données (dataPoint) 
            // en utilisant l'axe X par défaut du modèle.
            var dataPoint = plotView.Model.DefaultXAxis.InverseTransform(screenPoint.X);

            // Initialise une variable pour stocker la série actuellement survolée par la souris.
            LineSeries hoveredSeries = null;

            // Vérifie si le point de la souris se trouve dans la zone de la légende.
            if (IsPointInLegendArea(plotView.Model, screenPoint))
            {
                // Si oui, tente de trouver la série associée à la légende à cet emplacement.
                hoveredSeries = FindSeriesInLegend(plotView.Model, screenPoint, allSeries);
            }

            // Si aucune série n'a été trouvée dans la légende, cherche la série la plus proche de la position du curseur.
            if (hoveredSeries == null)
            {
                hoveredSeries = FindNearestSeries(dataPoint, screenPoint.Y, plotView.Model, allSeries);
            }

            // Parcourt toutes les séries pour ajuster leur opacité en fonction de la série survolée.
            foreach (var series in allSeries)
            {
                // Si aucune série n'est survolée ou si la série actuelle est celle survolée,
                // applique une opacité maximale (alpha = 1) pour mettre en valeur cette série.
                if (hoveredSeries == null || series == hoveredSeries)
                {
                    series.Color = ChangeAlpha(series.Color, 1);
                }
                // Sinon, réduit l'opacité des autres séries (alpha = 0.2) pour les rendre moins visibles.
                else
                {
                    series.Color = ChangeAlpha(series.Color, 0.2);
                }
            }

            // Redessine le graphique pour refléter les changements effectués sur les couleurs des séries.
            plotView.InvalidatePlot(true);
        }


        private bool IsPointInLegendArea(PlotModel model, ScreenPoint point)
        {
            var legend = model.Legends.FirstOrDefault();
            if (legend == null) return false;

            // Calculer la zone de la légende horizontale
            var plotArea = model.PlotArea;
            double itemWidth = 100;  // Largeur estimée pour chaque élément
            double legendWidth = (itemWidth + 30) * model.Series.Count;  // 30 pour l'espacement
            double legendHeight = 50;  // Hauteur fixe pour la légende horizontale

            var legendArea = new OxyRect(
                plotArea.Left + (plotArea.Width - legendWidth) / 2,  // Centré horizontalement
                plotArea.Top - legendHeight - 10,                    // Au-dessus du graphe
                legendWidth,
                legendHeight
            );

            return legendArea.Contains(point.X, point.Y);
        }

        private LineSeries FindSeriesInLegend(PlotModel model, ScreenPoint point, List<LineSeries> allSeries)
        {
            var legend = model.Legends.FirstOrDefault();
            if (legend == null) return null;

            // Calculer la position de départ de la légende horizontale
            var plotArea = model.PlotArea;
            double itemWidth = 100;  // Largeur de chaque entrée de légende
            double legendWidth = (itemWidth + 30) * model.Series.Count;
            double startX = plotArea.Left + (plotArea.Width - legendWidth) / 2;  // Centré

            // Calculer l'index de l'élément survolé horizontalement
            int index = (int)((point.X - startX) / (itemWidth + 30));  // 30 pour l'espacement

            if (index >= 0 && index < allSeries.Count)
            {
                return allSeries[index];
            }

            return null;
        }

        private LineSeries FindNearestSeries(double dataX, double screenY, PlotModel model, List<LineSeries> allSeries)
        {
            LineSeries nearestSeries = null;
            double minDistance = double.MaxValue;

            foreach (var series in allSeries)
            {
                // Trouver les deux points les plus proches sur l'axe X
                var points = series.Points.ToList();
                for (int i = 0; i < points.Count - 1; i++)
                {
                    var p1 = points[i];
                    var p2 = points[i + 1];

                    if (dataX >= p1.X && dataX <= p2.X)
                    {
                        // Interpolation linéaire pour trouver la valeur Y approximative
                        var ratio = (dataX - p1.X) / (p2.X - p1.X);
                        var interpolatedY = p1.Y + (ratio * (p2.Y - p1.Y));

                        // Convertir en coordonnées écran
                        var screenPoint = model.DefaultYAxis.Transform(interpolatedY);
                        var distance = Math.Abs(screenPoint - screenY);

                        if (distance < minDistance)
                        {
                            minDistance = distance;
                            nearestSeries = series;
                        }
                    }
                }
            }

            // Ne retourner la série que si elle est suffisamment proche
            return minDistance < 50 ? nearestSeries : null;
        }

        private void HandleMouseLeaveUpdated(PlotView plotView, List<LineSeries> allSeries)
        {
            if (plotView == null) return;

            // Réinitialiser les couleurs des séries
            foreach (var series in allSeries)
            {
                series.Color = ChangeAlpha(series.Color, 1);
            }

            plotView.InvalidatePlot(true);
        }

        private OxyColor ChangeAlpha(OxyColor color, double alpha)
        {
            return OxyColor.FromArgb((byte)(alpha * 255), color.R, color.G, color.B);
        }


        private async void btnImprimer_ClickAsync(object sender, EventArgs e)
        {
            barreDeChargement = new BarreDeChargement();
            barreDeChargement.Text = "Préparation à l'export en PDF";
            barreDeChargement.Show();

            await Task.Run(() => PrintExcelFile());

            barreDeChargement.Close();
        }

        private void PrintExcelFile()
        {
            Application excelApp = new Application();
            Workbook workbook = null;
            Worksheet tempWorksheet = null;

            try
            {
                workbook = excelApp.Workbooks.Open("informationsElevesModifieExcel.xlsx");
                Worksheet sourceWorksheet = (Worksheet)workbook.Worksheets[1];
                tempWorksheet = (Worksheet)workbook.Worksheets.Add();

                // Copier les en-têtes d'origine
                CopyHeader(sourceWorksheet, tempWorksheet);

                // Définir la plage de données à trier (exclure les en-têtes)
                Range dataRange = sourceWorksheet.Range["A2", sourceWorksheet.Cells[sourceWorksheet.UsedRange.Rows.Count,
                    sourceWorksheet.UsedRange.Columns.Count]];

                // Trier les données par colonne B puis par colonne E
                dataRange.Sort(dataRange.Columns[2], XlSortOrder.xlAscending, dataRange.Columns[5], Type.Missing,
                    XlSortOrder.xlAscending, Type.Missing, XlSortOrder.xlAscending, XlYesNoGuess.xlNo, Type.Missing,
                    Type.Missing, XlSortOrientation.xlSortColumns, XlSortMethod.xlPinYin, XlSortDataOption.xlSortNormal);

                // Initialiser la barre de chargement
                int totalRows = sourceWorksheet.UsedRange.Rows.Count - 1;
                int processedRows = 0;

                // Parcourir les lignes et détecter les changements dans la colonne B
                int startRow = 2; // Assumons que la première ligne est l'en-tête
                string previousValue = Convert.ToString(sourceWorksheet.Cells[startRow, 2].Value);
                int currentRow = startRow;
                int tempRow = 2; // Commencer à la deuxième ligne dans la feuille temporaire

                for (int i = startRow + 1; i <= sourceWorksheet.UsedRange.Rows.Count; i++)
                {
                    string currentValue = Convert.ToString(sourceWorksheet.Cells[i, 2].Value);
                    if (currentValue != previousValue || i == sourceWorksheet.UsedRange.Rows.Count)
                    {
                        if (i == sourceWorksheet.UsedRange.Rows.Count && currentValue == previousValue)
                        {
                            currentRow = i;
                        }

                        // Ignorer les lignes dont la colonne B commence par "2"
                        if (!previousValue.StartsWith("2"))
                        {
                            // Changer la couleur de fond des lignes où la colonne P n'est pas vide
                            for (int row = startRow; row <= currentRow; row++)
                            {
                                if (!string.IsNullOrEmpty(Convert.ToString(sourceWorksheet.Cells[row, 16].Value)))
                                {
                                    Range range = sourceWorksheet.Rows[row];
                                    range.Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                                }
                            }

                            // Copier les colonnes spécifiées vers la feuille temporaire
                            CopySelectedColumns(sourceWorksheet, tempWorksheet, startRow, currentRow, tempRow);

                            // Insérer un saut de page
                            if (i != sourceWorksheet.UsedRange.Rows.Count)
                            {
                                tempWorksheet.HPageBreaks.Add((Range)tempWorksheet.Cells[tempRow + (currentRow - startRow + 1), 1]);
                            }

                            tempRow += (currentRow - startRow + 1); // Passer à la prochaine ligne après le groupe copié
                        }

                        startRow = i;
                        previousValue = currentValue;
                    }
                    currentRow = i;

                    // Mettre à jour la barre de chargement
                    processedRows++;
                    int progressPercentage = (int)((double)processedRows / totalRows * 100);
                    UpdateProgressBar(progressPercentage);
                }

                // Ajuster les marges et l'orientation de la page
                tempWorksheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;
                tempWorksheet.PageSetup.LeftMargin = excelApp.InchesToPoints(0.25);
                tempWorksheet.PageSetup.RightMargin = excelApp.InchesToPoints(0.25);
                tempWorksheet.PageSetup.TopMargin = excelApp.InchesToPoints(0.25);
                tempWorksheet.PageSetup.BottomMargin = excelApp.InchesToPoints(0.25);
                tempWorksheet.Columns.AutoFit();
                tempWorksheet.PageSetup.FitToPagesWide = 1;
                tempWorksheet.PageSetup.FitToPagesTall = false;

                // Définir la ligne d'en-tête pour qu'elle soit répétée sur chaque page
                tempWorksheet.PageSetup.PrintTitleRows = "$1:$1";

                // Imprimer la feuille temporaire
                //tempWorksheet.PrintOut();
                PrintToPDF(tempWorksheet);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue lors de l'exportation en PDF.\n" +
                    "S'il vous manque le fichier informationsElevesModifieExcel.xlsx dans Documents," +
                    "vous pouvez le créer avec le bouton Enregistrer: " + ex.Message);
            }
            finally
            {
                ReleaseComObject(tempWorksheet);
                if (workbook != null)
                {
                    workbook.Close(false);
                    ReleaseComObject(workbook);
                }

                excelApp.Quit();
                ReleaseComObject(excelApp);
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private void PrintToPDF(Worksheet worksheet)
        {
            try
            {
                worksheet.PrintOut(ActivePrinter: "Microsoft Print to PDF");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue lors de l'impression en PDF: " + ex.Message);
            }
        }

        private void CopySelectedColumns(Worksheet source, Worksheet destination, int startRow, int endRow, int destinationStartRow)
        {
            string[] columns = { "B", "E", "F", "G", "H", "J", "K", "L", "M" };
            int destinationColumnIndex = 1;

            foreach (string column in columns)
            {
                Range sourceRange = source.Range[$"{column}{startRow}:{column}{endRow}"];
                Range destinationRange = destination.Cells[destinationStartRow, destinationColumnIndex];

                sourceRange.Copy(destinationRange);
                destinationColumnIndex++;
            }
        }

        private void CopyHeader(Worksheet source, Worksheet destination)
        {
            string[] columns = { "B", "E", "F", "G", "H", "J", "K", "L", "M" };
            int destinationColumnIndex = 1;

            foreach (string column in columns)
            {
                Range sourceRange = source.Range[$"{column}1"];
                Range destinationRange = destination.Cells[1, destinationColumnIndex];

                sourceRange.Copy(destinationRange);
                destinationColumnIndex++;
            }
        }

        private void UpdateProgressBar(int progress)
        {
            if (barreDeChargement.InvokeRequired)
            {
                barreDeChargement.Invoke(new Action<int>(UpdateProgressBar), new object[] { progress });
            }
            else
            {
                barreDeChargement.UpdateProgress(progress);
            }
        }

        private void ReleaseComObject(object obj)
        {
            if (obj != null && Marshal.IsComObject(obj))
            {
                Marshal.ReleaseComObject(obj);
            }
        }

        private void ChargerDernierEnregistre(string path)
        {
            try
            {
                // Définit le chemin du fichier XML global
                Global.pathXML = path;
                Global.options.Clear();

                // Crée une liste pour stocker les niveaux
                List<Niveau> listNiveau = new List<Niveau>();
                // Charge le document XML
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Global.pathXML);

                // Sélectionne tous les noeuds de niveau dans le XML
                XmlNodeList niveauNodes = xmlDoc.SelectNodes("//College/Niveau");

                // Parcourt chaque noeud de niveau
                foreach (XmlNode niveauNode in niveauNodes)
                {
                    // Obtient le nom du niveau et crée un objet Niveau
                    string nomNiveau = niveauNode.Attributes["nomNiveau"].Value;
                    Niveau niveau = new Niveau(nomNiveau);

                    // Crée une liste pour les classes
                    List<Classe> listClasse = new List<Classe>();

                    // Sélectionne tous les noeuds de classe dans le noeud de niveau actuel
                    XmlNodeList classeNodes = niveauNode.SelectNodes("Classe");
                    foreach (XmlNode classeNode in classeNodes)
                    {
                        // Obtient le nom de la classe et du professeur principal
                        string nomClasse = classeNode.Attributes["nomClasse"].Value;
                        string nomProf = classeNode.Attributes["nomProfPrinc"].Value;
                        // Ajoute le nom du professeur principal à une liste globale s'il n'est pas vide
                        if (nomProf != "")
                        {
                            Global.listeNomEtPrenomProf.Add(nomProf);
                        }
                        // Crée un objet Classe
                        Classe classe = new Classe(nomClasse, nomProf);

                        // Crée une liste pour les élèves
                        List<Eleve> listEleve = new List<Eleve>();

                        // Sélectionne tous les noeuds d'élève dans le noeud de classe actuel
                        XmlNodeList eleveNodes = classeNode.SelectNodes("Eleve");
                        foreach (XmlNode eleveNode in eleveNodes)
                        {
                            // Obtient les informations de l'élève
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

                            // Traite la date d'entrée
                            int annee = Int32.Parse(eleveNode["dateEntree"].InnerText.Substring(6));
                            int mois = Int32.Parse(eleveNode["dateEntree"].InnerText.Substring(3, 2));
                            int jour = Int32.Parse(eleveNode["dateEntree"].InnerText.Substring(0, 2));
                            DateTime dateEntree = new DateTime(annee, mois, jour);

                            // Obtient la note de l'élève
                            string note = eleveNode["note"].InnerText;
                            // Crée un objet Eleve
                            Eleve eleve = new Eleve(numEleve, nomEleve, prenomEleve, naissanceEleve, sexeEleve, mefEleve, redouble, nomClasse, LV1Eleve, option1Eleve, option2Eleve, LV1EleveOption, option1EleveOption, option2EleveOption, dateEntree)
                            {
                                rdbNiveau = new RadioButton(),
                                ine = ineEleve,
                                anciennesClasses = lesAnciennesClasse,
                                anciensNiveaux = lesAnciennesNotes
                            };
                            //eleve.nonInscrit = "";
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

                            // Configure le nom du RadioButton pour l'élève
                            eleve.rdbNiveau.Name = "rdb" + note;
                            // Ajoute l'élève à la liste des élèves de la classe
                            listEleve.Add(eleve);
                            eleve.classeEleve = nomClasse;
                            // Incrémente le compteur global des élèves
                            if (nomClasse.Substring(0, 1) != "2")
                                Global.nbEleves++;
                            // Ajoute l'élève à la liste globale des élèves valides
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

                                if (testListeOption.Length > 3)
                                {
                                    if (!Global.lesOptions.Any(s => s.Contains(testListeOption.Substring(0, 3))))
                                    {
                                        Global.lesOptions.Add(testListeOption);
                                        Global.options.Add(new Options(testListeOption));
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
                            // Ajoute les options de l'élève aux listes globales correspondantes
                            Global.listeLV1Eleve.Add(LV1Eleve);
                            Global.listeOption1Eleve.Add(option1Eleve);
                            Global.listeOption2Eleve.Add(option2Eleve);
                        }
                        // Assigne la liste des élèves à la classe
                        classe.setListEleve(listEleve);
                        // Ajoute la classe à la liste des classes
                        listClasse.Add(classe);
                    }
                    // Assigne la liste des classes au niveau
                    niveau.setListClasse(listClasse);
                    // Ajoute le niveau à la liste des niveaux
                    listNiveau.Add(niveau);
                }

                // Assigne la liste des niveaux à la variable globale correspondante
                Global.lesNiveaux = listNiveau;

                // Affiche un message de succès à l'utilisateur
                MessageBox.Show("Les données ont bien été importées avec succès ! \n Cliquez sur le bouton ACTUALISER.");
                //InterfacePr.pnlBarre_Paint();
            }
            catch (Exception error)
            {
                // Affiche un message d'erreur si une exception se produit
                MessageBox.Show(error.ToString());
            }
        }


        private void btnImages_Click(object sender, EventArgs e)
        {
            ImporterImages impImg = new ImporterImages();
            impImg.Show();
        }

        private void btnImpression_Click(object sender, EventArgs e)
        {
            try
            {
                ImpressionFiches impression = new ImpressionFiches();
                impression.ApercuImpressionAvecChoix(); // Utiliser cette méthode
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'impression : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}