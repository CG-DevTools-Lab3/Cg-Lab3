﻿namespace cg22_model.Models.ColorSpacesSpaces
{
    /// <summary>
        /// component1 represents H: Hue [0; 360]
        /// component2 represents S: Saturation [0; 1]
        /// component3 represents L: Lightness [0; 1]
        /// </summary>
    public class HSL : IColorSpace
    {
        /// <summary>
        /// Convert one pixel represented with FloatPixel class from HSL to RGB format
        /// </summary>
        /// <param name="pixel">pixel that you need to conver 
        /// represented with FloatPixel array</param>
        /// <returns>Converted pixel represented with FloatPixel class</returns>
        public static FloatPixel ToRGBSinglePixel(FloatPixel pixel)
        {
            var result = new FloatPixel();

            var H = pixel.Component1;
            var S = pixel.Component2;
            var L = pixel.Component3;

            var C = (1 - System.Math.Abs(2f * L - 1f)) * S;
            var X = C * (1 - System.Math.Abs(((H / 60) % 2) - 1));
            var m = L - (C / 2f);
            var RGBValues = new FloatPixel[] { new FloatPixel(C, X, 0f), new FloatPixel(X, C, 0f),
                new FloatPixel(0f, C, X), new FloatPixel(0f, X, C),
                new FloatPixel(X, 0f, C), new FloatPixel(C, 0f, X)
            };
            
            if (0 <= H && H < 60)
            {
                result = RGBValues[0];
            }

            if (60 <= H && H < 120)
            {
                result = RGBValues[1];
            }

            if (120 <= H && H < 180)
            {
                result = RGBValues[2];
            }

            if (180 <= H && H < 240)
            {
                result = RGBValues[3];
            }

            if (240 <= H && H < 300)
            {
                result = RGBValues[4];
            }

            if (300 <= H && H < 360)
            {
                result = RGBValues[5];
            }

            result = new FloatPixel(
                (result.Component1 + m) * 255f,
                (result.Component2 + m) * 255f,
                (result.Component3 + m) * 255f);

            return result;
        }
        /// <summary>
        /// Convert image represented with FloatPixel class from HSL to RGB format
        /// </summary>
        /// <param name="image">image that you need to conver 
        /// represented with FloatPixel matrix</param>
        /// <returns>Converted image represented with FloatPixel class matrix</returns>
        public FloatPixel[,] ToRGB(FloatPixel[,] image)
        {
            var width = image.GetUpperBound(0) + 1;
            var height = image.GetUpperBound(1) + 1;
            var result = new FloatPixel[width, height];

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    var pixel = image[x, y];
                    result[x, y] = ToRGBSinglePixel(pixel);
                }
            }

            return result;
        }
        /// <summary>
        /// Covert pixel from RGB to HSL
        /// </summary>
        /// <param name="pixel">pixel that you need to convert</param>
        /// <returns>converted pixel</returns>
        public static FloatPixel FromRGBSinglePixel(FloatPixel pixel)
        {
            var result = new FloatPixel();

            var R = pixel.Component1;
            var G = pixel.Component2;
            var B = pixel.Component3;


            var _R = (R / 255f);
            var _G = (G / 255f);
            var _B = (B / 255f);

            var _Min = System.Math.Min(System.Math.Min(_R, _G), _B);
            var _Max = System.Math.Max(System.Math.Max(_R, _G), _B);
            var _Delta = _Max - _Min;

            var H = 0f;
            var S = 0f;
            var L = (float)((_Max + _Min) / 2.0f);

            if (_Delta != 0)
            {
                if (L < 0.5f)
                {
                    S = (float)(_Delta / (_Max + _Min));
                }
                else
                {
                    S = (float)(_Delta / (2.0f - _Max - _Min));
                }


                if (_R == _Max)
                {
                    H = (_G - _B) / _Delta;
                }
                else if (_G == _Max)
                {
                    H = 2f + (_B - _R) / _Delta;
                }
                else if (_B == _Max)
                {
                    H = 4f + (_R - _G) / _Delta;
                }
            }

            result.Component1 = H < 0 ? H * 60f + 360f : H * 60f;
            result.Component2 = S;
            result.Component3 = L;
            
            return result;
        }
        /// <summary>
        /// Covert image from RGB to HSL format
        /// </summary>
        /// <param name="image">image that you need to convert</param>
        /// <returns>Converted image</returns>
        public FloatPixel[,] FromRGB(FloatPixel[,] image)
        {
            var width = image.GetUpperBound(0) + 1;
            var height = image.GetUpperBound(1) + 1;
            var result = new FloatPixel[width, height];

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    var pixel = image[x, y];
                    result[x, y] = FromRGBSinglePixel(pixel);
                }
            }

            return result;
        }

        /// <summary>
        /// The image generated by ToRGB() is already scaled to [0; 256] range
        /// </summary>
        public FloatPixel[,] ScaleFrom256(FloatPixel[,] image)
        {
            var width = image.GetUpperBound(0) + 1;
            var height = image.GetUpperBound(1) + 1;
            var result = new FloatPixel[width, height];

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    var pixel = new FloatPixel(
                        image[x, y].Component1,
                        image[x, y].Component2,
                        image[x, y].Component3);

                    pixel.Component1 /= (255f / 360f);
                    pixel.Component2 /= 255f;
                    pixel.Component3 /= 255f;
                    if (pixel.Component1 < 0 || pixel.Component2 < 0 || pixel.Component3 < 0)
                    {
                        throw new System.Exception("Negative component found");
                    }

                    result[x, y] = pixel;
                }
            }

            return result;
        }
        /// <summary>
        /// Scale image to it's limits
        /// </summary>
        /// <param name="image">image you need to Scale</param>
        /// <returns>Scaled image</returns>
        public FloatPixel[,] ScaleTo256(FloatPixel[,] image)
        {
            var width = image.GetUpperBound(0) + 1;
            var height = image.GetUpperBound(1) + 1;
            var result = new FloatPixel[width, height];

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {

                    var pixel = new FloatPixel(
                        image[x, y].Component1,
                        image[x, y].Component2,
                        image[x, y].Component3);

                    pixel.Component1 *= (255f / 360f);
                    pixel.Component2 *= 255f;
                    pixel.Component3 *= 255f;
                    if (pixel.Component1 < 0 || pixel.Component2 < 0 || pixel.Component3 < 0)
                    {
                        throw new System.Exception("Negative component found");
                    }

                    result[x, y] = pixel;
                }
            }

            return result;
        }

        /// <summary>
        /// Checks if the image array is in given ranges:
        /// H: Hue [0; 360]
        /// S: [0; 1]
        /// V: [0; 1]
        /// </summary>
        /// <param name="image">image you need to check</param>
        /// <returns>True if all ok</returns>
        public bool Check(FloatPixel[,] image)
        {
            var width = image.GetUpperBound(0) + 1;
            var height = image.GetUpperBound(1) + 1;
            var result = new FloatPixel[width, height];

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    var H = image[x, y].Component1;
                    var S = image[x, y].Component2;
                    var L = image[x, y].Component3;

                    if (!(0f <= H && H <= 360))
                    {
                        return false;
                    }
                    if (!(0f <= S && S <= 1f))
                    {
                        return false;
                    }
                    if (!(0f <= L && L <= 1f))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        /// <summary>
        /// Get components names
        /// </summary>
        /// <returns>components names</returns>
        public string[] GetComponentsNames()
        {
            return new string[] { "Hue", "Saturation", "Lightness" };
        }
    }
}