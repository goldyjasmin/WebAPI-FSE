using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FSE.DAL.Models
{
    public partial class FeedBackManagementSystemContext : DbContext
    {
        public FeedBackManagementSystemContext()
        {
        }

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
        public virtual DbSet<TblPoceventDetails> TblPoceventDetails { get; set; }
        public virtual DbSet<TblRating> TblRating { get; set; }
        public virtual DbSet<TblRoleType> TblRoleType { get; set; }
        public virtual DbSet<TblUserCategory> TblUserCategory { get; set; }

        // Unable to generate entity type for table 'dbo.TempTblEventEnrollmentDetails'. Please see the warning messages.

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<TblBaseLocation>(entity =>
            {
                entity.HasKey(e => e.BaseLocationId)
                    .HasName("PK__tblBaseL__E28EB8A5BB05E072");

                entity.ToTable("tblBaseLocation");

                entity.Property(e => e.BaseLocationId).HasColumnName("BaseLocationID");

                entity.Property(e => e.BaseLocation).HasMaxLength(100);
            });

            modelBuilder.Entity<TblBusinessUnit>(entity =>
            {
                entity.HasKey(e => e.BusinessUnitId)
                    .HasName("PK__tblBusin__19FA597D4C353E9F");

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

                entity.Property(e => e.IsReminderSent).HasColumnName("isReminderSent");

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.HasOne(d => d.BaseLocation)
                    .WithMany(p => p.TblEventEnrollmentDetails)
                    .HasForeignKey(d => d.BaseLocationId)
                    .HasConstraintName("FK_tblEventEnrollmentDetails_tblBaseLocation");

                entity.HasOne(d => d.BusinessUnit)
                    .WithMany(p => p.TblEventEnrollmentDetails)
                    .HasForeignKey(d => d.BusinessUnitId)
                    .HasConstraintName("FK_tblEventEnrollmentDetails_tblBusinessUnit");

                entity.HasOne(d => d.Iiepcategory)
                    .WithMany(p => p.TblEventEnrollmentDetails)
                    .HasForeignKey(d => d.IiepcategoryId)
                    .HasConstraintName("FK_tblEventEnrollmentDetails_tblIIEPCategory");
            });

            modelBuilder.Entity<TblFeedbackDetails>(entity =>
            {
                entity.HasKey(e => e.FeedbackDetailsId)
                    .HasName("PK__tblFeedb__BE0D13D84C62961F");

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
                    .HasConstraintName("FK__tblFeedba__Feedb__2D27B809");

                entity.HasOne(d => d.QuestionId1Navigation)
                    .WithMany(p => p.TblFeedbackDetailsQuestionId1Navigation)
                    .HasForeignKey(d => d.QuestionId1)
                    .HasConstraintName("FK__tblFeedba__Quest__2E1BDC42");

                entity.HasOne(d => d.QuestionId2Navigation)
                    .WithMany(p => p.TblFeedbackDetailsQuestionId2Navigation)
                    .HasForeignKey(d => d.QuestionId2)
                    .HasConstraintName("FK__tblFeedba__Quest__2F10007B");

                entity.HasOne(d => d.Rating)
                    .WithMany(p => p.TblFeedbackDetails)
                    .HasForeignKey(d => d.RatingId)
                    .HasConstraintName("FK__tblFeedba__Ratin__300424B4");

                entity.HasOne(d => d.UserCategory)
                    .WithMany(p => p.TblFeedbackDetails)
                    .HasForeignKey(d => d.UserCategoryId)
                    .HasConstraintName("FK__tblFeedba__UserC__30F848ED");
            });

            modelBuilder.Entity<TblFeedbackOptions>(entity =>
            {
                entity.HasKey(e => e.FeedbackOptionId)
                    .HasName("PK__tblFeedb__B9F9845BC2C16693");

                entity.ToTable("tblFeedbackOptions");

                entity.Property(e => e.FeedbackOptionId).HasColumnName("FeedbackOptionID");

                entity.Property(e => e.FeedbackDesc).HasMaxLength(500);
            });

            modelBuilder.Entity<TblFeedbackQuestions>(entity =>
            {
                entity.HasKey(e => e.QuestionId)
                    .HasName("PK__tblFeedb__0DC06F8C13B74B14");

                entity.ToTable("tblFeedbackQuestions");

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.QuestionName).HasMaxLength(500);
            });

            modelBuilder.Entity<TblIiepcategory>(entity =>
            {
                entity.HasKey(e => e.IiepcategoryId)
                    .HasName("PK__tblIIEPC__94FD13E3D35B11C4");

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

                entity.Property(e => e.IsActive).HasColumnName("isActive");

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
                    .HasConstraintName("FK__tblLogin__RoleID__34C8D9D1");
            });

            modelBuilder.Entity<TblNotParticipated>(entity =>
            {
                entity.ToTable("tblNotParticipated");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BaseLocationId).HasColumnName("BaseLocationID");

                entity.Property(e => e.BeneficiaryName).HasMaxLength(250);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.EventId)
                    .HasColumnName("EventID")
                    .HasMaxLength(100);

                entity.Property(e => e.EventName).HasMaxLength(250);

                entity.Property(e => e.IsReminderSent).HasColumnName("isReminderSent");

                entity.Property(e => e.UserCategoryId).HasColumnName("UserCategoryID");

                entity.HasOne(d => d.BaseLocation)
                    .WithMany(p => p.TblNotParticipated)
                    .HasForeignKey(d => d.BaseLocationId)
                    .HasConstraintName("FK_tblNotParticipated_tblBaseLocation");

                entity.HasOne(d => d.UserCategory)
                    .WithMany(p => p.TblNotParticipated)
                    .HasForeignKey(d => d.UserCategoryId)
                    .HasConstraintName("FK_tblNotParticipated_tblUserCategory");
            });

            modelBuilder.Entity<TblPoceventDetails>(entity =>
            {
                entity.ToTable("tblPOCEventDetails");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BaseLocationId).HasColumnName("BaseLocationID");

                entity.Property(e => e.BeneficiaryName).HasMaxLength(250);

                entity.Property(e => e.Category).HasMaxLength(250);

                entity.Property(e => e.CouncilName).HasMaxLength(250);

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.EventId)
                    .HasColumnName("EventID")
                    .HasMaxLength(200);

                entity.Property(e => e.EventName).HasMaxLength(250);

                entity.Property(e => e.Month).HasMaxLength(50);

                entity.Property(e => e.OverallVolunteringHours).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.PoccontactNo).HasColumnName("POCContactNo");

                entity.Property(e => e.Pocid).HasColumnName("POCID");

                entity.Property(e => e.Pocname).HasColumnName("POCName");

                entity.Property(e => e.Project).HasMaxLength(200);

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.Property(e => e.TotalTravelHours).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TotalVolunteerHours).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.BaseLocation)
                    .WithMany(p => p.TblPoceventDetails)
                    .HasForeignKey(d => d.BaseLocationId)
                    .HasConstraintName("FK_tblPOCEventDetails_tblBaseLocation");
            });

            modelBuilder.Entity<TblRating>(entity =>
            {
                entity.HasKey(e => e.RatingId)
                    .HasName("PK__tblRatin__FCCDF87C0E958361");

                entity.ToTable("tblRating");

                entity.Property(e => e.RatingDesc).HasMaxLength(100);
            });

            modelBuilder.Entity<TblRoleType>(entity =>
            {
                entity.HasKey(e => e.RoleTypeId)
                    .HasName("PK__tblRoleT__3E697339861D9B63");

                entity.ToTable("tblRoleType");

                entity.Property(e => e.RoleTypeId).HasColumnName("RoleTypeID");

                entity.Property(e => e.RoleType).HasMaxLength(25);
            });

            modelBuilder.Entity<TblUserCategory>(entity =>
            {
                entity.HasKey(e => e.UserCategoryId)
                    .HasName("PK__tblUserC__2421C3E4B047F537");

                entity.ToTable("tblUserCategory");

                entity.Property(e => e.UserCategoryId).HasColumnName("UserCategoryID");

                entity.Property(e => e.UserCategoryName).HasMaxLength(500);
            });
        }
    }
}
