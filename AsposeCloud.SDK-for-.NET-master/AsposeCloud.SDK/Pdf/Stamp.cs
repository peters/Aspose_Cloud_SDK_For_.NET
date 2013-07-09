using System;
using System.Collections.Generic;
using System.Text;

namespace Aspose.Cloud.Pdf
{
    public class Stamp
    {
         public Stamp() { }
         public int Type{get;set;}
         public bool Background{get;set;}
         public float BottomMargin{get;set;}
         public int HorizontalAlignment{get;set;}
         public float LeftMargin{get;set;}
         public float Opacity{get;set;}
         public float RightMargin{get;set;}
         public int Rotate{get;set;}
         public float RotateAngle{get;set;}
         public float TopMargin{get;set;}
         public int VerticalAlignment{get;set;}
         public float XIndent{get;set;}
         public float YIndent{get;set;}
         public float Zoom{get;set;}
         public int TextAlignment{get;set;}
         public string TEXT{get;set;}
         public List<StampTextStateRequest>TextState {get;set;}
         public float Width{get;set;}
         public float Height{get;set;}
         public int PageIndex{get;set;}
         public int StartingNumber { get; set; }
        
    }
}
