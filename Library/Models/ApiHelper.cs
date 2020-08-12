using System.Threading.Tasks;
using RestSharp;

namespace Library.Models
{
  class ApiHelper
  {
    public static async Task<string> ApiCall(string query, string type)
    {
      RestClient client = new RestClient("https://api.nytimes.com/svc/books/v3/");
      RestRequest request = new RestRequest($"reviews.json?{type}={query}&api-key={EnvironmentVariables.ApiKey}");
      var response = await client.ExecuteAsync(request);
      return response.Content;
    }
  }
}