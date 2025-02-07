
namespace FichesT
{
    partial class NouvelleAnnee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NouvelleAnnee));
            this.lblNomEleve = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCompteur2 = new System.Windows.Forms.Label();
            this.lblCompteur1 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPrenomEleve = new System.Windows.Forms.Label();
            this.cbbClasse = new System.Windows.Forms.ComboBox();
            this.btnSuivant = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNomEleve
            // 
            this.lblNomEleve.AutoSize = true;
            this.lblNomEleve.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomEleve.Location = new System.Drawing.Point(217, 142);
            this.lblNomEleve.Name = "lblNomEleve";
            this.lblNomEleve.Size = new System.Drawing.Size(48, 23);
            this.lblNomEleve.TabIndex = 0;
            this.lblNomEleve.Text = "Nom";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(56)))), ((int)(((byte)(88)))));
            this.panel1.Controls.Add(this.lblCompteur2);
            this.panel1.Controls.Add(this.lblCompteur1);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(645, 86);
            this.panel1.TabIndex = 1;
            // 
            // lblCompteur2
            // 
            this.lblCompteur2.AutoSize = true;
            this.lblCompteur2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompteur2.ForeColor = System.Drawing.Color.White;
            this.lblCompteur2.Location = new System.Drawing.Point(572, 30);
            this.lblCompteur2.Name = "lblCompteur2";
            this.lblCompteur2.Size = new System.Drawing.Size(40, 23);
            this.lblCompteur2.TabIndex = 12;
            this.lblCompteur2.Text = "000";
            // 
            // lblCompteur1
            // 
            this.lblCompteur1.AutoSize = true;
            this.lblCompteur1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompteur1.ForeColor = System.Drawing.Color.White;
            this.lblCompteur1.Location = new System.Drawing.Point(29, 30);
            this.lblCompteur1.Name = "lblCompteur1";
            this.lblCompteur1.Size = new System.Drawing.Size(40, 23);
            this.lblCompteur1.TabIndex = 10;
            this.lblCompteur1.Text = "000";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(211, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(239, 28);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "Nouvelle année scolaire";
            // 
            // lblPrenomEleve
            // 
            this.lblPrenomEleve.AutoSize = true;
            this.lblPrenomEleve.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrenomEleve.Location = new System.Drawing.Point(217, 164);
            this.lblPrenomEleve.Name = "lblPrenomEleve";
            this.lblPrenomEleve.Size = new System.Drawing.Size(70, 23);
            this.lblPrenomEleve.TabIndex = 2;
            this.lblPrenomEleve.Text = "Prénom";
            // 
            // cbbClasse
            // 
            this.cbbClasse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbClasse.FormattingEnabled = true;
            this.cbbClasse.Location = new System.Drawing.Point(221, 206);
            this.cbbClasse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbClasse.Name = "cbbClasse";
            this.cbbClasse.Size = new System.Drawing.Size(212, 24);
            this.cbbClasse.TabIndex = 3;
            this.cbbClasse.SelectedIndexChanged += new System.EventHandler(this.cbbClasse_SelectedIndexChanged);
            // 
            // btnSuivant
            // 
            this.btnSuivant.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuivant.Location = new System.Drawing.Point(461, 267);
            this.btnSuivant.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSuivant.Name = "btnSuivant";
            this.btnSuivant.Size = new System.Drawing.Size(149, 50);
            this.btnSuivant.TabIndex = 20;
            this.btnSuivant.Text = "Suivant";
            this.btnSuivant.UseVisualStyleBackColor = true;
            this.btnSuivant.Click += new System.EventHandler(this.btnSuivant_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Enabled = false;
            this.btnAnnuler.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnuler.Location = new System.Drawing.Point(32, 267);
            this.btnAnnuler.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(149, 50);
            this.btnAnnuler.TabIndex = 19;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // NouvelleAnnee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 345);
            this.Controls.Add(this.btnSuivant);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.cbbClasse);
            this.Controls.Add(this.lblPrenomEleve);
            this.Controls.Add(this.lblNomEleve);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "NouvelleAnnee";
            this.Text = "NouvelleAnnee";
            this.Load += new System.EventHandler(this.NouvelleAnnee_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNomEleve;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPrenomEleve;
        private System.Windows.Forms.ComboBox cbbClasse;
        private System.Windows.Forms.Button btnSuivant;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Label lblCompteur2;
        private System.Windows.Forms.Label lblCompteur1;
    }
}