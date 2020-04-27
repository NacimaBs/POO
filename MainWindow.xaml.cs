using Clubtennismvvm.Models;
using Clubtennismvvm.ModelsVues;
using Clubtennismvvm.ModelsVues.Services;
using Clubtennismvvm.Vues;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Clubtennismvvm
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ClubModel club;
        const string FichierDir = @"../../../DonneeClub.bin";
        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists(FichierDir))
            {

                Stream openFileStream = File.OpenRead(FichierDir);
                BinaryFormatter deserializer = new BinaryFormatter();
                club = (ClubModel)deserializer.Deserialize(openFileStream);
                openFileStream.Close();
                if(club.Membres.Count!=0)
                {
                    int n=club.Membres[0].IdMembre;
                    foreach(MembreModel m in club.Membres)
                    {
                        if(m.IdMembre>n)
                        {
                            n = m.IdMembre;
                        }
                    }
                    MembreModel.Nmembre = n + 1;
                }
    else
                {
                    MembreModel.Nmembre = 0;
                }
                
                if(club.Equipes.Count!=0)
                {
                    int n = club.Equipes[0].IdEquipe;
                    foreach (EquipeModel e in club.Equipes)
                    {
                        if (e.IdEquipe > n)
                        {
                            n = e.IdEquipe;
                        }
                    }
                    EquipeModel.id = n + 1;
                }
                else
                {
                    EquipeModel.id = 0;
                }
                if(club.Evenements.Count!=0)
                {
                    
                    int n = club.Evenements[0].Id;
                    foreach (EvenementsModel e in club.Evenements)
                    {
                        if (e.Id > n)
                        {
                            n = e.Id;
                        }
                    }
                    EvenementsModel.id = n + 1;
                }
                else
                {
                    EvenementsModel.id = 0;
                }
                
            }
            else
            {
                club = new ClubModel();
                
                
            }
            ModelVuePrincipale principale = new ModelVuePrincipale(club);
           
            principale.CurrentControlViewModel = new AccueilModelView();
            principale.currentViewModel.club = club;
            DataContext = principale;



        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Stream SaveFileStream = File.Create(FichierDir);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(SaveFileStream, club);
            SaveFileStream.Close();
        }
    }
}
