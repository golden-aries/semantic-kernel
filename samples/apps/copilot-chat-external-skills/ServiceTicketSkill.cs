// Copyright (c) Microsoft. All rights reserved.

using Microsoft.SemanticKernel.Orchestration;
using Microsoft.SemanticKernel.SkillDefinition;

namespace CopilotChatExternalSkills;

/// <summary>
/// Skill related to filing ticket
/// </summary>
public class ServiceTicketSkill
{
    [SKFunction("File service ticket")]
    [SKFunctionName("FileTicket")]
    [SKFunctionContextParameter(Name = "chatId", Description = "Chat ID to extract history from")]
    [SKFunctionContextParameter(Name = "audience", Description = "The audience the chat bot is interacting with.")]
    public async Task FileTicketAsync(SKContext context)
    {
        await Task.CompletedTask;
    }

}
