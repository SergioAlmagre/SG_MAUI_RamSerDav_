using Microsoft.Extensions.Logging;
using SG_MAUI_RamSerDav_.MVVM.Models;
using SG_MAUI_RamSerDav_.Repositories;

namespace SG_MAUI_RamSerDav_
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

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<BaseRepository<Usuario>>();
            return builder.Build();
        }
    }
}
