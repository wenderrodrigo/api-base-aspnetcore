using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using WebApi.Application.DTOs;
using WebApi.Application.Interfaces;
using WebApi.Application.services;
using WebApi.Domain.Entities;
using static System.Net.Mime.MediaTypeNames;
using System.Net;
using Newtonsoft.Json;
using WebApi.Api.Utilities;

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
                return await JsonHelpers.SerializeToJsonResponseAsync(_userServices.GetUserByIdAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Condominium/{idCondominium}")]
        public async Task<ActionResult> GetUsersByCondominiumAsync(int idCondominium)
        {
            try
            {
                return await JsonHelpers.SerializeToJsonResponseAsync(_userServices.GetUsersByCondominiumAsync(idCondominium));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet()]
        public async Task<ActionResult> GetUsersAllAsync()
        {
            try
            {
                return await JsonHelpers.SerializeToJsonResponseAsync(_userServices.GetUsersAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult> RegisterUserAsync(UserDTO userDTO)
        {
            try
            {
                var validacao = await _userValidator.ValidateAsync(userDTO);

                if (!validacao.IsValid)
                {
                    return BadRequest(validacao.Errors);
                }

                User user = await _userServices.RegisterUserAsync(userDTO);
                return CreatedAtAction(nameof(GetUserByIdAsync), new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> ChangeUserAsync(UserDTO userDTO)
        {
            try
            {
                var validacao = await _userValidator.ValidateAsync(userDTO);

                if (!validacao.IsValid)
                {
                    return BadRequest(validacao.Errors);
                }

                User user = await _userServices.ChangeUserAsync(userDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteUserAsync(UserDTO userDTO)
        {
            try
            {
                var validacao = await _userValidator.ValidateAsync(userDTO);

                if (!validacao.IsValid)
                {
                    return BadRequest(validacao.Errors);
                }

                var deleteUser = await _userServices.DeleteUserAsync(userDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
