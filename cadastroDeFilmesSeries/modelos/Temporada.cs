using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadastroDeFilmesSeries.modelos
{
    internal class Temporada
    {

        public Temporada(int numeroDaTemporada,Serie serie) 
        { 
            this.NumeroDaTemporada = numeroDaTemporada;
            this.Serie = serie;
            this.episodios = new List<Episodio>();
        }

        private int NumeroDaTemporada { get; }

        public int getNumeroDaTemporada 
        { 
            get {return NumeroDaTemporada;}
          
        }
        private Serie Serie {  get; }
        private List<Episodio> episodios;

        public void AdicionarEpisodio(Episodio episodio)
        {
            episodios.Add(episodio);
        }

        public Episodio episodioCadastrado(string nomeEpisodio)
        {

            foreach(var episodio in episodios)
            {

                if (episodio.getNome.Equals(nomeEpisodio)){
                    return episodio;
                }

            }

            return null;

        }

        public void exibirEpisodios()
        {

            if(episodios.Count == 0)
            {
                Console.WriteLine("Não contém episódios");
            }
            else
            {

                for (int i = 0; i < episodios.Count; i++)
                {
                    Console.WriteLine($"Episódio {i + 1}");
                    Console.WriteLine(episodios[i].ToString());
                    Console.WriteLine();
                }

            }

        }

    }
}
