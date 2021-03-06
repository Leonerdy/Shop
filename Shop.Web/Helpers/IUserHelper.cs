﻿using Microsoft.AspNetCore.Identity;
using Shop.Web.Data.Entities;
using Shop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserByEmailAsync(string email);

        Task<bool> GetUserRoleAsync(User user, string role);

        Task<IdentityResult> AddUserAsync(User user, string password);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();

        Task<IdentityResult> UpdateUserAsync(User user);

        Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword);

        Task<SignInResult> ValidatePasswordAsync(User user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);

        Task<string> GenerateEmailConfirmationTokenAsync(User user);

        Task<IdentityResult> ConfirmEmailAsync(User user, string token);

        Task<User> GetUserByIdAsync(string userId);

        Task<string> GeneratePasswordResetTokenAsync(User user);

        Task<IdentityResult> ResetPasswordAsync(User user, string token, string password);

        Task<List<User>> GetAllUsersAsync();

        Task RemoveUserFromRoleAsync(User user, string roleName);

        Task DeleteUserAsync(User user);

    }
}
