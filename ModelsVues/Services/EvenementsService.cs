using Clubtennismvvm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clubtennismvvm.ModelsVues.Services
{       /// <summary>
        /// Classe regroupant L'ensemble des methodes lié aux evenements
        /// </summary>
    public abstract class EvenementsService
    {
            
        /// <summary>
        /// Renvoie true si l'évenement e2 est en conflit avec l'évenement e1
        /// </summary>
        public static bool Chevauchement(EvenementsModel e1,EvenementsModel e2)
        {
            DateTime dd1 = e1.DateDeDebut;
            DateTime dd2 = e2.DateDeDebut;
            DateTime df1 = e1.DateDeFin;
            DateTime df2 = e2.DateDeFin;
            if (dd1 < dd2 && dd2 < df1)
            {
                return true;
            }
            if (dd1 < df2 && df2 < df1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
