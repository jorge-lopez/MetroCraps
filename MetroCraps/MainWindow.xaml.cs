using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MetroCraps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Boton_Jugar_Click(object sender, RoutedEventArgs e)
        {
            int PrimerDado, SegundoDado;
            int Estado = Craps.Jugar(out PrimerDado, out SegundoDado);


            CambiarDados(PrimerDado, SegundoDado);
           
            switch (Estado)
            {
                case -1:
                    Label_Estado.Content = "Perdio";
                    Label_Punto.Content = "0";
                    break;
                case 0:
                    Label_Estado.Content = "Continua";
                    Label_Punto.Content = Craps.Punto;
                    
                    break;
                case 1:
                    Label_Estado.Content = "Gano";
                   // Label_Punto.Content = "0";
                    break;
                default:
                    break;
            }
            

            Label_Dado.Content = (PrimerDado + SegundoDado);
        }


        private void CambiarDados(int PrimerDado, int SegundoDado)
        {            
            //  Primer Dado
            string imagen = @"/MetroCraps;component/Imagenes/dado" + PrimerDado+ ".png";
            var Uri = new Uri(imagen, UriKind.Relative);
            Imagen_Dado1.Source = new BitmapImage(Uri);
            
            //Segundo Dado
            imagen = @"/MetroCraps;component/Imagenes/dado" + SegundoDado + ".png";
            Uri = new Uri(imagen, UriKind.Relative);
            Imagen_Dado2.Source = new BitmapImage(Uri);
        }
    }
}
