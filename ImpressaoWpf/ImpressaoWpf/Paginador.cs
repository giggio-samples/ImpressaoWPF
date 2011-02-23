using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace ImpressaoWpf
{
    class Paginador : DocumentPaginator
    {
        public Paginador(IList<Cliente> clientes, Size pageSize)
        {
            PageSize = pageSize;
            _clientes = clientes;
        }

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
            controleParaImprimir.DataContext = _clienteAtual;
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
