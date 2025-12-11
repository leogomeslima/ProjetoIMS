using FluentAssertions;
using ProjetoIMS.Domain.Entities;
using ProjetoIMS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoIMS.Tests.Domain
{
    public class MovimentacaoTests
    {
        [Fact]
        public void Movimentacao_DeveSerCriadaComSucesso()
        {
            // Arrange
            var ativoId = Guid.NewGuid();
            var origemId = Guid.NewGuid();
            var destinoId = Guid.NewGuid();

            // Act
            var movimentacao = new Movimentacao(
                ativoId,
                MovementReason.TrocaSetor,
                origemId,
                destinoId
            );

            // Assert
            movimentacao.Should().NotBeNull();
            movimentacao.AtivoId.Should().Be(ativoId);
            movimentacao.Motivo.Should().Be(MovementReason.TrocaSetor);
            movimentacao.LocalizacaoOrigemId.Should().Be(origemId);
            movimentacao.LocalizacaoDestinoId.Should().Be(destinoId);
            movimentacao.DataHora.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));
        }
    }
}
