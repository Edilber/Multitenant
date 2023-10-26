using Back.Application.Common.Exceptions;
using Back.Application.Common.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Back.Infraestructure.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IdentityService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public Task<bool> AssignUserToRole(string userName, IList<string> roles)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateRoleAsync(string roleName)
        {
            var result = await _roleManager.CreateAsync(new IdentityRole(roleName));
            if (!result.Succeeded)
            {
                throw new ValidationException(result.Errors);
            }

            return result.Succeeded;
        }

        public async Task<(bool isSucceed, string userId)> CreateUserAsync(string userName, string password, string email, string phone, List<string> roles)
        {
            var user = new IdentityUser
            {
                UserName = userName,
                Email = email,
                PhoneNumber = phone
            };

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                throw new ValidationException(result.Errors);
            }

            var role = await _userManager.AddToRolesAsync(user, roles);

            if (!role.Succeeded)
            {
                throw new ValidationException(result.Errors);
            }

            return (result.Succeeded, user.Id);

        }

        public Task<bool> DeleteRoleAsync(string roleId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<(string id, string userName, string email, string phoneNumber)>> GetAllUsersAsync()
        {
            var users = await _userManager.Users.Select(x => new
            {
                x.Id,
                x.UserName,
                x.Email,
                x.PhoneNumber
            }).ToListAsync();

            return users.Select(user => (user.Id, user.UserName, user.Email, user.PhoneNumber)).ToList();
        }

        public Task<(string id, string roleName)> GetRoleByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<(string? id, string? roleName)>> GetRolesAsync()
        {
            var roles = await _roleManager.Roles.Select(x => new
            {
                x.Id,
                x.Name
            }).ToListAsync();

            return roles.Select(role => (role.Id, role.Name)).ToList();
        }

        public async Task<(string? userId, string? UserName, string? email, string? phone, IList<string> roles)> GetUserDetailAsync(string userId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null)
            {
                throw new NotFoundException("Usuario no encontrado");
            }

            var roles = await _userManager.GetRolesAsync(user);
            return (user.Id, user.UserName, user.Email, user.PhoneNumber, roles);
        }

        public Task<(string userId, string UserName, string email, IList<string> roles)> GetUserDetailsByUserNameAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetUserIdAsync(string userName)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == userName);
            if(user == null)
            {
                throw new NotFoundException("User not found");
            }
            return await _userManager.GetUserIdAsync(user);
        }

        public Task<List<string>> GetUserRolesAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(string userId, string role)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SigninUserAsync(string userName, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(userName, password, true, false);
            return result.Succeeded;
        }

        public Task<bool> UpdateRole(string id, string roleName)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateUserProfile(string id, string email, string phone, IList<string> roles)
        {
            var user = await _userManager.FindByIdAsync(id);
            if(user == null)
            {
                throw new NotFoundException("User not found");
            }

            user.Email = email;
            user.PhoneNumber = phone;

            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }

        public async Task<bool> UpdateUsersRole(string userName, IList<string> usersRole)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if(user == null)
            {
                throw new NotFoundException("User not found");
            }

            var rolesUser = await _userManager.GetRolesAsync(user);
            
            if(rolesUser.Count != 0)
            {
                var result = await _userManager.RemoveFromRolesAsync(user, rolesUser);
            }

            var response = await _userManager.AddToRolesAsync(user, usersRole);
            return response.Succeeded;
        }
    }
}
