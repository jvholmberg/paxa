using System.ComponentModel.DataAnnotations;

namespace Paxa.Common.Entities
{
    public class Friendship
    {
        [Key]
        public int Id { get; set; }
        public int FromPersonId { get; set; }
        public int ToPersonId { get; set; }
        public int TypeId { get; set; }

        public virtual Person FromPerson { get; set; }
        public virtual Person ToPerson { get; set; }
        public virtual FriendshipType Type { get; set; }

        public Friendship()
        {
        }
    }
}
