using System.Collections.ObjectModel;

namespace UnoApp4.Presentation;

public partial class MainViewModel : ObservableObject
{
    private INavigator _navigator;
    private List<int> exitPlayers = new List<int>();

    [ObservableProperty]
    private string? name;
    [ObservableProperty]
    private int? maxPlayer=5;
    [ObservableProperty]
    private bool clickMeClickeble = false;


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

        var selector = new Random();
        int selected = selector.Next(0, exitPlayers.Count);
        var indexButton = exitPlayers[selected];

        exitPlayers.RemoveAll(x => x == indexButton);

        await ShowSimpleDialog(indexButton);
        await RedrawButtons();
        
        ClickMeClickeble = exitPlayers.Count > 0;
    }
    public async Task ShowSimpleDialog(int number)
    {
        //var result = await _navigator.ShowMessageDialogAsync<string>(this, title: "Сенин командан", content: $"{number}!!!");
        await _navigator.NavigateViewModelAsync<SecondViewModel>(this, data: new Entity($"{number}"),qualifier: Qualifiers.Dialog);
    }
    private async Task RedrawButtons()
    {
        Buttons.Clear();
        for (int i = 1; i < maxPlayer + 1; i++)
        {
            var buttonEntity = new ButtonEntityModel();
            buttonEntity.isEnabled = exitPlayers.Any(z => z == i);

            buttonEntity.Index = i;
            buttonEntity.Content = i.ToString();
            Buttons.Add(buttonEntity);
        }
    }
    private async Task GoToSecondView()
    {
        Buttons.Clear();
        exitPlayers.Clear();
        for (int i = 1; i < maxPlayer + 1; i++)
        {
            exitPlayers.Add(i);
            var buttonEntity = new ButtonEntityModel();
            //buttonEntity.IsEnabled = false;
            buttonEntity.Index = i;
            buttonEntity.Content = i.ToString();
            Buttons.Add(buttonEntity);

        }
        ClickMeClickeble = exitPlayers.Count > 0;
    }

}
