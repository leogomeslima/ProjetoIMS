namespace ProjetoIMS.Application.DTOs.Dashboard
{
    public class DashboardDto
    {
        public int TotalAtivos { get; set; }
        public int AtivosAtivos { get; set; }
        public int AtivosEmManutencao { get; set; }
        public int AtivosInativos { get; set; }
        public int AtivosBaixa { get; set; }
        public int AtivosPerdidos { get; set; }
        public decimal ValorTotalAtivos { get; set; }
        public decimal ValorAtualAtivos { get; set; }
        public List<AssetsByStatusDto> AtivosPorStatus { get; set; } = new();
        public List<AssetsByLocationDto> AtivosPorLocalizacao { get; set; } = new();
        public List<AssetsByCategoryDto> AtivosPorCategoria { get; set; } = new();
    }

    public class AssetsByStatusDto
    {
        public string Status { get; set; } = string.Empty;
        public int Quantidade { get; set; }
    }

    public class AssetsByLocationDto
    {
        public string Localizacao { get; set; } = string.Empty;
        public int Quantidade { get; set; }
    }

    public class AssetsByCategoryDto
    {
        public string Categoria { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public decimal ValorTotal { get; set; }
    }

}
