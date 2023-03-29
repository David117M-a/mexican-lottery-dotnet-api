using Mexican_Lottery_dotnet_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Mexican_Lottery_dotnet_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Table>? Tables { get; set; }
        public DbSet<Card>? Cards { get; set; }
    }
}
