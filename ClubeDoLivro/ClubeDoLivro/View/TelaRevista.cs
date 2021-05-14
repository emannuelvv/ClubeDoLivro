using ClubeDoLivro.Controller;
using ClubeDoLivro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDoLivro.View
{
    public class TelaRevista : TelaBase, ICadastro
    {
        private ControladorCaixa controladorCaixa;
        private ControladorRevista controladorRevista;
        private TelaCaixa telaCaixa;
        public TelaRevista(ControladorCaixa controlador, ControladorRevista ctrlRevista) : base("TelaRevista")
        {
            controladorCaixa = controlador;
            controladorRevista = ctrlRevista;
            
        }

        public void EditarRegistro()
        {
            ConfigurarTela("Editando um Registro");

            VisualizarRegistrosCaixa();

            Console.WriteLine();

            Console.Write("Digite o número da revista que deseja editar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuEditar = GravarRevista(idSelecionado);

            if (conseguiuEditar)
            {
                Console.WriteLine("Revista editada com sucesso ");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Erro ao editar revista, tente novamente");
                Console.ReadLine();
                EditarRegistro();
            }
        }

        public void ExcluirRegistro()
        {
            ConfigurarTela("Excluindo um Registro...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número da revista que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = controladorRevista.ExcluirRevista(idSelecionado);

            if (conseguiuExcluir)
            {
                Console.WriteLine("Revista excluida com sucesso");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Erro ao excluir revista, tente novamente");
                Console.ReadLine();
                ExcluirRegistro();
            }
        }

        public void InserirNovoRegistro()
        {
            ConfigurarTela("Inserindo novo Registro");

            bool consegueGravar = GravarRevista(0);

            if (consegueGravar)
            {
                Console.WriteLine("Revista inserida com sucesso");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Erro ao inserir revista");
                Console.ReadLine();
                InserirNovoRegistro();
            }
        }

        public void VisualizarRegistros()
        {
            ConfigurarTela("Visualizando revistas...");

            string configuracaColunasTabela = "{0,-10} | {1,-10} | {2,-20} | {3,-30}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Revista[] revista = controladorRevista.SelecionarTodasAsRevistas();

            if (revista.Length == 0)
            {
                Console.WriteLine("Nehuma revista cadastrada");
                Console.ReadLine();
                return;
            }

            for (int i = 0; i < revista.Length; i++)
            {
                Console.WriteLine(configuracaColunasTabela,
                   revista[i].id, revista[i].caixa.numero, revista[i].colecao, revista[i].numeroEdicao);
            }
        }

        public void VisualizarRegistrosCaixa()
        {



            ConfigurarTela("Visualizando caixas...");

            bool consegueListar = false;
            Console.WriteLine();
            Caixa[] caixa = controladorCaixa.SelecionarTodasAsCaixas();

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0,-15} | {1,-40} | {2,-30}", "Numero", "Cor", "Etiqueta Caixa");

            Console.WriteLine("-------------------------------------------------------------------------");

            if (caixa.Length == 0)
            {
                Console.WriteLine("Nehuma caixa cadastrada");
                Console.ReadLine();
                
            }


            foreach (var e in caixa)
            {
                
                    Console.WriteLine("{0,-15} | {1,-40} | {2,-30}", e.numero, e.cor, e.etiquetaCaixa);
                
            }
            Console.WriteLine();

            Console.ResetColor();

     
        }

        public string ObterOpcao()
        {
            Console.WriteLine("Digite 1 para inserir uma nova revista");
            Console.WriteLine("Digite 2 para visualizar revistas");
            Console.WriteLine("Digite 3 para editar revista");
            Console.WriteLine("Digite 4 para excluir revista");

            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        private bool GravarRevista(int id)
        {


            string resultadoValidacao;
            bool conseguiuGravar = true;



                VisualizarRegistrosCaixa();


                Console.Write("Informe o numero da caixa em que a revista sera guarada: ");
                int numeroCaixa = Convert.ToInt32(Console.ReadLine());


                Console.Write("Informe o numero da edição da revista: ");
                int numeroEdicao = Convert.ToInt32(Console.ReadLine());

                Console.Write("Informe o ano da edição: ");
                DateTime anoEdicao = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Informe a coleção da revista: ");
                string colecao = Console.ReadLine();


                resultadoValidacao = controladorRevista.RegistrarRevista(id, numeroCaixa, numeroEdicao, anoEdicao, colecao);
                if (resultadoValidacao != "REVISTA_VALIDA")
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

            Console.WriteLine(configuracaoColunasTabela, "Id", "Numero Caixa", "Coleção", "Numero Edição");

            Console.WriteLine("--------------------------------------------------------------------------------");

            Console.ResetColor();
        }

       

    }
}
