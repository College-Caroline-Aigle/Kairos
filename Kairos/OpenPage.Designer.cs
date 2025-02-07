
namespace FichesT
{
    partial class OpenPage
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenPage));
            this.btnOpen = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnCancel1 = new System.Windows.Forms.Button();
            this.lblText1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbXLS = new System.Windows.Forms.RadioButton();
            this.rdbXLSX = new System.Windows.Forms.RadioButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(113, 158);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(119, 47);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Ouvrir";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // btnCancel1
            // 
            this.btnCancel1.Location = new System.Drawing.Point(15, 206);
            this.btnCancel1.Name = "btnCancel1";
            this.btnCancel1.Size = new System.Drawing.Size(67, 24);
            this.btnCancel1.TabIndex = 2;
            this.btnCancel1.Text = "Annuler";
            this.btnCancel1.UseVisualStyleBackColor = true;
            this.btnCancel1.Click += new System.EventHandler(this.btnCancel1_Click);
            // 
            // lblText1
            // 
            this.lblText1.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText1.ForeColor = System.Drawing.Color.DimGray;
            this.lblText1.Location = new System.Drawing.Point(12, 9);
            this.lblText1.Name = "lblText1";
            this.lblText1.Size = new System.Drawing.Size(334, 76);
            this.lblText1.TabIndex = 3;
            this.lblText1.Text = "Sélectionnez un fichier élèves en .xls OU en .xlsx afin de remplir le tableau de " +
    "fiches en T.";
            this.lblText1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblText1.Click += new System.EventHandler(this.lblText1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbXLS);
            this.groupBox1.Controls.Add(this.rdbXLSX);
            this.groupBox1.Location = new System.Drawing.Point(112, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(120, 54);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // rdbXLS
            // 
            this.rdbXLS.AutoSize = true;
            this.rdbXLS.Checked = true;
            this.rdbXLS.Location = new System.Drawing.Point(64, 20);
            this.rdbXLS.Name = "rdbXLS";
            this.rdbXLS.Size = new System.Drawing.Size(48, 23);
            this.rdbXLS.TabIndex = 2;
            this.rdbXLS.TabStop = true;
            this.rdbXLS.Text = ".xls";
            this.rdbXLS.UseVisualStyleBackColor = true;
            // 
            // rdbXLSX
            // 
            this.rdbXLSX.AutoSize = true;
            this.rdbXLSX.Location = new System.Drawing.Point(10, 20);
            this.rdbXLSX.Name = "rdbXLSX";
            this.rdbXLSX.Size = new System.Drawing.Size(54, 23);
            this.rdbXLSX.TabIndex = 1;
            this.rdbXLSX.TabStop = true;
            this.rdbXLSX.Text = ".xlsx";
            this.rdbXLSX.UseVisualStyleBackColor = true;
            // 
            // OpenPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 234);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblText1);
            this.Controls.Add(this.btnCancel1);
            this.Controls.Add(this.btnOpen);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(374, 281);
            this.MinimumSize = new System.Drawing.Size(374, 281);
            this.Name = "OpenPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.OpenPage_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnCancel1;
        private System.Windows.Forms.Label lblText1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbXLS;
        private System.Windows.Forms.RadioButton rdbXLSX;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

