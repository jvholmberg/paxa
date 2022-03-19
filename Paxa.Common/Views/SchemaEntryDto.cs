namespace Paxa.Common.Views
{
    public class SchemaEntryDto
    {
        public int Id { get; set; }
        public string FromTimestamp { get; set; }
        public string ToTimestamp { get; set; }
        public WeekdayDto Weekday { get; set; }
        public int SchemaId { get; set; }

        public SchemaEntryDto()
        {
        }
    }
}
