using Clubtennismvvm.Models;
using Clubtennismvvm.ModelsVues.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Clubtennismvvm.ModelsVues
{
    class ListeEquipeModelView :BaseModelView
    {
        public ICommand SupprimerEquipeCommand { get; set; }


        public ListeEquipeModelView(ClubModel club)
        {
            this.club = club;
            SupprimerEquipeCommand = new SimpleCommand(SupprimerEquipe); 
        }

        public void  SupprimerEquipe(object obj)
        {
            EquipeService.SupprimerEquipe(club, obj as EquipeModel);

        }
    }
}
