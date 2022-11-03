using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Serialization;

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
        public Bitmap OpenFile(string path)
        {
            var fStream = new FileStream(path, FileMode.Open);
            var binReader = new BinaryReader(fStream);
            var bitmap = new Bitmap(1, 1);
            try
            {
                char magic = binReader.ReadChar();
                char number = binReader.ReadChar();
                string magicNumber = new string(new char[] {magic, number});
                bitmap.Dispose();
                bitmap = SignatureChecker.CheckSignature(magicNumber).GetBitmap(binReader);
                var prop = (PropertyItem)FormatterServices.GetUninitializedObject(typeof(PropertyItem));
                prop.Id = 4096;
                prop.Len = 2;
                prop.Type = 2;
                prop.Value = new byte[] {(byte)magicNumber[0], (byte)magicNumber[1]};
                bitmap.SetPropertyItem(prop);
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
            return bitmap;
        }

        public void SaveAs(string filename, string magicNumber, Bitmap bitmap)
        {
            BinaryWriter binWriter = new BinaryWriter(File.Create(filename));
            try
            {
                SignatureChecker.CheckSignature(magicNumber).SaveAs(binWriter, bitmap);
            }
            finally
            {
                binWriter.Dispose();
            }
        }
    }
}
