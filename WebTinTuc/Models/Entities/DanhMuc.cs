using System;
using System.Collections.Generic;

namespace WebTinTuc.Models.Entities
{
    public partial class DanhMuc
    {
        public DanhMuc()
        {
            BaiBao = new HashSet<BaiBao>();
        }

        public long IdDanhMuc { get; set; }
        public string TenDanhMuc { get; set; }

        public virtual ICollection<BaiBao> BaiBao { get; set; }
    }
}
