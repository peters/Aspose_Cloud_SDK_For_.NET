using System.Collections.Generic;

namespace Aspose.Cloud.Cells
{
    public class ProtectionOptions
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
        public ProtectionOptions()
        { }
        public ProtectionOptions(bool allowDeletingColumn, bool allowDeletingRow, List<string> allowEditArea, bool allowFiltering, bool allowFormattingCell, bool allowFormattingColumn, bool allowFormattingRow, bool allowInsertingColumn, bool allowInsertingHyperlink, bool allowInsertingRow, bool allowSelectingLockedCell, bool allowSelectingUnlockedCell, bool allowSorting, bool allowUsingPivotTable)
        {
            AllowDeletingColumn = allowDeletingColumn;
            AllowDeletingRow = allowDeletingRow;
            AllowEditArea = allowEditArea;
            AllowFiltering = allowFiltering;
            AllowFormattingCell = allowFormattingCell;
            AllowFormattingColumn = allowFormattingColumn;
            AllowFormattingRow = allowFormattingRow;
            AllowInsertingColumn = allowInsertingColumn;
            AllowInsertingHyperlink = allowInsertingHyperlink;
            AllowInsertingRow = allowInsertingRow;
            AllowSelectingLockedCell = allowSelectingLockedCell;
            AllowSelectingUnlockedCell = allowSelectingUnlockedCell;
            AllowSorting = allowSorting;
            AllowUsingPivotTable = allowUsingPivotTable;
        }
    }
    
}
