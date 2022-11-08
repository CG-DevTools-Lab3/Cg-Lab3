using System;

namespace cg22_model.Models.ColorSpacesSpaces
{
    public class RGB : IColorSpace
    {
        public FloatPixel[,] ToRGB(FloatPixel[,] image)
        {
            return GetNewInstance(image);
        }

        public FloatPixel[,] FromRGB(FloatPixel[,] image)
        {
            return GetNewInstance(image);
        }

        public FloatPixel[,] ScaleFrom256(FloatPixel[,] image)
        {
            return GetNewInstance(image);
        }

        public FloatPixel[,] ScaleTo256(FloatPixel[,] image)
        {
            return GetNewInstance(image);
        }

        public bool Check(FloatPixel[,] image)
        {
            int width = image.GetUpperBound(0) + 1;
            int height = image.GetUpperBound(1) + 1;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var pixel = image[x, y];
                    if (pixel == null)
                        return false;
                    if (pixel.Component1 < 0f || pixel.Component2 < 0f || pixel.Component3 < 0f)
                        return false;
                    if (pixel.Component1 > 255f || pixel.Component2 > 255f || pixel.Component3 > 255f)
                        return false;
                }
            }

            return true;
        }

        public string[] GetComponentsNames()
        {
            return new string[] {"Red", "Green", "Blue"};
        }

        private FloatPixel[,] GetNewInstance(FloatPixel[,] image)
        {
            int width = image.GetUpperBound(0) + 1;
            int height = image.GetUpperBound(1) + 1;
            FloatPixel[,] result = new FloatPixel[width, height];
            float maxVal = 255.0f;
            bool flag = false;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var pixel = image[x, y];
                    var R = pixel.Component1;
                    var G = pixel.Component2;
                    var B = pixel.Component3;

                    if (R > maxVal)
                    {
                        maxVal = R;
                        flag = true;
                    }

                    if (G > maxVal)
                    {
                        maxVal = G;
                        flag = true;
                    }

                    if (B > maxVal)
                    {
                        maxVal = B;
                        flag = true;
                    }
                }
            }

            if (flag)
            {
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        var pixel = image[x, y];
                        var R = (pixel.Component1 / maxVal) * 255f;
                        var G = (pixel.Component2 / maxVal) * 255f;
                        var B = (pixel.Component3 / maxVal) * 255f;
                        if (R < 0f)
                        {
                            R = 0f;
                        }

                        if (G < 0f)
                        {
                            G = 0f;
                        }

                        if (B < 0f)
                        {
                            B = 0f;
                        }

                        result[x, y] = new FloatPixel(R, G, B);
                    }
                }

                return result;
            }

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var pixel = image[x, y];
                    var R = pixel.Component1;
                    var G = pixel.Component2;
                    var B = pixel.Component3;

                    if (R < 0f)
                    {
                        R = 0f;
                    }

                    if (G < 0f)
                    {
                        G = 0f;
                    }

                    if (B < 0f)
                    {
                        B = 0f;
                    }

                    result[x, y] = new FloatPixel(R, G, B);
                }
            }

            return result;
        }
    }
}