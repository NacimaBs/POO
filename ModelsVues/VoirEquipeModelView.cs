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
   public class VoirEquipeModelView : BaseModelView
    {
        #region Attributs

        private EquipeModel equipe;

        private BindingList<CompetiteurModel> joueursEquipe=new BindingList<CompetiteurModel> { };

        private BindingList<CompetiteurModel> membresDispo = new BindingList<CompetiteurModel> { };

        private CompetiteurModel membreSelectione;

        private CompetiteurModel joueurSelectione;

        #endregion

        #region Proprietés 

        public ICommand AjouterJoueurCommand{ get; set; }

        public ICommand SupprimerJoueurCommand { get; set; }

        public BindingList<CompetiteurModel> JoueursEquipe
        {
            get { return this.joueursEquipe; }
            set
            {
                this.joueursEquipe = value;
                NotifyPropertyChanged();
            }
        }
        public BindingList<CompetiteurModel> MembresDispo
        {
            get { return this.membresDispo; }
            set
            {
                this.membresDispo = value;
                NotifyPropertyChanged();
            }
        }
        public EquipeModel Equipe
        {
            get {return  this.equipe; }
            set
            {
                this.equipe = value;
                NotifyPropertyChanged();
            }
        }

        public CompetiteurModel MembreSelectione

        {
            get { return this.membreSelectione; }
            set
            {
                this.membreSelectione = value;
                NotifyPropertyChanged();
            }
        }        
        public CompetiteurModel JoueurSelectione

        {
            get { return this.joueurSelectione; }
            set
            {
                this.joueurSelectione = value;
                NotifyPropertyChanged();
            }
        }
        
        #endregion

        #region Constructeurs

        public VoirEquipeModelView(ClubModel club,EquipeModel e)
        {
            this.club = club;
            this.equipe = e;
            Initialisation();
         
        }


        #endregion

        #region Methodes

        private void SupprimerJoueur(object obj)
        {
            MembresDispo.Add(JoueurSelectione);
            
            EquipeService.SupprimerJoueurEquipe(club, JoueurSelectione);
            JoueursEquipe.Remove(JoueurSelectione);


        }
        private void AjouterJoueur(object obj)
        {
            JoueursEquipe.Add(MembreSelectione);
            EquipeService.AjouterJoueur(club,Equipe, MembreSelectione);
            MembresDispo.Remove(MembreSelectione);


        }

        public void Initialisation()
        {
            Dictionary<string, int> Intclassement = new Dictionary<string, int> { };
            Intclassement.Add("-15", 0);
            Intclassement.Add("-4/6", 1);
            Intclassement.Add("-2/6", 2);
            Intclassement.Add("0", 3);
            Intclassement.Add("1/6", 4);
            Intclassement.Add("2/6", 5);
            Intclassement.Add("3/6", 6);
            Intclassement.Add("4/6", 7);
            Intclassement.Add("5/6", 8);
            Intclassement.Add("15", 9);
            Intclassement.Add("30", 15);
            Intclassement.Add("15/5", 14);
            Intclassement.Add("15/4", 13);
            Intclassement.Add("15/3", 12);
            Intclassement.Add("15/2", 11);
            Intclassement.Add("15/1", 10);
            Intclassement.Add("40", 21);
            Intclassement.Add("30/5", 20);
            Intclassement.Add("30/4", 19);
            Intclassement.Add("30/3", 18);
            Intclassement.Add("30/2", 17);
            Intclassement.Add("30/1", 16);
            foreach (CompetiteurModel c in MembreService.ListeCompetiteurDisponible(club))
            {
                if (c.Equipe == null && Intclassement[c.Classement] >= Intclassement[equipe.Niveau])
                {
                    this.membresDispo.Add(c);
                }
            }
            foreach(CompetiteurModel c in Equipe.ListeDeJoueur)
            {
                this.joueursEquipe.Add(c);
            }
            

            AjouterJoueurCommand = new SimpleCommand(AjouterJoueur);
            SupprimerJoueurCommand = new SimpleCommand(SupprimerJoueur);
        }

        #endregion

    }
}
