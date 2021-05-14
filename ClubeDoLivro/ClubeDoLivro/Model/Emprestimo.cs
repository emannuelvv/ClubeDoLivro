using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDoLivro.Model
{
    public class Emprestimo 
    {
        public int id;
        public Amiguinho amiguinho;
        public Revista revista;
        public DateTime dataEmprestimo;
        public DateTime dataDevolucao;
        public string statusEmprestimo;

        public Emprestimo()
        {
            id = GeradorId.GerarIdEmprestimo();
        }

        public Emprestimo(int idSelecionado)
        {
            id = idSelecionado;
        }

        public string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(amiguinho.nome.ToString()))
                resultadoValidacao += "Amiguinho é obrigatório  \n";

            if (string.IsNullOrEmpty(revista.colecao.ToString()))
                resultadoValidacao += "Revista é obrigatorio  \n";

            if (string.IsNullOrEmpty(dataDevolucao.ToString()))
                resultadoValidacao += "A Data de Devolução é obrigatorio \n";

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "Emprestido Validado";

            return resultadoValidacao;
        }
        public string FormatarData()
        {
            string converte = dataDevolucao.ToString(("dd/MM/yyyy"));

            return converte;
        }
        public override bool Equals(object obj)
        {
            Emprestimo emprestimo = (Emprestimo)obj;

            if (id == emprestimo.id)
                return true;
            else
                return false;
        }

    }
}
