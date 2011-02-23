using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace ImpressaoWpf.Impressao
{
    class Paginador : DocumentPaginator
    {
        private Size _pageSize;

        public Paginador(Size pageSize)
        {
            PageSize = pageSize;
            _clientes = _servicoDados.ObterClientes();
            foreach (var cliente in _clientes)
            {
                cliente.ImagemFrenteMarcaDAgua = "file:///C:/Users/Alan.PACTOR/Pictures/Microsoft_windows_logo.png";
                //cliente.ImagemFrenteMarcaDAgua = "file:///C:/Users/Alan.PACTOR/Pictures/logo_life_clube.png";
            }
        }

        private ServicoDados _servicoDados = new ServicoDados();
        private IList<Cliente> _clientes;
        private int paginaAtual = 0;
        private Cliente _clienteAtual;

        public override DocumentPage GetPage(int pageNumber)
        {
            Control controleParaImprimir;
            if (paginaAtual % 2 == 0)
            {
                controleParaImprimir = new Frente();
                _clienteAtual = _clientes[paginaAtual / 2];
            }
            else
            {
                controleParaImprimir = new Verso();
            }
            paginaAtual++;
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

        public override Size PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        public override IDocumentPaginatorSource Source
        { get { return null; } }
    }
}
