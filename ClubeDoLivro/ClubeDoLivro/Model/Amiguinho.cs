using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDoLivro.Model
{
    public class Amiguinho
    {
        public int id;
        public string nome;
        public string nomeResponsavel;
        public string telefone;
        public string endereco;

        public Amiguinho()
        {
            id = GeradorId.GerarIdAmiguinho();
        }

        public Amiguinho(int idSelecionado)
        {
            id = idSelecionado;
        }


        public string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(nome))
                resultadoValidacao += "Mome é obrigatório  \n";

            if (string.IsNullOrEmpty(nomeResponsavel))
                resultadoValidacao += "Nome do Responsável é obrigatorio  \n";

            if (string.IsNullOrEmpty(telefone))
                resultadoValidacao += "Telefone é obrigatório  \n";

            if (string.IsNullOrEmpty(endereco))
                resultadoValidacao += "Endereço é obrigatório  \n";

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "Amigo Validado";

            return resultadoValidacao;
        }


        public override bool Equals(object obj)
        {
            Amiguinho amg = (Amiguinho)obj;

            if (id == amg.id)
                return true;
            else
                return false;
        }

    }
}
