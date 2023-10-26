using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        //Seccion usuarios
        Task<bool> SigninUserAsync(string userName, string password);
        Task<string> GetUserIdAsync(string userName);
        Task<(string userId, string UserName, string email, string phone, IList<string> roles)> GetUserDetailAsync(string userId);
        Task<(string userId, string UserName, string email, IList<string> roles)> GetUserDetailsByUserNameAsync(string userId);
        Task<(bool isSucceed, string userId)> CreateUserAsync(string userName, string password, string email, string phone, List<string> roles);
        Task<List<(string id, string userName, string email, string phoneNumber)>> GetAllUsersAsync();
        Task<bool> UpdateUserProfile(string id, string email, string phone, IList<string> roles);

        //Seccion roles
        Task<bool> CreateRoleAsync(string roleName);
        Task<bool> DeleteRoleAsync(string roleId);
        Task<(string id, string roleName)> GetRoleByIdAsync(string id);
        Task<List<(string id, string roleName)>> GetRolesAsync();
        Task<bool> UpdateRole(string id, string roleName);

        // User's Role section
        Task<bool> IsInRoleAsync(string userId, string role);
        Task<List<string>> GetUserRolesAsync(string userId);
        Task<bool> AssignUserToRole(string userName, IList<string> roles);
        Task<bool> UpdateUsersRole(string userName, IList<string> usersRole);
    }
}
