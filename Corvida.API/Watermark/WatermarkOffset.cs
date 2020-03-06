using System;
using System.Collections.Generic;
using System.Text;

namespace Corvida.API.Watermark
{
    public class WatermarkOffset
    {
        public int Vertical { get; }
        public int Horizontal { get; }
        public OffsetType Type { get; }

        public WatermarkOffset(OffsetType offsetType, int verticalOffset, int horizontalOffset)
        {
            if (offsetType == OffsetType.Percent)
            {
                if (!(verticalOffset <= 100 && verticalOffset >= -100) || !(horizontalOffset <= 100 && horizontalOffset >= -100))
                    throw new ArgumentException("For OffsetType Percent the offset values have to be between -100 and +100");
            }
            this.Type = offsetType;
            this.Vertical = verticalOffset;
            this.Horizontal = horizontalOffset;
        }
    }
}
