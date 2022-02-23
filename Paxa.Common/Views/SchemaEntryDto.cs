namespace Paxa.Common.Views
{
    public class SchemaEntryDto
    {
        public int Id { get; set; }
        public TimestampDto FromTimestamp { get; set; }
        public TimestampDto ToTimestampId { get; set; }
        public WeekdayDto WeekdayId { get; set; }
        public int SchemaId { get; set; }

        public SchemaEntryDto()
        {
        }
    }
}
