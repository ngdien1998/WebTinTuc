using System.Collections.Generic;
using WebTinTuc.Models.Entities;

namespace WebTinTuc.Models.ViewModels
{
    public class FooterViewModel
    {
        public List<DanhMuc> DanhMuc { get; set; }
        public List<BaiBao> BaiBao { get; set; }
    }
}