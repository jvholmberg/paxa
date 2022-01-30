using System.Collections.Generic;

namespace Paxa.Views
{
    public class AuthenticateResponse
    {
        public int UserId { get; set; }
        public int? PersonId { get; set; }
        public ICollection<Membership> Memberships { get; set; }
        public string Email { get; set; }
        public string JwtToken { get; set; }

        public AuthenticateResponse()
        {
        }
    }
}
