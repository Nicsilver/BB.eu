using System.Threading.Tasks;
using BB.eu.Shared.Models;

namespace BB.eu.Web.Services
{
    public interface IRenterService : IWriteAble<Renter>
    {
        Task<Renter> LoginAsync(Renter entity);
    }
}