using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Clubtennismvvm.Models
{
    [Serializable()]
    public abstract class PersonneModel : BaseModel,  IDataErrorInfo ,IPersonne
    {

       


        #region Attributs

        protected string prenom;

        protected string nom;

        protected DateTime dateDeNaissance=DateTime.Now;

        protected string adresse;

        protected string ville;

        protected ESexe sexe;

        protected string numeroDeTelephone;

        #endregion

        #region Constructeur
                public PersonneModel()
        {

        }
        public PersonneModel(string Prenom, string Nom, DateTime DateDeNaissance, string Adresse,string Ville, ESexe Sexe, string NumeroDeTelephone)
        {
            this.Prenom = Prenom;
            this.Nom = Nom;
            this.DateDeNaissance = DateDeNaissance;
            this.Adresse = Adresse;
            this.Sexe = Sexe;
            this.ville = Ville;
            this.NumeroDeTelephone = NumeroDeTelephone;

        }
        #endregion

        #region Proprietés

        public string Prenom
        {
            get { return prenom; }
            set
            {
                prenom = value;
                NotifyPropertyChanged();

            }
        }
        public string Nom
        {
            get { return nom; }
            set
            {
                nom = value;
                NotifyPropertyChanged();

            }
        }
        public DateTime DateDeNaissance
        {
            get { return dateDeNaissance; }
            set
            {
                this.dateDeNaissance = value;
                NotifyPropertyChanged();
            }
        }
        public string Adresse
        {
            get { return adresse; }

            set
            {
                this.adresse = value;
                NotifyPropertyChanged();

            }
        }
        public string Ville
        {
            get { return ville; }
            set
            {
                this.ville = value;
                NotifyPropertyChanged();
            }
        }
        public ESexe Sexe
        {
            get { return sexe; }
            set
            {
                this.sexe = value;
                NotifyPropertyChanged();

            }
        }
        public string NumeroDeTelephone
        {
            get { return numeroDeTelephone; }

            set
            {
                this.numeroDeTelephone = value;
                NotifyPropertyChanged();

            }
        }

        public string Error
        {
            get { return ""; }
        }
        public virtual string this[string columnName] => throw new NotImplementedException();





        #endregion



    }
}
