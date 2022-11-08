namespace cg22_model.Models.ColorSpacesSpaces
{
    public class YCbCr709 : IColorSpace
    {
        public static FloatPixel ToRGBSinglePixel(FloatPixel pixel)
        {
            var result = new FloatPixel();

            var Y = pixel.Component1;
            var Cb = pixel.Component2;
            var Cr = pixel.Component3;

            var R = Y + 1.402f * (Cr - 128);
            var G = Y - 0.34414f * (Cb - 128f) - 0.714144f * (Cr - 128f);
            var B = Y + 1.772f * (Cb - 128f);

            result.Component1 = R;
            result.Component2 = G;
            result.Component3 = B;

            return result;
        }

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

        public static FloatPixel FromRGBSinglePixel(FloatPixel pixel)
        {
            var result = new FloatPixel();

            var R = pixel.Component1;
            var G = pixel.Component2;
            var B = pixel.Component3;

            var Y = 0.299f * R + 0.587f * G + 0.114f * B;
            var Cb = 128f - (0.168736f * R) - 0.331264f * G + 0.5f * B;
            var Cr = 128f + 0.5f * R - 0.418688f * G - 0.081312f * B;

            result.Component1 = Y;
            result.Component2 = Cb;
            result.Component3 = Cr;

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
                    result[x, y] = FromRGBSinglePixel(pixel);
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
                    var pixel = new FloatPixel(
                        image[x, y].Component1,
                        image[x, y].Component2,
                        image[x, y].Component3);

                    result[x, y] = pixel;
                }
            }

            return result;
        }

        public FloatPixel[,] ScaleTo256(FloatPixel[,] image)
        {
            return ScaleFrom256(image);
        }

        public bool Check(FloatPixel[,] image)
        {
            var width = image.GetUpperBound(0) + 1;
            var height = image.GetUpperBound(1) + 1;
            var result = new FloatPixel[width, height];

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    var Y = image[x, y].Component1;
                    var Cb = image[x, y].Component2;
                    var Cr = image[x, y].Component3;

                    if (!(0f <= Y && Y <= 255f))
                    {
                        return false;
                    }
                    if (!(0f <= Cb && Cb <= 255f))
                    {
                        return false;
                    }
                    if (!(0f <= Cr && Cr <= 255f))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public string[] GetComponentsNames()
        {
            return new string[] { "Luma", "Blue-difference", "Red-difference" };
        }
    }
}