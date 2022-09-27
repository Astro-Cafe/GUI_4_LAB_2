using GUI_4_LAB_2.Models;
using GUI_4_LAB_2.ViewModels;
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
using System.Windows.Shapes;

namespace GUI_4_LAB_2
{
    /// <summary>
    /// Interaction logic for SuperheroEditor.xaml
    /// </summary>
    public partial class SuperheroEditor : Window
    {
        public SuperheroEditor(Superhero superhero)
        {
            InitializeComponent();
            this.DataContext = new SuperheroEditorViewModel();
            (this.DataContext as SuperheroEditorViewModel).Setup(superhero);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in stack.Children)
            {
                if (item is TextBox t)
                {
                    t.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                }
                
            }
            this.DialogResult = true;
        }
    }
}
