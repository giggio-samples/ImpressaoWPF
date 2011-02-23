using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace ImpressaoWpf
{
    class Paginador : DocumentPaginator
    {
        public Paginador(Size pageSize)
        {
            PageSize = pageSize;
            _clientes = _servicoDados.ObterClientes();
            foreach (var cliente in _clientes)
            {
                var img = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "imgs", "Microsoft_windows_logo.png");
                cliente.ImagemFrenteMarcaDAgua = img;
            }
        }

        private readonly ServicoDados _servicoDados = new ServicoDados();
        private readonly IList<Cliente> _clientes;
        private int _paginaAtual;
        private Cliente _clienteAtual;

        public override DocumentPage GetPage(int pageNumber)
        {
            Control controleParaImprimir;
            if (_paginaAtual % 2 == 0)
            {
                controleParaImprimir = new Frente();
                _clienteAtual = _clientes[_paginaAtual / 2];
            }
            else
            {
                controleParaImprimir = new Verso();
            }
            _paginaAtual++;
            controleParaImprimir.Width = PageSize.Width;
            controleParaImprimir.Height = PageSize.Height;
            controleParaImprimir.DataContext = _clienteAtual;
            controleParaImprimir.Measure(PageSize);
            controleParaImprimir.Arrange(new Rect(new Point(0, 0), PageSize));
            controleParaImprimir.UpdateLayout();
            return new DocumentPage(controleParaImprimir);

        }

        public override bool IsPageCountValid
        { get { return true; } }

        public override int PageCount
        { get { return _clientes.Count * 2; } }

        public override Size PageSize { get; set; }

        public override IDocumentPaginatorSource Source
        { get { return null; } }
    }
}
