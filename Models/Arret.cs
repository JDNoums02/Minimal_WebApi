
using System.Text.Json.Serialization;

namespace TP4.Models
{
    public class Arret
    {
        public int Id { get; set; }
        public Trajet? Trajet { get; set; }
        public int? TrajetId { get;set; } 
        public double Latitude {  get; set; }
        public double Longitude { get; set; }
        

        
    }

    
}