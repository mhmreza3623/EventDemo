using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace SharedKernel.Common.HttpClient;

public class HttpClientHelper
{
    private const string ContentType = "application/json";

    public async Task<TResult?> SendRequestAsJson<TRequest, TResult>(string baseUrl, string apiAddress, TRequest? requestModel, HttpMethod httpMethod)
    {
        using (var client = new System.Net.Http.HttpClient())
        {
            client.BaseAddress = new Uri(baseUrl);
            var request = new HttpRequestMessage(httpMethod, apiAddress);
            if (requestModel != null)
            {
                var requestValue = JsonConvert.SerializeObject(requestModel);
                request.Content = new StringContent(requestValue, Encoding.UTF8, ContentType);
            }

            var response = await client.SendAsync(request);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ContentType));

            var result = JsonConvert.DeserializeObject<TResult>(response.Content.ReadAsStringAsync().Result);

            return result;
        }
    }
}
