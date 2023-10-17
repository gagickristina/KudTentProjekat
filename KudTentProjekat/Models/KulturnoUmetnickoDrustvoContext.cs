using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KudTentProjekat.Models
{
    public partial class KulturnoUmetnickoDrustvoContext : DbContext
    {
        public KulturnoUmetnickoDrustvoContext()
        {
        }

        public KulturnoUmetnickoDrustvoContext(DbContextOptions<KulturnoUmetnickoDrustvoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clan> Clan { get; set; }
        public virtual DbSet<GodisnjaClanarina> GodisnjaClanarina { get; set; }
        public virtual DbSet<MesecnaClanarina> MesecnaClanarina { get; set; }
        public virtual DbSet<Placeno> Placeno { get; set; }
        public virtual DbSet<Privilegije> Privilegije { get; set; }
        public virtual DbSet<Priznanica> Priznanica { get; set; }
        public virtual DbSet<Sekcije> Sekcije { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-HFNP9LL\\SQLEXPRESS;Database=KulturnoUmetnickoDrustvo;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clan>(entity =>
            {
                entity.HasKey(e => e.Idclana);

                entity.Property(e => e.Idclana).HasColumnName("IDClana");

                entity.Property(e => e.Idplaceno).HasColumnName("IDPlaceno");

                entity.Property(e => e.Idprivilegije).HasColumnName("IDPrivilegije");

                entity.Property(e => e.Idsekcije).HasColumnName("IDSekcije");

                entity.Property(e => e.KorisnickoIme)
                    .IsRequired()
                    .HasColumnName("korisnickoIme")
                    .HasMaxLength(50);

                entity.Property(e => e.Lozinka)
                    .IsRequired()
                    .HasColumnName("lozinka")
                    .HasMaxLength(50);

                entity.Property(e => e.Popust)
                    .IsRequired()
                    .HasColumnName("popust")
                    .HasMaxLength(50);

                entity.Property(e => e.PrezimeIme)
                    .IsRequired()
                    .HasColumnName("prezimeIme")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdplacenoNavigation)
                    .WithMany(p => p.Clan)
                    .HasForeignKey(d => d.Idplaceno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clan_Placeno");

                entity.HasOne(d => d.IdprivilegijeNavigation)
                    .WithMany(p => p.Clan)
                    .HasForeignKey(d => d.Idprivilegije)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clan_Privilegije");

                entity.HasOne(d => d.IdsekcijeNavigation)
                    .WithMany(p => p.Clan)
                    .HasForeignKey(d => d.Idsekcije)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clan_Sekcije");
            });

            modelBuilder.Entity<GodisnjaClanarina>(entity =>
            {
                entity.HasKey(e => e.Idgodisnja);

                entity.Property(e => e.Idgodisnja)
                    .HasColumnName("IDGodisnja")
                    .ValueGeneratedNever();

                entity.Property(e => e.CenaObicna).HasColumnName("cenaObicna");

                entity.Property(e => e.CenaPopust).HasColumnName("cenaPopust");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<MesecnaClanarina>(entity =>
            {
                entity.HasKey(e => e.Idmesecna);

                entity.Property(e => e.Idmesecna)
                    .HasColumnName("IDMesecna")
                    .ValueGeneratedNever();

                entity.Property(e => e.CenaObicna).HasColumnName("cenaObicna");

                entity.Property(e => e.CenaPopust).HasColumnName("cenaPopust");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Placeno>(entity =>
            {
                entity.HasKey(e => e.Idplaceno);

                entity.Property(e => e.Idplaceno)
                    .HasColumnName("IDPlaceno")
                    .ValueGeneratedNever();

                entity.Property(e => e.Idgodisnja).HasColumnName("IDGodisnja");

                entity.Property(e => e.Idmesecna).HasColumnName("IDMesecna");

                entity.HasOne(d => d.IdgodisnjaNavigation)
                    .WithMany(p => p.Placeno)
                    .HasForeignKey(d => d.Idgodisnja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Placeno_godisnjaClanarina");

                entity.HasOne(d => d.IdmesecnaNavigation)
                    .WithMany(p => p.Placeno)
                    .HasForeignKey(d => d.Idmesecna)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Placeno_MesecnaClanarina");
            });

            modelBuilder.Entity<Privilegije>(entity =>
            {
                entity.HasKey(e => e.Idprivilegije);

                entity.Property(e => e.Idprivilegije)
                    .HasColumnName("IDPrivilegije")
                    .ValueGeneratedNever();

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasColumnName("naziv")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Priznanica>(entity =>
            {
                entity.HasKey(e => e.Idpriznanice);

                entity.Property(e => e.Idpriznanice).HasColumnName("IDPriznanice");

                entity.Property(e => e.Cena).HasColumnName("cena");

                entity.Property(e => e.Datum)
                    .IsRequired()
                    .HasColumnName("datum")
                    .HasMaxLength(30);

                entity.Property(e => e.Idkorisnika).HasColumnName("IDKorisnika");

                entity.Property(e => e.NazivMeseca)
                    .IsRequired()
                    .HasColumnName("nazivMeseca")
                    .HasMaxLength(20);

                entity.HasOne(d => d.IdkorisnikaNavigation)
                    .WithMany(p => p.Priznanica)
                    .HasForeignKey(d => d.Idkorisnika)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Priznanica_Clan");
            });

            modelBuilder.Entity<Sekcije>(entity =>
            {
                entity.HasKey(e => e.Idsekcije);

                entity.Property(e => e.Idsekcije)
                    .HasColumnName("IDSekcije")
                    .ValueGeneratedNever();

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
