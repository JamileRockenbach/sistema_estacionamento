namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine(">> Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            veiculos.Add(placa);
            Console.WriteLine($"Veículo {placa} cadastrado com sucesso :)");
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine(">> Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            if (veiculos.Any(x => x.Equals(placa, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine(">> Digite a quantidade de horas que o veículo permaneceu estacionado:");
                string entrada = Console.ReadLine();

                if (!int.TryParse(entrada, out int horas) || horas < 0)
                {
                    Console.WriteLine("Entrada inválida de horas. Operação cancelada.");
                    return;
                }

                decimal valorTotal = precoInicial + precoPorHora * horas;
                string placaArmazenada = veiculos.First(x => x.Equals(placa, StringComparison.OrdinalIgnoreCase));
                veiculos.Remove(placaArmazenada);

                Console.WriteLine($"O veículo {placaArmazenada} foi removido e o preço total foi de: R$ {valorTotal:F2}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("| Os veículos estacionados são:");
                foreach (string v in veiculos)
                {
                    Console.WriteLine(v);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}