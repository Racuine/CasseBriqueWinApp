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
    class OptionViewModel : ViewModelBase, INotifyPropertyChanged
    {

        public List<string> ListSexe { get; set; }
        public OptionViewModel()
        {
            ValiderModification = new RelayCommand(ModifierLePays,PaysIsSelected);
            MiseAZero = new RelayCommand(MiseAZeroDuJoueur);
            Deconnexion = new RelayCommand(NaviguerVersConnection);
        }

        public event EventHandler RetourALaConnection;

        public void NaviguerVersConnection()
        {
            RetourALaConnection(this, new EventArgs());
        }

        public RelayCommand ValiderModification { get; set; }
        public RelayCommand MiseAZero { get; set; }
        public RelayCommand Deconnexion { get; set; }

        public Pays pays = new Pays();

        public Pays Pays
        {
            get
            {
                return pays;
            }
            set
            {
                ValiderModification.RaiseCanExecuteChanged();
                pays = value;
            }
        }

        public async void ModifierLePays()
        {
            Joueur.libPaysStatic = Pays.libelle;
            PostJoueur();
            MessageDialog msgDialog = new MessageDialog("Nouveau Pays : "+pays.libelle, "Modification");
            await msgDialog.ShowAsync();
        }

        public Boolean PaysIsSelected()
        {
            if (Pays != null)
                return true;
            else return false;
        }

        public async void MiseAZeroDuJoueur()
        {
            DeleteJoueur();
            Joueur.xpAccumuleeStatic = 0;
            Joueur.lvlStatic = 1;
            MessageDialog msgDialog = new MessageDialog("Votre compte a été remis à zéro", "Modification");
            await msgDialog.ShowAsync();
        }

        public async void PostJoueur()
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.PostAsync("http://cassebrique.azurewebsites.net/api/joueur/?idJoueurPost="+Joueur.idJoueurStatic+"&idPaysPost="+Pays.idPays, null);
            }
            catch (Exception e)
            {
                MessageDialog msgDialog = new MessageDialog("Une erreur s'est produite lors de l'envoi de votre nouveau pays", "Oooops...");
                await msgDialog.ShowAsync();
            }
        }

        public async void DeleteJoueur()
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.PostAsync("http://cassebrique.azurewebsites.net/api/joueur/?idJoueur=" + Joueur.idJoueurStatic, null);
            }
            catch (Exception e)
            {
                MessageDialog msgDialog = new MessageDialog("Une erreur s'est produite lors de l'envoi de votre nouveau pays", "Oooops...");
                await msgDialog.ShowAsync();
            }
        }
    }
}
