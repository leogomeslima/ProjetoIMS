using AutoMapper;
using ProjetoIMS.Application.DTOs.Asset;
using ProjetoIMS.Domain.Entities;

namespace ProjetoIMS.Application.Mappings
{
    public class AssetProfile : Profile
    {
        public AssetProfile()
        {
            CreateMap<Asset, AssetDto>()
                .ForMember(dest => dest.LocalizacaoNome,
                    opt => opt.MapFrom(src => src.Localizacao != null ? src.Localizacao.Nome : null))
                .ForMember(dest => dest.ResponsavelNome,
                    opt => opt.MapFrom(src => src.Responsavel != null ? src.Responsavel.Nome : null))
                .ForMember(dest => dest.ValorAtual,
                    opt => opt.MapFrom(src => src.CalculateDepreciation()));

            CreateMap<CreateAssetDto, Asset>()
                .ConstructUsing(src => new Asset(
                    src.Nome,
                    src.CodigoPatrimonio,
                    src.Categoria,
                    src.DataCompra,
                    src.ValorCompra,
                    src.NumeroSerie,
                    src.TaxaDepreciacao,
                    src.Observacoes))
                .ForMember(dest => dest.LocalizacaoId, opt => opt.MapFrom(src => src.LocalizacaoId))
                .ForMember(dest => dest.ResponsavelId, opt => opt.MapFrom(src => src.ResponsavelId));
        }
    }
}
