using System;
using System.Collections.Generic;

namespace WebTinTuc.Models.Entities
{
    public partial class BinhLuan
    {
        public BinhLuan()
        {
            InverseIdBlchaNavigation = new HashSet<BinhLuan>();
        }

        public long IdBinhLuan { get; set; }
        public string NoiDung { get; set; }
        public string TenNguoiBl { get; set; }
        public string Email { get; set; }
        public DateTime ThoiGian { get; set; }
        public long? IdBlcha { get; set; }
        public long IdBaiBao { get; set; }

        public virtual BaiBao IdBaiBaoNavigation { get; set; }
        public virtual BinhLuan IdBlchaNavigation { get; set; }
        public virtual ICollection<BinhLuan> InverseIdBlchaNavigation { get; set; }
    }
}
