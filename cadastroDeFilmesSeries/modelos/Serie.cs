using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadastroDeFilmesSeries.modelos
{
    internal class Serie : Titulo
    {

        public Serie(string nome, string descricao, int anoDeLancamento,bool ativa)
            : base(nome, descricao, anoDeLancamento)
        {
            this.Ativa = ativa;
            this.temporadas = new List<Temporada>();
        }

        private bool Ativa {  get; set; }
        private List<Temporada> temporadas;

        public string AtivaResp 
        {
            get
            {
                if (Ativa)
                {
                    return "Sim";
                }
                else
                {
                    return "Não";
                }
            }
        }

        public void AdicionarTemporada(Temporada temporada)
        {
            temporadas.Add(temporada);
        }

        public override string ToString()
        {
            return $"\nNome: {Nome.ToUpper()} \nDescrição: {Descricao} \nAno de Lançamento: {AnoDeLancamento} \nAtiva: {AtivaResp}";
        }

        public Temporada temporadaCadastrada(int numeroTemporada)
        {
            foreach (var temporada in temporadas) 
            { 
                if(numeroTemporada == temporada.getNumeroDaTemporada)
                {
                    return temporada;
                }
            }

            return null;

        }

        public void ExibirTemporadas()
        {

            if(temporadas.Count == 0)
            {
                Console.WriteLine("Não contém temporadas");
            }
            else
            {
                foreach (var temporada in temporadas)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Temporada {temporada.getNumeroDaTemporada}");
                    Console.WriteLine();
                    temporada.exibirEpisodios();

                }
            }

        }

    }
}
