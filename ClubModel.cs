using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Clubtennismvvm.Models
{
    /// <summary>
    /// Classe club permet d'instancier un club
    /// </summary>

    [Serializable()]
    public class ClubModel: BaseModel 
    {

        #region Attributs

        private string nom;

        private string ville;

        

        private BindingList<MembreModel> membres = new BindingList<MembreModel> { };

        private BindingList<PersonnelModel> personnels = new BindingList<PersonnelModel> { };

        private BindingList<EvenementsModel> evenements = new BindingList<EvenementsModel> { }; // Contient l'ensemble des evenements organisé par le club 

        private BindingList<PaiementModel> paiements = new BindingList<PaiementModel> { }; // Contient l'ensemble des paiements demandé aux membres par le club

        private BindingList<EquipeModel> equipes = new BindingList<EquipeModel>{ };

        

        

        #endregion

        #region Proprieté
        public string Nom
        {
            get { return this.nom; }
            set
            {
                this.nom = value;
                NotifyPropertyChanged();
            }
        }

        public string Ville
        {
            get { return this.ville; }
            set
            {
                this.ville = value;
                NotifyPropertyChanged();
            }
        }

        public BindingList<MembreModel> Membres
        {
            get { return this.membres; }
            set
            {
                this.membres = value;
                NotifyPropertyChanged();
            }
        }
        public BindingList<EquipeModel> Equipes
        {
            get { return this.equipes; }
            set
            {
                this.equipes = value;
                NotifyPropertyChanged();
            }
        }
        public BindingList<EvenementsModel> Evenements
        {
            get { return this.evenements; }
            set
            {
                this.evenements = value;
                NotifyPropertyChanged();
            }
        }
        public BindingList<PaiementModel> Paiements
        {
            get { return this.paiements; }
            set
            {
                this.paiements = value;
                NotifyPropertyChanged();
            }
        }


        public BindingList<PersonnelModel> Personnels
        {
            get { return this.personnels; }
            set
            {
                this.personnels = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        #region Constructeurs

        public ClubModel()
        {

        }

        #endregion

        #region Méthodes

        /// <summary>
        /// Retourne la liste liste des stages
        /// </summary>
        /// <returns></returns>
        public BindingList<StageModel> ListeDesStages()
        {
            BindingList<StageModel> ListeStage = new BindingList<StageModel> { };
            foreach(EvenementsModel  e in evenements)
            {
                if(e is StageModel)
                {
                    ListeStage.Add(e as StageModel);
                }
            }
            
            return ListeStage;
        }
        /// <summary>
        /// Retourne la liste liste des Competitions
        /// </summary>
        /// <returns></returns>
        public BindingList<CompetitionModel> ListeDesCompetitions()
        {
            BindingList<CompetitionModel> ListeCompetition = new BindingList<CompetitionModel> { };
            foreach (EvenementsModel e in evenements)
            {
                if (e is CompetitionModel)
                {
                    ListeCompetition.Add(e as CompetitionModel);
                }
            }

            return ListeCompetition;
        }

        #endregion


    }
}

