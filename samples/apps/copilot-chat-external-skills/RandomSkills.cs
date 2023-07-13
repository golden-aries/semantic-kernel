// Copyright (c) Microsoft. All rights reserved.

using System.ComponentModel;
using Microsoft.SemanticKernel.Orchestration;
using Microsoft.SemanticKernel.SkillDefinition;

namespace CopilotChatExternalSkills;
public class RandomSkills
{


    //[SKFunction("Get Weather Forecast")]
    //[SKFunctionName("GetWeather")]
    //[SKFunctionContextParameter(Name = "location", Description = "Location for which to get the weather")]
    //[SKFunctionContextParameter(Name = "date", Description = "Forecast date")]
    //public async Task<string> GetWeatherAsync(SKContext context)
    //{
    //    await Task.CompletedTask;
    //    return "24 celcius no rain";
    //}

    [SKFunction("Get Weather Forecast")]
    [SKFunctionName("GetWeather")]
    //[SKFunctionContextParameter(Name = "location", Description = "Location for which to get the weather")]
    //[SKFunctionContextParameter(Name = "date", Description = "Forecast date")]
    public async Task<string> GetWeatherAsync(
        [Description("Location for which to get the weather forecast")] string location,
        [Description("Date on which weather forecast is required")] string date)
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
