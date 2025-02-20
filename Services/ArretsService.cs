using Microsoft.EntityFrameworkCore;
using TP4.Models;

namespace TP4.Services
{
    /// <summary>
    /// Service pour gérer les opérations liées aux arrêts.
    /// </summary>
    public class ArretsService(ApplicationDbContext db)
    {
        private readonly ApplicationDbContext _db = db;

        /// <summary>
        /// Constructeur du service Arrets.
        /// </summary>
        /// <param name="db">Instance de la base de données en mémoire.</param>


        /// <summary>
        /// Récupère un arrêt par son identifiant. Si l'arrêt est trouvé, les informations du trajet associé seront présentes, si le trajet existe.
        /// </summary>
        /// <param name="id">L'identifiant de l'arrêt à rechercher.</param>
        /// <returns>L'arrêt correspondant à l'identifiant ou null si non trouvé.</returns>
        public Arret? GetArretById(int id)
        {
            var arret = _db.Arrets.SingleOrDefault(arret => arret.Id == id);
            if (arret != null)
                arret.Trajet = _db.Trajets.SingleOrDefault(t => t.Id == arret.TrajetId);
                
            return arret;
        }

        /// <summary>
        /// Supprime un arrêt de la base de données.
        /// </summary>
        /// <param name="id">L'identifiant de l'arrêt à supprimer.</param>
        /// <returns>True si l'arrêt a été supprimé avec succès, sinon False.</returns>
        public bool DeleteArret(int id)
        {
            var arret = _db.Arrets.SingleOrDefault(arret => arret.Id == id);
            if (arret != null)
            {
                _db.Arrets.Remove(arret);
                _db.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
