using Avaliação1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Avaliação1
{
    internal class Poligonal
    {
        private int azGraus;
        private int azMinutos;
        private int azSegundos;
        private double calculoPerimetro = 90.76;
        private string descricao;
        List<Estacao> estacoes = new List<Estacao>();

        //public static Angulo angAnterior = new(60, 30, 20);
        //public static Angulo azAnterior = new(225, 32, 48);
        //public Estacao estacaoFirst = new(1, 90.76, 'E', angAnterior, azAnterior);
        public Estacao estacaoAnt = new();


        public Poligonal()
        {
            Descricao = "FAZENDA RIO VERDE";

            Estacao estacaoFirst = new Estacao();
            estacaoFirst.numero = 1;
            estacaoFirst.Graus = 60;
            estacaoFirst.Minutos = 30;
            estacaoFirst.Segundos = 20;
            estacaoFirst.deflexao = 'E';
            estacaoFirst.distancia = 90.76;
            estacaoFirst.azimute.Graus = 255;
            estacaoFirst.azimute.Minutos = 32;
            estacaoFirst.azimute.Segundos = 48;

          //  estacoes.Add(estacaoFirst);

          //  CalcularAzimutes();



            //Angulo angAnterior = new(60, 30, 20);
            //Angulo azAnterior = new(225, 32, 48);
            //Estacao estacaoFirst = new Estacao(1, 90.76, 'E', angAnterior, azAnterior);
            estacoes.Add(estacaoFirst);
            estacaoAnt.numero = 1;
        }

        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
        public int AzGraus
        {
            get { return azGraus; }
            set { azGraus = value; }
        }

        public int AzMinutos
        {
            get { return azMinutos; }
            set { azMinutos = value; }
        }

        public int AzSegundos
        {
            get { return azSegundos; }
            set { azSegundos = value; }
        }
        //Cálculo do Azimute e printar na tela
        public void LerList()
        {
            List<Angulo> azimutes = CalcularAzimutes();
            int index = 0;

            foreach (Estacao item in estacoes)
            {
                Angulo anguloEstacao = azimutes[index];
                Console.WriteLine("".PadRight(3)
                                    + item.numero
                                    + "".PadRight(16)
                                    + item.Graus
                                    + "° "
                                    + item.Minutos
                                    + "' "
                                    + item.Segundos
                                    + "'' ".PadRight(18)
                                    + item.deflexao
                                    + " ".PadRight(20)
                                    + item.distancia
                                    + "".PadRight(26)
                                    + $"{anguloEstacao.Graus}° {anguloEstacao.Minutos}' {anguloEstacao.Segundos}''");
                index++;
            }
        }

        public double Perimetro()

        {
            foreach (Estacao estacao in estacoes)
            {
                calculoPerimetro += estacao.distancia;
            }
            return calculoPerimetro;
        }

        public double getPerimetro()
        {
            calculoPerimetro = Math.Round(calculoPerimetro, 2);

            return calculoPerimetro;
            
        }

        public void InserirEditar(int iAcao, int numEstacao = 0, Estacao estacao = null)
        {
            Console.Clear();

            switch (iAcao)
            {
                case 0:
                    Console.WriteLine("------------------------------------------------------NOVA ESTAÇÃO------------------------------------------------------");
                    Console.WriteLine("========================================================================================================================");
                    estacao = new();
                    estacao.Numero += estacaoAnt.Numero;
                    estacaoAnt.Numero++;
                    break;

                case 1:
                    Console.WriteLine("------------------------------------------------------EDITAR ESTAÇÃO----------------------------------------------------");
                    Console.WriteLine("========================================================================================================================");
                    estacao.Numero = numEstacao;
                    break;

                default:
                    break;
            }

            Console.WriteLine("Graus:");
            estacao.Graus = int.Parse(Console.ReadLine());

            Console.WriteLine("Minutos:");
            estacao.Minutos = int.Parse(Console.ReadLine());

            Console.WriteLine("Segundos");
            estacao.Segundos = int.Parse(Console.ReadLine());

            Console.WriteLine("Distância:");

            double dis = double.Parse(Console.ReadLine());

            if (iAcao == 0) // Inserção
            {
                calculoPerimetro += dis;

            }
            else //Edição
            {   
                calculoPerimetro = (calculoPerimetro - estacao.distancia) + dis;
            }

            estacao.distancia = dis;

            Console.WriteLine("Deflexão (D, E):");
            estacao.deflexao = char.Parse(Console.ReadLine());
            Console.WriteLine("========================================================================================================================");

            if (iAcao == 0)
                estacoes.Add(estacao);

            CalcularAzimutes();
        }

        public void Insercao()
        {
            // Console.Clear();
            InserirEditar(0);
        }

        //Método Exclusão - Para excluir é necessário que digite o número da estação e acionará a função
        public void Exclusao()
        {   
            Console.WriteLine("Excluir - Digite o Número da Estação: ");
            //  int numero = int.Parse(Console.ReadLine());

            if (int.TryParse(Console.ReadLine(), out int numero))
            {
                foreach (Estacao e in estacoes)
                {
                    if(e.numero == numero) 
                    {
                        calculoPerimetro -= e.distancia;
                    }                    
                }

                int estacoesRemovidas = estacoes.RemoveAll(a => a.numero == numero);

                if (estacoesRemovidas == 0)
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n--------- O NÚMERO DA ESTAÇÃO É INVÁLIDA ---------\n");
                    Console.ResetColor(); // Restaura as cores padrão do console

                }  //  Console.WriteLine("O número da estação informado não existe.");
                else
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"\n---------Estação Nº{numero} removida com sucesso---------\n");
                    Console.ResetColor(); // Restaura as cores padrão do console
                }
            }

            //  estacoes.RemoveAll(a => a.numero == numero);
            // Painel();
        }


        public void Alteracao()
        {
            Console.WriteLine("Alterar - Digite o Número da Estação: ");
            if (int.TryParse(Console.ReadLine(), out int op))
            {
                bool estacaoEncontrada = false; // Inicializa como false

                foreach (Estacao estacao in estacoes)
                {
                    if (estacao.numero == op)
                    {
                        Console.Clear();
                        // Editar Console....
                        InserirEditar(1, op, estacao);
                        estacaoEncontrada = true; // Define como true se a estação for encontrada
                        break; // Você pode sair do loop, pois já encontrou a estação
                    }
                }

                if (!estacaoEncontrada)
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n--------- O NÚMERO DA ESTAÇÃO É INVÁLIDA ---------\n");
                    Console.ResetColor(); // Restaura as cores padrão do console

                }
           }
            
        }


        public void Painel()
        {
            Console.Clear();
            string data = DateTime.Now.Date.ToString("dd/MM/yyyy");
            Console.WriteLine("Engenharia Cartográfica".PadRight(45) + "Sistema de Poligonais".PadRight(57) + "Data: " + data);
            Console.WriteLine("========================================================================================================================");
            Console.WriteLine("Poligonal: " + descricao);
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Estação".PadRight(20) + "Ângulo lido".PadRight(25) + "Deflexão".PadRight(20) + "Distância(m)".PadRight(30) + "Azimute".PadRight(20));
            Console.WriteLine("========================================================================================================================");
            LerList();
            Console.WriteLine("");
            Console.WriteLine("========================================================================================================================");
            Console.WriteLine("Perímetro: " + getPerimetro() + " metros" + "".PadRight(70) + "Pag.: 01 de 01");
            // Console.WriteLine("\n<Esc> Sair <F1> Inserir estação <F2> Alterar estação <F3> Excluir estação <PgDn> <PgUp>");
            string text = "\n<Esc> Sair <F1> Inserir <F2> Alterar <F3> Excluir <PgDn> <PgUp>";

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("<Esc> Sair ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("<F1> Inserir(+) ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("<F2> Alterar(*) ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("<F3> Excluir(-) ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("CTRL+S(/)");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("<PgDn> <PgUp>");
            Console.ResetColor();

            Console.WriteLine();
        }
        #region Atalhos 
        public void Opcoes()
        {            

            ConsoleKeyInfo keyInfo;
            bool sair = false;

            do
            {   // Verifica a tecla precionada
                keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {                                 
                    case ConsoleKey.Escape: // 'ESC' para Sair
                        Console.WriteLine("Deseja fechar o sistema? (0 - Não, 1 - Sim)");
                        char opcao = Console.ReadKey().KeyChar;

                        if (opcao == '1')
                        {
                            sair = true;
                        }                        
                        break;

                    case ConsoleKey.F1: // 'F1' para Inserir                   
                        Insercao();
                        break;
                    case ConsoleKey.Add: // '+' para Inserir
                        Insercao();
                        break;
                    case ConsoleKey.F2: // 'F2' para Editar                       
                        Alteracao();
                        break;
                    case ConsoleKey.Multiply: // '*' para Editar
                        Alteracao();
                        break;
                    case ConsoleKey.F3: // 'F3' para Excluir
                        Exclusao();                        
                        break;
                    case ConsoleKey.Subtract: // '-' para Excluir
                        Exclusao();
                        break;
                    case ConsoleKey.S:
                        if ((keyInfo.Modifiers & ConsoleModifiers.Control) != 0) // 'CTRL + S'  para Salvar
                        {
                            SalvarArquivo();
                        }
                        break;
                    case ConsoleKey.Divide:
                        SalvarArquivo(); // '/' para salvar
                        break;
                    default:
                        break;
                }

                Painel();
                } while (keyInfo.Key != ConsoleKey.Escape);
            //} while (!sair);
        }
        #endregion

            /*public void Opcoes()
            {
                ConsoleKeyInfo keyInfo;
                do
                {
                    keyInfo = Console.ReadKey(true);

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.F1: Insercao(); break;
                        case ConsoleKey.F2: Alteracao(); break;
                        case ConsoleKey.F3: Exclusao(); break;
                        case ConsoleKey.S:
                            if ((keyInfo.Modifiers & ConsoleModifiers.Control) != 0)
                            {
                                SalvarArquivo();

                            }
                            break;
                        default: break;
                    }

                    Painel();
                } while (keyInfo.Key != ConsoleKey.Escape);
            }
            */
            #region Função responsável por calcular o Azimute
        public List<Angulo> CalcularAzimutes()
        {
            List<Angulo> azimutes = new List<Angulo>();

            // Use os valores de azAnterior para inicializar os azimutes
            int azGraus = estacaoAnt.azimute.Graus;
            int azMinutos = estacaoAnt.azimute.Minutos;
            int azSegundos = estacaoAnt.azimute.Segundos;

            foreach (Estacao estacao in estacoes)
            {
                Angulo anguloEstacao = new Angulo();

                if (Char.ToUpper(estacao.deflexao) == 'D')
                {
                    anguloEstacao.Segundos = azSegundos + estacao.Segundos;
                    if (anguloEstacao.Segundos > 60)
                    {
                        anguloEstacao.Minutos = 1 + azMinutos + estacao.Minutos;
                        anguloEstacao.Segundos -= 60;
                    }
                    else
                    {
                        anguloEstacao.Minutos = azMinutos + estacao.Minutos;
                    }

                    if (anguloEstacao.Minutos > 60)
                    {
                        anguloEstacao.Graus = 1 + azGraus + estacao.Graus;
                        anguloEstacao.Minutos -= 60;
                    }
                    else
                    {
                        anguloEstacao.Graus = azGraus + estacao.Graus;
                    }

                    if (anguloEstacao.Graus > 359)
                    {
                        anguloEstacao.Graus -= 360;
                    }
                }
                else if (Char.ToUpper(estacao.deflexao) == 'E')
                {
                    anguloEstacao.Segundos = azSegundos - estacao.Segundos;
                    if (anguloEstacao.Segundos < 0)
                    {
                        anguloEstacao.Minutos = azMinutos + estacao.Minutos - 1;
                        anguloEstacao.Segundos += 60;
                    }
                    else
                    {
                        anguloEstacao.Minutos = azMinutos - estacao.Minutos;
                    }

                    if (anguloEstacao.Minutos < 0)
                    {
                        anguloEstacao.Graus = azGraus - estacao.Graus - 1;
                        anguloEstacao.Minutos += 60;
                    }
                    else
                    {
                        anguloEstacao.Graus = azGraus - estacao.Graus;
                    }

                    if (anguloEstacao.Graus < 0)
                    {
                        anguloEstacao.Graus += 360;
                    }
                }

                // Atualize os valores dos azimutes para a próxima iteração
                azGraus = anguloEstacao.Graus;
                azMinutos = anguloEstacao.Minutos;
                azSegundos = anguloEstacao.Segundos;

                // Adicione o azimute à lista de azimutes
                azimutes.Add(anguloEstacao);
                estacao.azimute = anguloEstacao;
                
            }

            return azimutes;
        }
        #endregion
        /*public List<Angulo> CalcularAzimutes()
        {
            List<Angulo> azimutes = new List<Angulo>();

            // Azimute inicial por padrão
            int azGraus = AzGraus;
            int azMinutos = AzMinutos;
            int azSegundos = AzSegundos;

            foreach (Estacao estacao in estacoes)
            {
                Angulo anguloEstacao = new Angulo();

                if (estacao.numero == 0)
                {
                    anguloEstacao.Graus = azGraus;
                    anguloEstacao.Minutos = azMinutos;
                    anguloEstacao.Segundos = azSegundos;
                }
                else
                {
                    if (Char.ToUpper(estacao.deflexao) == 'D')
                    {
                        anguloEstacao.Segundos = azSegundos + estacao.Segundos;
                        if (anguloEstacao.Segundos > 60)
                        {
                            anguloEstacao.Minutos = 1 + azMinutos + estacao.Minutos;
                            anguloEstacao.Segundos -= 60;
                        }
                        else
                        {
                            anguloEstacao.Minutos = azMinutos + estacao.Minutos;
                        }

                        if (anguloEstacao.Minutos > 60)
                        {
                            anguloEstacao.Graus = 1 + azGraus + estacao.Graus;
                            anguloEstacao.Minutos -= 60;
                        }
                        else
                        {
                            anguloEstacao.Graus = azGraus + estacao.Graus;
                        }

                        if (anguloEstacao.Graus > 359)
                        {
                            anguloEstacao.Graus -= 360;
                        }
                    }
                    else if (Char.ToUpper(estacao.deflexao) == 'E')
                    {
                        anguloEstacao.Segundos = azSegundos - estacao.Segundos;
                        if (anguloEstacao.Segundos < 0)
                        {
                            anguloEstacao.Minutos = azMinutos + estacao.Minutos - 1;
                            anguloEstacao.Segundos += 60;
                        }
                        else
                        {
                            anguloEstacao.Minutos = azMinutos - estacao.Minutos;
                        }

                        if (anguloEstacao.Minutos < 0)
                        {
                            anguloEstacao.Graus = azGraus - estacao.Graus - 1;
                            anguloEstacao.Minutos += 60;
                        }
                        else
                        {
                            anguloEstacao.Graus = azGraus - estacao.Graus;
                        }

                        if (anguloEstacao.Graus < 0)
                        {
                            anguloEstacao.Graus += 360;
                        }
                    }
                }

                // Atualize os valores dos azimutes
                azGraus = anguloEstacao.Graus;
                azMinutos = anguloEstacao.Minutos;
                azSegundos = anguloEstacao.Segundos;

                // Adicione o azimute à lista de azimutes
                azimutes.Add(anguloEstacao);
            }

            return azimutes;
        }
        */

        #region Funções responsáveis por gerar o arquivo de texto
        public void SalvarArquivo()
        {
            Console.WriteLine("\nDigite o nome do arquivo para salvar:");
            string nomeArquivo = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nomeArquivo))
            {
                nomeArquivo = "arquivo.txt";
            }

            if (!nomeArquivo.EndsWith(".txt"))
            {
                nomeArquivo += ".txt";
            }

            Console.WriteLine($"\nSalvando {nomeArquivo}...");

            //Cria o arquivo
            using (StreamWriter arquivo = new StreamWriter(nomeArquivo))
            {   // Define um Layout para o arquivo 
                string linhaSeparadora = new string('-', 70);
                arquivo.WriteLine(linhaSeparadora);
                arquivo.WriteLine("| Estação | Ângulo       | Deflexão | Distância | Azimute        |");
                arquivo.WriteLine("|---------|--------------|-----------|-----------|---------------|");

                //Percorre a lista de Estações inserindo no arquivo
                foreach (Estacao estacao in estacoes)
                {
                    string linha = $"| {estacao.numero,-7} | {FormatarAngulo(estacao.Graus, estacao.Minutos, estacao.Segundos)} | {estacao.deflexao,-8} | {estacao.distancia,-9} | {FormatarAngulo(estacao.azimute.Graus, estacao.azimute.Minutos, estacao.azimute.Segundos)} |";
                    // Grava a linha
                    arquivo.WriteLine(linha);
                }
                // Salva o arquivo 
                arquivo.WriteLine(linhaSeparadora);
            }

            Console.WriteLine($"Os dados foram salvos com sucesso no arquivo: {nomeArquivo}");
            Thread.Sleep(3000);
            Console.Clear();
        }

        private string FormatarAngulo(int graus, int minutos, int segundos)
        {   // Formata os Angulos para exibição no arquivo
            return $"{graus,3}° {minutos,2}' {segundos,2}''";
        }

        #endregion


    }

}
