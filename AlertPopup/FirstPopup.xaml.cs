using CommunityToolkit.Maui.Views;

namespace utf.AlertPopup;

public partial class FirstPopup : Popup
{
	public FirstPopup()
	{
		InitializeComponent();
    }

    private void ClosePopup(object sender, EventArgs e)
    {
        Close();
    }
}