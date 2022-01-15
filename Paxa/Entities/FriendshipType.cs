using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Paxa.Entities
{
    public class FriendshipType
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Friendship> Friendships { get; set; }

        public FriendshipType()
        {
        }
    }
}
