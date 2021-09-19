namespace Paxa.Views
{
    public class User
    {
        public int Id { get; set; }
        public int? PersonId { get; set; }
        public int? OrganizationId { get; set; }
        public string Email { get; set; }

        public User()
        {
        }
    }
}
