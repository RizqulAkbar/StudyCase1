using Authentication.Data;
using Authentication.Dtos;
using Authentication.Helpers;
using Authentication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.DAL
{
    public class UserDal : IUser
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private AppSettings _appSettings;

        public UserDal(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager, IOptions<AppSettings> appSettings)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _appSettings = appSettings.Value;
        }

        public async Task AddRole(string rolename)
        {
            IdentityResult roleResult;
            try
            {
                var roleIsExist = await _roleManager.RoleExistsAsync(rolename);
                if (!roleIsExist)
                    roleResult = await _roleManager.CreateAsync(new IdentityRole(rolename));
                else
                    throw new Exception($"Role {rolename} sudah ada");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task AddUserToRole(string username, string role)
        {
            var user = await _userManager.FindByNameAsync(username);
            try
            {
                await _userManager.AddToRoleAsync(user, role);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error {ex.Message}");
            }
        }

        public async Task<User> Authenticate(string username, string password)
        {
            var userFind = await _userManager.CheckPasswordAsync(
                await _userManager.FindByNameAsync(username), password);
            if (!userFind)
                return null;

            var user = new User
            {
                Username = username
            };

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.Username));
            var roles = await GetRolesFromUser(username);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            return user;
        }

        public IEnumerable<UserDto> GetAllUser()
        {
            List<UserDto> users = new List<UserDto>();
            var results = _userManager.Users;
            foreach (var user in results)
            {
                users.Add(new UserDto { Username = user.UserName, Email = user.Email });
            }

            return users;
        }

        public IEnumerable<CreateRoleDto> GetRoles()
        {
            List<CreateRoleDto> lstRole = new List<CreateRoleDto>();
            var results = _roleManager.Roles;
            foreach (var role in results)
            {
                lstRole.Add(new CreateRoleDto { RoleName = role.Name });
            }
            return lstRole;
        }

        public async Task<List<string>> GetRolesFromUser(string username)
        {
            List<string> lstRoles = new List<string>();
            var user = await _userManager.FindByNameAsync(username);

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                lstRoles.Add(role);
            }
            return lstRoles;
        }

        public async Task Registration(CreateUserDto user)
        {
            try
            {
                var newUser = new IdentityUser
                {
                    UserName = user.Username,
                    Email = user.Email
                };
                var result = await _userManager.CreateAsync(newUser, user.Password);
                if (!result.Succeeded)
                    throw new System.Exception("Gagal menambahkan user");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }
    }
}
