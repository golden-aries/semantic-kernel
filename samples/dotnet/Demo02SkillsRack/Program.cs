// Copyright (c) Microsoft. All rights reserved.

using Demo02SkillsRack.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Orchestration;

var cb = new ConfigurationBuilder();
cb.AddJsonFile("appsettings.json");
cb.AddUserSecrets<AIServiceOptions>(); // re-using the same secret id as CopilotChatWebApi
var config = cb.Build();
var options = new AIServiceOptions();
config.Bind("AIService", options);

var builder = Kernel.Builder.WithAzureChatCompletionService(
        options.Models.Completion,
        options.Endpoint,
        options.Key);

IKernel kernel = builder.Build();
// Load the Skills Directory
var d = System.IO.Directory.GetCurrentDirectory();
var skillsDirectory = Path.GetFullPath($"{d}/../../../skills");

await CreateExcuse(kernel, skillsDirectory);

// await CreateLimeric(kernel, skillsDirectory);

// await JokeOnGoingToDepartmentStore(kernel, skillsDirectory);

// await JokeOnTravelToDinosaurAge(kernel, skillsDirectory);

Console.WriteLine("Done!");

static async Task JokeOnTravelToDinosaurAge(IKernel kernel, string skillsDirectory)
{
    // Load the FunSkill from the Skills Directory
    var mySkill = kernel.ImportSemanticSkillFromDirectory(skillsDirectory, "FunSkill");

    // The default input variable 
    var myInput = "time travel to dinosaur age";

    // Run the Function called Joke with the default parameter of $input
    var result = await kernel.RunAsync(myInput, mySkill["Joke"]);

    // Return the result to the Notebook
    Console.WriteLine(result);
}

static async Task JokeOnGoingToDepartmentStore(IKernel kernel, string skillsDirectory)
{
    // Reload the FunSkill from the Skills Directory in case you are changing it for fun
    var mySkill = kernel.ImportSemanticSkillFromDirectory(skillsDirectory, "FunSkill");

    // THIS IS NEW!
    var myContext = new ContextVariables();

    // The variables are manually set when you use a ContextVariables object
    myContext.Set("input", "going to the department store");
    myContext.Set("audience_type", "snobby people");

    var myResult = await kernel.RunAsync(myContext, mySkill["Joke"]);
    Console.WriteLine(myResult);
}

static async Task CreateLimeric(IKernel kernel, string skillsDirectory)
{
    var mySkill = kernel.ImportSemanticSkillFromDirectory(skillsDirectory, "FunSkill");

    var myContext = new ContextVariables();
    myContext.Set("name", "Marie Curie");
    myContext.Set("who_is_name", "the great scientist");

    var myResult = await kernel.RunAsync(myContext, mySkill["Limerick"]);

    Console.WriteLine(myResult);
}

static async Task CreateExcuse(IKernel kernel, string skillsDirectory)
{
    var mySkill = kernel.ImportSemanticSkillFromDirectory(skillsDirectory, "FunSkill");

    // The default input variable 
    var myInput = "I forgot to bring my tools";

    // Run the Function called Joke with the default parameter of $input
    var result = await kernel.RunAsync(myInput, mySkill["Excuses"]);

    // Return the result to the Notebook
    Console.WriteLine(result);
}
