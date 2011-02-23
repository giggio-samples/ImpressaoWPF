using System.Collections.Generic;

namespace ImpressaoWpf.Impressao
{
    public class ServicoDados
    {
        public IList<Cliente> ObterClientes()
        {
            return new List<Cliente>
                       {
                           new Cliente {Nome = "Giovanni"},
                           new Cliente {Nome = "Alan"},
                       };
        }
    }
}