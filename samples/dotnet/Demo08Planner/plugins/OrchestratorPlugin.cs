using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Orchestration;
using Microsoft.SemanticKernel.SkillDefinition;
using Newtonsoft.Json.Linq;

namespace Plugins;

public class OrchestratorPlugin
{
    IKernel _kernel;

    public OrchestratorPlugin(IKernel kernel)
    {
        _kernel = kernel;
    }

    [SKFunction("Routes the request to the appropriate function.")]
    public async Task<string> RouteRequest(SKContext context)
    {
        // Save the original user request
        string request = context["input"];

        // Add the list of available functions to the context
        context["options"] = "Sqrt, Add";

        // Retrieve the intent from the user request
        var GetIntent = _kernel.Skills.GetFunction("OrchestratorPlugin", "GetIntent");
        var CreateResponse = _kernel.Skills.GetFunction("OrchestratorPlugin", "CreateResponse");
        await GetIntent.InvokeAsync(context);
        string intent = context["input"].Trim();

        var GetNumbers = _kernel.Skills.GetFunction("OrchestratorPlugin", "GetNumbers");
        var ExtractNumbersFromJson = _kernel.Skills.GetFunction("OrchestratorPlugin", "ExtractNumbersFromJson");
        ISKFunction MathFunction;

        // Call the appropriate function
        switch (intent)
        {
            case "Sqrt":
                MathFunction = _kernel.Skills.GetFunction("MathPlugin", "Sqrt");
                break;
            case "Add":
                MathFunction = _kernel.Skills.GetFunction("MathPlugin", "Add");
                break;
            default:
                return "I'm sorry, I don't understand.";
        }

        var pipelineContext = new ContextVariables(request);
        pipelineContext["original_request"] = request;

        var output = await _kernel.RunAsync(
            pipelineContext,
            GetNumbers,
            ExtractNumbersFromJson,
            MathFunction,
            CreateResponse);

        return output["input"];
    }

    [SKFunction("Extracts numbers from JSON")]
    public SKContext ExtractNumbersFromJson(SKContext context)
    {
        JObject numbers = JObject.Parse(context["input"]);

        // otherwise, loop through numbers and add them to the context
        foreach (var number in numbers)
        {
            if (number.Key == "number1")
            {
                context["input"] = number.Value.ToString();
                continue;
            }
            else
            {
                context[number.Key] = number.Value.ToString();
            }
        }
        return context;
    }
}