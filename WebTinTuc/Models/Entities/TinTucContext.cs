using Microsoft.EntityFrameworkCore;

namespace WebTinTuc.Models.Entities
{
    public partial class TinTucContext : DbContext
    {
        public TinTucContext()
        {
        }

        public TinTucContext(DbContextOptions<TinTucContext> options) : base(options)
        {
        }

        public virtual DbSet<BaiBao> BaiBao { get; set; }
        public virtual DbSet<BinhLuan> BinhLuan { get; set; }
        public virtual DbSet<DanhMuc> DanhMuc { get; set; }
        public virtual DbSet<QuanTriVien> QuanTriVien { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<BaiBao>(entity =>
            {
                entity.HasKey(e => e.IdBaiBao);

                entity.ToTable("BaiBao", "TinTuc");

                entity.HasIndex(e => e.IdDanhMuc)
                    .HasName("BaiBao___DanhMuc");

                entity.HasIndex(e => e.Username)
                    .HasName("BaiBao___QuanTriVien");

                entity.Property(e => e.IdBaiBao).HasColumnType("bigint(20)");

                entity.Property(e => e.HinhAnh).IsUnicode(false);

                entity.Property(e => e.IdDanhMuc).HasColumnType("bigint(20)");

                entity.Property(e => e.LuotXem).HasColumnType("int(11)");

                entity.Property(e => e.NoiDung)
                    .IsRequired()
                    .HasColumnType("longtext");

                entity.Property(e => e.Tags).IsUnicode(false);

                entity.Property(e => e.TieuDe)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.TomTat).IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDanhMucNavigation)
                    .WithMany(p => p.BaiBao)
                    .HasForeignKey(d => d.IdDanhMuc)
                    .HasConstraintName("BaiBao___DanhMuc");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.BaiBao)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BaiBao___QuanTriVien");
            });

            modelBuilder.Entity<BinhLuan>(entity =>
            {
                entity.HasKey(e => e.IdBinhLuan);

                entity.ToTable("BinhLuan", "TinTuc");

                entity.HasIndex(e => e.IdBaiBao)
                    .HasName("BinhLuan___BaiBao");

                entity.HasIndex(e => e.IdBlcha)
                    .HasName("BinhLuan___BinhLuan");

                entity.Property(e => e.IdBinhLuan).HasColumnType("bigint(20)");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdBaiBao).HasColumnType("bigint(20)");

                entity.Property(e => e.IdBlcha)
                    .HasColumnName("IdBLCha")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.NoiDung).IsUnicode(false);

                entity.Property(e => e.TenNguoiBl)
                    .HasColumnName("TenNguoiBL")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdBaiBaoNavigation)
                    .WithMany(p => p.BinhLuan)
                    .HasForeignKey(d => d.IdBaiBao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BinhLuan___BaiBao");

                entity.HasOne(d => d.IdBlchaNavigation)
                    .WithMany(p => p.InverseIdBlchaNavigation)
                    .HasForeignKey(d => d.IdBlcha)
                    .HasConstraintName("BinhLuan___BinhLuan");
            });

            modelBuilder.Entity<DanhMuc>(entity =>
            {
                entity.HasKey(e => e.IdDanhMuc);

                entity.ToTable("DanhMuc", "TinTuc");

                entity.Property(e => e.IdDanhMuc).HasColumnType("bigint(20)");

                entity.Property(e => e.TenDanhMuc)
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<QuanTriVien>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.ToTable("QuanTriVien", "TinTuc");

                entity.Property(e => e.Username)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ChucVu)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.GioiTinh)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.HoTen)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.MatKhau)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.NgaySinh).HasColumnType("date");
            });
        }
    }
}
