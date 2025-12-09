using ProjetoIMS.Domain.Enums;

namespace ProjetoIMS.Domain.Entities
{
    public class Movimentacao : BaseEntity
    {
        public Guid AtivoId { get; private set; }
        public Guid? LocalizacaoOrigemId { get; private set; }
        public Guid? LocalizacaoDestinoId { get; private set; }
        public Guid? ResponsavelId { get; private set; }
        public MovementReason Motivo { get; private set; }
        public string? Observacoes { get; private set; }
        public DateTime DataHora { get; private set; }


        public virtual Asset Ativo { get; private set; }
        public virtual Localizacao? LocalizacaoOrigem { get; private set; }
        public virtual Localizacao? LocalizacaoDestino { get; private set; }
        public virtual Responsavel? Responsavel { get; private set; }

        private Movimentacao() { }

        public Movimentacao(
            Guid ativoId,
            MovementReason motivo,
            Guid? localizacaoOrigemId = null,
            Guid? localizacaoDestinoId = null,
            Guid? responsavelId = null,
            string? observacoes = null)
        {
            AtivoId = ativoId;
            Motivo = motivo;
            LocalizacaoOrigemId = localizacaoOrigemId;
            LocalizacaoDestinoId = localizacaoDestinoId;
            ResponsavelId = responsavelId;
            Observacoes = observacoes;
            DataHora = DateTime.UtcNow;
        }
    }

}
