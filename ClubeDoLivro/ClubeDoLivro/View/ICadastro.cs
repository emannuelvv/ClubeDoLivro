using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDoLivro.View
{
        public interface ICadastro
        {
            void InserirNovoRegistro();

            void EditarRegistro();

            void ExcluirRegistro();

            void VisualizarRegistros();

            string ObterOpcao();
        }
    }

