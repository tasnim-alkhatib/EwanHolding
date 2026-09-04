using Microsoft.EntityFrameworkCore;
using EwanHolding.Domain.Entities;

namespace EwanHolding.Infrastructure.Persistence
{
    public class EwanHoldingDbContext : DbContext
    {
        public EwanHoldingDbContext(DbContextOptions<EwanHoldingDbContext> options) : base(options) { }

        public DbSet<Company> Companies => Set<Company>();
        public DbSet<News> News => Set<News>();
        public DbSet<Contact> Contacts => Set<Contact>();
        public DbSet<Media> Medias => Set<Media>();
        public DbSet<CoreValue> CoreValues => Set<CoreValue>();
        public DbSet<Stat> Stats => Set<Stat>();
        public DbSet<Service> Services => Set<Service>();
        public DbSet<TermsAndConditions> TermsAndConditions => Set<TermsAndConditions>();
        public DbSet<InvestmentOpportunities> InvestmentOpportunities => Set<InvestmentOpportunities>();
        public DbSet<Admin> Admins => Set<Admin>();
        public DbSet<PageContent> PageContents => Set<PageContent>();
    }
}
