using utf.Service;
using utf.ViewModels;

namespace utf.Views;

public partial class SettingsView : ContentPage
{
    public SettingsView()
    {
        InitializeComponent();
        BindingContext = SettingsViewModel.Instance;
    }
}