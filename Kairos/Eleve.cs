using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Web;

namespace FichesT
{
    public class Eleve
    {

        public int numEleve { get; set; }
        public string nomEleve { get; set; }
        public string prenomEleve { get; set; }
        public string naissanceEleve { get; set; }
        public string sexeEleve { get; set; }
        public string mefEleve { get; set; }
        public string redouble {  get; set; }
        public string classeEleve { get; set; }
        public Options LV1 { get; set; }
        public Options option1 { get; set; }
        public Options option2 { get; set; }
        public string LV1Eleve {  get; set; }
        public string option1Eleve { get; set; }
        public string option2Eleve { get; set; }
        public DateTime dateEntree { get; set; }
        public DateTime dateSortie { get; set; }
        public string nonInscrit { get; set; }
        public string etablissementOrigine { get; set; }

        public Color couleurLV1 { get; set; }
        public Color couleurOpt1 { get; set; }
        public Color couleurOpt2 { get; set; }

        public RadioButton rdbNiveau { get; set; }

        public string ine { get; set; }
        public List<string> anciennesClasses { get; set; }
        public List<char> anciensNiveaux { get; set; }

        public Eleve() 
        { }
        
        
        public Eleve(int numEleve, string nomEleve, string prenomEleve, string naissanceEleve, string sexeEleve, string mefEleve, string classeEleve, string LV1Eleve, string option1Eleve, string option2Eleve)
        {
            this.numEleve = numEleve;
            this.nomEleve = nomEleve;
            this.prenomEleve = prenomEleve;
            this.naissanceEleve = naissanceEleve;
            this.sexeEleve = sexeEleve;
            this.mefEleve = mefEleve;
            this.classeEleve = classeEleve;
            this.LV1Eleve = LV1Eleve;
            this.option1Eleve = option1Eleve;
            this.option2Eleve = option2Eleve;
            this.ine = "vide";
        }

        public Eleve(int numEleve, string nomEleve, string prenomEleve, string naissanceEleve, string sexeEleve, string mefEleve, string classeEleve, string LV1Eleve, string option1Eleve, string option2Eleve, Options LV1, Options option1, Options option2)
        {
            this.numEleve = numEleve;
            this.nomEleve = nomEleve;
            this.prenomEleve = prenomEleve;
            this.naissanceEleve = naissanceEleve;
            this.sexeEleve = sexeEleve;
            this.mefEleve = mefEleve;
            this.classeEleve = classeEleve;
            this.LV1Eleve = LV1Eleve;
            this.option1Eleve = option1Eleve;
            this.option2Eleve = option2Eleve;
            this.LV1 = LV1;
            this.option1 = option1;
            this.option2 = option2;
            this.ine = "vide";
        }

        public Eleve(int numEleve, string nomEleve, string prenomEleve, string naissanceEleve, string sexeEleve, string mefEleve, string redouble, string classeEleve, string LV1Eleve, string option1Eleve, string option2Eleve, Options LV1, Options option1, Options option2)
        {
            this.numEleve = numEleve;
            this.nomEleve = nomEleve;
            this.prenomEleve = prenomEleve;
            this.naissanceEleve = naissanceEleve;
            this.sexeEleve = sexeEleve;
            this.mefEleve = mefEleve;
            this.classeEleve = classeEleve;
            this.LV1Eleve = LV1Eleve;
            this.option1Eleve = option1Eleve;
            this.option2Eleve = option2Eleve;
            this.LV1 = LV1;
            this.option1 = option1;
            this.option2 = option2;
            this.ine = "vide";
        }

        public Eleve(int numEleve, string nomEleve, string prenomEleve, string naissanceEleve, string sexeEleve, string mefEleve, string LV1Eleve, string option1Eleve, string option2Eleve, Options LV1, Options option1, Options option2, DateTime dateEntree)
        {
            this.numEleve = numEleve;
            this.nomEleve = nomEleve;
            this.prenomEleve = prenomEleve;
            this.naissanceEleve = naissanceEleve;
            this.sexeEleve = sexeEleve;
            this.mefEleve = mefEleve;
            this.LV1Eleve = LV1Eleve;
            this.option1Eleve = option1Eleve;
            this.option2Eleve = option2Eleve;
            this.LV1 = LV1;
            this.option1 = option1;
            this.option2 = option2;
            this.dateEntree = dateEntree;
            this.ine = "vide";
        }

