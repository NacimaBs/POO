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
    public class AjouterMembreModelView : BaseModelView ,INotifyPropertyChanged
    {
      
        #region Attributs

        private string buttonVoirMembre = "Hidden";

        private string buttonAjouter = "Visible";

        private double cotisation;


        #endregion

        #region Proprietés



        #region Command
        public ICommand AjouterMembreCommand { get; set; }

        #endregion

        #region  Model

        public MembreModel Membre { get; set; }

        #endregion

        #region View
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
        public double Cotisation
        {
            get { return this.cotisation; }
            set
            {
                this.cotisation = value;
                NotifyPropertyChanged();
            }
        }

        #region Enum
        public IList<ESexe> SexeEnum
        {
            get { return Enum.GetValues(typeof(ESexe)).Cast<ESexe>().ToList<ESexe>(); }
        }
        #endregion

        #endregion

        #endregion

        #region Constructeurs

        public AjouterMembreModelView(ClubModel club)
        {
            Membre = new MembreModel();
            this.club = club;
      
            AjouterMembreCommand = new SimpleCommand(AjouterMembre);
           
        }


        #endregion

        #region Methodes

        public void AjouterMembre(object parameters)
        {

                
            if(Membre.Competition)
            {
                CompetiteurModel c =new CompetiteurModel(Membre);
                MembreService.AjouterMembre(club,c);
            }
            else
            {
                MembreService.AjouterMembre(club,Membre);
            }
                ButtonAjouter = "Hidden";
                ButtonVoirMembre = "Visible";
                Cotisation = MembreService.CalculCotisation(Membre);
        }




        #endregion

    }


}
