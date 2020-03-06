using System;
using System.Collections.Generic;
using System.Text;

namespace Corvida.API.Watermark
{
    public class WatermarkAlignment
    {
        public HorizontalAlignment Horizontal { get; }
        public VerticalAlignment Vertical { get; }

        public WatermarkAlignment(HorizontalAlignment horizontalAlignment, VerticalAlignment verticalAlignment)
        {
            this.Horizontal = horizontalAlignment;
            this.Vertical = verticalAlignment;
        }
    }
}
