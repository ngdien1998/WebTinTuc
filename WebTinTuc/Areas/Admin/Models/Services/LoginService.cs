using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTinTuc.Areas.Admin.Models.ViewModels;
using WebTinTuc.Models.Entities;

namespace WebTinTuc.Areas.Admin.Models.Services
{
    public class LoginService
    {
        private readonly TinTucContext context;

        public LoginService(TinTucContext context)
        {
            this.context = context;
        }

        public bool AllowToLogin(AdminUserViewModel admin)
        {
            var entity = context.QuanTriVien.Where(e => 
                e.Username == admin.Username && admin.MatKhau == e.MatKhau);
            return entity != null;
        }
    }
}