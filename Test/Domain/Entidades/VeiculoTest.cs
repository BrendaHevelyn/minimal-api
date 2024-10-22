using MinimalApi.Dominio.Entidades;

namespace Test.Domain.Entidades;

[TestClass]
public class VeiculoTest
{
    [TestMethod]
    public void TestarGetSetPropriedades()
    {   
        //Arrange
        var veiculo = new Veiculo();

        //Act
        veiculo.Id = 1;
        veiculo.Nome = "Celta";
        veiculo.Marca = "Chevrolet";
        veiculo.Ano = 2012;

        //Assert
        Assert.AreEqual(1, veiculo.Id);
        Assert.AreEqual("Celta", veiculo.Nome);
        Assert.AreEqual("Chevrolet", veiculo.Marca);
        Assert.AreEqual(2012, veiculo.Ano);
    }

}