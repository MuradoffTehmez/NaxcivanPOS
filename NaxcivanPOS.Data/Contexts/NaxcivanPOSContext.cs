using Microsoft.EntityFrameworkCore;
using NaxcivanPOS.Entities.Models;

namespace NaxcivanPOS.Data.Contexts
{
    /// <summary>
    /// NaxcivanPOS məlumat bazası konteksti
    /// </summary>
    public class NaxcivanPOSContext : DbContext
    {
        public NaxcivanPOSContext(DbContextOptions<NaxcivanPOSContext> options) : base(options) { }

        public NaxcivanPOSContext() { }

        public DbSet<Mehsul> Mehsullar { get; set; }
        public DbSet<Satis> Satislar { get; set; }
        public DbSet<MehsulKateqoriyasi> MehsulKateqoriyalari { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Using in-memory database for testing to avoid LocalDB issues
                // For production, you would configure a real database connection
                optionsBuilder.UseInMemoryDatabase("NaxcivanPOS");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mehsul cədvəli konfiqurasiyası
            modelBuilder.Entity<Mehsul>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Ad).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Qiymet).HasColumnType("decimal(18,2)");
                entity.Property(e => e.YaradilmaTarixi).HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.SonGuncellemeTarixi).HasDefaultValueSql("GETDATE()");
                
                // Əlaqələr
                entity.HasOne(m => m.Kateqoriya)
                      .WithMany()
                      .HasForeignKey(m => m.KateqoriyaId)
                      .OnDelete(DeleteBehavior.SetNull);
            });

            // Satis cədvəli konfiqurasiyası
            modelBuilder.Entity<Satis>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ToplamQiymet).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Tarix).HasDefaultValueSql("GETDATE()");
                
                // Əlaqələr
                entity.HasOne(s => s.Mehsul)
                      .WithMany()
                      .HasForeignKey(s => s.MehsulId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // MehsulKateqoriyasi cədvəli konfiqurasiyası
            modelBuilder.Entity<MehsulKateqoriyasi>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Ad).IsRequired().HasMaxLength(100);
                entity.Property(e => e.YaradilmaTarixi).HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.SonGuncellemeTarixi).HasDefaultValueSql("GETDATE()");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}