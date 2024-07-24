using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
namespace utf.Service;

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
            new Theme("Same as system", "System"),
            new Theme("Dark", "Dark"),
            new Theme("Light", "Light")
        };
        Themes = new List<Theme>(defaultThemes);
        var hasCustom = Preferences.ContainsKey("CustomTheme");
        if (hasCustom)
        {
            Themes.Add(new Theme("Custom theme", "Custom"));
        }

        var theme = Preferences.Get("theme", "System").ToString();

        SelectedTheme = Themes.Single(x => x.Key == theme);
        WeakReferenceMessenger.Default.Register<ThemeAddedMessage>(this, (r, m) =>
        {
            //SelectedTheme = null;

            //if (m.Value == "Custom")
            //{
            //    var customTheme = Themes.SingleOrDefault(x => x.Key == "Custom");

            //    if (customTheme == null)
            //    {
            //        customTheme = new Theme("Custom theme", "Custom");

            //        Themes.Add(customTheme);
            //    }

            //    SelectedTheme = customTheme;
            //}
        });
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
    public string Name;
    public string Key;
    public Theme(string name, string key)
    {
        Name = name;
        Key = key;
    }
    




}
