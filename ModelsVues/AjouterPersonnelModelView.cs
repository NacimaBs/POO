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
    public class AjouterPersonnelModelView :BaseModelView
    {
        #region Attributs

        private string buttonVoirMembre = "Hidden";

        private string buttonAjouter= "Visible";

        private PersonnelModel personnel;

        #endregion

        #region Proprietés

        public PersonnelModel Personnel
        {
            get { return personnel; }
            set
            {
                this.personnel = value;
                NotifyPropertyChanged();

            }
        }
        public string ButtonVoirMembre
        {
            get { return buttonVoirMembre; }
            set
            {
                this.buttonVoirMembre = value;
                NotifyPropertyChanged();

            }
        }
        public string ButtonAjouter
        {
            get
            {
                return buttonAjouter;
            }
            set
            {
                this.buttonAjouter = value;
                NotifyPropertyChanged();
            }
        }

        #region Enum
        public IList<ESexe> SexeEnum
        {
            get { return Enum.GetValues(typeof(ESexe)).Cast<ESexe>().ToList<ESexe>(); }
        }
        public IList<EStatus> StatusEnum
        {
            get { return Enum.GetValues(typeof(EStatus)).Cast<EStatus>().ToList<EStatus>(); }
        }
        public IList<EPoste> PosteEnum
        {
            get { return Enum.GetValues(typeof(EPoste)).Cast<EPoste>().ToList<EPoste>(); }
        }

        #endregion

        #region ICommand

        public ICommand AjouterPersonnelCommand { get; set; }
        

        #endregion

        #endregion

        #region Constructeur

        public AjouterPersonnelModelView(ClubModel club)
        {
            this.club = club;
            Personnel = new PersonnelModel();
            AjouterPersonnelCommand = new SimpleCommand(AjouterPersonnel);
        }

        #endregion

        #region Methode

        private void AjouterPersonnel(object obj)
        {
            PersonnelService.AjouterPersonnel(club ,Personnel);
            ButtonAjouter = "Hidden";
            ButtonVoirMembre= "Visible";
        }

        #endregion

        
        
    }
}
