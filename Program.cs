using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    private static readonly HttpClient client = new HttpClient();

    static async Task Main(string[] args)
    {
        
        string token = "NTE4NDYxMTA4NDcwNjc3NTA3.GmQBRh.M9V5FyUXSsQ_wmWfDi0LE3RrPPx_2IaGRoAuhg";
        string channelId = "876126506240335902"; 
        string messageId = "1244968799501946920"; 
        string emoji = "%F0%9F%91%8D"; 
        try
        {
            await AddReactionAsync(token, channelId, messageId, emoji);
            Console.WriteLine("Reaction added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    private static async Task AddReactionAsync(string token, string channelId, string messageId, string emoji)
    {
        string url = $"https://discord.com/api/v9/channels/{channelId}/messages/{messageId}/reactions/{emoji}/@me";

        using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, url))
        {
            request.Headers.Add("Authorization", token);
            request.Headers.Add("User-Agent", "DiscordBot (your_bot_email@example.com, v1)");

            HttpResponseMessage response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();
        }
    }
}
