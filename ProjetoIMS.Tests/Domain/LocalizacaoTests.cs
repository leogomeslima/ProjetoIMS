using FluentAssertions;
using ProjetoIMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoIMS.Tests.Domain
{
    public class LocalizacaoTests
    {
        [Fact]
        public void Localizacao_DeveSerCriadaComSucesso()
        {
            // Arrange & Act
            var localizacao = new Localizacao("Prédio A - 1º Andar", "Sala de TI");

            // Assert
            localizacao.Should().NotBeNull();
            localizacao.Id.Should().NotBeEmpty();
            localizacao.Nome.Should().Be("Prédio A - 1º Andar");
            localizacao.Descricao.Should().Be("Sala de TI");
            localizacao.IsDeleted.Should().BeFalse();
        }

        [Fact]
        public void Localizacao_DeveAtualizarDadosCorretamente()
        {
            // Arrange
            var localizacao = new Localizacao("Nome Antigo", "Descrição Antiga");

            // Act
            localizacao.Update("Nome Novo", "Descrição Nova");

            // Assert
            localizacao.Nome.Should().Be("Nome Novo");
            localizacao.Descricao.Should().Be("Descrição Nova");
            localizacao.UpdatedAt.Should().NotBeNull();
        }
    }
}
