using App2.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace App2.Model_View
{
    class StatViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public RelayCommand Recherche { get; set; }
        public event EventHandler ValiderRecherche;
        public NiveauMeilleurScore Statistiques { get; set; }
        public int Experience { get; set; }
        public static IEnumerable<Historique> ListeScore { get; set; }

        public StatViewModel()
        {
            Recherche = new RelayCommand(ClickRechercheStatistique);
        }


        public async Task InitializeAsync() {
            await GetExperience();
            await GetStatistiques();
        }

        public void AfficherStatistiques()
        {
            ValiderRecherche(this, new EventArgs());
        }

        public async void ClickRechercheStatistique()
        {
            await GetHistorique();
            AfficherStatistiques();
        }

        public async Task GetHistorique()
        {
            try
            {

                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("http://cassebrique.azurewebsites.net/api/historique/?idJoueur=" + Joueur.idJoueurStatic +"&niveau="+NiveauRecherche);
                String json = await response.Content.ReadAsStringAsync();

                var stats = Newtonsoft.Json.JsonConvert.DeserializeObject<Historique[]>(json);
                ListeScore = stats;
            }
            catch (Exception e)
            {
                MessageDialog msgDialog = new MessageDialog("Une erreur s'est produite lors de la récupération de l'historique", "Oooops...");
                await msgDialog.ShowAsync();
            }
        }

        public async Task GetStatistiques()
        {
            try
            {

                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("http://cassebrique.azurewebsites.net/api/historique/?idJoueur="+Joueur.idJoueurStatic);
                String json = await response.Content.ReadAsStringAsync();

                var stats = Newtonsoft.Json.JsonConvert.DeserializeObject<NiveauMeilleurScore>(json);
                Statistiques = stats;
            }
            catch (Exception e)
            {
            }
        }

        public async Task GetExperience()
        {
            try
            {

                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("http://cassebrique.azurewebsites.net/api/experience/?idJoueur="+Joueur.idJoueurStatic);
                String json = await response.Content.ReadAsStringAsync();
                Experience = Convert.ToInt16(json);
            }
            catch (Exception e)
            {

            }
        }


        public int NiveauRecherche { get;
            set; }

    }
}
