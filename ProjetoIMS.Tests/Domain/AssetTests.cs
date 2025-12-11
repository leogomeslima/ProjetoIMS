using FluentAssertions;
using ProjetoIMS.Domain.Entities;
using ProjetoIMS.Domain.Enums;
using Xunit;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoIMS.Tests.Domain
{
    public class AssetTests
    {
        [Fact]
        public void Asset_DeveSerCriadoComSucessoComDadosValidos()
        {
            // Arrange & Act
            var asset = new Asset(
                nome: "Notebook Dell",
                codigoPatrimonio: "NB-001",
                categoria: "Informática",
                dataCompra: DateTime.UtcNow.AddDays(-30),
                valorCompra: 5000m,
                numeroSerie: "SN123",
                taxaDepreciacao: 20m
            );

            // Assert
            asset.Should().NotBeNull();
            asset.Id.Should().NotBeEmpty();
            asset.Nome.Should().Be("Notebook Dell");
            asset.CodigoPatrimonio.Should().Be("NB-001");
            asset.Status.Should().Be(AssetStatus.Ativo);
            asset.QRCode.Should().NotBeNullOrEmpty();
            asset.IsDeleted.Should().BeFalse();
        }

        [Fact]
        public void Asset_DeveGerarQRCodeAutomaticamente()
        {
            // Arrange & Act
            var asset = new Asset(
                "Notebook",
                "NB-001",
                "TI",
                DateTime.UtcNow,
                1000m
            );

            // Assert
            asset.QRCode.Should().Contain("ASSET-NB-001");
            asset.QRCode.Should().Contain(asset.Id.ToString());
        }

        [Fact]
        public void Asset_DeveAlterarStatusCorretamente()
        {
            // Arrange
            var asset = new Asset("Notebook", "NB-001", "TI", DateTime.UtcNow, 1000m);
            var statusAnterior = asset.Status;

            // Act
            asset.ChangeStatus(AssetStatus.EmManutencao);

            // Assert
            asset.Status.Should().Be(AssetStatus.EmManutencao);
            asset.Status.Should().NotBe(statusAnterior);
            asset.UpdatedAt.Should().NotBeNull();
        }

        [Fact]
        public void Asset_DeveCalcularDepreciacaoCorretamente()
        {
            // Arrange
            var dataCompra = DateTime.UtcNow.AddYears(-2);
            var valorCompra = 10000m;
            var taxaDepreciacao = 20m; // 20% ao ano

            var asset = new Asset(
                "Notebook",
                "NB-001",
                "TI",
                dataCompra,
                valorCompra,
                taxaDepreciacao: taxaDepreciacao
            );

            // Act
            var valorAtual = asset.CalculateDepreciation();

            // Assert
            // 2 anos * 20% = 40% de depreciação
            // 10000 - (10000 * 0.40) = 6000
            valorAtual.Should().BeApproximately(6000m, 100m); // Margem de erro
        }

        [Fact]
        public void Asset_DeveFazerSoftDeleteCorretamente()
        {
            // Arrange
            var asset = new Asset("Notebook", "NB-001", "TI", DateTime.UtcNow, 1000m);

            // Act
            asset.Delete();

            // Assert
            asset.IsDeleted.Should().BeTrue();
            asset.Status.Should().Be(AssetStatus.Baixa);
            asset.UpdatedAt.Should().NotBeNull();
        }

        [Fact]
        public void Asset_DeveAtualizarDadosCorretamente()
        {
            // Arrange
            var asset = new Asset("Notebook", "NB-001", "TI", DateTime.UtcNow, 1000m);

            // Act
            asset.Update(
                nome: "Notebook Dell XPS",
                categoria: "Informática",
                numeroSerie: "SN999",
                taxaDepreciacao: 15m,
                observacoes: "Atualizado"
            );

            // Assert
            asset.Nome.Should().Be("Notebook Dell XPS");
            asset.Categoria.Should().Be("Informática");
            asset.NumeroSerie.Should().Be("SN999");
            asset.TaxaDepreciacao.Should().Be(15m);
            asset.Observacoes.Should().Be("Atualizado");
            asset.UpdatedAt.Should().NotBeNull();
        }

        [Fact]
        public void Asset_DeveAtribuirLocalizacaoCorretamente()
        {
            // Arrange
            var asset = new Asset("Notebook", "NB-001", "TI", DateTime.UtcNow, 1000m);
            var localizacaoId = Guid.NewGuid();

            // Act
            asset.AssignLocation(localizacaoId);

            // Assert
            asset.LocalizacaoId.Should().Be(localizacaoId);
            asset.UpdatedAt.Should().NotBeNull();
        }

        [Fact]
        public void Asset_DeveAtribuirResponsavelCorretamente()
        {
            // Arrange
            var asset = new Asset("Notebook", "NB-001", "TI", DateTime.UtcNow, 1000m);
            var responsavelId = Guid.NewGuid();

            // Act
            asset.AssignResponsible(responsavelId);

            // Assert
            asset.ResponsavelId.Should().Be(responsavelId);
            asset.UpdatedAt.Should().NotBeNull();
        }
    }
}
