using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.Model
{
    public class Pays
    {
        public int idPays { get; set; }
        public string libelle { get; set; }

        public static string TransformationPays(string pays)
        {
            pays = pays.Replace('_',' ');
            return pays;
        }
    }
}
