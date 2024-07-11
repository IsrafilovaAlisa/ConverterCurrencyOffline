using Microsoft.Maui.Controls;
using System.Diagnostics;

namespace utf.DataBase;

public partial class FramePurchases : ContentPage
{
    private readonly InformationABTPurchases _informationABTPurchases;
	public FramePurchases()
	{
        BindingContext = InformationABTPurchases.DBInfoVM;
        _informationABTPurchases = new InformationABTPurchases();
        InitializeComponent();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
    }

    private void GetEntities()
    {
       
        
    }

}