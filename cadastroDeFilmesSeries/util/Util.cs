using cadastroDeFilmesSeries.main;
using cadastroDeFilmesSeries.modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadastroDeFilmesSeries.util
{
    internal class Util
    {
        private Dictionary<string, Titulo> titulos = new Dictionary<string, Titulo>();
        private Dictionary<string, Filme> filmes = new Dictionary<string, Filme>();
        private Dictionary<string, Serie> series = new Dictionary<string, Serie>();

        public void Menu()
        {

            Console.WriteLine("Cadastro de filmes e séries".ToUpper());

            Console.WriteLine("\nDigite a opção que deseja: ");
            Console.WriteLine("\nDigite 1 para registrar um Filme");
            Console.WriteLine("Digite 2 para registrar uma Série");
            Console.WriteLine("Digite 3 para registrar uma Temporada");
            Console.WriteLine("Digite 4 para registrar um Episódio");
            Console.WriteLine("Digite 5 para buscar um Título");
            Console.WriteLine("Digite 6 para sair");

            Console.WriteLine();

            Console.Write("Digite a opção: ");
            int opcao = int.Parse(Console.ReadLine()!);

            while (opcao < 1 || opcao > 6)
            {
                Console.Write("Digite uma opção válida: ");
                opcao = int.Parse(Console.ReadLine()!);
            }

            switch(opcao)
            {
                case 1: CadastrarFilme(); 
                    break;
                case 2: CadastrarSerie();
                    break;
                case 3: CadastrarTemporada();
                    break;
                case 4: CadastrarEpisodio();
                    break;
                case 5: BuscarTitulo();
                    break;
                default: Sair();
                    break;
            }

        }

        public void CadastrarFilme()
        {

            Console.Clear();

            Console.Write("\nDigite o nome do Filme que deseja cadastrar: ");
            string nomeFilme = Console.ReadLine()!.ToLower();

            if (filmes.ContainsKey(nomeFilme))
            {
                Console.WriteLine($"\nO filme {nomeFilme} já está no catálago");
                LimparConsole();
                this.Menu();
            }


            Console.Write($"\nDigite uma descrição para o filme {nomeFilme.ToUpper()}: ");
            string descricaoFilme = Console.ReadLine()!;

            Console.Write($"\nDigite o ano de lançamento: ");
            int anoDeLancamento = int.Parse(Console.ReadLine()!);

            Console.Write($"\nDigite a duração em minutos: ");
            int duracaoEmMinutos = int.Parse(Console.ReadLine()!);

            Console.Write($"\nDigite o nome do diretor: ");
            string nomeDiretor = Console.ReadLine()!;

            Filme filme = new Filme(nomeFilme, descricaoFilme, anoDeLancamento, duracaoEmMinutos, nomeDiretor);

            filmes.Add(nomeFilme, filme);
            titulos.Add(nomeFilme, filme);

            Console.WriteLine("\nFilme adicionado !");

            Console.WriteLine($"\nO Filme {nomeFilme.ToUpper()} foi adicionada no catálago !");

            LimparConsole();

            this.Menu();

        }

        public void CadastrarSerie()
        {

            Console.Clear();

            Console.Write("\nDigite o nome do Série que deseja cadastrar: ");
            string nomeSerie = Console.ReadLine()!.ToLower();


            if (series.ContainsKey(nomeSerie))
            {
                Console.WriteLine($"\nA série {nomeSerie.ToUpper()} já está no catálago");
                Console.WriteLine("Voltando para o menu principal");
                LimparConsole();
                this.Menu();
            }

            Console.Write($"\nDigite uma descrição para a série {nomeSerie.ToUpper()}: ");
            string descricaoSerie = Console.ReadLine()!;

            Console.Write($"\nDigite o ano de lançamento: ");
            int anoDeLancamento = int.Parse(Console.ReadLine()!);

            Console.Write($"\nA série está ativa ?");
            Console.WriteLine("\nDigite 1 - Sim");
            Console.WriteLine("Digite 2 - Não");
            bool serieAtiva;

            Console.WriteLine();

            Console.Write("Opção: ");
            int opcaoAtiva = int.Parse(Console.ReadLine()!);
            opcaoAtiva = ValidaOpcao(opcaoAtiva);

            if (opcaoAtiva == 1)
            {
                serieAtiva = true;
            }
            else
            {
                serieAtiva = false;
            }

            Serie serie = new Serie(nomeSerie, descricaoSerie, anoDeLancamento, serieAtiva);
            series.Add(nomeSerie, serie);
            titulos.Add(nomeSerie, serie);

            Console.WriteLine("\nSérie adicionada !");

            Console.WriteLine($"\nA Série {nomeSerie.ToUpper()} foi adicionada no catálago !");

            LimparConsole();

            this.Menu();

        }


        public void CadastrarTemporada()
        {
            Console.Clear();

            Console.Write("Digite o nome da Série que deseja cadastrar a temporada: ");
            string nomeSerie = Console.ReadLine()!.ToLower();

            Console.WriteLine();

            if(series.ContainsKey(nomeSerie))
            {
                var serie = series[nomeSerie];

                Console.Write("Digite o número da temporada: ");
                int numeroTemporada = int.Parse(Console.ReadLine()!);

                if (serie.temporadaCadastrada(numeroTemporada) != null)
                {
                    Console.WriteLine("Temporada já está cadastrada");
                    Console.WriteLine("Voltando para o menu principal");
                    LimparConsole();
                    this.Menu();
                }
                else
                {
                    Temporada temporada = new Temporada(numeroTemporada, serie);

                    serie.AdicionarTemporada(temporada);

                    Console.WriteLine("Temporada Cadastrada com sucesso !");

                }

            }
            else
            {
                Console.WriteLine("Série não Cadastrada");

                Console.WriteLine($"Deseja cadastrar a série {nomeSerie} ?");
                Console.WriteLine("Digite 1 - Sim");
                Console.WriteLine("Digite 2 - Não");
                int opcao = ValidaOpcao(int.Parse(Console.ReadLine()!));

                if(opcao == 1)
                {
                    CadastrarSerie();
                }
                
            }

            LimparConsole();
            this.Menu();

        }


        public void CadastrarEpisodio()
        {
            Console.Clear();

            Console.Write("Digite o nome da Série que deseja cadastrar o episódio: ");
            string nomeSerie = Console.ReadLine()!.ToLower();

            Console.WriteLine();

            if (series.ContainsKey(nomeSerie))
            {
                var serie = series[nomeSerie];

                Console.Write("Digite o número da temporada que deseja cadastrar o episódio: ");
                int numeroTemporada = int.Parse(Console.ReadLine()!);

                var temporada = serie.temporadaCadastrada(numeroTemporada);

                if (temporada != null)
                {

                    Console.WriteLine();

                    Console.Write("Digite o nome do episódio: ");
                    string nomeEpisodio = Console.ReadLine()!.ToLower();

                    if(temporada.episodioCadastrado(nomeEpisodio) != null)
                    {
                        Console.WriteLine("Episódio já cadastrado");
                        Console.WriteLine("Voltando para o menu");
                        LimparConsole();
                        this.Menu();
                    }
                    else
                    {
                        Console.Write($"\nDigite uma descrição para o episódio {nomeEpisodio.ToUpper()}: ");
                        string descricaoEpisodio = Console.ReadLine()!;

                        Console.Write("\nDigite a duração em minutos: ");
                        int duracaoEmMinutosEpisodio = int.Parse(Console.ReadLine()!);

                        Episodio episodio = new Episodio(nomeEpisodio, descricaoEpisodio, duracaoEmMinutosEpisodio, temporada);

                        temporada.AdicionarEpisodio(episodio);

                        Console.WriteLine("Episódio cadastrado com sucesso!");
                    }

                }
                else
                {
                    Console.WriteLine("Temporada não cadastrada");
                    LimparConsole();
                    this.Menu();
                }

            }
            else
            {
                Console.WriteLine("Série não Cadastrada");

                Console.WriteLine($"Deseja cadastrar a série {nomeSerie} ?");
                Console.WriteLine("Digite 1 - Sim");
                Console.WriteLine("Digite 2 - Não");
                int opcao = ValidaOpcao(int.Parse(Console.ReadLine()!));

                if (opcao == 1)
                {
                    CadastrarSerie();
                }

            }

            LimparConsole();
            this.Menu();

        }

        public void BuscarTitulo()
        {
            Console.Clear();

            Console.Write("Digite o nome do Título que deseja buscar: ");
            string nomeTitulo = Console.ReadLine()!.ToLower();

            Console.WriteLine();

            if (titulos.ContainsKey(nomeTitulo))
            {
                var titulo = titulos[nomeTitulo];

                Console.WriteLine(titulo.ToString());

                if (titulo is Serie)
                {
                    Serie serie = (Serie) titulo;
                    serie.ExibirTemporadas();
                }

            }
            else
            {
                Console.WriteLine("Título não cadastrado");
            }

            Console.WriteLine();
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            this.Menu();

        }

        public void Sair()
        {
            Console.Clear();
            Console.WriteLine("Programa encerrado");
        }


        public static void LimparConsole()
        {
            Thread.Sleep(4000);
            Console.Clear();
        }

        public static int ValidaOpcao(int opcao)
        {

            while(opcao != 1 && opcao != 2) 
            {
                Console.WriteLine("Opção Inválida !");
                Console.Write("Digite Novamente: ");
                opcao = int.Parse(Console.ReadLine()!);
            }

            return opcao;

        }

    }
}
