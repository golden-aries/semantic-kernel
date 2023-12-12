// Copyright (c) Microsoft. All rights reserved.

using System.Diagnostics;
using Newtonsoft.Json;

namespace TxExperiment.Http;
public class TxHttpHandler : DelegatingHandler
{
    private static readonly string s_prefix = "*************** LLM";
    /// <summary>
    /// ClientName
    /// </summary>
    public readonly string ClientName = nameof(TxHttpHandler);

    private static readonly string s_requestsLeft = "x-ratelimit-remaining-requests";
    private static readonly string s_tokensLeft = "x-ratelimit-remaining-tokens";
    private static readonly string s_msReqId = "x-ms-client-request-id";
    private static long s_seq;
    private static readonly Stopwatch s_stopWatch = Stopwatch.StartNew();

    /// <inheritdoc/>
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        try
        {
            request.Headers.TryGetValues(s_msReqId, out var reqIds);
            var reqId = reqIds?.FirstOrDefault();
            _ = request.Content ??
                 throw new InvalidOperationException("HttpRequest Content is null");

            var reqStr = await (request.Content.ReadAsStringAsync(cancellationToken))
                .ConfigureAwait(false);
            if (string.IsNullOrWhiteSpace(reqStr))
            {
                throw new InvalidOperationException($"{s_prefix} | Request | Unexpected | ReqId {reqId} | {request.RequestUri}");

            }

            var holder = JsonConvert.DeserializeObject<MessagesHolder>(reqStr)
                   ?? throw new JsonException("Unable to deserialize ChatHistory");
            var tokenQty = TokenCounter.GetContextMessagesTokenCount(holder.Messages!);

            TimeSpan fromPreviousRequest;
            lock (s_stopWatch)
            {
                s_seq += 1;
                s_stopWatch.Stop();
                fromPreviousRequest = s_stopWatch.Elapsed;
            }
            Debug.WriteLine($"{s_prefix} | {s_seq} Request  | Tokens {tokenQty} | ReqId {reqId} | {request.RequestUri}\n");
            Debug.WriteLine($"{DateTime.Now} | Delay From previous: {fromPreviousRequest} \n" + JsonConvert.SerializeObject(holder, Formatting.Indented));

            var resp = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
            lock (s_stopWatch)
            {
                s_stopWatch.Start();
            }
            if (resp.IsSuccessStatusCode || 429 == (int)resp.StatusCode)
            {

                resp.Headers.TryGetValues(s_requestsLeft, out var requestsLeft);
                resp.Headers.TryGetValues(s_tokensLeft, out var tokensLeft);
                request.Headers.TryGetValues(s_msReqId, out var respReqIds);
                var respReqId = respReqIds?.FirstOrDefault();
                Debug.Assert(reqId == respReqId);

                var rl = requestsLeft?.FirstOrDefault();
                var tl = tokensLeft?.FirstOrDefault();
                Debug.WriteLine($"{s_prefix} | {s_seq} Response {resp.StatusCode} | Requests Left: {rl} | Tokens Left: {tl} | ReqId {respReqId}\n");

                if (resp.IsSuccessStatusCode)
                {
                    var respStr = await resp.Content
                        .ReadAsStringAsync(cancellationToken)
                        .ConfigureAwait(false);
                    //resp.Content = new StringContent(reqStr);
                    Debug.WriteLine(respStr);
                }
            }
            else
            {
                Debug.WriteLine($"{s_prefix} | {s_seq} Response {resp.StatusCode}");
            }
            return resp;

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"{s_prefix} | {s_seq} Eception: ex.Message");
            throw;
        }
    }
}
