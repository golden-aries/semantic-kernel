//// Copyright (c) Microsoft. All rights reserved.
//using DemoCommon.Options;
using Microsoft.Extensions.Configuration;
//using Microsoft.SemanticKernel;
//using Microsoft.SemanticKernel.Memory;

var cb = new ConfigurationBuilder();
//cb.AddJsonFile("appsettings.json");
//cb.AddUserSecrets<AIServiceOptions>(); // re-using the same secret id as CopilotChatWebApi
//var config = cb.Build();
//var options = new AIServiceOptions();
//config.Bind(AIServiceOptions.PropertyName, options);
//options.Validate();

//var builder = Kernel.Builder
//    .WithAzureChatCompletionService(
//        options.Models.Completion,
//        options.Endpoint,
//        options.Key)
//    .WithAzureTextEmbeddingGenerationService(
//        options.Models.Embedding,
//        options.Endpoint,
//        options.Key)
//    .WithMemoryStorage(new VolatileMemoryStore());

//IKernel kernel = builder.Build();

//await QLincolnSpeach(kernel);

//// await ResumeFromNoInfo(kernel);
//// await ResumeFromMemories(kernel);

//Console.WriteLine("Done!");

//static async Task ResumeFromNoInfo(IKernel kernel)
//{
//    var myFunction = kernel.CreateSemanticFunction(@"
//Tell me about me and {{$input}} in less than 70 characters.
//", maxTokens: 100, temperature: 0.8, topP: 1);
//    var result = await myFunction.InvokeAsync("my work history");
//    Console.WriteLine(result);
//}

//static async Task ResumeFromMemories(IKernel kernel)
//{
//    const string memoryCollectionName = "Facts About Me";

//    await kernel.Memory.SaveInformationAsync(memoryCollectionName, id: "LinkedIn Bio",
//        text: "I currently work in the hotel industry at the front desk. I won the best team player award.");

//    await kernel.Memory.SaveInformationAsync(memoryCollectionName, id: "LinkedIn History",
//        text: "I have worked as a tourist operator for 8 years. I have also worked as a banking associate for 3 years.");

//    await kernel.Memory.SaveInformationAsync(memoryCollectionName, id: "Recent Facebook Post",
//        text: "My new dog Trixie is the cutest thing you've ever seen. She's just 2 years old.");

//    await kernel.Memory.SaveInformationAsync(memoryCollectionName, id: "Old Facebook Post",
//        text: "Can you believe the size of the trees in Yellowstone? They're huge! I'm so committed to forestry concerns.");

//    Console.WriteLine("Four GIGANTIC vectors were generated just now from those 4 pieces of text above.");

//    string ask = "Tell me about me and my work history.";
//    var relatedMemory = "I know nothing.";
//    var counter = 0;

//    var memories = kernel.Memory.SearchAsync(memoryCollectionName, ask, limit: 5, minRelevanceScore: 0.77);

//    await foreach (MemoryQueryResult memory in memories)
//    {
//        if (counter == 0) { relatedMemory = memory.Metadata.Text; }
//        Console.WriteLine($"Result {++counter}:\n  >> {memory.Metadata.Id}\n  Text: {memory.Metadata.Text}  Relevance: {memory.Relevance}\n");
//    }
//    var myFunction = kernel.CreateSemanticFunction(@"
//{{$input}}
//Tell me about me and my work history in less than 70 characters.
//", maxTokens: 100, temperature: 0.1, topP: .1);

//    var result = await myFunction.InvokeAsync(relatedMemory);

//    Console.WriteLine(result);
//}

//List<string> ChunkTextFile(string filePath, int recommendedLength)
//{
//    List<string> chunks = new List<string>();

//    // Read in the text file
//    string text = File.ReadAllText(filePath);

//    // Break the text into chunks of the recommended length
//    int startIndex = 0;
//    while (startIndex < text.Length)
//    {
//        int endIndex = startIndex + recommendedLength;
//        if (endIndex > text.Length)
//        {
//            endIndex = text.Length;
//        }

//        // Look for a natural breakage point like a paragraph or just before a new heading
//        while (endIndex < text.Length && !char.IsWhiteSpace(text[endIndex]))
//        {
//            endIndex++;
//        }

//        // Get the chunk of text
//        string chunk = text.Substring(startIndex, endIndex - startIndex);

//        // Strip the whitespace at the start and end of the string
//        chunk = chunk.Trim();

//        // Add the chunk to the list
//        chunks.Add(chunk);

//        // Move to the next chunk
//        startIndex = endIndex;
//    }

//    return chunks;
//}

//async Task QLincolnSpeach(IKernel kernel)
//{
//    // Get the list of chunks from the file
//    List<string> chunks = ChunkTextFile("./lincoln.txt", 140);

//    const string lincolnMemoryCollectionName = "Abe's Words";

//    // Add the chunks to memory
//    int counter = 0;
//    foreach (string chunk in chunks)
//    {
//        Console.WriteLine($"Chunk {counter}: {chunk}");

//        await kernel.Memory.SaveInformationAsync(lincolnMemoryCollectionName, id: $"Chunk {counter++}",
//            text: chunk);
//    }

//    var aCounter = 0;
//    var myPrompt = "What should the people do?";
//    var myMemory = "";
//    var memories = kernel.Memory.SearchAsync(lincolnMemoryCollectionName, myPrompt, limit: 5, minRelevanceScore: 0.77);

//    await foreach (MemoryQueryResult memory in memories)
//    {
//        Console.WriteLine($"Result {++aCounter}:\n  >> {memory.Metadata.Id}\n  Text: {memory.Metadata.Text}  Relevance: {memory.Relevance}\n");
//        myMemory += memory.Metadata.Text + " ";
//    }

//    Console.WriteLine("Memory to feed back into the prompt will be:\n  >> " + myMemory + "\n");
//    var myLincolnFunction = kernel.CreateSemanticFunction(@"
//Lincoln said:
//---
//{{$input}}
//---
//So what should the people do?
//", maxTokens: 100, temperature: 0.1, topP: .1);

//    var lincolnResult = await myLincolnFunction.InvokeAsync(myMemory);

//    Console.WriteLine("Generated response ... 'according to Lincoln':\n" + lincolnResult);
//}
