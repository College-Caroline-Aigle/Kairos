using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FichesT
{
    public class Niveau
    {
        public string nomDuNiveau { get; set; }
        private List<Classe> lesClasses;

        public Niveau()
        {
            lesClasses = new List<Classe>();
        }
        public Niveau(List<Classe> desClasses)
        {
            lesClasses = new List<Classe>();
            lesClasses = desClasses;
        }

        public Niveau(string nomDuNiveau)
        {
            this.nomDuNiveau = nomDuNiveau;
            lesClasses = new List<Classe>();
        }

        public Niveau(string nomDuNiveau, List<Classe> desClasses)
        {
            this.nomDuNiveau = nomDuNiveau;
            lesClasses = new List<Classe>();
            lesClasses = desClasses;
        }

        public void setListClasse(List<Classe> uneListClasse)
        {
            lesClasses = uneListClasse;
        }
        public void setLesClasses(Classe uneClasse)
        {
            lesClasses.Add(uneClasse);
        }
        public List<Classe> getLesClasse()
        {
            return lesClasses;
        }
        public Classe getClasse(string unNomClasse, List<Classe> desClasses)
        {
            foreach (Classe laClasse in desClasses)
            {
                if (laClasse.nomDeLaClasse == unNomClasse)
                    return laClasse;
            }
            return null;
        }
        public void supprClasse(Classe laClasse)
        {
            lesClasses.Remove(laClasse);
        }
    }
}
