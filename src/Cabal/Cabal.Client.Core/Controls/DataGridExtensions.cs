using System.Reflection;
using Microsoft.Windows.Controls;

namespace Cabal.Client.Core.Controls
{
    public static class DataGridExtensions
    {
        public static T GetRowDataItem<T>(this DataGridCell cell)
        {
            PropertyInfo property = typeof(DataGridCell).GetProperty("RowDataItem",
                                                                     BindingFlags.NonPublic | BindingFlags.Instance);
            return (T)property.GetValue(cell, null);
        }
    }
}
