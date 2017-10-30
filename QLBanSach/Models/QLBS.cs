namespace QLBanSach.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QLBS : DbContext
    {
        public QLBS()
            : base("name=QLBS")
        {
        }

        public virtual DbSet<BAOCAOTONG> BAOCAOTONGs { get; set; }
        public virtual DbSet<DATHANG> DATHANGs { get; set; }
        public virtual DbSet<HOADON> HOADONs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<NHACUNGCAP> NHACUNGCAPs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<PHIEUNHAP> PHIEUNHAPs { get; set; }
        public virtual DbSet<QUYEN> QUYENs { get; set; }
        public virtual DbSet<SACH> SACHes { get; set; }
        public virtual DbSet<THELOAI> THELOAIs { get; set; }
        public virtual DbSet<BK_BAOCAOTONG> BK_BAOCAOTONG { get; set; }
        public virtual DbSet<BK_CT_DATHANG> BK_CT_DATHANG { get; set; }
        public virtual DbSet<BK_CT_HOADON> BK_CT_HOADON { get; set; }
        public virtual DbSet<BK_SACH> BK_SACH { get; set; }
        public virtual DbSet<CT_DATHANG> CT_DATHANG { get; set; }
        public virtual DbSet<CT_HOADON> CT_HOADON { get; set; }
        public virtual DbSet<CT_PHIEUNHAP> CT_PHIEUNHAP { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DATHANG>()
                .Property(e => e.madathang)
                .IsUnicode(false);

            modelBuilder.Entity<DATHANG>()
                .Property(e => e.makh)
                .IsUnicode(false);

            modelBuilder.Entity<DATHANG>()
                .Property(e => e.sdt)
                .IsUnicode(false);

            modelBuilder.Entity<DATHANG>()
                .HasMany(e => e.CT_DATHANG)
                .WithRequired(e => e.DATHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.mahoadon)
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.manv)
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.makh)
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .HasMany(e => e.CT_HOADON)
                .WithRequired(e => e.HOADON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.makh)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.sodienthoai)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .HasMany(e => e.DATHANGs)
                .WithRequired(e => e.KHACHHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACHHANG>()
                .HasMany(e => e.HOADONs)
                .WithRequired(e => e.KHACHHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.mancc)
                .IsUnicode(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.sdtncc)
                .IsUnicode(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .HasMany(e => e.PHIEUNHAPs)
                .WithRequired(e => e.NHACUNGCAP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.manv)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.sodienthoai)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.matkhaunv)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.maquyen)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.HOADONs)
                .WithRequired(e => e.NHANVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.PHIEUNHAPs)
                .WithRequired(e => e.NHANVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUNHAP>()
                .Property(e => e.mapn)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUNHAP>()
                .Property(e => e.manv)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUNHAP>()
                .Property(e => e.mancc)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUNHAP>()
                .HasMany(e => e.CT_PHIEUNHAP)
                .WithRequired(e => e.PHIEUNHAP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QUYEN>()
                .Property(e => e.maquyen)
                .IsUnicode(false);

            modelBuilder.Entity<QUYEN>()
                .HasMany(e => e.NHANVIENs)
                .WithRequired(e => e.QUYEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.masach)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.matheloai)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.anhbia)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .HasMany(e => e.CT_DATHANG)
                .WithRequired(e => e.SACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SACH>()
                .HasMany(e => e.CT_HOADON)
                .WithRequired(e => e.SACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SACH>()
                .HasMany(e => e.CT_PHIEUNHAP)
                .WithRequired(e => e.SACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THELOAI>()
                .Property(e => e.matheloai)
                .IsUnicode(false);

            modelBuilder.Entity<THELOAI>()
                .HasMany(e => e.SACHes)
                .WithRequired(e => e.THELOAI)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BK_CT_DATHANG>()
                .Property(e => e.madathang)
                .IsUnicode(false);

            modelBuilder.Entity<BK_CT_DATHANG>()
                .Property(e => e.masach)
                .IsUnicode(false);

            modelBuilder.Entity<BK_CT_HOADON>()
                .Property(e => e.mahoadon)
                .IsUnicode(false);

            modelBuilder.Entity<BK_CT_HOADON>()
                .Property(e => e.masach)
                .IsUnicode(false);

            modelBuilder.Entity<BK_SACH>()
                .Property(e => e.masach)
                .IsUnicode(false);

            modelBuilder.Entity<BK_SACH>()
                .Property(e => e.matheloai)
                .IsUnicode(false);

            modelBuilder.Entity<BK_SACH>()
                .Property(e => e.anhbia)
                .IsUnicode(false);

            modelBuilder.Entity<CT_DATHANG>()
                .Property(e => e.madathang)
                .IsUnicode(false);

            modelBuilder.Entity<CT_DATHANG>()
                .Property(e => e.masach)
                .IsUnicode(false);

            modelBuilder.Entity<CT_HOADON>()
                .Property(e => e.mahoadon)
                .IsUnicode(false);

            modelBuilder.Entity<CT_HOADON>()
                .Property(e => e.masach)
                .IsUnicode(false);

            modelBuilder.Entity<CT_PHIEUNHAP>()
                .Property(e => e.masach)
                .IsUnicode(false);

            modelBuilder.Entity<CT_PHIEUNHAP>()
                .Property(e => e.mapn)
                .IsUnicode(false);
        }
    }
}
