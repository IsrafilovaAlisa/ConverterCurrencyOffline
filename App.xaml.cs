using CommunityToolkit.Mvvm.Messaging;
using System.Diagnostics;
using utf.Classes;

namespace utf
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
            WeakReferenceMessenger.Default.Register<ThemeChangedMessage>(this, (r, m) =>
            {
                if (r is App b) b.LoadTheme(m.Value);
            });

            var theme = Preferences.Get("theme", "System");

            LoadTheme(theme);
        }
        private void LoadTheme(string theme) 
        {
            if(!MainThread.IsMainThread)
            {
                MainThread.BeginInvokeOnMainThread(() => LoadTheme(theme));
                return;
            }
            if(theme == "System")
            {
                theme = Current.PlatformAppTheme.ToString();
            }
            ResourceDictionary dictionary = theme switch
            {
                "Dark" => new Resources.Themes.DarkTheme(),
                "Light" => new Resources.Themes.LightTheme(),
            };
            if(dictionary != null )
            {
                Resources.MergedDictionaries.Clear();
                Resources.MergedDictionaries.Add(dictionary);
            }
        }
         
    }
}
