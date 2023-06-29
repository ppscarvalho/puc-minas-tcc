using Polly;
using SGL.Integrations.AutoMapper;
using SGL.Integrations.Htpp.Cliente;
using SGL.Integrations.Htpp.Fornecedor;
using SGL.Integrations.Htpp.Produto;
using SGL.Integrations.Interfaces;
using SGL.Integrations.Services;
using SGL.Util.Extensions;
using SGL.Util.Options;

var builder = WebApplication.CreateBuilder(args);
const int timeWait = 30;

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<HttpClienteDelegatingHandler>();
builder.Services.AddScoped<HttpFornecedorDelegatingHandler>();
builder.Services.AddScoped<HttpProdutoDelegatingHandler>();

builder.Services.AddHttpClient<IClienteClient, ClienteClient>()
      .AddHttpMessageHandler<HttpClienteDelegatingHandler>()
      .AddPolicyHandler(PollyExtensions.GetRetryPolicy())
      .AddTransientHttpErrorPolicy(p => p.CircuitBreakerAsync(2, TimeSpan.FromSeconds(timeWait)));

builder.Services.AddHttpClient<IFornecedorClient, FornecedorClient>()
      .AddHttpMessageHandler<HttpFornecedorDelegatingHandler>()
      .AddPolicyHandler(PollyExtensions.GetRetryPolicy())
      .AddTransientHttpErrorPolicy(p => p.CircuitBreakerAsync(2, TimeSpan.FromSeconds(timeWait)));

builder.Services.AddHttpClient<IProdutoClient, ProdutoClient>()
      .AddHttpMessageHandler<HttpProdutoDelegatingHandler>()
      .AddPolicyHandler(PollyExtensions.GetRetryPolicy())
      .AddTransientHttpErrorPolicy(p => p.CircuitBreakerAsync(2, TimeSpan.FromSeconds(timeWait)));

//Options
builder.Services.Configure<APIsOptions>(builder.Configuration.GetSection(nameof(APIsOptions)));

// Service
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IFornecedorService, FornecedorService>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();

// AutoMapping
builder.Services.AddAutoMapperSetup();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
