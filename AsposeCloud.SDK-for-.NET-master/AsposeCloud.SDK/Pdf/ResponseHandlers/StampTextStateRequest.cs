using System;
using System.Collections.Generic;
using System.Text;

namespace Aspose.Cloud.Pdf
{
    public class StampTextStateRequest
    {
        public float FontSize{get;set;}
    public string Font{get;set;}
    public List<ForegroundColorRequest> foregroundcolorResponse{get;set;} 
    public List<BackgroundColorRequest> backgroundcolorResponse{get;set;}
    public int FontStyle{get;set;}
    }
}
