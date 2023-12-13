// Copyright (c) Microsoft. All rights reserved.

using DemoCommon;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;
using TxExperiment.Http;

string SepcialHttpClientName = nameof(TxAiChatCompletionSettings);

var hab = Host.CreateApplicationBuilder(args);
hab.Configuration.AddJsonFile("appsettings.json")
    .AddUserSecrets<TxAiChatCompletionSettings>();

hab.Services.AddTransient<TxHttpHandler>();
hab.Services.AddHttpClient();
hab.Services.AddHttpClient(SepcialHttpClientName)
    .AddHttpMessageHandler<TxHttpHandler>();

var host = hab.Build();
var env = host.Services.GetRequiredService<IHostEnvironment>();
Console.WriteLine($"{env.ApplicationName} running in {env.EnvironmentName} environment!");

var conf = host.Services.GetRequiredService<IConfiguration>();

var opts = conf.GetSection(nameof(TxAiChatCompletionSettings))
    .Get<TxAiChatCompletionSettings>()
    ?? throw new ArgumentNullException(nameof(TxAiChatCompletionSettings));

var factory = host.Services.GetRequiredService<IHttpClientFactory>();

var builder = new KernelBuilder();
builder.Services.AddLogging(c => c.AddConsole().SetMinimumLevel(LogLevel.Information));


Kernel kernel = builder
        .AddAzureOpenAIChatCompletion(
                deploymentName: opts.DeploymentName,
                modelId: opts.ModelId,
                endpoint: opts.Endpoint,
                apiKey: opts.ApiKey,
                 httpClient: factory.CreateClient(SepcialHttpClientName))
        .Build();

var appLifeTime = host.Services.GetRequiredService<IHostApplicationLifetime>(); // kernel.Services.GetRequiredService<IApplicationLifetime>();
string folder = RepoFiles.SamplePluginsPath();
folder = Path.Combine(folder, "IntentDetectionPlugin");
var plugin = kernel.ImportPluginFromPromptDirectory(folder);


if (!plugin.TryGetFunction("AssistantIntent", out var func))
{
    Console.WriteLine("Function nof found!");
    return;
};
var a = new KernelArguments("Do you know any Joke!");
#pragma warning disable CA1031 // Do not catch general exception types
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
#pragma warning restore CA1031 // Do not catch general exception types
Console.WriteLine("Done!");
