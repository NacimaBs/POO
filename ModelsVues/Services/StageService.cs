using Clubtennismvvm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clubtennismvvm.ModelsVues.Services
{
    /// <summary>
    /// Classe regroupant L'ensemble des methodes lié aux stages
    /// </summary>
    public abstract class StageService
    {
        /// <summary>
        /// Retourne true si le membre participe au stage
        /// </summary>
        public static bool ParticipeAuStage(MembreModel m,StageModel s)
        {
            return s.Participants.Contains(m);
        }

        /// <summary>
        /// Modifie le stage 
        /// </summary>
        public static void ModifierStage(ClubModel club , StageModel s)
        {
            if(s!=null)
            {
                foreach (StageModel stage in club.ListeDesStages())
                {
                    if (stage.Id == s.Id)
                    {
                        club.Evenements.Remove(stage);
                        club.Evenements.Add(s);
                        break;
                    }
                }
            }

        }

        /// <summary>
        /// Ajoute un participant au stage
        /// </summary>
        public static void AjouterParticipant(ClubModel club, StageModel s, MembreModel m)
        {
            if (m != null)
            {


                if (!s.Participants.Contains(m))
                {
                    
                    PaiementModel p = new PaiementModel(s.CoutDuStage, m, s);
                    PaiementService.AjouterPaiement(club, p);
                   
                }

            }
        }
            
        /// <summary>
        /// Supprime un participant au stage 
        /// </summary>
        public static void SupprimerParticipant(ClubModel club, StageModel s, MembreModel m)
        {
            if (m != null)
            {
                List<PaiementModel> paiements = PaiementService.PaiementMembre(club, m);

                foreach (PaiementModel p in paiements) // On parcours la liste des paiements en attente du membre
                {
                    if (p.Nature is StageModel) // On regarde si il a postuler pour le stage si c'est le cas on valide le paiement
                    {
                        StageModel stage = p.Nature as StageModel;
                        if (stage.Id == s.Id)
                        {
                            PaiementService.SupprimerPaiement(club, p);
                            s.Participants.Remove(m);
                            ModifierStage(club, s);
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Ajoute un stage à la liste des evenenements
        /// </summary>
         public static void AjouterStage(ClubModel club,StageModel s)
        {  
            if(!club.Evenements.Contains(s))
            {
                club.Evenements.Add(s);
            }
           
        }

        /// <summary>
        /// Deprogramme le stage
        /// </summary>     
        public static void SupprimerStage(ClubModel club,StageModel s)
        {
            if (club.Evenements.Contains(s))
            {
                club.Evenements.Remove(s);
            }
        }

        /// <summary>
        /// Retourne true si le membre a postuler pour le stage mais n'a pas encore payer
        /// </summary>
        public static bool VeutParticiper(ClubModel club,StageModel s,MembreModel m)
        {
            if(m!=null)
            {
                List<PaiementModel> ListePaiementsEnAttenteDuMembre = PaiementService.PaiementMembre(club, m);
                foreach (PaiementModel p in ListePaiementsEnAttenteDuMembre) // On regarde si le membre à postuler pour le stage et doit le payer
                {
                    if (p.Nature is StageModel)
                    {
                        StageModel stage = p.Nature as StageModel;
                        if (stage.Id == s.Id) 
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            return false;

            

        }
    }
}
