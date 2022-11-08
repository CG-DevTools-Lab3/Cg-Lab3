using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Serialization;
using cg22_model.Models.ColorSpacesSpaces;

namespace cg22_model.Models
{
    /// <summary>
    /// Incapsulates logic of interpreting picture in various formats
    /// </summary>
    public class FileReaderSaver
    {

        /// <summary>
        /// Returns bitmap representation of picture
        /// </summary>
        /// <param name="path"> Path to file </param>
        /// <returns> Bitmap representation of picture </returns>
        public FloatImage OpenFile(string path, IColorSpace colorSpace)
        {
            var fStream = new FileStream(path, FileMode.Open);
            var binReader = new BinaryReader(fStream);
            FloatImage floatImage = null;
            try
            {
                char magic = binReader.ReadChar();
                char number = binReader.ReadChar();
                string magicNumber = new string(new char[] { magic, number });
                var image = SignatureChecker.CheckSignature(magicNumber).GetFloatImage(binReader);
                image = colorSpace.ScaleFrom256(image);
                floatImage = new FloatImage(magicNumber, colorSpace, image);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                fStream.Dispose();
                binReader.Dispose();
            }

            return floatImage;
        }
        /// <summary>
        /// Save file
        /// </summary>
        /// <param name="filename">file path</param>
        /// <param name="magicNumber">file signature</param>
        /// <param name="bitmap">bitmap with pixels</param>
        public void SaveAs(string filename, FloatImage floatImage)
        {
            BinaryWriter binWriter = new BinaryWriter(File.Create(filename));

            try
            {
                SignatureChecker.CheckSignature(floatImage.FileMagicNumber).SaveAs(binWriter, floatImage.ColorSpace.ScaleTo256(floatImage.Image));
            }
            finally
            {
                binWriter.Dispose();
            }
        }
    }
}
