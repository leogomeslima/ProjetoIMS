using ProjetoIMS.Domain.Enums;

namespace ProjetoIMS.Application.DTOs.Movimentacao
{
    public class MovimentacaoDto
    {
        public Guid Id { get; set; }
        public Guid AtivoId { get; set; }
        public string AtivoNome { get; set; } = string.Empty;
        public string AtivoCodigoPatrimonio { get; set; } = string.Empty;
        public Guid? LocalizacaoOrigemId { get; set; }
        public string? LocalizacaoOrigemNome { get; set; }
        public Guid? LocalizacaoDestinoId { get; set; }
        public string? LocalizacaoDestinoNome { get; set; }
        public Guid? ResponsavelId { get; set; }
        public string? ResponsavelNome { get; set; }
        public MovementReason Motivo { get; set; }
        public string MotivoDescricao { get; set; } = string.Empty;
        public string? Observacoes { get; set; }
        public DateTime DataHora { get; set; }
    }
}
