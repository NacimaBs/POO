using Clubtennismvvm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clubtennismvvm.ModelsVues.Services
{
    /// <summary>
    /// Classe regroupant L'ensemble des methodes lié aux equipes
    /// </summary>
    public class EquipeService
    {
        /// <summary>
        /// Ajoute une equipe au club
        /// </summary>
        public static void AjouterEquipe(ClubModel club,EquipeModel e)
        {
            foreach(CompetiteurModel competiteur in e.ListeDeJoueur)
            {
                competiteur.Equipe = e;
                MembreService.ModifierMembre(club,competiteur);
            }
            club.Equipes.Add(e);

        }
        /// <summary>
        /// Ajoute le joueur à l'equipe
        /// </summary>
        public static void AjouterJoueur(ClubModel club,EquipeModel equipe,CompetiteurModel c)
        {
            equipe.ListeDeJoueur.Add(c);
            c.Equipe = equipe;
            ModifierEquipe(club, equipe);
        }
        /// <summary>
        /// Met à jour une equipe
        /// </summary>
        public static void ModifierEquipe(ClubModel club ,EquipeModel e)
        {
            foreach(EquipeModel equipe in club.Equipes)
            {
                if(equipe.IdEquipe==e.IdEquipe)
                {
                    club.Equipes.Remove(equipe);
                    club.Equipes.Add(e);
                    break;
                }
            }
        }
        /// <summary>
        /// Supprime un membre d'une equipe
        /// </summary>
        public static void SupprimerJoueurEquipe(ClubModel club, MembreModel m)
        {
            if (m is CompetiteurModel)
            {
                CompetiteurModel c = m as CompetiteurModel;
                EquipeModel equipe = MembreService.EquipeDuJoueur(club, c);
                equipe.ListeDeJoueur.Remove(c);
                c.Equipe = null;
                MembreService.ModifierMembre(club, c);
                EquipeService.ModifierEquipe(club, equipe);
            }


        }
        /// <summary>
        /// Supprime une equipe du club
        /// </summary>
        public static void SupprimerEquipe(ClubModel club,EquipeModel equipe)
        {
            foreach(CompetiteurModel c in equipe.ListeDeJoueur)
            {
                c.Equipe = null;
                MembreService.ModifierMembre(club, c);
            }
            club.Equipes.Remove(equipe);
        }
    }
}
