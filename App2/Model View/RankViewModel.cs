using App2.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media;

namespace App2.Model_View
{
    class RankViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public RelayCommand Recherche { get; set; }

        public event EventHandler ValiderRecherche;

        public void AfficherClassement () {
            ValiderRecherche(this, new EventArgs());
        }

        public Pays Pays { get;
            set; }

        public int Niveau
        {
            get
            {
                return niveau;
            }

            set
            {
                niveau = value;
            }
        }

        public static IEnumerable<Classement> ListeClassement
        {
            get
            {
                return listeClassement;
            }

            set
            {
                listeClassement = value;
            }
        }

        public RankViewModel()
        {
            Recherche = new RelayCommand(ClickRechercheClassement);
        }


        public static async Task InitializeAsync()
        {
            await GetPays();
        }

        public async void ClickRechercheClassement()
        {
            await GetClassement();
            AfficherClassement();
        }



        private static IEnumerable<Classement> listeClassement;
        
        
        private int niveau;


        public async Task GetClassement()
        {
            try
            {


                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("http://cassebrique.azurewebsites.net/api/classement/?niveau="+niveau+"&dateDebRech=2014-01-01&pays="+Pays.libelle);//,new FormUrlEncodedContent(values)
                String json = await response.Content.ReadAsStringAsync();

                var classements = Newtonsoft.Json.JsonConvert.DeserializeObject<Classement[]>(json);
                listeClassement = classements;
            }
            catch (Exception e)
            {
                MessageDialog msgDialog = new MessageDialog("Une erreur s'est produite lors de la récupération des classements", "Oooops...");
                await msgDialog.ShowAsync();
                listeClassement = null;
            }
        }

        /*
        ObservableCollection<FontFamily> fonts = new ObservableCollection<FontFamily>();
        fonts.Add(new FontFamily("Arial"));
        fonts.Add(new FontFamily("Courier New"));
        fonts.Add(new FontFamily("Times New Roman"));
     
        FontsCombo.DataContext = fonts;
        */

        public static IEnumerable<Pays> listePays { get; set; }

        public static async Task GetPays()
        {
            try
            {

                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("http://cassebrique.azurewebsites.net/api/pays/");//,new FormUrlEncodedContent(values)
                String json = await response.Content.ReadAsStringAsync();

                var pays = Newtonsoft.Json.JsonConvert.DeserializeObject<Pays[]>(json);
                listePays = pays;
            }
            catch (Exception e)
            {
                MessageDialog msgDialog = new MessageDialog("Une erreur s'est produite lors de la récupération des classements", "Oooops...");
                await msgDialog.ShowAsync();
            }
        }
    }
}
