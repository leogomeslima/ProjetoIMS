using ProjetoIMS.Domain.Enums;

namespace ProjetoIMS.Application.DTOs.Movimentacao
{
    public class CreateMovimentacaoDto
    {
        public Guid AtivoId { get; set; }
        public Guid? LocalizacaoOrigemId { get; set; }
        public Guid? LocalizacaoDestinoId { get; set; }
        public Guid? ResponsavelId { get; set; }
        public MovementReason Motivo { get; set; }
        public string? Observacoes { get; set; }
    }
}
