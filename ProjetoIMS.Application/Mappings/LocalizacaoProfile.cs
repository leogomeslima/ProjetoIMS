using AutoMapper;
using ProjetoIMS.Application.DTOs.Localizacao;
using ProjetoIMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoIMS.Application.Mappings
{
    public class LocalizacaoProfile : Profile
    {
        public LocalizacaoProfile()
        {
            CreateMap<Localizacao, LocalizacaoDto>()
                .ForMember(dest => dest.QuantidadeAtivos,
                    opt => opt.MapFrom(src => src.Ativos.Count(a => !a.IsDeleted)));

            CreateMap<CreateLocalizacaoDto, Localizacao>()
                .ConstructUsing(src => new Localizacao(src.Nome, src.Descricao));
        }
    }
}
