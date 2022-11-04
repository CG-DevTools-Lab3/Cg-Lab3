using System;

namespace cg22_model.Models.ColorSpacesSpaces
{
    public class RGB : IColorSpace
    {
        public FloatPixel[,] ToRGB(FloatPixel[,] image)
        {
            throw new NotImplementedException();
        }

        public FloatPixel[,] FromRGB(FloatPixel[,] image)
        {
            throw new NotImplementedException();
        }

        public FloatPixel[,] ScaleFrom256(FloatPixel[,] image)
        {
            throw new NotImplementedException();
        }

        public FloatPixel[,] ScaleTo256(FloatPixel[,] image)
        {
            throw new NotImplementedException();
        }

        public bool Check(FloatPixel[,] image)
        {
            throw new NotImplementedException();
        }

        public string[] GetComponentsNames()
        {
            throw new NotImplementedException();
        }
    }
}