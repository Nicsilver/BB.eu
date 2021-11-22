using System.Collections.Generic;
using System.Threading.Tasks;
using BB.eu.API.Services.Generic;
using BB.eu.Shared.Models;

namespace BB.eu.API.Services
{
    public interface ITenantDataService : IWriteAble<Tenant>, IReadAble<Tenant>
    {
    }
}