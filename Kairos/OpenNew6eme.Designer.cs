
namespace FichesT
{
    partial class OpenNew6eme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenNew6eme));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbXLS = new System.Windows.Forms.RadioButton();
            this.rdbXLSX = new System.Windows.Forms.RadioButton();
            this.btnCancel1 = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.lblText1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbXLS);
            this.groupBox1.Controls.Add(this.rdbXLSX);
            this.groupBox1.Location = new System.Drawing.Point(79, 153);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(127, 63);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // rdbXLS
            // 
            this.rdbXLS.AutoSize = true;
            this.rdbXLS.Checked = true;
            this.rdbXLS.Location = new System.Drawing.Point(71, 22);
            this.rdbXLS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdbXLS.Name = "rdbXLS";
            this.rdbXLS.Size = new System.Drawing.Size(49, 21);
            this.rdbXLS.TabIndex = 2;
            this.rdbXLS.TabStop = true;
            this.rdbXLS.Text = ".xls";
            this.rdbXLS.UseVisualStyleBackColor = true;
            // 
            // rdbXLSX
            // 
            this.rdbXLSX.AutoSize = true;
            this.rdbXLSX.Location = new System.Drawing.Point(5, 22);
            this.rdbXLSX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdbXLSX.Name = "rdbXLSX";
            this.rdbXLSX.Size = new System.Drawing.Size(55, 21);
            this.rdbXLSX.TabIndex = 1;
            this.rdbXLSX.Text = ".xlsx";
            this.rdbXLSX.UseVisualStyleBackColor = true;
            // 
            // btnCancel1
            // 
            this.btnCancel1.Location = new System.Drawing.Point(268, 197);
            this.btnCancel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel1.Name = "btnCancel1";
            this.btnCancel1.Size = new System.Drawing.Size(109, 47);
            this.btnCancel1.TabIndex = 6;
            this.btnCancel1.Text = "Annuler";
            this.btnCancel1.UseVisualStyleBackColor = true;
            this.btnCancel1.Click += new System.EventHandler(this.btnCancel1_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(268, 134);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(109, 47);
            this.btnOpen.TabIndex = 5;
            this.btnOpen.Text = "Ouvrir";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // lblText1
            // 
            this.lblText1.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText1.ForeColor = System.Drawing.Color.DimGray;
            this.lblText1.Location = new System.Drawing.Point(35, 18);
            this.lblText1.Name = "lblText1";
            this.lblText1.Size = new System.Drawing.Size(336, 102);
            this.lblText1.TabIndex = 8;
            this.lblText1.Text = "Sélectionnez un fichier élèves en .xls OU en .xlsx contenant les nouveaux élèves " +
    "de 6ème.";
            this.lblText1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OpenNew6eme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 281);
            this.Controls.Add(this.lblText1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel1);
            this.Controls.Add(this.btnOpen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "OpenNew6eme";
            this.Text = " Ouvrir la nouvelle 6ème";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbXLS;
        private System.Windows.Forms.RadioButton rdbXLSX;
        private System.Windows.Forms.Button btnCancel1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label lblText1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}