using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebTinTuc.Models.Entities;

namespace WebTinTuc.Areas.Admin.Models.Services
{
    public class BaiBaoService : IDataRepository<BaiBao>
    {
        private readonly TinTucContext context;

        public BaiBaoService(TinTucContext context)
        {
            this.context = context;
        }

        public void Add(BaiBao entity)
        {
            context.BaiBao.Add(entity);
            context.SaveChanges();
        }

        public void Delete(BaiBao entity)
        {
            context.BaiBao.Remove(entity);
            context.SaveChanges();
        }

        public BaiBao Get(object id)
        {
            return context.BaiBao.Find(id);
        }

        public IEnumerable<BaiBao> GetAll()
        {
            return context.BaiBao.Include(e => e.UsernameNavigation);
        }

        public void Update(BaiBao dbEntity, BaiBao entity)
        {
            dbEntity.TieuDe = entity.TieuDe;
            dbEntity.TomTat = entity.TomTat;
            dbEntity.NoiDung = entity.NoiDung;
            dbEntity.HinhAnh = entity.HinhAnh;
            dbEntity.ThoiGianTao = entity.ThoiGianTao;
            dbEntity.Username = entity.Username;
            dbEntity.IdDanhMuc = entity.IdDanhMuc;
            dbEntity.LuotXem = entity.LuotXem;
            dbEntity.Tags = entity.Tags;

            context.SaveChanges();
        }
    }
}
