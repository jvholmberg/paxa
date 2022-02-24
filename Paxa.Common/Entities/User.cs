using System.ComponentModel.DataAnnotations;

namespace Paxa.Common.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int? PersonId { get; set; }

        public virtual Person Person { get; set; }
        public virtual ICollection<Membership> Memberships { get; set; }
        public virtual List<RefreshToken> RefreshTokens { get; set; }

        public User()
        {
        }
    }
}
