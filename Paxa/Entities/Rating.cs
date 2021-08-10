using System.ComponentModel.DataAnnotations;

namespace Paxa.Entities
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }
        public int Value { get; set; }
        public int TypeId { get; set; }
        // TODO: Change to userid instead and make user only be either person or organization, not both.
        public int? PersonId { get; set; }
        public int? OrganizationId { get; set; }
        public virtual RatingType Type { get; set; }
        public virtual Person Person { get; set; }
        public virtual Organization Organization { get; set; }

        public Rating()
        {
        }
    }
}
