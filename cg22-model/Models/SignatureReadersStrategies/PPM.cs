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
        public FloatPixel[,] GetFloatImage(BinaryReader binReader)
        {
            int width = 0;
            int height = 0;
            int maxVal = 0;
            var sb = new StringBuilder();

            // Read width
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

            // Read height
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

            // Read maxVal
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

            FloatPixel[,] image = new FloatPixel[width, height];

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

                    image[x, y] = new FloatPixel(r, g, b);
                }
            }

            return image;
        }

        public void SaveAs(BinaryWriter binWriter, FloatPixel[,] image)
        {
            int intWidth = image.GetUpperBound(0) + 1;
            int intHeight = image.GetUpperBound(1) + 1;
            char[] width = Convert.ToString(intWidth).ToCharArray();
            char[] height = Convert.ToString(intHeight).ToCharArray();
            char[] maxVal = new char[] { '2', '5', '5' };

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
            for (int y = 0; y < intHeight; y++)
            {
                for (int x = 0; x < intWidth; x++)
                {
                    var color = image[x, y];
                    binWriter.Write(Convert.ToByte(Convert.ToInt32(Math.Round(color.Component1))));
                    binWriter.Write(Convert.ToByte(Convert.ToInt32(Math.Round(color.Component2))));
                    binWriter.Write(Convert.ToByte(Convert.ToInt32(Math.Round(color.Component3))));
                }
            }
        }
    }
}