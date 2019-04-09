using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace _450251_Hackathon_WebApi.Models
{
    public partial class FeedBackManagementSystemContext : DbContext
    {
        public FeedBackManagementSystemContext(DbContextOptions<FeedBackManagementSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblBaseLocation> TblBaseLocation { get; set; }
        public virtual DbSet<TblBusinessUnit> TblBusinessUnit { get; set; }
        public virtual DbSet<TblEventEnrollmentDetails> TblEventEnrollmentDetails { get; set; }
        public virtual DbSet<TblFeedbackDetails> TblFeedbackDetails { get; set; }
        public virtual DbSet<TblFeedbackOptions> TblFeedbackOptions { get; set; }
        public virtual DbSet<TblFeedbackQuestions> TblFeedbackQuestions { get; set; }
        public virtual DbSet<TblIiepcategory> TblIiepcategory { get; set; }
        public virtual DbSet<TblLogin> TblLogin { get; set; }
        public virtual DbSet<TblNotParticipated> TblNotParticipated { get; set; }
        public virtual DbSet<TblRating> TblRating { get; set; }
        public virtual DbSet<TblRoleType> TblRoleType { get; set; }
        public virtual DbSet<TblUserCategory> TblUserCategory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=DOTNET;Database=FeedBackManagementSystem;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<TblBaseLocation>(entity =>
            {
                entity.HasKey(e => e.BaseLocationId)
                    .HasName("PK__tblBaseL__E28EB8A54C574B8B");

                entity.ToTable("tblBaseLocation");

                entity.Property(e => e.BaseLocationId).HasColumnName("BaseLocationID");

                entity.Property(e => e.BaseLocation).HasMaxLength(100);
            });

            modelBuilder.Entity<TblBusinessUnit>(entity =>
            {
                entity.HasKey(e => e.BusinessUnitId)
                    .HasName("PK__tblBusin__19FA597D79228B4D");

                entity.ToTable("tblBusinessUnit");

                entity.Property(e => e.BusinessUnitId).HasColumnName("BusinessUnitID");

                entity.Property(e => e.BusinessUnit).HasMaxLength(100);
            });

            modelBuilder.Entity<TblEventEnrollmentDetails>(entity =>
            {
                entity.ToTable("tblEventEnrollmentDetails");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BaseLocationId).HasColumnName("BaseLocationID");

                entity.Property(e => e.BeneficiaryName).HasMaxLength(500);

                entity.Property(e => e.BusinessUnitId).HasColumnName("BusinessUnitID");

                entity.Property(e => e.CouncilName).HasMaxLength(500);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EmployeeName).HasMaxLength(500);

                entity.Property(e => e.EventDate).HasColumnType("date");

                entity.Property(e => e.EventId)
                    .HasColumnName("EventID")
                    .HasMaxLength(200);

                entity.Property(e => e.EventName).HasMaxLength(500);

                entity.Property(e => e.IiepcategoryId).HasColumnName("IIEPCategoryID");

                entity.Property(e => e.Status).HasMaxLength(100);
            });

            modelBuilder.Entity<TblFeedbackDetails>(entity =>
            {
                entity.HasKey(e => e.FeedbackDetailsId)
                    .HasName("PK__tblFeedb__BE0D13D8BB055429");

                entity.ToTable("tblFeedbackDetails");

                entity.Property(e => e.FeedbackDetailsId).HasColumnName("FeedbackDetailsID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EventId)
                    .HasColumnName("EventID")
                    .HasMaxLength(200);

                entity.Property(e => e.FeedbackOptionId).HasColumnName("FeedbackOptionID");

                entity.Property(e => e.UserCategoryId).HasColumnName("UserCategoryID");

                entity.HasOne(d => d.FeedbackOption)
                    .WithMany(p => p.TblFeedbackDetails)
                    .HasForeignKey(d => d.FeedbackOptionId)
                    .HasConstraintName("FK__tblFeedba__Feedb__25869641");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.TblFeedbackDetails)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK__tblFeedba__Quest__267ABA7A");

                entity.HasOne(d => d.Rating)
                    .WithMany(p => p.TblFeedbackDetails)
                    .HasForeignKey(d => d.RatingId)
                    .HasConstraintName("FK__tblFeedba__Ratin__276EDEB3");

                entity.HasOne(d => d.UserCategory)
                    .WithMany(p => p.TblFeedbackDetails)
                    .HasForeignKey(d => d.UserCategoryId)
                    .HasConstraintName("FK__tblFeedba__UserC__286302EC");
            });

            modelBuilder.Entity<TblFeedbackOptions>(entity =>
            {
                entity.HasKey(e => e.FeedbackOptionId)
                    .HasName("PK__tblFeedb__B9F9845BB0AEDE74");

                entity.ToTable("tblFeedbackOptions");

                entity.Property(e => e.FeedbackOptionId).HasColumnName("FeedbackOptionID");

                entity.Property(e => e.FeedbackDesc).HasMaxLength(500);
            });

            modelBuilder.Entity<TblFeedbackQuestions>(entity =>
            {
                entity.HasKey(e => e.QuestionId)
                    .HasName("PK__tblFeedb__0DC06F8C66F5AE87");

                entity.ToTable("tblFeedbackQuestions");

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.QuestionName).HasMaxLength(500);
            });

            modelBuilder.Entity<TblIiepcategory>(entity =>
            {
                entity.HasKey(e => e.IiepcategoryId)
                    .HasName("PK__tblIIEPC__94FD13E3D31AD18E");

                entity.ToTable("tblIIEPCategory");

                entity.Property(e => e.IiepcategoryId).HasColumnName("IIEPCategoryID");

                entity.Property(e => e.Iiepcategory)
                    .HasColumnName("IIEPCategory")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TblLogin>(entity =>
            {
                entity.ToTable("tblLogin");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("UserID")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TblLogin)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__tblLogin__RoleID__29572725");
            });

            modelBuilder.Entity<TblNotParticipated>(entity =>
            {
                entity.ToTable("tblNotParticipated");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BaseLocationId).HasColumnName("BaseLocationID");

                entity.Property(e => e.BusinessUnitId).HasColumnName("BusinessUnitID");

                entity.Property(e => e.Designation).HasMaxLength(100);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EventId)
                    .HasColumnName("EventID")
                    .HasMaxLength(200);

                entity.Property(e => e.UserCategoryId).HasColumnName("UserCategoryID");

                entity.HasOne(d => d.BaseLocation)
                    .WithMany(p => p.TblNotParticipated)
                    .HasForeignKey(d => d.BaseLocationId)
                    .HasConstraintName("FK__tblNotPar__BaseL__2A4B4B5E");

                entity.HasOne(d => d.BusinessUnit)
                    .WithMany(p => p.TblNotParticipated)
                    .HasForeignKey(d => d.BusinessUnitId)
                    .HasConstraintName("FK__tblNotPar__Busin__2B3F6F97");

                entity.HasOne(d => d.UserCategory)
                    .WithMany(p => p.TblNotParticipated)
                    .HasForeignKey(d => d.UserCategoryId)
                    .HasConstraintName("FK__tblNotPar__UserC__2C3393D0");
            });

            modelBuilder.Entity<TblRating>(entity =>
            {
                entity.HasKey(e => e.RatingId)
                    .HasName("PK__tblRatin__FCCDF87C1AD85F15");

                entity.ToTable("tblRating");

                entity.Property(e => e.RatingDesc).HasMaxLength(100);
            });

            modelBuilder.Entity<TblRoleType>(entity =>
            {
                entity.HasKey(e => e.RoleTypeId)
                    .HasName("PK__tblRoleT__3E6973397ACDCFD8");

                entity.ToTable("tblRoleType");

                entity.Property(e => e.RoleTypeId).HasColumnName("RoleTypeID");

                entity.Property(e => e.RoleType).HasMaxLength(25);
            });

            modelBuilder.Entity<TblUserCategory>(entity =>
            {
                entity.HasKey(e => e.UserCategoryId)
                    .HasName("PK__tblUserC__2421C3E48E4C465B");

                entity.ToTable("tblUserCategory");

                entity.Property(e => e.UserCategoryId).HasColumnName("UserCategoryID");

                entity.Property(e => e.UserCategoryName).HasMaxLength(500);
            });
        }
    }
}
