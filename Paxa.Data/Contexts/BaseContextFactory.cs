using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paxa.Data.Contexts
{
    public abstract class BaseContextFactory<T> : IDesignTimeDbContextFactory<T>
        where T: DbContext
    {
        protected IConfiguration Configuration { get; }

        public BaseContextFactory()
        {
            Configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(
                        "DatabaseConnection",
                        "User ID=postgres;Server=localhost;Database=paxa"),
                })
                .Build();

        }

        public abstract T CreateDbContext(string[] args);
    }
}
