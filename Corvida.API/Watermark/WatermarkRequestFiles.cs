using System;
using System.Collections.Generic;
using System.Text;

namespace Corvida.API.Watermark
{
    public class WatermarkRequestFiles
    {
        public String Image { get; }
        public String Watermark { get; }
        public Uri ImageUrl { get; }
        public Uri WatermarkUrl { get; }

        public WatermarkRequestFiles(String imageBase64, String watermarkBase64)
        {
            this.Image = imageBase64;
            this.Watermark = watermarkBase64;
        }

        public WatermarkRequestFiles(Uri imageUrl, String watermarkBase64)
        {
            this.ImageUrl = imageUrl;
            this.Watermark = watermarkBase64;
        }

        public WatermarkRequestFiles(String imageBase64, Uri watermarkUrl)
        {
            this.Image = imageBase64;
            this.WatermarkUrl = watermarkUrl;
        }

        public WatermarkRequestFiles(Uri imageUrl, Uri watermarkUrl)
        {
            this.ImageUrl = imageUrl;
            this.WatermarkUrl = watermarkUrl;
        }
    }
}
