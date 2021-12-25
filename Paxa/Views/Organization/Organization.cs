using System.Collections.Generic;

namespace Paxa.Views
{
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Location? Location { get; set; }
        public ICollection<int> ResourceIds { get; set; } = new List<int>();
        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();

        public Organization()
        {
        }
    }
}
