using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using WebApi.Api.Utilities;
using WebApi.Application.DTOs;
using WebApi.Application.Interfaces;
using WebApi.Domain.Entities;

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

        /// <summary>
        /// Obtem a categoria pelo um Id.
        /// </summary>
        /// <param name="id">Id da categoria.</param>
        /// <returns>Uma instância de <see cref="Category"/>.</returns>
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Solicitação obtida com sucesso.", Type = typeof(string))]
        [SwaggerResponse((int)HttpStatusCode.NoContent, Description = "Nenhum dado encontrado.", Type = typeof(string))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Parâmetro(s) não informado(s).", Type = typeof(string))]
        //[Route("api/certificados/protocolo/{protocolo}")]
        //[AcceptVerbs("Get")]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCategoryAsync(int id)
        {
            try
            {
                return await JsonHelpers.SerializeToJsonResponseAsync(_categoryServices.GetCategoryByIdAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Item/{idItem}")]
        public async Task<ActionResult> GetCategoryByItemAsync(int id)
        {
            try
            {
                return await JsonHelpers.SerializeToJsonResponseAsync(_categoryServices.GetCategoryByItemAsync(id));
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
                return await JsonHelpers.SerializeToJsonResponseAsync(_categoryServices.GetCategoriesAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> RegisterCategoryAsync(CategoryDTO categoryDTO)
        {
            try
            {
                var validacao = await _categoryValidator.ValidateAsync(categoryDTO);

                if (!validacao.IsValid)
                {
                    return BadRequest(validacao.Errors);
                }

                Category category = await _categoryServices.RegisterCategoryAsync(categoryDTO);
                return CreatedAtAction(nameof(GetCategoryAsync), new { id = category.Id }, category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> ChangeCategoryAsync(CategoryDTO categoryDTO)
        {
            try
            {
                var validacao = await _categoryValidator.ValidateAsync(categoryDTO);

                if (!validacao.IsValid)
                {
                    return BadRequest(validacao.Errors);
                }

                Category category = await _categoryServices.ChangeCategoryAsync(categoryDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCategoryAsync(CategoryDTO categoryDTO)
        {
            try
            {
                var validacao = await _categoryValidator.ValidateAsync(categoryDTO);

                if (!validacao.IsValid)
                {
                    return BadRequest(validacao.Errors);
                }

                var deletedCategory = await _categoryServices.DeleteCategoryAsync(categoryDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
