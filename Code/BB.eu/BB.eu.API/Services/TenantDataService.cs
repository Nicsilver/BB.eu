using System.Collections.Generic;
using System.Threading.Tasks;
using BB.eu.API.Data;
using BB.eu.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BB.eu.API.Services
{
    public class TenantDataService : ITenantDataService
    {
        private readonly DataContextFactory contextFactory;

        public TenantDataService(DataContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public async Task<Tenant> CreateAsync(Tenant entity)
        {
            DataContext dataContext = contextFactory.CreateDbContext();

            var entityEntry = await dataContext.AddAsync(entity);
            int isCreated = await dataContext.SaveChangesAsync();

            return isCreated > 0 ? entityEntry.Entity : null;
        }

        public async Task<bool> UpdateAsync(Tenant entity)
        {
            DataContext dataContext = contextFactory.CreateDbContext();

            dataContext.Tenants.Update(entity);
            int updated = await dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            DataContext dataContext = contextFactory.CreateDbContext();

            Tenant entity = await GetByIdAsync(id);

            dataContext.Tenants.Remove(entity);
            int deleted = await dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<List<Tenant>> GetAllAsync()
        {
            DataContext dataContext = contextFactory.CreateDbContext();

            return await dataContext.Tenants.ToListAsync();
        }

        public async Task<Tenant> GetByIdAsync(int id)
        {
            DataContext dataContext = contextFactory.CreateDbContext();

            return await dataContext.Tenants.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}