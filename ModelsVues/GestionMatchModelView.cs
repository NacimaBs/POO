using Clubtennismvvm.Models;
using Clubtennismvvm.ModelsVues.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Clubtennismvvm.ModelsVues
{
    class GestionMatchModelView:BaseModelView
    {
        #region Attributs

        private BindingList<MatchModel> matches = new BindingList<MatchModel> { };

        #endregion

        #region Proprietés 

        public ICommand MatchGagneCommand { get; set; }

        public ICommand MatchPerduCommand { get; set; }

        public BindingList<MatchModel> Matches
        {
            get { return this.matches; }
            set
            {
                this.matches = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        #region Constructeurs
        public GestionMatchModelView(ClubModel club, CompetitionModel competition)
        {
            this.club = club;
            this.matches = competition.Matches;
            MatchGagneCommand = new SimpleCommand(MatchGagne);
            MatchPerduCommand = new SimpleCommand(MatchPerdu);

        }


        #endregion

        #region Methodes
        private void MatchPerdu(object obj)
        {
            MatchService.DeclarerMatch(club, obj as MatchModel,false);
            Matches.Remove(obj as MatchModel);
        }

        private void MatchGagne(object obj)
        {
            MatchService.DeclarerMatch(club, obj as MatchModel,true);
            Matches.Remove(obj as MatchModel);
        }
        #endregion

    }
}
