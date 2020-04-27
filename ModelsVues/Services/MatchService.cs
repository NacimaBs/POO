using Clubtennismvvm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clubtennismvvm.ModelsVues.Services
{    /// <summary>
     /// Classe regroupant L'ensemble des methodes lié aux matches
     /// </summary>
    public class MatchService
    {
        /// <summary>
        /// Met à jour les resultats du matche
        /// </summary>
        public static void DeclarerMatch(ClubModel club, MatchModel m,bool resultat)
        {
            m.ClubEstVainqueur = resultat;
            m.EstAJouer = false;
            if (m is MatchDoubleModel)
            {
                MatchDoubleModel matchdouble = m as MatchDoubleModel;
                CompetiteurModel competiteur1 = matchdouble.ListejoueurDuClub[0];
                CompetiteurModel competiteur2 = matchdouble.ListejoueurDuClub[1];
                competiteur1.MatchesJoue.Add(matchdouble);
                competiteur2.MatchesJoue.Add(matchdouble);
                MiseAJourStatJoueur(club, competiteur1, matchdouble);
                MiseAJourStatJoueur(club, competiteur2, matchdouble);


            }
            else
            {
                MatchSimpleModel matchSimple = m as MatchSimpleModel;
                CompetiteurModel competiteur = matchSimple.JoueurDuClub;
                competiteur.MatchesJoue.Add(matchSimple);
                MiseAJourStatJoueur(club, competiteur, matchSimple);


            }
        }
        /// <summary>
        /// Met à jour les stats du joueur
        /// </summary>
        public static void MiseAJourStatJoueur(ClubModel club, CompetiteurModel competiteur, MatchModel m)
        {
            competiteur.NombreDeMatchJoues = competiteur.NombreDeMatchJoues + 1;

            if (m.ClubEstVainqueur)
            {
                    
                 competiteur.NombreDeMatchGagnes = competiteur.NombreDeMatchGagnes + 1;
                if (m is MatchDoubleModel)
                {
                    competiteur.NombreDePoint =competiteur.NombreDePoint+ 1;
                }
                else
                {
                    competiteur.NombreDePoint = competiteur.NombreDePoint + 2;
                }
                   


            }
            else
            {
                competiteur.NombreDeMatchPerdus = competiteur.NombreDeMatchPerdus + 1;


            }
            MembreService.ModifierMembre(club, competiteur);


        }

    } 
}
