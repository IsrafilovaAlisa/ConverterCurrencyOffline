namespace utf
{
    public partial class MainPage : ContentPage
    {
        //public Entry AmountSum;
        

        public MainPage()
        {
            
            InitializeComponent();
            //AmountSum.TextChanged += newCurrency;
            BindingContext = MainPageViewModel.Instance;

        }

        
        //void newCurrency(object sender, TextChangedEventArgs e)
        //{
        //    introducedSum.Text = AmountSum.Text + " рублей  ->";
        //    if(AmountSum.Text != null)
        //    {
        //        CurrencyPicker.IsVisible = true;
        //    }
        //}

        //private async void Button_Clicked(object sender, EventArgs e)
        //{
        //    await Shell.Current.GoToAsync("testingPage");
        //}
    }

}
