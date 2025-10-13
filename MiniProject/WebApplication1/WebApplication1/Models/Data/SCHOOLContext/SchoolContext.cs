using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models.Data.SCHOOLContext;

public partial class SchoolContext : DbContext
{
    public SchoolContext()
    {
    }

    public SchoolContext(DbContextOptions<SchoolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Score> Scores { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //    => optionsBuilder.UseSqlServer("ConnectionString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Courseid)
                .HasName("PK2")
                .IsClustered(false);

            entity.ToTable("COURSE");

            entity.Property(e => e.Courseid).HasColumnName("COURSEID");
            entity.Property(e => e.Coursecode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("COURSECODE");
            entity.Property(e => e.Coursename)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("COURSENAME");
        });

        modelBuilder.Entity<Score>(entity =>
        {
            entity.HasKey(e => e.Scoreid)
                .HasName("PK3")
                .IsClustered(false);

            entity.ToTable("SCORES");

            entity.Property(e => e.Scoreid).HasColumnName("SCOREID");
            entity.Property(e => e.Courseid).HasColumnName("COURSEID");
            entity.Property(e => e.Grade)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("GRADE");
            entity.Property(e => e.Mark)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("MARK");
            entity.Property(e => e.Studentid).HasColumnName("STUDENTID");

            entity.HasOne(d => d.Course).WithMany(p => p.Scores)
                .HasForeignKey(d => d.Courseid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefCOURSE2");

            entity.HasOne(d => d.Student).WithMany(p => p.Scores)
                .HasForeignKey(d => d.Studentid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefSTUDENT1");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Studentid)
                .HasName("PK1")
                .IsClustered(false);

            entity.ToTable("STUDENT");

            entity.Property(e => e.Studentid).HasColumnName("STUDENTID");
            entity.Property(e => e.Birthdate).HasColumnName("BIRTHDATE");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FIRSTNAME");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("GENDER");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LASTNAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
