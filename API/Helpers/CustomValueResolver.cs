using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class CustomValueResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        public IConfiguration _config { get; }
        public CustomValueResolver(IConfiguration config)
        {
            _config = config;
            
        }

        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            return $"{_config["ApiUrl"]}{source.PictureUrl}";
        }
    }
}