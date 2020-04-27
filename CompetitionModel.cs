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
    public class CompetitionModel : EvenementsModel, IDataErrorInfo
    {
        #region Attributs

        private string titre;

        private EquipeModel equipeDuClub=null;

        private EquipeModel equipeAdverse=null;

        private BindingList<MatchModel> matches = new BindingList<MatchModel> { };

        private double cout=0;

        private ESexe categorie;

        private int nombreDeJoueurParEquipe=0; // Nombre de joueur par equipe qui participeront à la competition

        private string lieu;

        private bool estDouble = false;

        private string niveau="-15";

        private int idCompetition;

        #endregion

        #region Proprietés 

        public string Titre
        {
            get { return this.titre; }
            set
            {
                this.titre = value;
                NotifyPropertyChanged();
            }

        }

        public ESexe Categorie
        {
            get { return this.categorie; }
            set
            {
                this.categorie = value;
                NotifyPropertyChanged();
            }
        }

        public double Cout
        {
            get { return this.cout; }
            set
            {
                this.cout = value;
                NotifyPropertyChanged();
            }
        }

        public string Lieu
        {
            get { return this.lieu; }
            set
            {
                this.lieu = value;
                NotifyPropertyChanged();
            }
        }

        public int IdCompetiton
        {
            get { return this.idCompetition; }
            set
            {
                this.idCompetition = value;
                NotifyPropertyChanged();
            }
        }

        public bool EstDouble
        {
            get { return this.estDouble; }
            set
            {
                this.estDouble = value;
                NotifyPropertyChanged();
            }

        }

        public BindingList<MatchModel> Matches
        {
            get { return this.matches; }
            set
            {
                this.matches = value;
                NotifyPropertyChanged();
            }
        }

        public int NombreDeJoueurParEquipe
        {
            get { return this.nombreDeJoueurParEquipe; }
            set
            {
                this.nombreDeJoueurParEquipe = value;
                NotifyPropertyChanged();
            }
        }

        public EquipeModel EquipeDuClub
        {
            get { return this.equipeDuClub; }
            set
            {
                this.equipeDuClub = value;
                NotifyPropertyChanged();
            }

        }
        public EquipeModel EquipeAdverse
        {
            get { return this.equipeDuClub; }
            set
            {
                this.equipeAdverse = value;
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



        #endregion

        #region Constructeurs

        public CompetitionModel()
        {
            this.idCompetition = id;
            id++;
        }
        #endregion

        #region Methodes



        #endregion

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
                    case "Titre":
                        {
                            if (string.IsNullOrEmpty(titre) || (!Regex.IsMatch(titre, "^[a-zA-Z- ']+$")))
                            {
                                return "Entrez un titre valide";
                            }
                            return "";

                        }
                    case "Lieu":
                        {
                            if (string.IsNullOrEmpty(Lieu) || (!Regex.IsMatch(lieu, "^[a-zA-Z- ']+$")))
                            {
                                return "Entrez un prenom valide";
                            }
                            return "";

                        }
                    case "DateDeDebut":
                        {

                            DateTime dateref = DateTime.Now;

                            if (dateDeDebut <= dateref)
                            {
                                return "Entrez une date de debut valide";
                            }
                            return "";
                        }
                    case "DateDeFin":
                        {



                            if (dateDeFin < dateDeDebut)
                            {
                                return "Entrez une date de fin valide";
                            }
                            return "";
                        }
                    case "Cout":
                        {
                            if (string.IsNullOrEmpty(Convert.ToString(cout)) || (!Regex.IsMatch(Convert.ToString(cout), "^[0-9]+$")))
                            {
                                return "Entrez un cout valide";
                            }
                            return "";

                        }
                    case "NombreDeJoueurParEquipe":
                        {
                            if (string.IsNullOrEmpty(Convert.ToString(NombreDeJoueurParEquipe)) || (!Regex.IsMatch(Convert.ToString(NombreDeJoueurParEquipe), "^[1-9]+$")))
                            {
                                return "Entrez un nombre valide";
                            }
                            return "";

                        }
                    case "Niveau":
                        {
                            if (string.IsNullOrEmpty(Convert.ToString(Niveau)) || (!Regex.IsMatch(Convert.ToString(Niveau), "^[0-9/-]+$")))
                            {
                                return "Entrez un niveau valide";
                            }
                            return "";

                        }
                    case "EquipeDuClub":
                        {
                            if (EquipeDuClub!=null )
                            {
                                return "Selectione une equipe";
                            }
                            return "";

                        }

                    default:
                        {
                            return "";
                        }
                }
            }
        }
    }
}
