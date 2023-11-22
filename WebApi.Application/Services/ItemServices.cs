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
    public class ItemServices : IItemServices
    {
        private readonly IMapper _mapper;
        private readonly IItemRepository _itemRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ItemServices(IItemRepository itemRepository,
            ICategoryRepository categoryRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }


        public async Task<Item?> GetItemByIdAsync(int id)
        {
            return await _itemRepository.GetItemByIdAsync(id);
        }

        public async Task<List<Item>> GetItemsByUserAsync(int idUser)
        {
            return await _itemRepository.GetItemsByUserAsync(idUser);
        }

        public async Task<List<Item>> GetItemsAllAsync()
        {
            return await _itemRepository.GetItemsAllAsync();
        }

        public async Task<Item> RegisterItemAsync(ItemDTO itemDTO)
        {
            var item = _mapper.Map<Item>(itemDTO);

            return await _itemRepository.RegisterItemAsync(item);
        }

        public async Task<Item> ChangeItemAsync(ItemDTO itemDTO)
        {
            // Obter o item pelo ID
            Item? itemChanged = await _itemRepository.GetItemByIdAsync(itemDTO.Id) ?? throw new Exception("Item não encontrado para o ID informado.");

            // Obter a categoria pelo ID
            var itemCategoryChanged = await _categoryRepository.GetCategoryByIdAsync(itemDTO.IdCategory) ?? throw new Exception("Categoria não encontrada para o ID informado.");

            // Atualizar os campos do item
            itemChanged.Name = itemDTO.Name;
            itemChanged.Category = itemCategoryChanged; // Corrigindo o typo 'itemCategoryChangedy'
            itemChanged.Price = itemDTO.Price;
            itemChanged.Image = itemDTO.Image;
            itemChanged.DateChange = DateTime.Now;

            // Salvar as mudanças no item
            return await _itemRepository.ChangeItemAsync(itemChanged);
        }


        public async Task<Item> DeleteItemAsync(ItemDTO itemDTO)
        {
            var item = _mapper.Map<Item>(itemDTO);

            return await _itemRepository.DeleteItemAsync(item);
        }
    }
}
