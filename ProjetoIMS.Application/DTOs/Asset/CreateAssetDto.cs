namespace ProjetoIMS.Application.DTOs.Asset
{
    public class CreateAssetDto
    {
        public string Nome { get; set; } = string.Empty;
        public string CodigoPatrimonio { get; set; } = string.Empty;
        public string? NumeroSerie { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public DateTime DataCompra { get; set; }
        public decimal ValorCompra { get; set; }
        public decimal? TaxaDepreciacao { get; set; }
        public string? Observacoes { get; set; }
        public Guid? LocalizacaoId { get; set; }
        public Guid? ResponsavelId { get; set; }
    }
}
