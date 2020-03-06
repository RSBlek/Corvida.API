using Corvida.API.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Corvida.API.GaussianBlur
{
    public class GaussianBlurClient : ApiClient
    {
        public GaussianBlurClient(String apiKey) : base(apiKey) { }
        public GaussianBlurClient(Guid apiKey) : base(apiKey) { }

        public async Task<Image> GaussianBlurRequest(Uri imageUrl, int horizontalBlur, int verticalBlur)
        {
            GaussianBlurRequest request = new GaussianBlurRequest(imageUrl, horizontalBlur, verticalBlur);
            return await GaussianBlurRequest(request);
        }

        public async Task<Image> GaussianBlurRequest(Image image, int horizontalBlur, int verticalBlur)
        {
            GaussianBlurRequest request = new GaussianBlurRequest(ImageToBase64(image), horizontalBlur, verticalBlur);
            return await GaussianBlurRequest(request);
        }

        private async Task<Image> GaussianBlurRequest(GaussianBlurRequest request)
        {
            if (request.Horizontal < 0 || request.Vertical < 0 || request.Horizontal > 250 || request.Vertical > 250)
                throw new ArgumentException("Horizontal and vertical blur values have to be between 0 and 250");

            HttpClient httpClient = HttpClientLazy.Value;

            String json = JsonSerializer.Serialize(request);
            StringContent jsonContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Post, this.Endpoint + "/gaussianblur");
            httpRequest.Content = jsonContent;
            httpRequest.Headers.Add("Authorization", "ApiKey " + ApiKey.ToString());

            HttpResponseMessage response = await httpClient.SendAsync(httpRequest);
            await CheckSuccess(response);

            byte[] responseBytes = await response.Content.ReadAsByteArrayAsync();
            MemoryStream memoryStream = new MemoryStream(responseBytes);
            return Image.FromStream(memoryStream);
        }

    }
}
