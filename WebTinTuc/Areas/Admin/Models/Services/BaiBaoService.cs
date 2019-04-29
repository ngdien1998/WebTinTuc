using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebTinTuc.Models.Entities;
using System.Linq;

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
            var dsBinhLuan = context.BinhLuan.Where(e => e.IdBaiBao == entity.IdBaiBao);
            foreach (var binhLuan in dsBinhLuan)
            {
                context.BinhLuan.Remove(binhLuan);
            }
            context.BaiBao.Remove(entity);
            context.SaveChanges();
        }

        public BaiBao Get(object id)
        {
            return context.BaiBao
                .Include(e => e.UsernameNavigation)
                .FirstOrDefault(e => e.IdBaiBao == (long)id);
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
            dbEntity.IdDanhMuc = entity.IdDanhMuc;
            dbEntity.Tags = entity.Tags;

            context.SaveChanges();
        }
    }
}
