using Microsoft.Toolkit.Uwp.Services.Twitter;
using Microsoft.Toolkit.Uwp.UI.Controls;
//using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TagSearcherUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private TwitterUser _twitterUser;

        public MainPage()
        {
            this.InitializeComponent();

            if (IsTwitterAccountActive())
            {
                splSearch.Visibility = Visibility.Visible;
                btnLogin.Visibility = Visibility.Collapsed;
            }
            else
            {
                splSearch.Visibility = Visibility.Collapsed;
                btnLogin.Visibility = Visibility.Visible;
            }
        }


        private bool IsTwitterAccountActive()
        {
            try
            {
                var currentScreenName = TwitterService.Instance.UserScreenName;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
        
            // these keys have been disabled.
            // go to https://apps.twitter.com/ to generate your own
            TwitterService.Instance.Initialize(
                "FsrvZnvsDbfpo8JrmTtPFHjZt",
                "bWh44797GNgzGzAGqWedXzpnJa4hSLbX832MUBJshOQIbAx28v",
                "http://www.franksworld.com");

            // Login to Twitter
            if (await TwitterService.Instance.LoginAsync())
            {
                splSearch.Visibility = Visibility.Visible;
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            BladeItem bi = new BladeItem();
            bi.Title = txtSearch.Text;
            bi.Content = new SearchResults(txtSearch.Text);
            bladeView.Items.Add(bi);
        }

    }
}
