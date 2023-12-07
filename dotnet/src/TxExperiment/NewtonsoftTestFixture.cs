// Copyright (c) Microsoft. All rights reserved.

using Azure.AI.OpenAI;
using Newtonsoft.Json;

namespace PrivateTests;

public static class NewtonsoftTestFixture
{
    public static string Serialize(ChatCompletions obj)
    {
        var result = JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);
        return result;
    }

    public static ChatCompletions? DeSerialize(string obj)
    {
        var result = JsonConvert.DeserializeObject<ChatCompletions>(obj);
        return result;
    }
}
