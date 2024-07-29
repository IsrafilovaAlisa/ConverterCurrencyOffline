using utf.ViewModels;

namespace utf.Views;

public partial class LogPurchasesView : ContentPage
{
	public LogPurchasesView()
	{
        InitializeComponent();
        BindingContext = LogPurchasesViewModel.DBInfoVM;
        
    }
   

}