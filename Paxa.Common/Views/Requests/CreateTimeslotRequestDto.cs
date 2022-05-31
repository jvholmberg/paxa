namespace Paxa.Common.Views
{
    public class CreateTimeslotRequestDto
    {
        public int ResourceId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public CreateTimeslotRequestDto()
        {
        }
    }
}
