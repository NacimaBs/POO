using Clubtennismvvm.Models;
using Clubtennismvvm.ModelsVues.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Clubtennismvvm.ModelsVues
{

    public class ListeMembreModelVue : BaseModelView
    {
        #region Attributs 
        private BindingList<MembreModel> membres;

        public delegate BindingList<MembreModel> DelegateTri(BindingList<MembreModel> Liste);

        private string estAfficherParCompetition = "";

        private string estAfficherParSexe = "";

        private string estAfficherParCotisation = "";

        private bool trieParAlphabetique = true;

        #endregion

        #region Proprietés

        public BindingList<MembreModel> Membres
        {
            get { return membres; }
            set
            {
                this.membres = value;
                NotifyPropertyChanged();
            }
        }

        public bool TrieParAlphabetique
        {
            get { return this.trieParAlphabetique; }
            set
            {
                this.trieParAlphabetique = value;

                NotifyPropertyChanged();
            }
        }
        public string EstAfficherParSexe
        {
            get { return estAfficherParSexe; }
            set
            {
                this.estAfficherParSexe = value;
                AfficherPar();
                if(trieParAlphabetique)
                {
                    TrierPar(Membres, MembreService.TriOdreAlphabetique);
                }
                else
                {
                    TrierPar(Membres, MembreService.TriClassement);
                }
            }
        }
        public string EstAfficherParCotisation
        {
            get { return estAfficherParCotisation; }
            set
            {
                this.estAfficherParCotisation = value;
                AfficherPar();
                if (trieParAlphabetique)
                {
                    TrierPar(Membres, MembreService.TriOdreAlphabetique);
                }
                else
                {
                    TrierPar(Membres, MembreService.TriClassement);
                }
            }
        }
        public string EstAfficherParCompetition
        {
            get { return estAfficherParCompetition; }
            set
            {
                this.estAfficherParCompetition = value;
                AfficherPar();
                if (trieParAlphabetique)
                {
                    TrierPar(Membres, MembreService.TriOdreAlphabetique);
                }
                else
                {
                    TrierPar(Membres, MembreService.TriClassement);
                }
            }

        }

        #region ICommand
        public ICommand SupprimerMembreCommand { get; set; }
        public ICommand AfficherParSexeCommand { get; set; }
        public ICommand AfficherParCotisationCommand { get; set; }
        public ICommand AfficherParCompetitionCommand { get; set; }
        public ICommand TrierParCommand { get; set; }

        #endregion

        #endregion

        #region Constructeur
        public ListeMembreModelVue(ClubModel club)
        {
            this.membres = club.Membres;
            this.club = club;

            TrierPar(Membres, MembreService.TriOdreAlphabetique);
            SupprimerMembreCommand = new SimpleCommand(SupprimerMembre);
            AfficherParSexeCommand = new SimpleCommand(AfficherParSexe);
            AfficherParCompetitionCommand = new SimpleCommand(AfficherParCompetition);
            AfficherParCotisationCommand = new SimpleCommand(AfficherParCotisation);
            TrierParCommand = new SimpleCommand(Tri);
        }
        #endregion

        #region Methodes
        private void SupprimerMembre(object obj)
        {
            MembreModel m = obj as MembreModel;
            MembreService.SupprimerMembre(club, m);
            membres.Remove(m);
            

        }

        private void Tri(Object obj)
        {
            if ((obj as String) == "Classement")
            {
                TrieParAlphabetique = false;
                TrierPar(Membres, MembreService.TriClassement);
            }
            else
            {
                TrieParAlphabetique = true;
                TrierPar(Membres, MembreService.TriOdreAlphabetique);
            }
        }
        
        private void TrierPar(BindingList<MembreModel> ListeATrier,DelegateTri MethodeDeTri)
        {

            Membres = MethodeDeTri(ListeATrier);

        }

        private void AfficherParCompetition(object obj)
        {
            EstAfficherParCompetition = obj.ToString();
        }
        private void AfficherParSexe(object obj)
        {
            EstAfficherParSexe = obj.ToString();
        }
        private void AfficherParCotisation(object obj)
        {
            EstAfficherParCotisation = obj.ToString();
        }
        private void AfficherPar()
        {

            Membres = club.Membres;
            BindingList<MembreModel> AfficherMembres = new BindingList<MembreModel> { };
            if (EstAfficherParCotisation != "")
            {
                foreach (MembreModel m in Membres)
                {
                    if (MembreService.CotisationAJour(club,m).ToString() == EstAfficherParCotisation)
                    {
                        AfficherMembres.Add(m);

                    }

                }
                Membres = AfficherMembres;
            }

            AfficherMembres = new BindingList<MembreModel> { };
            if (EstAfficherParCompetition != "" && EstAfficherParSexe != "")
            {
                foreach (MembreModel m in Membres)
                {
                    if (m.Sexe.ToString() == EstAfficherParSexe && m.Competition.ToString() == EstAfficherParCompetition)
                    {
                        AfficherMembres.Add(m);
                    }
                }
                Membres = AfficherMembres;
            }
            else
            {
                if (EstAfficherParCompetition != "")
                {
                    foreach (MembreModel m in Membres)
                    {
                        if (m.Competition.ToString() == EstAfficherParCompetition)
                        {
                            AfficherMembres.Add(m);
                        }
                    }
                    Membres = AfficherMembres;
                }
                else
                {
                    if (EstAfficherParSexe != "")
                    {
                        foreach (MembreModel m in Membres)
                        {
                            if (m.Sexe.ToString() == EstAfficherParSexe)
                            {
                                AfficherMembres.Add(m);
                            }
                        }
                        Membres = AfficherMembres;
                    }

                }

            }








        }

        #endregion
    }
} 






