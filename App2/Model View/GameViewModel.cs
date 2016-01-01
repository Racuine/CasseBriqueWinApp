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

namespace App2.Model_View 
{
    class GameViewModel : ViewModelBase, INotifyPropertyChanged
    {

        //PAS CLEAN CODE CAR AURAIT DU ETRE DANS UNE LISTE MAIS BUGS RENCONTRE ET PERTE DE TEMPS

        public static int niveauJeuChoisiPourJoueur { get; set; }

        public RelayCommand NavigateNiveau1 { get; set; }
        public RelayCommand NavigateNiveau2 { get; set; }
        public RelayCommand NavigateNiveau3 { get; set; }
        public RelayCommand NavigateNiveau4 { get; set; }
        public RelayCommand NavigateNiveau5 { get; set; }
        public RelayCommand NavigateNiveau6 { get; set; }
        public RelayCommand NavigateNiveau7 { get; set; }
        public RelayCommand NavigateNiveau8 { get; set; }
        public RelayCommand NavigateNiveau9 { get; set; }
        public RelayCommand NavigateNiveau10 { get; set; }

        public GameViewModel()
        {

            NavigateNiveau1 = new RelayCommand(NaviguerJeu1, validerSiNiveauOKNiveau1 );
            NavigateNiveau2 = new RelayCommand(NaviguerJeu2, validerSiNiveauOKNiveau2);
            NavigateNiveau3 = new RelayCommand(NaviguerJeu3, validerSiNiveauOKNiveau3);
            NavigateNiveau4 = new RelayCommand(NaviguerJeu4, validerSiNiveauOKNiveau4);
            NavigateNiveau5 = new RelayCommand(NaviguerJeu5, validerSiNiveauOKNiveau5);
            NavigateNiveau6 = new RelayCommand(NaviguerJeu6, validerSiNiveauOKNiveau6);
            NavigateNiveau7 = new RelayCommand(NaviguerJeu7, validerSiNiveauOKNiveau7);
            NavigateNiveau8 = new RelayCommand(NaviguerJeu8, validerSiNiveauOKNiveau8);
            NavigateNiveau9 = new RelayCommand(NaviguerJeu9, validerSiNiveauOKNiveau9);
            NavigateNiveau10 = new RelayCommand(NaviguerJeu10, validerSiNiveauOKNiveau10);
        }

        public event EventHandler ValiderChoixNiveau;
        
        public Boolean validerSiNiveauOKNiveau1( )
        {
            return true;
        }
        public Boolean validerSiNiveauOKNiveau2()
        {
            if (Joueur.xpAccumuleeStatic > 100)
                return true;
            else
                return false;
        }
        public Boolean validerSiNiveauOKNiveau3()
        {
            if (Joueur.xpAccumuleeStatic > 200)
                return true;
            else
                return false;
        }
        public Boolean validerSiNiveauOKNiveau4()
        {
            if (Joueur.xpAccumuleeStatic > 300)
                return true;
            else
                return false;
        }
        public Boolean validerSiNiveauOKNiveau5()
        {
            if (Joueur.xpAccumuleeStatic > 400)
                return true;
            else
                return false;
        }
        public Boolean validerSiNiveauOKNiveau6()
        {
            if (Joueur.xpAccumuleeStatic > 500)
                return true;
            else
                return false;
        }
        public Boolean validerSiNiveauOKNiveau7()
        {
            if (Joueur.xpAccumuleeStatic > 600)
                return true;
            else
                return false;
        }
        public Boolean validerSiNiveauOKNiveau8()
        {
            if (Joueur.xpAccumuleeStatic > 700)
                return true;
            else
                return false;
        }
        public Boolean validerSiNiveauOKNiveau9()
        {
            if (Joueur.xpAccumuleeStatic > 800)
                return true;
            else
                return false;
        }
        public Boolean validerSiNiveauOKNiveau10()
        {
            if (Joueur.xpAccumuleeStatic > 900)
                return true;
            else
                return false;
        }

        public void NaviguerJeu1()
        {
            niveauJeuChoisiPourJoueur = 1;
            ValiderChoixNiveau(this, new EventArgs());
        }
        public void NaviguerJeu2()
        {
            niveauJeuChoisiPourJoueur = 2;
            ValiderChoixNiveau(this, new EventArgs());
        }
        public void NaviguerJeu3()
        {
            niveauJeuChoisiPourJoueur = 3;
            ValiderChoixNiveau(this, new EventArgs());
        }
        public void NaviguerJeu4()
        {
            niveauJeuChoisiPourJoueur = 4;
            ValiderChoixNiveau(this, new EventArgs());
        }
        public void NaviguerJeu5()
        {
            niveauJeuChoisiPourJoueur = 5;
            ValiderChoixNiveau(this, new EventArgs());
        }
        public void NaviguerJeu6()
        {
            niveauJeuChoisiPourJoueur = 6;
            ValiderChoixNiveau(this, new EventArgs());
        }
        public void NaviguerJeu7()
        {
            niveauJeuChoisiPourJoueur = 7;
            ValiderChoixNiveau(this, new EventArgs());
        }
        public void NaviguerJeu8()
        {
            niveauJeuChoisiPourJoueur = 8;
            ValiderChoixNiveau(this, new EventArgs());
        }
        public void NaviguerJeu9()
        {
            niveauJeuChoisiPourJoueur = 9;
            ValiderChoixNiveau(this, new EventArgs());
        }
        public void NaviguerJeu10()
        {
            niveauJeuChoisiPourJoueur = 10;
            ValiderChoixNiveau(this, new EventArgs());
        }
        
    }
}
