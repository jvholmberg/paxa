using System.ComponentModel.DataAnnotations;

namespace Paxa.Entities
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }

        public virtual Organization Organization { get; set; }

        public Location()
        {
        }
    }
}
