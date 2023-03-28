using ApiDotNet.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ApiDotNet.Infra.Data.repositories
{
	public static class PagedBaseResponseHelper
	{
		public static async Task<TResponse> GetResponseAsync<TResponse, T>
			(IQueryable<T> query, PagedBaseRequest request)
			where TResponse : PagedBaseResponse<T>, new()
		{
			var response = new TResponse();
			var count = await query.CountAsync();
			response.TotalPages = (int)Math.Abs((double)count / request.pageSize);
			response.TotalRegisters = count;

			if (string.IsNullOrEmpty(request.OrderByProperty))
				response.Data = await query.ToListAsync();
			else
				response.Data = query.OrderByDynamic(request.OrderByProperty)
								 .Skip((request.Page - 1) * request.pageSize)
								 .Take(request.pageSize)
								 .ToList();
			return response;
		}

		private static IEnumerable<T> OrderByDynamic<T>(this IEnumerable<T> query, string propertyName)
		{
			return query.OrderBy(x => x.GetType().GetProperty(propertyName).GetValue(x, null));
		}
	}
}
