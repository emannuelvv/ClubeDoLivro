using ClubeDoLivro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDoLivro.Controller
{
    public class ControladorEmprestimo : ControladorBase
    {

        private readonly ControladorRevista controladorRevista;

        private readonly ControladorAmiguinho controladorAmiguinho;

        public ControladorEmprestimo(ControladorRevista ctrlRevista, ControladorAmiguinho ctrlAmiguinho)
        {
            controladorRevista = ctrlRevista;
            controladorAmiguinho = ctrlAmiguinho;
        }

        public string RegistrarRevista(int id, int idAmiguinho, int idRevista, DateTime dataEmprestimo, DateTime dataDevolucao, string statusEmprestimo)

        {
            Emprestimo emprestimo;

            int posicao;

            if (id == 0)
            {

                posicao = ObterPosicaoVaga();

                if (posicao != 0)
                {
                    posicao = ObterPosicaoOcupada(new Emprestimo(id));
                    emprestimo = (Emprestimo)registros[posicao];
                }
                else
                {
                    emprestimo = new Emprestimo();
                }

            }
            else
            {
                posicao = ObterPosicaoOcupada(new Emprestimo(id));
                emprestimo = (Emprestimo)registros[posicao];
               
            }

            emprestimo.amiguinho = controladorAmiguinho.SelecionarAmiguinhoPorId(idAmiguinho);
            emprestimo.revista = controladorRevista.SelecionarRevistaPorId(idRevista);
            emprestimo.dataEmprestimo = dataEmprestimo;
            emprestimo.dataDevolucao = dataDevolucao;
            
            emprestimo.statusEmprestimo = statusEmprestimo;
            


            string resultadoValidacao = emprestimo.Validar();
            if (resultadoValidacao == "Emprestimo valido")
            {
                registros[posicao] = emprestimo;
            }

            return resultadoValidacao;
        }

        public bool ExcluirEmprestimo(int idSelecionado)
        {
            return ExcluirRegistro(new Emprestimo(idSelecionado));
        }

        public Emprestimo[] SelecionarTodosOsEmprestimos()
        {
            Emprestimo[] emprestimos = new Emprestimo[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), emprestimos, emprestimos.Length);

            return emprestimos;
        }


    }
}
