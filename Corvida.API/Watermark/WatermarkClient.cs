using Corvida.API.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Corvida.API.Watermark
{
    public class WatermarkClient : ApiClient
    {
        public WatermarkClient(String apiKey) : base(apiKey) { }
        public WatermarkClient(Guid apiKey) : base(apiKey) { }

        public async Task<Image> WatermarkRequest(Image image, Image watermark, int opacity, WatermarkAlignment alignment = null, WatermarkOffset offset = null, WatermarkSize size = null)
        {
            WatermarkRequestFiles files = new WatermarkRequestFiles(ImageToBase64(image), ImageToBase64(watermark));
            return await WatermarkRequest(files, opacity, alignment, offset, size);
        }

        private async Task<Image> WatermarkRequest(WatermarkRequestFiles files, int opacity, WatermarkAlignment alignment = null, WatermarkOffset offset = null, WatermarkSize size = null)
        {
            if (!(opacity >= 0 && opacity <= 100))
                throw new ArgumentException("Opacity is a percentage value and has to be between 0 and 100");

            WatermarkRequest watermarkRequest = new WatermarkRequest(files, opacity, alignment, offset, size);
            HttpClient httpClient = HttpClientLazy.Value;


            String json = JsonSerializer.Serialize(watermarkRequest);
            StringContent jsonContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Post, this.Endpoint + "/watermark");
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
