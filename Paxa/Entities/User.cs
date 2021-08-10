using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Paxa.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int? PersonId { get; set; }
        public int? OrganizationId { get; set; }
        public virtual List<RefreshToken> RefreshTokens { get; set; }
        public virtual Person Person { get; set; }
        public virtual Organization Organization { get; set; }

        public User()
        {
        }
    }
}
