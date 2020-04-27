using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Clubtennismvvm.Models
{
    [Serializable()]
    public class EquipeModel : BaseModel, IDataErrorInfo
    {
        #region Attributs

        public static int id;

        private string nom;

        private int idEquipe;

        private BindingList<CompetiteurModel> listeDeJoueur = new BindingList<CompetiteurModel> { };

        private PersonnelModel entraineur;

        private int nombreDePoint;

        private string niveau; // Classement maximun autorisé pour faire partie de l'équipe

        private ECategorie categorie; // Categorie (homme,femme,mineur)

        #endregion

        #region Proprietés 

        public BindingList<CompetiteurModel> ListeDeJoueur
        {
            get { return this.listeDeJoueur; }
            set
            {
                this.listeDeJoueur = value;
                NotifyPropertyChanged();

            }
        }
        public string Nom
        {
            get { return this.nom; }
            set
            {
                this.nom = value;
                NotifyPropertyChanged();
            }
        }
        public string Niveau
        {

            get { return this.niveau; }
            set
            {
                this.niveau = value;
                NotifyPropertyChanged();
            }
        }
        public PersonnelModel Entraineur

        {
            get { return this.entraineur; }
            set
            {
                this.entraineur = value;
                NotifyPropertyChanged();
            }
        }
        public ECategorie Categorie
        {
            get { return this.categorie; }
            set
            {
                this.categorie = value;
                NotifyPropertyChanged();
            }

        }
        public int NombreDePoint
        {
            get { return this.nombreDePoint; }
            set
            {
                this.nombreDePoint = value;
                NotifyPropertyChanged();
            }
        }
        public int IdEquipe
        {
            get { return this.idEquipe; }
            set
            {
                this.idEquipe = value;
                NotifyPropertyChanged();
            }
        }



        #endregion

        #region Constructeurs

        public EquipeModel()
        {
            this.idEquipe = id;
            id++;

        }

        #endregion

        #region Methodes



        #endregion

        #region Verification

        public string Error
        {
            get { return ""; }
        }

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {

                    case "Nom":
                        {
                            if (string.IsNullOrEmpty(nom) || (!Regex.IsMatch(nom, "^[a-zA-Z- ]+$")))
                            {
                                return "Entrez un nom valide";
                            }
                            return "";
                        }



                    case "Niveau":
                        {
                            if ((string.IsNullOrEmpty(Niveau) || (!Regex.IsMatch(Niveau, "^[0-9-/]+$"))))
                            {
                                return "Entrez une tranche de niveau valide";
                            }
                            return "";
                        }

                    default:
                        return "";
                }
            }

            #endregion
        }
    }
}
