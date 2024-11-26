using HeroesAPI.Data;
using HeroesAPI.Models.Entities;

namespace HeroesAPI.Repositories.Interfaces
{
    public interface IHeroRepository
    {
        Task<Herois> AddAsync(Herois heroes);
        Task<Herois> UpdateAsync(Herois heroes);
        Task DeleteAsync(Herois hero);
        Task<Herois> GetbyIdAsync(int id);
        Task<Herois> GetbyNameAsync(string name);
        Task<List<Herois>> GetAllAsync();
    }
}