        public Eleve(int numEleve, string nomEleve, string prenomEleve, string naissanceEleve, string sexeEleve, string mefEleve, string classeEleve, string LV1Eleve, string option1Eleve, string option2Eleve, Options LV1, Options option1, Options option2, DateTime dateEntree)
        {
            this.numEleve = numEleve;
            this.nomEleve = nomEleve;
            this.prenomEleve = prenomEleve;
            this.naissanceEleve = naissanceEleve;
            this.sexeEleve = sexeEleve;
            this.mefEleve = mefEleve;
            this.classeEleve = classeEleve;
            this.LV1Eleve = LV1Eleve;
            this.option1Eleve = option1Eleve;
            this.option2Eleve = option2Eleve;
            this.LV1 = LV1;
            this.option1 = option1;
            this.option2 = option2;
            this.dateEntree = dateEntree;
            this.ine = "vide";
        }

        public Eleve(int numEleve, string nomEleve, string prenomEleve, string naissanceEleve, string sexeEleve, string mefEleve, string redouble, string classeEleve, string LV1Eleve, string option1Eleve, string option2Eleve, Options LV1, Options option1, Options option2, DateTime dateEntree)
        {
            this.numEleve = numEleve;
            this.nomEleve = nomEleve;
            this.prenomEleve = prenomEleve;
            this.naissanceEleve = naissanceEleve;
            this.sexeEleve = sexeEleve;
            this.mefEleve = mefEleve;
            this.redouble = redouble;
            this.classeEleve = classeEleve;
            this.LV1Eleve = LV1Eleve;
            this.option1Eleve = option1Eleve;
            this.option2Eleve = option2Eleve;
            this.LV1 = LV1;
            this.option1 = option1;
            this.option2 = option2;
            this.dateEntree = dateEntree;
            this.ine = "vide";
        }

        public void setDateSortie(DateTime dateSortie)
        {
            this.dateSortie = dateSortie;
        }

        public Color CouleurLV1()
        {
            if (LV1Eleve.Contains("Angl"))
            {
                couleurLV1 = Color.Pink;
            }
            else if (LV1Eleve.Contains("All"))
            {
                couleurLV1 = Color.DarkGreen;
            }
            else if (LV1Eleve.Contains("Esp"))
            {
                couleurLV1 = Color.Purple;
            }
            else if (LV1Eleve == "Aucune")
            {
                couleurLV1 = Color.Transparent;
            }
            return couleurLV1;
        }

        public Color couleurOption1()
        {
            if (option1Eleve == "Upe2a")
            {
                couleurOpt1 = Color.SaddleBrown;
            }
            else if (option1Eleve == "Ulis")
            {
                couleurOpt1 = Color.Orange;
            }
            else if (option1Eleve == "Segpa")
            {
                couleurOpt1 = Color.OrangeRed;
            }
            else if (option1Eleve.Contains("Angl"))
            {
                couleurOpt1 = Color.Pink;
            }
            else if (option1Eleve.Contains("All"))
            {
                couleurOpt1 = Color.DarkGreen;
            }
            else if (option1Eleve.Contains("Esp"))
            {
                couleurOpt1 = Color.Purple;
            }
            else if (option1Eleve.Contains("Italien"))
            {
                couleurOpt1 = Color.LightGreen;
            }
            else if (option1Eleve.Contains("Russe"))
            {
                couleurOpt1 = Color.White;
            }
            else if (option1Eleve.Contains("Arabe"))
            {
                couleurOpt1 = Color.Beige;
            }
            else if (option1Eleve.Contains("Chinois"))
            {
                couleurOpt1 = Color.Black;
            }
            else if (option1Eleve == "Aucune")
            {
                couleurOpt1 = Color.Transparent;
            }
            return couleurOpt1;
        }

        public Color couleurOption2()
        {
            if (option2Eleve == "Latin")
            {
                couleurOpt2 = Color.Yellow;
            }
            else if (option2Eleve == "CultureReg")
            {
                couleurOpt2 = Color.Blue;
            }
            else if (option2Eleve == "Aucune")
            {
                couleurOpt2 = Color.Transparent;
            }
            return couleurOpt2;
        }
    }
}
