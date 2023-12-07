//using System.Text.Json;
//using Microsoft.SemanticKernel.Orchestration;
//using Microsoft.SemanticKernel.Planning;
//using SemanticKernel.Service.CopilotChat.Models;

//namespace Tests;

//public class PlanSerializationTest
//{
//    //[Fact]
//    public void CanSerializePlan()
//    {
//        string planJson = @"{""plan"":{
//""rationale"": ""the list contains a function that allows to get the weather forecast"",
//""function"": ""RandomSkills.GetWeather"",
//""parameters"": {
//""location"": ""Vancouver"",
//""date"": ""July 14, 2023""
//}}}
//";
//        Plan plan = Plan.FromJson(planJson) ?? throw new JsonException("Unable to deserialize plan");


//        var proposedPlan = new ProposedPlan(plan, PlanType.Action, PlanState.NoOp);
//        var proposedPlanJson = JsonSerializer.Serialize<ProposedPlan>(proposedPlan);
//        var deSerializedProposedPlan = JsonSerializer.Deserialize<ProposedPlan>(proposedPlanJson)
//            ?? throw new JsonException("Unable to deserialzie ProposedPlan");
//        string newPlanJson = JsonSerializer.Serialize(deSerializedProposedPlan.Plan);
//        var newPlanContext = new SKContext();
//        var deserializedPlan = Plan.FromJson(newPlanJson, newPlanContext);

//    }
//}
