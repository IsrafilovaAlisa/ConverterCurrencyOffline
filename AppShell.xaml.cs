using utf.DataBase;

namespace utf
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("HistoryCurrency", typeof(HistoryCurrencyView));
            //Routing.RegisterRoute("API", typeof(ServiceAPIKey));
            Routing.RegisterRoute("LocalPurchases", typeof(FramePurchases));
            
        }
    }
}
