using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clubtennismvvm.Models
{
    [Serializable()]
    public class MatchModel :BaseModel
    {
        #region Attributs

        protected static int Id;

        protected int idMatch;

        protected bool clubEstVainqueur;

        protected EquipeModel equipeDuClub; // Equipe qui represente notre  club

        protected EquipeModel equipeAdverse; // Equipe fictive (évite de devoir rentrer tout les membres adverse)

        protected bool estAJouer;

        #endregion

        #region Proprietés 
        public int IdMatch
        {
            get { return this.idMatch; }
            set
            {
                this.idMatch = value;
                NotifyPropertyChanged();
            }
        }
        public bool EstAJouer
        {
            get { return this.estAJouer; }
            set
            {
                this.estAJouer = value;
                NotifyPropertyChanged();
            }
        }

        public bool ClubEstVainqueur
        {
            get { return this.clubEstVainqueur; }
            set
            {
                this.clubEstVainqueur = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        #region Constructeurs

        public MatchModel(EquipeModel e1,EquipeModel e2)
        {
            this.estAJouer = true;
            this.equipeDuClub = e1;
            this.equipeAdverse = e2;
            Id++;
        }

        #endregion

        #region Methodes

        #endregion
    }
}
