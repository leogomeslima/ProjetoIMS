using ProjetoIMS.Domain.Entities;

namespace ProjetoIMS.Domain.Interfaces
{
    public interface IResponsavelRepository : IRepository<Responsavel>
    {
        Task<Responsavel?> GetByEmailAsync(string email);
        Task<IEnumerable<Responsavel>> GetWithAssetsAsync();
    }
}
