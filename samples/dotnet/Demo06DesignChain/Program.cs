// Copyright (c) Microsoft. All rights reserved.
using DemoCommon.Options;
using Markdig;
using Microsoft.AspNetCore.Html;
using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Orchestration;
using Microsoft.SemanticKernel.SkillDefinition;

var cb = new ConfigurationBuilder();
cb.AddJsonFile("appsettings.json");
cb.AddUserSecrets<AIServiceOptions>(); // re-using the same secret id as CopilotChatWebApi
var config = cb.Build();
var options = new AIServiceOptions();
config.Bind(AIServiceOptions.PropertyName, options);
options.Validate();

var builder = Kernel.Builder
    .WithAzureChatCompletionService(
        options.Models.Completion,
        options.Endpoint,
        options.Key);

IKernel kernel = builder.Build();
// define the Skills Directory
var d = System.IO.Directory.GetCurrentDirectory();
var skillsDirectory = Path.GetFullPath($"{d}/../../../skills");
// load skill from skills directory
var skillDT = kernel.ImportSemanticSkillFromDirectory(skillsDirectory, "DesignThinkingSkill");
string resultFile = Path.Combine(Directory.GetCurrentDirectory(), "result.html");

var input = @"
Customer 1: The power button on my phone is broken. The warranty is still valid.
Customer 2: My display stopped working.
Customer 3: The customer service rep didn't answer my email.
Customer 4: Every time I call customer support I get no answer.
Customer 5: The display screen cracked and it's still under warranty.
Customer 6: My power button fell off the phone. That's ridiculous.
Customer 7: I'm so frustrated with this company.
Customer 8: When I use the power button too much, it stops working.
";

await DoItAsAChainedQuery(kernel, skillDT, input, resultFile);

// await DoItOneByOne(kernel, skillDT, input);

Console.WriteLine("Done!");

static async Task<SKContext> Empathize(IKernel kernel, IDictionary<string, ISKFunction> skillDT, string input)
{
    Console.Write("Empathizing ...");

    // The default input variable 

    var empathyResult = await kernel.RunAsync(input, skillDT["Empathize"]);
    Console.WriteLine(empathyResult);
    return empathyResult;
}

static async Task<SKContext> Definig(IKernel kernel, IDictionary<string, ISKFunction> skillDT, SKContext empathyResult)
{
    Console.Write("Defining ...");

    var defineResult = await kernel.RunAsync(empathyResult.ToString(), skillDT["Define"]);
    Console.WriteLine(defineResult);
    return defineResult;
}

static async Task<SKContext> Ideate(IKernel kernel, IDictionary<string, ISKFunction> skillDT, SKContext defineResult)
{
    Console.WriteLine("Ideating...");
    var ideateResult = await kernel.RunAsync(defineResult.ToString(), skillDT["Ideate"]);

    Console.WriteLine(ideateResult);
    return ideateResult;
}

static async Task DoItOneByOne(IKernel kernel, IDictionary<string, ISKFunction> skillDT, string input)
{
    var empathyResult = await Empathize(kernel, skillDT, input);

    var defineResult = await Definig(kernel, skillDT, empathyResult);

    var ideateResult = await Ideate(kernel, skillDT, defineResult);
}

static async Task DoItAsAChainedQuery(IKernel kernel, IDictionary<string, ISKFunction> skillDT, string input, string resultFile)
{
    var myResult = await kernel.RunAsync(input, skillDT["Empathize"], skillDT["Define"], skillDT["Ideate"]);

    var myPipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
    var myResult2HTML = Markdown.ToHtml("# Ideate: 'Design Thinking' directions generated from customer empathy (Empathize) and problem definition (Define)\n\n" + myResult.ToString(), myPipeline);
    File.WriteAllText(resultFile, myResult2HTML);
    //System.Diagnostics.Process.Start(resultFile);
    //var myHTMLContent = new HtmlContentBuilder();

    //myHTMLContent.AppendHtml(myResult2HTML);
    //myHTMLContent
}
