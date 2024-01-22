using System;
using System.Linq;

namespace Projet_C_sharp{
    internal class Program{
        public static void Main(string[] args){
            Bibliotheque bibliotheque = new Bibliotheque();

        // Ajout de livres et d'auteurs (à adapter selon vos besoins)
        Livre livre1 = new Livre("Bintou", "Aime Cesaire", "sac", 5);
        Livre livre2 = new Livre("Popo", "Kinpes Dupuit", "ok", 3);

        Auteur auteur1 = new Auteur("Mame Cheikh", "ok sans pour autant");
        Auteur auteur2 = new Auteur("Puipui Djema", "d'accord merci");

        auteur1.livreEcris.Add(livre1);
        auteur2.livreEcris.Add(livre2);

        bibliotheque.AjouterLivre(livre1);
        bibliotheque.AjouterLivre(livre2);
        bibliotheque.AjouterAuteur(auteur1);
        bibliotheque.AjouterAuteur(auteur2);

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Ajouter un livre");
            Console.WriteLine("2. Emprunter un livre");
            Console.WriteLine("3. Retourner un livre");
            Console.WriteLine("4. Afficher la liste des livres disponibles");
            Console.WriteLine("5. Afficher la liste des emprunts en cours");
            Console.WriteLine("6. Quitter");

            Console.Write("Choisissez une option (1-6) : ");
            string choix = Console.ReadLine();
            switch (choix)
            {
                case "1":
                {
                    Console.Write("Titre du livre : ");
                    string titre = Console.ReadLine();

                    Console.Write("Auteur du livre : ");
                    string auteur = Console.ReadLine();

                    Console.Write("ISBN du livre : ");
                    string isbn = Console.ReadLine();

                    Console.Write("Nombre d'exemplaires disponibles : ");
                    int nombreExemplaire;
                    while (!int.TryParse(Console.ReadLine(), out nombreExemplaire) || nombreExemplaire < 0)
                    {
                        Console.WriteLine("Veuillez entrer un nombre valide.");
                        Console.Write("Nombre d'exemplaires disponibles : ");
                    }
                    Livre nouveauLivre = new Livre(titre, auteur, isbn, nombreExemplaire);
                    bibliotheque.AjouterLivre(nouveauLivre);
                    Console.WriteLine($"Le livre \"{titre}\" a été ajouté à la bibliothèque avec succès.");
                }
                    break;
                
                case "2":
                    Console.Write("ISBN du livre à emprunter : ");
                    string isbnEmprunte = Console.ReadLine();
                    Livre livreEmpruntable = bibliotheque.Livres.FirstOrDefault(l => l.isbn == isbnEmprunte);

                    if (livreEmpruntable != null)
                    {
                        Console.Write("Date d'emprunt (format YYYY-MM-DD) : ");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime dateEmprunt))
                        {
                            Console.Write("Date de retour prévue (format YYYY-MM-DD) : ");
                            if (DateTime.TryParse(Console.ReadLine(), out DateTime dateRetourPrevue))
                            {
                                bibliotheque.EffectuerEmprunt(livreEmpruntable, dateEmprunt, dateRetourPrevue);
                            }
                            else
                            {
                                Console.WriteLine("Format de date incorrect. Opération annulée.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Format de date incorrect. Opération annulée.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Livre non trouvé dans la bibliothèque. Veuillez vérifier l'ISBN et réessayer.");
                    }
                    break;
                
                case "3":
                    Console.Write("ISBN du livre à retourner : ");
                    string isbnRendu = Console.ReadLine();
                    Emprunt empruntToReturn = bibliotheque.Emprunts.FirstOrDefault(e => e.livreEmpruntee.isbn == isbnRendu);
                    if (empruntToReturn != null)
                    {
                        bibliotheque.RetournerLivre(empruntToReturn);
                        Console.WriteLine("Opération de retour effectuée avec succès.");
                    }
                    else
                    {
                        Console.WriteLine("Aucun emprunt trouvé pour le livre avec l'ISBN spécifié. Veuillez vérifier l'ISBN et réessayer.");
                    }
                    break;

                case "4":
                    bibliotheque.AfficherLivresDisponibles();
                    break;

                case "5":
                    bibliotheque.AfficherEmpruntsEnCours();
                    break;
                
                case "6":
                    Environment.Exit(0);
                    break;
                
                default:
                    Console.WriteLine("Option non valide. Veuillez choisir une option valide.");
                    break;
            }
        }
        }
    }
}