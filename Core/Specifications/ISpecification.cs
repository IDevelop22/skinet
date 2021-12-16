using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public interface ISpecification<T> where T : BaseEntity 
    {
        Expression<Func<T,bool>> Criteria {get;set;}
        List<Expression<Func<T,object>>> Includes {get;set;}
        Expression<Func<T,object>> OrderBy{get;set;}
        Expression<Func<T,object>> OrderByDesc {get;set;} 

        int Take {get;set;}
        int Skip{get;set;}
        bool PaginationEnabled{get;set;}

        
    }
}