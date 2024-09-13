using MinimalApi.Dominio.Entidades;

[TestClass]
public class VeiculoTest
{
    [TestMethod]
    public void TestarGetSetPropriedades()
    {
        // Arrange
        var veiculo = new Veiculo();

        // Act
        veiculo.Id = 1;
        veiculo.Nome = "Mustang";
        veiculo.Marca = "Ford";
        veiculo.Ano = 2022;

        // Assert
        Assert.AreEqual(1, veiculo.Id);
        Assert.AreEqual("Mustang", veiculo.Nome);
        Assert.AreEqual("Ford", veiculo.Marca);
        Assert.AreEqual(2022, veiculo.Ano);
    }
}