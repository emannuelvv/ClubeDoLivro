using ClubeDoLivro.Controller;
using ClubeDoLivro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDoLivro.View
{
    public class TelaCaixa : TelaBase, ICadastro
    {
        private ControladorCaixa controladorCaixa;
        public TelaCaixa(ControladorCaixa controlador) : base ("TelaCaixa")
        {
            controladorCaixa = controlador;
        }

        public void EditarRegistro()
        {
            ConfigurarTela("Editando um Registro");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número da caixa que deseja editar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuEditar = GravarCaixa(idSelecionado);

            if (conseguiuEditar) {
                Console.WriteLine("Caixa editada com sucesso !");
                Console.ReadLine();
            } else
            {
                Console.Write("Erro ao editar caixa, tente novamente");
                EditarRegistro();
            }
        }

        public void ExcluirRegistro()
        {
            ConfigurarTela("Excluindo um Registro...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número da caixa que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = controladorCaixa.ExcluirCaixa(idSelecionado);

            if (conseguiuExcluir)
            {
                Console.WriteLine("Caixa excluida com sucesso");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Erro ao excluir caixa, tente novamente");
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
                Console.WriteLine("Caixa inserida com sucesso");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Erro ao inserir caixa");
                Console.ReadLine();
                InserirNovoRegistro();
            }

        }

        public void VisualizarRegistros()
        {
            ConfigurarTela("Visualizando caixas...");

            string configuracaColunasTabela = "{0,-10} | {1,-40} | {2,-30}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Caixa[] caixa = controladorCaixa.SelecionarTodasAsCaixas();

            if (caixa.Length == 0)
            {
                Console.WriteLine("Nehuma caixa cadastrada");
                Console.ReadLine();
                return;
            }

            for (int i = 0; i < caixa.Length; i++)
            {
                Console.WriteLine(configuracaColunasTabela, caixa[i].numero, caixa[i].cor, caixa[i].etiquetaCaixa);

            }


        }

         public  string ObterOpcao()
        {
            Console.WriteLine("Digite 1 para inserir nova caixa");
            Console.WriteLine("Digite 2 para visualizar caixas");
            Console.WriteLine("Digite 3 para editar caixas");
            Console.WriteLine("Digite 4 para excluir caixas");

            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
            
        }

        private bool GravarCaixa(int id)
        {


            string resultadoValidacao;
            bool conseguiuGravar = true;

            Console.Write("Digite a cor da caixa: ");
            string cor = Console.ReadLine();

            Console.Write("Informe a etiqueta: ");
            string etiqueta = Console.ReadLine();


            resultadoValidacao = controladorCaixa.RegistrarCaixa(id, cor, etiqueta);
            if (resultadoValidacao != "CAIXA_VALIDA")
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

            Console.WriteLine(configuracaoColunasTabela, "Número", "Cor", "Etiqueta");

            Console.WriteLine("-------------------------------------------------------------------------------------");

            Console.ResetColor();
        }
    }
}
