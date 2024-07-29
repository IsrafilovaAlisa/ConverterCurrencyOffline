using utf.ViewModels;

namespace utf.Views
{
    public partial class MainPage : ContentPage
    {
        //public Entry AmountSum;


        public MainPage()
        {

            InitializeComponent();
            BindingContext = MainPageViewModel.Instance;

        }



    }

}
