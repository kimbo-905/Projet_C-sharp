
namespace Projet_C_sharp
{
    public class Livre : IEmpruntable
    {
        public string titre { get; set; }
        public string auteur{ get; set; }
        public string isbn{ get; set; }
        public int nombre_exemplaire{ get; set; }

        public Livre(string titre, string auteur, string isbn, int nombreExemplaire)
        {
            this.titre = titre;
            this.auteur = auteur;
            this.isbn = isbn;
            nombre_exemplaire = nombreExemplaire;
        }

        public void Emprunter()
        {
            throw new System.NotImplementedException();
        }

        public void Retourner()
        {
            throw new System.NotImplementedException();
        }
    }
}