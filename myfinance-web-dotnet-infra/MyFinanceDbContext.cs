using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet_domain.Entities;

namespace myfinance_web_dotnet_infra;

public class MyFinanceDbContext : DbContext
{
    public DbSet<PlanoConta> PlanoConta {get; set; }
    public DbSet<Transacao> Transacao {get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=127.0.0.1,1433;Database=myfinance;User Id=sa;Password=MyStrong@Passw0rd;Encrypt=False;Trusted_Connection=False;TrustServerCertificate=False;");
    }
}
