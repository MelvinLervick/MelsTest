using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace BeyondSearch
{
    /// <summary>
    /// Interaction logic for WebPost.xaml
    /// </summary>
    public partial class WebPost : Window
    {
        private bool requestCompleted = false;
        private DateTime startTime;
        private DateTime endTime;
        private List<int> spanList = new List<int>();

        private string[] searchTerms = new string[5]
        {
            "cars",
            "hotels",
            "cats",
            "dogs",
            "C#"
        };

        public WebPost()
        {
            InitializeComponent();
            TextUrl.Text = "https://blekko.com/api/infospace";
            TextCount.Text = "1";
            TextParameters.Text = "+/json+/ps=10&source=0a7eddd0&p=0&ua=Infospace%20QA&ip=63.64.65.63";
        }

        private void Menu_FileExitClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonUrl_Click(object sender, RoutedEventArgs e)
        {
            var leftBrowser = this.CheckboxBrowserLeft.IsChecked;
            if (leftBrowser != null && (bool) leftBrowser)
            {
                Browser1.Visibility = Visibility.Visible;
                Source1.Visibility = Visibility.Hidden;
                if (this.rbGet.IsChecked != null && (bool)this.rbGet.IsChecked)
                {
                    // Get
                    string request = this.TextUrl.Text + "?q=" + searchTerms[0] + this.TextParameters.Text;
                    this.Browser1.Navigate(request);
                }
                else
                {
                    // Post
                    this.Browser1.Navigate("q=" + searchTerms[0] + this.TextUrl.Text, "", Encoding.UTF8.GetBytes(this.TextParameters.Text),
                                           "Content-Type: application/x-www-form-urlencoded\r");
                }
            }
            else
            {
                Browser1.Visibility = Visibility.Hidden;
            }

            var rightBrowser = this.CheckboxBrowserRight.IsChecked;
            if (rightBrowser != null && (bool) rightBrowser)
            {
                Browser2.Visibility = Visibility.Visible;
                Source2.Visibility = Visibility.Hidden;
                if (this.rbGet.IsChecked != null && (bool)this.rbGet.IsChecked)
                {
                    // Get
                    string request = this.TextUrl.Text + "?q=" + searchTerms[0] + this.TextParameters.Text;
                    this.Browser2.Navigate(request);
                }
                else
                {
                    // Post
                    this.Browser2.Navigate("q=" + searchTerms[0] + this.TextUrl.Text, "", Encoding.UTF8.GetBytes(this.TextParameters.Text),
                                           "Content-Type: application/x-www-form-urlencoded\r");
                }
            }
            else
            {
                Browser2.Visibility = Visibility.Hidden;
            }
        }

        private void ButtonUrl1_Click(object sender, RoutedEventArgs e)
        {
            var count = Int32.Parse(this.TextCount.Text);
            int loopCounter = 0;

            while (loopCounter < count)
            {
                this.Start_Timer();
                var leftBrowser = this.CheckboxBrowserLeft.IsChecked;
                if (leftBrowser != null && (bool) leftBrowser)
                {
                    Browser1.Visibility = Visibility.Visible;
                    Source1.Visibility = Visibility.Hidden;
                    if (this.rbGet.IsChecked != null && (bool) this.rbGet.IsChecked)
                    {
                        // Get
                        string request = this.TextUrl.Text + "?q=" + searchTerms[spanList.Count%5] + this.TextParameters.Text;
                        this.Browser1.Navigate(request);
                        
                    }
                    else
                    {
                        // Post
                        this.Browser1.Navigate("q=" + searchTerms[spanList.Count % 5] + this.TextUrl.Text, "", Encoding.UTF8.GetBytes(this.TextParameters.Text),
                                               "Content-Type: application/x-www-form-urlencoded\r");
                    }
                }
                else
                {
                    Browser1.Visibility = Visibility.Hidden;
                }

                var rightBrowser = this.CheckboxBrowserRight.IsChecked;
                if (rightBrowser != null && (bool) rightBrowser)
                {
                    Browser2.Visibility = Visibility.Visible;
                    Source2.Visibility = Visibility.Hidden;
                    if (this.rbGet.IsChecked != null && (bool) this.rbGet.IsChecked)
                    {
                        // Get
                        string request = this.TextUrl.Text + "?q=" + searchTerms[spanList.Count % 5] + this.TextParameters.Text;
                        this.Browser2.Navigate(request);
                    }
                    else
                    {
                        // Post
                        this.Browser2.Navigate("q=" + searchTerms[spanList.Count % 5] + this.TextUrl.Text, "", Encoding.UTF8.GetBytes(this.TextParameters.Text),
                                               "Content-Type: application/x-www-form-urlencoded\r");
                    }
                }
                else
                {
                    Browser2.Visibility = Visibility.Hidden;
                }

                loopCounter++;
                TextMessage.Text = string.Format("Perf 1 Request {0}:{1}", loopCounter, count);

                //this.Stop_Timer();
                Dispatcher.Invoke(new Action(() => { }), DispatcherPriority.ContextIdle, null);

            }
            //TextMessage.Text = String.Format("Average = {0}", spanList.Aggregate((acc, cur) => acc + cur)/spanList.Count);
        }

        private void ButtonUrl2_Click(object sender, RoutedEventArgs e)
        {
            var leftBrowser = this.CheckboxBrowserLeft.IsChecked;
            if (leftBrowser != null && (bool)leftBrowser)
            {
                Browser1.Visibility = Visibility.Visible;
                Source1.Visibility = Visibility.Hidden;
                if (this.rbGet.IsChecked != null && (bool)this.rbGet.IsChecked)
                {
                    // Get
                    string request = this.TextUrl.Text + "?q=" + searchTerms[0] + this.TextParameters.Text;
                    this.Browser1.Navigate(request);
                }
                else
                {
                    // Post
                    this.Browser1.Navigate("q=" + searchTerms[0] + this.TextUrl.Text, "", Encoding.UTF8.GetBytes(this.TextParameters.Text),
                                           "Content-Type: application/x-www-form-urlencoded\r");
                }
            }
            else
            {
                Browser1.Visibility = Visibility.Hidden;
            }

            var rightBrowser = this.CheckboxBrowserRight.IsChecked;
            if (rightBrowser != null && (bool)rightBrowser)
            {
                Browser2.Visibility = Visibility.Visible;
                Source2.Visibility = Visibility.Hidden;
                if (this.rbGet.IsChecked != null && (bool)this.rbGet.IsChecked)
                {
                    // Get
                    string request = this.TextUrl.Text + "?q=" + searchTerms[0] + this.TextParameters.Text;
                    this.Browser2.Navigate(request);
                }
                else
                {
                    // Post
                    this.Browser2.Navigate("q=" + searchTerms[0] + this.TextUrl.Text, "", Encoding.UTF8.GetBytes(this.TextParameters.Text),
                                           "Content-Type: application/x-www-form-urlencoded\r");
                }
            }
            else
            {
                Browser2.Visibility = Visibility.Hidden;
                Source2.Visibility = Visibility.Visible;
                Source2.Text = HttpUtility.UrlDecode(TextParameters.Text);
            }
        }

        private string DisplayBrowserSource(WebBrowser browser)
        {
            System.Windows.Forms.HtmlDocument document = browser.Document as System.Windows.Forms.HtmlDocument;
            if (document != null)
            {
                return document.Body.InnerHtml;
            }

            return string.Empty;
        }

        private void Browser1_OnLoadCompleted(object sender, NavigationEventArgs e)
        {
            //this.Source2.Text = DisplayBrowserSource(Browser1);
            //Browser2.Visibility = Visibility.Hidden;
            //Source2.Visibility = Visibility.Visible;
            this.Stop_Timer();
            TextMessage.Text = String.Format("Average = {0} Loop Count = {1}", spanList.Aggregate((acc, cur) => acc + cur) / spanList.Count, spanList.Count);
            this.DisplayTimeDelays();
        }

        private void Browser2_OnLoadCompleted(object sender, NavigationEventArgs e)
        {
            //this.Source1.Text = DisplayBrowserSource(Browser2);
            //Browser1.Visibility = Visibility.Hidden;
            //Source1.Visibility = Visibility.Visible;
            this.Stop_Timer();
            TextMessage.Text = String.Format("Average = {0} Loop Count = {1}", spanList.Aggregate((acc, cur) => acc + cur) / spanList.Count, spanList.Count);
        }

        private void DisplayTimeDelays()
        {
            Browser2.Visibility = Visibility.Hidden;
            Source2.Visibility = Visibility.Visible;
            Source2.Text = String.Empty;
            int iteration = 0;

            foreach (int time in spanList)
            {
                Source2.Text += String.Format("Iteration: {0} Time[{1}]\n", ++iteration, time);
            }

        }

        private void Start_Timer()
        {
            requestCompleted = false;
            startTime = DateTime.Now;
        }

        private void Stop_Timer()
        {
            endTime = DateTime.Now;
            spanList.Add(endTime.Subtract(startTime).Milliseconds);
            requestCompleted = true;
        }
    }
}
