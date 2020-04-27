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
    /// Classe regroupant L'ensemble des methodes lié aux personnel
    /// </summary>
    public abstract class PersonnelService
    {
        /// <summary>
        ///  Ajoute une personne au personnel du club
        /// </summary>
        public static void AjouterPersonnel(ClubModel club,PersonnelModel P)
        {
            if(!club.Personnels.Contains(P))
            {
                club.Personnels.Add(P);
            }
            
        }
        /// <summary>
        ///  Supprime une personne du personnel du club
        /// </summary>
        public static void SupprimerPersonnel(ClubModel club,PersonnelModel p)
        {
            if (club.Personnels.Contains(p))
            {
                club.Personnels.Remove(p);

            }
        }
        /// <summary>
        ///  Modifie un personnel du club
        /// </summary>
        public static void ModifierPersonnel(ClubModel club,PersonnelModel P)
        {
            if(P!=null)
            {
                foreach (PersonnelModel p in club.Personnels)
                {
                    if (p.IdMembre == P.IdMembre)
                    {
                        club.Personnels.Remove(p);
                        club.Personnels.Add(P);
                        break;
                    }
                }
            }

        }
        /// <summary>
        ///  Retourne la liste des entraineurs du club
        /// </summary>
        public static BindingList<MembreModel> ListeEntraineur(ClubModel club)
        {
            BindingList<MembreModel> listeentraineur = new BindingList<MembreModel> { };
            foreach(PersonnelModel p in club.Personnels )
            {
                if(p.EstEntraineur)
                {
                    listeentraineur.Add(p);
                }
            }
            return listeentraineur;
        }
    }
}
