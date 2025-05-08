using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

List<Pessoa> hospedes = new List<Pessoa>();
Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);
Reserva reserva = new Reserva(diasReservados: 0);

//Criei um menu por minha conta.
int opcao;
bool temReserva = false;

do
{
    Console.WriteLine("\n=== Menu ===");
    Console.WriteLine("1 - Fazer uma reserva");
    Console.WriteLine("2 - Informar quantidade de dias");
    Console.WriteLine("3 - Informar hóspedes");
    Console.WriteLine("4 - Confirmar reserva");
    Console.WriteLine("5 - Encerrar programa");

    Console.Write("Escolha uma opção: ");
    //O ReadLine é um objeto do C# para String, por isso tive que transformalo em inteiro
    //para obter um menu númerico
    if (!int.TryParse(Console.ReadLine(), out opcao)) opcao = 0;

    switch (opcao)
    {
        case 1:
            reserva.CadastrarSuite(suite);
            Console.WriteLine("Suíte cadastrada.");
            temReserva = true;
            break;

        case 2:
            if (!temReserva)
            {
                Console.WriteLine("Você precisa cadastrar a suíte primeiro (opção 1).");
                break;
            }

            Console.Write("Informe a quantidade de dias: ");
            if (int.TryParse(Console.ReadLine(), out int dias))
            {
                reserva.DiasReservados = dias;
                Console.WriteLine("Dias reservados atualizados.");
            }
            else
            {
                Console.WriteLine("Entrada inválida.");
            }
            break;

        case 3:
            if (!temReserva)
            {
                Console.WriteLine("Você precisa cadastrar a suíte primeiro (opção 1).");
                break;
            }

            hospedes.Clear();
            Console.Write("Quantos hóspedes deseja cadastrar? ");
            if (int.TryParse(Console.ReadLine(), out int qtd))
            {
                for (int i = 1; i <= qtd; i++)
                {
                    Console.Write($"Nome do hóspede {i}: ");
                    string nome = Console.ReadLine();
                    hospedes.Add(new Pessoa(nome));
                }

                try
                {
                    reserva.CadastrarHospedes(hospedes);
                    Console.WriteLine("Hóspedes cadastrados com sucesso.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
            }
            break;

        case 4:
            Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
            Console.WriteLine($"Valor total: {reserva.CalcularValorDiaria()}");
            break;

        case 5:
            Console.WriteLine("Encerrando programa...");
            break;

        default:
            Console.WriteLine("Opção inválida.");
            break;
    }

} while (opcao != 5);