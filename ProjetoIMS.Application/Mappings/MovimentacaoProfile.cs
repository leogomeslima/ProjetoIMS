using AutoMapper;
using ProjetoIMS.Application.DTOs.Movimentacao;
using ProjetoIMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoIMS.Application.Mappings
{
    public class MovimentacaoProfile : Profile
    {
        public MovimentacaoProfile()
        {
            CreateMap<Movimentacao, MovimentacaoDto>()
                .ForMember(dest => dest.AtivoNome,
                    opt => opt.MapFrom(src => src.Ativo.Nome))
                .ForMember(dest => dest.AtivoCodigoPatrimonio,
                    opt => opt.MapFrom(src => src.Ativo.CodigoPatrimonio))
                .ForMember(dest => dest.LocalizacaoOrigemNome,
                    opt => opt.MapFrom(src => src.LocalizacaoOrigem != null ? src.LocalizacaoOrigem.Nome : null))
                .ForMember(dest => dest.LocalizacaoDestinoNome,
                    opt => opt.MapFrom(src => src.LocalizacaoDestino != null ? src.LocalizacaoDestino.Nome : null))
                .ForMember(dest => dest.ResponsavelNome,
                    opt => opt.MapFrom(src => src.Responsavel != null ? src.Responsavel.Nome : null))
                .ForMember(dest => dest.MotivoDescricao,
                    opt => opt.MapFrom(src => src.Motivo.ToString()));

            CreateMap<CreateMovimentacaoDto, Movimentacao>()
                .ConstructUsing(src => new Movimentacao(
                    src.AtivoId,
                    src.Motivo,
                    src.LocalizacaoOrigemId,
                    src.LocalizacaoDestinoId,
                    src.ResponsavelId,
                    src.Observacoes));
        }
    }
}
