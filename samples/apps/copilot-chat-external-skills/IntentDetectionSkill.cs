// Copyright (c) Microsoft. All rights reserved.

using Microsoft.SemanticKernel.Orchestration;
using Microsoft.SemanticKernel.SkillDefinition;

namespace CopilotChatExternalSkills;
public class IntentDetectionSkill
{
    private string _prompt = @"
{{$input}}

---------------------------------------------

Provide the intent of the user. The intent should be one of the following: suggestion, ticket

INTENT: 
";


    [SKFunction("Detects intent")]
    [SKFunctionName("Detect user intent")]
    public async Task DetectUserIntentAsync(SKContext context)
    {
        
        await Task.CompletedTask;
    }

}
