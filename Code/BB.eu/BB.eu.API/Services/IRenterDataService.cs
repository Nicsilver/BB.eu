using System.Threading.Tasks;
using BB.eu.API.Services.Generic;
using BB.eu.Shared.Models;

namespace BB.eu.API.Services
{
    public interface IRenterDataService : IWriteAble<Renter>, IReadAble<Renter>
    {
        Task<Renter> GetByEmailAsync(string email);
    }
}