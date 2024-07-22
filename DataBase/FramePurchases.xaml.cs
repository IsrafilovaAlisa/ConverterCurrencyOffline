using Microsoft.Maui.Controls;
using System.Diagnostics;

namespace utf.DataBase;

public partial class FramePurchases : ContentPage
{
	public FramePurchases()
	{
        BindingContext = InformationABTPurchases.DBInfoVM;
        InitializeComponent();
    }
   

}