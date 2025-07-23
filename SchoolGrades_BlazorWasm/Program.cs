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
        
        // Leggi configurazione
        if (!Commons.ReadConfigData())
        {
            // Se non esiste configurazione, usa valori di default
            Commons.DatabaseFileName_Current = Commons.DatabaseFileName_Teacher;
            Commons.PathAndFileDatabase = Path.Combine(Commons.PathDatabase, Commons.DatabaseFileName_Current);
        }
        
        // Inizializza BusinessLayer
        Commons.bl = new BusinessLayer();
        
        // Inizializza il thread di salvataggio in background
        Commons.CreateAndStartBackgroundSavingThread();
    }
    catch (Exception ex)
    {
        Commons.ErrorLog("Errore nell'inizializzazione: " + ex.Message);
        throw;
    }
}
