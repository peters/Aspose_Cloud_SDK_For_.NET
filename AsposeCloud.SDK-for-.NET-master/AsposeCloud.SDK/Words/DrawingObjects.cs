using System;
using System.Collections.Generic;
using System.Text;

namespace Aspose.Cloud.Words
{
    public class DrawingObjects
    {

        public DrawingObjects() { }

        public List<Aspose.Cloud.Words.List> List { get; set; }
        public LinkResponse link { get; set; }
    }

    public class List
    {
        public LinkResponse link { get; set; }
    }
}
