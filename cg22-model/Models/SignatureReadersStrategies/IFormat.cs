using System.Drawing;
using System.IO;

namespace cg22_model.Models.SignatureReadersStrategies
{
    /// <summary>
    /// Represents interface for strategies of reading pictures. Supposed, that first two bytes was read
    /// </summary>
    internal interface IFormat
    {
        FloatPixel[,] GetFloatImage(BinaryReader binReader);

        void SaveAs(BinaryWriter binWriter, FloatPixel[,] image);
    }
}