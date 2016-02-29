using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Client
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Ville { get; set; }

        public string Nomcomplet
        {
            get
             {
                return Id+" "+ Nom + " " + Prenom + " " + Ville;
             }

            set { }
        }
    
}
