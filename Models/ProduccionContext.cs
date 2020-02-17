using Microsoft.EntityFrameworkCore;

namespace ApiASPLinux.Models
{
    public class ProduccionContext: DbContext
    {
        public ProduccionContext(DbContextOptions<ProduccionContext> options)
            : base(options)
        {
        }

        public DbSet<Operario> Operarios {get; set;}
    }
}