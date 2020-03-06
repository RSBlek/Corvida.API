using System;
using System.Collections.Generic;
using System.Text;

namespace Corvida.API.Watermark
{
    /// <summary>
    /// Type of the given offset values. Pixel will use an absolute offset measured in pixels. Percent will calculate the relative offset in relation to the entire image.
    /// </summary>
    public enum OffsetType
    {
        /// <summary>
        /// Absolute offset in pixels
        /// </summary>
        Pixel = 0,
        /// <summary>
        /// Relative offset in relation to the entire image. HorizontalAlignment and VerticalAlignment values have to be between -100 and +100 if the OffsetType is Percent.
        /// </summary>
        Percent = 1
    }
}
