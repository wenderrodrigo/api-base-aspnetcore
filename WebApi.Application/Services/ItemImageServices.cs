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
    public class ItemImageServices : IItemImageServices
    {
        private readonly IMapper _mapper;
        private readonly IItemImageRepository _itemImageRepository;

        public ItemImageServices(IItemImageRepository itemImageRepository,
            IMapper mapper)
        {
            _itemImageRepository = itemImageRepository;
            _mapper = mapper;
        }


        public async Task<ItemImage?> GetItemImageByIdAsync(int id)
        {
            return await _itemImageRepository.GetItemImageByIdAsync(id);
        }

        public async Task<List<ItemImage>> GetItemImagesAllAsync()
        {
            return await _itemImageRepository.GetItemImagesAllAsync();
        }

        public async Task<ItemImage> RegisterItemImageAsync(ItemImageDTO itemImageDTO)
        {
            var itemImage = _mapper.Map<ItemImage>(itemImageDTO);

            return await _itemImageRepository.RegisterItemImageAsync(itemImage);
        }

        public async Task<ItemImage> ChangeItemImageAsync(ItemImageDTO itemImageDTO)
        {
            // Obter o item pelo ID
            ItemImage? itemChanged = await _itemImageRepository.GetItemImageByIdAsync(itemImageDTO.Id) ?? throw new Exception("Item não encontrado para o ID informado.");

            // Atualizar os campos do item
            itemChanged.PathImagem = itemImageDTO.PathImagem;

            // Salvar as mudanças no item
            return await _itemImageRepository.ChangeItemImageAsync(itemChanged);
        }


        public async Task<ItemImage> DeleteItemImageAsync(int idItem)
        {
            // Obter o item pelo ID
            ItemImage? item = await _itemImageRepository.GetItemImageByIdAsync(idItem) ?? throw new Exception("Item não encontrado para o ID informado.");

            return await _itemImageRepository.DeleteItemImageAsync(item);
        }
    }
}
