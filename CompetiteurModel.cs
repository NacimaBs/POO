using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clubtennismvvm.Models
{
    [Serializable()]
    public class CompetiteurModel : MembreModel
    {
        #region Attributs

        private List<MatchModel> matchesJoue = new List<MatchModel> { };

        private EquipeModel equipeDuJoueur;

        private int nombreDePoint=0;

        private int nombreDeMatchJoue = 0;

        private int nombreDeMatchPerdus=0;

        private int nombreDeMatchGagnes = 0;

        #endregion

        #region Proprietés 

        public List<MatchModel> MatchesJoue
        {
            get { return this.matchesJoue; }
            set
            {
                this.matchesJoue = value;
                NotifyPropertyChanged();
            }
        }
        public EquipeModel Equipe
        {
            get { return this.equipeDuJoueur; }
            set
            {
                this.equipeDuJoueur = value;
                NotifyPropertyChanged();
            }
        }
        public int NombreDePoint
        {
            get { return this.nombreDePoint; }
            set
            {
                this.nombreDePoint = value;
                NotifyPropertyChanged();
            }
        }
        public int NombreDeMatchJoues
        {
            get { return this.nombreDeMatchJoue; }
            set
            {
                this.nombreDeMatchJoue = value;
                NotifyPropertyChanged();
            }
        }
        public int NombreDeMatchGagnes
        {
            get { return this.nombreDeMatchGagnes; }
            set
            {
                this.nombreDeMatchGagnes = value;
                NotifyPropertyChanged();
            }
        }
        public int NombreDeMatchPerdus
        {
            get { return this.nombreDeMatchPerdus; }
            set
            {
                this.nombreDeMatchPerdus= value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        #region Constructeurs

        public CompetiteurModel(MembreModel m)
        {
            this.adresse = m.Adresse;
            this.classement = m.Classement;
            this.competition = m.Competition;
            this.nom = m.Nom; 
            this.prenom = m.Prenom;
            this.numeroDeTelephone = m.NumeroDeTelephone;
            this.sexe = m.Sexe;
            this.dateDeNaissance = m.DateDeNaissance;
            this.ville = m.Ville;


        }
        #endregion

        #region Methodes

        #endregion
    }
}
