using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDoLivro
{
    public class GeradorId
    {

        private static int numeroCaixa = 0;
        private static int idRevista = 0;
        private static int idAmiguinho = 0;
        private static int idEmprestimo = 0;
        public static int GerarNumeroCaixa()
        {
            return numeroCaixa++;
        }

        public static int GerarIdRevista()
        {
            return idRevista++;
        }

        public static int GerarIdAmiguinho()
        {
            return idAmiguinho++;
        }

        public static int GerarIdEmprestimo()
        {
            return idEmprestimo++;
        }

    }
}
