using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chamado_Pira
{
    internal class Cl_utilizador
    {
        public string utilizador { get; set; }
        public string password { get; set; }
        public string permissoes { get; set; }

        public Cl_utilizador()
        {
            permissoes = "1111";
        }

    }
}
