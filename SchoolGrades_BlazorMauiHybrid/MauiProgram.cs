using Microsoft.Extensions.Logging;
using SchoolGrades;
using gamon.TreeMptt;
using TreeMpttBlazor.Extensions;

namespace SchoolGrades_BlazorMauiHybrid
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
                });

            builder.Services.AddMauiBlazorWebView();

            // Registrazione dei servizi SchoolGrades
            builder.Services.AddSingleton<BusinessLayer>();
            builder.Services.AddScoped<TreeMptt>();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif
            var app = builder.Build();

            // Inizializzazione di Commons
            InitializeCommons();

            return app;
        }

        private static void InitializeCommons()
        {
            try
            {
                // Inizializzazione dei percorsi di Commons
                Commons.CreatePaths();
                
                // Prova a leggere la configurazione
                try
                {
                    Commons.ReadConfigData();
                }
                catch
                {
                    Console.WriteLine("Configurazione non trovata o invalida. Sarà gestita dalla pagina Setup.");
                }
                
                // Inizializza BusinessLayer solo se la configurazione è valida
                try
                {
                    Commons.bl = new BusinessLayer();
                    
                    if (!string.IsNullOrEmpty(Commons.PathAndFileDatabase) && File.Exists(Commons.PathAndFileDatabase))
                    {
                        Commons.CreateAndStartBackgroundSavingThread();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Errore nell'inizializzazione BusinessLayer: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore nell'inizializzazione generale: {ex.Message}");
            }
        }
    }
}
