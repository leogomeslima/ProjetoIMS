namespace ProjetoIMS.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAssetRepository Assets { get; }
        ILocalizacaoRepository Localizacoes { get; }
        IResponsavelRepository Responsaveis { get; }
        IMovimentacaoRepository Movimentacoes { get; }
        Task<int> CommitAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
