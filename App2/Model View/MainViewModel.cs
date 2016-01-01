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
    class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {

        public MainViewModel()
        {
            Recherche = new RelayCommand(NaviguerMenuJeu,ISConnectionCompleted);
        }

        public Boolean ISConnectionCompleted()
        {
            if ( Joueur.sexeStatic != null )
                return true;
            else return false;
        }


        public RelayCommand Recherche { get; set; }

        public event EventHandler ValiderRecherche;

        public void NaviguerMenuJeu()
        {
            ValiderRecherche(this, new EventArgs());
        }
        

        public static async Task GetJoueur()
        {
            try
            {
                Joueur.idJoueurStatic = 3;
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("http://cassebrique.azurewebsites.net/api/joueur/?idJoueur="+Joueur.idJoueurStatic);//,new FormUrlEncodedContent(values)
                String json = await response.Content.ReadAsStringAsync();

                Joueur joueur = Newtonsoft.Json.JsonConvert.DeserializeObject<Joueur>(json);
                Joueur.libPaysStatic = joueur.libPays;
                Joueur.lvlStatic = joueur.lvl;
                Joueur.nomPrenomStatic = joueur.nomPrenom;
                Joueur.sexeStatic = joueur.sexe;

                client = new HttpClient();
                response = await client.GetAsync("http://cassebrique.azurewebsites.net/api/experience/?idJoueur="+Joueur.idJoueurStatic);
                json = await response.Content.ReadAsStringAsync();
                Joueur.xpAccumuleeStatic = Convert.ToInt16(json);
            }
            catch (Exception e)
            {
                MessageDialog msgDialog = new MessageDialog("Une erreur s'est produite lors de la récupération du joueur", "Oooops...");
                await msgDialog.ShowAsync();
            }
        }
    }
}
