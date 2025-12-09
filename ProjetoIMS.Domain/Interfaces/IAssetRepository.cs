using ProjetoIMS.Domain.Entities;

namespace ProjetoIMS.Domain.Interfaces
{
    public interface IAssetRepository : IRepository<Asset>
    {
        Task<(IEnumerable<Asset> Items, int TotalCount)> GetPagedAsync(
            AssetSpecification specification,
            int pageNumber,
            int pageSize);
        Task<Asset?> GetByPatrimonioAsync(string codigoPatrimonio);
        Task<IEnumerable<Asset>> GetByStatusAsync(Enums.AssetStatus status);
        Task<IEnumerable<Asset>> GetByLocationAsync(Guid localizacaoId);
        Task<IEnumerable<Asset>> GetByResponsibleAsync(Guid responsavelId);
        Task<IEnumerable<Asset>> GetDepreciatedAssetsAsync(decimal minDepreciation);
    }
}
