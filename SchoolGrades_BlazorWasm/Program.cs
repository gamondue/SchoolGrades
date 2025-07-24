using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SchoolGrades_BlazorWasm;
using SchoolGrades;
using gamon.TreeMptt;
using TreeMpttBlazor.Extensions;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Registrazione dei servizi SchoolGrades
builder.Services.AddSingleton<BusinessLayer>();
builder.Services.AddScoped<TreeMptt>();

var app = builder.Build();

// Inizializzazione di Commons (simile a come viene fatto nel Windows Forms)
await InitializeCommonsAsync();

await app.RunAsync();

static async Task InitializeCommonsAsync()
{
    try
    {
        // Inizializzazione dei percorsi di Commons
        Commons.CreatePaths();
        
        // Prova a leggere la configurazione - se non esiste, Setup gestirà la configurazione iniziale
        try
        {
            Commons.ReadConfigData();
        }
        catch
        {
            // Se la configurazione non esiste o è invalida, Setup permetterà di configurarla
            Console.WriteLine("Configurazione non trovata o invalida. Sarà gestita dalla pagina Setup.");
        }
        
        // Inizializza BusinessLayer solo se la configurazione è valida
        try
        {
            Commons.bl = new BusinessLayer();
            
            // Inizializza il thread di salvataggio in background solo se il database è configurato
            if (!string.IsNullOrEmpty(Commons.PathAndFileDatabase) && File.Exists(Commons.PathAndFileDatabase))
            {
                Commons.CreateAndStartBackgroundSavingThread();
            }
        }
        catch (Exception ex)
        {
            // Se l'inizializzazione del BusinessLayer fallisce, l'utente dovrà configurare tramite Setup
            Console.WriteLine($"Errore nell'inizializzazione BusinessLayer: {ex.Message}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Errore nell'inizializzazione generale: {ex.Message}");
        // L'applicazione può continuare e l'utente userà Setup per configurare
    }
}
