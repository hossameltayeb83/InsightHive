﻿using InsightHive.Application.Responses;
using InsightHive.Domain.Entities;

namespace InsightHive.Application.Interfaces.Persistence
{
    public interface IUserRepository
    {
        public Task<AuthenticationResponse> RegisterAsync(User user, string password);
        public Task<bool> LoginAsync(string email, string password);
        public Task<bool> UpdateAsync(User user);
        public Task<User?> GetByEmailAsync(string email);
    }
}
