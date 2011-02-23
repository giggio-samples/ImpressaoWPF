using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ImpressaoWpf.Impressao
{
    public class Cliente : DependencyObject
    {
        public string Nome { get; set; }
        public string ImagemFrenteMarcaDAgua { get; set; }
    }
}
