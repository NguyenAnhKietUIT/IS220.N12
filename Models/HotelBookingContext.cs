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
        public virtual DbSet<CONTACT> CONTACTs { get; set; }
        public virtual DbSet<CUSTOMER> CUSTOMERs { get; set; }
        public virtual DbSet<DISCOUNT> DISCOUNTs { get; set; }
        public virtual DbSet<EVALUATE_CUSTOMER> EVALUATE_CUSTOMER { get; set; }
        public virtual DbSet<EVALUATE_PROPERTY> EVALUATE_PROPERTY { get; set; }
        public virtual DbSet<PLACE> PLACEs { get; set; }
        public virtual DbSet<PROPERTY> PROPERTies { get; set; }
        public virtual DbSet<RESERVATION> RESERVATIONs { get; set; }
        public virtual DbSet<ROOM> ROOMs { get; set; }
        public virtual DbSet<SERVICE> SERVICEs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ACCOUNT>()
                .HasMany(e => e.CUSTOMERs)
                .WithRequired(e => e.ACCOUNT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ACCOUNT>()
                .HasMany(e => e.PROPERTies)
                .WithRequired(e => e.ACCOUNT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.userNameSend)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.userNameReceive)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .HasMany(e => e.EVALUATE_CUSTOMER)
                .WithRequired(e => e.CUSTOMER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CUSTOMER>()
                .HasMany(e => e.EVALUATE_PROPERTY)
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

            modelBuilder.Entity<PLACE>()
                .Property(e => e.ImageOfPlace)
                .IsUnicode(false);

            modelBuilder.Entity<PLACE>()
                .HasMany(e => e.PROPERTies)
                .WithRequired(e => e.PLACE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PROPERTY>()
                .Property(e => e.CheckInTime)
                .IsUnicode(false);

            modelBuilder.Entity<PROPERTY>()
                .Property(e => e.CheckOutTime)
                .IsUnicode(false);

            modelBuilder.Entity<PROPERTY>()
                .Property(e => e.Phone_Property)
                .IsUnicode(false);

            modelBuilder.Entity<PROPERTY>()
                .Property(e => e.TypeName)
                .IsUnicode(false);

            modelBuilder.Entity<PROPERTY>()
                .Property(e => e.TypeOfCategory)
                .IsUnicode(false);

            modelBuilder.Entity<PROPERTY>()
                .HasMany(e => e.EVALUATE_CUSTOMER)
                .WithRequired(e => e.PROPERTY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PROPERTY>()
                .HasMany(e => e.EVALUATE_PROPERTY)
                .WithRequired(e => e.PROPERTY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PROPERTY>()
                .HasMany(e => e.ROOMs)
                .WithRequired(e => e.PROPERTY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PROPERTY>()
                .HasMany(e => e.SERVICEs)
                .WithMany(e => e.PROPERTies)
                .Map(m => m.ToTable("SERVICE_SUPPLIED").MapLeftKey("PropertyID").MapRightKey("ServiceID"));

            modelBuilder.Entity<RESERVATION>()
                .Property(e => e.PhoneCheckInPerson)
                .IsUnicode(false);

            modelBuilder.Entity<RESERVATION>()
                .Property(e => e.Total)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ROOM>()
                .Property(e => e.RoomName)
                .IsUnicode(false);

            modelBuilder.Entity<ROOM>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ROOM>()
                .HasMany(e => e.RESERVATIONs)
                .WithRequired(e => e.ROOM)
                .WillCascadeOnDelete(false);
        }
    }
}
