using Authentication.Dtos;
using Authentication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Authentication.Data
{
    public interface IUser
    {
        IEnumerable<UserDTO> GetAllUser();
        Task Registration(CreateUserDTO user);
        Task AddRole(string rolename);
        IEnumerable<CreateRoleDTO> GetRoles();
        Task AddUserToRole(string username, string role);
        Task<List<string>> GetRolesFromUser(string username);
        Task<User> Authenticate(string username, string password);
    }
}
