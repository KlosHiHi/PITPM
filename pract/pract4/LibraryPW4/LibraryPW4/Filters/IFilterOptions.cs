namespace LibraryPW4.Filters
{
    public interface IFilterOptions
    {
        bool? IsRead { get; set; }
        int? MinPriority { get; set; }
        string? SearchText { get; set; }
    }
}