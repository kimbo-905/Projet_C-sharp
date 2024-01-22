using System.Collections.Generic;

namespace Projet_C_sharp
{
    public class Auteur
    {
        public string nom{ get; set; }
        public string biographie{ get; set; }
        public List<Livre> livreEcris{ get; set; }

        public Auteur(string nom, string biographie)
        {
            this.nom = nom;
            this.biographie = biographie;
            this.livreEcris = new List<Livre>();
        }
    }
}