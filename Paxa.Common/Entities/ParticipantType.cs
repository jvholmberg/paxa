using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Paxa.Common.Entities
{
    public class ParticipantType
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Participant> Participants { get; set; }

        public ParticipantType()
        {
        }
    }
}
