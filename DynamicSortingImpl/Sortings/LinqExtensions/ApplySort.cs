using System.Text;
using System.Linq.Dynamic.Core;
using SourceGenerator.Models;

namespace DynamicSortingImpl.Sortings.LinqExtensions;

public static class ApplySort
{
    public static IQueryable<T> ApplySortCondition<T>(
        this IQueryable<T> query, 
        IList<SortCondition<T>> sortConditions
    )
    {
        Console.WriteLine("[ApplySortCondition]: Applying sort condition");
        if (sortConditions.Count == 0)
        {
            return query;
        }

        var stringBuilders = new StringBuilder();
        foreach (var sort in sortConditions)
        {
            var propertyName = sort?.SortBy;
            if (string.IsNullOrWhiteSpace(propertyName))
            {
                continue;
            }
            var sortOrder = sort?.OrderBy == SortDirection.ASC ? "" : " desc";
            stringBuilders.Append($"it.{propertyName}{sortOrder}, ");
        }
        
        var sortExpression = stringBuilders.ToString();
        sortExpression = sortExpression.TrimEnd(',', ' ');

        return query.OrderBy(sortExpression);
    }
}