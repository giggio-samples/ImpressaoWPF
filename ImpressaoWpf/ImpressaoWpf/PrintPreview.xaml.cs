using System.Windows;
using System.Windows.Documents;

namespace ImpressaoWpf
{
    public partial class PrintPreview : Window
    {
        public PrintPreview()
        {
            InitializeComponent();
        }
        public IDocumentPaginatorSource Document
        {
            get { return viewer.Document; }
            set { viewer.Document = value; }
        }
    }
}
