using System.Collections.Generic;
using System.Threading.Tasks;

namespace BB.eu.Web.Services
{
    public interface IReadAble<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
    }
}