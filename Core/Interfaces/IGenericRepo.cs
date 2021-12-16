using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces
{
    public interface IGenericRepo<T> where T : BaseEntity
    {
         Task<T> GetEntityById(int id);
         Task<IReadOnlyList<T>> GetAllAsync();

         Task<T> GetEntityBySpec(ISpecification<T> spec );
         Task<IReadOnlyList<T>> ListAllBySpec(ISpecification<T> spec);
    }
}