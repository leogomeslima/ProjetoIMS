namespace ProjetoIMS.Application.DTOs.Asset
{
    public class UpdateAssetDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public string? NumeroSerie { get; set; }
        public decimal? TaxaDepreciacao { get; set; }
        public string? Observacoes { get; set; }
    }

}
