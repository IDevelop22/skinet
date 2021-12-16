using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithBrandsAndTypesSpec : BaseSpecification<Product>
    {
        public ProductsWithBrandsAndTypesSpec()
        {
            
        }
   

        public ProductsWithBrandsAndTypesSpec(int? id=null,string orderBy = null,int? pageIndex=null,int? take = null) : base(id.HasValue? p=>p.Id==id : null )
        {
            AddIncludes(p=>p.ProductBrand);
            AddIncludes(p=>p.ProductType);
            if(!String.IsNullOrEmpty(orderBy))
            {
                switch (orderBy)  
                {
                  case  "priceAsc" :  SetOrderBy(p=>p.Price);
                  break;
                   case  "priceDesc" : SetOrderByDesc(p=>p.Price);
                   break;
                     
                };
            }
            if(pageIndex.HasValue)
            {
                 AddPagination(take.Value * (pageIndex.Value-1),take.Value);
            }
           


        }

    }
}