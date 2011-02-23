using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Xps.Packaging;

namespace ImpressaoWpf
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PrintClick(object sender, RoutedEventArgs e)
        {
            var printDialog = new PrintDialog();
            if (printDialog.ShowDialog() != true) return;

            var paginator = new Paginador(new ServicoDados().ObterClientes(),
                                                new Size(printDialog.PrintableAreaWidth,
                                                printDialog.PrintableAreaHeight));
            printDialog.PrintDocument(paginator, "Impressão Wpf");
        }

        private void PreviewClick(object sender, RoutedEventArgs e)
        {
            var printDialog = new PrintDialog();
            var paginator = new Paginador(new ServicoDados().ObterClientes(),
                                                new Size(printDialog.PrintableAreaWidth,
                                                printDialog.PrintableAreaHeight));
            using (var xpsDocument = new XpsDocument(Path.GetRandomFileName(), FileAccess.ReadWrite))
            {
                var writer = XpsDocument.CreateXpsDocumentWriter(xpsDocument);
                writer.Write(paginator);
                var previewWindow = new PrintPreview
                {
                    Document = xpsDocument.GetFixedDocumentSequence()
                };
                previewWindow.ShowDialog();
            }
        }
    }
}
