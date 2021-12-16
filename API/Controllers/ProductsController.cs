using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
   
    public class ProductsController:BaseApiController
    {
        public IMapper _mapper { get; }
        private readonly IGenericRepo<Product> _productRepo; 
        private readonly IGenericRepo<ProductBrand> _productBrandRepo;
        private readonly IGenericRepo<ProductType> _productTypeRepo;

        public ProductsController(IMapper _mapper, IGenericRepo<Product> productRepo , IGenericRepo<ProductBrand> productBrandRepo , IGenericRepo<ProductType> productTypeRepo )
        {
            this._mapper = _mapper;
            _productRepo = productRepo;
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>>  GetProducts(int? pageIndex=null,int? take = null)
        {  
          var productSpec = new ProductsWithBrandsAndTypesSpec(orderBy: "priceAsc",pageIndex: pageIndex,take:take);
          var products = await _productRepo.ListAllBySpec(productSpec);
          var data = _mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductToReturnDto>>(products);
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        { 
          var productSpec = new ProductsWithBrandsAndTypesSpec(id);

            var product = await _productRepo.GetEntityBySpec(productSpec);
            var data = _mapper.Map<Product,ProductToReturnDto>(product);
            return Ok(data);
        }
          [HttpGet("brands")]
        public async Task<ActionResult<List<Product>>>  GetProductBrands()
        {
            
           return Ok(null); 
        }
          [HttpGet("types")]
        public async Task<ActionResult<List<Product>>>  GetProductTypes()
        {
            
           return Ok(null); 
        }
        
    }
}