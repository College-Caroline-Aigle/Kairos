using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FichesT
{
    public class Classe
    {
        public string nomDeLaClasse { get; set; }
        public string nomProfPrinc { get; set; }

        private List<Eleve> lesEleves ;

        public Classe()
        {
            lesEleves = new List<Eleve>();
            nomProfPrinc = "";
        }

        public Classe(string nomDeLaClasse)
        {
            this.nomDeLaClasse = nomDeLaClasse;
            lesEleves = new List<Eleve>();
            nomProfPrinc = "";
        }

        public Classe(string nomDeLaClasse, string nomProfPrinc)
        {
            this.nomDeLaClasse = nomDeLaClasse;
            this.nomProfPrinc = nomProfPrinc;
            lesEleves = new List<Eleve>();
        }

        public Classe(string nomDeLaClasse, string nomProfPrinc, List<Eleve> desEleves)
        {
            this.nomDeLaClasse = nomDeLaClasse;
            this.nomProfPrinc = nomProfPrinc;
            lesEleves = desEleves;
        }

        public void setNomProfPrinc(string nomDuProfPrinc)
        {
            nomProfPrinc = nomDuProfPrinc;
        }
        
        public void setListEleve(List<Eleve> uneListEleve)
        {
            lesEleves = uneListEleve;
        }
        
        public void setLesEleves(Eleve unEleve)
        {
            lesEleves.Add(unEleve);
        }

        public List<Eleve> getLesEleves()
        {
            return lesEleves;
        }

        public Eleve getEleve(string unNomEleve, string unPrenomEleve, List<Eleve> desEleves)
        {
            foreach (Eleve lEleve in desEleves)
            {
                if (lEleve.nomEleve == unNomEleve | lEleve.prenomEleve == unPrenomEleve)
                    return lEleve;
            }
            return null;
        }

        public string getNomProfPrinc() {  return nomProfPrinc; }
    }
}
