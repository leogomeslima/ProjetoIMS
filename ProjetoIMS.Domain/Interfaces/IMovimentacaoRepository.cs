using ProjetoIMS.Domain.Entities;

namespace ProjetoIMS.Domain.Interfaces
{
    public interface IMovimentacaoRepository : IRepository<Movimentacao>
    {
        Task<IEnumerable<Movimentacao>> GetByAssetAsync(Guid ativoId);
        Task<IEnumerable<Movimentacao>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Movimentacao>> GetByLocationAsync(Guid localizacaoId);
        Task<(IEnumerable<Movimentacao> Items, int TotalCount)> GetPagedAsync(
            int pageNumber,
            int pageSize,
            Guid? ativoId = null);
    }
}
