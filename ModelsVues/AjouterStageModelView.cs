using Clubtennismvvm.Models;
using Clubtennismvvm.ModelsVues.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Clubtennismvvm.ModelsVues
{
    class AjouterStageModelView :BaseModelView 
    {
        #region Attributs

        private string ajouteStage = "Visible";

        private string ajouteAutreStage = "Hidden";

        #endregion

        #region Proprietés
        public BindingList<MembreModel> Entraineurs { get; set; }

        public StageModel stage { get; set; }

        public string AjouteStage
        {
            get { return ajouteStage; }
            set
            {
                this.ajouteStage = value;
                NotifyPropertyChanged();
                this.ajouteAutreStage = "Visible";
                NotifyPropertyChanged("AjouteAutreStage");
                
            }
        }
        public string AjouteAutreStage
        {
            get { return ajouteAutreStage; }

        }

        public ICommand AjouterStageCommand { get; set; }
        #endregion

        public AjouterStageModelView(ClubModel club)
        {
            this.club = club;
            stage = new StageModel();
            Entraineurs = PersonnelService.ListeEntraineur(club);
            AjouterStageCommand = new SimpleCommand(AjouterStage);
        }

        private void AjouterStage(object obj)
        {
            StageService.AjouterStage(club,stage);
            AjouteStage = "Hidden";
        }

    }
}
