using ProjetoIMS.Domain.Enums;

namespace ProjetoIMS.Application.DTOs.Asset
{
    public class AssetFilterDto
    {
        public string? SearchTerm { get; set; }
        public string? Categoria { get; set; }
        public AssetStatus? Status { get; set; }
        public Guid? LocalizacaoId { get; set; }
        public Guid? ResponsavelId { get; set; }
        public DateTime? DataCompraInicio { get; set; }
        public DateTime? DataCompraFim { get; set; }
        public string? NumeroSerie { get; set; }
        public string? CodigoPatrimonio { get; set; }
        public decimal? ValorMinimo { get; set; }
        public decimal? ValorMaximo { get; set; }
        public string? OrderBy { get; set; }
        public bool OrderDescending { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
