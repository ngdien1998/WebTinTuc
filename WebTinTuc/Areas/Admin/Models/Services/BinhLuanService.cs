using System.Collections.Generic;
using WebTinTuc.Models.Entities;

namespace WebTinTuc.Areas.Admin.Models.Services
{
    public class BinhLuanService : IDataRepository<BinhLuan>
    {
        private readonly TinTucContext context;

        public BinhLuanService(TinTucContext context)
        {
            this.context = context;
        }

        public void Add(BinhLuan entity)
        {
            context.BinhLuan.Add(entity);
            context.SaveChanges();
        }

        public void Delete(BinhLuan entity)
        {
            context.BinhLuan.Remove(entity);
            context.SaveChanges();
        }

        public BinhLuan Get(object id)
        {
            return context.BinhLuan.Find(id);
        }

        public IEnumerable<BinhLuan> GetAll()
        {
            return context.BinhLuan;
        }

        public void Update(BinhLuan dbEntity, BinhLuan entity)
        {
            dbEntity.NoiDung = entity.NoiDung;
            dbEntity.TenNguoiBl = entity.TenNguoiBl;
            dbEntity.Email = entity.Email;
            dbEntity.ThoiGian = entity.ThoiGian;
            dbEntity.IdBlchaNavigation = entity.IdBlchaNavigation;
            dbEntity.IdBaiBao = entity.IdBaiBao;

            context.SaveChanges();
        }
    }
}