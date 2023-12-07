// Copyright (c) Microsoft. All rights reserved.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.Json;
using Azure.AI.OpenAI;

namespace TxExperiment;
public static class TxChatCompletionsSerializer
{
    public static ChatCompletions? DeserializeChatCompletions(JsonElement element)
    {
        var method = typeof(ChatCompletions).GetMethod(
            "DeserializeChatCompletions",
            BindingFlags.Static | BindingFlags.NonPublic);

        var result = method.Invoke(typeof(ChatCompletions), new object[] { element });
        return result as ChatCompletions;
    }
}
