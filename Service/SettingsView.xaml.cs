namespace utf.Service;

public partial class SettingsView : ContentPage
{
	public SettingsView()
	{
		InitializeComponent();
		BindingContext = SettingsViewModel.Instance;
	}
}