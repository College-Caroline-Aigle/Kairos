
namespace FichesT
{
    partial class InterfacePrinc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InterfacePrinc));
            this.FichierTimer = new System.Windows.Forms.Timer(this.components);
            this.NiveauxTimer = new System.Windows.Forms.Timer(this.components);
            this.EleveTimer = new System.Windows.Forms.Timer(this.components);
            this.ClasseTimer = new System.Windows.Forms.Timer(this.components);
            this.panelMenu = new System.Windows.Forms.Panel();
            this.Laylow = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlContientFichiers = new System.Windows.Forms.Panel();
            this.btnOpenBase = new System.Windows.Forms.Button();
            this.btnFiles = new System.Windows.Forms.Button();
            this.pnlNiveaux = new System.Windows.Forms.Panel();
            this.btn3ème = new System.Windows.Forms.Button();
            this.btn4ème = new System.Windows.Forms.Button();
            this.btn5ème = new System.Windows.Forms.Button();
            this.btn6ème = new System.Windows.Forms.Button();
            this.btnNiveaux = new System.Windows.Forms.Button();
            this.pnlEleves = new System.Windows.Forms.Panel();
            this.btnSuppEleve = new System.Windows.Forms.Button();
            this.btnDeplaClasse = new System.Windows.Forms.Button();
            this.btnAjoutFicheEleve = new System.Windows.Forms.Button();
            this.Btnélèves = new System.Windows.Forms.Button();
            this.pnlClasse = new System.Windows.Forms.Panel();
            this.btnAjoutProf = new System.Windows.Forms.Button();
            this.btnRenomClasse = new System.Windows.Forms.Button();
            this.btnClasse = new System.Windows.Forms.Button();
            this.pnlCompleteGauche = new System.Windows.Forms.Panel();
            this.btnImages = new System.Windows.Forms.Button();
            this.pnlNouvelleAnnee = new System.Windows.Forms.Panel();
            this.btnNouvelleAnnee = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.btnActualiser = new System.Windows.Forms.Button();
            this.btnImprimer = new System.Windows.Forms.Button();
            this.btnOuvertureXmlGenererParAppli = new System.Windows.Forms.Button();
            this.lblTitleNbEleves = new System.Windows.Forms.Label();
            this.pnlBarre = new System.Windows.Forms.Panel();
            this.btnImpression = new System.Windows.Forms.Button();
            this.btnLegende = new System.Windows.Forms.Button();
            this.btnStatsNiv = new System.Windows.Forms.Button();
            this.lblNbEleves = new System.Windows.Forms.Label();
            this.btnExtraireDonneesEleves = new System.Windows.Forms.Button();
            this.btnSupAffichage = new System.Windows.Forms.Button();
            this.btnResetTout = new System.Windows.Forms.Button();
            this.layoutClasses6e = new System.Windows.Forms.FlowLayoutPanel();
            this.layoutNiveaux = new System.Windows.Forms.FlowLayoutPanel();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.panelMenu.SuspendLayout();
            this.Laylow.SuspendLayout();
            this.pnlContientFichiers.SuspendLayout();
            this.pnlNiveaux.SuspendLayout();
            this.pnlEleves.SuspendLayout();
            this.pnlClasse.SuspendLayout();
            this.pnlCompleteGauche.SuspendLayout();
            this.pnlNouvelleAnnee.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.pnlBarre.SuspendLayout();
            this.layoutNiveaux.SuspendLayout();
            this.SuspendLayout();
            // 
            // FichierTimer
            // 
            this.FichierTimer.Interval = 10;
            this.FichierTimer.Tick += new System.EventHandler(this.FichierTimer_Tick);
            // 
            // NiveauxTimer
            // 
            this.NiveauxTimer.Interval = 10;
            this.NiveauxTimer.Tick += new System.EventHandler(this.NiveauxTimer_Tick);
            // 
            // EleveTimer
            // 
            this.EleveTimer.Interval = 10;
            this.EleveTimer.Tick += new System.EventHandler(this.EleveTimer_Tick);
            // 
            // ClasseTimer
            // 
            this.ClasseTimer.Interval = 10;
            this.ClasseTimer.Tick += new System.EventHandler(this.ClasseTimer_Tick);
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(95)))), ((int)(((byte)(147)))));
            this.panelMenu.Controls.Add(this.Laylow);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(225, 1175);
            this.panelMenu.TabIndex = 0;
            // 
            // Laylow
            // 
            this.Laylow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(129)))), ((int)(((byte)(180)))));
            this.Laylow.Controls.Add(this.pnlContientFichiers);
            this.Laylow.Controls.Add(this.pnlNiveaux);
            this.Laylow.Controls.Add(this.pnlEleves);
            this.Laylow.Controls.Add(this.pnlClasse);
            this.Laylow.Controls.Add(this.pnlCompleteGauche);
            this.Laylow.Dock = System.Windows.Forms.DockStyle.Left;
            this.Laylow.Location = new System.Drawing.Point(0, 97);
            this.Laylow.Margin = new System.Windows.Forms.Padding(0);
            this.Laylow.Name = "Laylow";
            this.Laylow.Size = new System.Drawing.Size(225, 1078);
            this.Laylow.TabIndex = 4;
            // 
            // pnlContientFichiers
            // 
            this.pnlContientFichiers.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.pnlContientFichiers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(95)))), ((int)(((byte)(147)))));
            this.pnlContientFichiers.Controls.Add(this.btnOpenBase);
            this.pnlContientFichiers.Controls.Add(this.btnFiles);
            this.pnlContientFichiers.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlContientFichiers.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.pnlContientFichiers.Location = new System.Drawing.Point(0, 0);
            this.pnlContientFichiers.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.pnlContientFichiers.MaximumSize = new System.Drawing.Size(225, 111);
            this.pnlContientFichiers.MinimumSize = new System.Drawing.Size(225, 63);
            this.pnlContientFichiers.Name = "pnlContientFichiers";
            this.pnlContientFichiers.Size = new System.Drawing.Size(225, 63);
            this.pnlContientFichiers.TabIndex = 2;
            // 
            // btnOpenBase
            // 
            this.btnOpenBase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(87)))), ((int)(((byte)(136)))));
            this.btnOpenBase.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOpenBase.FlatAppearance.BorderSize = 0;
            this.btnOpenBase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenBase.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenBase.ForeColor = System.Drawing.Color.White;
            this.btnOpenBase.Location = new System.Drawing.Point(0, 63);
            this.btnOpenBase.Margin = new System.Windows.Forms.Padding(0);
            this.btnOpenBase.Name = "btnOpenBase";
            this.btnOpenBase.Size = new System.Drawing.Size(225, 48);
            this.btnOpenBase.TabIndex = 1;
            this.btnOpenBase.Text = "Ouvrir une base élève";
            this.btnOpenBase.UseVisualStyleBackColor = false;
            this.btnOpenBase.Click += new System.EventHandler(this.btnOpenBase_Click);
            // 
            // btnFiles
            // 
            this.btnFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(95)))), ((int)(((byte)(147)))));
            this.btnFiles.CausesValidation = false;
            this.btnFiles.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFiles.FlatAppearance.BorderSize = 0;
            this.btnFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiles.Font = new System.Drawing.Font("Segoe MDL2 Assets", 15.4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiles.ForeColor = System.Drawing.Color.White;
            this.btnFiles.Location = new System.Drawing.Point(0, 0);
            this.btnFiles.Margin = new System.Windows.Forms.Padding(0);
            this.btnFiles.Name = "btnFiles";
            this.btnFiles.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.btnFiles.Size = new System.Drawing.Size(225, 63);
            this.btnFiles.TabIndex = 0;
            this.btnFiles.Text = "Fichiers";
            this.btnFiles.UseVisualStyleBackColor = false;
            this.btnFiles.Click += new System.EventHandler(this.btnFiles_Click);
            // 
            // pnlNiveaux
            // 
            this.pnlNiveaux.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(95)))), ((int)(((byte)(147)))));
            this.pnlNiveaux.Controls.Add(this.btn3ème);
            this.pnlNiveaux.Controls.Add(this.btn4ème);
            this.pnlNiveaux.Controls.Add(this.btn5ème);
            this.pnlNiveaux.Controls.Add(this.btn6ème);
            this.pnlNiveaux.Controls.Add(this.btnNiveaux);
            this.pnlNiveaux.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNiveaux.Location = new System.Drawing.Point(0, 64);
            this.pnlNiveaux.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.pnlNiveaux.MaximumSize = new System.Drawing.Size(225, 256);
            this.pnlNiveaux.MinimumSize = new System.Drawing.Size(225, 63);
            this.pnlNiveaux.Name = "pnlNiveaux";
            this.pnlNiveaux.Size = new System.Drawing.Size(225, 63);
            this.pnlNiveaux.TabIndex = 4;
            // 
            // btn3ème
            // 
            this.btn3ème.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(87)))), ((int)(((byte)(136)))));
            this.btn3ème.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn3ème.FlatAppearance.BorderSize = 0;
            this.btn3ème.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn3ème.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn3ème.ForeColor = System.Drawing.Color.White;
            this.btn3ème.Location = new System.Drawing.Point(0, 207);
            this.btn3ème.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn3ème.Name = "btn3ème";
            this.btn3ème.Size = new System.Drawing.Size(225, 48);
            this.btn3ème.TabIndex = 1;
            this.btn3ème.Text = "3ème";
            this.btn3ème.UseVisualStyleBackColor = false;
            this.btn3ème.Click += new System.EventHandler(this.btn3ème_Click);
            // 
            // btn4ème
            // 
            this.btn4ème.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(87)))), ((int)(((byte)(136)))));
            this.btn4ème.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn4ème.FlatAppearance.BorderSize = 0;
            this.btn4ème.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn4ème.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn4ème.ForeColor = System.Drawing.Color.White;
            this.btn4ème.Location = new System.Drawing.Point(0, 159);
            this.btn4ème.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn4ème.Name = "btn4ème";
            this.btn4ème.Size = new System.Drawing.Size(225, 48);
            this.btn4ème.TabIndex = 1;
            this.btn4ème.Text = "4ème";
            this.btn4ème.UseVisualStyleBackColor = false;
            this.btn4ème.Click += new System.EventHandler(this.btn4ème_Click);
            // 
            // btn5ème
            // 
            this.btn5ème.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(87)))), ((int)(((byte)(136)))));
            this.btn5ème.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn5ème.FlatAppearance.BorderSize = 0;
            this.btn5ème.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn5ème.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn5ème.ForeColor = System.Drawing.Color.White;
            this.btn5ème.Location = new System.Drawing.Point(0, 111);
            this.btn5ème.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn5ème.Name = "btn5ème";
            this.btn5ème.Size = new System.Drawing.Size(225, 48);
            this.btn5ème.TabIndex = 1;
            this.btn5ème.Text = "5ème";
            this.btn5ème.UseVisualStyleBackColor = false;
            this.btn5ème.Click += new System.EventHandler(this.btn5ème_Click);
            // 
            // btn6ème
            // 
            this.btn6ème.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(87)))), ((int)(((byte)(136)))));
            this.btn6ème.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn6ème.FlatAppearance.BorderSize = 0;
            this.btn6ème.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn6ème.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn6ème.ForeColor = System.Drawing.Color.White;
            this.btn6ème.Location = new System.Drawing.Point(0, 63);
            this.btn6ème.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn6ème.Name = "btn6ème";
            this.btn6ème.Size = new System.Drawing.Size(225, 48);
            this.btn6ème.TabIndex = 1;
            this.btn6ème.Text = "6ème";
            this.btn6ème.UseVisualStyleBackColor = false;
            this.btn6ème.Click += new System.EventHandler(this.btn6ème_Click);
            // 
            // btnNiveaux
            // 
            this.btnNiveaux.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(95)))), ((int)(((byte)(147)))));
            this.btnNiveaux.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNiveaux.FlatAppearance.BorderSize = 0;
            this.btnNiveaux.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNiveaux.Font = new System.Drawing.Font("Segoe MDL2 Assets", 15.4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNiveaux.ForeColor = System.Drawing.Color.White;
            this.btnNiveaux.Location = new System.Drawing.Point(0, 0);
            this.btnNiveaux.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNiveaux.Name = "btnNiveaux";
            this.btnNiveaux.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.btnNiveaux.Size = new System.Drawing.Size(225, 63);
            this.btnNiveaux.TabIndex = 0;
            this.btnNiveaux.Text = "Niveaux";
            this.btnNiveaux.UseVisualStyleBackColor = false;
            this.btnNiveaux.Click += new System.EventHandler(this.btnNiveaux_Click);
            // 
            // pnlEleves
            // 
            this.pnlEleves.Controls.Add(this.btnSuppEleve);
            this.pnlEleves.Controls.Add(this.btnDeplaClasse);
            this.pnlEleves.Controls.Add(this.btnAjoutFicheEleve);
            this.pnlEleves.Controls.Add(this.Btnélèves);
            this.pnlEleves.Location = new System.Drawing.Point(0, 128);
            this.pnlEleves.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.pnlEleves.MaximumSize = new System.Drawing.Size(225, 207);
            this.pnlEleves.MinimumSize = new System.Drawing.Size(225, 63);
            this.pnlEleves.Name = "pnlEleves";
            this.pnlEleves.Size = new System.Drawing.Size(225, 63);
            this.pnlEleves.TabIndex = 5;
            // 
            // btnSuppEleve
            // 
            this.btnSuppEleve.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(87)))), ((int)(((byte)(136)))));
            this.btnSuppEleve.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSuppEleve.FlatAppearance.BorderSize = 0;
            this.btnSuppEleve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuppEleve.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuppEleve.ForeColor = System.Drawing.Color.White;
            this.btnSuppEleve.Location = new System.Drawing.Point(0, 159);
            this.btnSuppEleve.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSuppEleve.Name = "btnSuppEleve";
            this.btnSuppEleve.Size = new System.Drawing.Size(225, 48);
            this.btnSuppEleve.TabIndex = 4;
            this.btnSuppEleve.Text = "Supprimer fiche élève";
            this.btnSuppEleve.UseVisualStyleBackColor = false;
            this.btnSuppEleve.Click += new System.EventHandler(this.btnSuppEleve_Click);
            // 
            // btnDeplaClasse
            // 
            this.btnDeplaClasse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(87)))), ((int)(((byte)(136)))));
            this.btnDeplaClasse.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDeplaClasse.FlatAppearance.BorderSize = 0;
            this.btnDeplaClasse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeplaClasse.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeplaClasse.ForeColor = System.Drawing.Color.White;
            this.btnDeplaClasse.Location = new System.Drawing.Point(0, 111);
            this.btnDeplaClasse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeplaClasse.Name = "btnDeplaClasse";
            this.btnDeplaClasse.Size = new System.Drawing.Size(225, 48);
            this.btnDeplaClasse.TabIndex = 3;
            this.btnDeplaClasse.Text = "Déplacer fiche élève";
            this.btnDeplaClasse.UseVisualStyleBackColor = false;
            this.btnDeplaClasse.Click += new System.EventHandler(this.btnDeplaClasse_Click);
            // 
            // btnAjoutFicheEleve
            // 
            this.btnAjoutFicheEleve.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(87)))), ((int)(((byte)(136)))));
            this.btnAjoutFicheEleve.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAjoutFicheEleve.FlatAppearance.BorderSize = 0;
            this.btnAjoutFicheEleve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjoutFicheEleve.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjoutFicheEleve.ForeColor = System.Drawing.Color.White;
            this.btnAjoutFicheEleve.Location = new System.Drawing.Point(0, 63);
            this.btnAjoutFicheEleve.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAjoutFicheEleve.Name = "btnAjoutFicheEleve";
            this.btnAjoutFicheEleve.Size = new System.Drawing.Size(225, 48);
            this.btnAjoutFicheEleve.TabIndex = 2;
            this.btnAjoutFicheEleve.Text = "Ajouter une fiche élève";
            this.btnAjoutFicheEleve.UseVisualStyleBackColor = false;
            this.btnAjoutFicheEleve.Click += new System.EventHandler(this.btnAjoutFicheEleve_Click);
            // 
            // Btnélèves
            // 
            this.Btnélèves.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(95)))), ((int)(((byte)(147)))));
            this.Btnélèves.Dock = System.Windows.Forms.DockStyle.Top;
            this.Btnélèves.FlatAppearance.BorderSize = 0;
            this.Btnélèves.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btnélèves.Font = new System.Drawing.Font("Segoe MDL2 Assets", 15.4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btnélèves.ForeColor = System.Drawing.Color.White;
            this.Btnélèves.Location = new System.Drawing.Point(0, 0);
            this.Btnélèves.Margin = new System.Windows.Forms.Padding(0);
            this.Btnélèves.Name = "Btnélèves";
            this.Btnélèves.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.Btnélèves.Size = new System.Drawing.Size(225, 63);
            this.Btnélèves.TabIndex = 0;
            this.Btnélèves.Text = "Élèves";
            this.Btnélèves.UseVisualStyleBackColor = false;
            this.Btnélèves.Click += new System.EventHandler(this.Btnélèves_Click);
            // 
            // pnlClasse
            // 
            this.pnlClasse.Controls.Add(this.btnAjoutProf);
            this.pnlClasse.Controls.Add(this.btnRenomClasse);
            this.pnlClasse.Controls.Add(this.btnClasse);
            this.pnlClasse.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlClasse.Location = new System.Drawing.Point(0, 192);
            this.pnlClasse.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.pnlClasse.MaximumSize = new System.Drawing.Size(225, 159);
            this.pnlClasse.MinimumSize = new System.Drawing.Size(225, 63);
            this.pnlClasse.Name = "pnlClasse";
            this.pnlClasse.Size = new System.Drawing.Size(225, 63);
            this.pnlClasse.TabIndex = 6;
            // 
            // btnAjoutProf
            // 
            this.btnAjoutProf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(87)))), ((int)(((byte)(136)))));
            this.btnAjoutProf.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAjoutProf.FlatAppearance.BorderSize = 0;
            this.btnAjoutProf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjoutProf.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjoutProf.ForeColor = System.Drawing.Color.White;
            this.btnAjoutProf.Location = new System.Drawing.Point(0, 111);
            this.btnAjoutProf.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.btnAjoutProf.Name = "btnAjoutProf";
            this.btnAjoutProf.Size = new System.Drawing.Size(225, 48);
            this.btnAjoutProf.TabIndex = 5;
            this.btnAjoutProf.Text = "Ajouter des professeurs";
            this.btnAjoutProf.UseVisualStyleBackColor = false;
            this.btnAjoutProf.Click += new System.EventHandler(this.btnAjoutProf_Click);
            // 
            // btnRenomClasse
            // 
            this.btnRenomClasse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(87)))), ((int)(((byte)(136)))));
            this.btnRenomClasse.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRenomClasse.FlatAppearance.BorderSize = 0;
            this.btnRenomClasse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRenomClasse.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRenomClasse.ForeColor = System.Drawing.Color.White;
            this.btnRenomClasse.Location = new System.Drawing.Point(0, 63);
            this.btnRenomClasse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRenomClasse.Name = "btnRenomClasse";
            this.btnRenomClasse.Size = new System.Drawing.Size(225, 48);
            this.btnRenomClasse.TabIndex = 3;
            this.btnRenomClasse.Text = "Renommer une Classe";
            this.btnRenomClasse.UseVisualStyleBackColor = false;
            this.btnRenomClasse.Click += new System.EventHandler(this.btnRenomClasse_Click);
            // 
            // btnClasse
            // 
            this.btnClasse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(95)))), ((int)(((byte)(147)))));
            this.btnClasse.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClasse.FlatAppearance.BorderSize = 0;
            this.btnClasse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClasse.Font = new System.Drawing.Font("Segoe MDL2 Assets", 15.4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClasse.ForeColor = System.Drawing.Color.White;
            this.btnClasse.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClasse.Location = new System.Drawing.Point(0, 0);
            this.btnClasse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClasse.Name = "btnClasse";
            this.btnClasse.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.btnClasse.Size = new System.Drawing.Size(225, 63);
            this.btnClasse.TabIndex = 0;
            this.btnClasse.Text = "Classes";
            this.btnClasse.UseVisualStyleBackColor = false;
            this.btnClasse.Click += new System.EventHandler(this.btnClasse_Click);
            // 
            // pnlCompleteGauche
            // 
            this.pnlCompleteGauche.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(95)))), ((int)(((byte)(147)))));
            this.pnlCompleteGauche.Controls.Add(this.btnImages);
            this.pnlCompleteGauche.Controls.Add(this.pnlNouvelleAnnee);
            this.pnlCompleteGauche.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCompleteGauche.Location = new System.Drawing.Point(0, 256);
            this.pnlCompleteGauche.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCompleteGauche.Name = "pnlCompleteGauche";
            this.pnlCompleteGauche.Size = new System.Drawing.Size(225, 2000);
            this.pnlCompleteGauche.TabIndex = 7;
            // 
            // btnImages
            // 
            this.btnImages.Location = new System.Drawing.Point(29, 464);
            this.btnImages.Margin = new System.Windows.Forms.Padding(4);
            this.btnImages.Name = "btnImages";
            this.btnImages.Size = new System.Drawing.Size(155, 28);
            this.btnImages.TabIndex = 336;
            this.btnImages.Text = "Importer images";
            this.btnImages.UseVisualStyleBackColor = true;
            this.btnImages.Visible = false;
            this.btnImages.Click += new System.EventHandler(this.btnImages_Click);
            // 
            // pnlNouvelleAnnee
            // 
            this.pnlNouvelleAnnee.Controls.Add(this.btnNouvelleAnnee);
            this.pnlNouvelleAnnee.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNouvelleAnnee.Location = new System.Drawing.Point(0, 0);
            this.pnlNouvelleAnnee.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.pnlNouvelleAnnee.MaximumSize = new System.Drawing.Size(225, 159);
            this.pnlNouvelleAnnee.MinimumSize = new System.Drawing.Size(225, 63);
            this.pnlNouvelleAnnee.Name = "pnlNouvelleAnnee";
            this.pnlNouvelleAnnee.Size = new System.Drawing.Size(225, 63);
            this.pnlNouvelleAnnee.TabIndex = 7;
            // 
            // btnNouvelleAnnee
            // 
            this.btnNouvelleAnnee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(95)))), ((int)(((byte)(147)))));
            this.btnNouvelleAnnee.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNouvelleAnnee.FlatAppearance.BorderSize = 0;
            this.btnNouvelleAnnee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNouvelleAnnee.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNouvelleAnnee.ForeColor = System.Drawing.Color.White;
            this.btnNouvelleAnnee.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNouvelleAnnee.Location = new System.Drawing.Point(0, 0);
            this.btnNouvelleAnnee.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNouvelleAnnee.Name = "btnNouvelleAnnee";
            this.btnNouvelleAnnee.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.btnNouvelleAnnee.Size = new System.Drawing.Size(225, 62);
            this.btnNouvelleAnnee.TabIndex = 0;
            this.btnNouvelleAnnee.Text = "Nouvelle Année";
            this.btnNouvelleAnnee.UseVisualStyleBackColor = false;
            this.btnNouvelleAnnee.Click += new System.EventHandler(this.btnNouvelleAnnee_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(69)))), ((int)(((byte)(107)))));
            this.panelLogo.Controls.Add(this.btnActualiser);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(225, 97);
            this.panelLogo.TabIndex = 1;
            // 
            // btnActualiser
            // 
            this.btnActualiser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnActualiser.Location = new System.Drawing.Point(29, 18);
            this.btnActualiser.Margin = new System.Windows.Forms.Padding(4);
            this.btnActualiser.Name = "btnActualiser";
            this.btnActualiser.Size = new System.Drawing.Size(173, 63);
            this.btnActualiser.TabIndex = 333;
            this.btnActualiser.Text = "ACTUALISER";
            this.btnActualiser.UseVisualStyleBackColor = false;
            this.btnActualiser.Click += new System.EventHandler(this.BtnActualiser_Click);
            // 
            // btnImprimer
            // 
            this.btnImprimer.Location = new System.Drawing.Point(260, 54);
            this.btnImprimer.Margin = new System.Windows.Forms.Padding(4);
            this.btnImprimer.Name = "btnImprimer";
            this.btnImprimer.Size = new System.Drawing.Size(160, 26);
            this.btnImprimer.TabIndex = 8;
            this.btnImprimer.Text = "Exporter en PDF";
            this.btnImprimer.UseVisualStyleBackColor = true;
            this.btnImprimer.Click += new System.EventHandler(this.btnImprimer_ClickAsync);
            // 
            // btnOuvertureXmlGenererParAppli
            // 
            this.btnOuvertureXmlGenererParAppli.Location = new System.Drawing.Point(345, 21);
            this.btnOuvertureXmlGenererParAppli.Margin = new System.Windows.Forms.Padding(4);
            this.btnOuvertureXmlGenererParAppli.Name = "btnOuvertureXmlGenererParAppli";
            this.btnOuvertureXmlGenererParAppli.Size = new System.Drawing.Size(101, 26);
            this.btnOuvertureXmlGenererParAppli.TabIndex = 1;
            this.btnOuvertureXmlGenererParAppli.Text = "Xml Appli";
            this.btnOuvertureXmlGenererParAppli.UseVisualStyleBackColor = true;
            this.btnOuvertureXmlGenererParAppli.Click += new System.EventHandler(this.btnOuvertureXmlGenererParAppli_Click);
            // 
            // lblTitleNbEleves
            // 
            this.lblTitleNbEleves.AutoSize = true;
            this.lblTitleNbEleves.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleNbEleves.ForeColor = System.Drawing.Color.White;
            this.lblTitleNbEleves.Location = new System.Drawing.Point(39, 25);
            this.lblTitleNbEleves.Name = "lblTitleNbEleves";
            this.lblTitleNbEleves.Size = new System.Drawing.Size(109, 20);
            this.lblTitleNbEleves.TabIndex = 2;
            this.lblTitleNbEleves.Text = "Total d\'élèves :";
            // 
            // pnlBarre
            // 
            this.pnlBarre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(56)))), ((int)(((byte)(88)))));
            this.pnlBarre.Controls.Add(this.btnImpression);
            this.pnlBarre.Controls.Add(this.btnLegende);
            this.pnlBarre.Controls.Add(this.btnImprimer);
            this.pnlBarre.Controls.Add(this.btnStatsNiv);
            this.pnlBarre.Controls.Add(this.lblNbEleves);
            this.pnlBarre.Controls.Add(this.btnExtraireDonneesEleves);
            this.pnlBarre.Controls.Add(this.btnOuvertureXmlGenererParAppli);
            this.pnlBarre.Controls.Add(this.btnSupAffichage);
            this.pnlBarre.Controls.Add(this.lblTitleNbEleves);
            this.pnlBarre.Controls.Add(this.btnResetTout);
            this.pnlBarre.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarre.ForeColor = System.Drawing.Color.DimGray;
            this.pnlBarre.Location = new System.Drawing.Point(225, 0);
            this.pnlBarre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlBarre.Name = "pnlBarre";
            this.pnlBarre.Size = new System.Drawing.Size(1699, 97);
            this.pnlBarre.TabIndex = 1;
            this.pnlBarre.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBarre_Paint);
            // 
            // btnImpression
            // 
            this.btnImpression.BackColor = System.Drawing.Color.Transparent;
            this.btnImpression.Location = new System.Drawing.Point(590, 54);
            this.btnImpression.Margin = new System.Windows.Forms.Padding(4);
            this.btnImpression.Name = "btnImpression";
            this.btnImpression.Size = new System.Drawing.Size(187, 26);
            this.btnImpression.TabIndex = 336;
            this.btnImpression.Text = "Imprimer les fiches en T";
            this.btnImpression.UseVisualStyleBackColor = false;
            this.btnImpression.Click += new System.EventHandler(this.btnImpression_Click);
            // 
            // btnLegende
            // 
            this.btnLegende.BackColor = System.Drawing.Color.Transparent;
            this.btnLegende.Location = new System.Drawing.Point(590, 20);
            this.btnLegende.Margin = new System.Windows.Forms.Padding(4);
            this.btnLegende.Name = "btnLegende";
            this.btnLegende.Size = new System.Drawing.Size(187, 26);
            this.btnLegende.TabIndex = 334;
            this.btnLegende.Text = "Changer légende";
            this.btnLegende.UseVisualStyleBackColor = false;
            this.btnLegende.Click += new System.EventHandler(this.btnLegende_Click);
            // 
            // btnStatsNiv
            // 
            this.btnStatsNiv.Location = new System.Drawing.Point(24, 54);
            this.btnStatsNiv.Margin = new System.Windows.Forms.Padding(4);
            this.btnStatsNiv.Name = "btnStatsNiv";
            this.btnStatsNiv.Size = new System.Drawing.Size(187, 27);
            this.btnStatsNiv.TabIndex = 335;
            this.btnStatsNiv.Text = "Statistiques par niveaux";
            this.btnStatsNiv.UseVisualStyleBackColor = true;
            this.btnStatsNiv.Visible = false;
            this.btnStatsNiv.Click += new System.EventHandler(this.btnStatsNiv_Click);
            // 
            // lblNbEleves
            // 
            this.lblNbEleves.AutoSize = true;
            this.lblNbEleves.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblNbEleves.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblNbEleves.Location = new System.Drawing.Point(157, 25);
            this.lblNbEleves.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNbEleves.Name = "lblNbEleves";
            this.lblNbEleves.Size = new System.Drawing.Size(27, 20);
            this.lblNbEleves.TabIndex = 332;
            this.lblNbEleves.Text = "---";
            // 
            // btnExtraireDonneesEleves
            // 
            this.btnExtraireDonneesEleves.Location = new System.Drawing.Point(229, 20);
            this.btnExtraireDonneesEleves.Margin = new System.Windows.Forms.Padding(4);
            this.btnExtraireDonneesEleves.Name = "btnExtraireDonneesEleves";
            this.btnExtraireDonneesEleves.Size = new System.Drawing.Size(108, 27);
            this.btnExtraireDonneesEleves.TabIndex = 331;
            this.btnExtraireDonneesEleves.Text = "Enregistrer";
            this.btnExtraireDonneesEleves.UseVisualStyleBackColor = true;
            this.btnExtraireDonneesEleves.Click += new System.EventHandler(this.btnExtraireDonneesEleves_Click);
            // 
            // btnSupAffichage
            // 
            this.btnSupAffichage.BackColor = System.Drawing.Color.Transparent;
            this.btnSupAffichage.Image = ((System.Drawing.Image)(resources.GetObject("btnSupAffichage.Image")));
            this.btnSupAffichage.Location = new System.Drawing.Point(468, 28);
            this.btnSupAffichage.Margin = new System.Windows.Forms.Padding(4);
            this.btnSupAffichage.Name = "btnSupAffichage";
            this.btnSupAffichage.Size = new System.Drawing.Size(44, 43);
            this.btnSupAffichage.TabIndex = 330;
            this.btnSupAffichage.UseVisualStyleBackColor = false;
            this.btnSupAffichage.Click += new System.EventHandler(this.btnSupAffichage_Click);
            this.btnSupAffichage.MouseHover += new System.EventHandler(this.btnSupAffichage_MouseHover);
            // 
            // btnResetTout
            // 
            this.btnResetTout.BackColor = System.Drawing.Color.Transparent;
            this.btnResetTout.Image = ((System.Drawing.Image)(resources.GetObject("btnResetTout.Image")));
            this.btnResetTout.Location = new System.Drawing.Point(520, 28);
            this.btnResetTout.Margin = new System.Windows.Forms.Padding(4);
            this.btnResetTout.Name = "btnResetTout";
            this.btnResetTout.Size = new System.Drawing.Size(44, 43);
            this.btnResetTout.TabIndex = 328;
            this.btnResetTout.UseVisualStyleBackColor = false;
            this.btnResetTout.Click += new System.EventHandler(this.btnResetTout_Click);
            this.btnResetTout.MouseHover += new System.EventHandler(this.btnResetTout_MouseHover);
            // 
            // layoutClasses6e
            // 
            this.layoutClasses6e.AutoSize = true;
            this.layoutClasses6e.BackColor = System.Drawing.Color.DarkGray;
            this.layoutClasses6e.Location = new System.Drawing.Point(0, 0);
            this.layoutClasses6e.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.layoutClasses6e.Name = "layoutClasses6e";
            this.layoutClasses6e.Size = new System.Drawing.Size(0, 0);
            this.layoutClasses6e.TabIndex = 0;
            this.layoutClasses6e.Paint += new System.Windows.Forms.PaintEventHandler(this.layoutClasses6e_Paint);
            // 
            // layoutNiveaux
            // 
            this.layoutNiveaux.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutNiveaux.AutoScroll = true;
            this.layoutNiveaux.BackColor = System.Drawing.Color.Gray;
            this.layoutNiveaux.Controls.Add(this.layoutClasses6e);
            this.layoutNiveaux.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutNiveaux.Location = new System.Drawing.Point(231, 101);
            this.layoutNiveaux.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutNiveaux.Name = "layoutNiveaux";
            this.layoutNiveaux.Size = new System.Drawing.Size(1681, 1063);
            this.layoutNiveaux.TabIndex = 2;
            this.layoutNiveaux.WrapContents = false;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // InterfacePrinc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1924, 1175);
            this.Controls.Add(this.layoutNiveaux);
            this.Controls.Add(this.pnlBarre);
            this.Controls.Add(this.panelMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "InterfacePrinc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kairos - Gestion";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.InterfacePrinc_Load);
            this.panelMenu.ResumeLayout(false);
            this.Laylow.ResumeLayout(false);
            this.pnlContientFichiers.ResumeLayout(false);
            this.pnlNiveaux.ResumeLayout(false);
            this.pnlEleves.ResumeLayout(false);
            this.pnlClasse.ResumeLayout(false);
            this.pnlCompleteGauche.ResumeLayout(false);
            this.pnlNouvelleAnnee.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.pnlBarre.ResumeLayout(false);
            this.pnlBarre.PerformLayout();
            this.layoutNiveaux.ResumeLayout(false);
            this.layoutNiveaux.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer FichierTimer;
        private System.Windows.Forms.Timer NiveauxTimer;
        private System.Windows.Forms.Timer EleveTimer;
        private System.Windows.Forms.Timer ClasseTimer;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.FlowLayoutPanel Laylow;
        private System.Windows.Forms.Panel pnlContientFichiers;
        private System.Windows.Forms.Button btnOpenBase;
        private System.Windows.Forms.Button btnFiles;
        private System.Windows.Forms.Panel pnlNiveaux;
        private System.Windows.Forms.Button btn3ème;
        private System.Windows.Forms.Button btn4ème;
        private System.Windows.Forms.Button btn5ème;
        private System.Windows.Forms.Button btn6ème;
        private System.Windows.Forms.Button btnNiveaux;
        private System.Windows.Forms.Panel pnlEleves;
        private System.Windows.Forms.Button btnDeplaClasse;
        private System.Windows.Forms.Button btnAjoutFicheEleve;
        private System.Windows.Forms.Button Btnélèves;
        private System.Windows.Forms.Panel pnlClasse;
        private System.Windows.Forms.Button btnRenomClasse;
        private System.Windows.Forms.Button btnClasse;
        private System.Windows.Forms.Panel pnlCompleteGauche;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label lblTitleNbEleves;
        private System.Windows.Forms.Panel pnlBarre;
        private System.Windows.Forms.FlowLayoutPanel layoutClasses6e;
        private System.Windows.Forms.FlowLayoutPanel layoutNiveaux;
        private System.Windows.Forms.Button btnSuppEleve;
        private System.Windows.Forms.Button btnSupAffichage;
        private System.Windows.Forms.Button btnResetTout;
        private System.Windows.Forms.Button btnAjoutProf;
        private System.Windows.Forms.Panel pnlNouvelleAnnee;
        private System.Windows.Forms.Button btnNouvelleAnnee;
        private System.Windows.Forms.Button btnExtraireDonneesEleves;
        private System.Windows.Forms.Button btnOuvertureXmlGenererParAppli;
        private System.Windows.Forms.Label lblNbEleves;
        private System.Windows.Forms.Button btnActualiser;
        private System.Windows.Forms.Button btnLegende;
        private System.Windows.Forms.Button btnStatsNiv;
        private System.Windows.Forms.Button btnImprimer;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button btnImages;
        private System.Windows.Forms.Button btnImpression;
    }
}