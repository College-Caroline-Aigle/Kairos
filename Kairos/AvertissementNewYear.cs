using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FichesT
{
    public partial class AvertissementNewYear : Form
    {
        public AvertissementNewYear()
        {
            InitializeComponent();
        }

        private void btnContinuer_Click(object sender, EventArgs e)
        {
            OpenNew6eme frmOpenNew6eme = new OpenNew6eme();
            frmOpenNew6eme.Show();
            this.Close();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
