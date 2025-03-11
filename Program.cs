using MudBlazor;
using MudBlazor.Services;
using ProtelBlazorApp.Components; // Importa los componentes de la aplicación Blazor

var builder = WebApplication.CreateBuilder(args); // Crea un constructor de aplicación web con los argumentos proporcionados

// Agregar el servicio de notificaciones de MudBlazor
builder.Services.AddMudServices(config => {
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopRight;
});

// Agrega servicio mudblazor al contenedor, este es un servicio de componentes de Blazor para Material Design
builder.Services.AddMudServices();


// Agrega servicios al contenedor.
builder.Services.AddRazorComponents() // Agrega servicios de componentes Razor
    .AddInteractiveServerComponents(); // Agrega servicios de componentes interactivos del servidor

var app = builder.Build(); // Construye la aplicación



/* Niveles de registro:
 * trace: registra eventos muy detallados sobre la ejecución de la aplicación
 * debug: registra eventos de depuración que pueden ser útiles durante el desarrollo
 * information: registra eventos informativos que describen el progreso de la aplicación
 */

// Configura el pipeline de solicitudes HTTP.
if (!app.Environment.IsDevelopment()) // Si el entorno no es de desarrollo
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true); // Usa un manejador de excepciones y crea un ámbito para errores
    app.UseHsts(); // Usa HSTS (HTTP Strict Transport Security) para mejorar la seguridad
}

app.UseHttpsRedirection(); // Redirige las solicitudes HTTP a HTTPS
app.UseAntiforgery(); // Usa protección contra falsificación de solicitudes
app.MapStaticAssets(); // Mapea los activos estáticos
app.MapRazorComponents<App>() // Mapea los componentes Razor de la aplicación
    .AddInteractiveServerRenderMode(); // Agrega el modo de renderizado interactivo del servidor

app.Run(); // Ejecuta la aplicación

