using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Paxa.Entities
{
    public class RatingType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }

        public RatingType()
        {
        }
    }
}
