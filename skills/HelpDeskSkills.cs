using System.ComponentModel;
using Microsoft.SemanticKernel.Orchestration;
using Microsoft.SemanticKernel.SkillDefinition;

namespace Skills;

/// <summary>
/// HelpDeskSkill
/// </summary>
public class HelpDeskSkill
{
    /// <summary>
    /// GeQuoteAsync
    /// </summary>
    /// <param name="quoteKind"></param>
    /// <param name="department"></param>
    /// <returns></returns>
    [SKFunction, Description("Get Qpath System Deployment(Installation) Quote")]
    public async Task<SKContext> GeQuoteAsync(
        [Description("New Hospital or additional department installation")] string quoteKind,
        [Description("Department Name (for department installation)")] string department)
    {
        await Task.CompletedTask;
        return new SKContext();
    }


    [SKFunction, Description("File ticket for Telexy Support Team")]
    public async Task<SKContext> FileTicketAsync(
        [Description("Problem Description")] string description)
    {
        await Task.CompletedTask;
        return new SKContext();
    }
}
