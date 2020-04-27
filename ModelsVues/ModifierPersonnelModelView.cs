using Clubtennismvvm.Models;
using Clubtennismvvm.ModelsVues.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Clubtennismvvm.ModelsVues
{
    public class ModifierPersonnelModelView:BaseModelView
    {
        #region Attributs

        private PersonnelModel p;

        private string sauvegarderVisible = "Visible";

        #endregion

        #region Proprietés

        public PersonnelModel P
        {
            get { return p; }
            set
            {
                this.p = value;
                NotifyPropertyChanged();
            }

        }
        public ICommand ModifierPersonnelCommand { get; set; }
        public string SauvegarderVisible
        {
            get { return sauvegarderVisible; }
            set
            {
                this.sauvegarderVisible = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        #region Constructeurs
        public ModifierPersonnelModelView(ClubModel club,PersonnelModel P)
        {
            this.club = club;
            this.P = P;
            ModifierPersonnelCommand = new SimpleCommand(ModifierPersonnel);
        }

        #endregion

        #region Méthodes
        private void ModifierPersonnel(object obj)
        {
            PersonnelService.ModifierPersonnel(club,P);
            SauvegarderVisible = "Hidden";
        }

        #endregion
    }
}
