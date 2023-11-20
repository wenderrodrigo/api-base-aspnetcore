using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.DTOs;
using WebApi.Application.Interfaces;
using WebApi.Application.services;
using WebApi.Domain.Entities;
using static System.Net.Mime.MediaTypeNames;
namespace App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly IValidator<UserDTO> _userValidator;

        public UserController(IUserServices userServices, IValidator<UserDTO> userValidator)
        {
            _userServices = userServices ?? throw new ArgumentNullException(nameof(userServices));
            _userValidator = userValidator ?? throw new ArgumentNullException(nameof(userValidator));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUserByIdAsync(int id)
        {
            try
            {
                var user = await _userServices.GetUserByIdAsync(id);

                if (user is null)
                    return NoContent();

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{idCondominium}")]
        public async Task<ActionResult> GetUsersByCondominiumAsync(int idCondominium)
        {
            try
            {
                var user = await _userServices.GetUsersByCondominiumAsync(idCondominium);

                if (user is null)
                    return NoContent();

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> RegisterItemAsync(UserDTO userDTO)
        {
            try
            {
                var validacao = await _userValidator.ValidateAsync(userDTO);

                if (!validacao.IsValid)
                {
                    return BadRequest(validacao.Errors);
                }

                User user = await _userServices.RegisterUserAsync(userDTO);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> ChangeItemAsync(UserDTO userDTO)
        {
            try
            {
                var validacao = await _userValidator.ValidateAsync(userDTO);

                if (!validacao.IsValid)
                {
                    return BadRequest(validacao.Errors);
                }

                User user = await _userServices.ChangeUserAsync(userDTO);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteItemAsync(UserDTO userDTO)
        {
            try
            {
                var validacao = await _userValidator.ValidateAsync(userDTO);

                if (!validacao.IsValid)
                {
                    return BadRequest(validacao.Errors);
                }

                var deleteUser = await _userServices.DeleteUserAsync(userDTO);
                return Ok(deleteUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
