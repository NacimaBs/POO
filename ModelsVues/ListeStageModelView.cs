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
    public class ListeStageModelView :BaseModelView
    {
        #region Attributs

        private BindingList<StageModel> stages;

        #endregion

        #region Proprietés

        public ICommand SupprimerStageCommand { get; set; }

        public BindingList<StageModel> Stages
        {
            get { return this.stages; }
            set
            {
                this.stages = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        #region Constructeurs

        public ListeStageModelView(ClubModel club)
        {
            this.club = club;
            this.Stages = club.ListeDesStages();
            SupprimerStageCommand = new SimpleCommand(SupprimerStage);
        }

        #endregion

        #region Méthodes
        private void SupprimerStage(object obj)
        {
            StageService.SupprimerStage(club, obj as StageModel);
            this.Stages.Remove(obj as StageModel);
            NotifyPropertyChanged("Stages");
        }


        #endregion
    }
}
