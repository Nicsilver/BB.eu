using System.Threading.Tasks;

namespace BB.eu.API.Services.Generic
{
    public interface IWriteAble<T>
    {
        Task<T> CreateAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteByIdAsync(int id);
    }
}