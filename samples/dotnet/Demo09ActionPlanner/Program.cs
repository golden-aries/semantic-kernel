//// Copyright (c) Microsoft. All rights reserved.

//using System.Reflection;
//using System.Text.Json;
//using Microsoft.SemanticKernel;
//using Microsoft.SemanticKernel.Orchestration;
//using Microsoft.SemanticKernel.Planning;

var a = 0;
//var kernelSettings = KernelSettings.LoadSettings();
//IKernel kernel = new KernelBuilder()
//    .WithCompletionService(kernelSettings)
//    .Build();

//string folder = SampleSkillsPath();
//kernel.ImportSemanticSkillFromDirectory(folder, "SummarizeSkill");
//kernel.ImportSemanticSkillFromDirectory(folder, "WriterSkill");

//// Create an instance of ActionPlanner.
//// The ActionPlanner takes one goal and returns a single function to execute.
//var planner = new ActionPlanner(kernel);

//// We're going to ask the planner to find a function to achieve this goal.
//var goal = "Write a poem about Cleopatra.";

//// The planner returns a plan, consisting of a single function
//// to execute and achieve the goal requested.
//var plan = await planner.CreatePlanAsync(goal);

//var serializedPlan = JsonSerializer.Serialize(plan, new JsonSerializerOptions { WriteIndented = true });
////Console.WriteLine("Plan:\n");
////Console.WriteLine(serializedPlan);

//// Execute the full plan (which is a single function)
//SKContext result = await plan.InvokeAsync();

//// Show the result, which should match the given goal
//Console.WriteLine(result);

///* Output:
// *
// * Cleopatra was a queen
// * But she didn't act like one
// * She was more like a teen

// * She was always on the scene
// * And she loved to be seen
// * But she didn't have a queenly bone in her body
// */

///// <summary>
///// Scan the local folders from the repo, looking for "samples/skills" folder.
///// </summary>
///// <returns>The full path to samples/skills</returns>
//string SampleSkillsPath()
//{
//    const string Parent = "samples";
//    const string Folder = "skills";

//    bool SearchPath(string pathToFind, out string result, int maxAttempts = 10)
//    {
//        var currDir = Path.GetFullPath(Assembly.GetExecutingAssembly().Location);
//        bool found;
//        do
//        {
//            result = Path.Join(currDir, pathToFind);
//            found = Directory.Exists(result);
//            currDir = Path.GetFullPath(Path.Combine(currDir, ".."));
//        } while (maxAttempts-- > 0 && !found);

//        return found;
//    }

//    if (!SearchPath(Parent + Path.DirectorySeparatorChar + Folder, out string path)
//        && !SearchPath(Folder, out path))
//    {
//        throw new DirectoryNotFoundException("Skills directory not found. The app needs the skills from the repo to work.");
//    }

//    return path;
//}
