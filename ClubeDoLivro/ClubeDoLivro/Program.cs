using ClubeDoLivro.Controller;
using ClubeDoLivro.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDoLivro
{
    class Program
    {
        static void Main(string[] args)
        {

            ControladorAmiguinho ctrlAmiguinho = new ControladorAmiguinho();

            ControladorCaixa ctrlCaixa = new ControladorCaixa();

            ControladorRevista ctrlRevista = new ControladorRevista(ctrlCaixa);

            ControladorEmprestimo ctrlEmprestimo = new ControladorEmprestimo(ctrlRevista, ctrlAmiguinho);

            TelaBase telaBase = new TelaBase(ctrlCaixa, ctrlRevista, ctrlAmiguinho, ctrlEmprestimo);




            while (true)
            {
                ICadastro telaSelecionada = telaBase.ObterOpcao();

                if (telaSelecionada == null)
                    break;

                Console.Clear();

                if (telaSelecionada is TelaBase)
                    Console.WriteLine(((TelaBase)telaSelecionada).Nome); Console.WriteLine();

                string opcao = telaSelecionada.ObterOpcao();

                if (opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
                    continue;

                if (opcao == "1")
                    telaSelecionada.InserirNovoRegistro();

                else if (opcao == "2")
                {
                    telaSelecionada.VisualizarRegistros();
                    Console.ReadLine();
                }

                else if (opcao == "3")
                    telaSelecionada.EditarRegistro();

                else if (opcao == "4")
                    telaSelecionada.ExcluirRegistro();

                Console.Clear();
            }
        }
        }
    }

