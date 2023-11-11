﻿using LazyNotesOnline.Models;
using LazyNotesOnline.Models.DTOs;
using LazyNotesOnline.Repositores;
using System.Security.Cryptography;

namespace LazyNotesOnline.Services
{
    public class UserLoginAndCreateService : IUserLoginAndCreateService
    {
        public UserStatusDTO UserLogin(string inputedNickName, string password) //1
        {
            var clientAcc = _appDbContext.Users.SingleOrDefault(a => a.NickName == inputedNickName);
            if (clientAcc == null)
            {
                return new UserStatusDTO(false);
            }

            var isUserExist = VerifyPasswordHash(password, clientAcc.PasswordHash, clientAcc.PasswordSalt);
            return new UserStatusDTO(isUserExist, clientAcc.Role);
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            return computeHash.SequenceEqual(computeHash);
        }

        public async Task<(bool, User)> SignupNewUser(string userName, string newNickName, string password) //2
        {

            var nickNameExistAlready = _appDbContext.Users.Any(u => u.NickName == newNickName);
            if (nickNameExistAlready)
            {
                return (false, null);
            }

            var userRepository = new UserRepository();
            var acc = userRepository.CreateUser(userName, newNickName, password);
            _appDbContext.Users.Add(acc);
            await _appDbContext.SaveChangesAsync();
            return (true, acc);
            
        }

        //
        private readonly AppDbContext _appDbContext;

        public UserLoginAndCreateService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

    }
}
