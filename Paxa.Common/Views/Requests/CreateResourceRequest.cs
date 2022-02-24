namespace Paxa.Common.Views
{
    public class CreateResourceRequest
    {
        public int OrganizationId { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }

        public CreateResourceRequest()
        {
        }
    }
}
