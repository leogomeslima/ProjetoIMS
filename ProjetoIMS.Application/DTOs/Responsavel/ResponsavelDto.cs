namespace ProjetoIMS.Application.DTOs.Responsavel
{
    public class ResponsavelDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Telefone { get; set; }
        public int QuantidadeAtivos { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
