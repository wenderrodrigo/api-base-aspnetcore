using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Api.Utilities;
using WebApi.Application.DTOs;
using WebApi.Application.Interfaces;
using WebApi.Domain.Entities;
using static System.Net.Mime.MediaTypeNames;
namespace App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsForSaleController : ControllerBase
    {
        private readonly IItemServices _itemsServices;
        private readonly ICategoryServices _categoryServices;
        private readonly IValidator<ItemDTO> _itemsValidator;

        public ItemsForSaleController(IItemServices itemsServices, ICategoryServices categoryServices, IValidator<ItemDTO> itemsValidator)
        {
            _itemsServices = itemsServices ?? throw new ArgumentNullException(nameof(itemsServices));
            _categoryServices = categoryServices ?? throw new ArgumentNullException(nameof(categoryServices));
            _itemsValidator = itemsValidator ?? throw new ArgumentNullException(nameof(itemsValidator));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetItemAsync(int id)
        {
            try
            {
                return await JsonHelpers.SerializeToJsonResponseAsync(_itemsServices.GetItemByIdAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("User/{idUser}")]
        public async Task<ActionResult> GetItemsByUserAsync(int idUser)
        {
            try
            {
                return await JsonHelpers.SerializeToJsonResponseAsync(_itemsServices.GetItemsByUserAsync(idUser));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Category/{idCategory}")]
        public async Task<ActionResult> GetItemsByCategoryAsync(int idCategory)
        {
            try
            {
                return await JsonHelpers.SerializeToJsonResponseAsync(_itemsServices.GetItemsByCategoryAsync(idCategory));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet()]
        public async Task<ActionResult> GetItemsAllAsync()
        {
            try
            {
                return await JsonHelpers.SerializeToJsonResponseAsync(_itemsServices.GetItemsAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> RegisterItemAsync(ItemDTO itemDto)
        {
            try
            {
                var validacao = await _itemsValidator.ValidateAsync(itemDto);

                if (!validacao.IsValid)
                {
                    return BadRequest(validacao.Errors);
                }

                Item item = await _itemsServices.RegisterItemAsync(itemDto);
                return StatusCode(201, item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> ChangeItemAsync(ItemDTO itemDto)
        {
            try
            {
                var validacao = await _itemsValidator.ValidateAsync(itemDto);

                if (!validacao.IsValid)
                {
                    return BadRequest(validacao.Errors);
                }

                Item item = await _itemsServices.ChangeItemAsync(itemDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteItemAsync(int idItem)
        {
            try
            {
                if (idItem == 0)
                {
                    return BadRequest();
                }

                var deletedItem = await _itemsServices.DeleteItemAsync(idItem);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
