using ConsumeAPIExample.DTO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConsumeAPIExample.Services
{
    public class ReqresService : IReqresService
    {
        private readonly HttpClient _httpClient;

        public ReqresService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"https://reqres.in/api/users/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var user = JsonSerializer.Deserialize<UserDTO>(content);
            return user;
        }

        public async Task<UsersDTO> GetUsers()
        {
            var response = await _httpClient.GetAsync($"https://reqres.in/api/users");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var users = JsonSerializer.Deserialize<UsersDTO>(content);
            return users;
        }
    }
}
