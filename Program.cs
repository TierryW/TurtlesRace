//Grupo
//Cicero Eduardo Silva Fernandes
//Leticia Regina Oliveira da Silva
//Tierry Willis Yun de Souza

namespace TurtleRace;

class Program
{
    static void Main(string[] args)
    {
        // Chama o método MenuPrincipal.
        // Este é o primeiro método que será executado quando o programa iniciar.
        TartarugasNinjas.MenuPrincipal();
    }

}
// Declaração da classe TartarugasNinjas.
public class TartarugasNinjas
{
    // Propriedades privadas da classe TartarugasNinjas.
    private int Posicao { get; set; }
    private int Velocidade { get; set; }
    private int TempoDescanso { get; set; }
    private EstrategiaCorrida Estrategia { get; set; }
    private string Nome { get; set; }
    private double Peso { get; set; }
    private ConsoleColor Cor { get; set; }
    private double Comprimento { get; set; }
    private char Simbolo { get; set; }
    // Objeto Random para gerar números aleatórios.
    public readonly Random random = new Random();
    // Construtor da classe TartarugasNinjas.
    public TartarugasNinjas(string nome, double peso, ConsoleColor cor, double comprimento)
    {
        Nome = nome;
        Peso = peso;
        Cor = cor;
        Comprimento = comprimento;
        Velocidade = 0;
        Posicao = 0;
        TempoDescanso = 0;
        Estrategia = EstrategiaCorrida.Aceleracao; // Define a estratégia de corrida inicial da tartaruga como Aceleracao.
        Simbolo = '>';
    }
    // Uma enumeração é um tipo de valor distinto com valores nomeados.
    public enum EstrategiaCorrida
    {
        Aceleracao,
        Desaceleracao,
        Descanso
    }
    // Esta propriedade é do tipo List<TartarugasNinjas> e é inicializada como uma nova lista de TartarugasNinjas.
    public static List<TartarugasNinjas> listTartarugas { get; set; } = new List<TartarugasNinjas>();
    // Declaração do método MenuPrincipal.
    public static void MenuPrincipal()
    {


        int menuOption; // Variável para armazenar a opção do menu escolhida pelo usuário.
                        // Loop do-while para repetir o menu até que o usuário escolha a opção 4 (Sair).
        do
        {
            Console.Clear();
            Tocar("Menuu.wav");
            // Exibe as opções do menu.
            Console.WriteLine("--BEM VINDO A CORRIDA DAS TARTARUGAS!--");
            Console.WriteLine("\n1 - Cadastrar sua Tartaruga Ninja");
            Console.WriteLine("2 - Exibir dados da Tartaruga Ninja");
            Console.WriteLine("3 - Começar a corrida");
            Console.WriteLine("4 - Sair");
            // Solicita ao usuário que escolha uma opção.
            Console.Write("\nEscolha uma das opcoes acima:");
            // Tenta converter a entrada do usuário para um número inteiro e armazena em menuOption.
            int.TryParse(Console.ReadLine(), out menuOption);
            // Switch case para executar a ação correspondente à opção escolhida.
            switch (menuOption)
            {
                case 1:
                    CadastrarTartarugaNinja();
                    break;
                case 2:
                    ExibirDados();
                    break;
                case 3:
                    ComecarCorrida();
                    break;
                case 4:
                    Console.WriteLine("\nSaindo...");
                    Thread.Sleep(1000);
                    break;
                default:
                    // Se uma opção inválida for escolhida, exibe uma mensagem de erro.
                    Console.WriteLine("Opcao Invalida !");
                    break;

            }
        } while (menuOption != 4); // O loop continua até que a opção 4 (Sair) seja escolhida.
    }
    // Declaração do método CadastrarTartarugaNinja.
    public static void CadastrarTartarugaNinja()
    {
        // A variável i é inicializada com o número atual de tartarugas na lista.
        int i = listTartarugas.Count;
        // Se já existem 5 tartarugas na lista, informa ao usuário que o limite de competidores foi excedido.
        if (i == 5)
        {
            Console.Clear();
            Console.WriteLine("\nExcedeu o limite de competidores!\n");
            Thread.Sleep(1000); // Pausa a execução do programa por 1 segundo.
        }
        // Loop while para cadastrar tartarugas até que o limite de 5 seja atingido.
        while (i < 5)
        {
            Console.Clear();
            Console.WriteLine("--CADASTRE A SUA TARTARUGA--");
            // Solicita ao usuário que informe os dados da tartaruga
            Console.WriteLine("\nInforme o nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Informe o peso: ");
            double peso = double.Parse(Console.ReadLine());
            Console.WriteLine("Informe o comprimento: ");
            double comprimento = double.Parse(Console.ReadLine());
            //Escolha da Cor
            Console.WriteLine("Escolha uma cor: ");
            Console.WriteLine("| 1 Vermelho | 2 Azul | 3 Verde | 4 Amarelo | 5 Rosa | 6 Preto");
            int indexCor;
            while (!int.TryParse(Console.ReadLine(), out indexCor) || indexCor < 1 || indexCor > 6)
            {
                Console.Write("Cor inválida! Digite um número válido: ");
            }
            ConsoleColor cor;
            switch (indexCor)
            {
                case 1:
                    cor = ConsoleColor.Red;
                    break;
                case 2:
                    cor = ConsoleColor.Blue;
                    break;
                case 3:
                    cor = ConsoleColor.Green;
                    break;
                case 4:
                    cor = ConsoleColor.Yellow;
                    break;
                case 5:
                    cor = ConsoleColor.Magenta;
                    break;
                case 6:
                    cor = ConsoleColor.Black;
                    break;
                default:
                    cor = ConsoleColor.White;
                    break;
            }

            // Cria um novo objeto TartarugasNinjas com os dados informados e adiciona à lista de tartarugas.
            TartarugasNinjas tartaruga = new TartarugasNinjas(nome, peso, cor, comprimento);
            listTartarugas.Add(tartaruga);
            Console.Clear();
            // Informa ao usuário que a tartaruga foi cadastrada com sucesso.
            Console.WriteLine("Tartaruga cadastrada com sucesso!\n");
            // Pergunta ao usuário se deseja cadastrar outra tartaruga.
            Console.WriteLine("Deseja cadastrar outra Tartaruga? \n1 - Sim\n2 - Nao");
            int op = int.Parse(Console.ReadLine());
            // Se o usuario escolher cadastrar incrementa o contador
            if (op == 1)
            {
                i++;
            }
            else
            {
                break;
            }

        }

    }

