using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clubtennismvvm.Models
{
    [Serializable()]
    public class MatchSimpleModel : MatchModel
    {
        #region Attributs

        private CompetiteurModel joueurDuClub;

        #endregion

        #region Proprietés 

        public CompetiteurModel JoueurDuClub
        {
            get { return this.joueurDuClub; }
            set
            {
                this.joueurDuClub = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        #region Constructeurs

        public MatchSimpleModel(EquipeModel e1, EquipeModel e2, CompetiteurModel c):base(e1, e2)
            {
            this.joueurDuClub = c;
            this.idMatch = Id;
            }

        #endregion

        #region Methodes

        #endregion
    }
}
