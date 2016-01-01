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

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace App2.View
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class Activity_statistics_result : Page
    {
        public Activity_statistics_result()
        {
            this.InitializeComponent();
            HistoriqueListView.ItemsSource = StatViewModel.ListeScore;
        }
        

        private void RankingViewModel_AffichageClassement(object sender, EventArgs e)
        {
            Frame.Navigate(typeof(Activity_ranking_result));
        }

        private void AllerJouer(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Activity_level_game));
        }

        private void AllerOption(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Activity_game_option));
        }

        private void AllerStatistiques(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Activity_statistics));
        }
        private void AllerClassement(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Acticity_ranking));
        }
    }
}
