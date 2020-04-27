using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clubtennismvvm.Models
{
    [Serializable()]
    public class PaiementModel : BaseModel
    {
        #region Attributs

        public static int Nidpaiement=0;

        private int idPaiement;

        private double montant;

        private MembreModel payeur;

        private Object nature;

        private DateTime dateDeEmission;

        #endregion

        #region Proprietés

        public int IdPaiement
        {
            get { return this.idPaiement; }
            set
            {
                this.idPaiement = value;
                NotifyPropertyChanged();
            }
        }

        public double Montant
        {
            get { return this.montant; }
            set
            {
                this.montant = value;
                NotifyPropertyChanged();
            }
        }

        public Object  Nature
        {
            get { return this.nature; }
            set
            {
                this.nature = value;
                NotifyPropertyChanged();
            }
        }

        public MembreModel Payeur
        {
            get { return this.payeur; }
            set
            {
                this.payeur = value;
                NotifyPropertyChanged();
            }
        }
        
        public DateTime DateDeEmission
        {
            get { return this.dateDeEmission; }
            set
            {
                this.dateDeEmission = value;
                NotifyPropertyChanged();
            }
        }



        #endregion

        #region Constructeur
        
        public PaiementModel(double montant,MembreModel m,object nature)
        {
            this.idPaiement = Nidpaiement;
            this.dateDeEmission = DateTime.Now;
            this.montant = montant;
            this.payeur = m;
            this.nature = nature;
            Nidpaiement++; 
        }

        #endregion
    }
}
