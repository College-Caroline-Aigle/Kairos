
namespace FichesT
{
    partial class ChangementClasseEleve
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangementClasseEleve));
            this.cbbEleve = new System.Windows.Forms.ComboBox();
            this.lblSuppEl2 = new System.Windows.Forms.Label();
            this.btnValider = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.cbbClasse = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSuppEl1 = new System.Windows.Forms.Label();
            this.cbbNewClasse = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbbEleve
            // 
            this.cbbEleve.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbEleve.FormattingEnabled = true;
            this.cbbEleve.Location = new System.Drawing.Point(105, 160);
            this.cbbEleve.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbEleve.Name = "cbbEleve";
            this.cbbEleve.Size = new System.Drawing.Size(261, 24);
            this.cbbEleve.TabIndex = 32;
            // 
            // lblSuppEl2
            // 
            this.lblSuppEl2.AutoSize = true;
            this.lblSuppEl2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuppEl2.Location = new System.Drawing.Point(31, 160);
            this.lblSuppEl2.Name = "lblSuppEl2";
            this.lblSuppEl2.Size = new System.Drawing.Size(53, 20);
            this.lblSuppEl2.TabIndex = 31;
            this.lblSuppEl2.Text = "Élève :";
            // 
            // btnValider
            // 
            this.btnValider.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValider.Location = new System.Drawing.Point(216, 208);
            this.btnValider.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(149, 50);
            this.btnValider.TabIndex = 30;
            this.btnValider.Text = "Valider";
            this.btnValider.UseVisualStyleBackColor = true;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnuler.Location = new System.Drawing.Point(35, 208);
            this.btnAnnuler.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(149, 50);
            this.btnAnnuler.TabIndex = 29;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // cbbClasse
            // 
            this.cbbClasse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbClasse.FormattingEnabled = true;
            this.cbbClasse.Location = new System.Drawing.Point(35, 114);
            this.cbbClasse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbClasse.Name = "cbbClasse";
            this.cbbClasse.Size = new System.Drawing.Size(151, 24);
            this.cbbClasse.TabIndex = 28;
            this.cbbClasse.SelectionChangeCommitted += new System.EventHandler(this.cbbClasse_SelectionChangeCommitted);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(56)))), ((int)(((byte)(88)))));
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(421, 70);
            this.panel1.TabIndex = 27;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(131, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(152, 23);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Déplacer un élève";
            // 
            // lblSuppEl1
            // 
            this.lblSuppEl1.AutoSize = true;
            this.lblSuppEl1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuppEl1.Location = new System.Drawing.Point(31, 91);
            this.lblSuppEl1.Name = "lblSuppEl1";
            this.lblSuppEl1.Size = new System.Drawing.Size(115, 20);
            this.lblSuppEl1.TabIndex = 26;
            this.lblSuppEl1.Text = "Classe actuelle :";
            // 
            // cbbNewClasse
            // 
            this.cbbNewClasse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbNewClasse.FormattingEnabled = true;
            this.cbbNewClasse.Location = new System.Drawing.Point(216, 114);
            this.cbbNewClasse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbNewClasse.Name = "cbbNewClasse";
            this.cbbNewClasse.Size = new System.Drawing.Size(151, 24);
            this.cbbNewClasse.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(212, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 33;
            this.label1.Text = "Nouvelle Classe :";
            // 
            // ChangementClasseEleve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 327);
            this.Controls.Add(this.cbbNewClasse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbbEleve);
            this.Controls.Add(this.lblSuppEl2);
            this.Controls.Add(this.btnValider);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.cbbClasse);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblSuppEl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ChangementClasseEleve";
            this.Text = "ChangementClasseEleve";
            this.Load += new System.EventHandler(this.ChangementClasseEleve_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbbEleve;
        private System.Windows.Forms.Label lblSuppEl2;
        private System.Windows.Forms.Button btnValider;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.ComboBox cbbClasse;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSuppEl1;
        private System.Windows.Forms.ComboBox cbbNewClasse;
        private System.Windows.Forms.Label label1;
    }
}