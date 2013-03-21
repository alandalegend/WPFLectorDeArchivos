using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ObtenerSeries
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSubir_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == true)
            {
                new FileInfo(dlg.FileName);
                using (Stream s = dlg.OpenFile())
                {
                    TextReader reader = new StreamReader(s);
                    string st = reader.ReadToEnd();
                    string[] Arreglo = st.Split(new char[] { ' ' });
                    foreach (var CadaPalabra in Arreglo)
                    {
                        if (CadaPalabra.StartsWith(txtIniciar.Text))
                        {
                            var ContenidoActual = txtResultado.Text;
                            string[] _ContActual = ContenidoActual.Split(new char[] { '\n' });

                            if (_ContActual.Contains(CadaPalabra.Trim()))
                            {
                                txtResultado.Text += CadaPalabra.Trim() + "\n";
                            }
                        }
                    }
                }
            }
        }
    }
}
