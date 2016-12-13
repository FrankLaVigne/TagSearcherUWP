using Microsoft.Toolkit.Uwp.Services.Twitter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
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
            this.lvSearchResults.ItemsSource = await TwitterService.Instance.SearchAsync(this.SearchTerm, 50);
        }

        private void lvSearchResults_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            var tweet = ((FrameworkElement)e.OriginalSource).DataContext;
            mfiCopy.Tag = tweet;
            mfCopyMenu.ShowAt(lvSearchResults, e.GetPosition(lvSearchResults));
        }

        private void mfiCopy_Click(object sender, RoutedEventArgs e)
        {
            var menuFlyoutItemSender = (MenuFlyoutItem)sender;
            var tweet = menuFlyoutItemSender.Tag as Tweet;

            DataPackage dataPackage = new DataPackage();
            dataPackage.RequestedOperation = DataPackageOperation.Copy;
            dataPackage.SetText($"@{tweet.User.ScreenName} {tweet.Text} ");
            Clipboard.SetContent(dataPackage);
        }
    }
}
