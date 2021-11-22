using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BB.eu.Shared.Models;

namespace BB.eu.Web.Services
{
    public class RenterService : IRenterService
    {
        private readonly HttpClient httpClient;

        public RenterService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Renter> CreateAsync(Renter entity)
        {
            HttpResponseMessage result = await httpClient.PutAsJsonAsync($"Renter/Create", entity);
            var renter = await result.Content.ReadFromJsonAsync<Renter>();
            // Console.WriteLine(renter.FirstName);
            return renter;
        }

        public Task<bool> UpdateAsync(Renter entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Renter>> GetAllAsync()
        {
            return await httpClient.GetFromJsonAsync<List<Renter>>("Renter/GetAll");
        }

        public Task<Renter> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}