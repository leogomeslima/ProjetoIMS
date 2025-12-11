namespace ProjetoIMS.Application.DTOs.Responsavel
{
    public class CreateResponsavelDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Telefone { get; set; }
    }
}
