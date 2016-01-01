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
    class GamePlusScoreViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public GamePlusScoreViewModel()
        {
            Jouer = new RelayCommand(NaviguerMenuJeu);
        }

        public static int ScoreGenere { get; set; }
        public static int BonusGenere { get; set; }

        public int ScoreTotal
        {
            get
            {
                return getScoreTotal();
            }
        }

        public int getScoreTotal()
        {
            return ScoreGenere + BonusGenere;
        }

        public RelayCommand Jouer { get; set; }

        public event EventHandler ValiderScore;

        public void NaviguerMenuJeu()
        {
            GenererJeu();
            PostExperience();
            PostScore();
            ValiderScore(this, new EventArgs());
        }

        public void GenererJeu()
        {
            Random rnd = new Random();
            ScoreGenere = rnd.Next(30, 101);
            BonusGenere = rnd.Next(0,15);
        }
        

        public async void PostExperience()
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.PostAsync("http://cassebrique.azurewebsites.net/api/experience/?idJoueur=" + Joueur.idJoueurStatic+"&experienceGagnee="+ScoreGenere,null);
                Joueur.xpAccumuleeStatic += ScoreGenere;
            }
            catch (Exception e)
            {
                MessageDialog msgDialog = new MessageDialog("Une erreur s'est produite lors de l'envoi de votre experience", "Oooops...");
                await msgDialog.ShowAsync();
            }
        }


        public async void PostScore()
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.PostAsync("http://cassebrique.azurewebsites.net/api/historique/?score=" + getScoreTotal() + "&idJoueur=" 
                    + Joueur.idJoueurStatic + "&idNiveau=" + GameViewModel.niveauJeuChoisiPourJoueur, null);
            }
            catch (Exception e)
            {
                MessageDialog msgDialog = new MessageDialog("Une erreur s'est produite lors de l'envoi de votre score", "Oooops...");
                await msgDialog.ShowAsync();
            }
        }
        
    }
}
