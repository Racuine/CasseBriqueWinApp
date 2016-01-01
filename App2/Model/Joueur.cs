using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.Model
{
    public class Joueur
    {
        public Decimal idJoueur { get; set; }
        public string nomPrenom { get; set; }
        public string sexe { get; set; }
        public int xpAccumulee { get; set; }
        public string libPays { get; set; }
        public int lvl { get; set; }
        public static Decimal idJoueurStatic { get; set; }
        public static string nomPrenomStatic { get; set; }
        public static string sexeStatic { get; set; }
        public static int xpAccumuleeStatic { get; set; }
        public static string libPaysStatic { get; set; }
        public static int lvlStatic { get; set; }
    }
}