    public static void ExibirDados()
    {
        Console.Clear();
        // Exibe um cabeçalho para os dados da tartaruga.
        Console.WriteLine("--DADOS DE SUA TARTARUGA NINJA RUNNER!--");
        // Loop foreach para percorrer cada tartaruga na lista de tartarugas.
        foreach (TartarugasNinjas tartaruga in listTartarugas)
        {
            Console.WriteLine($"\nNome: {tartaruga.Nome}\nPeso: {tartaruga.Peso}\nCor: {tartaruga.Cor}\nTamanho: {tartaruga.Comprimento}\n");
        }
        Console.WriteLine("Aperte qualquer tecla para voltar ao menu.");
        Console.ReadKey();
    }

    public static void ComecarCorrida()
    {
        ResetarCorrida(); // Chama o método para resetar a corrida.
        int tamanhoPista = 100;
        // Símbolo inicial da tartaruga
        TartarugasNinjas vencedora = null; // Variável para armazenar a tartaruga vencedora.
                                           //Inicia uma array de threads criando uma para cada tartaruga
        Thread[] thread = new Thread[listTartarugas.Count];
        Tocar("Corrida.wav");
        Random random = new Random();
        // Loop for para cada turno da corrida.
        for (int i = 0; i < tamanhoPista; i++)
        {
            Console.Clear();

            Console.WriteLine("--FOI DADA A LARGADA!!--\n");
            // Loop foreach para mover cada tartaruga na corrida.
            foreach (TartarugasNinjas tartaruga in listTartarugas)
            {
                // Cria uma nova thread para mover a tartaruga atual.
                // O metodo IndexOf retrona o indice da tartaruga na lista.
                thread[listTartarugas.IndexOf(tartaruga)] = new Thread(() => Mover(tartaruga, tamanhoPista, random));
                thread[listTartarugas.IndexOf(tartaruga)].Start();
                // Se a tartaruga atual alcançou ou ultrapassou o fim da pista...
                if (tartaruga.Posicao >= tamanhoPista)
                {
                    // ...e ainda não há uma vencedora ou a tartaruga atual descansou menos que a vencedora atual...
                    if (vencedora == null || tartaruga.TempoDescanso < vencedora.TempoDescanso)
                    {
                        // ...então a tartaruga atual se torna a nova vencedora.
                        vencedora = tartaruga;
                    }
                }
            }
            foreach (TartarugasNinjas tartaruga in listTartarugas)
            {
                Desenhar(tartaruga, tamanhoPista);
            }
            Thread.Sleep(1000);
            // Se já há uma vencedora, encerra o loop da corrida.
            if (vencedora != null)
            {
                break;
            }
        }
        // Se há uma vencedora...
        if (vencedora != null)
        {
            //Irá tocar a música da vitoria
            // ...exibe a vencedora da corrida.
            Console.WriteLine("\nA vencdora da corrida é:");
            Console.WriteLine($"\nNome: {vencedora.Nome}\nPeso: {vencedora.Peso}\nCor: {vencedora.Cor}\nTamanho: {vencedora.Comprimento}\n");
            Tocar("Vitoria.wav");
        }
        Console.WriteLine("Aperte qualquer tecla para continuar.");
        Console.ReadKey();
    }

