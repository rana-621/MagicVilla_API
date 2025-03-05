using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MagicVilla_VillaAPI.Repository
{
    public class RepositoryVilla : IVillaRepository
    {
        private readonly ApplicationDbContext _db;
        public RepositoryVilla(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task CreateAsyc(Villa entity)
        {
            await _db.Villas.AddAsync(entity);
            await SaveAsyc();
        }

        public async Task<Villa> GetAsyc(Expression<Func<Villa, bool>> filter = null, bool tracked = true)
        {
            IQueryable<Villa> query = _db.Villas;

            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<Villa>> GetAllAsyc(Expression<Func<Villa, bool>> filter = null)
        {
            IQueryable<Villa> query = _db.Villas;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }

        public async Task RemoveAsyc(Villa entity)
        {
            _db.Villas.Remove(entity);
            await SaveAsyc();
        }

        public async Task SaveAsyc()
        {
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsyc(Villa entity)
        {
            _db.Villas.Update(entity);
            await SaveAsyc();
        }
    }
}
