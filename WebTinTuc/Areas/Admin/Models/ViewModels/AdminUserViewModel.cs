using System.ComponentModel.DataAnnotations;

namespace WebTinTuc.Areas.Admin.Models.ViewModels
{
    public class AdminUserViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string MatKhau { get; set; }
    }
}
