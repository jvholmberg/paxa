namespace Paxa.Common.Views
{
    public class MembershipDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OrganizationId { get; set; }
        public MembershipRoleDto Role { get; set; }

        public MembershipDto()
        {
        }
    }
}
