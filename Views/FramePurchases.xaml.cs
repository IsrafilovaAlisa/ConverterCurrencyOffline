using utf.ViewModels;

namespace utf.Views;

public partial class FramePurchases : ContentPage
{
	public FramePurchases()
	{
        InitializeComponent();
        BindingContext = InformationABTPurchases.DBInfoVM;
        
    }
   

}