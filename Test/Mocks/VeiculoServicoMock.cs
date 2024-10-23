using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Interfaces;
using MinimalApi.DTOs;

namespace Test.Mocks;

public class VeiculoServicoMock : IVeiculoServico
{
    private static List<Veiculo> veiculos = new List<Veiculo>(){
        new Veiculo{
            Id = 1,
            Nome = "Celta",
            Marca = "Chevrolet",
            Ano = 2012
        }
    };

    public void Apagar(Veiculo veiculo)
    {
        var veiculoApagar = BuscaPorId(veiculo.Id);

        if (veiculo != null)
        {
            veiculos.Remove(veiculo);
        }
        
    }

    public void Atualizar(Veiculo veiculo)
    {
        var veiculoAtualizar = BuscaPorId(veiculo.Id);
        
        if (veiculoAtualizar != null)
        {
            veiculoAtualizar.Nome = veiculo.Nome;
            veiculoAtualizar.Marca = veiculo.Marca;
            veiculoAtualizar.Ano = veiculo.Ano;
        }
    }

    public Veiculo? BuscaPorId(int id)
    {
        return veiculos.Find(a => a.Id == id);    
    }

    public void Incluir(Veiculo veiculo)
    {
        veiculo.Id = veiculos.Count() + 1;
        veiculos.Add(veiculo);       
    }

    public List<Veiculo> Todos(int? pagina = 1, string? nome = null, string? marca = null)
    {
        return veiculos;
    }
}