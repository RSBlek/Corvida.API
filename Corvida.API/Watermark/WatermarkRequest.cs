using System;
using System.Collections.Generic;
using System.Text;

namespace Corvida.API.Watermark
{
    public class WatermarkRequest
    {
        public WatermarkAlignment Alignment { get; }
        public WatermarkOffset Offset { get; }
        public WatermarkSize Size { get; }
        public Int32 Opacity { get; }
        public WatermarkRequestFiles Files { get; }

        public WatermarkRequest(WatermarkRequestFiles files, int opacity)
        {
            this.Files = files;
            this.Opacity = opacity;
        }

        public WatermarkRequest(WatermarkRequestFiles files, int opacity, WatermarkAlignment alignment)
        {
            this.Files = files;
            this.Opacity = opacity;
            this.Alignment = alignment;
        }

        public WatermarkRequest(WatermarkRequestFiles files, int opacity, WatermarkAlignment alignment, WatermarkOffset offset)
        {
            this.Files = files;
            this.Opacity = opacity;
            this.Alignment = alignment;
            this.Offset = offset;
        }

        public WatermarkRequest(WatermarkRequestFiles files, int opacity, WatermarkAlignment alignment, WatermarkOffset offset, WatermarkSize size)
        {
            this.Files = files;
            this.Opacity = opacity;
            this.Alignment = alignment;
            this.Offset = offset;
            this.Size = size;
        }

    }
}
