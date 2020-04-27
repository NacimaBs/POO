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
    /// Classe regroupant L'ensemble des methodes lié aux paiements
    /// </summary>
    public abstract class PaiementService
    {
        /// <summary>
        /// Ajoute un paiement en attente
        /// </summary>
        public static void AjouterPaiement(ClubModel club,PaiementModel p)
        {
            if(!club.Paiements.Contains(p)) // On regarde si le paiement n'est pas déja present
            {
                club.Paiements.Add(p);
            }
           
        }
        /// <summary>
        /// Supprimer un paiement en attente
        /// </summary>
        public static void SupprimerPaiement(ClubModel club,PaiementModel p)
        {
            if(club.Paiements.Contains(p)) // On regarde si le paiement est present
            {
                club.Paiements.Remove(p);
            }
       
        }
        /// <summary>
        /// Retourne la liste des membres avec au moins un paiement en attente
        /// </summary>
        public static List<MembreModel> ListeMembrePaiementEnAttente(ClubModel club)
        {
           
            List<MembreModel> ListeDesMembresAvecPaiement = new List<MembreModel> { };

            foreach(PaiementModel p in club.Paiements) // On parcours l'ensmeble des paiments en attente du club
            {
                if(!ListeDesMembresAvecPaiement.Contains(p.Payeur)) // On ajoute le membre à la liste si il a un paiement en  attente
                {
                    ListeDesMembresAvecPaiement.Add(p.Payeur);
                }
            }
            return ListeDesMembresAvecPaiement;
        }
        /// <summary>
        /// Retourne la liste des paiements en attente du membre
        /// </summary>
        public static List<PaiementModel> PaiementMembre(ClubModel club,MembreModel m)
        {
            List<PaiementModel> paiementdumembre = new List<PaiementModel> { };
            if (m!=null)
            {
                foreach (PaiementModel p in club.Paiements) // On parcours l'ensmeble des paiments en attente du club
                {
                    if (p.Payeur.IdMembre == m.IdMembre) // Si le paiement concerne le membre
                    {
                        paiementdumembre.Add(p);
                    }
                }
            }
            

            return paiementdumembre;
        }
        /// <summary>
        /// Declare payer le paiement du stage et ajoute le membre au stage
        /// </summary>
        public static void PayerStage(ClubModel club,PaiementModel p)
        {
            if(p!=null)
            {
                SupprimerPaiement(club, p); // On supprime le piament des paiement en attente
                StageModel s = p.Nature as StageModel;
                if(s!=null)
                {
                    s.Participants.Add(p.Payeur); // On ajoute le membre aux participants du stage
                    StageService.ModifierStage(club, s); // on met le stage a jour
                }

            }

        }
        /// <summary>
        /// Retourne la valeur total des paiement en attente du membre
        /// </summary>
        public static double PaiementTotal(ClubModel club,MembreModel m)
        {
            double somme = 0;
            foreach(PaiementModel p in PaiementMembre(club,m))
            {
                somme += p.Montant;
            }
            return somme;

        }
    }
}
