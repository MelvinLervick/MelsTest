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

namespace Search
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			txtUrl.Text = "http://www.rylinks.com";
		}

		private void Menu_FileExitClick(object sender, RoutedEventArgs e)
		{
			Application app = Application.Current;
			app.Shutdown();
		}
		// Navigates to the URL in the address box when 
		// the ENTER key is pressed while the ToolStripTextBox has focus.
		private void txtUrl_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == System.Windows.Input.Key.Enter)
			{
				Navigate(txtUrl.Text);
			}
		}

		// Navigates to the URL in the address box when 
		// the Go button is clicked.
		private void goButton_Click(object sender, RoutedEventArgs e)
		{
			Navigate(txtUrl.Text);
		}

		// Navigates to the given URL if it is valid.
		private void Navigate(String address)
		{
			if (String.IsNullOrEmpty(address)) return;
			if (address.Equals("about:blank")) return;
			if (!address.StartsWith("http://") &&
				!address.StartsWith("https://"))
			{
				address = "http://" + address;
			}
			try
			{
				SearchBrowser.Navigate(new Uri(address));
			}
			catch (System.UriFormatException)
			{
				return;
			}
		}

		// Updates the URL in TextBoxAddress upon navigation.
		private void SearchBrowser_Navigated(object sender,
			NavigationEventArgs e)
		{
			txtUrl.Text = SearchBrowser.Source.ToString();
		}
	}
}
