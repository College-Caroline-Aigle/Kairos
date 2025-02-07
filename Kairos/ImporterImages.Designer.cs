namespace FichesT
{
    partial class ImporterImages
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImporterImages));
            this.gpbImport = new System.Windows.Forms.GroupBox();
            this.rdbImage = new System.Windows.Forms.RadioButton();
            this.rdbDossier = new System.Windows.Forms.RadioButton();
            this.gpbNiveau = new System.Windows.Forms.GroupBox();
            this.rdb3eme = new System.Windows.Forms.RadioButton();
            this.rdb4eme = new System.Windows.Forms.RadioButton();
            this.rdb5eme = new System.Windows.Forms.RadioButton();
            this.rdb6eme = new System.Windows.Forms.RadioButton();
            this.btnOuvrir = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.gpbImport.SuspendLayout();
            this.gpbNiveau.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbImport
            // 
            this.gpbImport.Controls.Add(this.rdbImage);
            this.gpbImport.Controls.Add(this.rdbDossier);
            this.gpbImport.Location = new System.Drawing.Point(17, 16);
            this.gpbImport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpbImport.Name = "gpbImport";
            this.gpbImport.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpbImport.Size = new System.Drawing.Size(297, 123);
            this.gpbImport.TabIndex = 0;
            this.gpbImport.TabStop = false;
            this.gpbImport.Text = "Type d\'importation";
            // 
            // rdbImage
            // 
            this.rdbImage.AutoSize = true;
            this.rdbImage.Location = new System.Drawing.Point(24, 80);
            this.rdbImage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdbImage.Name = "rdbImage";
            this.rdbImage.Size = new System.Drawing.Size(151, 21);
            this.rdbImage.TabIndex = 1;
            this.rdbImage.TabStop = true;
            this.rdbImage.Text = "Importer une image";
            this.rdbImage.UseVisualStyleBackColor = true;
            // 
            // rdbDossier
            // 
            this.rdbDossier.AutoSize = true;
            this.rdbDossier.Checked = true;
            this.rdbDossier.Location = new System.Drawing.Point(24, 36);
            this.rdbDossier.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdbDossier.Name = "rdbDossier";
            this.rdbDossier.Size = new System.Drawing.Size(211, 21);
            this.rdbDossier.TabIndex = 0;
            this.rdbDossier.TabStop = true;
            this.rdbDossier.Text = "Importer un dossier d\'images";
            this.rdbDossier.UseVisualStyleBackColor = true;
            // 
            // gpbNiveau
            // 
            this.gpbNiveau.Controls.Add(this.rdb3eme);
            this.gpbNiveau.Controls.Add(this.rdb4eme);
            this.gpbNiveau.Controls.Add(this.rdb5eme);
            this.gpbNiveau.Controls.Add(this.rdb6eme);
            this.gpbNiveau.Location = new System.Drawing.Point(17, 148);
            this.gpbNiveau.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpbNiveau.Name = "gpbNiveau";
            this.gpbNiveau.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpbNiveau.Size = new System.Drawing.Size(297, 202);
            this.gpbNiveau.TabIndex = 1;
            this.gpbNiveau.TabStop = false;
            this.gpbNiveau.Text = "Niveau à importer";
            // 
            // rdb3eme
            // 
            this.rdb3eme.AutoSize = true;
            this.rdb3eme.Location = new System.Drawing.Point(160, 132);
            this.rdb3eme.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdb3eme.Name = "rdb3eme";
            this.rdb3eme.Size = new System.Drawing.Size(64, 21);
            this.rdb3eme.TabIndex = 4;
            this.rdb3eme.TabStop = true;
            this.rdb3eme.Text = "3ème";
            this.rdb3eme.UseVisualStyleBackColor = true;
            // 
            // rdb4eme
            // 
            this.rdb4eme.AutoSize = true;
            this.rdb4eme.Location = new System.Drawing.Point(24, 132);
            this.rdb4eme.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdb4eme.Name = "rdb4eme";
            this.rdb4eme.Size = new System.Drawing.Size(64, 21);
            this.rdb4eme.TabIndex = 3;
            this.rdb4eme.TabStop = true;
            this.rdb4eme.Text = "4ème";
            this.rdb4eme.UseVisualStyleBackColor = true;
            // 
            // rdb5eme
            // 
            this.rdb5eme.AutoSize = true;
            this.rdb5eme.Location = new System.Drawing.Point(160, 62);
            this.rdb5eme.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdb5eme.Name = "rdb5eme";
            this.rdb5eme.Size = new System.Drawing.Size(64, 21);
            this.rdb5eme.TabIndex = 2;
            this.rdb5eme.TabStop = true;
            this.rdb5eme.Text = "5ème";
            this.rdb5eme.UseVisualStyleBackColor = true;
            // 
            // rdb6eme
            // 
            this.rdb6eme.AutoSize = true;
            this.rdb6eme.Checked = true;
            this.rdb6eme.Location = new System.Drawing.Point(24, 62);
            this.rdb6eme.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdb6eme.Name = "rdb6eme";
            this.rdb6eme.Size = new System.Drawing.Size(64, 21);
            this.rdb6eme.TabIndex = 1;
            this.rdb6eme.TabStop = true;
            this.rdb6eme.Text = "6ème";
            this.rdb6eme.UseVisualStyleBackColor = true;
            // 
            // btnOuvrir
            // 
            this.btnOuvrir.Location = new System.Drawing.Point(17, 375);
            this.btnOuvrir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOuvrir.Name = "btnOuvrir";
            this.btnOuvrir.Size = new System.Drawing.Size(137, 28);
            this.btnOuvrir.TabIndex = 2;
            this.btnOuvrir.Text = "Ouvrir";
            this.btnOuvrir.UseVisualStyleBackColor = true;
            this.btnOuvrir.Click += new System.EventHandler(this.btnOuvrir_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Location = new System.Drawing.Point(177, 375);
            this.btnAnnuler.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(137, 28);
            this.btnAnnuler.TabIndex = 3;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // ImporterImages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 421);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnOuvrir);
            this.Controls.Add(this.gpbNiveau);
            this.Controls.Add(this.gpbImport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ImporterImages";
            this.Text = "ImporterImages";
            this.gpbImport.ResumeLayout(false);
            this.gpbImport.PerformLayout();
            this.gpbNiveau.ResumeLayout(false);
            this.gpbNiveau.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbImport;
        private System.Windows.Forms.RadioButton rdbImage;
        private System.Windows.Forms.RadioButton rdbDossier;
        private System.Windows.Forms.GroupBox gpbNiveau;
        private System.Windows.Forms.RadioButton rdb3eme;
        private System.Windows.Forms.RadioButton rdb4eme;
        private System.Windows.Forms.RadioButton rdb5eme;
        private System.Windows.Forms.RadioButton rdb6eme;
        private System.Windows.Forms.Button btnOuvrir;
        private System.Windows.Forms.Button btnAnnuler;
    }
}