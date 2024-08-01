using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadastroDeFilmesSeries.modelos
{
    internal class Episodio
    {

        public Episodio(string nome, string descricao,int duracaoEmMinutos,Temporada temporada) 
        { 
            this.Nome = nome.ToLower();
            this.Descricao = descricao;
            this.DuracaoEmMinutos = duracaoEmMinutos;
            this.Temporada = temporada;
        }

        private string Nome {  get; set; }

        public string getNome
        {
            get { return Nome; }
        }

        private string Descricao { get; set; }
        private int DuracaoEmMinutos { get; set; }
        private Temporada Temporada { get; }

        public override string ToString()
        {
            return $"\nNome: {Nome.ToUpper()} \nDescrição: {Descricao} " +
                $" \nDuração em minutos: {DuracaoEmMinutos}";
        }

    }

}
