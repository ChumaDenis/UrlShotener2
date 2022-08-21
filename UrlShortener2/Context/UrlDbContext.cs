using Microsoft.EntityFrameworkCore;
using UrlShortener2.Models;

namespace UrlShortener2.Context
{
    public class UrlDbContext:DbContext
    {
        public UrlDbContext(DbContextOptions<UrlDbContext> options) : base(options)
        {

        }

        public DbSet<UrlInfo> UrlInfos { get; set; }

    }
}
