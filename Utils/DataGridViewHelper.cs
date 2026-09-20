using System.Drawing;
using System.Windows.Forms;

namespace QuanLyKtx.Utils
{
    public static class DataGridViewHelper
    {
        public static void Configure(DataGridView grid)
        {
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            grid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            grid.AllowUserToResizeRows = false;
            grid.ScrollBars = ScrollBars.Both;

            grid.DataBindingComplete -= Grid_DataBindingComplete;
            grid.DataBindingComplete += Grid_DataBindingComplete;
        }

        private static void Grid_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (sender is not DataGridView grid || grid.Columns.Count == 0) return;

            grid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            grid.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);

            foreach (DataGridViewColumn column in grid.Columns)
            {
                if (column.Visible && column.Width < 70)
                {
                    column.Width = 70;
                }
            }
        }
    }
}