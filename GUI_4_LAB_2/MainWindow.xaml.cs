using System;
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

namespace GUI_4_LAB_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool darkTheme;
        public MainWindow()
        {
            InitializeComponent();
            darkTheme = false;
            SetDefaultColors();
        }

		#region ColorChange
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (!darkTheme)
			{
                this.Resources["CustomGridColor"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#23272a")); 
                this.Resources["CustomLabelColor"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2c2f33")); 
                this.Resources["CustomButtonColor"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7289da")); 
                this.Resources["CustomTextColor"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffff")); 
                darkTheme = true;
            }
            else
			{
                SetDefaultColors();
                darkTheme = false;
            }
        }
        
        private void SetDefaultColors()
		{
            this.Resources["CustomGridColor"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#484b6a"));
            this.Resources["CustomLabelColor"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7a7c9f"));
            this.Resources["CustomButtonColor"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7a7c9f"));
            this.Resources["CustomTextColor"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fafafa"));
        }
		#endregion
	}
}
