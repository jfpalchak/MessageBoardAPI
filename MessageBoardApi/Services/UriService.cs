using MessageBoardApi.Filters;
using Microsoft.AspNetCore.WebUtilities;

namespace MessageBoardApi.Services;

// Our concrete UriService class implements our Interface
public class UriService : IUriService
{
  // We will be getting the base URL (localhost , api.com , etc) in this string,
  // via Dependency Injection from our configurations.
  private readonly string _baseUri;
  public UriService(string baseUri)
  {
    _baseUri = baseUri;
  }

  public Uri GetPageUri(PaginationFilter filter, string route)
  {
    // Makes a new Uri from base uri and route string. ( localhost + /api/messages = localhost/api/messages )
    Uri _enpointUri = new Uri(string.Concat(_baseUri, route));
    // Using the QueryHelpers class (built-in), 
    // we add a new query string, “pageNumber” to our Uri. (localhost/api/messages?pageNumber={i})
    var modifiedUri = QueryHelpers.AddQueryString(_enpointUri.ToString(), "pageNumber", filter.PageNumber.ToString());
    // Similarly, we add another query string, “pageSize”
    modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "pageSize", filter.PageSize.ToString());

    return new Uri(modifiedUri);
  }
}