
namespace FichesT
{
    partial class OuvertureFichierGenererParNous
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OuvertureFichierGenererParNous));
            this.lblText1 = new System.Windows.Forms.Label();
            this.btnAnnulerOuvertureCsv = new System.Windows.Forms.Button();
            this.btnOuvrirFIchierCsv = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblText1
            // 
            this.lblText1.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText1.ForeColor = System.Drawing.Color.DimGray;
            this.lblText1.Location = new System.Drawing.Point(79, 28);
            this.lblText1.Name = "lblText1";
            this.lblText1.Size = new System.Drawing.Size(319, 97);
            this.lblText1.TabIndex = 9;
            this.lblText1.Text = "Sélectionnez le fichier élèves créer à partir de cette application en fomat .xml " +
    "afin de remplir le tableau de fiches en T.";
            this.lblText1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAnnulerOuvertureCsv
            // 
            this.btnAnnulerOuvertureCsv.Location = new System.Drawing.Point(181, 219);
            this.btnAnnulerOuvertureCsv.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAnnulerOuvertureCsv.Name = "btnAnnulerOuvertureCsv";
            this.btnAnnulerOuvertureCsv.Size = new System.Drawing.Size(109, 47);
            this.btnAnnulerOuvertureCsv.TabIndex = 8;
            this.btnAnnulerOuvertureCsv.Text = "Annuler";
            this.btnAnnulerOuvertureCsv.UseVisualStyleBackColor = true;
            this.btnAnnulerOuvertureCsv.Click += new System.EventHandler(this.btnAnnulerOuvertureCsv_Click);
            // 
            // btnOuvrirFIchierCsv
            // 
            this.btnOuvrirFIchierCsv.Location = new System.Drawing.Point(181, 153);
            this.btnOuvrirFIchierCsv.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOuvrirFIchierCsv.Name = "btnOuvrirFIchierCsv";
            this.btnOuvrirFIchierCsv.Size = new System.Drawing.Size(109, 47);
            this.btnOuvrirFIchierCsv.TabIndex = 7;
            this.btnOuvrirFIchierCsv.Text = "Ouvrir";
            this.btnOuvrirFIchierCsv.UseVisualStyleBackColor = true;
            this.btnOuvrirFIchierCsv.Click += new System.EventHandler(this.btnOuvrirFIchierCsv_Click);
            // 
            // OuvertureFichierGenererParNous
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 302);
            this.Controls.Add(this.lblText1);
            this.Controls.Add(this.btnAnnulerOuvertureCsv);
            this.Controls.Add(this.btnOuvrirFIchierCsv);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "OuvertureFichierGenererParNous";
            this.Text = "OuvertureFichierGenererParNous";
            this.Load += new System.EventHandler(this.OuvertureFichierGenererParNous_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblText1;
        private System.Windows.Forms.Button btnAnnulerOuvertureCsv;
        private System.Windows.Forms.Button btnOuvrirFIchierCsv;
    }
}