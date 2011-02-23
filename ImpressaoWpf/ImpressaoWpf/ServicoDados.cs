using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace ImpressaoWpf
{
    public class ServicoDados
    {
        public IList<Cliente> ObterClientes()
        {
            var img = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "imgs", "Microsoft_windows_logo.png");
            return new List<Cliente>
                       {
                           new Cliente {Nome = "Giovanni", ImagemFrenteMarcaDAgua = img},
                           new Cliente {Nome = "Felipe", ImagemFrenteMarcaDAgua = img},
                       };
        }
    }
}