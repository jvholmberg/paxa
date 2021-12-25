namespace Paxa.Views
{
    public class AuthenticateResponse
    {
        public int UserId { get; set; }
        public int? PersonId { get; set; }
        public int? OrganizationId { get; set; }
        public string Email { get; set; }
        public string JwtToken { get; set; }

        public AuthenticateResponse(Entities.User user, string jwtToken)
        {
            UserId = user.Id;
            PersonId = user.Person?.Id;
            OrganizationId = user.Organization?.Id;
            Email = user.Email;
            JwtToken = jwtToken;
        }
    }
}
