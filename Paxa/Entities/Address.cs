using System.ComponentModel.DataAnnotations;

namespace Paxa.Entities
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string Street{ get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public Address()
        {
        }
    }
}
