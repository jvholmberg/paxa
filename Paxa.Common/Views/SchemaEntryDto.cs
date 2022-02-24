namespace Paxa.Common.Views
{
    public class SchemaEntryDto
    {
        public int Id { get; set; }
        public TimestampDto FromTimestamp { get; set; }
        public TimestampDto ToTimestamp { get; set; }
        public WeekdayDto Weekday { get; set; }
        public int SchemaId { get; set; }

        public SchemaEntryDto()
        {
        }
    }
}
