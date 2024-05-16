using AutoMapper;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.Responses;
using InsightHive.Domain.Entities;
using InsightHive.Identity.Models;
using InsightHive.Persistence.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace InsightHive.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly InsightHiveDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public UserRepository(InsightHiveDbContext context,
                              UserManager<AppUser> userManager,
                              IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<AuthenticationResponse> RegisterAsync(User user, string password)
        {
            var role = await _context.Roles.FindAsync(user.RoleId);
            if (role == null)
                return new AuthenticationResponse { Succeeded = false, Errors = ["Invalid roleId"] };

            var appUser = _mapper.Map<AppUser>(user);

            var identityResult = await _userManager.CreateAsync(appUser, password);

            if (identityResult.Succeeded)
                await AddUserAsync(_mapper.Map<User>(appUser));

            return _mapper.Map<AuthenticationResponse>(identityResult);
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            var appUser = await _userManager.FindByEmailAsync(email);
            return appUser == null ? false : await _userManager.CheckPasswordAsync(appUser, password);
        }

        public async Task<bool> UpdateAsync(User user)
        {
            var appUser = _mapper.Map<AppUser>(user);
            var identityResult = await _userManager.UpdateAsync(appUser);

            if (identityResult.Succeeded)
                return await UpdateUserAsync(user);

            return false;
        }

        private async Task<bool> AddUserAsync(User user)
        {
            _context.Users.Add(user);
            return await _context.SaveChangesAsync() > 0;
        }

        private async Task<bool> UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public Task<User?> GetByEmailAsync(string email)
        {
            return _context.Users.Include(e => e.Role).FirstOrDefaultAsync(e => e.Email == email);
        }
    }
}
