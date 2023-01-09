using Domain.Entities;
using Domain.Entities.Authentication;
using Domain.Entities.Base;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Persistence.Contexts
{
    public class PersonelDbContext : IdentityDbContext<AppUser,AppRole,string>
    {
        public PersonelDbContext(DbContextOptions options) : base(options)
        {

        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            BaseEntityConfiguration();
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<DepartmanRol>()
            //    .HasKey(c => c.Id);
            //modelBuilder.Entity<DepartmanRol>()
            //    .HasOne(c => c.Departman)
            //    .WithMany(d => d.DepartmanRols)
            //    .HasForeignKey(c => c.DepartmanId);

            //modelBuilder.Entity<Personel>()
            //    .HasKey(c => c.Id);

            //modelBuilder.Entity<PersonelSirket>()
            //    .HasKey(h => h.Id);
            //modelBuilder.Entity<PersonelSirket>()
            //    .HasOne(c => c.Sube)
            //    .WithMany(d => d.PersonelSirkets)
            //    .HasForeignKey(c => c.SubeId);

            //modelBuilder.Entity<PersonelIzin>()
            //    .HasOne(c => c.Personel)
            //    .WithMany(d => d.PersonelIzins)
            //    .HasForeignKey(c => c.PersonelId);

            //modelBuilder.Entity<PersonelDeneyim>()
            //    .HasOne(c => c.Personel)
            //    .WithMany(d => d.PersonelDeneyims)
            //    .HasForeignKey(c => c.PersonelId);

            //modelBuilder.Entity<Departman>()
            //    .HasKey(h => h.Id);
            //modelBuilder.Entity<Departman>()
            //    .HasOne(c => c.Sube)
            //    .WithMany(d => d.Departman)
            //    .HasForeignKey(c => c.SubeId);

            //primary key identity
            base.OnModelCreating(modelBuilder);
        }

        //entities
        public DbSet<Departman> Departmans { get; set; }
        public DbSet<DepartmanRol> DepartmanRols { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<PersonelSigorta> PersonelSigortas { get; set; }
        public DbSet<PersonelAdres> PersonelAdres { get; set; }
        public DbSet<PersonelDeneyim> PersonelDeneyims { get; set; }
        public DbSet<PersonelEgitim> PersonelEgitims { get; set; }
        public DbSet<PersonelKimlik> PersonelKimliks { get; set; }
        public DbSet<Personeliletisim> Personeliletisims { get; set; }
        public DbSet<PersonelResim> PersonelResims { get; set; }

        public void BaseEntityConfiguration()
        {
            var entries = ChangeTracker.Entries()
                    .Where(e => e.Entity is BaseEntity && (
                            e.State == EntityState.Added
                            || e.State == EntityState.Modified));
            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdateDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreationDateTime = DateTime.Now;
                }
            }

        }
    }
}
