using MagicVilla_VillaAPI.Models;
using System.Linq.Expressions;

namespace MagicVilla_VillaAPI.Repository.IRepository
{
    public interface IVillaRepository
    {
        Task<List<Villa>> GetAllAsyc(Expression<Func<Villa, bool>> filter = null);
        Task<Villa> GetAsyc(Expression<Func<Villa, bool>> filter = null, bool tracked = true);
        Task CreateAsyc(Villa entity);
        Task UpdateAsyc(Villa entity);
        Task RemoveAsyc(Villa entity);
        Task SaveAsyc();
    }
}
