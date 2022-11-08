namespace cg22_model.Models.ColorSpacesSpaces
{
    public class YCoCg : IColorSpace
    /// <summary>
    /// component1 represents Y: Luma [0; 1]
    /// component2 represents Co: Chrominance orange [-1/2; 1/2]
    /// component3 represents Cg: Chrominance green [-1/2; 1/2]
    /// </summary>
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
                    var Co = pixel.Component2;
                    var Cg = pixel.Component3;
                    var R = Y + Co - Cg;
                    var G = Y + Cg;
                    var B = Y - Co - Cg;
                    result[x, y] = new FloatPixel(R * 255, G * 255, B * 255);
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
                    var R = pixel.Component1 / 255;
                    var G = pixel.Component2 / 255;
                    var B = pixel.Component3 / 255;
                    var Y = R / 4 + G / 2 + B / 4;
                    var Co = R / 2 - B / 2;
                    var Cg = -R / 4 + G / 2 - B / 4;
                    result[x, y] = new FloatPixel(Y, Co, Cg);
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
                    var Y = pixel.Component1 / 255f;
                    var Co = pixel.Component2 / 255f - 0.5f;
                    var Cg = pixel.Component3 / 255f - 0.5f;
                    result[x, y] = new FloatPixel(Y, Co, Cg);
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
                    var Y = pixel.Component1 * 255;
                    var Co = (pixel.Component2 + 0.5f) * 255;
                    var Cg = (pixel.Component3 + 0.5f) * 255;
                    result[x, y] = new FloatPixel(Y, Co, Cg);
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
                    if (pixel.Component1 > 1 || pixel.Component1 < 0)
                    {
                        return false;
                    }
                    if (pixel.Component2 > 1 / 2 || pixel.Component2 < -1 / 2)
                    {
                        return false;
                    }
                    if (pixel.Component3 > 1 / 2 || pixel.Component3 < -1 / 2)
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
                "Chrominance orange",
                "Chrominance green"
            };
        }
    }
}