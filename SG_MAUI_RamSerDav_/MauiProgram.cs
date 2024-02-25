using Microsoft.Extensions.Logging;
using SG_MAUI_RamSerDav_.MVVM.Models;
using SG_MAUI_RamSerDav_.Repositories;

namespace SG_MAUI_RamSerDav_
{
    /// <summary>
    /// Clase que contiene la configuración de la aplicación Maui.
    /// </summary>
    public static class MauiProgram
    {
        /// <summary>
        /// Método estático para crear y configurar la aplicación Maui.
        /// </summary>
        /// <returns>La instancia de la aplicación Maui creada.</returns>
        public static MauiApp CreateMauiApp()
        {
            // Crea un nuevo constructor de la aplicación Maui
            var builder = MauiApp.CreateBuilder();

            // Configura la aplicación Maui
            builder
                .UseMauiApp<App>() // Usaremos App como HILO principal
                .ConfigureFonts(fonts =>
                {
                    // Agrega las fuentes personalizadas a la configuracion
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            // Agrega el registro de mensajes de depuración en modo de depuración
            builder.Logging.AddDebug();
#endif

            // Registra el repositorio de usuarios como singleton
            builder.Services.AddSingleton<BaseRepository<Usuario>>();

            // Construye y retorna la aplicación configurada y lista para funcionar
            return builder.Build();
        }
    }
}
