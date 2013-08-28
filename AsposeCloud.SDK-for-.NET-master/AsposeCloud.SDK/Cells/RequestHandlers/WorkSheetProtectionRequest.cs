using System;
using System.Collections.Generic;
using System.Text;

namespace Aspose.Cloud.Cells
{
    public class WorksheetProtectionRequest
    {
        public bool AllowDeletingColumn { get; set; }
        public bool AllowDeletingRow { get; set; }
        public List<string> AllowEditArea { get; set; }
        public bool AllowFiltering { get; set; }
        public bool AllowFormattingCell { get; set; }
        public bool AllowFormattingColumn { get; set; }
        public bool AllowFormattingRow { get; set; }
        public bool AllowInsertingColumn { get; set; }
        public bool AllowInsertingHyperlink { get; set; }
        public bool AllowInsertingRow { get; set; }
        public bool AllowSelectingLockedCell { get; set; }
        public bool AllowSelectingUnlockedCell { get; set; }
        public bool AllowSorting { get; set; }
        public bool AllowUsingPivotTable { get; set; }
        public string Password { get; set; }
        public string ProtectionType { get; set; }
    }
   

}
