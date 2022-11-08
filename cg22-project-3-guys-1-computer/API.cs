using cg22_model.Models;
using cg22_model.Models.ColorSpacesSpaces;

namespace cg22_project_3_guys_1_computer;

public static class API
{
    public static FloatImage OpenImage(string path, IColorSpace currentColorSpace)
    {
        var frs = new FileReaderSaver();
        return frs.OpenFile(path, currentColorSpace);
    }

    public static void SaveImage(string path, FloatImage floatImage)
    {
        var frs = new FileReaderSaver();
        frs.SaveAs(path, floatImage);
    }
}