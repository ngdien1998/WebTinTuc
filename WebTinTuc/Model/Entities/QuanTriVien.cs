using System;
using System.Collections.Generic;

namespace WebTinTuc.Model.Entities
{
    public partial class QuanTriVien
    {
        public QuanTriVien()
        {
            BaiBao = new HashSet<BaiBao>();
        }

        public string Username { get; set; }
        public string MatKhau { get; set; }
        public string HoTen { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string Email { get; set; }
        public string ChucVu { get; set; }

        public virtual ICollection<BaiBao> BaiBao { get; set; }
    }
}
