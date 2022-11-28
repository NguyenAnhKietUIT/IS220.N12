using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace IS220.N12.Models
{
    public partial class HotelBookingContext : DbContext
    {
        public HotelBookingContext()
            : base("name=HotelBookingContext")
        {
        }

        public virtual DbSet<ACCOUNT> ACCOUNTs { get; set; }
        public virtual DbSet<CUSTOMER> CUSTOMERs { get; set; }
        public virtual DbSet<DISCOUNT> DISCOUNTs { get; set; }
        public virtual DbSet<EVALUATE_CUSTOMER> EVALUATE_CUSTOMER { get; set; }
        public virtual DbSet<EVALUATE_HOTEL> EVALUATE_HOTEL { get; set; }
        public virtual DbSet<HOTEL> HOTELs { get; set; }
        public virtual DbSet<ImageOfPlace> ImageOfPlaces { get; set; }
        public virtual DbSet<ImageOfType> ImageOfTypes { get; set; }
        public virtual DbSet<PLACE> PLACEs { get; set; }
        public virtual DbSet<RESERVATION> RESERVATIONs { get; set; }
        public virtual DbSet<ROOM> ROOMs { get; set; }
        public virtual DbSet<SERVICE> SERVICEs { get; set; }
        public virtual DbSet<SERVICE_SUPPLIED> SERVICE_SUPPLIED { get; set; }
        public virtual DbSet<TYPE_HOTEL> TYPE_HOTEL { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ACCOUNT>()
                .HasMany(e => e.CUSTOMERs)
                .WithRequired(e => e.ACCOUNT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ACCOUNT>()
                .HasMany(e => e.HOTELs)
                .WithRequired(e => e.ACCOUNT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CUSTOMER>()
                .HasMany(e => e.EVALUATE_CUSTOMER)
                .WithRequired(e => e.CUSTOMER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CUSTOMER>()
                .HasMany(e => e.RESERVATIONs)
                .WithRequired(e => e.CUSTOMER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DISCOUNT>()
                .Property(e => e.Requirement)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DISCOUNT>()
                .Property(e => e.Reduction)
                .HasPrecision(19, 4);

            modelBuilder.Entity<HOTEL>()
                .HasMany(e => e.EVALUATE_CUSTOMER)
                .WithRequired(e => e.HOTEL)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HOTEL>()
                .HasMany(e => e.ROOMs)
                .WithRequired(e => e.HOTEL)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HOTEL>()
                .HasMany(e => e.SERVICE_SUPPLIED)
                .WithRequired(e => e.HOTEL)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RESERVATION>()
                .Property(e => e.Total)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ROOM>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ROOM>()
                .HasMany(e => e.RESERVATIONs)
                .WithRequired(e => e.ROOM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SERVICE>()
                .HasMany(e => e.SERVICE_SUPPLIED)
                .WithRequired(e => e.SERVICE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SERVICE_SUPPLIED>()
                .Property(e => e.Price_Service)
                .HasPrecision(19, 4);
        }
    }
}
