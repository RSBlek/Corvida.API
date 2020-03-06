using Corvida.API.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Corvida.API.Canny
{
    public class CannyRequest : ImageRequest
    {
        public double? Threshold1 { get; }
        public double? Threshold2 { get; }
        public int? ApertureSize { get; }
        public bool? L2Gradient { get; }

        public CannyRequest(String base64Image, double? threshold1 = null, double? threshold2 = null, int? apertureSize = null, bool? l2Gradient = null) : base(base64Image)
        {
            this.Threshold1 = threshold1;
            this.Threshold2 = threshold2;
            this.ApertureSize = apertureSize;
            this.L2Gradient = l2Gradient;
        }

        public CannyRequest(Uri imageUrl, double? threshold1 = null, double? threshold2 = null, int? apertureSize = null, bool? l2Gradient = null) : base(imageUrl)
        {
            this.Threshold1 = threshold1;
            this.Threshold2 = threshold2;
            this.ApertureSize = apertureSize;
            this.L2Gradient = l2Gradient;
        }
    }
}