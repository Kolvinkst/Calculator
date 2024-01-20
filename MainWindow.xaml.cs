using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;

namespace Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
           

            foreach (UIElement el in mainRoot.Children)
            {
                if(el is Button)
                {
                    ((Button)el).Click += Buttpn_Clock;
                }
                
            }
        }

        private void Buttpn_Clock(object sender, RoutedEventArgs e)
        {
            var format = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();
            format.NumberGroupSeparator = " ";
            string str = (string)((Button)e.OriginalSource).Content;

            if (str == "C")
                input.Text = "";
            
            else if (str == "=")
            {
                string result = new DataTable().Compute(input.Text, null).ToString();
                input.Text = result;
            }

            else if (str == "√")
            {
                if (double.TryParse(input.Text, out double resultats))
                {
                    input.Text = Math.Sqrt(resultats).ToString();
                }
            }
            else
            {
                input.Text += str;
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.WindowState == System.Windows.WindowState.Maximized)
            {
               foreach (var x in this.mainRoot.Children.OfType<Button>())
                {
                    x.FontSize = 72;
                    input.FontSize = 72;
                }
            }
        }
    }
}
