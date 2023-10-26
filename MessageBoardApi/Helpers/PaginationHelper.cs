using MessageBoardApi.Wrappers;
using MessageBoardApi.Filters;
using MessageBoardApi.Services;

namespace MessageBoardApi.Helpers;

public class PaginationHelper
{
    // @params: paged data from EFCore,
    // filter, total record count, URI service object, and route string of the controller. (/api/messages/)
  public static PagedResponse<List<T>> CreatePagedResponse<T>(List<T> pageData, PaginationFilter validFilter, int totalRecords, IUriService uriService, string route)
  {
    // Initializes the Response Object with required params.
    var response = new PagedResponse<List<T>>(pageData, validFilter.PageNumber, validFilter.PageSize);
    // Some basic math functions to calculate the total pages. (total records / pageSize)
    var totalPages = ((double)totalRecords / (double)validFilter.PageSize);
    int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));

    // We have to generate the next page URL only if a next page exists.
    // We check if the requested page number is less than the total pages and generate the URI for the next page. 
    // If the requested page number is equal to or greater than the total number of available pages, we return null.
    response.NextPage =
      validFilter.PageNumber >= 1 && validFilter.PageNumber < roundedTotalPages
      ? uriService.GetPageUri(new PaginationFilter(validFilter.PageNumber + 1, validFilter.PageSize), route)
      : null;

    // Similarly, we generate the URL for the previous page.
    response.PreviousPage =
      validFilter.PageNumber - 1 >= 1 && validFilter.PageNumber <= roundedTotalPages
      ? uriService.GetPageUri(new PaginationFilter(validFilter.PageNumber -1, validFilter.PageSize), route)
      : null;

    // We generate URLs for the First and Last page by using our URIService.
    response.FirstPage = uriService.GetPageUri(new PaginationFilter(1, validFilter.PageSize), route);
    response.LastPage = uriService.GetPageUri(new PaginationFilter(roundedTotalPages, validFilter.PageSize), route);
    // Set the total pages and total records to the response object.
    response.TotalPages = roundedTotalPages;
    response.TotalRecords = totalRecords;

    return response;
  }
}