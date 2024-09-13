using System.Net;
using System.Text;
using System.Text.Json;
using MinimalApi.Dominio.Entidades;
using Test.Helpers;

[TestClass]
public class VeiculoRequestTest
{
    [ClassInitialize]
    public static void ClassInit(TestContext testContext)
    {
        Setup.ClassInit(testContext);
    }

    [ClassCleanup]
    public static void ClassCleanup()
    {
        Setup.ClassCleanup();
    }

    [TestMethod]
    public async Task TestarGetTodosVeiculos()
    {
        // Act
        var response = await Setup.client.GetAsync("/veiculos");

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        var result = await response.Content.ReadAsStringAsync();
        var veiculos = JsonSerializer.Deserialize<List<Veiculo>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        Assert.IsTrue(veiculos?.Count > 0);
        Assert.IsNotNull(veiculos.FirstOrDefault()?.Nome ?? "");
        Assert.IsNotNull(veiculos.FirstOrDefault()?.Marca ?? "");
    }

    [TestMethod]
    public async Task TestarPostIncluirVeiculo()
    {
        // Arrange
        var novoVeiculo = new Veiculo
        {
            Nome = "Carro C",
            Marca = "Marca C"
        };

        var content = new StringContent(JsonSerializer.Serialize(novoVeiculo), Encoding.UTF8, "Application/json");

        // Act
        var response = await Setup.client.PostAsync("/veiculos", content);

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        var result = await response.Content.ReadAsStringAsync();
        var veiculoIncluido = JsonSerializer.Deserialize<Veiculo>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        Assert.IsNotNull(veiculoIncluido?.Nome ?? "");
        Assert.AreEqual("Carro C", veiculoIncluido?.Nome);
        Assert.AreEqual("Marca C", veiculoIncluido?.Marca);
    }
}