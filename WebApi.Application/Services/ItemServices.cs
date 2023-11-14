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
        //private readonly IMapper _mapper;
        private readonly IItemRepository _itemRepository;

        public ItemServices(IItemRepository itemRepository)//, IMapper mapper)
        {
            _itemRepository = itemRepository;
            //_mapper = mapper;
        }


        public async Task<Item?> GetItemByIdAsync(int id)
        {
            return await _itemRepository.GetItemByIdAsync(id);
        }

        public async Task<List<Item>> GetItemsByUserAsync(int idUser)
        {
            return await _itemRepository.GetItemsByUserAsync(idUser);
        }

        public async Task<Item> RegisterItemAsync(ItemDTO itemDTO)
        {
            var item = new Item();// _mapper.Map<Item>(itemDTO);

            return await _itemRepository.RegisterItemAsync(item);
        }

        public async Task<Item> ChangeItemAsync(ItemDTO itemDTO)
        {
            Item? itemChanged = await _itemRepository.GetItemByIdAsync(itemDTO.Id) ?? throw new Exception("Aluno não encontrado para o Cpf informado.");

            //var itemCategoryChanged = await _itemRepository.GetCategoryByIdAsync(item.CategoryId);

            itemChanged.Name = itemDTO.Name;
            itemChanged.IdCategory = itemDTO.IdCategory;
            itemChanged.Price = itemDTO.Price;
            itemChanged.Image = itemDTO.Image;
            itemChanged.DateChange = DateTime.Now;

            return await _itemRepository.ChangeItemAsync(itemChanged);
        }

        public async Task<Item> DeleteItemAsync(ItemDTO itemDTO)
        {
            var item = new Item();//_mapper.Map<Item>(itemDTO);

            return await _itemRepository.DeleteItemAsync(item);
        }
    }
}
