using InvestApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvestApp.DataAccess
{
    public class InvestAppDbContext : DbContext
    {
        public InvestAppDbContext(DbContextOptions<InvestAppDbContext> options) : base(options) { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<CurrencyInvestment> CurrencyInvestments { get; set; }
        public virtual DbSet<MetalInvestment> MetalInvestments { get; set; }
    }
}
