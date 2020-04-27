using AutoMapper;
using AutoMapper.QueryableExtensions;
using JobSolution.Domain.Auth;
using JobSolution.Domain.Entities;
using JobSolution.Infrastructure.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace JobSolution.Infrastructure.Extensions
{
    public static class QueryableExtensions
    {


        public async static Task<PaginatedResult<TDto>> CreatePaginatedResultAsync<TEntity, TDto>(this IQueryable<TEntity> query, PagedRequest pagedRequest, IMapper mapper, int userId =0)
            where TEntity : BaseEntity
            where TDto : class
        {
            
            query = query.ApplyFilters(pagedRequest);
            query = query.Paginate(pagedRequest);


            if(userId > 0)
            {
                query = query.Where(x => x.Id == userId);
            }


            var total = await query.CountAsync();



            var projectionResult = query.ProjectTo<TDto>(mapper.ConfigurationProvider);

            projectionResult = projectionResult.Sort(pagedRequest);

            var listResult = await projectionResult.ToListAsync();
            return new PaginatedResult<TDto>()
            {
                Items = listResult,
                PageSize = pagedRequest.PageSize,
                PageIndex = pagedRequest.PageIndex,
                Total = total
            };
        }


        private static IQueryable<T> Paginate<T>(this IQueryable<T> query, PagedRequest pagedRequest)
        {
            var entities = query.Skip((pagedRequest.PageIndex) * pagedRequest.PageSize).Take(pagedRequest.PageSize);
            return entities;
        }

        private static IQueryable<T> Sort<T>(this IQueryable<T> query, PagedRequest pagedRequest)
        {
            if (!string.IsNullOrWhiteSpace(pagedRequest.ColumnNameForSorting))
            {
                
                query = query.OrderBy(pagedRequest.ColumnNameForSorting + " " + pagedRequest.SortDirection);
            }
            return query;
        }

        private static IQueryable<T> ApplyFilters<T>(this IQueryable<T> query, PagedRequest pagedRequest)
        {
            var predicate = new StringBuilder();
            var requestFilters = pagedRequest.RequestFilters;
            for (int i = 0; i < requestFilters.Filters.Count; i++)
            {
                if (i > 0)
                {
                    predicate.Append($" {requestFilters.LogicalOperator} ");
                }
                predicate.Append(requestFilters.Filters[i].Path + $".{nameof(string.Contains)}(@{i})");
            }

            if (requestFilters.Filters.Any())
            {
                var propertyValues = requestFilters.Filters.Select(filter => filter.Value).ToArray();

                query = query.Where(predicate.ToString(), propertyValues);
            }

            return query;
        }
    }
}
