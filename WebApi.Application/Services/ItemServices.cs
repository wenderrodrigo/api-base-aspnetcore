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
        private readonly IUserRepository _userRepository;

        public ItemServices(IItemRepository itemRepository,
            ICategoryRepository categoryRepository,
            IUserRepository userRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
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

        public async Task<List<Item>> GetItemsByCategoryAsync(int idCategory)
        {
            return await _itemRepository.GetItemsByCategoryAsync(idCategory);
        }

        public async Task<List<Item>> GetItemsAllAsync()
        {
            return await _itemRepository.GetItemsAllAsync();
        }

        public async Task<Item> RegisterItemAsync(ItemDTO itemDTO)
        {
            // Obter a categoria pelo ID
            var itemCategoryRegister = await _categoryRepository.GetCategoryByIdAsync(itemDTO.IdCategory) ?? throw new Exception("Categoria não encontrada para o ID informado.");
            var itemUserRegister = await _userRepository.GetUserByIdAsync(itemDTO.IdUser) ?? throw new Exception("Categoria não encontrada para o ID informado.");

            var item = _mapper.Map<Item>(itemDTO);
            List<ItemImage> itemImages = _mapper.Map<List<ItemImage>>(itemDTO.ItemImagesDTO);

            item.Category = itemCategoryRegister;
            item.User = itemUserRegister;
            item.ItemImages = itemImages;

            return await _itemRepository.RegisterItemAsync(item);
        }

        public async Task<Item> ChangeItemAsync(ItemDTO itemDTO)
        {
            // Obter o item pelo ID
            Item? itemChanged = await _itemRepository.GetItemByIdAsync(itemDTO.Id) ?? throw new Exception("Item não encontrado para o ID informado.");

            // Obter a categoria pelo ID
            var itemCategoryChanged = await _categoryRepository.GetCategoryByIdAsync(itemDTO.IdCategory) ?? throw new Exception("Categoria não encontrada para o ID informado.");

            List<ItemImage> itemImages = _mapper.Map<List<ItemImage>>(itemDTO.ItemImagesDTO);

            // Atualizar os campos do item
            itemChanged.Name = itemDTO.Name;
            itemChanged.Category = itemCategoryChanged; // Corrigindo o typo 'itemCategoryChangedy'
            itemChanged.Price = itemDTO.Price;
            itemChanged.ItemImages = itemImages;
            itemChanged.DateChange = DateTime.Now;

            // Salvar as mudanças no item
            return await _itemRepository.ChangeItemAsync(itemChanged);
        }


        public async Task<Item> DeleteItemAsync(int idItem)
        {
            // Obter o item pelo ID
            Item? item = await _itemRepository.GetItemByIdAsync(idItem) ?? throw new Exception("Item não encontrado para o ID informado.");

            return await _itemRepository.DeleteItemAsync(item);
        }
    }
}
