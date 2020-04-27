using Clubtennismvvm.Models;
using Clubtennismvvm.ModelsVues.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clubtennismvvm.ModelsVues
{
   public class StatistiqueMembreModelView : BaseModelView
    {
        #region Attributs

        private BindingList<CompetiteurModel> competiteurs = new BindingList<CompetiteurModel> { };

        private Dictionary<int, int> nombreMatchJoue = new Dictionary<int, int> { };

        #endregion

        #region Proprietés 

        public BindingList<CompetiteurModel> Competiteurs
        {
            get { return  this.competiteurs; }
            set
            {
                this.competiteurs = value;
                NotifyPropertyChanged();
            }
        }

        public Dictionary<int,int> NombreDeMatcheJoue
        {
            get { return this.nombreMatchJoue; }
            set
            {
                this.nombreMatchJoue = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        #region Constructeurs
        public StatistiqueMembreModelView(ClubModel club)
        {
            this.club = club;
            Inititialisation();
        }
        #endregion

        #region Methodes

        private void Inititialisation()
        {
            competiteurs = MembreService.ListeCompetiteur(club);
            foreach(CompetiteurModel c in competiteurs)
            {
                NombreDeMatcheJoue.Add(c.IdMembre, c.MatchesJoue.Count);
            }
        }

        #endregion

    }
}
