using System;
using System.Collections.Generic;
using System.Text;

namespace Corvida.API.Watermark
{
    public class WatermarkSize
    {
        public int MaxWidth { get; }
        public int MaxHeight { get; }
        public SizeType Type { get; }

        public WatermarkSize(SizeType sizeType, int maxWidth, int maxHeight)
        {
            if (sizeType == SizeType.Percent)
            {
                if (!(maxWidth <= 100 && maxWidth >= 0) || !(maxHeight <= 100 && maxHeight >= 0))
                    throw new ArgumentException("For SizeType Percent the values have to be between 0 and 100");
            }
            this.Type = sizeType;
            this.MaxWidth = maxWidth;
            this.MaxHeight = maxHeight;
        }
    }
}
