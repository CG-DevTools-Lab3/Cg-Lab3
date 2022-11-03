using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace cg22_model.Models.SignatureReadersStrategies
{
    /// <summary>
    /// Strategy for reading .ppm files
    /// </summary>
    internal class PPM : IFormat
    {
        /// <summary>
        /// Reads .ppm file and return its Bitmap representation
        /// </summary>
        /// <param name="binReader"> BinaryReader of picture file </param>
        /// <returns> Bitmap representation of picture </returns>
        public Bitmap GetBitmap(BinaryReader binReader)
        {
            int width = 0;
            int height = 0;
            int maxVal = 0;
            var sb = new StringBuilder();

            // Чтение ширины
            binReader.ReadByte();
            while (true)
            {
                char inp = binReader.ReadChar();
                if (!('0' <= inp & inp <= '9'))
                {
                    break;
                }
                sb.Append(inp);
            }

            if (sb.Length == 0 | Convert.ToInt32(sb.ToString()) == 0)
            {
                throw new ArgumentException("Invalid picture width!");
            }
            width = Convert.ToInt32(sb.ToString());

            sb.Clear();
            
            // Чтение высоты
            while (true)
            {
                char inp = binReader.ReadChar();
                if (!('0' <= inp & inp <= '9'))
                {
                    break;
                }
                sb.Append(inp);
            }

            if (sb.Length == 0 | Convert.ToInt32(sb.ToString()) == 0)
            {
                throw new ArgumentException("Invalid picture height!");
            }
            height = Convert.ToInt32(sb.ToString());

            sb.Clear();

            // Чтение maxVal
            while (true)
            {
                char inp = binReader.ReadChar();
                if (!('0' <= inp & inp <= '9'))
                {
                    break;
                }
                sb.Append(inp);
            }
            if (sb.Length == 0 | Convert.ToInt32(sb.ToString()) == 0 | Convert.ToInt32(sb.ToString()) >= 65536)
            {
                throw new ArgumentException("Invalid picture maxval!");
            }
            maxVal = Convert.ToInt32(sb.ToString());

            Bitmap bitmap = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    byte r = 0x00;
                    byte g = 0x00;
                    byte b = 0x00;

                    try
                    {
                        r = binReader.ReadByte();
                        g = binReader.ReadByte();
                        b = binReader.ReadByte();
                    }
                    catch (Exception e)
                    {
                        throw new EndOfStreamException("Битый файл");
                    }

                    if (r > maxVal | g > maxVal | b > maxVal)
                    {
                        throw new IndexOutOfRangeException("Color bigger than maxVal");
                    }

                    bitmap.SetPixel(x, y, Color.FromArgb(255, r, g, b));
                }
            }

            return bitmap;
        }

        public void SaveAs(BinaryWriter binWriter, Bitmap bitmap)
        {
            char[] width = Convert.ToString(bitmap.Width).ToCharArray();
            char[] height = Convert.ToString(bitmap.Height).ToCharArray();
            char[] maxVal = new char[] {'2', '5', '5'};

            binWriter.Write('P');
            binWriter.Write('6');

            binWriter.Write(' ');
            foreach (var ch in width)
            {
                binWriter.Write(ch);
            }

            binWriter.Write(' ');
            foreach (var ch in height)
            {
                binWriter.Write(ch);
            }

            binWriter.Write(' ');
            foreach (var ch in maxVal)
            {
                binWriter.Write(ch);
            }

            binWriter.Write(' ');
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    var color = bitmap.GetPixel(x, y);
                    binWriter.Write(color.R);
                    binWriter.Write(color.G);
                    binWriter.Write(color.B);
                }
            }
        }
    }
}