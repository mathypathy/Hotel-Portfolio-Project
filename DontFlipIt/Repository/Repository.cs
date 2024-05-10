using DontFlipIt.Context;
using DontFlipIt.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DontFlipIt.Repository
{

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly HotelContext _context;
 

        public  Repository(HotelContext context)
        {
            _context = context;
        
        }
        public async Task<T?> GetById(int id)
        {  

          return await _context.Set<T>().FindAsync(id);

        }


        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task Add(T entity)
        {
            try
            {
                await _context.AddAsync(entity);
                _context.SaveChanges();
                

            }
            catch(Exception ex) 
            {
               
            }
         
        }

    
        public async Task Update(T entity)
        {
             _context.Update(entity);
             await _context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
           _context.Remove(entity);
            await _context.SaveChangesAsync();  
        }
    }
}
