using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Clubtennismvvm.Models
{
    [Serializable()]
    public class StageModel : EvenementsModel, IDataErrorInfo
    {


        #region Attributs

        private string nom;

        private int idStage;

        private MembreModel entraineurEncadrant;

        private List<MembreModel> participants = new List<MembreModel> { };

        private Double coutDuStage;

        private string trancheAge; // Sous la forme age - age 

        private string niveau; // Classement maximun atoriser pour participer au stage

        #endregion

        #region Propriete

        public string Nom
        {
            get { return nom; }

            set
            {
                this.nom = value;
                NotifyPropertyChanged();
            }
        }
        public MembreModel EntraineurEncadrant
        {
            get { return entraineurEncadrant; }
            set
            {
                this.entraineurEncadrant = value;
                NotifyPropertyChanged();
            }
        }
        public List<MembreModel> Participants
        {
            get { return participants; }
            set
            {
                this.participants = value;
                NotifyPropertyChanged();
            }
        }


        public double CoutDuStage
        {
            get { return coutDuStage; }
            set
            {
                this.coutDuStage = value;
                NotifyPropertyChanged();
            }
        }
        public string TrancheAge
        {
            get { return trancheAge; }
            set
            {
                this.trancheAge = value;
                NotifyPropertyChanged();
            }
        }
        public string Niveau
        {
            get { return niveau; }
            set
            {
                this.niveau = value;
                NotifyPropertyChanged();
            }
        }
        public int IdStage
            {
            get { return this.idStage; }

            }

        public string Error
        {
            get { return ""; }
        }





        #endregion

        #region Constructeur

        public StageModel()
        {
            
            this.idStage = id;
            id += 1;
        }
        public StageModel(double cout,string nom,string niveau):this()
        {
            this.coutDuStage = cout;
            this.nom = nom;
            this.niveau = niveau;
     
        }

        #endregion

        #region Verifications
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {

                    case "Nom":
                        {
                            if (string.IsNullOrEmpty(nom) || (!Regex.IsMatch(nom, "^[a-zA-Z- ]+$")))
                            {
                                return "Entrez un nom valide";
                            }
                            return "";
                        }
                    case "DateDeDebut":
                        {

                            DateTime dateref = DateTime.Now;

                            if (dateDeDebut <= dateref)
                            {
                                return "Entrez une date de debut valide";
                            }
                            return "";
                        }
                    case "DateDeFin":
                        {

                            

                            if (dateDeFin < dateDeDebut)
                            {
                                return "Entrez une date de fin valide";
                            }
                            return "";
                        }
                    case "TrancheAge":
                        {
                            if ((string.IsNullOrEmpty(trancheAge) || (!Regex.IsMatch(trancheAge, "^[0-9-]+$"))))
                            {
                                return "Entrez une tranche d'age valide";
                            }
                            return "";
                        }
                    case "Niveau":
                        {
                            if ((string.IsNullOrEmpty(Niveau) || (!Regex.IsMatch(Niveau, "^[0-9-/]+$"))))
                            {
                                return "Entrez une tranche de niveau valide";
                            }
                            return "";
                        }

                    case "CoutDuStage":
                        {

                            if ((String.IsNullOrEmpty(Convert.ToString(coutDuStage)) || (!Regex.IsMatch(Convert.ToString(coutDuStage), "^[0-9-]+$"))))
                            {
                                return "Entrez un cout valide";
                            }
                            return "";
                        }
                    default:
                        return "";

                }

            }
        }
        #endregion


 
    }
}
