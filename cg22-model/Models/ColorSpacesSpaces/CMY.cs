namespace cg22_model.Models.ColorSpacesSpaces
{
    /// <summary>
    /// Class for interaction with images in CMY format
    /// can conver image from CMY to RGB and from RGB to CMY
    /// component1 represents C: Cyan [0; 255]
    /// component2 represents M: Magenta [0; 255]
    /// component3 represents Y: Yellow [0; 255]
    /// </summary>
    public class CMY : IColorSpace
    {
        /// <summary>
        /// Convert CMY image to RGB format
        /// </summary>
        /// <param name="image"> image that you need to conver 
        /// represented with FloatPixel matrix</param>
        /// <returns>Converted image represented with matrix of pixels componentsin RGB format</returns>
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
                    var C = pixel.Component1;
                    var M = pixel.Component2;
                    var Y = pixel.Component3;
                    var R = (1 - C) * 255;
                    var G = (1 - M) * 255;
                    var B = (1 - Y) * 255;
                    result[x, y] = new FloatPixel(R, G, B);
                }
            }
            return result;
        }
        /// <summary>
        /// Convert RGB image to CMY format
        /// </summary>
        /// <param name="image">image that you need to conver 
        /// represented with FloatPixel matrix</param>
        /// <returns>Converted image represented with matrix of pixels components in CMY format</returns>
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
                    var C = 1 - R;
                    var M = 1 - G;
                    var Y = 1 - B;

                    result[x, y] = new FloatPixel(C, M, Y);
                }
            }
            return result;
        }
        /// <summary>
        /// Scales components from RGB intervals [0, 255]
        /// to CMY intervals [0,255]
        /// </summary>
        /// <param name="image">image that you need to conver 
        /// represented with FloatPixel matrix</param>
        /// <returns>Scaled image represented with FloatPixel matrix in CMY intervals</returns>
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
                    result[x, y] = new FloatPixel(pixel.Component1 / 255f, pixel.Component2 / 255f,
                        pixel.Component3 / 255f);
                }
            }
            return result;
        }
        /// <summary>
        /// Scales components from RGB intervals
        /// to CMY intervals
        /// </summary>
        /// <param name="image">image that you need to conver 
        /// represented with FloatPixel matrix</param>
        /// <returns>Scaled image represented with FloatPixel matrix in RGB intervals</returns>
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
                    result[x, y] = new FloatPixel(pixel.Component1 * 255, pixel.Component2 * 255,
                        pixel.Component3 * 255);
                }
            }
            return result;
        }
        /// <summary>
        /// Check that all components is in it's intervals
        /// </summary>
        /// <param name="image">image that you need to conver</param>
        /// <returns>True if all components of all pixels in it's intervals - else False</returns>
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
                    if (pixel.Component2 > 1 || pixel.Component2 < 0)
                    {
                        return false;
                    }
                    if (pixel.Component3 > 1 || pixel.Component3 < 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// Function for getting components names
        /// </summary>
        /// <returns>String array with component names</returns>
        public string[] GetComponentsNames()
        {
            return new string[]
            {
                "Cyan",
                "Magenta",
                "Yellow"
            };
        }
    }
}