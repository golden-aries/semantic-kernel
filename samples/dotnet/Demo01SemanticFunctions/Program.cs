using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;
using Demo01SemanticFunctions;
using DemoCommon;
using Json.More;


var hab = Host.CreateApplicationBuilder(args);
hab.Configuration.AddJsonFile("appsettings.json")
    .AddUserSecrets<TxAiChatCompletionSettings>();

var host = hab.Build();
var conf = host.Services.GetRequiredService<IConfiguration>();

//var hb = new HostBuilder();
//hb.ConfigureAppConfiguration(cb =>
//{
//    cb.AddJsonFile("appsettings.json");
//    cb.AddUserSecrets<TxAiChatCompletionSettings>();
//});
//var host = hb.Build();
//var conf = host.Services.GetRequiredService<IConfiguration>();

//var cb = new ConfigurationBuilder();
//cb.AddJsonFile("appsettings.json");
//cb.AddUserSecrets<TxAiChatCompletionSettings>();
//var conf = cb.Build();

var opts = conf.GetSection(nameof(TxAiChatCompletionSettings)).Get<TxAiChatCompletionSettings>();
var builder = new KernelBuilder();
builder.Services.AddLogging(c => c.AddConsole().SetMinimumLevel(LogLevel.Information));


Kernel kernel = builder
        .AddAzureOpenAIChatCompletion(
                deploymentName: opts.ModelId,
                modelId: opts.ModelId,
                endpoint: opts.Endpoint,
                apiKey: opts.ApiKey)
        .Build();
//Console.WriteLine("Waiting for 1 day!");
//await Task.Delay(TimeSpan.FromDays(1));

var appLifeTime = host.Services.GetRequiredService<IHostApplicationLifetime>(); // kernel.Services.GetRequiredService<IApplicationLifetime>();
//var folder = RepoFiles.SamplePluginsPath();
//var plugin = kernel.ImportPluginFromPromptDirectory(folder, "MiscPlugin");

var folder = "C:\\src\\try\\sk\\Plugins\\MiscPlugin";
var plugin = kernel.ImportPluginFromPromptDirectory(folder);

if (!plugin.TryGetFunction("DiscoverIntent", out var func))
{
    Console.WriteLine("Function nof found!");
    return;
};
var a = new KernelArguments("Do you know any Joke!");
try
{
    FunctionResult result = await kernel.InvokeAsync(func, a, appLifeTime.ApplicationStopping);
    var v = result.GetValue<string>();
    Console.Write(result.ToString());
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
Console.WriteLine("Done!");
