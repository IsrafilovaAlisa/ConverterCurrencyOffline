using CommunityToolkit.Maui.Views;

namespace utf.AlertPopup;

public partial class InputValueError : Popup
{
	public InputValueError()
	{
		InitializeComponent();
    }

    private void ClosePopup(object sender, EventArgs e)
    {
        Close();
    }
}