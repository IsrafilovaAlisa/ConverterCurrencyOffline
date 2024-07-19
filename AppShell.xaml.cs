using utf.DataBase;

namespace utf
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("HistoryCurrency", typeof(HistoryCurrencyView));
            Routing.RegisterRoute("LocalPurchases", typeof(FramePurchases));
            // Routing.RegisterRoute("New", typeof(NewPageTest));
           
        }
       
    }
}
