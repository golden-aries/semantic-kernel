//// Copyright (c) Microsoft. All rights reserved.

//using DemoCommon.Options;
using Microsoft.Extensions.Configuration;
//using Microsoft.SemanticKernel;
//using Microsoft.SemanticKernel.SemanticFunctions;

var cb = new ConfigurationBuilder();
//cb.AddJsonFile("appsettings.json");
//cb.AddUserSecrets<AIServiceOptions>(); // re-using the same secret id as CopilotChatWebApi
//var config = cb.Build();
//var options = new AIServiceOptions();
//config.Bind(AIServiceOptions.PropertyName, options);
//options.Validate();

//var builder = Kernel.Builder.WithAzureChatCompletionService(
//        options.Models.Completion,
//        options.Endpoint,
//        options.Key);

//IKernel kernel = builder.Build();

//string mySemanticFunctionInline = """
//{{$input}}

//Summarize the content above in less than 140 characters.
//""";



//var promptConfig = new PromptTemplateConfig
//{
//    Completion =
//    {
//        MaxTokens = 1000, Temperature = 0.2, TopP = 0.5,
//    }
//};

//var promptTemplate = new PromptTemplate(
//    mySemanticFunctionInline, promptConfig, kernel
//);

//var functionConfig = new SemanticFunctionConfig(promptConfig, promptTemplate);

//var summaryFunction = kernel.RegisterSemanticFunction("MySkill", "Summary", functionConfig);

//Console.WriteLine("A semantic function has been registered.");

//var input = """
//I think with some confidence I can say that 2023 is going to be the most exciting year that 
//the AI community has ever had,” writes Kevin Scott, chief technology officer at Microsoft, 
//in a Q&A on the company’s AI blog. He acknowledges that he also thought 2022 was the most 
//exciting year for AI, but he believes that the pace of innovation is only increasing. 
//This is particularly true with generative AI, which doesn’t simply analyze large data sets 
//but is a tool people can use to create entirely new works. We can already see its promise 
//in systems like GPT-3, which can do anything from helping copyedit and summarize text to 
//providing inspiration, and DALL-E 2, which can create useful and arresting works of art 
//based on text inputs. Here are some of Scott’s predictions about how AI will change the 
//way we work and play.
//""";
//// Text source: https://www.microsoft.com/en-us/worklab/kevin-scott-on-5-ways-generative-ai-will-transform-work-in-2023

//var summary = await kernel.RunAsync(input, summaryFunction);

//Console.WriteLine(summary);
//Console.WriteLine("Done!");
