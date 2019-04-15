using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebTinTuc.Models.Entities
{
    public partial class BaiBao
    {
        public BaiBao()
        {
            BinhLuan = new HashSet<BinhLuan>();
        }

        public long IdBaiBao { get; set; }

        [Required]
        public string TieuDe { get; set; }

        [Required]
        public string TomTat { get; set; }

        [Required]
        public string NoiDung { get; set; }

        [Required]
        public string HinhAnh { get; set; }

        public DateTime ThoiGianTao { get; set; }

        public string Username { get; set; }

        [Required]
        public long? IdDanhMuc { get; set; }

        public int? LuotXem { get; set; }

        public string Tags { get; set; }

        public virtual DanhMuc IdDanhMucNavigation { get; set; }
        public virtual QuanTriVien UsernameNavigation { get; set; }
        public virtual ICollection<BinhLuan> BinhLuan { get; set; }
    }
}
