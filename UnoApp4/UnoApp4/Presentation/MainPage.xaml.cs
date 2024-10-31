using Uno.Toolkit.UI;

namespace UnoApp4.Presentation;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.InitializeComponent();
        //SyncSelection(tabBar.SelectedItem as TabBarItem);
        //tabBar.SelectionChanged += OnSelectionChanged;
    }
    //private void OnSelectionChanged(TabBar sender, TabBarSelectionChangedEventArgs args)
    //{
    //    SyncSelection(args.NewItem as TabBarItem);
    //}

    //private void SyncSelection(TabBarItem? tabBarItem)
    //{
    //    if (tabBarItem is TabBarItem item)
    //    {
    //        foreach (var page in pageContainer.Children)
    //        {
    //            if (page is Grid pageGrid)
    //            {
    //                pageGrid.Visibility = pageGrid.Name == (string)item.Tag ? Visibility.Visible : Visibility.Collapsed;
    //            }
    //        }
    //    }
    //}
}
