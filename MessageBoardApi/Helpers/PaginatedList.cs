using Microsoft.EntityFrameworkCore;

namespace MessageBoardApi.Helpers;

// NOT USED IN THIS PROJECT, USE AS REFERENCE MATERIAL
// An alternative, simpler solution to PaginationHelper
// Set Action params to int pageNumber = 1, int pageSize = {default}
// call: PaginatedList<Object>.CreateAsync()
public class PaginatedList<T> : List<T>
{
  public int PageNumber { get; set; }
  public int TotalPages { get; set; }
  public bool HasPreviousPage => PageNumber > 1;
  public bool HasNextPage => PageNumber < TotalPages;

  public PaginatedList(List<T> items, int count, int pageNumber, int pageSize)
  {
    PageNumber = pageNumber;
    TotalPages = (int)Math.Ceiling(count / (double)pageSize);

    this.AddRange(items);
  }

  public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
  {
    var count = await source.CountAsync();
    var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

    return new PaginatedList<T>(items, count, pageNumber, pageSize);
  }
}