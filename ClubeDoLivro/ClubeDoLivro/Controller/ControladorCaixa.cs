using ClubeDoLivro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDoLivro.Controller
{
    public class ControladorCaixa : ControladorBase
    {

        public string RegistrarCaixa(int numero, string cor, string etiqueta)

        {
            Caixa caixa;
            
            int posicao;

            if (numero == 0)
            {
                
                posicao = ObterPosicaoVaga();

                if(posicao != 0)
                {
                    posicao = ObterPosicaoOcupada(new Caixa(numero));
                    caixa = (Caixa)registros[posicao];
                }
                else
                {
                    caixa = new Caixa();
                }
                
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Caixa(numero));
                caixa = (Caixa)registros[posicao];
            }

            
            caixa.cor = cor ;
            caixa.etiquetaCaixa = etiqueta;

            string resultadoValidacao = caixa.Validar();
            if (resultadoValidacao == "Caixa valida")
            {
                registros[posicao] = caixa;
            }

            return  resultadoValidacao;
        }

        public Caixa SelecionarCaixaPorId(int id)
        {
            return (Caixa)SelecionarRegistroPorId(new Caixa(id));
        }

        public bool ExcluirCaixa(int idSelecionado)
        {
            return ExcluirRegistro(new Caixa(idSelecionado));
        }

        public Caixa[] SelecionarTodasAsCaixas()
        {
            Caixa[] caixaAux = new Caixa[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), caixaAux, caixaAux.Length);

            return caixaAux;
        }

    }
}
