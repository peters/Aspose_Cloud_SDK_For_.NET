using System.Collections.Generic;

namespace Aspose.Cloud.Cells
{
    public class GradientFill
    {
        public GradientFill()
        { 
        
        }

        public GradientFillType FillType { get; set; }
        public GradientDirectionType DirectionType { get; set; }
        public int Angle { get; set; }
        public List<GradientFillStop> GradientFillStops { get; set; }
        
    }
}
