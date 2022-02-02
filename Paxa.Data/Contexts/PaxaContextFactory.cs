using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Paxa.Data.Contexts
{
    public class PaxaContextFactory : BaseContextFactory<PaxaContext>
    {

        public PaxaContextFactory()
        {
        }

        public override PaxaContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PaxaContext>();
            optionsBuilder.UseNpgsql(Configuration.GetValue<string>("DatabaseConnection"));

            return new PaxaContext(optionsBuilder.Options);
        }
    }
}
