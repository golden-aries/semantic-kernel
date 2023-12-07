using System.Text.Json;
using TxExperiment;

namespace TxTests;

public class TxUnitTest1
{
    private string json = @"
{
  ""Id"": ""chatcmpl-7mSfLlVaFSuxrRjnPbvjCj9oVbZ6W"",
  ""Created"": 1691786602,
  ""Choices"": [
    {
      ""Message"": {
        ""Role"": {
          ""Label"": ""assistant""
        },
        ""Content"": ""The user is reporting that their tester is not functioning properly.""
      },
      ""Index"": 0,
      ""FinishReason"": ""stop""
    }
  ],
  ""Usage"": {
    ""CompletionTokens"": 12,
    ""PromptTokens"": 408,
    ""TotalTokens"": 420
  }
}
";

    [Fact]
    public void Test1()
    {
        var elem = JsonSerializer.Deserialize<JsonElement>(json);
        TxChatCompletionsSerializer.DeserializeChatCompletions(elem);
    }
}
