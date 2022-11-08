using System;
using System.Drawing;
using System.IO;

namespace cg22_model.Models.SignatureReadersStrategies
{
    /// <summary>
    /// Special class for unsupported formats
    /// </summary>
    internal class FormatDoesntSupported : IFormat
    {
        /// <summary>
        /// Always throws exception
        /// </summary>
        /// <param name="binReader"> BinaryReader of picture file </param>
        /// <returns> Always NotSupportedException </returns>
        /// <exception cref="NotSupportedException"></exception>
        public FloatPixel[,] GetFloatImage(BinaryReader binReader)
        {
            throw new NotSupportedException("Format does not supports!");
        }

        public void SaveAs(BinaryWriter binWriter, FloatPixel[,] image)
        {
            throw new NotSupportedException("Format does not supports!");
        }
    }
}