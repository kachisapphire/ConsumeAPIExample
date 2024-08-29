using ConsumeAPIExample.DTO;

namespace ConsumeAPIExample.Services
{
    public interface IReqresService
    {
        Task<UserDTO> GetUserByIdAsync(int id);
        Task<UsersDTO> GetUsers();
    }
}
