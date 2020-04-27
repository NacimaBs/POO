using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Clubtennismvvm.Models
{
    [Serializable()]
    public abstract class EvenementsModel : BaseModel,IEvenements
    {
        #region Attributs

        protected DateTime dateDeDebut = DateTime.Now;

        protected DateTime dateDeFin = new DateTime(2020, 1, 1);

        public static int id;

        #endregion

        #region Proprietés

        public int Id
        {
            get { return id; }
            set
            {
                this.Id = value;
                NotifyPropertyChanged();
            }
        }
        public DateTime DateDeDebut
        {
            get { return dateDeDebut; }
            set
            {
                this.dateDeDebut = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("DateDeFin");
            }
        }
        public DateTime DateDeFin
        {
            get { return dateDeFin; }
            set
            {
                this.dateDeFin = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

    }
}
