using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using Brasileirao;

public class Program
{
    public static void Main(string[] args)
    {
        List<Time> tabela = new List<Time>();
        

        Dictionary<string, Time> dicionario = new Dictionary<string, Time>();

        string fileName = "times.json";
       
        if (File.Exists(fileName))
        {
            string jsonString = File.ReadAllText(fileName);
            tabela = JsonSerializer.Deserialize<List<Time>>(jsonString)!;
            foreach (var time in tabela)
            {
                dicionario[time.Nome] = time;
            }
        }

        

        ExibirMensagemBemvindo();

    


        void ExibirMensagemBemvindo()
        {
            Console.Clear();
            Console.WriteLine("**************************");
            Console.WriteLine("Bem-vindo ao e-Brasileirão");
            Console.WriteLine("**************************");
            Console.WriteLine();
            Thread.Sleep(1000);
            Console.WriteLine("Digite: ");
            Console.WriteLine("1 - Adicionar um time;");
            Console.WriteLine("2 - Executar uma partida;");
            Console.WriteLine("3 - Exibir a tabela;");
            Console.WriteLine("4 - Mostrar o histórico de um time.");
            Console.WriteLine("5 - Sair");
            string opcao = Console.ReadLine()!;
            int opcaoNumero = int.Parse(opcao);
            switch (opcaoNumero)
            {
                case 1:
                    AdicionarTime();
                    break;
                case 2:
                    ExecutarPartida();
                    break;
                case 3:
                    MostrarTabela();
                    break;
                case 4:
                    MostrarHistorico();
                    break;
                case 5:
                    Sair();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Opção digitada não existe.");
                    ExibirMensagemBemvindo();
                    break;
            }
        }

        void AdicionarTime()
        {
            Console.Clear();
            Console.WriteLine("Adicionando time\n");
            Console.WriteLine("Digite o time que deseja adicionar: ");
            string nomeTime = Console.ReadLine();
            var time = new Time(nomeTime);
            AdicionarNasTabelas(time);
            Console.WriteLine("Time adicionado com sucesso.");
            Thread.Sleep(2000);
            ExibirMensagemBemvindo();
        }
        
        void ExecutarPartida()
        {
            Console.Clear();
            Console.WriteLine("Executar Partida\n");
            Console.WriteLine("Times disponíveis:");
            for (int i = 0; i < tabela.Count; i++)
            {
                Console.WriteLine($"{i}) {tabela[i]}");
            }
            Console.WriteLine("Digite o número do primeiro time:");
            int numero1 = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Digite o número segundo time:");
            int numero2 = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Digite 'v' para vitória do primeiro time, 'e' para empate e 'd' para derrota");
            char resultado = char.Parse(Console.ReadLine()!);
            Time time1 = tabela[numero1];
            Time time2 = tabela[numero2];
            time1.JogarPartida(time2, resultado);
            Console.WriteLine("Partida efetuada com sucesso");
            Thread.Sleep(2000);
            ExibirMensagemBemvindo() ;

        }

        void MostrarTabela()
        {
            Console.Clear();
            Console.WriteLine("Tabela do Brasileirão");
            int i = 1;
            var tabelaOrdenada = tabela.OrderByDescending(t => t.Pontos);
            foreach (Time t in tabelaOrdenada)
            {
                Console.WriteLine($"{i}){t.ToString()}");
                i++;
            }
            Console.WriteLine("Aperte alguma tecla para voltar para o Menu");
            Console.ReadKey();
            ExibirMensagemBemvindo ();
        }

        void MostrarHistorico()
        {
            Console.Clear();
            Console.WriteLine("Histórico do times.");
            Console.WriteLine("Digite o time que deseja ver o histórico:");
            string nomeTime = Console.ReadLine()!;
            if (dicionario.ContainsKey(nomeTime))
            {
                Time time = dicionario[nomeTime];
                Console.WriteLine("\n" + time.Resumo);
            }
            else
            {
                Console.WriteLine("Time não encontrado.");
            }
            Console.WriteLine("Aperte alguma tecla para voltar para o Menu");
            Console.ReadKey();
            ExibirMensagemBemvindo();
        }

        void Sair()
        {

            string jsonFinal = JsonSerializer.Serialize(tabela, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fileName, jsonFinal);

            Console.Clear();
            Console.WriteLine("Finalizando o aplicativo");
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine("Finalizando o aplicativo.");
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine("Finalizando o aplicativo..");
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine("Finalizando o aplicativo...");
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine("Finalizando o aplicativo....");
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine("Aplicativo finalizado!");
        }

        void AdicionarNasTabelas(Time t)
        {
            dicionario.Add(t.Nome, t);
            tabela.Add(t);
        }
    }
}

