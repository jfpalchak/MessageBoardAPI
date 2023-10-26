using MessageBoardApi.Filters;

namespace MessageBoardApi.Services;

public interface IUriService
{
  public Uri GetPageUri(PaginationFilter filter, string route);
}