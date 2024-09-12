using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using utf.Classes;
namespace utf.ViewModels;

public partial class SettingsViewModel: ObservableObject
{
    public static SettingsViewModel Instance = new();

    [ObservableProperty]
    public bool lightThemeColor;
    [ObservableProperty]
    public bool darkThemeColor;
    [ObservableProperty]
    public List<Theme> themes;
    [ObservableProperty]
    public Theme selectedTheme;


    public SettingsViewModel()
    {
        var defaultThemes = new List<Theme>()
        {
            new Theme("Системная", "System"),
            new Theme("Темная", "Dark"),
            new Theme("Светлая", "Light")
        };
        Themes = new List<Theme>(defaultThemes);
        var theme = Preferences.Get("theme", "System").ToString();
        SelectedTheme = Themes.Single(x => x.Key == theme);
    }
    partial void OnSelectedThemeChanged(Theme value)
    {
        if (value == null)
        {
            return;
        }

        Preferences.Set("theme", value.Key);

        WeakReferenceMessenger.Default.Send(new ThemeChangedMessage(value.Key));
    }
}
public class Theme
{
    public string Name { get; set; }
    public string Key { get; set; }
    public Theme(string name, string key)
    {
        Name = name;
        Key = key;
    }
}
