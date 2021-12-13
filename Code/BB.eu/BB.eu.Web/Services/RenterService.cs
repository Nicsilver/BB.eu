using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BB.eu.Shared.Models;
using BB.eu.Shared.Requests;

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

        public async Task<Renter> LoginAsync(Renter entity)
        {
            HttpResponseMessage responseMessage = await httpClient.PutAsJsonAsync("Renter/Login", entity);

            if (responseMessage.StatusCode != HttpStatusCode.OK) return null;
            return await responseMessage.Content.ReadFromJsonAsync<Renter>();
        }


    }
}