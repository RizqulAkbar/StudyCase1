using Authentication.Data;
using Authentication.Dtos;
using Authentication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUser _user;

        public UsersController(IUser user)
        {
            _user = user;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Registration(CreateUserDto user)
        {
            try
            {
                await _user.Registration(user);
                return Ok($"Registrasi user {user.Username} berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetAll()
        {
            return Ok(_user.GetAllUser());
        }

        [HttpPost("Role")]
        public async Task<ActionResult> AddRole(CreateRoleDto roleDTO)
        {
            try
            {
                await _user.AddRole(roleDTO.RoleName);
                return Ok($"Tambah role {roleDTO.RoleName} berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Role")]
        public ActionResult<IEnumerable<CreateRoleDto>> GetAllRole()
        {
            return Ok(_user.GetRoles());
        }

        [HttpPost("UsertoRole")]
        public async Task<ActionResult> AddUserToRole(string username, string role)
        {
            try
            {
                await _user.AddUserToRole(username, role);
                return Ok($"Adding {username} to {role} berhasil");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("RolesByUser/{username}")]
        public async Task<ActionResult<List<string>>> GetRolesByUser(string username)
        {
            var results = await _user.GetRolesFromUser(username);
            return Ok(results);
        }

        [AllowAnonymous]
        [HttpPost("Authentication")]
        public async Task<ActionResult<User>> Authentication(LoginUserDto loginUserDto)
        {
            try
            {
                var user = await _user.Authenticate(loginUserDto.Username, loginUserDto.Password);
                if (user == null)
                    return BadRequest("username/password tidak tepat");
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
