using App2.Model_View;
using App2.Vues;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App2
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        MainViewModel mainVM;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            init();
        }

        public async void init()
        {
            await MainViewModel.GetJoueur();
            mainVM.Recherche.RaiseCanExecuteChanged();
        }


        public MainPage()
        {
            this.InitializeComponent();
            mainVM = new MainViewModel();

            //on dit que le datacontext de la vue est le viewModel
            MainPanel.DataContext = mainVM;
            //S'abonner à l'évenement de ViewModel
            mainVM.ValiderRecherche += Main_game;
        }

        //Méthode apellée lors de 'abonnement à l'event
        private void Main_game(object sender, EventArgs e)
        {
            Frame.Navigate(typeof(Activity_level_game));
        }
        
    }
}
