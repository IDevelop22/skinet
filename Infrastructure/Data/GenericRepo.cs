using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class GenericRepo<T> : IGenericRepo<T> where T : BaseEntity
    {

        private readonly StoreContext _context;

        public GenericRepo(StoreContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetEntityById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetEntityBySpec(ISpecification<T> spec)
        {
            return await ApplySpec(_context.Set<T>(),spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAllBySpec(ISpecification<T> spec)
        {
            return await ApplySpec(_context.Set<T>(),spec).ToListAsync();
        }

        public  IQueryable<T> ApplySpec(IQueryable<T> query,ISpecification<T> spec)
        {
            return   SpecificationEvaluator<T>.GetQuery(query,spec);
        }
    }
}