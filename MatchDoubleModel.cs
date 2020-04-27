using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clubtennismvvm.Models
{
    [Serializable()]
    public class MatchDoubleModel : MatchModel
    {
        #region Attributs

        private List<CompetiteurModel> listeJoueurDuClub = new List<CompetiteurModel> { }; // les deux joueur jouant pour l'équipe du club sur le match

        #endregion

        #region Proprietés 

        public List<CompetiteurModel> ListejoueurDuClub
        {
            get { return this.listeJoueurDuClub; }
            set
            {
                this.listeJoueurDuClub = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        #region Constructeurs

        public MatchDoubleModel(EquipeModel e1, EquipeModel e2, CompetiteurModel c1, CompetiteurModel c2):base(e1,e2)
        {
            ListejoueurDuClub.Add(c1);
            ListejoueurDuClub.Add(c2);
            this.idMatch = Id;
        }

        #endregion

        #region Methodes

        #endregion
    }
}
