namespace ProjetoIMS.Application.DTOs.Localizacao
{
    public class LocalizacaoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public int QuantidadeAtivos { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}