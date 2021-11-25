using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BB.eu.API.Data;
using BB.eu.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BB.eu.API.Services
{
    public class RenterDataService : IRenterDataService
    {
        private readonly DataContextFactory contextFactory;

        public RenterDataService(DataContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public async Task<Renter> CreateAsync(Renter entity)
        {
            DataContext dataContext = contextFactory.CreateDbContext();

            Renter r = await GetByEmailAsync(entity.Email);
            if (r != null) return null;

            entity.Guid = Guid.NewGuid();
            var entityEntry = await dataContext.AddAsync(entity);
            int isCreated = await dataContext.SaveChangesAsync();

            return isCreated > 0 ? entityEntry.Entity : null;
        }

        public async Task<bool> UpdateAsync(Renter entity)
        {
            DataContext dataContext = contextFactory.CreateDbContext();

            dataContext.Renters.Update(entity);
            int updated = await dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            DataContext dataContext = contextFactory.CreateDbContext();

            Renter entity = await GetByIdAsync(id);

            dataContext.Renters.Remove(entity);
            int deleted = await dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<List<Renter>> GetAllAsync()
        {
            DataContext dataContext = contextFactory.CreateDbContext();

            var entity = await dataContext.Renters
                .Include(x => x.Rooms)
                .ThenInclude(x => x.Pictures)
                .ToListAsync();

            return entity;
        }

        public async Task<Renter> GetByIdAsync(int id)
        {
            DataContext dataContext = contextFactory.CreateDbContext();

            Renter renter = await dataContext.Renters
                .Include(x => x.Rooms)
                .ThenInclude(x => x.Pictures)
                .FirstOrDefaultAsync(x => x.Id == id);

            return renter;
        }

        public async Task<Renter> GetByEmailAsync(string email)
        {
            DataContext dataContext = contextFactory.CreateDbContext();

            Renter renter = await dataContext.Renters
                .Include(x => x.Rooms)
                .ThenInclude(x => x.Pictures)
                .FirstOrDefaultAsync(x => x.Email == email);

            return renter;
        }
    }
}