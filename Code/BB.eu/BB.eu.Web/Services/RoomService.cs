using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BB.eu.Shared.Models;
using BB.eu.Shared.Requests;

namespace BB.eu.Web.Services
{
    public class RoomService : IRoomService
    {
        private readonly HttpClient httpClient;

        public RoomService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Room> CreateRoom(CreateRoomRequest request)
        {
            HttpResponseMessage result = await httpClient.PutAsJsonAsync($"Room/Create", request);
            Room room = await result.Content.ReadFromJsonAsync<Room>();
            return room;
        }
    }
}