using System;
namespace Projet_C_sharp
{
    public class Emprunt
    {
        public DateTime dateEmpruntInitial{ get; set; }
        public DateTime dateEmpruntRetour{ get; set; }
        public Livre livreEmpruntee{ get; set; }

        public Emprunt(DateTime dateEmpruntInitial, DateTime dateEmpruntRetour, Livre livreEmpruntee)
        {
            this.dateEmpruntInitial = dateEmpruntInitial;
            this.dateEmpruntRetour = dateEmpruntRetour;
            this.livreEmpruntee = livreEmpruntee;
        }
    }
}