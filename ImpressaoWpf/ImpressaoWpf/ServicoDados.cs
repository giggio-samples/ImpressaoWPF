using System.Collections.Generic;

namespace ImpressaoWpf
{
    public class ServicoDados
    {
        public IList<Cliente> ObterClientes()
        {
            return new List<Cliente>
                       {
                           new Cliente {Nome = "Giovanni"},
                           new Cliente {Nome = "Felipe"},
                       };
        }
    }
}