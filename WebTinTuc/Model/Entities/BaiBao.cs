using System;
using System.Collections.Generic;

namespace WebTinTuc.Model.Entities
{
    public partial class BaiBao
    {
        public BaiBao()
        {
            BinhLuan = new HashSet<BinhLuan>();
        }

        public long IdBaiBao { get; set; }
        public string TieuDe { get; set; }
        public string TomTat { get; set; }
        public string NoiDung { get; set; }
        public string HinhAnh { get; set; }
        public DateTime ThoiGianTao { get; set; }
        public string Username { get; set; }
        public long? IdDanhMuc { get; set; }
        public int? LuotXem { get; set; }
        public string Tags { get; set; }

        public virtual DanhMuc IdDanhMucNavigation { get; set; }
        public virtual QuanTriVien UsernameNavigation { get; set; }
        public virtual ICollection<BinhLuan> BinhLuan { get; set; }
    }
}
