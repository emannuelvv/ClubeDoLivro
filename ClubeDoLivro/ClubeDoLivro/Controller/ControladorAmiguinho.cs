using ClubeDoLivro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDoLivro.Controller
{
    public class ControladorAmiguinho : ControladorBase
    {



        public string RegistrarAmiguinho(int id, string nome, string nomeResponsavel, string telefone, string endereço)

        {
            Amiguinho amiguinho;

            int posicao;

            if (id == 0)
            {

                posicao = ObterPosicaoVaga();

                if (posicao != 0)
                {
                    posicao = ObterPosicaoOcupada(new Amiguinho(id));
                    amiguinho = (Amiguinho)registros[posicao];
                }
                else
                {
                    amiguinho = new Amiguinho();
                }

            }
            else
            {
                posicao = ObterPosicaoOcupada(new Amiguinho(id));
                amiguinho = (Amiguinho)registros[posicao];
            }

            amiguinho.nome = nome;
            amiguinho.nomeResponsavel = nomeResponsavel;
            amiguinho.telefone = telefone;
            amiguinho.endereco = endereço;

            string resultadoValidacao = amiguinho.Validar();
            if (resultadoValidacao == "Amigo valido")
            {
                registros[posicao] = amiguinho;
            }

            return resultadoValidacao;
        }

        public Amiguinho SelecionarAmiguinhoPorId(int id)
        {
            return (Amiguinho)SelecionarRegistroPorId(new Amiguinho(id));
        }

        public bool ExcluirAmiguinho(int idSelecionado)
        {
            return ExcluirRegistro(new Amiguinho(idSelecionado));
        }

        public Amiguinho[] SelecionarTodosOsAmiguinhos()
        {
            Amiguinho[] amgAux = new Amiguinho[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), amgAux, amgAux.Length);

            return amgAux;
        }



    }
}
