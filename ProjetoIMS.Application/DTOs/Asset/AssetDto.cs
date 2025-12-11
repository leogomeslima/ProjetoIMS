using ProjetoIMS.Domain.Enums;

namespace ProjetoIMS.Application.DTOs.Asset
{
    public class AssetDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string CodigoPatrimonio { get; set; } = string.Empty;
        public string? NumeroSerie { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public DateTime DataCompra { get; set; }
        public decimal ValorCompra { get; set; }
        public decimal? TaxaDepreciacao { get; set; }
        public AssetStatus Status { get; set; }
        public string? Observacoes { get; set; }
        public string? QRCode { get; set; }
        public Guid? LocalizacaoId { get; set; }
        public string? LocalizacaoNome { get; set; }
        public Guid? ResponsavelId { get; set; }
        public string? ResponsavelNome { get; set; }
        public decimal ValorAtual { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
