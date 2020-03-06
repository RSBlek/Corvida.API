using System;
using System.Collections.Generic;
using System.Text;

namespace Corvida.API.Common
{
    public abstract class ImageRequest
    {
        public String Image { get; }
        public Uri ImageUrl { get; }
        protected ImageRequest(Uri imageUrl)
        {
            this.ImageUrl = ImageUrl;
        }

        protected ImageRequest(String image)
        {
            this.Image = image;
        }

    }
}
