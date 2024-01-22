using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Projet_C_sharp
{
    public class Bibliotheque
    {
        public List<Livre> Livres { get; set; }
        public List<Auteur> Auteurs { get; set; }
        public List<Emprunt> Emprunts { get; set; }

        public Bibliotheque()
        {
            Livres = new List<Livre>();
            Auteurs = new List<Auteur>();
            Emprunts = new List<Emprunt>();
        }
        
        public void AjouterLivre(Livre livre)
        {
            Livres.Add(livre);
        }
        
        public void AjouterAuteur(Auteur auteur)
        {
            Auteurs.Add(auteur);
        }
        
        public void EffectuerEmprunt(Livre livre, DateTime dateEmprunt, DateTime dateRetourPrevue)
        {
            if (livre.nombre_exemplaire > 0)
            {
                Emprunt emprunt = new Emprunt(dateEmprunt, dateRetourPrevue, livre);
                Emprunts.Add(emprunt);
                livre.nombre_exemplaire--;
                Console.WriteLine("Emprunt effectué avec succès.");
            }
            else
            {
                Console.WriteLine("Désolé, aucun exemplaire disponible pour l'emprunt de ce livre.");
            }
        }
        
        public void RetournerLivre(Emprunt emprunt)
        {
            emprunt.livreEmpruntee.nombre_exemplaire++;
            Emprunts.Remove(emprunt);
            Console.WriteLine("Livre retourné avec succès.");
        }
        public void AfficherLivresDisponibles()
        {
            Console.WriteLine("Liste des livres disponibles :");
            foreach (var livre in Livres.Where(l => l.nombre_exemplaire > 0))
            {
                Console.WriteLine($"{livre.titre} par {livre.auteur} - ISBN: {livre.isbn}, Exemplaires disponibles: {livre.nombre_exemplaire}");
            }
        }

        public void AfficherEmpruntsEnCours()
        {
            Console.WriteLine("Liste des emprunts en cours :");
            foreach (var emprunt in Emprunts)
            {
                Console.WriteLine($"Emprunt de {emprunt.livreEmpruntee.titre} par {emprunt.livreEmpruntee.auteur} - Date de retour prévue : {emprunt.dateEmpruntRetour}");
            }
        }
    }
}