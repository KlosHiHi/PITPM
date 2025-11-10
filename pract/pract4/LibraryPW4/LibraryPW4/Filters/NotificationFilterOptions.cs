using LibraryPW4.Models;
using LibraryPW4.Sorts;

namespace LibraryPW4.Filters
{
    public class NotificationFilterOptions : IFilterOptions, ISortedOptions
    {
        public bool? IsRead { get; set; }
        public int? MinPriority { get; set; }
        public string? SearchText { get; set; }
        public string? ColumnName { get; set; }
        public bool Descending { get; set; }
        public NotificationType[]? Types { get; set; }
    }
}