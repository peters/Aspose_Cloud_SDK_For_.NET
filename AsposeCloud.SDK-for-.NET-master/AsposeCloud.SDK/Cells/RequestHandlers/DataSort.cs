using System.Collections.Generic;

namespace Aspose.Cloud.Cells
{
    public class DataSort
    {
        public DataSort()
        { 
        
        }

        public bool CaseSensitive { get; set; }
        public bool HasHeaders { get; set; }
        public bool SortLeftToRight { get; set; }
        public List <SortKey> KeyList { get; set; }

    }
}
