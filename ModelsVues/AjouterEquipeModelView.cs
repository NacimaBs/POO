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
    public class AjouterEquipeModelView:BaseModelView
    {
        #region Attributs

        private EquipeModel equipe;

        private BindingList<CompetiteurModel> listeDesCompetiteursSansEquipe = new BindingList<CompetiteurModel> { };

        private BindingList<CompetiteurModel> listeDesCompetiteursAAjouterALEquipe = new BindingList<CompetiteurModel> { };

        private List<PersonnelModel> listeDesEntraineurs=new List<PersonnelModel> { };

        private CompetiteurModel competiteurSelectione;

        private CompetiteurModel competiteurEquipeSelectione;

        private string buttonAjouter="Visible";


        #endregion

        #region Proprietés 

        #region Command
        public ICommand AjouterCompetiteurSCommand { get; set; }

        public ICommand SupprimerCompetiteurSCommand { get; set; }

        public ICommand AjouterEquipeCommand { get; set; }

        #endregion
        public string ButtonAjouter
        {
            get { return this.buttonAjouter; }
            set
            {
                this.buttonAjouter = value;
                NotifyPropertyChanged();
            }
        }

        public CompetiteurModel CompetiteurSelectione
        {
            get { return this.competiteurSelectione; }
            set
            {
                this.competiteurSelectione = value;
                NotifyPropertyChanged();
            }
        }
        public CompetiteurModel CompetiteurEquipeSelectione
        {
            get { return this.competiteurEquipeSelectione; }
            set
            {
                this.competiteurEquipeSelectione = value;
                NotifyPropertyChanged();
            }
        }
        public List<PersonnelModel> ListeDesEntraineurs
        {
            get { return this.listeDesEntraineurs; }
            set
            {
                this.listeDesEntraineurs = value;
                NotifyPropertyChanged();
            }
        }

        public IList<ECategorie> CategorieEnum
        {
            get { return Enum.GetValues(typeof(ECategorie)).Cast<ECategorie>().ToList<ECategorie>(); }
        }

        public BindingList<CompetiteurModel> ListeDesCompetiteursSansEquipe
        {
            get { return this.listeDesCompetiteursSansEquipe; }
            set
            {
                this.listeDesCompetiteursSansEquipe = value;
                NotifyPropertyChanged();
            }
        }


        public BindingList<CompetiteurModel> ListeDesCompetiteursAAjouterALEquipe
        {
            get { return this.listeDesCompetiteursAAjouterALEquipe; }
            set
            {
                this.listeDesCompetiteursAAjouterALEquipe = value;
                NotifyPropertyChanged();
            }
        }

        public EquipeModel Equipe
        {
            get { return this.equipe; }
            set
            {
                this.equipe = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        #region Constructeurs

        public AjouterEquipeModelView(ClubModel club)
        {
            this.club = club;
            Equipe = new EquipeModel();

            Initialisation();

        }

        #endregion
        
        #region Methodes

        public void Initialisation()
        {
          
            foreach (PersonnelModel e in PersonnelService.ListeEntraineur(club))
            {
                ListeDesEntraineurs.Add(e);
            }
            ListeDesCompetiteursSansEquipe = MembreService.ListeCompetiteurDisponible(club);

            AjouterCompetiteurSCommand = new SimpleCommand(AjouterCompetiteurS);
            SupprimerCompetiteurSCommand = new SimpleCommand(SupprimerCompetiteurS);
            AjouterEquipeCommand = new SimpleCommand(AjouterEquipe);

        }

        private void AjouterEquipe(object obj)
        {
            Equipe.ListeDeJoueur = listeDesCompetiteursAAjouterALEquipe;
            EquipeService.AjouterEquipe(club, Equipe);

            ButtonAjouter = "Hidden";
        }

        private void SupprimerCompetiteurS(object obj)
        {
            CompetiteurEquipeSelectione.Equipe = null;

            ListeDesCompetiteursSansEquipe.Add(CompetiteurEquipeSelectione);
            ListeDesCompetiteursAAjouterALEquipe.Remove(CompetiteurEquipeSelectione);
        }

        private void AjouterCompetiteurS(object obj)
        {
            CompetiteurSelectione.Equipe = Equipe;

            listeDesCompetiteursAAjouterALEquipe.Add(CompetiteurSelectione);
            ListeDesCompetiteursSansEquipe.Remove(CompetiteurSelectione);
        }


        #endregion
    }
}
