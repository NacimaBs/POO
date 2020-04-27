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
    /// Classe regroupant L'ensemble des methodes lié aux membres
    /// </summary>
    public abstract class MembreService
    {
        /// <summary>
        /// Retourne les cotisation que le membre doit payer à son inscription
        /// </summary>
        public static double CalculCotisation(MembreModel m)
        {

            double cotisation = 0;
            if (EstMajeur(m))
            {
                if (m.Ville != "Paris")
                {
                    cotisation = 280;
                }
                else
                {
                    cotisation = 200;
                }

            }
            else
            {
                if (m.Ville != "Paris")
                {
                    cotisation = 180;
                }
                else
                {
                    cotisation = 130;
                }

            }
            if (m.Competition)
            {
                cotisation += 20;
            }

            return cotisation;

        }
        /// <summary>
        /// Ajoute un membre au club
        /// </summary>
        public static void AjouterMembre(ClubModel club,MembreModel m)
        {
            double montantcotisation = CalculCotisation(m);
            CotisationModel c = new CotisationModel(montantcotisation);
            PaiementModel p = new PaiementModel(montantcotisation, m, c);
            PaiementService.AjouterPaiement(club,p);
            club.Membres.Add(m);
        }
        /// <summary>
        /// Met à jour le membre
        /// </summary>
        public static void ModifierMembre(ClubModel club,MembreModel m)
        {
            foreach(MembreModel membre in club.Membres)
            {
                if(membre.IdMembre==m.IdMembre)
                {
                    club.Membres.Remove(membre);
                    club.Membres.Add(m);
                    break;
                }
            }
        }
        /// <summary>
        /// Supprime le membre du club
        /// </summary>
        public static void SupprimerMembre(ClubModel club,MembreModel m)
        {
            if (club.Membres.Contains(m))
            {
                club.Membres.Remove(m);
                foreach(PaiementModel p in PaiementService.PaiementMembre(club,m))
                {
                    PaiementService.SupprimerPaiement(club, p);

                }
                EquipeService.SupprimerJoueurEquipe(club, m);
                foreach(EvenementsModel evenement in EvenementsAuquelIlParticipe(club,m))
                {
                    if(evenement is StageModel)
                    {
                        StageModel stage = evenement as StageModel;
                        stage.Participants.Remove(m);
                        StageService.ModifierStage(club, stage);
                    }
                    
                }

            }
        }
        /// <summary>
        /// Retourne l'équipe du joueur
        /// </summary>
        public static EquipeModel EquipeDuJoueur(ClubModel club,CompetiteurModel c)
        {
            EquipeModel e=new EquipeModel();
            foreach(EquipeModel equipe in club.Equipes)
            {
                if(equipe.ListeDeJoueur.Contains(c)) // On regarde dans quelle equipe est le joueur
                {
                    e = equipe; 
                }
            }
            return e;

        }
        /// <summary>
        /// Retourn true si le membre est majeur
        /// </summary>
        public static bool EstMajeur(MembreModel m)
        {
            int age = DateTime.Now.Year - m.DateDeNaissance.Year;
            DateTime dateanniversaire = new DateTime(DateTime.Now.Year, m.DateDeNaissance.Month, m.DateDeNaissance.Day); ;
            if (dateanniversaire > DateTime.Now)
            {
                age--;
            }
            return (age >= 18);
        }
        /// <summary>
        /// Renvoie la liste des evenements(competition ,stage) auquel un membre participe
        /// </summary>
        public static List<EvenementsModel> EvenementsAuquelIlParticipe(ClubModel club,MembreModel m)
        {
            BindingList<EvenementsModel> evenements = club.Evenements;
            List<EvenementsModel> participe = new List<EvenementsModel> { };
            foreach(EvenementsModel e in evenements)
            {
                if(e is StageModel)
                {
                    StageModel s = e as StageModel;
                    if(StageService.ParticipeAuStage(m,s))
                    {
                        participe.Add(e);
                    }
                }
                if(e is CompetitionModel)
                {
                    CompetitionModel c = e as CompetitionModel;
                    if(c.EquipeDuClub.ListeDeJoueur.Contains(m))
                    {
                        participe.Add(c);
                    }
                }
            }
            return participe;
        }
        /// <summary>
        /// Retourne true si le membre est disponible pour l'evenement (ne participe pas déja à un evenement sur la meme période )
        /// </summary>
        public static bool EstDisponible(ClubModel club,MembreModel m,EvenementsModel e)
        {
            bool Dispo = true;
            List<EvenementsModel> events = EvenementsAuquelIlParticipe(club,m);
            foreach (EvenementsModel evenement in events)
            {
                Dispo = Dispo && (!EvenementsService.Chevauchement(evenement, e));
            }
            return Dispo;
        }

        /// <summary>
        /// Renvoie la liste des competiteurs du club
        /// </summary>
        public static BindingList<CompetiteurModel> ListeCompetiteur(ClubModel club)
        {
            BindingList<CompetiteurModel> competiteurs = new BindingList<CompetiteurModel> { };
            foreach(MembreModel m in club.Membres)
            {
                if(m is CompetiteurModel)
                {
                    competiteurs.Add(m as CompetiteurModel);
                }
            }
            return competiteurs;
        }
        /// <summary>
        /// Retourne la liste des competiteurs qui n'ont pas d'équipe
        /// </summary>
        public static BindingList<CompetiteurModel> ListeCompetiteurDisponible(ClubModel club)
        {
            BindingList<CompetiteurModel> competiteurs = new BindingList<CompetiteurModel> { };
            foreach (MembreModel m in club.Membres)
            {
                CompetiteurModel c = m as CompetiteurModel;
                if ((m is CompetiteurModel) && (c.Equipe==null)) // si c'ets un competiteur sans équipe
                {
                    competiteurs.Add(m as CompetiteurModel);
                }
            }
            return competiteurs;
        }
        /// <summary>
        /// Retourne la liste de membre trier par ordre alphabetique
        /// </summary>
        public static BindingList<MembreModel> TriOdreAlphabetique(BindingList<MembreModel> liste)
        {
            BindingList<MembreModel> ListeAtrie = liste;
        
            BindingList<MembreModel> ListeTrie = new BindingList<MembreModel> { };

            List<string> MembresTriebis = new List<string> { };
            Dictionary<int, MembreModel> Membresd = new Dictionary<int, MembreModel> { };
            foreach (MembreModel m in ListeAtrie) // On remplie le dictionaire qui sert à identifer les membres par leur id 
            {
                Membresd.Add(m.IdMembre, m);
                MembresTriebis.Add(m.Prenom + " " + m.Nom + " " + m.IdMembre); // On consitue une liste de string avec le "full name" du membre et de son id pour pouvoir l'identifier
            }
            MembresTriebis.Sort(); // methode sort qui permet de trier par ordre alphabetique les string 
            foreach (string s in MembresTriebis)
            {
                int id = Int32.Parse(s.Split(' ')[2]); 
                ListeTrie.Add(Membresd[id]); // on reconstruit la liste grace au dictionaire de correspondance id et membre
            }



            return ListeTrie ;
        }
         /// <summary>
        /// Retourne la liste de membre trier par classement
        /// </summary>
        public static BindingList<MembreModel> TriClassement(BindingList<MembreModel> liste)
        {
           
            List<MembreModel> Membres = new List<MembreModel> { };
            BindingList<MembreModel> ListeTrie = new BindingList<MembreModel> { };
            foreach (MembreModel m in liste)
            {
                Membres.Add(m);
            }
            Membres.Sort(); // On utilise la methode sort sur la listes des  membres qui trie par le classement grace à l'implementation de Icomparable
            foreach (MembreModel m in Membres)
            {
                ListeTrie.Add(m);
            }




            return ListeTrie;
        }
        /// <summary>
        /// Retourne true si le membre est à jour dans ses cotisations
        /// </summary>
        public static bool CotisationAJour(ClubModel club,MembreModel m)
        {
            
            foreach(PaiementModel p in PaiementService.PaiementMembre(club,m))
            {
                
                if(p.Nature is CotisationModel)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
