using utf.DataBase;
using SQLite;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace utf
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            
            MainPage = new AppShell();
        }
         
    }
}
