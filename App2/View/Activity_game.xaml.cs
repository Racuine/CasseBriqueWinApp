using App2.Model_View;
using App2.View;
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

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace App2.Vues
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class Activity_game : Page
    {
        

        GamePlusScoreViewModel mainVM;

        public Activity_game()
        {
            this.InitializeComponent();
            mainVM = new GamePlusScoreViewModel();

            //on dit que le datacontext de la vue est le viewModel
            MainPanel.DataContext = mainVM;
            //S'abonner à l'évenement de ViewModel
            mainVM.ValiderScore += Game_Score;
        }

        //Méthode apellée lors de 'abonnement à l'event
        private void Game_Score(object sender, EventArgs e)
        {
            Frame.Navigate(typeof(Activity_game_score));
        }

    }
}
