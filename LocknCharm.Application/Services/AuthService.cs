using AutoMapper;
using LocknCharm.Application.Common;
using LocknCharm.Application.DTOs.ApplicationUser;
using LocknCharm.Application.DTOs.Auth;
using LocknCharm.Application.Interfaces;
using LocknCharm.Application.Repositories;
using LocknCharm.Domain.Entities;
using LocknCharm.Domain.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace LocknCharm.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IGenericRepository<ApplicationUser> _userRepository;
        private readonly IGenericRepository<ApplicationRole> _roleRepository;
        private readonly IGenericRepository<ApplicationUserRoles> _userRoleRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;
        private readonly JwtSettings _jwtSettings;
        public AuthService(IMapper mapper, IGenericRepository<ApplicationUser> userRepository, IPasswordHasher<ApplicationUser> passwordHasher, IGenericRepository<ApplicationRole> roleRepository, IGenericRepository<ApplicationUserRoles> userRoleRepository, JwtSettings jwtSettings)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
            _jwtSettings = jwtSettings;
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUserDTO> GetUserInfo(string? id)
        {
            if (id == null)
            {
                throw new UnauthorizedAccessException("Unauthorized");
            }
            var user = await _userRepository.GetByIdAsync(new Guid(id)) ?? throw new KeyNotFoundException($"User with username {id} is not existed!");
            return _mapper.Map<ApplicationUserDTO>(user);
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO model)
        {
            var user = await _userRepository.GetByPropertyAsync(u => u.UserName == model.UserName);
            if (user == null)
            {
                throw new ArgumentException($"User with username {model.UserName} is not existed!");
            }
           
            var passwordCheck = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash!, model.Password);
            if (passwordCheck == PasswordVerificationResult.Failed)
            {
                throw new ArgumentException("Password is not correct!");
            }

            var userRole = await _userRoleRepository.GetAll().Where(r => r.UserId == user.Id).Select(l => l.RoleId.ToString()).ToListAsync();

            return new LoginResponseDTO()
            {
                User = _mapper.Map<ApplicationUserDTO>(user),
                Token = Authentication.CreateToken(user, userRole, _jwtSettings)
            };
        }

        public async Task<ApplicationUserDTO> Register(RegisterRequestDTO model)
        {
            var userCheck = await _userRepository.GetAllAsync(u => u.Email == model.Email || u.UserName == model.UserName);

            if (userCheck.Count() > 0)
            {
                throw new ArgumentException($"User with username's {model.UserName} is existed!");
            }

            var user = _mapper.Map<ApplicationUser>(model);
            var passwordHash = _passwordHasher.HashPassword(user, model.Password);
            user.PasswordHash = passwordHash;
            user.CreatedTime = DateTime.UtcNow;

            await _userRepository.InsertAsync(user);
            await _userRepository.SaveAsync();


            var userCreated = _mapper.Map<ApplicationUserDTO>(user);
            var roleUser = new ApplicationUserRoles
            {
                UserId = new Guid(userCreated.Id),
                RoleId = new Guid(model.RoleId)
            };
            return userCreated;
        }
    }
}
