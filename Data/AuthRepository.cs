using System;
using System.Threading.Tasks;
using BaseBackend.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseBackend.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;

        }
        public async Task<User> Login(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);

            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // auth successfull
            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
                return true;
            }
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> CompleteRegister(User user, string password)
        {
            var userToUpdate = await _context.Users.FirstOrDefaultAsync(x => x.Username == user.Username);
            if (password != null)
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);
                userToUpdate.PasswordHash = passwordHash;
                userToUpdate.PasswordSalt = passwordSalt;
            }
            userToUpdate.Username = user.Username;
            userToUpdate.Company = user.Company;
            userToUpdate.Telephone = user.Telephone;
            userToUpdate.LastName = user.LastName;
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.Address = user.Address;
            userToUpdate.AboutMe = user.AboutMe;

            await _context.Users.AddAsync(userToUpdate);
            _context.Users.Update(userToUpdate);
            // _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _context.Users.AnyAsync(x => x.Username == username))
                return true;
                
            return false;
        }
    }
}