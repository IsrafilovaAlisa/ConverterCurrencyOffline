using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using utf.DataBase;

namespace utf
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            //builder.Services.AddDbContext<MyDbContext>(options =>
            //  options.UseSqlite($"Data Source={Path.Combine(FileSystem.AppDataDirectory, "InformationABPurchases")}"));
            //builder.Services.AddSingleton<InformationABTPurchases>();

#if DEBUG
            builder.Logging.AddDebug();
#endif
            
            return builder.Build();
        }
    }
}
