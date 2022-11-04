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
            if (_colorSpace is RGB)
            {
                return true;
            }

            var tmp = _colorSpace.ToRGB(_image);
            _colorSpace = new RGB();
            _image = _colorSpace.FromRGB(tmp);
            return true;
        }

        //TODO: Check if try-catch needed
        public bool ToHSL()
        {
            if (_colorSpace is HSL)
            {
                return true;
            }

            try
            {
                var tmp = _colorSpace.ToRGB(_image);
                _image = new HSL().FromRGB(tmp);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            _colorSpace = new HSL();
            return true;
        }

        public bool ToHSV()
        {
            if (_colorSpace is HSV)
            {
                return true;
            }

            var tmp = _colorSpace.ToRGB(_image);
            _colorSpace = new HSV();
            _image = _colorSpace.FromRGB(tmp);
            return true;
        }

        public bool ToYCbCr601()
        {
            if (_colorSpace is YCbCr601)
            {
                return true;
            }

            var tmp = _colorSpace.ToRGB(_image);
            _colorSpace = new YCbCr601();
            _image = _colorSpace.FromRGB(tmp);
            return true;
        }

        public bool ToYCbCr709()
        {
            if (_colorSpace is YCbCr709)
            {
                return true;
            }

            var tmp = _colorSpace.ToRGB(_image);
            _colorSpace = new YCbCr709();
            _image = _colorSpace.FromRGB(tmp);
            return true;
        }

        public bool ToYCoCg()
        {
            if (_colorSpace is YCoCg)
            {
                return true;
            }
            var tmp = _colorSpace.ToRGB(_image);
            _colorSpace = new YCoCg();
            _image = _colorSpace.FromRGB(tmp);
            return true;
        }

        public bool ToCMY()
        {
            if (_colorSpace is CMY)
            {
                return true;
            }

            var tmp = _colorSpace.ToRGB(_image);
            _colorSpace = new CMY();
            _image = _colorSpace.FromRGB(tmp);
            return true;
        }

        public FloatImage GetFloatImageComponent1()
        {
            var scaledImage = _colorSpace.ScaleTo256(_image);
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    var pixel = scaledImage[x, y].Component1;
                    scaledImage[x, y] = new FloatPixel(pixel, pixel, pixel);
                }
            }

            return new FloatImage("P5", new RGB(), scaledImage);
        }

        public FloatImage GetFloatImageComponent2()
        {
            var scaledImage = _colorSpace.ScaleTo256(_image);
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    var pixel = scaledImage[x, y].Component2;
                    scaledImage[x, y] = new FloatPixel(pixel, pixel, pixel);
                }
            }

            return new FloatImage("P5", new RGB(), scaledImage);
        }

        public FloatImage GetFloatImageComponent3()
        {
            var scaledImage = _colorSpace.ScaleTo256(_image);
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    var pixel = scaledImage[x, y].Component3;
                    scaledImage[x, y] = new FloatPixel(pixel, pixel, pixel);
                }
            }

            return new FloatImage("P5", new RGB(), scaledImage);
        }
    }
}