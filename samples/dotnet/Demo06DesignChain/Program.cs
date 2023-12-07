//// Copyright (c) Microsoft. All rights reserved.
using DemoCommon.Options;
//using Markdig;
//using Microsoft.SemanticKernel;
//using Microsoft.SemanticKernel.Orchestration;
//using Microsoft.SemanticKernel.SkillDefinition;

var options = OptionsAccessor.GetOptions();

//var builder = Kernel.Builder
//    .WithAzureChatCompletionService(
//        options.Models.Completion,
//        options.Endpoint,
//        options.Key);

//IKernel kernel = builder.Build();
//// define the Skills Directory
//var d = System.IO.Directory.GetCurrentDirectory();
//var skillsDirectory = Path.GetFullPath($"{d}/../../../skills");
//// load skill from skills directory
//var skillDT = kernel.ImportSemanticSkillFromDirectory(skillsDirectory, "DesignThinkingSkill");

//var batch = GetNegativeCase();

//// await DoItAsAChainedQuery(kernel, skillDT, input, resultFile);

//var result = await DoItOneByOne(kernel, skillDT, batch.Input);

//var resultFile = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "results", batch.FileName));
//Directory.CreateDirectory(resultFile.Directory!.FullName);
//SaveResultsToHtmlFile(resultFile.FullName, result);

//Console.WriteLine("Done!");

//static async Task<SKContext> Empathize(IKernel kernel, IDictionary<string, ISKFunction> skillDT, string input)
//{
//    Console.Write("Empathizing ...");

//    // The default input variable 

//    var empathyResult = await kernel.RunAsync(input, skillDT["Empathize"]);
//    Console.WriteLine(empathyResult);
//    return empathyResult;
//}

//static async Task<SKContext> Definig(IKernel kernel, IDictionary<string, ISKFunction> skillDT, SKContext empathyResult)
//{
//    Console.Write("Defining ...");

//    var defineResult = await kernel.RunAsync(empathyResult.ToString(), skillDT["Define"]);
//    Console.WriteLine(defineResult);
//    return defineResult;
//}

//static async Task<SKContext> Ideate(IKernel kernel, IDictionary<string, ISKFunction> skillDT, SKContext defineResult)
//{
//    Console.WriteLine("Ideating...");
//    var ideateResult = await kernel.RunAsync(defineResult.ToString(), skillDT["Ideate"]);

//    Console.WriteLine(ideateResult);
//    return ideateResult;
//}

//static async Task<SKContext> DoItOneByOne(IKernel kernel, IDictionary<string, ISKFunction> skillDT, string input)
//{
//    var empathyResult = await Empathize(kernel, skillDT, input);

//    var defineResult = await Definig(kernel, skillDT, empathyResult);

//    var ideateResult = await Ideate(kernel, skillDT, defineResult);
//    return ideateResult;
//}

//static async Task<SKContext> DoItAsAChainedQuery(IKernel kernel, IDictionary<string, ISKFunction> skillDT, string input, string resultFile)
//{
//    var myResult = await kernel.RunAsync(input, skillDT["Empathize"], skillDT["Define"], skillDT["Ideate"]);
//    return myResult;
//}

//static Batch GetPositiveCase()
//{
//    return new Batch
//    {
//        FileName = "positiveCase.html",
//        Input = @"
//Customer 1: The power button on my phone works well and very responsive. And it is still under warranty.
//Customer 2: My display is so vivid and responsive it is visible event in a broad day light.
//Customer 3: The customer service answer my email immediately.
//Customer 4: Every time I call customer support I get professional answer.
//Customer 5: The display screen works well and it's still under warranty.
//Customer 6: My power button is easy to find even at night. That's so wonderful.
//Customer 7: I'm very happy with the company.
//Customer 8: No matter how extensively I use the power button, but it still works well.
//"
//    };
//}

//static Batch GetNetralCase()
//{
//    return new Batch
//    {
//        FileName = "netralCase.html",
//        Input = @"
//Customer 1: The power button on my phone seems working. But sometimes response is slow.
//Customer 2: My display is visible.
//Customer 3: Mostly I was able to reach a customer service, but frequently it takes a lot of time.
//Customer 4: My customer support calls sometimes resolved sometimes not. Fifty fifty I would say.
//Customer 5: The display screen still works, but not bright enough. Warranty already expired.
//Customer 6: My power button works if I press it firmly. 
//Customer 7: I think the company doing something to address the issue.
//Customer 8: Power button works well. Hope it will stay the same, the warranty is out already.
//"
//    };
//}

//static Batch GetNegativeCase()
//{
//    return new Batch
//    {
//        FileName = "negativeCase.html",

//        Input = @"
//Customer 1: The power button on my phone is broken. The warranty is still valid.
//Customer 2: My display stopped working.
//Customer 3: The customer service rep didn't answer my email.
//Customer 4: Every time I call customer support I get no answer.
//Customer 5: The display screen cracked and it's still under warranty.
//Customer 6: My power button fell off the phone. That's ridiculous.
//Customer 7: I'm so frustrated with this company.
//Customer 8: When I use the power button too much, it stops working.
//"
//    };
//}

//static void SaveResultsToHtmlFile(string resultFile, SKContext result)
//{
//    var myPipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
//    var myResult2HTML = Markdown.ToHtml("# Ideate: 'Design Thinking' directions generated from customer empathy (Empathize) and problem definition (Define)\n\n" + result.ToString(), myPipeline);
//    File.WriteAllText(resultFile, myResult2HTML);
//    //System.Diagnostics.Process.Start(resultFile);
//    //var myHTMLContent = new HtmlContentBuilder();

//    //myHTMLContent.AppendHtml(myResult2HTML);
//    //myHTMLContent
//}

//public class Batch
//{
//    public string FileName { get; set; } = null!;
//    public string Input { get; set; } = null!;
//}
