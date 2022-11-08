﻿namespace cg22_model.Models.ColorSpacesSpaces
{
    /// <summary>
    /// component1 represents H: Hue [0; 360]
    /// component2 represents S: Saturation [0; 1]
    /// component3 represents V: Value [0; 1]
    /// </summary>
    public class HSV : IColorSpace
    {
        /// <summary>
        /// convert one pixel from HSV to RGB
        /// </summary>
        /// <param name="pixel">pixel you need to convert</param>
        /// <returns>converted pixel</returns>

        public static FloatPixel ToRGBSinglePixel(FloatPixel pixel)
        {
            var result = new FloatPixel();

            var H = pixel.Component1;
            var _S = pixel.Component2 * 100f;
            var _V = pixel.Component3 * 100f;

            var Hi = (int)System.Math.Floor(H / 60f) % 6;
            var Vmin = (100 - _S) * _V / 100f;

            var a = (_V - Vmin) * ((int)System.Math.Floor(H) % 60) / 60f;
            var Vinc = Vmin + a;
            var Vdec = _V - a;

            float[] RGBPixel;
            switch (Hi)
            {
                case 0:
                    RGBPixel = new float[] { _V, Vinc, Vmin };
                    break;

                case 1:
                    RGBPixel = new float[] { Vdec, _V, Vmin };
                    break;

                case 2:
                    RGBPixel = new float[] { Vmin, _V, Vinc };
                    break;

                case 3:
                    RGBPixel = new float[] { Vmin, Vdec, _V };
                    break;

                case 4:
                    RGBPixel = new float[] { Vinc, Vmin, _V };
                    break;

                case 5:
                    RGBPixel = new float[] { _V, Vmin, Vdec };
                    break;

                default:
                    RGBPixel = new float[] { 0, 0, 0 };
                    break;
            }

            RGBPixel[0] *= (255f / 100f);
            RGBPixel[1] *= (255f / 100f);
            RGBPixel[2] *= (255f / 100f);

            result.Component1 = RGBPixel[0];
            result.Component2 = RGBPixel[1];
            result.Component3 = RGBPixel[2];

            return result;
        }
        /// <summary>
        /// Convert image from HSV to RGB format
        /// </summary>
        /// <param name="image">image you need to convert</param>
        /// <returns>Converted image</returns>
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
        /// Convert one pixel from RGB to HSV format
        /// </summary>
        /// <param name="pixel">pixel you need to convert</param>
        /// <returns>Converted pixel</returns>
        public static FloatPixel FromRGBSinglePixel(FloatPixel pixel)
        {
            var result = new FloatPixel();
            var _R = pixel.Component1 / 255f;
            var _G = pixel.Component2 / 255f;
            var _B = pixel.Component3 / 255f;

            var _Min = System.Math.Min(System.Math.Min(_R, _G), _B);
            var _Max = System.Math.Max(System.Math.Max(_R, _G), _B);
            var _Delta = _Max - _Min;

            var H = 0f;
            var S = 0f;
            var V = _Max;

            if (_Delta != 0)
            {
                if (_Max == 0)
                {
                    S = 0;
                }
                else
                {
                    S = 1 - _Min / _Max;
                }

                if (_Max == _R)
                {
                    if (_G >= _B)
                    {
                        H = 60f * (_G - _B) / _Delta;
                    }
                    else
                    {
                        H = 60f * (_G - _B) / _Delta + 360f;
                    }
                }

                if (_Max == _G)
                {
                    H = 60f * (_B - _R) / _Delta + 120f;
                }

                if (_Max == _B)
                {
                    H = 60f * (_R - _G) / _Delta + 240f;
                }
            }

            result.Component1 = H;
            result.Component2 = S;
            result.Component3 = V;

            return result;
        }
        /// <summary>
        /// Convert image from RGB to HSV format
        /// </summary>
        /// <param name="image">image you need to convert</param>
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
        /// <param name="image">image you need to scale</param>
        /// <returns>Scaled image</returns>
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
        /// <param name="image">image you need to scale</param>
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
        /// Checks that image in it's limits
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
                    var V = image[x, y].Component3;

                    if (!(0f <= H && H <= 360))
                    {
                        return false;
                    }
                    if (!(0f <= S && S <= 1f))
                    {
                        return false;
                    }
                    if (!(0f <= V && V <= 1f))
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
        /// <returns>String array with components names</returns>
        public string[] GetComponentsNames()
        {
            return new string[] { "Hue", "Saturation", "Value" };
        }
    }
}