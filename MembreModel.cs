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
    public class MembreModel : PersonneModel, IComparable
    {
        #region Attributs

        public static int Nmembre ;

        protected bool competition = false;

        protected string classement;

        protected int idMembre;

        #endregion

        #region Proprietés

        public bool Competition
        {
            get { return competition; }
            set
            {

                this.competition = value;
                this.classement = "";
                NotifyPropertyChanged();
                NotifyPropertyChanged("Classement");

            }
        }
        public string Classement
        {
            get { return classement; }
            set
            {

                this.classement = value;
                NotifyPropertyChanged();

            }
        }
        public int IdMembre
        {
            get { return this.idMembre; }
            set
            {
                this.idMembre = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        #region Constructeurs

        public MembreModel()
        {
            this.IdMembre = Nmembre;
            Nmembre += 1;
        }
        public MembreModel(string Prenom, string Nom, DateTime DateDeNaissance, string Adresse, string Ville, ESexe Sexe, string NumeroDeTelephone, bool Competition = false, string Classement = default) : base(Prenom, Nom, DateDeNaissance, Adresse, Ville, Sexe, NumeroDeTelephone)
        {
            this.Competition = Competition;
            this.Classement = Classement;
            this.IdMembre = Nmembre;
            Nmembre += 1;

        }
        #endregion

        #region Verifications IDataErrorInfo
        public override string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Prenom":
                        {
                            if (string.IsNullOrEmpty(prenom) || (!Regex.IsMatch(prenom, "^[a-zA-Z-]+$")))
                            {
                                return "Entrez un prenom valide";
                            }
                            return "";

                        }
                    case "Nom":
                        {
                            if (string.IsNullOrEmpty(nom) || (!Regex.IsMatch(nom, "^[a-zA-Z-]+$")))
                            {
                                return "Entrez un nom valide";
                            }
                            return "";
                        }
                    case "DateDeNaissance":
                        {

                            DateTime dateref = new DateTime(1900, 1, 1);

                            if (dateDeNaissance < dateref)
                            {
                                return "Entrez une date de naissance valide";
                            }
                            return "";
                        }
                    case "NumeroDeTelephone":
                        {
                            if (string.IsNullOrEmpty(numeroDeTelephone) || (!Regex.IsMatch(numeroDeTelephone, "^0[1-68][0-9]{8}$")))
                            {
                                return "Entrez un numero valide";
                            }
                            return "";
                        }
                    case "Adresse":
                        {
                            if (string.IsNullOrEmpty(adresse))
                            {
                                return "Entrez une adresse";
                            }
                            return "";
                        }
                    case "Ville":
                        {
                            if (string.IsNullOrEmpty(ville))
                            { return "Entrez une ville"; }
                            return "";
                        }

                    case "Classement":
                        {
                            if (competition)
                            {
                                if (string.IsNullOrEmpty(classement)|| (!Regex.IsMatch(prenom, "^[0-9/-]+$")))
                                { return "Entrez un classement"; }
                            }
                            return "";
                        }
                    default:
                        return "";

                }

            }
        }


        #endregion

        #region Implementation IComparable

        public int CompareTo(object obj)
        {
            MembreModel m = obj as MembreModel;
            string c1 = this.classement;
            string c2 = m.classement;
            Dictionary<string, int> Intclassement = new Dictionary<string, int> { }; // On Creer un tableau de liaison associant à chaque classemet un poid
            Intclassement.Add("-15",0);
            Intclassement.Add("-4/6",1);
            Intclassement.Add("-2/6",2);
            Intclassement.Add("0",3);
            Intclassement.Add("1/6",4);
            Intclassement.Add("2/6",5);
            Intclassement.Add("3/6",6);
            Intclassement.Add("4/6",7);
            Intclassement.Add("5/6",8);
            Intclassement.Add("15",9);
            Intclassement.Add("30", 15);
            Intclassement.Add("15/5", 14);
            Intclassement.Add("15/4", 13);
            Intclassement.Add("15/3", 12);
            Intclassement.Add("15/2",11);
            Intclassement.Add("15/1", 10);
            Intclassement.Add("40", 21);
            Intclassement.Add("30/5", 20);
            Intclassement.Add("30/4", 19);
            Intclassement.Add("30/3", 18);
            Intclassement.Add("30/2", 17);
            Intclassement.Add("30/1", 16);
            if(c1==null )
            {
                if(c2==null)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            if (c2 == null)
            {
                if (c1 == null)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            return Intclassement[this.classement] - Intclassement[m.classement];
            
            
        }
        #endregion
    }
}
