
namespace FichesT
{
    partial class SuppEleve
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuppEleve));
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.cbbClasse = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSuppEl1 = new System.Windows.Forms.Label();
            this.cbbEleve = new System.Windows.Forms.ComboBox();
            this.lblSuppEl2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimer.Location = new System.Drawing.Point(216, 198);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(150, 51);
            this.btnSupprimer.TabIndex = 23;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnuler.Location = new System.Drawing.Point(35, 198);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(150, 51);
            this.btnAnnuler.TabIndex = 22;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // cbbClasse
            // 
            this.cbbClasse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbClasse.FormattingEnabled = true;
            this.cbbClasse.Location = new System.Drawing.Point(112, 102);
            this.cbbClasse.Name = "cbbClasse";
            this.cbbClasse.Size = new System.Drawing.Size(254, 24);
            this.cbbClasse.TabIndex = 21;
            this.cbbClasse.SelectionChangeCommitted += new System.EventHandler(this.cbbClasse_SelectionChangeCommitted);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(56)))), ((int)(((byte)(88)))));
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(402, 70);
            this.panel1.TabIndex = 20;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(120, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(167, 23);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Supprimer un élève";
            // 
            // lblSuppEl1
            // 
            this.lblSuppEl1.AutoSize = true;
            this.lblSuppEl1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuppEl1.Location = new System.Drawing.Point(31, 102);
            this.lblSuppEl1.Name = "lblSuppEl1";
            this.lblSuppEl1.Size = new System.Drawing.Size(58, 20);
            this.lblSuppEl1.TabIndex = 19;
            this.lblSuppEl1.Text = "Classe :";
            // 
            // cbbEleve
            // 
            this.cbbEleve.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbEleve.FormattingEnabled = true;
            this.cbbEleve.Location = new System.Drawing.Point(112, 146);
            this.cbbEleve.Name = "cbbEleve";
            this.cbbEleve.Size = new System.Drawing.Size(254, 24);
            this.cbbEleve.TabIndex = 25;
            // 
            // lblSuppEl2
            // 
            this.lblSuppEl2.AutoSize = true;
            this.lblSuppEl2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuppEl2.Location = new System.Drawing.Point(31, 146);
            this.lblSuppEl2.Name = "lblSuppEl2";
            this.lblSuppEl2.Size = new System.Drawing.Size(53, 20);
            this.lblSuppEl2.TabIndex = 24;
            this.lblSuppEl2.Text = "Élève :";
            // 
            // SuppEleve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 280);
            this.Controls.Add(this.cbbEleve);
            this.Controls.Add(this.lblSuppEl2);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.cbbClasse);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblSuppEl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SuppEleve";
            this.Text = "SuppEleve";
            this.Load += new System.EventHandler(this.SuppEleve_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.ComboBox cbbClasse;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSuppEl1;
        private System.Windows.Forms.ComboBox cbbEleve;
        private System.Windows.Forms.Label lblSuppEl2;
    }
}