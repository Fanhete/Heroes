using HeroesAPI.Data;
using HeroesAPI.Models.Entities;
using HeroesAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HeroesAPI.Repositories
{
    public class HeroisSuperpoderesRepository : IHeroisSuperpoderesRepository
    {
        private readonly AppDbContext _context;

        public HeroisSuperpoderesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<HeroisSuperpoderes> AddAsync(HeroisSuperpoderes heroisSuperpoderes)
        {
            _context.Add(heroisSuperpoderes);
            await _context.SaveChangesAsync();

            return heroisSuperpoderes;
        }

        public async Task DeleteAsync(HeroisSuperpoderes heroisSuperpoderes)
        {
            _context.HeroisSuperpoderes.Remove(heroisSuperpoderes);
            await _context.SaveChangesAsync();
        }

        public async Task<List<HeroisSuperpoderes>> GetByHeroiIdAsync(int heroiId)
        {
            return await _context.HeroisSuperpoderes
                .Where(h => h.HeroiId == heroiId)
                .ToListAsync();
        }        
    }
}
