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
    public class PaiementEnAttentesModelView : BaseModelView
    {
        #region Attributs

        private BindingList<MembreModel> paiementParMembre=new BindingList<MembreModel> { };

 


        #endregion

        #region Proprietés 

      
        public BindingList<MembreModel> PaiementParMembre
        {
            get { return this.paiementParMembre; }
            set
            {
                this.paiementParMembre = value;
                NotifyPropertyChanged();
            }
        }


        #endregion

        #region Constructeurs

        public PaiementEnAttentesModelView(ClubModel club)
        {
            this.club = club;
            Initialisation();
         
        }


        #endregion

        #region Méthodes

        private void Initialisation()
        {
            foreach(MembreModel m in PaiementService.ListeMembrePaiementEnAttente(club))
            {
                paiementParMembre.Add(m);
                
            }
        }

        #endregion

    }
}
