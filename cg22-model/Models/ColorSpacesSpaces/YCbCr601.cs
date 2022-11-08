namespace cg22_model.Models.ColorSpacesSpaces
{
    public class YCbCr601 : IColorSpace
    {
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
                    var Y = pixel.Component1;
                    var Cb = pixel.Component2;
                    var Cr = pixel.Component3;
                    var R = (255f / 219f) * (Y - 16f) + (255f / 224f) * 1.402f * (Cr - 128f);
                    var G = (255f / 219f) * (Y - 16f) - (255f / 224f) * 1.772f * (0.114f / 0.587f) * (Cb - 128f) - (255f / 224f) * 1.402f * (0.299f / 0.587f) * (Cr - 128f);
                    var B = (255f / 219f) * (Y - 16f) + (255f / 224f) * 1.772f * (Cb - 128f);
                    result[x, y] = new FloatPixel(R, G, B);
                }
            }
            return result;
        }

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
                    var R = pixel.Component1 / 255f;
                    var G = pixel.Component2 / 255f;
                    var B = pixel.Component3 / 255f;
                    var Y = 16f + (65.481f * R + 128.553f * G + 24.966f * B);
                    var Cb = 128f + (-37.797f * R - 74.203f * G + 112.0f * B);
                    var Cr = 128f + (112.0f * R - 93.786f * G - 18.214f * B);
                    result[x, y] = new FloatPixel(Y, Cb, Cr);
                }
            }
            return result;
        }

        public FloatPixel[,] ScaleFrom256(FloatPixel[,] image)
        {
            var width = image.GetUpperBound(0) + 1;
            var height = image.GetUpperBound(1) + 1;
            var result = new FloatPixel[width, height];
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    var pixel = image[x, y];
                    var Y = (pixel.Component1 - 16f) / 219f * 255f;
                    var Cb = (pixel.Component2 - 16f) / 224f * 255f;
                    var Cr = (pixel.Component3 - 16f) / 224f * 255f;
                    result[x, y] = new FloatPixel(Y, Cb, Cr);
                }
            }
            return result;
        }

        public FloatPixel[,] ScaleTo256(FloatPixel[,] image)
        {
            var width = image.GetUpperBound(0) + 1;
            var height = image.GetUpperBound(1) + 1;
            var result = new FloatPixel[width, height];
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    var pixel = image[x, y];
                    var Y = pixel.Component1 / 255f * 219f + 16f;
                    var Cb = pixel.Component2 / 255f * 224f + 16f;
                    var Cr = pixel.Component3 / 255f * 224f + 16f;
                    result[x, y] = new FloatPixel(Y, Cb, Cr);
                }
            }
            return result;
        }

        public bool Check(FloatPixel[,] image)
        {
            var width = image.GetUpperBound(0) + 1;
            var height = image.GetUpperBound(1) + 1;
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    var pixel = image[x, y];
                    var Y = pixel.Component1;
                    var Cb = pixel.Component2;
                    var Cr = pixel.Component3;
                    if (Y < 16f || Y > 235f)
                    {
                        return false;
                    }
                    if (Cb < 16f || Cb > 240f)
                    {
                        return false;
                    }
                    if (Cr < 16f || Cr > 240f)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public string[] GetComponentsNames()
        {
            return new string[]
            {
                "Luma",
                "BLue",
                "Red"
            };
        }
    }
}