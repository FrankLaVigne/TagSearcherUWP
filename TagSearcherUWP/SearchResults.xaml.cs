using Microsoft.Toolkit.Uwp.Services.Twitter;
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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace TagSearcherUWP
{
    public sealed partial class SearchResults : UserControl
    {
        public string SearchTerm { get; private set; }

        public SearchResults(string searchTerm)
        {
            this.InitializeComponent();
            this.SearchTerm = searchTerm;

            Search();
        }


        private async void Search()
        {

            var instance = TwitterService.Instance;

            // Get current user info
            //TwitterUser user = await TwitterService.Instance.GetUserAsync();
            //ProfileImage.DataContext = user;

            // Get user timeline
            //ListView.ItemsSource = await TwitterService.Instance.GetUserTimeLineAsync(user.ScreenName, 50);

            //// Post a tweet
            //await TwitterService.Instance.TweetStatusAsync("");

            // Post a tweet with a picture
            //await TwitterService.Instance.TweetStatusAsync(TweetText.Text, stream);

            // Search for a specific tag
            //var tweets = await TwitterService.Instance.SearchAsync(this.SearchTerm, 50);
            
            this.lvSearchResults.ItemsSource = await TwitterService.Instance.SearchAsync(this.SearchTerm, 50);


            var x = new Tweet();

        }



    }
}
