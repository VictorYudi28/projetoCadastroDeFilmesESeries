using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadastroDeFilmesSeries.modelos
{
    internal class Filme : Titulo
    {

        public Filme(string nome, string descricao, int anoDeLancamento ,int duracaoEmMinutos,string diretor)
            : base(nome, descricao, anoDeLancamento)
        {
            this.DuracaoEmMinutos = duracaoEmMinutos; 
            this.Diretor = diretor;
        }

        private int DuracaoEmMinutos {  get; set; }
        private string Diretor { get; set; }

        public override string ToString()
        {
            return $"\nNome: {Nome.ToUpper()} \nDescrição: {Descricao} " +
                $"\nAno de Lançamento: {AnoDeLancamento} \nDuração em minutos: {DuracaoEmMinutos} \nDiretor: {Diretor}";
        }

    }
}
