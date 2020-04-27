using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clubtennismvvm.Models
{
    interface IEvenements
    {
        DateTime DateDeDebut { get; set; }
        DateTime DateDeFin { get; set; }

        int Id { get; set; }
    }
}
