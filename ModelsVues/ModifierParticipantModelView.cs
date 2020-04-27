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
    class ModifierParticipantModelView :BaseModelView
    {
        #region Attributs

        private BindingList<MembreModel> membres =new BindingList<MembreModel> { };

        private BindingList<MembreModel> participants= new BindingList<MembreModel> { };

        private BindingList<MembreModel> participantsStage = new BindingList<MembreModel> { };

        private MembreModel membreSelectione;

        private MembreModel participantSelectione;

        private StageModel stage;

        #endregion

        #region Proprietés

        public BindingList<MembreModel> Membres
        {
            get { return this.membres; }
            set
            {
                this.membres = value;
                NotifyPropertyChanged();

            }
        }
       public MembreModel ParticipantSelectione
        {
            get { return this.participantSelectione; }
            set
            {
                this.participantSelectione = value;
                NotifyPropertyChanged();
            }
        }
        public BindingList<MembreModel> Participants
        {
            get { return this.participants; }
            set
            {
                this.participants = value;
                NotifyPropertyChanged();
            }
        }

        public MembreModel MembreSelectione
        {
            get { return this.membreSelectione; }
            set
            {
                this.membreSelectione = value;
                NotifyPropertyChanged();
            }
        }

        public BindingList<MembreModel> ParticipantsStage
        {
            get { return this.participantsStage; }
            set
            {
                this.participantsStage = value;
                NotifyPropertyChanged();
            }
        }

        public StageModel Stage
        {
            get { return this.stage; }
            set
            {
                this.stage = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand AjouterParticipantCommand { get; set; }

        public ICommand SupprimerParticipantCommand { get; set; }

        #endregion

        #region Constructeurs
        public ModifierParticipantModelView(ClubModel club,StageModel s)
        {
            this.club = club;
            stage = s;
            MiseAJourDesListe();
            AjouterParticipantCommand = new SimpleCommand(AjouterParticipant);
            SupprimerParticipantCommand = new SimpleCommand(SupprimerParticpant);
        }

        #endregion

        private void AjouterParticipant(object obj)
        {
            StageService.AjouterParticipant(club, stage, membreSelectione);
            Participants.Add(MembreSelectione);
            Membres.Remove(MembreSelectione);

        }
        private void SupprimerParticpant(object obj)
        {
            StageService.SupprimerParticipant(club, stage, participantSelectione); 
            Membres.Add(participantSelectione);
            if(ParticipantsStage.Contains(participantSelectione))
            {
                ParticipantsStage.Remove(participantSelectione);
            }
            if (Participants.Contains(participantSelectione))
            {
                Participants.Remove(participantSelectione);
            }


           
        }
        private void MiseAJourDesListe()
        {
            

            foreach (MembreModel m in club.Membres)
            {
                if (!StageService.VeutParticiper(club,stage,m) && MembreService.EstDisponible(club,m,stage) && !StageService.ParticipeAuStage(m,stage))
                {
                    Membres.Add(m);
                }
                if(StageService.VeutParticiper(club,stage,m))
                {
                    Participants.Add(m);
                }
                if(StageService.ParticipeAuStage(m,stage))
                {
                    ParticipantsStage.Add(m);
                }
            }

        }
    }
}
