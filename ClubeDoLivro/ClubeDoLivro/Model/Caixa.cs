using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDoLivro.Model
{
    public class Caixa
    {
        public string cor;
        public string etiquetaCaixa;
        public int numero;
               
        public Caixa()
        {
            numero = GeradorId.GerarNumeroCaixa();
        }

        public Caixa(int idSelecionado)
        {
            numero = idSelecionado;
        }

        public string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(cor))
                resultadoValidacao += "Cor é obrigatório  \n";

            if (string.IsNullOrEmpty(etiquetaCaixa))
                resultadoValidacao += "Etiqueta é obrigatorio  \n";

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "Caixa é valida";

            return resultadoValidacao;
        }


        public override bool Equals(object obj)
        {
            Caixa caixa = (Caixa)obj;

            if (numero == caixa.numero)
                return true;
            else
                return false;
        }

    }
}
