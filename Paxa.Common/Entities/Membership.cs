using System.ComponentModel.DataAnnotations;

namespace Paxa.Common.Entities
{
    public class Membership
    {
        [Key]
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public int OrganizationId { get; set; }
        public virtual MembershipRole Role { get; set; }
        public virtual User User { get; set; }
        public virtual Organization Organization { get; set; }

        public Membership()
        {
        }
    }
}
