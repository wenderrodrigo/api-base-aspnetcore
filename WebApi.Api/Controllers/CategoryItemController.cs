using FluentValidation;
using Microsoft.AspNetCore.Http;
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
    public class CategoryItemController : ControllerBase
    {
        private readonly ICategoryServices _categoryServices;
        private readonly IValidator<CategoryDTO> _categoryValidator;

        public CategoryItemController(ICategoryServices categoryServices, IValidator<CategoryDTO> categoryValidator)
        {
            _categoryServices = categoryServices ?? throw new ArgumentNullException(nameof(categoryServices));
            _categoryValidator = categoryValidator ?? throw new ArgumentNullException(nameof(categoryValidator));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCategoryAsync(int id)
        {
            try
            {
                var category = await _categoryServices.GetCategoryByIdAsync(id);

                if (category is null)
                    return NoContent();

                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{idItem}")]
        public async Task<ActionResult> GetCategoryByItemAsync(int id)
        {
            try
            {
                var category = await _categoryServices.GetCategoryByItemAsync(id);

                if (category is null)
                    return NoContent();

                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet()]
        public async Task<ActionResult> GetCategoriesAllAsync()
        {
            try
            {
                var category = await _categoryServices.GetCategoriesAllAsync();

                if (category is null)
                    return NoContent();

                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> RegisterItemAsync(CategoryDTO categoryDTO)
        {
            try
            {
                var validacao = await _categoryValidator.ValidateAsync(categoryDTO);

                if (!validacao.IsValid)
                {
                    return BadRequest(validacao.Errors);
                }

                Category category = await _categoryServices.RegisterCategoryAsync(categoryDTO);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> ChangeItemAsync(CategoryDTO categoryDTO)
        {
            try
            {
                var validacao = await _categoryValidator.ValidateAsync(categoryDTO);

                if (!validacao.IsValid)
                {
                    return BadRequest(validacao.Errors);
                }

                Category category = await _categoryServices.ChangeCategoryAsync(categoryDTO);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteItemAsync(CategoryDTO categoryDTO)
        {
            try
            {
                var validacao = await _categoryValidator.ValidateAsync(categoryDTO);

                if (!validacao.IsValid)
                {
                    return BadRequest(validacao.Errors);
                }

                var deletedCategory = await _categoryServices.DeleteCategoryAsync(categoryDTO);
                return Ok(deletedCategory);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
