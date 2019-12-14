using Microsoft.EntityFrameworkCore;

namespace Assistant.DAL.Core.Models
{
    public class AssistantContext : DbContext
    {
        public AssistantContext(DbContextOptions<AssistantContext> options)
                : base(options)
        { }

        public DbSet<User> Users { get; set; }

        public DbSet<MoneyMovement> MoneyMovements { get; set; }
    }
}
