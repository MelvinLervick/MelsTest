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
using BeyondSearch.SampleCode;

namespace BeyondSearch
{
    /// <summary>
    /// Interaction logic for TestBase.xaml
    /// </summary>
    public partial class TestBase : Window
    {
        public TestBase()
        {
            InitializeComponent();
        }

        private void Menu_FileExitClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonT1_Click(object sender, RoutedEventArgs e)
        {
            TemplateMethodExample tme = new TemplateMethodExample();
            Source1.Text = tme.GetTest1Value(TextParameter1.Text);
        }

        private void ButtonT2_Click(object sender, RoutedEventArgs e)
        {
        }

        private void ButtonT3_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
