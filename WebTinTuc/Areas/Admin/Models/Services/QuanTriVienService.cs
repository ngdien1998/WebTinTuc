using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTinTuc.Models.Entities;

namespace WebTinTuc.Areas.Admin.Models.Services
{
    public class QuanTriVienService : IDataRepository<QuanTriVien>
    {
        private readonly TinTucContext context;

        public QuanTriVienService(TinTucContext context)
        {
            this.context = context;
        }

        public void Add(QuanTriVien entity)
        {
            context.QuanTriVien.Add(entity);
            context.SaveChanges();
        }

        public void Delete(QuanTriVien entity)
        {
            context.QuanTriVien.Remove(entity);
            context.SaveChanges();
        }

        public QuanTriVien Get(object id)
        {
            return context.QuanTriVien.Find(id);
        }

        public IEnumerable<QuanTriVien> GetAll()
        {
            return context.QuanTriVien;
        }

        public void Update(QuanTriVien dbEntity, QuanTriVien entity)
        {
            dbEntity.MatKhau = entity.MatKhau;
            dbEntity.HoTen = entity.HoTen;
            dbEntity.NgaySinh = entity.NgaySinh;
            dbEntity.GioiTinh = entity.GioiTinh;
            dbEntity.Email = entity.Email;
            dbEntity.ChucVu = entity.ChucVu;

            context.SaveChanges();
        }
    }
}
