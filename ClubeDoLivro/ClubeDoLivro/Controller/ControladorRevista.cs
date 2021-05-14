using ClubeDoLivro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDoLivro.Controller
{
    public class ControladorRevista : ControladorBase
    {

        private readonly ControladorCaixa controladorCaixa;

        public ControladorRevista(ControladorCaixa ctrlCaixa)
        {
            controladorCaixa = ctrlCaixa;
        }

        public string RegistrarRevista(int id, int idCaixa, int numeroEdicao, DateTime ano, string colecao)

        {
            Revista revista;

            int posicao;

            if (id == 0)
            {

                posicao = ObterPosicaoVaga();

                if (posicao != 0)
                {
                    posicao = ObterPosicaoOcupada(new Revista(id));
                    revista = (Revista)registros[posicao];
                }
                else
                {
                    revista = new Revista();
                }

            }
            else
            {
                posicao = ObterPosicaoOcupada(new Revista(id));
                revista = (Revista)registros[posicao];
            }

            revista.caixa = controladorCaixa.SelecionarCaixaPorId(idCaixa);
            revista.numeroEdicao = numeroEdicao;
            revista.ano = ano;
            revista.colecao = colecao;
         

            string resultadoValidacao = revista.Validar();
            if (resultadoValidacao == "Revista valida")
            {
                registros[posicao] = revista;
            }

            return resultadoValidacao;
        }

        public Revista SelecionarRevistaPorId(int id)
        {
            return (Revista)SelecionarRegistroPorId(new Revista(id));
        }

        public bool ExcluirRevista(int idSelecionado)
        {
            return ExcluirRegistro(new Revista(idSelecionado));
        }

        public Revista[] SelecionarTodasAsRevistas()
        {
            Revista[] revistaAux = new Revista[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), revistaAux, revistaAux.Length);

            return revistaAux;
        }


    }
}