    public static void Mover(TartarugasNinjas tartaruga, int tamnhoPista, Random random)
    {
        // Escolhe uma estratégia de corrida aleatória para a tartaruga.
        EstrategiaCorrida estrategia = (EstrategiaCorrida)random.Next(0, 4);
        // Switch case para aplicar a estratégia de corrida escolhida.
        switch (estrategia)
        {
            case EstrategiaCorrida.Aceleracao:
                tartaruga.Velocidade = Math.Max(1, tartaruga.Velocidade + random.Next(1, 3));
                tartaruga.Simbolo = 'a';
                break;
            case EstrategiaCorrida.Desaceleracao:
                tartaruga.Velocidade = Math.Max(1, tartaruga.Velocidade - random.Next(1, 3));
                tartaruga.Simbolo = 'd';
                break;
            case EstrategiaCorrida.Descanso:
                // Se a estratégia de Descanso for escolhida, a tartaruga para de se mover e aumenta seu tempo de descanso.
                tartaruga.Velocidade = 0;
                tartaruga.Simbolo = 'z';
                tartaruga.TempoDescanso++;
                break;
            default:
                tartaruga.Simbolo = '>';
                break;
        }
        // Move a tartaruga de acordo com sua velocidade.
        tartaruga.Posicao += tartaruga.Velocidade;
        // Garante que a posição da tartaruga não ultrapasse o tamanho da pista.
        tartaruga.Posicao = Math.Min(tartaruga.Posicao, tamnhoPista);
    }

    public static void ResetarCorrida()
    {
        Random random = new Random();
        foreach (TartarugasNinjas tartaruga in listTartarugas)
        {
            tartaruga.Posicao = 0;
            tartaruga.TempoDescanso = 0;
            tartaruga.Velocidade = random.Next(1, 6);
            tartaruga.Estrategia = EstrategiaCorrida.Aceleracao;
        }
    }

    public static void Tocar(string FileName)
    {
        string dirAtual = Environment.CurrentDirectory;
        string dirMusic = dirAtual + @"\music\";
        try
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(dirMusic + FileName);
            player.Play();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocorreu um erro ao tentar tocar o arquivo de áudio: " + ex.Message);
        }

    }

    public static void Desenhar(TartarugasNinjas tartaruga, int tamnhoPista)
    {
        Console.ForegroundColor = tartaruga.Cor;
        // Exibe a posição atual da tartaruga na pista de corrida.
        Console.WriteLine("|" + new string('-', tartaruga.Posicao) + tartaruga.Simbolo + new string(' ', tamnhoPista - tartaruga.Posicao) + "| " + tartaruga.Posicao + "m" + " (" + tartaruga.Nome + ")");
        Console.ResetColor();
    }
}

