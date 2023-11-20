using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using WebApi.Application.DTOs;
using WebApi.Application.Interfaces;
using WebApi.Application.Interfaces.Repositories;
using WebApi.Domain.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace WebApi.Application.services
{
    public class CategoryServices : ICategoryServices
    {
        //private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryServices(ICategoryRepository categoryRepository)//, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            //_mapper = mapper;
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            return await _categoryRepository.GetCategoryByIdAsync(id);
        }

        public async Task<List<Category>> GetCategoriesAllAsync()
        {
            return await _categoryRepository.GetCategoriesAllAsync();
        }

        public async Task<Category?> GetCategoryByItemAsync(int idItem)
        {
            return await _categoryRepository.GetCategoryByItemAsync(idItem);
        }

        public async Task<Category> RegisterCategoryAsync(CategoryDTO categoryDTO)
        {
            var category = new Category();// _mapper.Map<Item>(categoryDTO);

            return await _categoryRepository.RegisterCategoryAsync(category);
        }

        public async Task<Category> ChangeCategoryAsync(CategoryDTO categoryDTO)
        {
            Category? categoryChanged = await _categoryRepository.GetCategoryByIdAsync(categoryDTO.Id) ?? throw new Exception("Aluno não encontrado para o Cpf informado.");

            categoryChanged.Name = categoryDTO.Name;
            categoryChanged.StatusId = categoryDTO.StatusId;

            return await _categoryRepository.ChangeCategoryAsync(categoryChanged);
        }

        public async Task<Category> DeleteCategoryAsync(CategoryDTO categoryDTO)
        {
            var category = new Category();//_mapper.Map<Category>(categoryDTO);

            return await _categoryRepository.DeleteCategoryAsync(category);
        }
    }
}
