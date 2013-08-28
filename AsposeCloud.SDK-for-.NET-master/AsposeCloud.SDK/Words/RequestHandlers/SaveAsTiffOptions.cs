
namespace Aspose.Cloud.Words
{
    public class SaveAsTiffOptions
    {
        public bool UseAntiAliasing { get; set; }
        public bool UseHighQualityRendering { get; set; }
        public int PageCount { get; set; }
        public int PageIndex { get; set; }
        public int Resolution { get; set; }
        public TiffCompression TiffCompression;
        public SaveAsTiffOptions()
        {
             UseAntiAliasing = true;
             UseHighQualityRendering = true;
             PageCount = 1;
             PageIndex=1;
             Resolution = 200;
             TiffCompression = TiffCompression.Ccitt3;
        }
        public SaveAsTiffOptions(bool useAntiAliasing, bool useHighQualityRendering, int pageCount, int pageIndex, int resolution, TiffCompression tiffCompression)
        {
            UseAntiAliasing = useAntiAliasing;
            UseHighQualityRendering = useHighQualityRendering;
            PageCount = pageCount;
            PageIndex = pageIndex;
            Resolution = resolution;
            TiffCompression = tiffCompression;
        }
    }
}
