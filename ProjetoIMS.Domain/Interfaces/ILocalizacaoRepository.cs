using ProjetoIMS.Domain.Entities;

namespace ProjetoIMS.Domain.Interfaces
{
    public interface ILocalizacaoRepository : IRepository<Localizacao>
    {
        Task<Localizacao?> GetByNameAsync(string nome);
        Task<IEnumerable<Localizacao>> GetWithAssetsAsync();
    }
}
