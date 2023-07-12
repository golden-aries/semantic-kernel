// Copyright (c) Microsoft. All rights reserved.

using Microsoft.SemanticKernel.Orchestration;
using Microsoft.SemanticKernel.SkillDefinition;

namespace CopilotChatExternalSkills;
public class RandomSkills
{


    [SKFunction("Get Weather Forecast")]
    [SKFunctionName("GetWeather")]
    [SKFunctionContextParameter(Name = "location", Description = "Location for which to get the weather")]
    [SKFunctionContextParameter(Name = "date", Description = "Forecast date")]
    public async Task<string> GetWeatherAsync(SKContext context)
    {
        await Task.CompletedTask;
        return "24 celcius no rain";
    }

    [SKFunction("Get Stock price")]
    [SKFunctionName("GetStock")]
    [SKFunctionContextParameter(Name = "name", Description = "Stock name")]
    public async Task<string> GetStockPriceAsync(SKContext context)
    {
        await Task.CompletedTask;
        return "5";
    }
}
