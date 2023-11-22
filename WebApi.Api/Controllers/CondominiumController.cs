using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Api.Utilities;
using WebApi.Application.DTOs;
using WebApi.Application.Interfaces;
using WebApi.Application.services;
using WebApi.Domain.Entities;
using static System.Net.Mime.MediaTypeNames;
namespace App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CondominiumController : ControllerBase
    {
        private readonly ICondominiumServices _condominiumServices;
        private readonly IValidator<CondominiumDTO> _condominiumValidator;

        public CondominiumController(ICondominiumServices condominiumServices, IValidator<CondominiumDTO> condominiumValidator)
        {
            _condominiumServices = condominiumServices ?? throw new ArgumentNullException(nameof(condominiumServices));
            _condominiumValidator = condominiumValidator ?? throw new ArgumentNullException(nameof(condominiumValidator));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCondominiumByIdAsync(int id)
        {
            try
            {
                return await JsonHelpers.SerializeToJsonResponseAsync(_condominiumServices.GetCondominiumByIdAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("User/{idUser}")]
        public async Task<ActionResult> GetCondominiumsByUserAsync(int idUser)
        {
            try
            {
                return await JsonHelpers.SerializeToJsonResponseAsync(_condominiumServices.GetCondominiumsByUserAsync(idUser));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet()]
        public async Task<ActionResult> GetCondominiumsAllAsync()
        {
            try
            {
                return await JsonHelpers.SerializeToJsonResponseAsync(_condominiumServices.GetCondominiumsAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> RegisterItemAsync(CondominiumDTO condominiumDTO)
        {
            try
            {
                var validacao = await _condominiumValidator.ValidateAsync(condominiumDTO);

                if (!validacao.IsValid)
                {
                    return BadRequest(validacao.Errors);
                }

                Condominium condominium = await _condominiumServices.RegisterCondominiumAsync(condominiumDTO);
                return Ok(condominium);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> ChangeItemAsync(CondominiumDTO condominiumDTO)
        {
            try
            {
                var validacao = await _condominiumValidator.ValidateAsync(condominiumDTO);

                if (!validacao.IsValid)
                {
                    return BadRequest(validacao.Errors);
                }

                Condominium condominium = await _condominiumServices.ChangeCondominiumAsync(condominiumDTO);
                return Ok(condominium);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteItemAsync(CondominiumDTO condominiumDTO)
        {
            try
            {
                var validacao = await _condominiumValidator.ValidateAsync(condominiumDTO);

                if (!validacao.IsValid)
                {
                    return BadRequest(validacao.Errors);
                }

                var deleteCondominium = await _condominiumServices.DeleteCondominiumAsync(condominiumDTO);
                return Ok(deleteCondominium);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
