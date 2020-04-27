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
    class PaiementsMembreModelView : BaseModelView
    {
        #region Attributs

        private BindingList<PaiementModel> paiementsEnAttentes = new BindingList<PaiementModel> { };

        private MembreModel copiemembre;

        #endregion

        #region Proprietés 
        public ICommand DeclarerPayeCommand { get; set; }
        public MembreModel CopieMembre{ get; set; }

        public BindingList<PaiementModel> PaiementsEnAttentes
        {
            get {return this.paiementsEnAttentes; }
            set
            {
                this.paiementsEnAttentes = value;
                NotifyPropertyChanged();
            }

        }

        #endregion

        #region Constructeurs

        public PaiementsMembreModelView(ClubModel club,int id)
        {
            this.club = club;
            
            Initialisation(id);
            DeclarerPayeCommand = new SimpleCommand(DeclarerPaye);
        }

        #endregion

        #region Methodes

        private void DeclarerPaye(object obj)
        {
            PaiementModel p = obj as PaiementModel;
            PaiementService.PayerStage(club, p);
            PaiementsEnAttentes.Remove(p);

        }

        private void Initialisation(int id)
        {
            foreach(MembreModel m in club.Membres)
            {
                if(m.IdMembre==id)
                {
                    CopieMembre = m;
                }
            }
            foreach(PaiementModel p in PaiementService.PaiementMembre(club,CopieMembre))
            {
                paiementsEnAttentes.Add(p);
            }
        }

        #endregion

    }
}
