namespace TP4.Models
{
    public class Trajet
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public DateTime DateCreationTrajet { get; set; } = DateTime.Now;
        public DateTime DateDerniereModification { get; set; } = DateTime.Now;
        public List<Arret>? PointsArret { get; set; } = [];

        public List<Chauffeur>? ChauffeursFormes { get; set; } = [];
      
    }
}
