// Copyright (c) Microsoft. All rights reserved.

using System.Collections.Generic;
using Newtonsoft.Json;

namespace Microsoft.SemanticKernel.Connectors.AI.OpenAI.AzureSdk;
internal class NewtonsoftTest1
{
    public static string Serialize(List<ChatResult> obj)
    {
        var result = JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);
        return result;
    }

    public static List<ChatResult>? DeSerialize(string obj)
    {
        var result = JsonConvert.DeserializeObject<List<ChatResult>>(obj);
        return result;
    }
}
