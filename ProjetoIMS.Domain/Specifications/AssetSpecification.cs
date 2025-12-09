using ProjetoIMS.Domain.Enums;

namespace ProjetoIMS.Domain.Specifications
{
    public class AssetSpecification
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

        public bool HasFilters()
        {
            return !string.IsNullOrWhiteSpace(SearchTerm) ||
                   !string.IsNullOrWhiteSpace(Categoria) ||
                   Status.HasValue ||
                   LocalizacaoId.HasValue ||
                   ResponsavelId.HasValue ||
                   DataCompraInicio.HasValue ||
                   DataCompraFim.HasValue ||
                   !string.IsNullOrWhiteSpace(NumeroSerie) ||
                   !string.IsNullOrWhiteSpace(CodigoPatrimonio) ||
                   ValorMinimo.HasValue ||
                   ValorMaximo.HasValue;
        }
    }

}
