using DineMaster_APICreation.DTO;
using DineMaster_APICreation.Models;

namespace DineMaster_APICreation.Repository
{
    public interface IUserRepo
    {
        void AddUser(UserDTO dto);
        List<UserDTO> GetUsers();

        UserModel GetUserByID(int id);
        void UpdateUser(UserModel um);
        void DeleteUser(int id);


    }
}
