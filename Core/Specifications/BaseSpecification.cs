using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Criteria { get ;set; }
        public List<Expression<Func<T, object>>> Includes { get ;set;} = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> OrderBy { get;set;}
        public Expression<Func<T, object>> OrderByDesc { get;set; }
        public Expression<Func<T, object>> Pagination { get ;set;}
        public int Take { get ;set;}
        public int Skip { get ;set; }
        public bool PaginationEnabled { get ;set;}

        public BaseSpecification()
        {}

        public BaseSpecification(Expression<Func<T,bool>> criteria)
        {
            Criteria = criteria;
        }

        public void AddIncludes(Expression<Func<T,object>> includesExpr)
        {
            Includes.Add(includesExpr);
        }

        public void SetOrderBy(Expression<Func<T,object>> orderByExpr)
        {
            OrderBy = orderByExpr;
        }

          public void SetOrderByDesc(Expression<Func<T,object>> orderByDescExpr)
        {
            OrderBy = orderByDescExpr;
        }

      public void AddPagination(int skip,int take)
      {
          Skip = skip;
          Take = take;
          PaginationEnabled = true;
      }

        
    }
}