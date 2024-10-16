using System.Text;
using System.Linq.Dynamic.Core;
using DynamicSortingImpl.Sortings.Models;

namespace DynamicSortingImpl.Sortings.LinqExtensions;

public static class ApplySort
{
    public static IQueryable ApplySortCondition(
        this IQueryable query, 
        IList<SortCondition> sortConditions
    )
    {
        if (sortConditions.Count == 0)
        {
            return query;
        }

        var stringBuilders = new StringBuilder();
        foreach (var sort in sortConditions)
        {
            var propertyName = sort?.Field;
            if (string.IsNullOrWhiteSpace(propertyName))
            {
                continue;
            }
            var sortOrder = sort?.Direction == SortDirection.Ascending ? "" : " desc";
            stringBuilders.Append($"it.{propertyName}{sortOrder}, ");
        }
        
        var sortExpression = stringBuilders.ToString();
        sortExpression = sortExpression.TrimEnd(',', ' ');

        return query.OrderBy(sortExpression);
    }
}