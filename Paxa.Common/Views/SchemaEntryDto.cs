namespace Paxa.Common.Views
{
    public class SchemaEntryDto
    {
        public int Id { get; set; }
        public int SchemaId { get; set; }
        public int StartHour { get; set; }
        public int StartMinute { get; set; }
        public int StartSecond { get; set; }
        public int EndHour { get; set; }
        public int EndMinute { get; set; }
        public int EndSecond { get; set; }
        public WeekdayDto Weekday { get; set; }

        public SchemaEntryDto()
        {
        }
    }
}
