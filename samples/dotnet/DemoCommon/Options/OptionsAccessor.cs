// Copyright (c) Microsoft. All rights reserved.

using Microsoft.Extensions.Configuration;

namespace DemoCommon.Options;
public static class OptionsAccessor
{
    public static AIServiceOptions GetOptions()
    {
        var cb = new ConfigurationBuilder();
        cb.AddJsonFile("appsettings.json");
        cb.AddUserSecrets<AIServiceOptions>(); // re-using the same secret id as CopilotChatWebApi
        var config = cb.Build();
        var options = new AIServiceOptions();
        config.Bind(AIServiceOptions.PropertyName, options);
        options.Validate();
        return options;
    }
}
