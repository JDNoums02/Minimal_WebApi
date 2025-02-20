using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TP4.Models;

namespace TP4.Services
{
    /// <summary>
    /// Service gérant les opérations liées aux trajets et aux arrêts.
    /// </summary>
    public class TrajetsService(ApplicationDbContext db)
    {
        private readonly ApplicationDbContext _db = db;

        /// <summary>
        /// Récupère tous les trajets.
        /// </summary>
        /// <returns>Liste de tous les trajets.</returns>
        public List<Trajet> GetAllTrajets() => 
            _db.Trajets.ToList();

        /// <summary>
        /// Récupère un trajet par son identifiant.
        /// </summary>
        /// <param name="idTrajet">Identifiant du trajet.</param>
        /// <param name="includeArrets">Indique si les arrêts doivent être inclus dans l'objet Trajet ou non.</param>
        /// <returns>Le trajet correspondant ou null si non trouvé.</returns>
        public Trajet? GetTrajetById(int idTrajet, bool? includeArrets)
        {
            var trajet = _db.Trajets.SingleOrDefault(traj => traj.Id == idTrajet);

            if (includeArrets == true && trajet!=null)
            {
                trajet.PointsArret=_db.Arrets.Where(t=>t.TrajetId == idTrajet).Include(x=>x.Trajet).ToList();
            }

            return trajet;
        }

        /// <summary>
        /// Crée un nouveau trajet avec comme valeur d'identifiant, le plus haut nombre existant des trajets +1
        /// </summary>
        /// <param name="trajet">Le trajet à créer.</param>
        /// <returns>Le trajet créé avec son nouvel identifiant.</returns>
        public Trajet CreateTrajet(Trajet trajet)
        {
            if (string.IsNullOrEmpty(trajet.Nom))
                throw new DbUpdateException();
            _db.Trajets.Add(trajet);

            _db.SaveChanges();

            return trajet;
        }

        /// <summary>
        /// Ajoute des arrêts à un trajet existant. Si un arrêt est en double dans la liste, il est ignoré.
        /// </summary>
        /// <param name="id">Identifiant du trajet.</param>
        /// <param name="arrets">Liste des arrêts à ajouter. Chaque arrêt est créé avec comme valeur d'identifiant, le plus haut nombre existant des arrêts +1 </param>
        /// <returns>Le trajet mis à jour ou null si le trajet n'existe pas.</returns>
        public Trajet? AddArretsToTrajet(int id, List<Arret> arrets)
        {
            var trajet = _db.Trajets.SingleOrDefault(trajet => trajet.Id == id);

            arrets = arrets.Distinct(new ArretEqualityComparer()).ToList();
            foreach (var arret in arrets)
            {
                if (!trajet.PointsArret.Any(arr => arr.Equals(arret)))
                {
                    arret.TrajetId = trajet.Id;
                    _db.Arrets.Add(arret);
                }
            }
            _db.SaveChanges();
            return trajet;
        }

        /// <summary>
        /// Récupère tous les arrêts d'un trajet spécifique.
        /// </summary>
        /// <param name="idTrajet">Identifiant du trajet.</param>
        /// <returns>Liste des arrêts du trajet.</returns>
        public List<Arret> GetArretsForTrajet(int idTrajet)
        {
            return _db.Arrets.Where(arret => arret.TrajetId == idTrajet).ToList();
        }

        /// <summary>
        /// Supprime un trajet et tous ses arrêts associés.
        /// </summary>
        /// <param name="id">Identifiant du trajet à supprimer.</param>
        /// <returns>True si le trajet a été supprimé, False sinon.</returns>
        public bool DeleteTrajet(int id)
        {
            Trajet trajet = GetTrajetById(id, true);
            if (trajet != null)
            {
                _db.Trajets.Remove(trajet);
                _db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
