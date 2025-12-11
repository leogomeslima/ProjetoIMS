using AutoMapper;
using ProjetoIMS.Application.DTOs.Responsavel;
using ProjetoIMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoIMS.Application.Mappings
{
    public class ResponsavelProfile : Profile
    {
        public ResponsavelProfile()
        {
            CreateMap<Responsavel, ResponsavelDto>()
                .ForMember(dest => dest.QuantidadeAtivos,
                    opt => opt.MapFrom(src => src.Ativos.Count(a => !a.IsDeleted)));

            CreateMap<CreateResponsavelDto, Responsavel>()
                .ConstructUsing(src => new Responsavel(src.Nome, src.Email, src.Telefone));
        }
    }
}
