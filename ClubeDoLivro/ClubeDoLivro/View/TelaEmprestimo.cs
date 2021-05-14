using ClubeDoLivro.Controller;
using ClubeDoLivro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDoLivro.View
{
    public class TelaEmprestimo : TelaBase,ICadastro
    {
        private ControladorEmprestimo controladorEmprestimo;
        private ControladorRevista controladorRevista;
        private ControladorAmiguinho controladorAmiguinho;
        private TelaCaixa telaCaixa;
        public TelaEmprestimo(ControladorEmprestimo controlador,ControladorRevista ctrlRevista, ControladorAmiguinho ctrlAmiguinho) : base("TelaEmprestimo")
        {
            controladorEmprestimo = controlador;
            controladorRevista = ctrlRevista;
            controladorAmiguinho = ctrlAmiguinho;

        }

        public void EditarRegistro()
        {
            
        }

        public void ExcluirRegistro()
        {
            ConfigurarTela("Finalizando um Registro...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número do emprestimo que deseja finalizar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = controladorEmprestimo.ExcluirEmprestimo(idSelecionado);

            if (conseguiuExcluir)
            {
                Console.WriteLine("Emprestimo finalizado com sucesso");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Erro ao finalizar emprestimo, tente novamente");
                Console.ReadLine();
                ExcluirRegistro();
            }
        }

        public void InserirNovoRegistro()
        {
            
                ConfigurarTela("Inserindo novo Registro");

                bool consegueGravar = RegistraEmprestimo(0);

                if (consegueGravar)
                {
                    Console.WriteLine("emprestimo registrado com sucesso");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Erro ao registrar emprestimo");
                    Console.ReadLine();
                    InserirNovoRegistro();
                }

            
        }

        public string ObterOpcao()
        {
            Console.WriteLine("Digite 1 para inserir novo emprestimo");
            Console.WriteLine("Digite 2 para visualizar emprestimo");
            Console.WriteLine("Digite 4 para finalizar um emprestimo");

            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void VisualizarRegistros()
        {
            ConfigurarTela("Visualizando emprestimos");

            string configuracaColunasTabela = "{0,-10} | {1,-10} | {2,-20} | {3,-30} | {4,-40}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Emprestimo[] emprestimos = controladorEmprestimo.SelecionarTodosOsEmprestimos();

            if (emprestimos.Length == 0)
            {
                Console.WriteLine("Nehum emprestimo registrado");
                Console.ReadLine();
                return;
            }

            for (int i = 0; i < emprestimos.Length; i++)
            {

                

                if(emprestimos[i].dataDevolucao > DateTime.Now )
                {
                    Console.WriteLine(configuracaColunasTabela,
                   emprestimos[i].id, emprestimos[i].amiguinho.nome, emprestimos[i].revista.colecao, emprestimos[i].dataDevolucao.ToString("dd/MM/yyyy"), emprestimos[i].statusEmprestimo);
                }
                else
                {
                    Console.WriteLine(configuracaColunasTabela,
                   emprestimos[i].id, emprestimos[i].amiguinho, emprestimos[i].revista.colecao, emprestimos[i].dataDevolucao, "DATA EXPIRADA");
                }


                
            }
        }
        public void VisualizarAmigos()
        {
            ConfigurarTela("Visualizando amiguinhos...");

            string configuracaColunasTabela = "{0,-15} | {1,-40} | {2,-30}";

            MontarCabecalhoTabelaAmigo(configuracaColunasTabela);

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


        public void VisualizarRevistas()
        {
            ConfigurarTela("Visualizando revistas...");

            string configuracaColunasTabela = "{0,-10} | {1,-10} | {2,-20} | {3,-30}";

            MontarCabecalhoTabelaRevista(configuracaColunasTabela);

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


        private static void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "ID", "AMIGUINHO", "REVISTA","DATA DEVOLUÇÃO", "STATUS DEVOLUÇÃO");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }

        private static void MontarCabecalhoTabelaRevista(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "Id", "Numero Caixa", "Coleção", "Numero Edição");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }

        private static void MontarCabecalhoTabelaAmigo(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "Id", "Amiguinho", "Telefone");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }

        private bool RegistraEmprestimo(int id)
        {


            string resultadoValidacao;
            bool conseguiuGravar = true;

            VisualizarAmigos();

            Console.Write("Informe o id do solicitante do emprestimo: ");
            int idSolicitante = Convert.ToInt32(Console.ReadLine());

            controladorEmprestimo.SelecionarRegistroPorId(idSolicitante);


            VisualizarRevistas();



            Console.Write("Informe o id da revista para o emprestimo: ");
            int idRevista = Convert.ToInt32(Console.ReadLine());

            Console.Write("Informe a data de devolução: ");
            DateTime dataDevolucao = Convert.ToDateTime(Console.ReadLine());

            DateTime dataRegistro = DateTime.Now;

            string statusEmprestimo = "DATA_VALIDA";

            resultadoValidacao = controladorEmprestimo.RegistrarRevista(id, idSolicitante, idRevista, dataRegistro, dataDevolucao, statusEmprestimo);
            if (resultadoValidacao != "EMPRESTIMO_VALIDO")
            {
                Console.WriteLine(resultadoValidacao);
                Console.ReadLine();
                conseguiuGravar = false;
            }

            return conseguiuGravar;
        }
    }
    }

