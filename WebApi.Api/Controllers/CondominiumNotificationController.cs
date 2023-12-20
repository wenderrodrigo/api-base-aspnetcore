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
    public class CondominiumNotification : ControllerBase
    {
        private readonly ICondominiumNotificationServices _condominiumNotificationServices;
        private readonly IValidator<CondominiumNotificationDTO> _condominiumNotificationValidator;

        public CondominiumNotification(ICondominiumNotificationServices condominiumNotificationServices, IValidator<CondominiumNotificationDTO> condominiumNotificationValidator)
        {
            _condominiumNotificationServices = condominiumNotificationServices ?? throw new ArgumentNullException(nameof(condominiumNotificationServices));
            _condominiumNotificationValidator = condominiumNotificationValidator ?? throw new ArgumentNullException(nameof(condominiumNotificationValidator));
        }

        [HttpGet("{id}", Name = "GetCondominiumNotificationById")]
        public async Task<ActionResult> GetCondominiumNotificationByIdAsync(int id)
        {
            try
            {
                return await JsonHelpers.SerializeToJsonResponseAsync(_condominiumNotificationServices.GetCondominiumNotificationByIdAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("User/{idUser}")]
        public async Task<ActionResult> GetCondominiumNotificationUserByIdAsync(int? idUser)
        {
            try
            {
                return await JsonHelpers.SerializeToJsonResponseAsync(_condominiumNotificationServices.GetCondominiumNotificationUserByIdAsync(idUser));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Condominium/{idCondominium}")]
        public async Task<ActionResult> GetCondominiumNotificationByIdCondominumAsync(int idCondominium)
        {
            try
            {
                return await JsonHelpers.SerializeToJsonResponseAsync(_condominiumNotificationServices.GetCondominiumNotificationByIdCondominumAsync(idCondominium));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{idCondominium}/{idTypeUser}/{idUser?}")]
        public async Task<ActionResult> GetCondominiumNotificationByIdCondominumAndIdTypeUserAsync(int idCondominium, int idTypeUser, int? idUser)
        {
            try
            {
                return await JsonHelpers.SerializeToJsonResponseAsync(_condominiumNotificationServices.GetCondominiumNotificationByIdCondominumAndIdTypeUserAsync(idCondominium, idTypeUser, idUser));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetCondominiumNotificationsAllAsync()
        {
            try
            {
                return await JsonHelpers.SerializeToJsonResponseAsync(_condominiumNotificationServices.GetCondominiumNotificationsAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> RegisterCondominiumNotificationAsync(CondominiumNotificationDTO condominiumNotificationDTO)
        {
            try
            {
                var validacao = await _condominiumNotificationValidator.ValidateAsync(condominiumNotificationDTO);

                if (!validacao.IsValid)
                {
                    return BadRequest(validacao.Errors);
                }

                var condominiumNotification = await _condominiumNotificationServices.RegisterCondominiumNotificationAsync(condominiumNotificationDTO);
                return CreatedAtAction("GetCondominiumNotificationById", new { id = condominiumNotification.Id }, condominiumNotification);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCondominiumNotificationAsync(CondominiumNotificationDTO condominiumNotificationDTO)
        {
            try
            {
                var validacao = await _condominiumNotificationValidator.ValidateAsync(condominiumNotificationDTO);

                if (!validacao.IsValid)
                {
                    return BadRequest(validacao.Errors);
                }

                var deleteNotification = await _condominiumNotificationServices.DeleteCondominiumNotificationAsync(condominiumNotificationDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
