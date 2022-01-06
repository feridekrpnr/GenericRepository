using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Entities.Repositories
{
    public interface IRepository <TEntity> where TEntity:class
    {
       ValueTask<TEntity> GetByIdAsync(int id); //id ye göre
       Task<IEnumerable<TEntity>> GetAllAsync(); //hepsini çağırma

       IEnumerable<TEntity> Find(Expression<Func<TEntity,bool>> predicate);// Expression filtreleme
       
       Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        // tek bir data dön ya single yada default (dönecek değer yoksa 0 döner),Task AddAsync(TEntity entity);
       Task AddAsync(TEntity entity); //bir tane data create edilecek buyüzden liste gerek yok

       Task AddRangeAsync(IEnumerable<TEntity> entities); // belli bir aralıkta değer create etmek için
       void Remove(TEntity entity);
       void RemoveRange(IEnumerable<TEntity> entities); // birden fazla silmek için

       
    }
}
