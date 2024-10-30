namespace UnoApp4.Presentation;

public sealed partial class SecondPage : ContentDialog
{
    public SecondPage()
    {
        this.InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        this.Navigator().GoBack(this);
    }
}

