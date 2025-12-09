using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoIMS.Domain.Entities
{
    public class Responsavel : BaseEntity
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string? Telefone { get; private set; }

        public virtual ICollection<Asset> Ativos { get; private set; }

        private Responsavel()
        {
            Ativos = new List<Asset>();
        }

        public Responsavel(string nome, string email, string? telefone = null) : this()
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }

        public void Update(string nome, string email, string? telefone)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Delete()
        {
            IsDeleted = true;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
