using System;
using System.Collections.Generic;

class Veiculo
{
    public string Placa { get; set; }
    public DateTime Entrada { get; set; }

    public Veiculo(string placa)
    {
        Placa = placa;
        Entrada = DateTime.Now;
    }
}

class Estacionamento
{
    private List<Veiculo> veiculos;

    public Estacionamento()
    {
        veiculos = new List<Veiculo>();
    }

    public void AdicionarVeiculo(string placa)
    {
        Veiculo novoVeiculo = new Veiculo(placa);
        veiculos.Add(novoVeiculo);
        Console.WriteLine($"Veículo com placa {placa} adicionado ao estacionamento.");
    }

    public void RemoverVeiculo(string placa)
    {
        Veiculo veiculo = veiculos.Find(v => v.Placa == placa);
        if (veiculo != null)
        {
            TimeSpan duracao = DateTime.Now - veiculo.Entrada;
            double valorCobrado = CalcularValor(duracao);
            Console.WriteLine($"Veículo com placa {placa} removido do estacionamento. Valor cobrado: R$ {valorCobrado}");
            veiculos.Remove(veiculo);
        }
        else
        {
            Console.WriteLine($"Veículo com placa {placa} não encontrado no estacionamento.");
        }
    }

    public void ListarVeiculos()
    {
        Console.WriteLine("Veículos estacionados:");
        foreach (Veiculo veiculo in veiculos)
        {
            Console.WriteLine($"Placa: {veiculo.Placa}, Entrada: {veiculo.Entrada}");
        }
    }

    private double CalcularValor(TimeSpan duracao)
    {
        // Lógica para calcular o valor a ser cobrado pela estadia do veículo
        // Exemplo simples: R$ 2,00 por hora
        return Math.Round(duracao.TotalHours * 2, 2);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Estacionamento estacionamento = new Estacionamento();

        // Exemplo de utilização
        estacionamento.AdicionarVeiculo("ABC1234");
        estacionamento.AdicionarVeiculo("XYZ5678");
        estacionamento.ListarVeiculos();
        estacionamento.RemoverVeiculo("ABC1234");
        estacionamento.ListarVeiculos();
    }
}
