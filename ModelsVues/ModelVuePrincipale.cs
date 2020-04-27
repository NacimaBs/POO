using Clubtennismvvm.Models;
using Clubtennismvvm.ModelsVues.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Clubtennismvvm.ModelsVues
{
    public enum EStatus { Independant, Salarie }
    public enum EPoste { Entraineur, Administratif }
    
    public  class ModelVuePrincipale : BaseModelView 
    {
        #region Attributs 

        public BaseModelView currentViewModel;

        public ClubModel club { get; set; }
        

        #endregion

        #region Proprietés

        
        

        public BaseModelView CurrentControlViewModel {
            get { return currentViewModel; } 
            
            set
            {
                value.club = club;
                this.currentViewModel = value;
                
                NotifyPropertyChanged();
                    
            }
        }

        public ICommand ChangerDeVueCommand { get; set; }

        #endregion

        #region Constructeur

        public ModelVuePrincipale(ClubModel club)
        {
            this.club = club;
            ChangerDeVueCommand = new SimpleCommand(ChangerDeVue);
        }

        #endregion

        #region Méthodes

        public void ChangerDeVue(object parameters)
        {
            if (parameters != null)
            {
     
                    
           
                switch(parameters.ToString())
                {
                    case "AjouterMembre":
                        {
                            this.CurrentControlViewModel = new AjouterMembreModelView(club);
                            break;
                        }
                    case "ListeMembre":
                        {
                            this.CurrentControlViewModel = new ListeMembreModelVue(club);
                            break;
                        }
                    case "AjouterPersonnel":
                        {
                            this.CurrentControlViewModel = new AjouterPersonnelModelView(club);
                            break;
                        }
                    case "ListePersonnel":
                        {
                            this.CurrentControlViewModel = new ListePersonnelModelView(club);
                            break;
                        }
                    case "AjouterStage":
                        {
                            this.CurrentControlViewModel = new AjouterStageModelView(club);
                            break;
                        }
                    case "ListeStage":
                        {
                            this.CurrentControlViewModel = new ListeStageModelView(club);
                            break;
                        }
                    case "AjouterCompetition":
                        {
                            this.CurrentControlViewModel = new AjouterCompetitionModelView(club);
                            break;
                        }
                    case "ListePaiement":
                        {
                            this.CurrentControlViewModel = new PaiementEnAttentesModelView(club);
                            break;
                        }
                    case "ListeCompetition":
                        {
                            this.CurrentControlViewModel = new ListeCompetitionModelView(club);
                            break;
                        }
                    case "AjouterEquipe":
                        {
                            this.CurrentControlViewModel = new AjouterEquipeModelView(club);
                            break;
                        }
                    case "ListeEquipe":
                        {
                            this.CurrentControlViewModel = new ListeEquipeModelView(club);
                            break;
                        }
                    case "StatistiqueMembre":
                        {
                            this.CurrentControlViewModel = new StatistiqueMembreModelView(club);
                            break;
                        }


                    default:
                        {
                            if (parameters is PersonnelModel)
                            {
                                this.CurrentControlViewModel = new ModifierPersonnelModelView(club, parameters as PersonnelModel);
                                break;
                            }
                            if (parameters is MembreModel)
                            {
                                this.CurrentControlViewModel = new ModifierMembreModelView(club, parameters as MembreModel);
                                break;
                            }

                            if (parameters is int)
                            {
                                this.CurrentControlViewModel = new PaiementsMembreModelView(club,Int32.Parse(parameters.ToString()));
                                break;
                            }
                            if (parameters is CompetitionModel)
                            {
                                this.CurrentControlViewModel = new GestionMatchModelView(club,parameters as CompetitionModel);
                                break;
                            }
                            if (parameters is EquipeModel)
                            {
                                this.CurrentControlViewModel = new VoirEquipeModelView(club,parameters as EquipeModel);
                                break;            
                        
                          
                           }

             

                            else
                            {
                                this.CurrentControlViewModel = new ModifierParticipantModelView(club,parameters as StageModel);
                                break;
                            }
                            
                        }
                }
            }
 
            
  
            
            

        }

        #endregion

    }
}
