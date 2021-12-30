namespace Paxa.Views
{
    public class Membership
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OrganizationId { get; set; }
        public MembershipRole Role { get; set; }

        public Membership()
        {
        }
    }
}
