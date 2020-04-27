using Clubtennismvvm.ModelsVues;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clubtennismvvm.Models
{
    [Serializable()]
    public class PersonnelModel: MembreModel 
    {
        #region Attributs

        private bool estEntraineur = false;

        private EStatus status = EStatus.Salarie;

        private double salaire;

        #endregion

        #region Proprietés
        public double Salaire
        {
            get { return this.salaire; }
            set
            {
                this.salaire = value;
                NotifyPropertyChanged();
            }
        }
        public bool EstEntraineur
        {
            get { return estEntraineur; }
            set
            {
                estEntraineur = value;
                NotifyPropertyChanged();
                this.competition = false;
                this.classement = " ";
                NotifyPropertyChanged("competition");
                NotifyPropertyChanged("Classement");
            }
        }
        public EStatus Status
        {
            get { return status; }
            set
            {
                this.status = value;
                NotifyPropertyChanged();
            }
        }
        public string Rib { get; set; }
        
        public DateTime DateEntreAssociation { get; set; }
        #endregion

        #region Constructeur
        public PersonnelModel()
        {
            this.DateEntreAssociation = DateTime.Now;    
        }
        #endregion

        #region Verification

        public override string this[string t] 
        {
            get
            {
                if(t=="Rib")
                {
                    if(String.IsNullOrEmpty(Rib))
                    {
                        return "Entrer un rib";
                    }
                    return "";
                }
                else 
                {
                    return base[t];
                }
                
            }
        }

        #endregion

    }
}
