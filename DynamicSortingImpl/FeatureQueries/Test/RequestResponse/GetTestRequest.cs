using DynamicSortingImpl.Abstraction;
using DynamicSortingImpl.Entities;
using DynamicSortingImpl.Sortings.Models;

namespace DynamicSortingImpl.FeatureQueries.Test.RequestResponse;

// [AllowSorting]
// [AllowFiltering]
// [AllowPaging]
public class GetTestRequest : ListRequestModel<AbcModel>
{
}