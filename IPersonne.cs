using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clubtennismvvm.Models
{
    interface IPersonne
    {
        string Prenom { get; set; }
        string Nom { get; set; }
        DateTime DateDeNaissance { get; set; }
        string Adresse { get; set; }
        string Ville { get; set; }
        ESexe Sexe { get; set; }
        string NumeroDeTelephone { get; set; }

    }
}
