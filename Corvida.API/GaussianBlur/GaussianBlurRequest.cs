using Corvida.API.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Corvida.API.GaussianBlur
{
    public class GaussianBlurRequest : ImageRequest
    {
        public int Horizontal { get; }
        public int Vertical { get; }

        public GaussianBlurRequest(Uri imageUrl, int horizontalBlur, int verticalBlur) : base(imageUrl)
        {
            this.Horizontal = horizontalBlur;
            this.Vertical = verticalBlur;
        }

        public GaussianBlurRequest(String image, int horizontalBlur, int verticalBlur) : base(image)
        {
            this.Horizontal = horizontalBlur;
            this.Vertical = verticalBlur;
        }
    }
}
