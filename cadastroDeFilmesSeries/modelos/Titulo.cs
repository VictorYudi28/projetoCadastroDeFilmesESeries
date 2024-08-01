using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadastroDeFilmesSeries.modelos
{

    internal abstract class Titulo
    {

        public Titulo(string nome, string descricao, int anoDeLancamento) 
        { 
            this.Nome = nome.ToLower();
            this.Descricao = descricao;
            this.AnoDeLancamento = anoDeLancamento;
        }

        protected string Nome {  get; set; }
        protected string Descricao { get; set; }
        protected int AnoDeLancamento { get; set; }

    }

}
