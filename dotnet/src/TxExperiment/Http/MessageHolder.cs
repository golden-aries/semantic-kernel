// Copyright (c) Microsoft. All rights reserved.

namespace TxExperiment.Http;
/// <summary>
/// Holds Messages
/// </summary>
public class MessagesHolder
{
    /// <summary>
    /// Messages
    /// </summary>
    public List<TxChatMessage>? Messages { get; set; }
}

/// <summary>
/// Tx implementation of chat message
/// </summary>
public class TxChatMessage
{
    public string? Role { get; set; }
    public string? Content { get; set; }
}
