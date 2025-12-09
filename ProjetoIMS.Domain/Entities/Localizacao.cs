using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoIMS.Domain.Entities
{
    public class Localizacao : BaseEntity
    {
        public string Nome { get; private set; }
        public string? Descricao { get; private set; }

        // Navigation Properties
        public virtual ICollection<Asset> Ativos { get; private set; }

        private Localizacao()
        {
            Ativos = new List<Asset>();
        }

        public Localizacao(string nome, string? descricao = null) : this()
        {
            Nome = nome;
            Descricao = descricao;
        }

        public void Update(string nome, string? descricao)
        {
            Nome = nome;
            Descricao = descricao;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Delete()
        {
            IsDeleted = true;
            UpdatedAt = DateTime.UtcNow;
        }
    }

}
