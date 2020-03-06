using Corvida.API.Canny;
using Corvida.API.GaussianBlur;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace Corvida.API.Demo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            GaussianBlurClient cannyClient = new GaussianBlurClient("YourApiKeyHere");
            String outputPath = Directory.GetCurrentDirectory() + "/img/output.jpg";
            using (Image image = Image.FromFile("./img/demo.jpg"))
            using (Image output = await cannyClient.GaussianBlurRequest(image, 30, 30))
            {
                output.Save(outputPath);
                Console.WriteLine("Image saved to: " + outputPath);
            }
        }
    }
}
