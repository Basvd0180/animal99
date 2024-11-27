using System.Net.Http.Json;
using System.Text.Json;

var client = new HttpClient();

while (true)
{
    Console.WriteLine("Your Prompt: ");
    var userPrompt = Console.ReadLine();
    var message = new OllamaRequest()
    {
        model = "phi3:mini",
        prompt = userPrompt,
        stream = false
    };
    Console.WriteLine("AI Response: ");
    var aiResponse = await client.PostAsJsonAsync(" ", message);
    var content = await aiResponse.Content.ReadAsStringAsync();
    var parsedResponse = JsonSerializer.Deserialize<OllamaResponse>(content);
    Console.WriteLine(parsedResponse.response);
    Console.WriteLine();
}

class OllamaRequest
{
    public string model { get; set; }
    public string prompt { get; set; }
    public bool stream { get; set; }
}

class OllamaResponse
{
    public string model { get; set; }
    public string created_at { get; set; }
    public string response { get; set; }
}