namespace TP4.Models
{
    public class Chauffeur
    {
        public int Id { get; set; }
        public string Nom { get; set; } =string.Empty;
        public string Prenom { get; set; }=string.Empty;
        public string? Couriel { get; set; } = string.Empty;
        public float SalaireHoraire { get; set; } 
        public DateTime DateNaissance { get; set; }
        public string NoLicence { get; set; } = string.Empty;
        public DateTime DateEmbauche { get; set; }
        public DateTime? DateFinEmbauche { get; set; }

        public List<Trajet>? TrajetsFormationRecue { get; set; }
    }
}
