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
    public class CondominiumServices : ICondominiumServices
    {
        //private readonly IMapper _mapper;
        private readonly ICondominiumRepository _condominiumRepository;

        public CondominiumServices(ICondominiumRepository condominiumRepository)//, IMapper mapper)
        {
            _condominiumRepository = condominiumRepository;
            //_mapper = mapper;
        }

        public async Task<Condominium?> GetCondominiumByIdAsync(int id)
        {
            return await _condominiumRepository.GetCondominiumByIdAsync(id);
        }

        public async Task<List<Condominium>> GetCondominiumsByUserAsync(int idUser)
        {
            return await _condominiumRepository.GetCondominiumsByUserAsync(idUser);
        }

        public async Task<Condominium> RegisterCondominiumAsync(CondominiumDTO condominiumDTO)
        {
            var condominium = new Condominium();// _mapper.Map<CondominiumDTO>(condominiumDTO);

            return await _condominiumRepository.RegisterCondominiumAsync(condominium);
        }

        public async Task<Condominium> ChangeCondominiumAsync(CondominiumDTO condominiumDTO)
        {
            Condominium? condominiumChanged = await _condominiumRepository.GetCondominiumByIdAsync(condominiumDTO.Id) ?? throw new Exception("Aluno não encontrado para o Cpf informado.");

            condominiumChanged.Name = condominiumDTO.Name;
            condominiumChanged.StatusId = 1;
            condominiumChanged.Cnpj = condominiumDTO.Cnpj;
            condominiumChanged.DateRegister = DateTime.Now;
            condominiumChanged.DateChange = DateTime.Now;

            return await _condominiumRepository.ChangeCondominiumAsync(condominiumChanged);
        }

        public async Task<Condominium> DeleteCondominiumAsync(CondominiumDTO condominiumDTO)
        {
            var condominium = new Condominium();//_mapper.Map<Condominium>(condominiumDTO);

            return await _condominiumRepository.DeleteCondominiumAsync(condominium);
        }
    }
}
