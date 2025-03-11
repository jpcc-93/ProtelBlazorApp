using MudBlazor;
using MudBlazor.Services;
using ProtelBlazorApp.Components; // Importa los componentes de la aplicaci�n Blazor

var builder = WebApplication.CreateBuilder(args); // Crea un constructor de aplicaci�n web con los argumentos proporcionados

// Agregar el servicio de notificaciones de MudBlazor
builder.Services.AddMudServices(config => {
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopRight;
});

// Agrega servicio mudblazor al contenedor, este es un servicio de componentes de Blazor para Material Design
builder.Services.AddMudServices();


// Agrega servicios al contenedor.
builder.Services.AddRazorComponents() // Agrega servicios de componentes Razor
    .AddInteractiveServerComponents(); // Agrega servicios de componentes interactivos del servidor

var app = builder.Build(); // Construye la aplicaci�n



/* Niveles de registro:
 * trace: registra eventos muy detallados sobre la ejecuci�n de la aplicaci�n
 * debug: registra eventos de depuraci�n que pueden ser �tiles durante el desarrollo
 * information: registra eventos informativos que describen el progreso de la aplicaci�n
 */

// Configura el pipeline de solicitudes HTTP.
if (!app.Environment.IsDevelopment()) // Si el entorno no es de desarrollo
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true); // Usa un manejador de excepciones y crea un �mbito para errores
    app.UseHsts(); // Usa HSTS (HTTP Strict Transport Security) para mejorar la seguridad
}

app.UseHttpsRedirection(); // Redirige las solicitudes HTTP a HTTPS
app.UseAntiforgery(); // Usa protecci�n contra falsificaci�n de solicitudes
app.MapStaticAssets(); // Mapea los activos est�ticos
app.MapRazorComponents<App>() // Mapea los componentes Razor de la aplicaci�n
    .AddInteractiveServerRenderMode(); // Agrega el modo de renderizado interactivo del servidor

app.Run(); // Ejecuta la aplicaci�n

