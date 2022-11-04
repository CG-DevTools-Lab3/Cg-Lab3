using System;
using System.Drawing;
using System.Windows.Markup;
using cg22_model.Models.ColorSpacesSpaces;

namespace cg22_model.Models
{
    /// <summary>
    /// Represents image
    /// </summary>
    public class FloatImage
    {
        private string _fileMagicNumber;
        private IColorSpace _colorSpace;
        private FloatPixel[,] _image;
        private int _width;
        private int _height;

        public const int ColorComponentsCount = 3;

        public FloatImage(string fileMagicNumber, IColorSpace colorSpace, FloatPixel[,] image)
        {
            _fileMagicNumber = fileMagicNumber;
            _colorSpace = colorSpace;
            _image = image;
            _width = _image.GetUpperBound(0) + 1;
            _height = _image.GetUpperBound(1) + 1;
        }

        public FloatImage(string fileMagicNumber, IColorSpace colorSpace, int width, int height)
        {
            _fileMagicNumber = fileMagicNumber;
            _colorSpace = colorSpace;
            _image = new FloatPixel[width, height];
            _width = width;
            _height = height;
        }


        public string FileMagicNumber
        {
            get => _fileMagicNumber;
        }

        public IColorSpace ColorSpace
        {
            get => _colorSpace;
        }

        public FloatPixel[,] Image
        {
            get
            {
                var newImage = new FloatPixel[_width, _height];
                for (var y = 0; y < _height; y++)
                {
                    for (var x = 0; x < _width; x++)
                    {
                        var pixel = _image[x, y];
                        newImage[x, y] = new FloatPixel(pixel.Component1, pixel.Component2, pixel.Component3);
                    }
                }
                return newImage;
            }
        }

        public int Width
        {
            get => _width;
        }

        public int Height
        {
            get => _height;
        }
        public Bitmap GetBitmap()
        {
            var _floatBitmap = _colorSpace.ToRGB(_image);
            _floatBitmap = new RGB().ToRGB(_floatBitmap);

            var bitmap = new Bitmap(_width, _height);

            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    byte r = Convert.ToByte(Convert.ToInt32(Math.Round(_floatBitmap[x, y].Component1)));
                    byte g = Convert.ToByte(Convert.ToInt32(Math.Round(_floatBitmap[x, y].Component2)));
                    byte b = Convert.ToByte(Convert.ToInt32(Math.Round(_floatBitmap[x, y].Component3)));
                    bitmap.SetPixel(x, y, Color.FromArgb(255, r, g, b));
                }
            }

            return bitmap;
        }

        public FloatPixel GetPixel(int x, int y)
        {
            return _image[x, y];
        }

        public void SetPixel(int x, int y, FloatPixel value)
        {
            if (_width <= x | x < 0)
            {
                throw new IndexOutOfRangeException("x is out of bounds");
            }

            if (_height <= y | y < 0)
            {
                throw new IndexOutOfRangeException("y is out of bounds");
            }

            _image[x, y] = value;
        }

        public bool ToRGB()
        {
        }

        public bool ToHSL()
        {
        }

        public bool ToHSV()
        {
        }

        public bool ToYCbCr601()
        {
        }

        public bool ToYCbCr709()
        {
        }

        public bool ToYCoCg()
        {
        }

        public bool ToCMY()
        {
        }

        public FloatImage GetFloatImageComponent1()
        {
        }

        public FloatImage GetFloatImageComponent2()
        {
        }

        public FloatImage GetFloatImageComponent3()
        {
        }
    }
}