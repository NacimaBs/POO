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
    public class ListeCompetitionModelView:BaseModelView
    {
        #region Attributs

        private BindingList<CompetitionModel> competitions = new BindingList<CompetitionModel> { };

        #endregion

        #region Proprietés 

        public BindingList<CompetitionModel> Competitions
        {
            get { return this.competitions; }
            set
            {
                this.competitions = value;
                NotifyPropertyChanged();
            }
        }
        public ICommand SupprimerCompetitionCommand { get; set; }
        

        #endregion

        #region Constructeurs

        public ListeCompetitionModelView(ClubModel club)
        {
            this.club = club;
            Initialisation();
            SupprimerCompetitionCommand = new SimpleCommand(SupprimerCompetition);
        }



        #endregion

        #region Methodes
        private void SupprimerCompetition(object obj)
        {
            CompetitionService.SupprimerCompetition(club, obj as CompetitionModel);
            competitions.Remove(obj as CompetitionModel);
        }

        private void Initialisation()
        {
            foreach (CompetitionModel competition in club.ListeDesCompetitions())
            {
                if(!CompetitionService.CompetitionTerminer(club,competition))
                {
                    competitions.Add(competition);
                }
            }
        }
        #endregion
    }
}
