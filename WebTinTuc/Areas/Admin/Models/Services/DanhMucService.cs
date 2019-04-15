using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTinTuc.Models.Entities;

namespace WebTinTuc.Areas.Admin.Models.Services
{
    public class DanhMucService : IDataRepository<DanhMuc>
    {
        private readonly TinTucContext context;

        public DanhMucService(TinTucContext context)
        {
            this.context = context;
        }

        public void Add(DanhMuc entity)
        {
            context.DanhMuc.Add(entity);
            context.SaveChanges();
        }

        public void Delete(DanhMuc entity)
        {
            context.DanhMuc.Remove(entity);
            context.SaveChanges();
        }

        public DanhMuc Get(object id)
        {
            return context.DanhMuc.Find(id);
        }

        public IEnumerable<DanhMuc> GetAll()
        {
            return context.DanhMuc.AsNoTracking();
        }

        public void Update(DanhMuc dbEntity, DanhMuc entity)
        {
            dbEntity.TenDanhMuc = entity.TenDanhMuc;

            context.SaveChanges();
        }
    }
}
