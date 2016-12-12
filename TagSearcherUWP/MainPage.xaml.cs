using Microsoft.Toolkit.Uwp.Services.Twitter;
//using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
        public MainPage()
        {
            this.InitializeComponent();
        }


        private async void TwitterLogin()
        {

            TwitterService.Instance.Initialize("", "", "");

            // Login to Twitter
            if (!await TwitterService.Instance.LoginAsync())
            {
                return;
            }

            // Get current user info
            var user = await TwitterService.Instance.GetUserAsync();
            //ProfileImage.DataContext = user;

            // Get user timeline
            //ListView.ItemsSource = await TwitterService.Instance.GetUserTimeLineAsync(user.ScreenName, 50);

            // Post a tweet
            await TwitterService.Instance.TweetStatusAsync("");

            // Post a tweet with a picture
            //await TwitterService.Instance.TweetStatusAsync(TweetText.Text, stream);

            // Search for a specific tag
            //ListView.ItemsSource = await TwitterService.Instance.SearchAsync(TagText.Text, 50);

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            //BladeItem bi = new BladeItem();
            //bi.Title = "Yay";

            //bladeView.Items.Add(bi);

            PivotItem pi = new PivotItem();
            pi.Header = "Yay!";

            pi.Content = new SearchResults();

            this.pvtSearches.Items.Add(pi);



        }
    }
}
