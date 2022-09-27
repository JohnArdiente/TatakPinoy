using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TatakPinoy.Data;
using TatakPinoy.Models;

namespace TatakPinoy.Services
{
    public interface IUserService
    {
        Task<UserModel> ValidateUserCredentialsAsync(string username, string password);
        string HashPassword(UserModel user, string password);
    }
    public class UserService : IUserService
    {
        private readonly PasswordHasher<UserModel> _hasher = new PasswordHasher<UserModel>();
        private readonly TatakPinoyContext _context;

        public UserService(TatakPinoyContext context)
        {
            _context = context;
        }

        public async Task<UserModel> ValidateUserCredentialsAsync(string username, string password)
        {
            UserModel user = null;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            user = await _context.UserModels.FirstOrDefaultAsync(x => x.Username == username);

            if (user is null) return null;

            try
            {
                var result = _hasher.VerifyHashedPassword(user, user.Password, password);
                if (result.Equals(PasswordVerificationResult.Success))
                {
                    return user;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return null;
        }

        public string HashPassword(UserModel user, string password)
        {
            return _hasher.HashPassword(user, password);
        }

        Task<UserModel> IUserService.ValidateUserCredentialsAsync(string username, string password)
        {
            throw new NotImplementedException();
        }

        /*public string HashPassword(UserModel user, string password)
        {
            throw new NotImplementedException();
        }*/
    }
}
