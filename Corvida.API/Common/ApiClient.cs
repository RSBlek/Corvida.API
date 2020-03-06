using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Corvida.API.Common
{
    public abstract class ApiClient
    {
        protected Guid ApiKey { get; }
        protected Lazy<HttpClient> HttpClientLazy { get; } = new Lazy<HttpClient>();
        public Uri Endpoint { get; set; } = new Uri("https://corvida.eu/api");

        protected ApiClient(String apiKey)
        {
            if (!Guid.TryParse(apiKey, out Guid guidApiKey))
                throw new ArgumentException("Invalid API key. The Key must be a valid GUID");
            this.ApiKey = guidApiKey;
        }

        protected ApiClient(Guid apiKey)
        {
            this.ApiKey = apiKey;
        }

        protected string ImageToBase64(Image image)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, image.RawFormat);
                byte[] imageBytes = memoryStream.ToArray();
                return Convert.ToBase64String(imageBytes);
            }
        }

        protected async Task<bool> CheckSuccess(HttpResponseMessage response)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                String stringContent = await response.Content.ReadAsStringAsync();
                JsonSerializerOptions serializerOptions = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                };
                BadRequestResult badRequestResult = JsonSerializer.Deserialize<BadRequestResult>(stringContent, serializerOptions);
                throw new BadRequestException(badRequestResult.Code, badRequestResult.Description);
            }
            else if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Could not execute request");
            }

            return true;
        }

    }
}
