using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;
using ImpressaoWpf.Impressao;

namespace ImpressaoWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PrintClick(object sender, RoutedEventArgs e)
        {
            var printDialog = new PrintDialog();
            if (printDialog.ShowDialog() != true) return;

            var paginator = new Paginador(new Size(printDialog.PrintableAreaWidth,
                                                   printDialog.PrintableAreaHeight));

            printDialog.PrintDocument(paginator, "My Random Data Table");
        }

        private void PreviewClick(object sender, RoutedEventArgs e)
        {
            var printDialog = new PrintDialog();
            var paginator = new Paginador(new Size(printDialog.PrintableAreaWidth,
                                                   printDialog.PrintableAreaHeight));

            var tempFileName = Path.GetRandomFileName();

            using (var xpsDocument = new XpsDocument(tempFileName, FileAccess.ReadWrite))
            {
                XpsDocumentWriter writer = XpsDocument.CreateXpsDocumentWriter(xpsDocument);
                writer.Write(paginator);

                var previewWindow = new PrintPreview
                {
                    Owner = this,
                    Document = xpsDocument.GetFixedDocumentSequence()
                };
                previewWindow.ShowDialog();
            }
        }
    }
}
