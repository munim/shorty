using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Shorty.Core.Data.Objects;
using Shorty.Data.Data.Objects;
using Shorty.Data.DataObjects;

namespace Shorty.Core.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Url> Urls { get; set; }
        public DbSet<VisitLog> VisitLogs { get; set; }
    }
}
