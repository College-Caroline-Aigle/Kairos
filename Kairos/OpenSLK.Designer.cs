namespace FichesT
{
    partial class OpenSLK
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenSLK));
            this.lblText1 = new System.Windows.Forms.Label();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.btnOuvrirSLK = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // lblText1
            // 
            this.lblText1.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText1.ForeColor = System.Drawing.Color.DimGray;
            this.lblText1.Location = new System.Drawing.Point(15, 11);
            this.lblText1.Name = "lblText1";
            this.lblText1.Size = new System.Drawing.Size(319, 97);
            this.lblText1.TabIndex = 12;
            this.lblText1.Text = "Sélectionnez le fichier élèves au fomat .slk contenant les nouveaux élèves de 6èm" +
    "e afin de remplir le tableau de fiches en T.";
            this.lblText1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Location = new System.Drawing.Point(117, 202);
            this.btnAnnuler.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(109, 47);
            this.btnAnnuler.TabIndex = 11;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // btnOuvrirSLK
            // 
            this.btnOuvrirSLK.Location = new System.Drawing.Point(117, 135);
            this.btnOuvrirSLK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOuvrirSLK.Name = "btnOuvrirSLK";
            this.btnOuvrirSLK.Size = new System.Drawing.Size(109, 47);
            this.btnOuvrirSLK.TabIndex = 10;
            this.btnOuvrirSLK.Text = "Ouvrir";
            this.btnOuvrirSLK.UseVisualStyleBackColor = true;
            this.btnOuvrirSLK.Click += new System.EventHandler(this.btnOuvrirSLK_Click);
            // 
            // OpenSLK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 262);
            this.Controls.Add(this.lblText1);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnOuvrirSLK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "OpenSLK";
            this.Text = "OpenSLK";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblText1;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Button btnOuvrirSLK;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}