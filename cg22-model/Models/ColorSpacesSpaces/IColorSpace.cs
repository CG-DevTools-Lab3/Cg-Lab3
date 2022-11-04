using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cg22_model.Models.ColorSpacesSpaces
{
    public interface IColorSpace
    {
        FloatPixel[,] ToRGB(FloatPixel[,] image);
        FloatPixel[,] FromRGB(FloatPixel[,] image);
        FloatPixel[,] ScaleFrom256(FloatPixel[,] image);
        FloatPixel[,] ScaleTo256(FloatPixel[,] image);
        bool Check(FloatPixel[,] image);
        string[] GetComponentsNames();
    }
}
