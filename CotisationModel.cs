using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clubtennismvvm.Models
{
    [Serializable()]
    public  class CotisationModel :BaseModel
    {
        #region Attributs

        public static int NidCotisation = 0;

        private int idCotisation;

        private double montant;

        #endregion

        #region Proprietés

        public int IdCotisation
        {
            get { return this.idCotisation; }
            set
            {
                this.idCotisation = value;
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

        #endregion

        #region Constructeur

        public CotisationModel(double montant)
        {
            this.idCotisation = NidCotisation;
            this.montant = montant;
            NidCotisation++;
        }

        #endregion
    }
}
