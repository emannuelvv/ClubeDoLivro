using ClubeDoLivro.Controller;
using ClubeDoLivro.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDoLivro
{
    public class TelaBase
    {
        private readonly ControladorEmprestimo controladorEmprestimo;
        private readonly ControladorRevista controladorRevista;
        private readonly ControladorCaixa controladorCaixa;
        private readonly ControladorAmiguinho controladorAmiguinho;
        private readonly TelaEmprestimo telaEmprestimo;
       
        private string nome;

        public string Nome { get { return nome; } }

        public TelaBase(string name)
        {
            nome = name;
        }

        public TelaBase(ControladorCaixa ctrlCaixa, ControladorRevista ctrlRevista, ControladorAmiguinho ctrlAmiguinho, ControladorEmprestimo ctrlEmprestimo)
        {
            controladorCaixa = ctrlCaixa;
            controladorRevista = ctrlRevista;
            controladorAmiguinho = ctrlAmiguinho; 
            controladorEmprestimo = ctrlEmprestimo;
        }

        public ICadastro  ObterOpcao()
        {
            TelaBase telaEmprestimo = null;
            ICadastro telaSelecionada = null;
            string opcao;
            do
            {
                Console.WriteLine("Digite 1 para o Cadastro de Revistas");
                Console.WriteLine("Digite 2 para o Cadastro de Caixas");
                Console.WriteLine("Digite 3 para o Cadastro de Amiguinhos");
                Console.WriteLine("Digite 4 para o Registro de Emprestimos");
                Console.WriteLine("Digite S para Sair");

                opcao = Console.ReadLine();



                if (opcao == "1")
                    telaSelecionada = new TelaRevista(controladorCaixa, controladorRevista);

                else if (opcao == "2")
                    telaSelecionada = new TelaCaixa(controladorCaixa);

                else if (opcao == "3")
                    telaSelecionada = new TelaAmiguinho(controladorAmiguinho);

                else if (opcao == "4")
                    telaSelecionada = new TelaEmprestimo(controladorEmprestimo, controladorRevista, controladorAmiguinho);

                else if (opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
                    telaSelecionada = null;

            } while (OpcaoInvalida(opcao));

            return telaSelecionada;
        }

        

        private bool OpcaoInvalida(string opcao)
        {
            if (opcao != "1" && opcao != "2" && opcao != "3" && opcao != "4" && opcao != "S" && opcao != "s")
            {
                Console.WriteLine("Opção Inválida");
                return true;
            }
            else
                return false;
        }

        protected void ConfigurarTela(string subtitulo)
        {
            Console.Clear();

            Console.WriteLine(nome);

            Console.WriteLine();

            Console.WriteLine(subtitulo);

            Console.WriteLine();
        }


    }
}
