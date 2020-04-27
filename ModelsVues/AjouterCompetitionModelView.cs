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
    public class AjouterCompetitionModelView :BaseModelView
    {
        #region Attributs

        private CompetitionModel competition;

        private BindingList<EquipeModel> listeDesEquipes;

        private string buttonAjouter = "Visible";

        #endregion

        #region Proprietés 

        #region Command

        public ICommand AjouterCompetitionCommand { get; set; }

        #endregion

        #region Enum

        public IList<ECategorie> CategorieEnum
        {
            get { return Enum.GetValues(typeof(ECategorie)).Cast<ECategorie>().ToList<ECategorie>(); }
        }

        #endregion

        public CompetitionModel Competition
        {
            get { return this.competition; }
            set
            {
                this.competition = value;
                NotifyPropertyChanged();
            }
        }
        public BindingList<EquipeModel> ListeDesEquipes
        {
            get { return this.listeDesEquipes; }
            set
            {
                this.listeDesEquipes = value;
                NotifyPropertyChanged();
            }
        }

        public string ButtonAjouter
        {
            get { return this.buttonAjouter; }
            set
            {
                this.buttonAjouter = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        #region Constructeurs

        public AjouterCompetitionModelView(ClubModel club)
        {
            this.club = club;
            Initialisation();

        }

        #endregion

        #region Methodes

        private void Initialisation()
        {
            Competition = new CompetitionModel();
            ListeDesEquipes = club.Equipes;

            AjouterCompetitionCommand = new SimpleCommand(AjouterCompetition);
        }
        private void AjouterCompetition(object obj)
        {
            CompetitionService.AjouterCompetition(club,Competition);
            ButtonAjouter = "Hidden";
        }

        #endregion
    }
}
