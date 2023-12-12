//// Copyright (c) Microsoft. All rights reserved.
using DemoCommon.Options;
//using Microsoft.SemanticKernel;
//using Microsoft.SemanticKernel.Orchestration;

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
//var skill = kernel.ImportSemanticSkillFromDirectory(skillsDirectory, "ChatSkill");

////await ChatBot(kernel, skill);

//await ChatBotWithPersonality(kernel, skill);

//Console.WriteLine("Done!");

//static async Task ChatBot(IKernel kernel, IDictionary<string, Microsoft.SemanticKernel.SkillDefinition.ISKFunction> skill)
//{
//    var myContext = new ContextVariables();
//    var botPrompt = "AI: Hello there how can I help you?";
//    var history = $"{botPrompt}\n";
//    //const int numberOfRounds = 4;

//    //for (var i = 0; i < numberOfRounds; i++)
//    while(true)
//    {
//        try
//        {
//            // get input from the user and set the context variable
//            //Console.Write($"{botPrompt} ({(i + 1)} of {numberOfRounds})");
//            Console.WriteLine(botPrompt); Console.Write("Me: ");
//            var input = Console.ReadLine() ?? throw new Exception("Empty input!");
//            if (input == "exit")
//            {
//                break;
//            }
//            myContext.Set("input", input);

//            // run the chat function
//            var myResult = await kernel.RunAsync(myContext, skill["Chat"]);

//            // tack onto the history 👇 what's come back from the model
//            /********************************************************/
//            var theNewChatExchange = $"Me: {input}\nAI:{myResult}\n";
//            history += theNewChatExchange;
//            myContext.Set("history", history);
//            /********************************************************/
//            // this way the new chat exchange gets passed into the next round

//            // announce the number of rounds and the history
//            //Console.WriteLine($"Chat for {i + 1} of {numberOfRounds} rounds with AI:\n{history}");

//            // prepare to "prompt" the user with the bot's response
//            botPrompt = $"AI: {myResult}:";
//        }
//        catch
//        {
//            // if the user hits "Escape" we end the chat early
//            Console.WriteLine("AI: Thanks for the wonderful chat!");
//            break;
//        }
//    }
//}

//static async Task ChatBotWithPersonality(IKernel kernel, IDictionary<string, Microsoft.SemanticKernel.SkillDefinition.ISKFunction> skill)
//{
//    var myContext = new ContextVariables();
//    var botName = "AI";

//    // Choose a personality here 👇 ...
//    /*********************************************************************/
//    var personality = "grumpy and extremely unhelpful";
//    /*********************************************************************/

//    var botPrompt = $"AI: Hello. My responses will be {personality}.";
//    var history = $"{botPrompt}\n";

//    const int numberOfRounds = 4;

//    myContext.Set("history", history);
//    myContext.Set("personality", personality);

//    //for (var i = 0; i < numberOfRounds; i++)
//    while(true)
//    {
//        try
//        {
//            // get input from the user and set the context variable
//            // get input from the user and set the context variable
//            Console.WriteLine(botPrompt); Console.Write("Me: ");
//            var input = Console.ReadLine() ?? throw new Exception("Empty input!");
//            if (input == "exit")
//            {
//                break;
//            }
//            myContext.Set("input", input);

//            // run the chat function
//            var myResult = await kernel.RunAsync(myContext, skill["ChatPersonality"]);

//            // tack onto the history what's come out
//            var theNewChatExchange = $"Me: {input}\nAI:{myResult}\n";
//            history += theNewChatExchange;
//            myContext.Set("history", history);

//            // announce the number of rounds and the history
//            //Console.WriteLine($"Chat for {i + 1} of {numberOfRounds} rounds with {botName}:\n{history}");

//            // prepare to "prompt" the user with the bot's response
//            botPrompt = $"AI: {myResult}";
//        }
//        catch
//        {
//            // if the user hits "Escape" we end the chat early
//            Console.WriteLine($"AI: Thanks for the wonderful chat!");
//            break;
//        }
//    }
//}
