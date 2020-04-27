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
    class ListePersonnelModelView:BaseModelView
    {

        #region Attributs

        private BindingList<PersonnelModel> staffs;

        #endregion

        #region Proprietés

        public BindingList<PersonnelModel> Staffs 
        { 
            get { return staffs; }
            set
            {
                this.staffs = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand SupprimerPersonnelCommand { get; set; }

        #endregion

        #region Constructeur

        public ListePersonnelModelView(ClubModel club)

        {
            this.club = club;
            this.Staffs = club.Personnels;
            SupprimerPersonnelCommand = new SimpleCommand(SupprimerPersonnel);
        }



        #endregion

        #region Méthodes

        private void SupprimerPersonnel(object obj)
        {
            PersonnelModel p = obj as PersonnelModel;
            PersonnelService.SupprimerPersonnel(club,p) ;
           
        }


        #endregion

    }
}
