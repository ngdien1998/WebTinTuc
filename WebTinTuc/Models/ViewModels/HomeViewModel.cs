using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTinTuc.Models.Entities;

namespace WebTinTuc.Models.ViewModels
{
    public class HomeViewModel
    {
        public List<BaiBao> TrendingPosts { get; set; }
        public List<BaiBao> FeaturedPosts { get; set; }
        public List<DanhMuc> LastestNews { get; set; }
        public List<BaiBao> PopularPosts { get; set; }
        public List<BaiBao> HotNews { get; set; }
        public List<DanhMuc> CategoriesPost { get; set; }
        public List<BaiBao> RandomCategory { get; set; }
        public List<DanhMuc> Categories { get; set; }
    }
}
