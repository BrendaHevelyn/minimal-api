using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Servicos;
using MinimalApi.Infraestrutura.Db;

namespace Test.Domain.Servicos;

[TestClass]
public class VeiculoServicoTest
{    
   
    private DbContexto CriarContextoDeTeste()
    {
        var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", ".."));
        
        var builder = new ConfigurationBuilder()
            .SetBasePath(path ?? Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

        var configuration = builder.Build();

        return new DbContexto(configuration);
    }
    

    [TestMethod]
    public void TestandoSalvarVeiculo()
    {   
        //Arrange
        var context = CriarContextoDeTeste();

        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Veiculos");

        var veiculo = new Veiculo();
        //veiculo.Id = 1;
        veiculo.Nome = "Celta";
        veiculo.Marca = "Chevrolet";
        veiculo.Ano = 2012;
        var veiculoServico = new VeiculoServico(context);

        //Act
        veiculoServico.Incluir(veiculo);

        //Assert
        Assert.AreEqual(1, veiculoServico.Todos(1).Count());       
        
    }

    public void TestandoBuscaPorId()
    {
        // Arrange
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Veiculos");

         var veiculo = new Veiculo();
        //veiculo.Id = 1;
        veiculo.Nome = "Celta";
        veiculo.Marca = "Chevrolet";
        veiculo.Ano = 2012;

        var veiculoServico = new VeiculoServico(context);

        // Act
        veiculoServico.Incluir(veiculo);
        var veiculoDoBanco = veiculoServico.BuscaPorId(veiculo.Id);

        // Assert
        Assert.AreEqual(1, veiculoDoBanco?.Id);
    }

    public void TestandoApagar()
    {
        // Arrange
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Veiculos");

        var veiculo = new Veiculo();
        //veiculo.Id = 1;
        veiculo.Nome = "Celta";
        veiculo.Marca = "Chevrolet";
        veiculo.Ano = 2012;

        var veiculoServico = new VeiculoServico(context);

        // Act
        veiculoServico.Incluir(veiculo);
        veiculoServico.Apagar(veiculo);
        var veiculoDoBanco = veiculoServico.BuscaPorId(veiculo.Id);

        // Assert
        Assert.IsNull(veiculoDoBanco);
    }

    public void TestandoAtualizar()
    {
        // Arrange
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Veiculos");

        var veiculo = new Veiculo();
        //veiculo.Id = 1;
        veiculo.Nome = "Celta";
        veiculo.Marca = "Chevrolet";
        veiculo.Ano = 2012;

        var veiculoServico = new VeiculoServico(context);

        // Act
        veiculoServico.Incluir(veiculo);
        var veiculoDoBanco = veiculoServico.BuscaPorId(veiculo.Id);

        Assert.IsNotNull(veiculoDoBanco);

        veiculo.Nome = "Palio";
        veiculo.Marca = "Fiat";
        veiculo.Ano = 2014;

        veiculoServico.Atualizar(veiculoDoBanco);
        var veiculoAtualizado = veiculoServico.BuscaPorId(veiculo.Id);


        // Assert       
        Assert.AreEqual("Palio", veiculoAtualizado?.Nome);
        Assert.AreEqual("Fiat", veiculoAtualizado?.Marca);
        Assert.AreEqual(2014, veiculoAtualizado?.Ano);
    }

}