using Corvida.API.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Corvida.API.Canny
{
    public class CannyClient : ApiClient
    {
        public CannyClient(String apiKey) : base(apiKey) { }
        public CannyClient(Guid apiKey) : base(apiKey) { }

        public async Task<Image> CannyRequest(Image image)
        {
            return await CannyRequest(image, null, null, null, null);
        }

        public async Task<Image> CannyRequest(Image image, double threshold1, double threshold2)
        {
            return await CannyRequest(image, threshold1, threshold2, null, null);
        }

        public async Task<Image> CannyRequest(Image image, double threshold1, double threshold2, int apertureSize, bool l2Gradient)
        {
            return await CannyRequest(image, threshold1, threshold2, apertureSize, l2Gradient);
        }

        public async Task<Image> CannyRequest(Uri imageUrl)
        {
            return await CannyRequest(imageUrl, null, null, null, null);
        }

        public async Task<Image> CannyRequest(Uri imageUrl, double threshold1, double threshold2)
        {
            return await CannyRequest(imageUrl, threshold1, threshold2, null, null);
        }

        public async Task<Image> CannyRequest(Uri imageUrl, double threshold1, double threshold2, int apertureSize, bool l2Gradient)
        {
            return await CannyRequest(imageUrl, threshold1, threshold2, apertureSize, l2Gradient);
        }

        private async Task<Image> CannyRequest(Image image, double? threshold1 = null, double? threshold2 = null, int? apertureSize = null, bool? l2Gradient = null)
        {
            CannyRequest request = new CannyRequest(ImageToBase64(image), threshold1, threshold2, apertureSize, l2Gradient);
            return await CannyRequest(request);
        }

        private async Task<Image> CannyRequest(Uri imageUrl, double? threshold1 = null, double? threshold2 = null, int? apertureSize = null, bool? l2Gradient = null)
        {
            CannyRequest request = new CannyRequest(imageUrl, threshold1, threshold2, apertureSize, l2Gradient);
            return await CannyRequest(request);
        }

        private async Task<Image> CannyRequest(CannyRequest request)
        {
            if (request.Threshold1.HasValue && request.Threshold1.Value <= 0 || request.Threshold2.HasValue && request.Threshold2.Value <= 0)
                throw new ArgumentException("Threshold has to be greater than 0");
            if (request.ApertureSize.HasValue && request.ApertureSize.Value <= 0)
                throw new ArgumentException("ApertureSize has to be greater than 0");
            HttpClient httpClient = HttpClientLazy.Value;

            String json = JsonSerializer.Serialize(request);
            StringContent jsonContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Post, this.Endpoint + "/canny");
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
