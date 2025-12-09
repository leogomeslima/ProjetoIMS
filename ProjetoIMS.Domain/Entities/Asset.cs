using ProjetoIMS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoIMS.Domain.Entities
{
    public class Asset : BaseEntity
    {
        public string Nome { get; private set; }
        public string CodigoPatrimonio { get; private set; }
        public string? NumeroSerie { get; private set; }
        public string Categoria { get; private set; }
        public DateTime DataCompra { get; private set; }
        public decimal ValorCompra { get; private set; }
        public decimal? TaxaDepreciacao { get; private set; }
        public AssetStatus Status { get; private set; }
        public string? Observacoes { get; private set; }
        public string? QRCode { get; private set; }

        // Foreign Keys
        public Guid? LocalizacaoId { get; private set; }
        public Guid? ResponsavelId { get; private set; }

        // Navigation Properties
        public virtual Localizacao? Localizacao { get; private set; }
        public virtual Responsavel? Responsavel { get; private set; }
        public virtual ICollection<Movimentacao> Movimentacoes { get; private set; }

        private Asset()
        {
            Movimentacoes = new List<Movimentacao>();
        }

        public Asset(
            string nome,
            string codigoPatrimonio,
            string categoria,
            DateTime dataCompra,
            decimal valorCompra,
            string? numeroSerie = null,
            decimal? taxaDepreciacao = null,
            string? observacoes = null)
            : this()
        {
            Nome = nome;
            CodigoPatrimonio = codigoPatrimonio;
            NumeroSerie = numeroSerie;
            Categoria = categoria;
            DataCompra = dataCompra;
            ValorCompra = valorCompra;
            TaxaDepreciacao = taxaDepreciacao;
            Status = AssetStatus.Ativo;
            Observacoes = observacoes;
            GenerateQRCode();
        }

        public void Update(
            string nome,
            string categoria,
            string? numeroSerie,
            decimal? taxaDepreciacao,
            string? observacoes)
        {
            Nome = nome;
            Categoria = categoria;
            NumeroSerie = numeroSerie;
            TaxaDepreciacao = taxaDepreciacao;
            Observacoes = observacoes;
            UpdatedAt = DateTime.UtcNow;
        }

        public void ChangeStatus(AssetStatus newStatus)
        {
            Status = newStatus;
            UpdatedAt = DateTime.UtcNow;
        }

        public void AssignLocation(Guid? localizacaoId)
        {
            LocalizacaoId = localizacaoId;
            UpdatedAt = DateTime.UtcNow;
        }

        public void AssignResponsible(Guid? responsavelId)
        {
            ResponsavelId = responsavelId;
            UpdatedAt = DateTime.UtcNow;
        }

        public decimal CalculateDepreciation()
        {
            if (!TaxaDepreciacao.HasValue || TaxaDepreciacao.Value == 0)
                return ValorCompra;

            var anos = (DateTime.UtcNow - DataCompra).TotalDays / 365;
            var depreciacao = ValorCompra * (TaxaDepreciacao.Value / 100) * (decimal)anos;
            var valorAtual = ValorCompra - depreciacao;

            return valorAtual > 0 ? valorAtual : 0;
        }

        private void GenerateQRCode()
        {
            QRCode = $"ASSET-{CodigoPatrimonio}-{Id}";
        }

        public void Delete()
        {
            IsDeleted = true;
            Status = AssetStatus.Baixa;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
