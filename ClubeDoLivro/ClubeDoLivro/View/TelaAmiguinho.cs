using ClubeDoLivro.Controller;
using ClubeDoLivro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDoLivro.View
{
    public class TelaAmiguinho : TelaBase, ICadastro
    {
        private ControladorAmiguinho controladorAmiguinho;

        public TelaAmiguinho(ControladorAmiguinho controlador) : base("TelaAmiguinho")
        {
            controladorAmiguinho = controlador;
        }

        public void EditarRegistro()
        {
            ConfigurarTela("Editando um Registro");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o id do Amiguinho que deseja editar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuEditar = GravarCaixa(idSelecionado);

            if (conseguiuEditar)
            {
                Console.WriteLine("Amiguinho editado com sucesso !");
                Console.ReadLine();
            }
            else
            {
                Console.Write("Erro ao editar amiguinho, tente novamente");
                EditarRegistro();
            }
        }

        public void ExcluirRegistro()
        {
            ConfigurarTela("Excluindo um Registro...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número do amiguinho que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = controladorAmiguinho.ExcluirAmiguinho(idSelecionado);

            if (conseguiuExcluir)
            {
                Console.WriteLine("Amiguinho excluido com sucesso");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Erro ao excluir amiguinho, tente novamente");
                Console.ReadLine();
                ExcluirRegistro();
            }
        }

        public void InserirNovoRegistro()
        {
            ConfigurarTela("Inserindo novo Registro");

            bool consegueGravar = GravarCaixa(0);

            if (consegueGravar)
            {
                Console.WriteLine("Amiguinho registrado com sucesso");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Erro ao inserir amiguinho");
                Console.ReadLine();
                InserirNovoRegistro();
            }
        }

        public void VisualizarRegistros()
        {
            ConfigurarTela("Visualizando amiguinhos...");

            string configuracaColunasTabela = "{0,-10} | {1,-55} | {2,-35}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Amiguinho[] amiguinhos = controladorAmiguinho.SelecionarTodosOsAmiguinhos();

            if (amiguinhos.Length == 0)
            {
                Console.WriteLine("Nehum amiguinho cadastrado");
                Console.ReadLine();
                return;
            }

            for (int i = 0; i < amiguinhos.Length; i++)
            {
                Console.WriteLine(configuracaColunasTabela, amiguinhos[i].id, amiguinhos[i].nome, amiguinhos[i].telefone);

            }
        }

        public string ObterOpcao()
        {

            Console.WriteLine("Digite 1 para registrar novo Amiguinho");
            Console.WriteLine("Digite 2 para visualizar amiguinhos");
            Console.WriteLine("Digite 3 para editar amiguinho");
            Console.WriteLine("Digite 4 para excluir amiguinho");

            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;

        }

        private bool GravarCaixa(int id)
        {

            string resultadoValidacao;
            bool conseguiuGravar = true;

            Console.Write("Digite o nome do amiguinho: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o nome do responsável: ");
            string nomeResponsavel = Console.ReadLine();

            Console.Write("Digite o telefone: ");
            string telefone = Console.ReadLine();

            Console.Write("Digite o endereço: ");
            string endereco = Console.ReadLine();

            resultadoValidacao = controladorAmiguinho.RegistrarAmiguinho(id, nome, nomeResponsavel, telefone, endereco);
            if (resultadoValidacao != "AMIGO_VALIDO")
            {
                Console.WriteLine(resultadoValidacao);
                Console.ReadLine();
                conseguiuGravar = false;
            }

            return conseguiuGravar;
        }

        private static void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "Id", "Amiguinho", "Telefone");

            Console.WriteLine("----------------------------------------------------------------------------");

            Console.ResetColor();
        }
    }
}

