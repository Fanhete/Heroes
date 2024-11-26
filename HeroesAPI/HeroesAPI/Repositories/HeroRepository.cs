using HeroesAPI.Data;
using HeroesAPI.Models.Entities;
using HeroesAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HeroesAPI.Repositories
{
    public class HeroRepository : IHeroRepository
    {
        private readonly AppDbContext _context;

        public HeroRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Herois> AddAsync(Herois heroes)
        {
            _context.Add(heroes);
            await _context.SaveChangesAsync();

            return heroes;
        }

        public async Task<Herois> UpdateAsync(Herois heroes)
        {
            _context.Update(heroes);
            await _context.SaveChangesAsync();

            return heroes;
        }

        public async Task DeleteAsync(Herois hereos)
        {
            _context.Remove(hereos);
            await _context.SaveChangesAsync();
        }
        public async Task<Herois> GetbyIdAsync(int id)
        {   
            return await _context.Herois.SingleOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Herois> GetbyNameAsync(string name)
        {
            return await _context.Herois.SingleOrDefaultAsync(d => d.Nome.ToLower() == name.ToLower());
        }   

        public async Task<List<Herois>> GetAllAsync()
        {
            return await _context.Herois.ToListAsync();
        }

    }
}
