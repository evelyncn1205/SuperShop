﻿using Microsoft.AspNetCore.Identity;
using SuperShop2.Data.Entities;
using SuperShop2.Models;
using System.Threading.Tasks;

namespace SuperShop2.Helpers
{
    public interface IUserHelper
    {
        Task <User> GetUserEmailAsync(string email);

        Task <IdentityResult> AddUserAsync(User user, string password);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();

        Task<IdentityResult> UpdateUserAsync(User user);

        Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);

    }
}
