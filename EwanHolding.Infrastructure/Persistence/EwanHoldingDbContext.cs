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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureEntities(modelBuilder);
        }

        private void ConfigureEntities(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(x => x.FullName).IsRequired().HasMaxLength(100);
                //entity.HasIndex(x => x.FullName).IsUnique();

                entity.Property(x => x.Email).IsRequired().HasMaxLength(200);
                entity.HasIndex(x => x.Email).IsUnique();

                entity.Property(x => x.PasswordHash).IsRequired().HasMaxLength(100);

                entity.Property(x => x.IsActive).IsRequired();

                entity.Property(x => x.Role).IsRequired();
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(x => x.Name_Ar).IsRequired().HasMaxLength(200);
                entity.HasIndex(x => x.Name_Ar).IsUnique();
                
                entity.Property(x => x.Name_En).IsRequired().HasMaxLength(200);
                entity.HasIndex(x => x.Name_En).IsUnique();

                entity.Property(x => x.Description_Ar).IsRequired().HasMaxLength(2000);
                
                entity.Property(x => x.Description_En).IsRequired().HasMaxLength(2000);
                
                entity.Property(x => x.WebsiteUrl).HasMaxLength(500);
                //entity.HasIndex(x => x.WebsiteUrl).IsUnique();

                entity.Property(x => x.LogoUrl).IsRequired().HasMaxLength(500);
                //entity.HasIndex(x => x.LogoUrl).IsUnique();

                entity.Property(x => x.IsActive).IsRequired();
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(x => x.Name_Ar).IsRequired().HasMaxLength(200);
                entity.HasIndex(x => x.Name_Ar).IsUnique();

                entity.Property(x => x.Name_En).IsRequired().HasMaxLength(200);
                entity.HasIndex(x => x.Name_En).IsUnique();

                entity.Property(x => x.Description_Ar).IsRequired().HasMaxLength(2000);
                
                entity.Property(x => x.Description_En).IsRequired().HasMaxLength(2000);
                
                entity.HasOne(x => x.Company).WithMany().HasForeignKey(x => x.CompanyId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<CoreValue>(entity =>
            {
                entity.Property(x => x.Title_Ar).IsRequired().HasMaxLength(200);
                entity.HasIndex(x => x.Title_Ar).IsUnique();

                entity.Property(x => x.Title_En).IsRequired().HasMaxLength(200);
                entity.HasIndex(x => x.Title_En).IsUnique();

                entity.Property(x => x.Description_Ar).IsRequired().HasMaxLength(2000);

                entity.Property(x => x.Description_En).IsRequired().HasMaxLength(2000);

                entity.Property(x => x.IconUrl).IsRequired().HasMaxLength(500);
                //entity.HasIndex(x => x.IconUrl).IsUnique();

                entity.Property(x => x.DisplayOrder).IsRequired();
                //entity.HasIndex(x => x.DisplayOrder).IsUnique();
            });

            modelBuilder.Entity<Stat>(entity =>
            {
                entity.Property(x => x.Label_Ar).IsRequired().HasMaxLength(100);
                entity.HasIndex(x => x.Label_Ar).IsUnique();

                entity.Property(x => x.Label_En).IsRequired().HasMaxLength(100);
                entity.HasIndex(x => x.Label_En).IsUnique();

                entity.Property(x => x.Value).IsRequired().HasMaxLength(100);

                entity.Property(x => x.DisplayOrder).IsRequired();
                //entity.HasIndex(x => x.DisplayOrder).IsUnique();
            });
        }
    }
}
