namespace Paxa.Common.Views
{
    public class SchemaDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public int OrganizationId { get; set; }
        public ICollection<int> ResourceIds { get; set; }
        public ICollection<SchemaEntryDto> SchemaEntries { get; set; }

        public SchemaDto()
        {
        }
    }
}
