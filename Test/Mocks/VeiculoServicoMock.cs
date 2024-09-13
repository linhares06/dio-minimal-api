using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Interfaces;

public class VeiculoServicoMock : IVeiculoServico
{
    private static List<Veiculo> veiculos = new List<Veiculo>()
    {
        new Veiculo
        {
            Id = 1,
            Nome = "Mustang",
            Marca = "Ford",
            Ano = 2022        
        },
        new Veiculo
        {
            Id = 2,
            Nome = "Civic",
            Marca = "Honda",
            Ano = 2021
        }
    };

    public List<Veiculo> Todos(int? pagina = 1, string? nome = null, string? marca = null)
    {
        return veiculos.Where(v =>
            (string.IsNullOrEmpty(nome) || v.Nome.Contains(nome, StringComparison.OrdinalIgnoreCase)) &&
            (string.IsNullOrEmpty(marca) || v.Marca.Contains(marca, StringComparison.OrdinalIgnoreCase))
        ).ToList();
    }

    public Veiculo? BuscaPorId(int id)
    {
        return veiculos.Find(v => v.Id == id);
    }

    public void Incluir(Veiculo veiculo)
    {
        veiculo.Id = veiculos.Count + 1;
        veiculos.Add(veiculo);
    }

    public void Atualizar(Veiculo veiculo)
    {
        var veiculoExistente = veiculos.Find(v => v.Id == veiculo.Id);
        if (veiculoExistente != null)
        {
            veiculoExistente.Nome = veiculo.Nome;
            veiculoExistente.Marca = veiculo.Marca;
        }
    }

    public void Apagar(Veiculo veiculo)
    {
        veiculos.Remove(veiculo);
    }
}