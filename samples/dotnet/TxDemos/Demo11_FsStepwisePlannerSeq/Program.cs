// Copyright (c) Microsoft. All rights reserved.

using DemoCommon;
using DemoCommon.Plugins;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Planning;
using TxExperiment.Http;
using TxExperiment.Skills;

string SepcialHttpClientName = nameof(TxAiChatCompletionSettings);

var hab = Host.CreateApplicationBuilder(args);
hab.Configuration.AddJsonFile("appsettings.json")
    .AddUserSecrets<TxAiChatCompletionSettings>();

hab.Services.Configure<TxAiChatCompletionSettings>(
       hab.Configuration.GetSection(nameof(TxAiChatCompletionSettings)));

hab.Services.AddLogging(builder =>
            builder.AddConsole().AddSeq());

hab.Services.AddTransient<TxHttpHandler>();
hab.Services.AddHttpClient();
hab.Services.AddHttpClient(SepcialHttpClientName)
    .AddHttpMessageHandler<TxHttpHandler>();

hab.Services.AddScoped<Kernel>(sp =>
{
    var opts = sp.GetRequiredService<IOptionsSnapshot<TxAiChatCompletionSettings>>().Value;
    var builder = new KernelBuilder();

    var factory = sp.GetRequiredService<IHttpClientFactory>();

    Kernel kernel = builder
        .AddAzureOpenAIChatCompletion(
                deploymentName: opts.DeploymentName,
                modelId: opts.ModelId,
                endpoint: opts.Endpoint,
                apiKey: opts.ApiKey,
                httpClient: factory.CreateClient(SepcialHttpClientName))
        .Build();

    //kernel.ImportPluginFromType<HelpDeskSkill>();
    kernel.ImportPluginFromType<EmailPlugin>();
    kernel.ImportPluginFromType<MathPlugin>();
    kernel.ImportPluginFromType<TimePlugin>();

    return kernel;
});

var host = hab.Build();
using var scope = host.Services.CreateScope();
var env = scope.ServiceProvider.GetRequiredService<IHostEnvironment>();
//var logger = scope.ServiceProvider.GetRequiredService<ILogger<TxHttpHandler>>();
//logger.LogInformation("Test logging");

Console.WriteLine($"{env.ApplicationName} running in {env.EnvironmentName} environment!");
var appLifeTime = scope.ServiceProvider.GetRequiredService<IHostApplicationLifetime>();
var kernel = scope.ServiceProvider.GetRequiredService<Kernel>();

string[] questions = new string[]
       {
            "I need quote",
            //"What is 387 minus 22? Email the solution to John and Mary.",
            //"Write a limerick, translate it to Spanish, and send it to Jane",
       };

#pragma warning disable SKEXP0061 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
var config = new FunctionCallingStepwisePlannerConfig
{
    MaxIterations = 15,
    MaxTokens = 4000,
};
var planner = new FunctionCallingStepwisePlanner(config);


foreach (var question in questions)
{
    try
    {
        FunctionCallingStepwisePlannerResult result = await planner.ExecuteAsync(kernel, question);
        Console.WriteLine($"Q: {question}\nA: {result.FinalAnswer}");
    }
    catch (Exception)
    {
        throw;
    }

    // You can uncomment the line below to see the planner's process for completing the request.
    // Console.WriteLine($"Chat history:\n{result.ChatHistory?.AsJson()}");
}
#pragma warning restore SKEXP0061 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
