using utf.Views;

namespace utf
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("Settings", typeof(SettingsView));
            Routing.RegisterRoute("LocalPurchases", typeof(FramePurchases));
           
        }
       
    }
}
