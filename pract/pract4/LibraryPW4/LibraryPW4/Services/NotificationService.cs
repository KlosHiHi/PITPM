using LibraryPW4.Filters;
using LibraryPW4.Model;
using System.Linq.Dynamic.Core;

namespace LibraryPW4.Services
{
    public class NotificationService
    {
        public IEnumerable<Notification> FilterAndSort(IEnumerable<Notification> notifications, NotificationFilterOptions options)
        {
            var result = notifications.AsQueryable();

            result = result.OrderBy($"{options.ColumnName} $({(options.Descending ? "DESC" : "")})") ?? result;

            if (options.SearchText is not null)
                result = result.Where(r => r.Title.Contains(options.SearchText));

            if (options.IsRead is not null)
                result = result.Where(r => r.IsRead);

            if (options.MinPriority is not null)
                result = result.Where(r => r.Priority >= options.MinPriority);

            if (options.Types is not null)
                result = result.Where(r => options.Types.Contains(r.Type));

            return result;
        }
    }
}
