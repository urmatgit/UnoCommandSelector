using System.Collections.ObjectModel;

namespace UnoApp4.Presentation;

public partial class MainViewModel : ObservableObject
{
    private INavigator _navigator;
    private List<int> exitPlayers=new List<int>();

    [ObservableProperty]
    private string? name;
    [ObservableProperty]
    private int? maxPlayer;
    [ObservableProperty]
    private bool clickMeClickeble=false;
    

    [ObservableProperty]
    private ObservableCollection<ButtonEntityModel> buttons = new ObservableCollection<ButtonEntityModel>();
    public MainViewModel(
        IStringLocalizer localizer,
        IOptions<AppConfig> appInfo,
        INavigator navigator)
    {
        _navigator = navigator;
        Title = "Main";
        Title += $" - {localizer["ApplicationName"]}";
        Title += $" - {appInfo?.Value?.Environment}";
        GoToSecond = new AsyncRelayCommand(GoToSecondView);
        ClickMe = new AsyncRelayCommand(ClickMeCommand);
    }
    public string? Title { get; }

    public ICommand GoToSecond { get; }
    public ICommand ClickMe { get; }
    private async Task ClickMeCommand()
    {
        if (exitPlayers.Count == 1)
        {
            buttons.SingleOrDefault(x => x.Index == exitPlayers[0]).isEnabled = false;

        }
        else
        {
            var selector = new Random();
            int selected = selector.Next(0, exitPlayers.Count);
            var indexButton = exitPlayers[selected];
            buttons.SingleOrDefault(x => x.Index == indexButton).isEnabled = false;
            exitPlayers.RemoveAll(x=>x== indexButton);
        }
        ClickMeClickeble = exitPlayers.Count > 0;
    }
    private async Task GoToSecondView()
    {
        Buttons.Clear();
        exitPlayers.Clear();
        for (int i = 1; i < maxPlayer+1; i++)
        {
            var buttonEntity = new ButtonEntityModel();
            //buttonEntity.IsEnabled = false;
            buttonEntity.Index = i;
            buttonEntity.Content = i.ToString();
            Buttons.Add(buttonEntity);
            exitPlayers.Add(i);
        }
        ClickMeClickeble = exitPlayers.Count > 0;
    }

}
