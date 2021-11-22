using System.Threading.Tasks;

namespace TDDPrototype
{
    public interface IRoomDataService
    {
        Task<Room> GetAsync(int id);
    }
}