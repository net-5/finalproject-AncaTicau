using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Conference.Domain.Entities
{
   
    public partial class ConferenceContext : DbContext
    {
        public ConferenceContext()
        {
        }

        public ConferenceContext(DbContextOptions<ConferenceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Editions> Editions { get; set; }
        public virtual DbSet<PaperStatuses> PaperStatuses { get; set; }
        public virtual DbSet<Papers> Papers { get; set; }
        public virtual DbSet<Photos> Photos { get; set; }
        public virtual DbSet<Rooms> Rooms { get; set; }
        public virtual DbSet<Schedules> Schedules { get; set; }
        public virtual DbSet<Speakers> Speakers { get; set; }
        public virtual DbSet<SponsorPhoto> SponsorPhoto { get; set; }
        public virtual DbSet<SponsorTypes> SponsorTypes { get; set; }
        public virtual DbSet<Sponsors> Sponsors { get; set; }
        public virtual DbSet<TalkTypes> TalkTypes { get; set; }
        public virtual DbSet<Talks> Talks { get; set; }
        public virtual DbSet<Workshops> Workshops { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=conference;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<PaperStatuses>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Papers>(entity =>
            {
                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Edition)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.GitHub)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.LinkedIn)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.PresentationDescription)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.PresentationTitle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Tags)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.HasOne(d => d.PaperStatus)
                    .WithMany(p => p.Papers)
                    .HasForeignKey(d => d.PaperStatusId);

                entity.HasOne(d => d.TalkType)
                    .WithMany(p => p.Papers)
                    .HasForeignKey(d => d.TalkTypeId);
            });

            modelBuilder.Entity<Photos>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Url).IsRequired();

                entity.HasOne(d => d.Speaker)
                    .WithMany(p => p.Photos)
                    .HasForeignKey(d => d.SpeakerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Photos_Photos");
            });

            modelBuilder.Entity<Rooms>(entity =>
            {
                entity.Property(e => e.Edition)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Topic)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Schedules>(entity =>
            {
                entity.Property(e => e.Edition)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Talk)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.TalkId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Speakers>(entity =>
            {
                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Edition)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SponsorPhoto>(entity =>
            {
                entity.HasOne(d => d.Sponsor)
                    .WithMany(p => p.SponsorPhoto)
                    .HasForeignKey(d => d.SponsorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SponsorPhoto_Sponsors");
            });

            modelBuilder.Entity<SponsorTypes>(entity =>
            {
                entity.Property(e => e.Edition)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Sponsors>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Edition)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Website).IsRequired();

                entity.HasOne(d => d.SponsorType)
                    .WithMany(p => p.Sponsors)
                    .HasForeignKey(d => d.SponsorTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sponsors_SponsorTypes");
            });

            modelBuilder.Entity<TalkTypes>(entity =>
            {
                entity.Property(e => e.Edition)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Talks>(entity =>
            {
                entity.Property(e => e.Edition)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Speaker)
                    .WithMany(p => p.Talks)
                    .HasForeignKey(d => d.SpeakerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Talks_Speakers");
            });

            modelBuilder.Entity<Workshops>(entity =>
            {
                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Edition)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Speaker)
                    .WithMany(p => p.Workshops)
                    .HasForeignKey(d => d.SpeakerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Workshops_Speakers");
            });
        }
    }
}
