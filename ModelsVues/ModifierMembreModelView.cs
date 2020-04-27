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
    class ModifierMembreModelView :BaseModelView
    {
        #region Attributs

        private MembreModel m;

        private string sauvegarderVisible = "Visible";

        #endregion

        #region Proprietés

        public MembreModel M
        {
            get { return m; }
            set
            {
                this.m = value;
                NotifyPropertyChanged();
            }
            
        }
        public ICommand ModifierMembreCommand { get; set; }
        public string SauvegarderVisible 
        {get { return sauvegarderVisible; }
            set
            {
                this.sauvegarderVisible = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        #region Constructeur
        public ModifierMembreModelView(ClubModel club,MembreModel membre)
        {
            this.club = club;
            M = membre;
            
            ModifierMembreCommand = new SimpleCommand(ModifierMembre);
        }
        #endregion

        #region Methodes
        private void ModifierMembre(object obj)
        {
            MembreService.ModifierMembre(club,M); ;

            SauvegarderVisible = "Hidden";
        }
        #endregion


    }
}
