using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public static class SpecificationEvaluator<T> where T:BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery,ISpecification<T> spec)
        {
            var query = inputQuery;

            if(spec.Criteria!=null)
            {
                query.Where(spec.Criteria);
            }

            query = spec.Includes.Aggregate(query,(current,includes) => current.Include(includes));

            if(spec.OrderBy!=null)
            {
                query = query.OrderBy(spec.OrderBy);
            }

            if(spec.OrderByDesc!=null)
            {
               query =  query.OrderByDescending(spec.OrderByDesc);
            }

            if(spec.PaginationEnabled)
            {
                query = query.Skip<T>(spec.Skip).Take<T>(spec.Take);
            }

            return query;

        }
    }
}