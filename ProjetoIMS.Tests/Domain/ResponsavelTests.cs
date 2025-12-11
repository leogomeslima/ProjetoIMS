using FluentAssertions;
using ProjetoIMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoIMS.Tests.Domain
{
    public class ResponsavelTests
    {
        [Fact]
        public void Responsavel_DeveSerCriadoComSucesso()
        {
            // Arrange & Act
            var responsavel = new Responsavel(
                "João Silva",
                "joao@empresa.com",
                "(11) 98765-4321"
            );

            // Assert
            responsavel.Should().NotBeNull();
            responsavel.Id.Should().NotBeEmpty();
            responsavel.Nome.Should().Be("João Silva");
            responsavel.Email.Should().Be("joao@empresa.com");
            responsavel.Telefone.Should().Be("(11) 98765-4321");
        }
    }

}
