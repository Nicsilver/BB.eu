using System.Threading.Tasks;

namespace BB.eu.Web.Services
{
    public interface IWriteAble<T>
    {
        Task<T> CreateAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteByIdAsync(int id);
    }
}