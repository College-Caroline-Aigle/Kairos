using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FichesT
{
    //Classe globale
    static class Global
    {
        public static string pathXML;
        public static string pathXLS;
        public static string pathXLSX;

        public static string pathSLK;
        public static string pathXLS6eme;
        public static string pathXLSX6eme;

        //Infos utiles
        public static int nbEleves = 0;
        public static int nbEleves6eme = 0;
        public static int nbCodesMEF = 0;
        public static int anneeScolaire = 0;
        public static int nbElevesReal = 0;
        public static int nbElevesReal6eme = 0;
        public static int numEleveMax = 0;

        // utile pour l'impression
        public static int indexEleve = 0;
        public static int indexNiveau = 0;
        public static int indexClasse = 0;
        public static int pageCounter = 0;
        public const int maxPages = 100; // Limite maximale de pages à générer   ????? pour le const

        public static List<string> listeNomEtPrenomProf = new List<string>();

        //Liste d'objets Niveau (6eme, 5eme, 4eme, 3eme)
        public static List<Niveau> lesNiveaux = new List<Niveau>();

        //Liste Légendes
        public static List<string> lesOptions = new List<string>();
        public static List<Options> options = new List<Options>();

        //Liste des élèves possédant une classe et un code MEF après tri dans la procédure "repartitionEleves()" :
        public static List<Eleve> elevesValides = new List<Eleve>();
        public static List<Eleve> elevesValides6eme = new List<Eleve>();

        //Déclaration des listes des informations de chaque élève
        public static List<int> listeNumEleve = new List<int>();
        public static List<string> listeNomEleve = new List<string>();
        public static List<string> listePrenomEleve = new List<string>();
        public static List<string> listeNaissanceEleve = new List<string>();
        public static List<string> listeRedouble = new List<string>();
        public static List<string> listeSexeEleve = new List<string>();
        public static List<string> listeMefEleve = new List<string>();
        public static List<string> listeClasseEleve = new List<string>();
        public static List<string> listeLV1Eleve = new List<string>();
        public static List<string> listeOption1Eleve = new List<string>();
        public static List<string> listeOption2Eleve = new List<string>();
        public static List<Options> listeLV1EleveOption = new List<Options>();
        public static List<Options> listeOption1EleveOption = new List<Options>();
        public static List<Options> listeOption2EleveOption = new List<Options>();
        public static List<DateTime> listeDateEntreeEleve = new List<DateTime>();
        public static List<DateTime> listeDateSortieEleve = new List<DateTime>();
        public static List<string> listeEtabOrig = new List<string>();
        public static List<string> listeIneEleve = new List<string>();

        //Déclaration des listes qui vont contenir les noms des classes par niveaux
        public static List<string> nomsClasses6e = new List<string>();
        public static List<string> nomsClasses5e = new List<string>();
        public static List<string> nomsClasses4e = new List<string>();
        public static List<string> nomsClasses3e = new List<string>();

        //Liste de tous les élèves du collège
        public static List<Eleve> ElevesAll = new List<Eleve>();

        //Compteurs pour NouvelleAnnee
        public static int rang;
        public static int LeCompteur;
        public static int avancement;
    }
}
