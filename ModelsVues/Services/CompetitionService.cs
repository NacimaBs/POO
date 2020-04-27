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
    /// Classe regroupant L'ensemble des methodes lié aux competitions
    /// </summary>
    public abstract class CompetitionService 
    {
        /// <summary>
        /// Ajoute une competition à la liste des competitions du club
        /// </summary>
        public static void AjouterCompetition(ClubModel club,CompetitionModel c)
        {
            c.Matches = InitialisationMatch(c); // On remplis la liste des matches de la competitions 
            if(!club.Evenements.Contains(c))
            {
                club.Evenements.Add(c);
            }
            
            foreach(CompetiteurModel competiteur in c.EquipeDuClub.ListeDeJoueur) // On ajoute le paiement de l'inscription à la competitionaux paiements en attente de ces joueurs
            {
                PaiementModel p = new PaiementModel(c.Cout, competiteur, c);
                PaiementService.AjouterPaiement(club,p);
            }
                        
        }
        /// <summary>
        /// Retourne true si l'ensemble des matches de la competitions on été joué
        /// </summary>
        public static bool CompetitionTerminer(ClubModel club,CompetitionModel competition)
        {
            
            foreach(MatchModel match in competition.Matches)
            {
                if(match.EstAJouer==true) // Si le matche n'est pas encore joué
                {
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// Deprogrammer competition
        /// </summary>
        public static void SupprimerCompetition(ClubModel club,CompetitionModel c)
        {
            if(club.Evenements.Contains(c))
            {
                club.Evenements.Remove(c);
                c.EquipeDuClub.NombreDePoint = c.EquipeDuClub.NombreDePoint - c.NombreDeJoueurParEquipe; // les points de malus pour une competition annulé
                EquipeService.ModifierEquipe(club, c.EquipeDuClub);
            }
        }

        /// <summary>
        /// Determine les matches à jouer pour une competition en remplissant la liste des matches de la competition
        /// </summary>
        public static BindingList<MatchModel> InitialisationMatch(CompetitionModel c)
        {

            Random random = new Random();
            int j = random.Next(0, c.NombreDeJoueurParEquipe);
            int NombreDeMatchDouble ; // Le nombre de match double qui serront potentiellement joué
            BindingList<MatchModel> MatchAJouer = new BindingList<MatchModel> { };
            List<CompetiteurModel> JoueurDejaPlacerClub = new List<CompetiteurModel> {  }; // Liste contenant les joueurs qui sont deja placé sur un match de la competition 
            if (c.NombreDeJoueurParEquipe > c.EquipeDuClub.ListeDeJoueur.Count) // Si l'équipe n'a pas assez de joueur
            {
                return MatchAJouer;
            }
            if (c.EstDouble) // Si la competition est double 
            {
                NombreDeMatchDouble = (c.NombreDeJoueurParEquipe/2);
                
                
                for (int i=0;i<NombreDeMatchDouble;i++) // On créer les matches doubles à jouer
                {
                    CompetiteurModel joueurClub = SelectioneJoueur(c.EquipeDuClub); // On selectionne deux joueurs de l'equipe du Club au hasard 

                    CompetiteurModel joueurClub2 = SelectioneJoueur(c.EquipeDuClub);


                    while (JoueurDejaPlacerClub.Contains(joueurClub2)) // On regarde si ils sont déja placé sur un match
                    {
                        joueurClub2 = SelectioneJoueur(c.EquipeDuClub);
                    }
                    JoueurDejaPlacerClub.Add(joueurClub2);
                    while (JoueurDejaPlacerClub.Contains(joueurClub))
                    {
                        joueurClub = SelectioneJoueur(c.EquipeDuClub);
                    }
                    JoueurDejaPlacerClub.Add(joueurClub); // On les considere comme déja sur un match
                    
                    MatchDoubleModel md = new MatchDoubleModel(c.EquipeDuClub, c.EquipeAdverse,joueurClub,joueurClub2); 
                    MatchAJouer.Add(md);
                }
                CompetiteurModel joueur = SelectioneJoueur(c.EquipeDuClub); 
                while(JoueurDejaPlacerClub.Contains(joueur)) // On place le joueur restant sur le match simple
                {
                    joueur = SelectioneJoueur(c.EquipeDuClub);
                }
                MatchSimpleModel matchSimple = new MatchSimpleModel(c.EquipeDuClub,c.EquipeAdverse,joueur);
                MatchAJouer.Add(matchSimple);
            }
            else
            {
                for(int i=0; i<c.NombreDeJoueurParEquipe; i++) // On creer les Matches Simple sur le meme principe que pour les matches doubles
                {
                    CompetiteurModel joueur = SelectioneJoueur(c.EquipeDuClub);
                    while (JoueurDejaPlacerClub.Contains(joueur))
                    {
                        joueur = SelectioneJoueur(c.EquipeDuClub);
                    }
                    JoueurDejaPlacerClub.Add(joueur);
                    MatchSimpleModel matchSimple = new MatchSimpleModel(c.EquipeDuClub, c.EquipeAdverse, joueur);
                    MatchAJouer.Add(matchSimple);
                }

            }
            return MatchAJouer;
        }

        /// <summary>
        /// Change les attributs du match pour le definir comme joué et en assignant le vainqueur
        /// </summary>
        public MatchModel JouerMatch(MatchModel m, bool clubestvainqueur)
        {
            m.EstAJouer = false;
            m.ClubEstVainqueur = clubestvainqueur;
            return m;

        }

        /// <summary>
        /// Change les attributs de la competition en mettant à jour le match 
        /// </summary>
        public CompetitionModel MiseAJourCompetition(CompetitionModel c,MatchModel m,bool clubestvainqueur) // Prend en parametre le match qui a été joué
        {
            MatchModel resultatmatch = JouerMatch(m, clubestvainqueur);
            c.Matches.Remove(m);
            c.Matches.Add(resultatmatch);
            return c;
        }
        /// <summary>
        /// Selectione un joueur au hasard dans une équipe
        /// </summary>
        public static CompetiteurModel SelectioneJoueur(EquipeModel e)
        {
            BindingList<CompetiteurModel> competiteurs = e.ListeDeJoueur;
            Random random = new Random();
            int i=random.Next(0, competiteurs.Count);
            return competiteurs[i];
        }

    }
}
