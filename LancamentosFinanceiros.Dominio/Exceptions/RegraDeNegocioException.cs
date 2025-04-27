using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace LancamentosFinanceiros.Dominio.Exceptions
{
    public class RegraDeNegocioException : Exception
    {
        public RegraDeNegocioException(string message) : base(message)
        {
        }
    }
}
